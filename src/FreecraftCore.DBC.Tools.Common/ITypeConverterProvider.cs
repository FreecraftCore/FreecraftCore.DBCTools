using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for object that can convert between two types
	/// <typeparamref name="TTypeToConvertFrom"/> and <typeparamref name="TTypeToConvertTo"/>
	/// </summary>
	/// <typeparam name="TTypeToConvertFrom"></typeparam>
	/// <typeparam name="TTypeToConvertTo"></typeparam>
	public interface ITypeConverterProvider<in TTypeToConvertFrom, out TTypeToConvertTo>
	{
		/// <summary>
		/// Converts the input <typeparamref name="TTypeToConvertFrom"/> <see cref="fromObject"/>
		/// to the target Type <see cref="TTypeToConvertTo"/>.
		/// </summary>
		/// <param name="fromObject">The input type. Can be null. If null the return will likely be null.</param>
		/// <returns>A non-null <typeparamref name="TTypeToConvertTo"/> instance based on the input <see cref="fromObject"/> if the input is not null
		/// If <see cref="fromObject"/> is null then the return should be null.</returns>
		[CanBeNull]
		TTypeToConvertTo Convert([CanBeNull] TTypeToConvertFrom fromObject);
	}
}
