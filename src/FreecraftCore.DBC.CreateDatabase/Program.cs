using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;

namespace FreecraftCore
{
	internal class Program
	{
		public static ApplicationConfiguration Config { get; private set; }

		static async Task Main(string[] args)
		{
			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			//TODO: This is just test code, we want to handle inputs better.
			Console.WriteLine($"Will create tables and database if they do not exist.");

			//TODO: We shouldn't check everytime we create a DBC table. Do this elsewhere
			await CreateDatabaseIfNotCreated();

			foreach(string dbcFile in Directory.GetFiles("DBC").Select(Path.GetFileNameWithoutExtension))
			{
				//TODO: Register in IoC
				DbcTypeParser parser = new DbcTypeParser();
				if(!parser.HasDbcType(dbcFile))
				{
					//TODO: We should create a logger specifically for Program.
					if(Config.LoggingLevel > LogLevel.Warning)
						Console.WriteLine($"Encountered unknown DBC Type: {dbcFile}. Will skip.");

					continue;
				}

				//We should check if we know a DBC file of this type.
				IServiceProvider provider = new CreateDatabaseContainerServiceBuilder(Config, dbcFile).Build();

				Stopwatch watch = new Stopwatch();
				watch.Start();
				using(var scope = provider.CreateScope())
				{
					ILogger<Program> logger = scope.ServiceProvider.GetService<ILogger<Program>>();

					try
					{
						if(Config.LoggingLevel > LogLevel.Information)
							logger.LogInformation($"Populating table for DBC: {dbcFile}");

						//This may look silly but we want to support the 50+ DBC types so
						//it needs to be handle magically otherwise we'd have to write code for each one.
						IDbcTargetFillable tableFiller = scope.ServiceProvider.GetService<IDbcTargetFillable>();

						await tableFiller.FillAsync();
					}
					catch(Exception e)
					{
						if(logger.IsEnabled(LogLevel.Error))
							logger.LogError($"Encountered Exception: {e.Message} \n\n Stack: {e.StackTrace}");

						throw;
					}
				}

				watch.Stop();

				if(Config.LoggingLevel > LogLevel.Information)
					Console.WriteLine($"Created Table: {dbcFile} In Milliseconds: {watch.ElapsedMilliseconds}");
			}

			Console.WriteLine("Finished. Press any key!");
			Console.ReadKey();
		}

		private static async Task CreateDatabaseIfNotCreated()
		{
			ContainerBuilder builder = new ContainerBuilder();
			ServiceCollection serviceCollection = new ServiceCollection();

			serviceCollection.RegisterDatabaseServices(Config.DatabaseConnectionString);
			serviceCollection.RegisterDBContextOptions(Config.DatabaseConnectionString);
			builder.Populate(serviceCollection);

			using(IServiceScope scope = new AutofacServiceProvider(builder.Build()).CreateScope())
			using(DbContext context = scope.ServiceProvider.GetService<DbContext>())
			{
				await context.Database.EnsureCreatedAsync();
				await context.Database.MigrateAsync();
			}
		}
	}
}
