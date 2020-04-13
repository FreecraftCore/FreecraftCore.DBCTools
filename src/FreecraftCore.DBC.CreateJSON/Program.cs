using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace FreecraftCore
{
	internal class Program
	{
		private static ApplicationConfiguration Config { get; set; }

		public static async Task Main(string[] args)
		{
			Console.WriteLine(DBCToolsExtensions.BuildToolsWelcomeMessage("CreateJSON"));

			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			if (!Directory.Exists(Config.DiffOutputPath))
				Directory.CreateDirectory(Config.DiffOutputPath);

			Parallel.ForEach(Directory.GetFiles(Config.DbcOutputPath).Select(Path.GetFileNameWithoutExtension), async dbcFile =>
			{
				DbcTypeParser parser = new DbcTypeParser();
				if(!parser.HasDbcType(dbcFile))
				{
					//TODO: We should create a logger specifically for Program.
					if(Config.LoggingLevel >= LogLevel.Warning)
						Console.WriteLine($"Encountered unknown DBC Type: {dbcFile}. Will skip.");

					return;
				}

				IServiceProvider provider = new JSONContainerServiceBuilder(Config, dbcFile).Build();

				using(var scope = provider.CreateScope())
				{
					ILogger<Program> logger = scope.ServiceProvider.GetService<ILogger<Program>>();

					try
					{
						if(logger.IsEnabled(LogLevel.Information))
							logger.LogInformation($"Populating CSV file for DBC: {dbcFile}");

						//This may look silly but we want to support the 50+ DBC types so
						//it needs to be handle magically otherwise we'd have to write code for each one.
						IDbcTargetFillable tableFiller = scope.ServiceProvider.GetService<IDbcTargetFillable>();

						await tableFiller.FillAsync()
							.ConfigureAwait(false);
					}
					catch(Exception e)
					{
						if(logger.IsEnabled(LogLevel.Error))
							logger.LogError($"Encountered Exception: {e.Message} \n\n Stack: {e.StackTrace}");

						throw;
					}
				}
			});

			Console.WriteLine("Finished. Press any key!");
		}
	}
}
