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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GM.Utility
{
	/// <summary>
	/// Utilities for string.
	/// </summary>
	public static class StringUtility
	{
		/// <summary>
		/// Removes the whitespace in this text.
		/// </summary>
		/// <param name="text">The text.</param>
		public static string RemoveWhitespace(this string text)
		{
			return Regex.Replace(text, @"\s+", "");
		}

		/// <summary>
		/// Transforms the first letter into upper case.
		/// </summary>
		/// <param name="text">The text.</param>
		public static string ToUpperFirstLetter(this string text)
		{
			if(text.Length == 0)
				return text;
			
			text = char.ToUpper(text[0]) + text.Substring(1);

			return text;
		}
	}
}
