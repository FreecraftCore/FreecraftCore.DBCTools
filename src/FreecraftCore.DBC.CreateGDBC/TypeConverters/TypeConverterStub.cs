using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public sealed class TypeConverterStub<T> : ITypeConverterProvider<T, T>
	{
		public T Convert(T fromObject)
		{
			return fromObject;
		}
	}
}
