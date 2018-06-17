using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore.DBC.CreateDatabase
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Creating table schema if not created.");

			DataBaseClientFilesDatabaseContext context = new DataBaseClientFilesDatabaseContext();

			//See this post for why this configuration is occuring below: https://stackoverflow.com/questions/6107206/improving-bulk-insert-performance-in-entity-framework
			context.ChangeTracker.AutoDetectChangesEnabled = false;

			await context.Database.MigrateAsync();
			bool alreadyExists = !await context.Database.EnsureCreatedAsync();

			Console.WriteLine($"Tables Already Existed: {alreadyExists}");

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

			//Everyone 1,000 entries we save
			int addCount = 0;
			foreach(KeyValuePair<uint, SpellDBCEntry<StringDBCReference>> spell in spellDbcFile.RecordDatabase)
			{
				SpellDBCEntry<string> entry = converterProvider.Convert(spell.Value);

				if(entry == null)
					throw new InvalidOperationException($"Failed to convert DBC Spell to SQL Spell Id: {spell.Key}");

				Console.WriteLine($"Adding Id: {spell.Key}");

				//Now it's converted, we should send it to the database
				await context.Spell.AddAsync(entry);
				addCount++;

				if(addCount > 1000)
				{
					addCount = 0;
					await context.SaveChangesAsync(true);
				}
			}

			int addCounted = await context.SaveChangesAsync();

			Console.WriteLine($"Added: {addCounted} rows of Spells from Spell.dbc");

			Console.WriteLine("Press any key!");
			Console.ReadKey();
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
