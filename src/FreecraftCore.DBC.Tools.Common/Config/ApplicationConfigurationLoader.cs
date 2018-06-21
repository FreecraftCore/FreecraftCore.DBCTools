using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	public sealed class ApplicationConfigurationLoader
	{
		public string ConfigPath { get; }

		/// <inheritdoc />
		public ApplicationConfigurationLoader([NotNull] string configPath = @"Config/Configuration.json")
		{
			if(string.IsNullOrEmpty(configPath)) throw new ArgumentException("Value cannot be null or empty.", nameof(configPath));
			ConfigPath = configPath;
		}

		public ApplicationConfiguration BuildConfigFile()
		{
			string configData = null;
			try
			{
				configData = File.ReadAllText(ConfigPath);
			}
			catch(Exception e)
			{
				throw new InvalidOperationException($"Failed to log Configuration.json from path Config/Configuration.json. Exception: {e.Message}");
			}

			//We assume it's on Config and named Configuration.json
			return JsonConvert.DeserializeObject<ApplicationConfiguration>(configData);
		}
	}
}
