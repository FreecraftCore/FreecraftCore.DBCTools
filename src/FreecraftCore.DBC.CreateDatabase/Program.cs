using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace FreecraftCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Creating table schema if not created.");

			ParsedDBCFile<SpellDBCEntry<StringDBCReference>> spellDbcFile = await ParseDBCFile<SpellDBCEntry<StringDBCReference>>("Spell.dbc");

			IServiceCollection serviceCollection = new ServiceCollection();
			ContainerBuilder builder = new ContainerBuilder();

			serviceCollection.AddEntityFrameworkMySql();
			serviceCollection.AddDbContext<DataBaseClientFilesDatabaseContext>(options =>
			{
				//TODO: When OnConfiguring no longer has this we should renable this
				options.UseMySql("Server=localhost;Database=client.dbc;Uid=root;Pwd=test;", optionsBuilder =>
				{
					optionsBuilder.MaxBatchSize(4000);
					optionsBuilder.MinBatchSize(20);
					optionsBuilder.EnableRetryOnFailure(5);
					optionsBuilder.CommandTimeout(1000);
				});

				options.EnableSensitiveDataLogging();
			});

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

			builder.Populate(serviceCollection);

			//TODO: Make logging optional
			//ILoggerFactory loggerFactory = new LoggerFactory()
			//	.AddFile($"{"Logs/Dump-{Date}"}-{Guid.NewGuid()}.txt", LogLevel.Trace);

			//builder.RegisterInstance(loggerFactory)
			//	.As<ILoggerFactory>();
			
			IServiceProvider container = new AutofacServiceProvider(builder.Build());

			ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>> converterProvider = container.GetRequiredService<ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>>>();
			using(var scope = container.CreateScope())
			{
				DataBaseClientFilesDatabaseContext context = scope.ServiceProvider.GetService<DataBaseClientFilesDatabaseContext>();
				await CreateDatabaseIfNotCreated(context);
			}

			Stopwatch watch = new Stopwatch();
			watch.Start();
			using(var scope = container.CreateScope())
			{
				DataBaseClientFilesDatabaseContext context = scope.ServiceProvider.GetService<DataBaseClientFilesDatabaseContext>();
				//See this post for why this configuration is occuring below: https://stackoverflow.com/questions/6107206/improving-bulk-insert-performance-in-entity-framework
				context.ChangeTracker.AutoDetectChangesEnabled = false;
				context.ChangeTracker.LazyLoadingEnabled = false;
				context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

				try
				{
					foreach(var spellCollection in spellDbcFile.RecordDatabase.Values.Split(spellDbcFile.RecordDatabase.Count / 3000).ToArray())
						await AddSpellEntriesToDatabase(spellCollection.ToArray(), converterProvider, context)
							.ConfigureAwait(false);
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}
			
			
			watch.Stop();

			Console.WriteLine($"Finished adding: {spellDbcFile.RecordDatabase.Count} records. Time: {watch.ElapsedMilliseconds}");

			Console.WriteLine("Press any key!");
			Console.ReadKey();
		}

		private static async Task CreateDatabaseIfNotCreated(DataBaseClientFilesDatabaseContext context)
		{
			await context.Database.MigrateAsync();
			await context.Database.EnsureCreatedAsync();
		}

		private static Task AddSpellEntriesToDatabase(
			[NotNull] SpellDBCEntry<StringDBCReference>[] entries, 
			[NotNull] ITypeConverterProvider<SpellDBCEntry<StringDBCReference>, SpellDBCEntry<string>> converterProvider,
			[NotNull] DataBaseClientFilesDatabaseContext context)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));
			if(converterProvider == null) throw new ArgumentNullException(nameof(converterProvider));
			if(context == null) throw new ArgumentNullException(nameof(context));

			//TODO: This probably should not be async
			context.Spell.AddRange(entries.Select(converterProvider.Convert));

			Console.WriteLine("Saving changes.");

			//Pass true to call AcceptAllChanges
			//This tells EF to release storage of changes and entites.
			return context.SaveChangesAsync(true);
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
