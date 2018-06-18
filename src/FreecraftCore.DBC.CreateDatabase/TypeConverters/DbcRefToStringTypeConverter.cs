using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Abstract base for all generic string DBC models
	/// that require conversions. They all need to convert strings or localized strings
	/// so this simplfies the type creation.
	/// </summary>
	/// <typeparam name="TDbcFromType"></typeparam>
	/// <typeparam name="TDbcToType"></typeparam>
	public abstract class DbcRefToStringTypeConverter<TDbcFromType, TDbcToType> : ITypeConverterProvider<TDbcFromType, TDbcToType>
		where TDbcFromType : IDBCEntryIdentifiable
		where TDbcToType : IDBCEntryIdentifiable
	{
		protected ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> LocalizedStringConverter { get; }

		protected ITypeConverterProvider<StringDBCReference, string> StringReferenceConverter { get; }

		/// <inheritdoc />
		protected DbcRefToStringTypeConverter([NotNull] ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> localizedStringConverter, [NotNull] ITypeConverterProvider<StringDBCReference, string> stringReferenceConverter)
		{
			LocalizedStringConverter = localizedStringConverter ?? throw new ArgumentNullException(nameof(localizedStringConverter));
			StringReferenceConverter = stringReferenceConverter ?? throw new ArgumentNullException(nameof(stringReferenceConverter));
		}
		/// <inheritdoc />
		public abstract TDbcToType Convert(TDbcFromType fromObject);
	}
}
