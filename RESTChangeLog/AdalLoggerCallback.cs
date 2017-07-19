using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;

namespace Schaeflein.Community.RESTChangeLog
{
	public class AdalLoggerCallback : IAdalLogCallback
	{
		public void Log(LogLevel level, string message)
		{
			Console.WriteLine(message);
		}
	}
}
