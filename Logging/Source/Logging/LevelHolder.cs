using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class LevelHolder
    {
        private static LoggingLevel loggingLevel = GetLevel(ConfigurationManager.AppSettings);
        public const string CONFIG_KEY = "LoggingLevel";
        

        public static LoggingLevel Level
        {
            get
            {
                return loggingLevel;
            }
            set
            {
                loggingLevel = value;
            }
        }


        public static LoggingLevel GetLevel(NameValueCollection appSettings)
        {
            string setting = appSettings[CONFIG_KEY];
            Type levelType = typeof(LoggingLevel);

            foreach (string level in Enum.GetNames(levelType))
            {
                if (setting == level)
                {
                    return (LoggingLevel)Enum.Parse(levelType, setting);
                }
            }
            return LoggingLevel.Normal;
        }
    }
}
