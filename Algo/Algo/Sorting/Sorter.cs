
using System;
namespace Algo.Sorting
{
	/// <summary>
	/// Base sorter class.
	/// </summary>
	public abstract class Sorter<T> where T : IComparable<T>
	{
		/// <summary>
		/// When overriden, sorts an input array.
		/// </summary>
		/// <param name="input">An array.</param>
		/// <returns>Sorted array containing input items.</returns>
		public abstract T[] Sort(T[] input);
	}
}
