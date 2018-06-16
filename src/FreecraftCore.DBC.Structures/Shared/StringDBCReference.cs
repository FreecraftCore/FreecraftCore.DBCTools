using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public class StringDBCReference
	{
		[WireMember(1)]
		public uint StringReferenceOffset { get; }

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
