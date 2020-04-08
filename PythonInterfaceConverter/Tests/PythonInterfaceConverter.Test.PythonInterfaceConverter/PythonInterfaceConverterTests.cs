using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonInterfaceConverter.Source.CommonLibrary;
using PythonInterfaceConverter.Source.PythonInterfaceConverter;

namespace PythonInterfaceConverter.Test.PythonInterfaceConverter
{
    [TestClass]
    public class PythonInterfaceConverterTests
    {
        private const string TEST_ARTIFACT_FOLDER_PATH = @".\Artifact";
        private const string TEST_IMPLEMENTATION_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\Executable.cs";
        private const string TEST_INTERFACE_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\IExecutable.cs";
        private const string TEST_EXPECTED_IMPLEMENTATION_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\ExpectedExecutable.cs";
        private const string TEST_EXPECTED_INTERFACE_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\ExpectedIExecutable.cs";
        private const string TEST_PYTHON_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\IExecutable.py";

        public string InitImplementationCSContent { get; set; }
        public string InitInterfaceCSContent { get; set; }


        [TestInitialize]
        public void TestInitialization()
        {
            InitImplementationCSContent = FileManagement.ReadFile(TEST_IMPLEMENTATION_CS_FILE_PATH);
            InitInterfaceCSContent = FileManagement.ReadFile(TEST_INTERFACE_CS_FILE_PATH);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            FileManagement.WriteFile(TEST_IMPLEMENTATION_CS_FILE_PATH, InitImplementationCSContent);
            FileManagement.WriteFile(TEST_INTERFACE_CS_FILE_PATH, InitInterfaceCSContent);
        }
        
        [TestMethod]
        public void FullConvertTest()
        {
            string expectedImplementationCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_IMPLEMENTATION_CS_FILE_PATH));
            string expectedInterfaceCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_INTERFACE_CS_FILE_PATH));


            Program.Main(new string[] { "full" , TEST_PYTHON_FILE_PATH,TEST_INTERFACE_CS_FILE_PATH,TEST_IMPLEMENTATION_CS_FILE_PATH,"Test"});
            string actualImplementationCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_IMPLEMENTATION_CS_FILE_PATH));
            string actualInterfaceCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_INTERFACE_CS_FILE_PATH));

            Assert.AreEqual(actualImplementationCSContent, expectedImplementationCSContent);
            Assert.AreEqual(actualInterfaceCSContent, expectedInterfaceCSContent);
        }
        [TestMethod]
        public void ImplementationConvertTest()
        {
            string expectedImplementationCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_IMPLEMENTATION_CS_FILE_PATH));


            Program.Main(new string[] { "impl", TEST_PYTHON_FILE_PATH, TEST_IMPLEMENTATION_CS_FILE_PATH, "Test" });
            string actualImplementationCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_IMPLEMENTATION_CS_FILE_PATH));

            Assert.AreEqual(actualImplementationCSContent, expectedImplementationCSContent);
        }

        [TestMethod]
        public void InterfaceConvertTest()
        {
            string expectedInterfaceCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_INTERFACE_CS_FILE_PATH));


            Program.Main(new string[] { "inter", TEST_PYTHON_FILE_PATH, TEST_INTERFACE_CS_FILE_PATH, "Test" });
            string actualInterfaceCSContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_INTERFACE_CS_FILE_PATH));
            
            Assert.AreEqual(actualInterfaceCSContent, expectedInterfaceCSContent);
        }

        private string RemoveUnnecessaryChars(string text)
        {
            return Regex.Replace(text.Replace("\r", "").Replace("\t", ""), @"\s+", "");
        }
    }
}
