using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class NonGenericDbcFileGeneratorFillable<TDbcFileType> : IDbcTargetFillable
		where TDbcFileType : IDBCEntryIdentifiable
	{
		private IDbcFileGenerator<TDbcFileType> DbcGenerator { get; }

		private IDbcEntryReader<TDbcFileType> DbcReader { get; }

		/// <inheritdoc />
		public NonGenericDbcFileGeneratorFillable([NotNull] IDbcFileGenerator<TDbcFileType> dbcGenerator, [NotNull] IDbcEntryReader<TDbcFileType> dbcReader)
		{
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
			//So the idea here is we just need to reader the entries and then
			//we write them with the generator
			ParsedDBCFile<TDbcFileType> parsedDbcFile = await DbcReader.Parse();

			await DbcGenerator.WriteEntries(parsedDbcFile.RecordDatabase.Values.ToArray());
		}
	}
}
