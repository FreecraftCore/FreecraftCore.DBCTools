using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class LocalizedStringToStringDbcRefTypeConverter : ITypeConverterProvider<LocalizedStringDBC<string>, LocalizedStringDBC<StringDBCReference>>
	{
		private ITypeConverterProvider<string, StringDBCReference> StringToStringRefConverter { get; }

		/// <inheritdoc />
		public LocalizedStringToStringDbcRefTypeConverter([NotNull] ITypeConverterProvider<string, StringDBCReference> stringToStringRefConverter)
		{
			StringToStringRefConverter = stringToStringRefConverter ?? throw new ArgumentNullException(nameof(stringToStringRefConverter));
		}

		/// <inheritdoc />
		public LocalizedStringDBC<StringDBCReference> Convert(LocalizedStringDBC<string> fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));

			//We have to use the Unknowns ctor overload because the serializer will
			//try to write null and will fail in that case.
			return new LocalizedStringDBC<StringDBCReference>(
				StringToStringRefConverter.Convert(fromObject.enUS),
				StringToStringRefConverter.Convert(fromObject.koKR),
				StringToStringRefConverter.Convert(fromObject.frFR),
				StringToStringRefConverter.Convert(fromObject.deDE),
				StringToStringRefConverter.Convert(fromObject.enCN),
				StringToStringRefConverter.Convert(fromObject.enTW),
				StringToStringRefConverter.Convert(fromObject.esES),
				StringToStringRefConverter.Convert(fromObject.esMX),
				StringToStringRefConverter.Convert(fromObject.ruRU),
				StringToStringRefConverter.Convert(fromObject.Unknown1),
				StringToStringRefConverter.Convert(fromObject.ptPT),
				StringToStringRefConverter.Convert(fromObject.itIT),
				fromObject.Flags,
				fromObject.Unknowns.Select(StringToStringRefConverter.Convert).ToArray());
		}
	}
}
