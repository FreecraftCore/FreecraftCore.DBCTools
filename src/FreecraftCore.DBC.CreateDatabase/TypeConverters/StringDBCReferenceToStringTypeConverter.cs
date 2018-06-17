using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class StringDBCReferenceToStringTypeConverter : ITypeConverterProvider<StringDBCReference, string>
	{
		private IReadOnlyDictionary<uint, string> StringOffsetMap { get; }

		/// <inheritdoc />
		public StringDBCReferenceToStringTypeConverter([NotNull] IReadOnlyDictionary<uint, string> stringOffsetMap)
		{
			StringOffsetMap = stringOffsetMap ?? throw new ArgumentNullException(nameof(stringOffsetMap));
		}

		/// <inheritdoc />
		public string Convert(StringDBCReference fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));

			//The StringDBCReference contains an offset pointer to a string
			//in the DBC. However, the reader should have a dictionary of offsets as a key
			//meaning we can just read the index of the dictionary at the offset key
			//and that should be the string.

			if(!StringOffsetMap.ContainsKey(fromObject.StringReferenceOffset))
				throw new InvalidOperationException($"Failed to read string from Offset Index: {fromObject.StringReferenceOffset}");

			return StringOffsetMap[fromObject.StringReferenceOffset];
		}
	}
}
