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
			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			//Now we want to search the entire output directory
			//for DBC files and stick them in the MPQ.

			string[] dbcFileNames = Directory.GetFiles(Config.DbcOutputPath);

			//Creates an MPQ with length of dbc files at the MPQ output directory.
			using(MpqArchive mpq = MpqArchive.CreateNew(Path.Combine(Config.MpqOutputPath, $"{Config.MpqOutputName}.MPQ"), MpqArchiveVersion.Version2, MpqFileStreamAttributes.None, MpqFileStreamAttributes.None, dbcFileNames.Length))
			{
				foreach(string dbc in dbcFileNames)
				{
					mpq.AddFileFromDiskWithCompression(dbc, Path.Combine("DBClientFiles", Path.GetFileName(dbc)), MpqCompressionTypeFlags.MPQ_COMPRESSION_ZLIB);
				}
			}
		}
	}
}
