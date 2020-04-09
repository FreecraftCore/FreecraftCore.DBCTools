using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace FreecraftCore
{
	/// <summary>
	/// Simplfied the reading of a DBC file from a file.
	/// </summary>
	public sealed class GenericDbcFileEntryReader<TDBCEntryType> : IDbcEntryReader<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		private string FilePath { get; }

		private ILogger<DBCEntryReader<TDBCEntryType>> Logger { get; }
 
		public GenericDbcFileEntryReader([NotNull] string filePath, [NotNull] ILogger<DBCEntryReader<TDBCEntryType>> logger)
		{
			FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<ParsedDBCFile<TDBCEntryType>> Parse()
		{
			using(FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
			{
				SerializerService serializer = new SerializerService();
				foreach (Type t in DBCEntryReader.RequiredSerializeableTypes)
					serializer.RegisterType(t);

				serializer.RegisterType<TDBCEntryType>();
				serializer.Compile();

				//TODO: How should we provide logger better than this?
				DBCEntryReader<TDBCEntryType> reader = new DBCEntryReader<TDBCEntryType>(fileStream, serializer);

				return await reader.Parse();
			}
		}
	}
}
