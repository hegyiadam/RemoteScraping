using System;
using System.Configuration;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logging.Test.Logging
{
    [TestClass]
    public class LoggingTests
    {
        private const string LOG_FOLDER = "log";
        private const string LOG_FILENAME = "application";
        private const string LOG_EXTENSION = ".log";



        [TestInitialize]
        public void OnInitialization()
        {
            LevelHolder.Level = LoggingLevel.Normal;
        }


        public static string LogFilePath
        {
            get
            {
                return Logger.Instance.FilePath;
            }
            set
            {
                Logger.Instance.FilePath = value;
            }
        }
        public int FileLength 
        { 
            get
            {
                FileInfo fileInfo = new FileInfo(LogFilePath);
                return (int)fileInfo.Length;
            }
        }
        [TestMethod]
        public void InfoTest()
        {
            int startLength = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Info(testMsg);
            int endLength = FileLength;
            Assert.IsTrue(startLength < endLength);
        }
        [TestMethod]
        public void DebugTest()
        {
            int startLength = FileLength;
            LevelHolder.Level = LoggingLevel.Debug;
            string testMsg = "Test message";
            Logger.Instance.Debug(testMsg);
            int endLength = FileLength;
            Assert.IsTrue(startLength < endLength);
        }

        [TestMethod]
        public void ErrorTest()
        {
            int startLength = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Error(LoggingLevel.Normal, testMsg);
            int endLength = FileLength;

            Assert.IsTrue(startLength < endLength);
        }

        [TestMethod]
        public void WarningTest()
        {
            int startLength = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Warning(LoggingLevel.Normal, testMsg);
            int endLength = FileLength;
            Assert.IsTrue(startLength < endLength);
        }

        [TestMethod]
        public void ErrorTest2()
        {
            int startLength = FileLength;
            LevelHolder.Level = LoggingLevel.Debug;
            string testMsg = "Test message";
            Logger.Instance.Error(LoggingLevel.Debug, testMsg);
            int endLength = FileLength;

            Assert.IsTrue(startLength < endLength);
        }

        [TestMethod]
        public void WarningTest2()
        {
            int startLength = FileLength;
            LevelHolder.Level = LoggingLevel.Debug;
            string testMsg = "Test message";
            Logger.Instance.Warning(LoggingLevel.Debug, testMsg);
            int endLength = FileLength;
            Assert.IsTrue(startLength < endLength);
        }


    }
}
