using System;

namespace ActionLogger
{
	public class LogManager
	{
		private static Lazy<IActionLogger> _logger;

		public static void Initialise(Func<IActionLogger> createLogger)
		{
			_logger = new Lazy<IActionLogger>(createLogger);
		}

		public static IActionLogger GetLogger()
		{
			return _logger.Value;
		}
	}
}
