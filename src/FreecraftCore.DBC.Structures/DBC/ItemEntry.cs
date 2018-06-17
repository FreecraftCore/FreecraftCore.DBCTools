using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Item.dbc
	[WireDataContract]
	[JsonObject]
	[Table("Item")]
	public sealed class ItemEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public uint EntryId => (uint)ItemId;

		[Key]
		[WireMember(1)]
		public int ItemId { get; private set; }

		[WireMember(2)]
		public int ItemClassId { get; private set; }

		[WireMember(3)]
		public int ItemSubClassId { get; private set; }

		[WireMember(4)]
		public int SoundOverride { get; private set; }

		//See: https://wowdev.wiki/DB/Material
		[WireMember(5)]
		public int MaterialId { get; private set; }

		//See: https://wowdev.wiki/DB/ItemDisplayInfo
		[WireMember(6)]
		public int ItemDisplayId { get; private set; }

		/// <summary>
		/// Indicates the slot this item should be equipped in.
		/// </summary>
		[WireMember(7)]
		public InventoryType InventorySlotType { get; private set; }

		/// <summary>
		/// Wiki says: 0 -4, mostly 0
		/// See: https://wowdev.wiki/DB/Item
		/// </summary>
		[WireMember(8)]
		public int SheathType { get; private set; }

		/// <inheritdoc />
		public ItemEntry(int itemId, int itemClassId, int itemSubClassId, int soundOverride, int materialId, int itemDisplayId, InventoryType inventorySlotType, int sheathType)
		{
			if(itemId < 0) throw new ArgumentOutOfRangeException(nameof(itemId));

			ItemId = itemId;
			ItemClassId = itemClassId;
			ItemSubClassId = itemSubClassId;
			SoundOverride = soundOverride;
			MaterialId = materialId;
			ItemDisplayId = itemDisplayId;
			InventorySlotType = inventorySlotType;
			SheathType = sheathType;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public ItemEntry()
		{
			
		}
	}
}
