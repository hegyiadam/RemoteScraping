using System.Configuration;

namespace WPFBrowserClient.Model
{
    public class ConfigManager
    {
        private static ConfigManager _instance = null;

        private ConfigManager()
        {
        }

        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigManager();
                }
                return _instance;
            }
        }

        public string DefaultURL
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultURL"];
            }
        }
    }
}