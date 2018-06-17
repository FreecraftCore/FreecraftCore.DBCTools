using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class StringDBCReference
	{
		[WireMember(1)]
		public uint StringReferenceOffset { get; private set; }

		/// <inheritdoc />
		public StringDBCReference(uint stringReferenceOffset)
		{
			StringReferenceOffset = stringReferenceOffset;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected StringDBCReference()
		{
			
		}
	}
}
