using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using JetBrains.Annotations;
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
	}
}
