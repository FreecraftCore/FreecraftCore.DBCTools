using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class LocalizedStringDBC<TStringType>
	{
		/// <summary>
		/// Array of localized strings.
		/// </summary>
		[WireMember(1)]
		[KnownSize(DBCConstants.MaxDbcLocale)]
		public TStringType[] Strings { get; }

		/// <inheritdoc />
		public LocalizedStringDBC([NotNull] TStringType[] strings)
		{
			Strings = strings ?? throw new ArgumentNullException(nameof(strings));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected LocalizedStringDBC()
		{

		}
	}
}
