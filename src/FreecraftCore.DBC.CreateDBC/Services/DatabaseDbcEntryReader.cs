using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	/// <summary>
	/// Database-based DBC <see cref="IDbcEntryReader{TDBCEntryType}"/>.
	/// Will read the DBC entries from the database and spit out
	/// the <see cref="ParsedDBCFile{TDBCEntryType}"/>.
	/// </summary>
	/// <typeparam name="TDBCEntryType">The DBC entry type.</typeparam>
	public sealed class DatabaseDbcEntryReader<TDBCEntryType> : IDbcEntryReader<TDBCEntryType>
		where TDBCEntryType : class, IDBCEntryIdentifiable
	{
		/// <summary>
		/// The Database context.
		/// </summary>
		private DbContext Context { get; }

		/// <inheritdoc />
		public DatabaseDbcEntryReader([NotNull] DbContext context)
		{
			Context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<ParsedDBCFile<TDBCEntryType>> Parse()
		{
			TDBCEntryType[] dbcEntryTypes = await Context.Set<TDBCEntryType>().ToArrayAsync();

			return new ParsedDBCFile<TDBCEntryType>(dbcEntryTypes.ToDictionary(type => type.EntryId));
		}
	}
}
