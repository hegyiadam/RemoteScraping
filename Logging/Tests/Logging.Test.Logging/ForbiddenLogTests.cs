using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Test.Logging
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ForbiddenLogTests
    {
        [TestInitialize]
        public void OnInitialization()
        {
            LevelHolder.Level = LoggingLevel.Normal;
        }

        [TestMethod]
        public void Debug()
        {
            int startLenght = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Debug(testMsg);
            int endLenght = FileLength;
            Assert.AreEqual(startLenght,endLenght);
        }
        [TestMethod]
        public void Error()
        {
            int startLenght = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Error(LoggingLevel.Debug,testMsg);
            int endLenght = FileLength;
            Assert.AreEqual(startLenght, endLenght);
        }
        [TestMethod]
        public void Warning()
        {
            int startLenght = FileLength;
            string testMsg = "Test message";
            Logger.Instance.Warning(LoggingLevel.Debug, testMsg);
            int endLenght = FileLength;
            Assert.AreEqual(startLenght, endLenght);
        }
        public int FileLength
        {
            get
            {
                FileInfo fileInfo = new FileInfo(LogFilePath);
                return (int)fileInfo.Length;
            }
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
    }
}
