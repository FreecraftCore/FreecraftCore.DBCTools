using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Fasterflect;
using FreecraftCore.Serializer;
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
	public class DbcRefToStringTypeConverter<TDbcFromType, TDbcToType> : ITypeConverterProvider<TDbcFromType, TDbcToType>
		where TDbcFromType : IDBCEntryIdentifiable
		where TDbcToType : IDBCEntryIdentifiable, new()
	{
		protected ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> LocalizedStringConverter { get; }

		protected ITypeConverterProvider<StringDBCReference, string> StringReferenceConverter { get; }

		/// <summary>
		/// Cached reflected <see cref="MemberInfo"/>
		/// </summary>
		public static IReadOnlyCollection<MemberInfo> OriginalSerializableMemberInfos { get; }
			= typeof(TDbcToType)
				.MembersWith(MemberTypes.Property, typeof(WireMemberAttribute))
				.ToArray();

		/// <inheritdoc />
		public DbcRefToStringTypeConverter([NotNull] ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> localizedStringConverter, [NotNull] ITypeConverterProvider<StringDBCReference, string> stringReferenceConverter)
		{
			LocalizedStringConverter = localizedStringConverter ?? throw new ArgumentNullException(nameof(localizedStringConverter));
			StringReferenceConverter = stringReferenceConverter ?? throw new ArgumentNullException(nameof(stringReferenceConverter));
		}
		/// <inheritdoc />
		public TDbcToType Convert(TDbcFromType fromObject)
		{
			TDbcToType entry = new TDbcToType();

			//We use reflection now to set members, it is fast with fasterflect
			foreach(MemberInfo mi in OriginalSerializableMemberInfos)
			{
				//TODO: The set and get might be slow. We could build a table for this.
				//Strings need special handling
				if(mi.Type() == typeof(LocalizedStringDBC<string>))
				{
					entry.SetPropertyValue(mi.Name, LocalizedStringConverter.Convert((LocalizedStringDBC<StringDBCReference>)fromObject.GetPropertyValue(mi.Name)));
				}
				else if (mi.Type() == typeof(string))
					//Sets the entry with the value from the original object.
					entry.SetPropertyValue(mi.Name, StringReferenceConverter.Convert((StringDBCReference) fromObject.GetPropertyValue(mi.Name)));
				else
					entry.SetPropertyValue(mi.Name, fromObject.GetPropertyValue(mi.Name)); //else it's a normal field so it should directly be set.
			}

			return entry;
		}
	}
}
