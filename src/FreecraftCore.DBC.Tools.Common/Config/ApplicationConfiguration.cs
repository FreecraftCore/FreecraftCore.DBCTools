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
		[JsonProperty]
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

		/// <summary>
		/// The path that DBC files should be
		/// loaded from.
		/// </summary>
		[JsonProperty]
		public string DbcInputPath { get; private set; }

		/// <summary>
		/// The output path that DBC files should be loaded from.
		/// </summary>
		[JsonProperty]
		public string DbcOutputPath { get; private set; }

		/// <summary>
		/// The path that generated MPQs should be written to.
		/// </summary>
		[JsonProperty]
		public string MpqOutputPath { get; private set; }

		/// <summary>
		/// The name that should be generated for an MPQ.
		/// DO NOT include extensions (ex. ".MPQ"). Leave extensions off.
		/// </summary>
		[JsonProperty]
		public string MpqOutputName { get; private set; }

		[JsonProperty]
		public string DiffOutputPath { get; private set; }

		/// <inheritdoc />
		public ApplicationConfiguration(string databaseConnectionString, bool loggingEnabled, LogLevel loggingLevel, string dbcInputPath, string dbcOutputPath, string mpqOutputPath, string mpqOutputName, string diffOutputPath)
		{
			DatabaseConnectionString = databaseConnectionString;
			LoggingEnabled = loggingEnabled;
			LoggingLevel = loggingLevel;
			DbcInputPath = dbcInputPath;
			DbcOutputPath = dbcOutputPath;
			MpqOutputPath = mpqOutputPath;
			MpqOutputName = mpqOutputName;
			DiffOutputPath = diffOutputPath;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public ApplicationConfiguration()
		{
			
		}
	}
}
