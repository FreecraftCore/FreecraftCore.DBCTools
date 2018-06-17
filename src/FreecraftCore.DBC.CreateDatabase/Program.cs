using System;
using System.Collections.Async;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Creating table schema if not created.");

			await CreateDatabaseIfNotCreated();

			ParsedDBCFile<SpellDBCEntry<StringDBCReference>> spellDbcFile = await ParseDBCFile<SpellDBCEntry<StringDBCReference>>("Spell.dbc");

			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<LocalizedStringDbcRefToStringTypeConverter>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterType<SpellDbcEntryRefToStringTypeConverter>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterType<StringDBCReferenceToStringTypeConverter>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterInstance(spellDbcFile.StringDatabase)
				.AsImplementedInterfaces()
				.AsSelf();

			IContainer container = builder.Build();

			ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>> converterProvider = container.Resolve<ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>>>();

			await spellDbcFile.RecordDatabase.Split(Environment.ProcessorCount * 2).ToArray().ParallelForEachAsync(async pairs =>
				{
					await AddSpellEntriesToDatabase(pairs.ToArray(), converterProvider)
						.ConfigureAwait(false);
				})
				.ConfigureAwait(false);

			Console.WriteLine($"Finished adding: {spellDbcFile.RecordDatabase.Count} records.");

			Console.WriteLine("Press any key!");
			Console.ReadKey();
		}

		private static async Task CreateDatabaseIfNotCreated()
		{
			DataBaseClientFilesDatabaseContext context = new DataBaseClientFilesDatabaseContext();

			//See this post for why this configuration is occuring below: https://stackoverflow.com/questions/6107206/improving-bulk-insert-performance-in-entity-framework
			context.ChangeTracker.AutoDetectChangesEnabled = false;

			await context.Database.MigrateAsync();
			bool alreadyExists = !await context.Database.EnsureCreatedAsync();
			context.Dispose();

			Console.WriteLine($"Tables Already Existed: {alreadyExists}");
		}

		private static async Task AddSpellEntriesToDatabase([NotNull] IReadOnlyCollection<KeyValuePair<uint, SpellDBCEntry<StringDBCReference>>> entries, [NotNull] ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>> converterProvider)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));
			if(converterProvider == null) throw new ArgumentNullException(nameof(converterProvider));

			foreach(IEnumerable<KeyValuePair<uint, SpellDBCEntry<StringDBCReference>>> spellCollection in entries.Split(5))
			{
				//We create the context several times so that we can reduce inmemory usage.
				//Otherwise Spell.dbc and other large DBCs can use up to a GB of memory.
				using(DataBaseClientFilesDatabaseContext context = new DataBaseClientFilesDatabaseContext())
				{
					//See this post for why this configuration is occuring below: https://stackoverflow.com/questions/6107206/improving-bulk-insert-performance-in-entity-framework
					context.ChangeTracker.AutoDetectChangesEnabled = false;
					context.ChangeTracker.LazyLoadingEnabled = false;

					context.Spell.AddRange(spellCollection.Select(s => converterProvider.Convert(s.Value)).ToArray());

					//Instead of tracking 1,000 and saving we just save after this subcollection.
					await context.SaveChangesAsync(true)
						.ConfigureAwait(false);
				}
			}
		}

		public static async Task<ParsedDBCFile<TDBCEntryType>> ParseDBCFile<TDBCEntryType>(string filePath) 
			where TDBCEntryType : IDBCEntryIdentifiable
		{
			using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				DBCReader<TDBCEntryType> reader = new DBCReader<TDBCEntryType>(fileStream);

				return await reader.ParseDBCFile();
			}
		}
	}
}
