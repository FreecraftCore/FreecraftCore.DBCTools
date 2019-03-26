using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public class Vector3<T> : Vector2<T>
	{
		/// <summary>
		/// X value.
		/// </summary>
		[WireMember(1)]
		public T Z { get; private set; }

		public Vector3(T x, T y, T z)
			: base(x, y)
		{
			Z = z;
		}

		protected Vector3()
		{

		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"{base.ToString()} Z: {Z}";
		}
	}
}