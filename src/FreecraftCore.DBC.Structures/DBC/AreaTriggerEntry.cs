using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//AreaTrigger.dbc
	/// <summary>
	/// Table model for AreTrigger.dbc
	/// https://wowdev.wiki/DB/AreaTrigger
	/// </summary>
	[WireDataContract]
	[JsonObject]
	[Table("AreaTrigger")]
	public sealed class AreaTriggerEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		public uint EntryId => (uint)AreaTriggerId;

		[Key]
		[WireMember(1)]
		public int AreaTriggerId { get; private set; }

		//TODO: Ref nav prop to Map.dbc
		/// <summary>
		/// Reference to Map.dbc of the map this <see cref="AreaTriggerEntry"/> is in.
		/// </summary>
		[WireMember(2)]
		public int MapId { get; private set; }

		/// <summary>
		/// Seems to be a box of size yards with center at x,y,z.
		/// </summary>
		[WireMember(3)]
		public Vector3<float> Position { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		[WireMember(4)]
		public float Radius { get; private set; }

		/// <summary>
		/// Indicates if the box is a radius-based axis-aligned bounding box trigger.
		/// </summary>
		[JsonIgnore]
		public bool isAxisAlignedBox => Math.Abs(Radius) > 0.0001f;

		//Most commonly used when size is 0, but not always
		/// <summary>
		/// When <see cref="Radius"/> is 0 this is sometimes used to define
		/// a non-uniform axis-aligned bounding box. Think a rectengular prism.
		/// </summary>
		[WireMember(5)]
		public Vector3<float> UnalignedBoxDimension { get; private set; }

		//Most commonly used when size is 0, but not always
		/// <summary>
		/// Y-axis rotation.
		/// </summary>
		[WireMember(6)]
		public float Orientation { get; private set; }

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public AreaTriggerEntry()
		{
			
		}
	}
}
