using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public static class DBCToolsExtensions
	{
		public static string BuildToolsWelcomeMessage(string toolName)
		{
			return $"FreecraftCore Copyright (c) 2020 Glader/HelloKitty\nRunning FreecraftCore.DBCTools {toolName}.";
		}
	}
}
