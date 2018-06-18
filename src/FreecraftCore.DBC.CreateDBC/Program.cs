using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	class Program
	{
		static async Task Main(string[] args)
		{
			ServiceCollection serviceCollection = new ServiceCollection();
			RegisterDatabaseServices(serviceCollection);

			ContainerBuilder container = new ContainerBuilder();

			container.Populate(serviceCollection);

			IServiceProvider serviceProvider = new AutofacServiceProvider(container.Build());

			DbContext context = serviceProvider.GetService<DbContext>();

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			ItemEntry[] entries = await context.Set<ItemEntry>()
				.ToAsyncEnumerable()
				.ToArray();

			Console.WriteLine($"Loaded: {entries.Length} Items.");

			stopWatch.Stop();
			Console.WriteLine($"Time Elapsed: {stopWatch.ElapsedMilliseconds}");

			//Write Item DBC
			using(FileStream fs = new FileStream(@"DBC_Output/Item.dbc", FileMode.CreateNew, FileAccess.Write))
			{
				DbcEntryWriter<ItemEntry> itemWriter = new DbcEntryWriter<ItemEntry>(fs);

				await itemWriter.WriteEntries(entries);
			}

			Console.ReadKey();
		}

		private static IServiceCollection RegisterDatabaseServices(IServiceCollection serviceCollection)
		{
			//TODO: We should support database connection strings in a config file.
			serviceCollection.AddEntityFrameworkMySql();
			serviceCollection.AddDbContext<DbContext, DataBaseClientFilesDatabaseContext>(options =>
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

			return serviceCollection;
		}
	}
}
