using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ActionLogger
{
	public class CouchCommunicator
	{
		private readonly String _url;

		public CouchCommunicator(Uri url, string db)
		{
			_url = BuildUrl(url, db);
		}

		private String BuildUrl(Uri url, string db)
		{
			var uri = new Uri(url, db);
			var location = uri.OriginalString;

			if (db.Contains("/") && location.EndsWith(db))
			{
				var escaped = db.Replace("/", "%2F");
				location = location.Substring(0, location.Length - db.Length) + escaped;
			}

			return location.EndsWith("/") ? location : location + "/";
		}

		public void Store(string json)
		{
			var req = (HttpWebRequest)WebRequest.Create(_url);

			req.Method = "POST";
			req.ContentType = "application/json";

			using (var s = req.GetRequestStream())
			using (var sr = new StreamWriter(s))
			{
				sr.Write(json);
			}

			try
			{
				var response = (HttpWebResponse)req.GetResponse();
				using (var stream = response.GetResponseStream())
				{
					//don't care!
				}
			}
			catch (WebException e)
			{
				if (e.Response != null)
				{
					using (var s = e.Response.GetResponseStream())
					using (var sr = new StreamReader(s))
					{
						Debug.WriteLine(sr.ReadToEnd());
					}
				}
			}
			
		}
	}
}
