using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ActionLogger
{
	public class CouchActionLogger : IActionLogger
	{
		private readonly CouchCommunicator _couch;
		private readonly IDictionary<string, object> _empty;

		public CouchActionLogger(Uri url, string db)
		{
			_couch = new CouchCommunicator(url, db);
			_empty = new Dictionary<string, object>();
		}

		public void Store(string action)
		{
			Store(action, _empty);
		}

		public void Store(string action, IDictionary<string, object> data)
		{
			data["-action"] = action;

            if (data.ContainsKey("-created") == false)
            {
                data["-created"] = DateTime.Now;
            }

			//fix dictionary key starting with '_'

			var serializer = new JsonSerializer();
			var sb = new StringBuilder();

			using (var sw = new StringWriter(sb))
			using (var writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, data);
			}

			_couch.Store(sb.ToString());
		}
	}
}
