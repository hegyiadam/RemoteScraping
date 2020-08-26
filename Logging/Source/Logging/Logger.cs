using log4net;
using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILogger
    {
        public ILog Log { get; set; }
        private static Logger _instance = null;
        private Logger()
        {
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }


        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public string FilePath 
        { 
            get
            {
                return ((log4net.Appender.FileAppender)LogManager.GetRepository().GetAppenders()[0]).File;
            }
            set
            {
                FileAppender fileAppender = ((log4net.Appender.FileAppender)LogManager.GetRepository().GetAppenders()[0]);
                fileAppender.File = value;
                fileAppender.ActivateOptions();
            }
        }

        public void Debug(string message)
        {
            if (IsLoggingEnabled(LoggingLevel.Debug))
            {
                Log.Debug(message);
            }
        }

        public void Error(LoggingLevel level,string message)
        {
            if (IsLoggingEnabled(level))
            {
                Log.Error(message);
            }
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Warning(LoggingLevel level, string message)
        {

            if (IsLoggingEnabled(level))
            {
                Log.Warn(message);
            }
        }

        private bool IsLoggingEnabled(LoggingLevel loggingLevel)
        {
            if(loggingLevel == LoggingLevel.Debug)
            {
                return IsDebugLevelEnabled;
            }
            return true;
        }

        private bool IsDebugLevelEnabled
        { 
            get
            {
                return LevelHolder.Level == LoggingLevel.Debug;
            }
        }
    }
}
