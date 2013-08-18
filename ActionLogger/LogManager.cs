using System;

namespace ActionLogger
{
	public class LogManager
	{
		private static Lazy<IActionLog> _logger;

		public static void Initialise(Func<IActionLog> createLogger)
		{
			_logger = new Lazy<IActionLog>(createLogger);
		}

		public static IActionLog GetLogger()
		{
			return _logger.Value;
		}
	}
}
