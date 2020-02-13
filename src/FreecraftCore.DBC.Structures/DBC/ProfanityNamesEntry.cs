using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//NamesProfanity.dbc
	/// <summary>
	/// Table model for NamesProfanity.dbc
	/// https://wowdev.wiki/DB/NamesProfanity
	/// </summary>
	[GenericDbcModel(typeof(ProfanityNamesEntry<StringDBCReference>), typeof(ProfanityNamesEntry<string>))]
	[WireDataContract]
	[JsonObject]
	[Table("NamesProfanity")]
	public sealed class ProfanityNamesEntry<TStringType> : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public uint EntryId => ProfanityNamesId;

		[Key]
		[WireMember(1)]
		public uint ProfanityNamesId { get; private set; }

		[WireMember(2)]
		public TStringType Pattern { get; private set; }

		[WireMember(3)]
		public uint LanguageID { get; private set; }

		/// <inheritdoc />
		public ProfanityNamesEntry(uint profanityNamesId, TStringType pattern, uint languageId)
		{
			ProfanityNamesId = profanityNamesId;
			Pattern = pattern;
			LanguageID = languageId;
		}

		public ProfanityNamesEntry()
		{
			
		}
	}
}
