using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FreecraftCore
{
	public sealed class ForeignKeyIgnoreInterceptor : DbCommandInterceptor
	{
		public override Task<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = new CancellationToken())
		{
			if(command.CommandText.Contains("INSERT"))
				command.CommandText = $"SET FOREIGN_KEY_CHECKS=0; {command.CommandText}";

			return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
		}
	}
}
