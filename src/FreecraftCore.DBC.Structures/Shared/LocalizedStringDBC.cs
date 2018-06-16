using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class LocalizedStringDBC<TStringType>
	{
		//This might seem ridiclous that we don't use arrays BUT EF does not support arrays
		//for the models so we MUST use seperate fields.
		/// <summary>
		/// The EN-US localization.
		/// </summary>
		[WireMember(1)]
		public TStringType enUS { get; }

		[NotMapped]
		[JsonIgnore]
		public TStringType enGB => enUS;

		[WireMember(2)]
		public TStringType koKR { get; }

		[WireMember(3)]
		public TStringType frFR { get; }

		[WireMember(4)]
		public TStringType deDE { get; }

		[WireMember(5)]
		public TStringType enCN { get; }

		[NotMapped]
		[JsonIgnore]
		public TStringType zhCN => enCN;

		[WireMember(6)]
		public TStringType enTW { get; }

		[NotMapped]
		[JsonIgnore]
		public TStringType zhTW => enTW;

		[WireMember(7)]
		public TStringType esES { get; }

		[WireMember(8)]
		public TStringType esMX { get; }

		[WireMember(9)]
		public TStringType ruRU { get; }

		[NotMapped]
		[JsonIgnore]
		[WireMember(10)]
		public TStringType Unknown1 { get; }

		[WireMember(11)]
		public TStringType ptPT { get; }

		[NotMapped]
		[JsonIgnore]
		public TStringType ptBR => ptPT;

		[WireMember(12)]
		public TStringType itIT { get; }

		//The below fields are read but are unknown
		/// <summary>
		/// Unknown field values.
		/// Leave these as default values.
		/// Do not write anything for them.
		/// </summary>
		[JsonIgnore]
		[NotMapped]
		[KnownSize(4)]
		[WireMember(13)]
		public TStringType[] Unknowns { get; }

		/// <summary>
		/// 4 byte bitmask for the localized string.
		/// TODO: What is this? Does it need to be set?
		/// </summary>
		[WireMember(14)]
		public uint Flags { get; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected LocalizedStringDBC()
		{

		}
	}
}
