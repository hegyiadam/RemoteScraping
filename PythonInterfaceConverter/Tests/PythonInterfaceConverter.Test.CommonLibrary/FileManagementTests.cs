using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonInterfaceConverter.Source.CommonLibrary;

namespace PythonInterfaceConverter.Test.CommonLibrary
{
    [TestClass]
    public class FileManagementTests
    {
        private const string TEST_ARTIFACT_FOLDER_PATH = @".\Artifact";
        private const string RAW_TEST_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\RawTestFile.txt";
        private const string TEST_RESOURCE_NAME = "PythonInterfaceConverter.Test.CommonLibrary.Artifact.ResourceTestFile.txt";

        public string TestFolderPath { get; set; }
        public string TestFileName { get; set; }

        public string NewTestFilePath
        {
            get
            {
                return TestFolderPath + "\\" + TestFileName;
            }
        }

        [TestInitialize]
        public void TestInitialization()
        {
            TestFolderPath = ConfigurationManager.AppSettings.Get("TempFolderPath");
            TestFileName = "NewTestFile.txt";
            if (!Directory.Exists(TestFolderPath))
            {
                Directory.CreateDirectory(TestFolderPath);
            }
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            if(File.Exists(NewTestFilePath))
            {
                File.Delete(NewTestFilePath);
            }
        }

        [TestMethod]
        public void WriteOneLineToFile()
        {
            string expectedFileContent = "Something new";

            FileManagement.WriteFile(NewTestFilePath, expectedFileContent);

            string actualFileContent = File.ReadAllText(NewTestFilePath);
            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod]
        public void WriteMultipleLinesToFile()
        {
            string expectedFileContent = "Something new\r\nLine2";

            FileManagement.WriteFile(NewTestFilePath, expectedFileContent);

            string actualFileContent = File.ReadAllText(NewTestFilePath);
            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod]
        public void ReadFile()
        {
            string expectedFileContent = "Line1\r\nLine2";

            string actualFileContent = FileManagement.ReadFile(RAW_TEST_FILE_PATH);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [TestMethod]
        public void GetAssemblyTextResource()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string expectedFileContent = "ResourceFile";
            string actualFileContent = FileManagement.GetAssemblyTextResource(assembly, TEST_RESOURCE_NAME);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }
    }
}
