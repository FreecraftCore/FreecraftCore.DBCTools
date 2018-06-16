using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public sealed class SpellTotemDataChunk<TDataType>
	{
		//This might seem ridiclous that we don't use arrays BUT EF does not support arrays
		//for the models so we MUST use seperate fields.
		[WireMember(1)]
		public TDataType One { get; }

		[WireMember(2)]
		public TDataType Two { get; }

		/// <inheritdoc />
		public SpellTotemDataChunk(TDataType one, TDataType two)
		{
			One = one;
			Two = two;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SpellTotemDataChunk()
		{
			
		}
	}
}
