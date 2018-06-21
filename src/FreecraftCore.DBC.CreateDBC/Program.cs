using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	class Program
	{
		public static ApplicationConfiguration Config { get; private set; }

		static async Task Main(string[] args)
		{
			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			DbcTypeParser dbcTypeParser = new DbcTypeParser();

			//For each implement DBCType we should try to build a DBC file for it.
			foreach(Type dbcType in dbcTypeParser.ComputeAllKnownDbcTypes())
			{
				string dbcName = dbcTypeParser.GetDbcName(dbcType);
				IServiceProvider provider = new CreateDbcContainerServiceBuilder(Config, dbcType).Build();

				using(IServiceScope scope = provider.CreateScope())
				{
					IDbcTargetFillable fillable = scope.ServiceProvider.GetService<IDbcTargetFillable>();

					await fillable.FillAsync();

					using(Stream ms = scope.ServiceProvider.GetRequiredService<Stream>())
					{
						//it is important to reset this position
						//Since we're 20 bytes in after likely writing the header last
						//Though the above statement could change, either way we want to be at the begining.
						ms.Position = 0;

						//It is possible nothing has been written, this is kinda hacky to put this
						//and leak this in a couple places. But it means no entires were found.
						if(ms.Length == 0)
							continue;

						//Once everything has been filled we should create the file
						using(FileStream fs = new FileStream($"{Config.DbcOutputPath}/{dbcName}.dbc", FileMode.Create, FileAccess.Write))
						{
							await ms.CopyToAsync(fs);
						}
					}
				}
			}

			Console.ReadKey();
		}
	}
}
