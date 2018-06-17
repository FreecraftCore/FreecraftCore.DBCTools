using System;
using System.Diagnostics;
using System.IO;
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

			ParsedDBCFile<SpellDBCEntry<StringDBCReference>> spellDbcFile = await ParseDBCFile<SpellDBCEntry<StringDBCReference>>("Spell.dbc");

			foreach(var spell in spellDbcFile.RecordDatabase)
			{
				
			}

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
