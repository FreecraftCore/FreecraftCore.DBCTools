using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//Based on: https://github.com/TrinityCore/SpellWork/blob/master/SpellWork/DBC/Structure.cs
	/// <summary>
	/// Structure for the DBC file header.
	/// </summary>
	[WireDataContract]
	public sealed class DBCHeader
	{
		/// <summary>
		/// TODO what is this
		/// </summary>
		[WireMember(1)]
		public int Signature { get; }

		/// <summary>
		/// Amount of entries in the DBC.
		/// </summary>
		[WireMember(2)]
		public int RecordsCount { get; }

		/// <summary>
		/// The amount of fields in the DBC.
		/// </summary>
		[WireMember(3)]
		public int FieldsCount { get; }

		/// <summary>
		/// The size of the record.
		/// </summary>
		[WireMember(4)]
		public int RecordSize { get; }

		/// <summary>
		/// The DBC string size.
		/// </summary>
		[WireMember(5)]
		public int StringTableSize { get; }

		/// <summary>
		/// TODO: What is this
		/// </summary>
		public bool IsDBC => Signature == 0x43424457;

		/// <summary>
		/// The size of the DBC records.
		/// </summary>
		public long DataSize => RecordsCount * RecordSize;

		/// <summary>
		/// The starting position of the string data.
		/// </summary>
		public long StartStringPosition => DataSize + sizeof(int) * 5;

		//Serializer ctor
		protected DBCHeader()
		{
			
		}
	}
}
