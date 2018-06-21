using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class GenericDbcFileGeneratorFillable<TDbcFileType, TDbcEntryType> : IDbcTargetFillable
		where TDbcFileType : IDBCEntryIdentifiable 
		where TDbcEntryType : IDBCEntryIdentifiable
	{
		private ITypeConverterProvider<TDbcEntryType, TDbcFileType> ModelConverter { get; }

		private IDbcFileGenerator<TDbcFileType> DbcGenerator { get; }

		private IDbcEntryReader<TDbcEntryType> DbcReader { get; }

		/// <inheritdoc />
		public GenericDbcFileGeneratorFillable([NotNull] ITypeConverterProvider<TDbcEntryType, TDbcFileType> modelConverter, [NotNull] IDbcFileGenerator<TDbcFileType> dbcGenerator, [NotNull] IDbcEntryReader<TDbcEntryType> dbcReader)
		{
			ModelConverter = modelConverter ?? throw new ArgumentNullException(nameof(modelConverter));
			DbcGenerator = dbcGenerator ?? throw new ArgumentNullException(nameof(dbcGenerator));
			DbcReader = dbcReader ?? throw new ArgumentNullException(nameof(dbcReader));
		}

		/// <inheritdoc />
		public void Fill()
		{
			FillAsync().ConfigureAwait(false).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task FillAsync()
		{
			//For generics we actuall have to convert the models we read
			//before we can write them
			//This is because of strings mostly

			//This actually isn't a parsed DBC file. We use the same
			//interface for table reading.
			ParsedDBCFile<TDbcEntryType> parsedDbcFile = await DbcReader.Parse();

			//Dispatches the converted models to the generator.
			await DbcGenerator.WriteEntries(parsedDbcFile.RecordDatabase.Values.Select(ModelConverter.Convert).ToArray());
		}
	}
}
