using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Converts <see cref="SpellRangeEntry{StringDBCReference}"/> to <see cref="SpellRangeEntry{string}"/>
	/// </summary>
	public sealed class SpellRangeEntryRefToStringTypeConverter : DbcRefToStringTypeConverter<SpellRangeEntry<StringDBCReference>, SpellRangeEntry<string>>
	{
		/// <inheritdoc />
		public SpellRangeEntryRefToStringTypeConverter([NotNull] ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> localizedStringConverter, [NotNull] ITypeConverterProvider<StringDBCReference, string> stringReferenceConverter) 
			: base(localizedStringConverter, stringReferenceConverter)
		{

		}

		/// <inheritdoc />
		public override SpellRangeEntry<string> Convert([NotNull] SpellRangeEntry<StringDBCReference> fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));

			return new SpellRangeEntry<string>(fromObject.SpellRangeId, fromObject.MinRange, fromObject.MinRangeFriendly, fromObject.MaxRange,
				fromObject.MaxRangeFriendly, fromObject.Field5, this.LocalizedStringConverter.Convert(fromObject.Description1), this.LocalizedStringConverter.Convert(fromObject.Description2));
		}
	}
}
