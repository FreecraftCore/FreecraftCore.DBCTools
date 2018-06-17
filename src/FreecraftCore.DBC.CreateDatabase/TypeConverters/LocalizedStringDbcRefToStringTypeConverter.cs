using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public sealed class LocalizedStringDbcRefToStringTypeConverter : ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>>
	{
		private ITypeConverterProvider<StringDBCReference, string> StringRefToStringConverter { get; }

		/// <inheritdoc />
		public LocalizedStringDbcRefToStringTypeConverter(ITypeConverterProvider<StringDBCReference, string> stringRefToStringConverter)
		{
			StringRefToStringConverter = stringRefToStringConverter;
		}

		/// <inheritdoc />
		public LocalizedStringDBC<string> Convert(LocalizedStringDBC<StringDBCReference> fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));

			return new LocalizedStringDBC<string>(
				StringRefToStringConverter.Convert(fromObject.enUS),
				StringRefToStringConverter.Convert(fromObject.koKR),
				StringRefToStringConverter.Convert(fromObject.frFR),
				StringRefToStringConverter.Convert(fromObject.deDE),
				StringRefToStringConverter.Convert(fromObject.enCN),
				StringRefToStringConverter.Convert(fromObject.enTW),
				StringRefToStringConverter.Convert(fromObject.esES),
				StringRefToStringConverter.Convert(fromObject.esMX),
				StringRefToStringConverter.Convert(fromObject.ruRU),
				StringRefToStringConverter.Convert(fromObject.Unknown1),
				StringRefToStringConverter.Convert(fromObject.ptPT),
				StringRefToStringConverter.Convert(fromObject.itIT),
				fromObject.Flags);
		}
	}
}
