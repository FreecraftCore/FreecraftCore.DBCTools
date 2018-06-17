using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	[Table("SpellRange")]
	[JsonObject]
	[WireDataContract]
	public class SpellRangeEntry<TStringType> : IDBCEntryIdentifiable
	{
		//TODO: Is this spell id? Or another id?
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public uint EntryId => SpellRangeId;

		[Key]
		[WireMember(1)]
		public uint SpellRangeId { get; private set; }

		[WireMember(2)]
		public float MinRange { get; private set; }

		[WireMember(3)]
		public float MinRangeFriendly { get; private set; }

		[WireMember(4)]
		public float MaxRange { get; private set; }

		[WireMember(5)]
		public float MaxRangeFriendly { get; private set; }

		//TODO: What does this field do?

		[WireMember(6)]
		public uint Field5 { get; private set; }

		[WireMember(7)]
		public LocalizedStringDBC<TStringType> Description1 { get; private set; }

		[WireMember(8)]
		public LocalizedStringDBC<TStringType> Description2 { get; private set; }

		/// <inheritdoc />
		public SpellRangeEntry(uint spellRangeId, float minRange, float minRangeFriendly, float maxRange, float maxRangeFriendly, uint field5, LocalizedStringDBC<TStringType> description1, LocalizedStringDBC<TStringType> description2)
		{
			SpellRangeId = spellRangeId;
			MinRange = minRange;
			MinRangeFriendly = minRangeFriendly;
			MaxRange = maxRange;
			MaxRangeFriendly = maxRangeFriendly;
			Field5 = field5;
			Description1 = description1;
			Description2 = description2;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public SpellRangeEntry()
		{
			
		}
	}
}
