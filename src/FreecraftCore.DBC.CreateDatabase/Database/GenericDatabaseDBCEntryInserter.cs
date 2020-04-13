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

			//https://stackoverflow.com/questions/41736995/entityframework-insert-speed-is-very-slow-with-large-quantity-of-data
			//This should speed up insert considerably.
			Context.ChangeTracker.AutoDetectChangesEnabled = false;
		}

		/// <inheritdoc />
		public async Task<int> InsertEntriesAsync(IReadOnlyCollection<TDBCEntryType> entries)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));
			
			if(Logger.IsEnabled(LogLevel.Information))
				Logger.LogInformation($"Adding: {entries.Count} Type: {typeof(TDBCEntryType).Name}");

			//This prevents inserting into the DB if there are ANY entries.
			if (await Context.Set<TDBCEntryType>().AnyAsync())
			{
				if(Logger.IsEnabled(LogLevel.Warning))
					Logger.LogInformation($"Insertion for Table: {typeof(TDBCEntryType).Name} skipped. Table is non-empty.");

				return 0;
			}

			//TODO: Improve the performance of this
			await Context.Set<TDBCEntryType>().AddRangeAsync(entries);

			return await Context.SaveChangesAsync(true);
		}
	}
}
