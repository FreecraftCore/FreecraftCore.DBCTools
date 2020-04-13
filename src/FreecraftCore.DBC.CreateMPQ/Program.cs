using System;
using System.IO;
using StormLibSharp;

namespace FreecraftCore.DBC.CreateMPQ
{
	class Program
	{
		public static ApplicationConfiguration Config { get; private set; }

		static void Main(string[] args)
		{
			Console.WriteLine(DBCToolsExtensions.BuildToolsWelcomeMessage("CreateMPQ"));

			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			//Now we want to search the entire output directory
			//for DBC files and stick them in the MPQ.

			string[] dbcFileNames = Directory.GetFiles(Config.DbcOutputPath);

			if (!Directory.Exists(Config.MpqOutputPath))
				Directory.CreateDirectory(Config.MpqOutputPath);

			string fullFilePath = Path.Combine(Config.MpqOutputPath, $"{Config.MpqOutputName}.MPQ");

			//If the MPQ already exists, then delete it
			if (File.Exists(fullFilePath))
				File.Delete(fullFilePath);

			//Creates an MPQ with length of dbc files at the MPQ output directory.
			using(MpqArchive mpq = MpqArchive.CreateNew(fullFilePath, MpqArchiveVersion.Version2, MpqFileStreamAttributes.None, MpqFileStreamAttributes.CreateAttributesFile, dbcFileNames.Length))
			{
				foreach(string dbc in dbcFileNames)
				{
					mpq.AddFileFromDiskWithCompression(dbc, Path.Combine("DBFilesClient", Path.GetFileName(dbc)), MpqCompressionTypeFlags.MPQ_COMPRESSION_ZLIB);
				}
			}

			Console.WriteLine("Finished");
		}
	}
}
