using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class StringDBC
	{
		/// <summary>
		/// Null terminated ASCII string.
		/// </summary>
		[Encoding(EncodingType.ASCII)]
		[WireMember(1)]
		public string StringValue { get; private set; }

		/// <inheritdoc />
		public StringDBC(string stringValue)
		{
			StringValue = stringValue ?? "";
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected StringDBC()
		{
			
		}
	}
}
