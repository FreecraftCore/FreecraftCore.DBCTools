using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	[Table("SpellRadius")]
	[JsonObject]
	[WireDataContract]
	public class SpellRadiusEntry : IDBCEntryIdentifiable
	{
		//TODO: Is this spell id?
		/// <inheritdoc />
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => SpellId;

		[Key]
		[WireMember(1)]
		public uint SpellId { get; private set; }

		[WireMember(2)]
		public float Radius { get; private set; }

		[WireMember(3)]
		public int Zero { get; private set; }

		[WireMember(4)]
		public float Radius2 { get; private set; }

		/// <inheritdoc />
		public SpellRadiusEntry(uint spellId, float radius, int zero, float radius2)
		{
			SpellId = spellId;
			Radius = radius;
			Zero = zero;
			Radius2 = radius2;
		}

		public SpellRadiusEntry()
		{
			
		}
	}
}
