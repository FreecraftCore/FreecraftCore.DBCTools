using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public sealed class GenericDatabaseDBCEntryInserter<TDBCEntryType> : IDatabaseDbcInsertable<TDBCEntryType>
		where TDBCEntryType : class, IDBCEntryIdentifiable
	{
		/// <summary>
		/// The DB Context to use to inser the entries into.
		/// </summary>
		private DbContext Context { get; }

		/// <summary>
		/// Logger instance.
		/// </summary>
		private ILogger<GenericDatabaseDBCEntryInserter<TDBCEntryType>> Logger { get; }

		/// <inheritdoc />
		public GenericDatabaseDBCEntryInserter([NotNull] DbContext context, [NotNull] ILogger<GenericDatabaseDBCEntryInserter<TDBCEntryType>> logger)
		{
			Context = context ?? throw new ArgumentNullException(nameof(context));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc />
		public async Task<int> InsertEntriesAsync(IReadOnlyCollection<TDBCEntryType> entries)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));
			
			if(Logger.IsEnabled(LogLevel.Information))
				Logger.LogInformation($"Adding: {entries.Count} Type: {typeof(TDBCEntryType).Name}");

			int entryChangeCount = 0;
			foreach(var subEntriesCollection in entries.Split(1000))
			{
				Context.Set<TDBCEntryType>().AddRange(subEntriesCollection.ToArray());

				entryChangeCount += await Context.SaveChangesAsync(true);
			}

			//TODO: fix this r.
			return entryChangeCount;
		}
	}
}
