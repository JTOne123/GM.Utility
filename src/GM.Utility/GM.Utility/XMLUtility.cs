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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GM.Utility
{
	/// <summary>
	/// Utilities for XML.
	/// </summary>
	public static class XMLUtility
	{
		/// <summary>
		/// Loads an XElement from the web. Supports HTTP/S and S/FTP.
		/// </summary>
		/// <param name="address">The address from which to download the XML.</param>
		/// <param name="credentials">The network credentials that are sent to the host and used to authenticate the request.</param>
		public static XElement LoadFromWeb(string address, ICredentials credentials=null)
		{
			if(credentials == null) {
				return XElement.Load(address);
			}

			using(var webClient = new WebClient()) {
				webClient.Credentials = credentials;
				string xmlContent = webClient.DownloadString(address);
				return XElement.Parse(xmlContent);
			}
		}
	}
}
