using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Fasterflect;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	/// <summary>
	/// Abstract base for all generic string DBC models
	/// that require conversions. They all need to convert strings or localized strings
	/// so this simplfies the type creation.
	/// </summary>
	/// <typeparam name="TDbcFromType"></typeparam>
	/// <typeparam name="TDbcToType"></typeparam>
	public class DbcStringToRefTypeConverter<TDbcFromType, TDbcToType> : ITypeConverterProvider<TDbcFromType, TDbcToType>
		where TDbcFromType : IDBCEntryIdentifiable
		where TDbcToType : IDBCEntryIdentifiable, new()
	{
		protected ITypeConverterProvider<LocalizedStringDBC<string>, LocalizedStringDBC<StringDBCReference>> LocalizedStringConverter { get; }

		protected ITypeConverterProvider<string, StringDBCReference> StringReferenceConverter { get; }

		private ILogger<DbcStringToRefTypeConverter<TDbcFromType, TDbcToType>> Logger { get; }

		private static MemberInfo[] ComputeSerializableMembers<T>()
		{
			return ComputeSerializableMembers(typeof(T));
		}

		private static MemberInfo[] ComputeSerializableMembers(Type type)
		{
			return type
				.MembersWith(MemberTypes.Property, typeof(WireMemberAttribute))
				.ToArray();
		}

		/// <inheritdoc />
		public DbcStringToRefTypeConverter([NotNull] ITypeConverterProvider<LocalizedStringDBC<string>, LocalizedStringDBC<StringDBCReference>> localizedStringConverter, [NotNull] ITypeConverterProvider<string, StringDBCReference> stringReferenceConverter, ILogger<DbcStringToRefTypeConverter<TDbcFromType, TDbcToType>> logger)
		{
			LocalizedStringConverter = localizedStringConverter ?? throw new ArgumentNullException(nameof(localizedStringConverter));
			StringReferenceConverter = stringReferenceConverter ?? throw new ArgumentNullException(nameof(stringReferenceConverter));
			Logger = logger;
		}

		/// <inheritdoc />
		public TDbcToType Convert(TDbcFromType fromObject)
		{
			TDbcToType entry = new TDbcToType();

			//TODO: Refactor this to generic so it can shared with CreateDatabase project
			//We use reflection now to set members, it is fast with fasterflect
			foreach(MemberInfo mi in entry.GetType().MembersWith(MemberTypes.Property, typeof(WireMemberAttribute)))
			{
				//THIS IS WRONG. WE HAVE TO DO NON-MAPPED BECAUSE THEY WILL BE NULL OTHERWISE
				//So, for table to file there may be some unmapped but serializable fields (probably set with defaults)
				//and we need to NOT try to set or read these non-mapped fields. It should remain the default values assigned
				//if you do try you'll get exceptions.
				//if(mi.HasAttribute<NotMappedAttribute>())
				//	continue;

				//Strings need special handling
				if(mi.Type() == typeof(LocalizedStringDBC<StringDBCReference>))
				{
					try
					{
						entry.SetPropertyValue(mi.Name, LocalizedStringConverter.Convert((LocalizedStringDBC<string>)fromObject.GetPropertyValue(mi.Name)));
					}
					catch(Exception e)
					{
						Logger.LogError($"Failed to convert Member: {mi.Name} on Type: {mi.DeclaringType} from Value: {(LocalizedStringDBC<string>)fromObject.GetPropertyValue(mi.Name)} Exception: {e.Message}");
						throw;
					}
				}
				else if (mi.Type() == typeof(StringDBCReference))
				{
					try
					{
						entry.SetPropertyValue(mi.Name, StringReferenceConverter.Convert((string)fromObject.GetPropertyValue(mi.Name)));
					}
					catch(Exception e)
					{
						Logger.LogError($"Failed to convert Member: {mi.Name} on Type: {mi.DeclaringType} from Value: {(LocalizedStringDBC<string>)fromObject.GetPropertyValue(mi.Name)} Exception: {e.Message}");
						throw;
					}
				}
				else if(mi.Type().Name.Contains("GenericStaticallySizedArrayChunk") && mi.Type().GenericTypeArguments[0] == typeof(StringDBCReference))
				{
					object arrayObject = Activator.CreateInstance(mi.Type());

					//for types with GenericStaticallySizedArrayChunk so we can set the members
					foreach(MemberInfo arrayChunkMemberInfo in ComputeSerializableMembers(mi.Type()))
						arrayObject.SetPropertyValue(arrayChunkMemberInfo.Name, StringReferenceConverter.Convert((string)fromObject.GetPropertyValue(mi.Name).GetPropertyValue(arrayChunkMemberInfo.Name)));

					entry.SetPropertyValue(mi.Name, arrayObject);
				}
				else
					//Sets the entry with the value from the original object.
					entry.SetPropertyValue(mi.Name, fromObject.GetPropertyValue(mi.Name));
			}

			return entry;
		}
	}
}
