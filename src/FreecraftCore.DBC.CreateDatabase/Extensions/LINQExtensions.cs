using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreecraftCore
{
	public static class LINQExtensions
	{
		public static IEnumerable<IEnumerable<T>> Split<T>(this IReadOnlyCollection<T> source, int chunkSize)
		{
			if(chunkSize > source.Count)
				return new IEnumerable<T>[]{ source };

			return source
				.Select((x, i) => new {Index = i, Value = x})
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value));
		}
	}
}
