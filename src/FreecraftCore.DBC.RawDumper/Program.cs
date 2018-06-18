using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Fasterflect;
using Newtonsoft.Json;

namespace FreecraftCore.DBC.RawDumper
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.Write($"Enter DBC file Name without extension: ");
			string fileName = Console.ReadLine();

			try
			{
				//TODO: Handle incorrect input
				//Once we know the file name we should know
				//the DBC record type we will need to work with
				Type recordType = typeof(DBCHeader).Assembly
					.GetExportedTypes()
					.First(t => t.GetCustomAttribute<TableAttribute>()?.Name.ToLower() == fileName.ToLower());

				//DBC might be generic string
				if(recordType.IsGenericType && !recordType.IsConstructedGenericType)
					recordType = recordType.MakeGenericType(typeof(StringDBCReference));

				//Now we can call dump
				await (Task)typeof(Program).GetMethod(nameof(DumpDBCTable))
					.MakeGenericMethod(recordType)
					.Invoke(null, new object[1] { $"{fileName}.dbc" });
			}
			catch(Exception e)
			{
				Console.WriteLine($"Exception: {e.Message} \n\n Stack: {e.StackTrace}");
				Console.ReadKey();
			}
		}

		public static async Task DumpDBCTable<TDBCEntryType>(string filePath)
			where TDBCEntryType : IDBCEntryIdentifiable
		{

			Stopwatch watch = new Stopwatch();
			ParsedDBCFile<TDBCEntryType> dbc = await ParseDBCFile<TDBCEntryType>(filePath, watch);
			watch.Stop();

			Console.WriteLine($"Loaded {filePath} in Milliseconds: {watch.ElapsedMilliseconds}");

			//Just dump it to a file
			// serialize JSON directly to a file
			using(StreamWriter file = File.CreateText($"Dump-{Path.GetFileNameWithoutExtension(filePath)}-{Guid.NewGuid().ToString()}.txt"))
			{
				JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
				serializer.Serialize(file, dbc);
			}
		}

		private static async Task<ParsedDBCFile<TDBCEntryType>> ParseDBCFile<TDBCEntryType>(string filePath, Stopwatch watch) where TDBCEntryType : IDBCEntryIdentifiable
		{
			ParsedDBCFile<TDBCEntryType> dbc = null;
			using(FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				DBCEntryReader<TDBCEntryType> reader = new DBCEntryReader<TDBCEntryType>(fileStream);

				watch.Start();
				dbc = await reader.Parse();
			}

			return dbc;
		}
	}
}
