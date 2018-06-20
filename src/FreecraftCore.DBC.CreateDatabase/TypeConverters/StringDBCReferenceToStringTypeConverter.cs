using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public sealed class StringDBCReferenceToStringTypeConverter : ITypeConverterProvider<StringDBCReference, string>
	{
		//It should be noted that WoW DBCs always have an empty/null string at the begining
		//of the string block.
		//This means there should be a key that is at offset 0 that is null/empty
		//But maybe this is not the case on tables that always have non-empty string values
		//so this should be verified. But it actually won't affect anything if that is the case
		//But should be noted when you create a DBC file.
		private IReadOnlyDictionary<uint, string> StringOffsetMap { get; }

		private ILogger<StringDBCReferenceToStringTypeConverter> Logger { get; }

		/// <inheritdoc />
		public StringDBCReferenceToStringTypeConverter([NotNull] IReadOnlyDictionary<uint, string> stringOffsetMap, [NotNull] ILogger<StringDBCReferenceToStringTypeConverter> logger)
		{
			StringOffsetMap = stringOffsetMap ?? throw new ArgumentNullException(nameof(stringOffsetMap));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc />
		public string Convert(StringDBCReference fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));


			if(!StringOffsetMap.ContainsKey(fromObject.StringReferenceOffset))
				throw new InvalidOperationException($"Failed to read string from Offset Index: {fromObject.StringReferenceOffset}");

			//The StringDBCReference contains an offset pointer to a string
			//in the DBC. However, the reader should have a dictionary of offsets as a key
			//meaning we can just read the index of the dictionary at the offset key
			//and that should be the string.

			return StringOffsetMap[fromObject.StringReferenceOffset];
		}
	}
}
