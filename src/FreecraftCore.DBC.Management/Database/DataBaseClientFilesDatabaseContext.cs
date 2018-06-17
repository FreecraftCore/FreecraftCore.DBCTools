using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	public sealed class DataBaseClientFilesDatabaseContext : DbContext
	{
		/// <summary>
		/// Represents the Spell.dbc table.
		/// </summary>
		public DbSet<SpellDBCEntry<string>> Spell { get; set; }

		public DataBaseClientFilesDatabaseContext([NotNull] DbContextOptions options) 
			: base(options)
		{

		}

		//TODO: Remove this
		/// <inheritdoc />
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("Server=localhost;Database=Client.DBC;Uid=root;Pwd=test;");

			base.OnConfiguring(optionsBuilder);
		}

		public DataBaseClientFilesDatabaseContext()
		{
			
		}
	}
}
