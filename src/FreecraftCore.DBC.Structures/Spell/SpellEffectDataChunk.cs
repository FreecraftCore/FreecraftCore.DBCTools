using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public sealed class SpellEffectDataChunk<TDataType>
	{
		//This might seem ridiclous that we don't use arrays BUT EF does not support arrays
		//for the models so we MUST use seperate fields.
		[WireMember(1)]
		public TDataType Effect1 { get; }

		[WireMember(2)]
		public TDataType Effect2 { get; }

		[WireMember(3)]
		public TDataType Effect3 { get; }

		/// <inheritdoc />
		public SpellEffectDataChunk(TDataType effect1, TDataType effect2, TDataType effect3)
		{
			Effect1 = effect1;
			Effect2 = effect2;
			Effect3 = effect3;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected SpellEffectDataChunk()
		{
			
		}
	}
}
