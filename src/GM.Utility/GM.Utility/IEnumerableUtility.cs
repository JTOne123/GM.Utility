﻿/*
MIT License

Copyright (c) 2017 Grega Mohorko

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Project: GM.Utility
Created: 2017-10-27
Author: Grega Mohorko
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Utility
{
	/// <summary>
	/// Utilities for <see cref="IEnumerable{T}"/>.
	/// <para>
	/// For more features, check out https://github.com/morelinq/MoreLINQ
	/// </para>
	/// </summary>
	public static class IEnumerableUtility
	{
		/// <summary>
		/// Returns distinct elements from a sequence using the provided value selector for equality comparison.
		/// </summary>
		/// <typeparam name="T1">The type of the elements of source.</typeparam>
		/// <typeparam name="TValue">The type of the value on which to distinct.</typeparam>
		/// <param name="source">The source collection.</param>
		/// <param name="valueSelector">A transform function to apply to each element to select the value on which to distinct.</param>
		public static IEnumerable<T1> DistinctBy<T1, TValue>(this IEnumerable<T1> source, Func<T1, TValue> valueSelector)
		{
			var alreadyIncluded = new HashSet<TValue>();

			foreach(var element in source) {
				if(alreadyIncluded.Add(valueSelector(element))) {
					yield return element;
				}
			}
		}

		/// <summary>
		/// Determines whether the provided collection is null or is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the collection.</typeparam>
		/// <param name="enumerable">The collection, which may be null or empty.</param>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			// Solution from: http://danielvaughan.org/post/IEnumerable-IsNullOrEmpty.aspx
			if(enumerable == null) {
				return true;
			}

			// if this is a collection, use the Count property
			// the count property is O(1) while IEnumerable.Count() is O(N)
			if(enumerable is ICollection<T> collection) {
				return collection.Count < 1;
			}
			return enumerable.Any();
		}

		/// <summary>
		/// Determines whether two sequences are equal by comparing the elements by using the default equality comparer for their type. Note that this method does not compare the order of elements and returns true even if the order is not equal.
		/// </summary>
		/// <typeparam name="T">The type of the elements of the input sequences.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">An IEnumerable to compare to the first sequence.</param>
		public static bool SequenceEqualUnordered<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			// Solution from: http://stackoverflow.com/questions/22173762/check-if-two-lists-are-equal
			// linear time!

			// hash-based dictionary of counts
			Dictionary<T, int> counts = first
				.GroupBy(element => element)
				.ToDictionary(group => group.Key, group => group.Count());

			// -1 for each element of the second sequence
			bool ok = true;
			foreach(T element in second) {
				if(counts.ContainsKey(element)) {
					counts[element]--;
				} else {
					ok = false;
					break;
				}
			}

			// check if the resultant counts are all zeros
			return ok && counts.Values.All(count => count == 0);
		}
	}
}
