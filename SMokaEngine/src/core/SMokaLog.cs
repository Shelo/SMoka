using System;

namespace SMokaEngine
{
	public static class SMokaLog
	{
		private static string LOG_TEMPLATE = "[{0}] {1}";

		private static string sharedTag = "LOG";
		public static string SharedTag
		{
			get
			{
				return sharedTag;
			}

			set
			{
				if (sharedTag == null)
				{
					sharedTag = "LOG";
				}
				else
				{
					sharedTag = value;
				}
			}
		}

		public static void O(string tag, string message)
		{
			Console.WriteLine(String.Format(LOG_TEMPLATE, tag, message));
		}
	}
}

