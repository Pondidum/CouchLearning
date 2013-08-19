using System.Collections.Generic;

namespace ActionLogger
{
	public interface IActionLogger
	{
		void Store(string action);
		void Store(string action, IDictionary<string, object> data);
	}
}
