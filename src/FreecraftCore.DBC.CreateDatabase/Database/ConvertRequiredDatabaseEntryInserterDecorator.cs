using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Decorator around a DBC SQL model entry inserter.
	/// This supposes the cases where the file model might be slightly different, maybe different generic type parameters,
	/// and does the conversion before dispatching to the actual inserter.
	/// </summary>
	/// <typeparam name="TDBCFileType">The Type of the file Model.</typeparam>
	/// <typeparam name="TDBCEntryType">The type of the SQL Entry Model.</typeparam>
	public class ConvertRequiredDatabaseEntryInserterDecorator<TDBCFileType, TDBCEntryType> : IDatabaseDbcInsertable<TDBCFileType>
		where TDBCEntryType : IDBCEntryIdentifiable
		where TDBCFileType : IDBCEntryIdentifiable
	{
		private IDatabaseDbcInsertable<TDBCEntryType> DecorateDbcInsertable { get; }
		
		private ITypeConverterProvider<TDBCFileType, TDBCEntryType> DbcTypeConverter { get; }

		static ConvertRequiredDatabaseEntryInserterDecorator()
		{
			//TODO: If you want to enforce same open generic type for both generic args you can check here. Decided not to for now though.
		}

		/// <inheritdoc />
		public ConvertRequiredDatabaseEntryInserterDecorator([NotNull] IDatabaseDbcInsertable<TDBCEntryType> decorateDbcInsertable, ITypeConverterProvider<TDBCFileType, TDBCEntryType> dbcTypeConverter)
		{
			DecorateDbcInsertable = decorateDbcInsertable ?? throw new ArgumentNullException(nameof(decorateDbcInsertable));
			DbcTypeConverter = dbcTypeConverter;
		}

		/// <inheritdoc />
		public Task<int> InsertEntriesAsync(IReadOnlyCollection<TDBCFileType> entries)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));

			return DecorateDbcInsertable.InsertEntriesAsync(entries.Select(DbcTypeConverter.Convert).ToArray());
		}
	}
}
