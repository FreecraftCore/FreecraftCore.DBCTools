using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public static class IoCContainerExtensions
	{
		/// <summary>
		/// Registers all <see cref="ITypeConverterProvider{TTypeToConvertFrom,TTypeToConvertTo}"/>
		/// in the provided Assembly: <see cref="ass"/>.
		/// </summary>
		/// <param name="builder">The container to register to.</param>
		/// <param name="ass">The assembly to scan.</param>
		public static ContainerBuilder RegisterTypeConvertersFromAssembly([NotNull] this ContainerBuilder builder, [NotNull] Assembly ass)
		{
			if(builder == null) throw new ArgumentNullException(nameof(builder));
			if(ass == null) throw new ArgumentNullException(nameof(ass));

			builder.RegisterAssemblyTypes(ass)
				.AsClosedTypesOf(typeof(ITypeConverterProvider<,>))
				.AsImplementedInterfaces();

			return builder;
		}

		public static IServiceCollection RegisterLoggingServices([NotNull] this IServiceCollection serviceCollection, LogLevel loggingLevel)
		{
			if(serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

			//ILoggerFactory loggerFactory = new LoggerFactory()
			//	.AddFile($"{"Logs/Dump-{Date}"}-{Guid.NewGuid()}.txt", LogLevel.Trace);

			serviceCollection.AddLogging(loggingBuilder =>
			{
				//TODO: Is the correct way to set level?
				loggingBuilder.SetMinimumLevel(loggingLevel);

				//This gets rid of the query spam.
				loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
				loggingBuilder.AddConsole();
			});

			return serviceCollection;
		}

		public static IServiceCollection RegisterDatabaseServices([NotNull] this IServiceCollection serviceCollection, [NotNull] string connectionString)
		{
			if(serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
			if(string.IsNullOrEmpty(connectionString)) throw new ArgumentException("Value cannot be null or empty.", nameof(connectionString));

			//TODO: We should support database connection strings in a config file.
			serviceCollection.AddEntityFrameworkMySql();
			serviceCollection.AddDbContext<DbContext, DataBaseClientFilesDatabaseContext>(options =>
			{
				//TODO: When OnConfiguring no longer has this we should renable this
				options.UseMySql(connectionString, optionsBuilder =>
				{
					optionsBuilder.MaxBatchSize(4000);
					optionsBuilder.MinBatchSize(20);
					optionsBuilder.EnableRetryOnFailure(5);
					optionsBuilder.CommandTimeout(1000);
				});

				options.EnableSensitiveDataLogging();
			});

			return serviceCollection;
		}

		public static IServiceCollection RegisterDBContextOptions([NotNull] this IServiceCollection serviceCollection, [NotNull] string connectionString) 
		{
			if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
			if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));

			serviceCollection.AddScoped<DbContextOptions<DataBaseClientFilesDatabaseContext>>(provider =>
			{
				DbContextOptionsBuilder<DataBaseClientFilesDatabaseContext> options = new DbContextOptionsBuilder<DataBaseClientFilesDatabaseContext>();
				//TODO: When OnConfiguring no longer has this we should renable this
				options.UseMySql(connectionString, optionsBuilder =>
				{
					optionsBuilder.MaxBatchSize(4000);
					optionsBuilder.MinBatchSize(20);
					optionsBuilder.EnableRetryOnFailure(5);
					optionsBuilder.CommandTimeout(1000);
				});

				options.EnableSensitiveDataLogging();

				return options.Options;
			});

			serviceCollection.AddScoped<IDbContextOptions, DbContextOptions>(provider =>
			{
				return provider.GetService<DbContextOptions<DataBaseClientFilesDatabaseContext>>();
			});

			return serviceCollection;
		}
	}
}
