using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;

namespace FreecraftCore
{
	/// <summary>
	/// Configuration object for the application.
	/// </summary>
	[JsonObject]
	public sealed class ApplicationConfiguration
	{
		/// <summary>
		/// The connection string to the database.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		public string DatabaseConnectionString { get; private set; }

		/// <summary>
		/// Indicates if logging should be enabled.
		/// </summary>
		[JsonProperty]
		public bool LoggingEnabled { get; private set; }

		/// <summary>
		/// The logging level of the optional logger.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty]
		public LogLevel LoggingLevel { get; private set; }

		/// <inheritdoc />
		public ApplicationConfiguration([NotNull] string databaseConnectionString, bool loggingEnabled, LogLevel loggingLevel)
		{
			if(string.IsNullOrEmpty(databaseConnectionString)) throw new ArgumentException("Value cannot be null or empty.", nameof(databaseConnectionString));

			DatabaseConnectionString = databaseConnectionString;
			LoggingEnabled = loggingEnabled;
			LoggingLevel = loggingLevel;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public ApplicationConfiguration()
		{
			
		}
	}
}
