using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreecraftCore
{
	public static class LINQExtensions
	{
		public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
		{
			return list.Select((item, index) => new {index, item})
				.GroupBy(x => x.index % parts)
				.Select(x => x.Select(y => y.item));
		}
	}
}
