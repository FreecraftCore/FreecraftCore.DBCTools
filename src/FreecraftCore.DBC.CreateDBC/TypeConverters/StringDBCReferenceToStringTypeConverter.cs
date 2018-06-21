using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public sealed class StringDBCReferenceToStringTypeConverter : ITypeConverterProvider<string, StringDBCReference>
	{
		//It should be noted that WoW DBCs always have an empty/null string at the begining
		//of the string block.
		//This means there should be a key that is at offset 0 that is null/empty
		//But maybe this is not the case on tables that always have non-empty string values
		//so this should be verified. But it actually won't affect anything if that is the case
		//But should be noted when you create a DBC file.
		private IDbcOffsetGenerator OffsetGenerator { get; }

		private ILogger<StringDBCReferenceToStringTypeConverter> Logger { get; }

		/// <inheritdoc />
		public StringDBCReferenceToStringTypeConverter([NotNull] IDbcOffsetGenerator offsetGenerator, [NotNull] ILogger<StringDBCReferenceToStringTypeConverter> logger)
		{
			OffsetGenerator = offsetGenerator ?? throw new ArgumentNullException(nameof(offsetGenerator));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		/// <inheritdoc />
		public StringDBCReference Convert(string fromObject)
		{
			//We cannot really throw when null
			//Because there are some cases where we cannot control the values coming in.
			if(fromObject == null) return new StringDBCReference(OffsetGenerator.CreateOffset(""));

			return new StringDBCReference(OffsetGenerator.CreateOffset(fromObject));
		}
	}
}
