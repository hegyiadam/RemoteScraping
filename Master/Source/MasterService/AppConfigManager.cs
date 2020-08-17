using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService
{
    public class AppConfigManager
    {
		private static AppConfigManager _instance = null;
		private AppConfigManager() { }
		public static AppConfigManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new AppConfigManager();
				}
				return _instance;
			}
		}

		public string ServerAddress 
		{
			get
			{
				string protocol = ConfigurationManager.AppSettings["protocol"];
				string ip = ConfigurationManager.AppSettings["ip"];
				string port = ConfigurationManager.AppSettings["port"];

				string protocolSeparator = "://";
				string portSeparator = ":";
				string separator = "/";

				string address = protocol + protocolSeparator + ip + portSeparator + port + separator;

				return address;
			}
		}
	}
}
