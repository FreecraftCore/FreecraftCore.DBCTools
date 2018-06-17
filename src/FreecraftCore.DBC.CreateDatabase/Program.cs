using System;
using System.Threading.Tasks;

namespace FreecraftCore.DBC.CreateDatabase
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Creating table schema if not created.");
			
			DataBaseClientFilesDatabaseContext context = new DataBaseClientFilesDatabaseContext();

			bool alreadyExists = !await context.Database.EnsureCreatedAsync();

			Console.WriteLine($"Tables Already Existed: {alreadyExists}");
			Console.WriteLine("Press any key!");

			Console.ReadKey();
		}
	}
}
