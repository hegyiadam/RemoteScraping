using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonInterfaceConverter.Source.CommonLibrary;
using PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary;
using System.IO;
using System.Text.RegularExpressions;

namespace PythonInterfaceConverter.Test.PythonInterfaceConverterLibrary
{
    [TestClass]
    public class InterfaceConverterTests
    {
        private const string TEST_ARTIFACT_FOLDER_PATH = @".\Artifact";
        private const string TEST_IMPLEMENTATION_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\Converted.cs";
        private const string TEST_INTERFACE_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\IConverted.cs";
        private const string TEST_EXPECTED_IMPLEMENTATION_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\ExpectedConverted.cs";
        private const string TEST_EXPECTED_INTERFACE_CS_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\ExpectedIConverted.cs";
        private const string TEST_PYTHON_FILE_PATH = TEST_ARTIFACT_FOLDER_PATH + @"\PythonFile.py";

        public void TestInitialization()
        {
            FileSafeCreate(TEST_IMPLEMENTATION_CS_FILE_PATH);
            FileSafeCreate(TEST_INTERFACE_CS_FILE_PATH);
        }



        [TestMethod]
        public void WriteDotNetInterfaceTest()
        {
            InterfaceData interfaceData = CreateInterfaceMockData();
            InterfaceConverter.WriteDotNetInterface(TEST_INTERFACE_CS_FILE_PATH, interfaceData);

            string expectedContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_INTERFACE_CS_FILE_PATH));
            string actualContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_INTERFACE_CS_FILE_PATH));

            Assert.AreEqual(expectedContent, actualContent);
        }

        [TestMethod]
        public void WriteDotNetImplementationTest()
        {
            InterfaceData interfaceData = CreateInterfaceMockData();
            InterfaceConverter.WriteDotNetImplementation(TEST_IMPLEMENTATION_CS_FILE_PATH, interfaceData);

            string expectedContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_EXPECTED_IMPLEMENTATION_CS_FILE_PATH));
            string actualContent = RemoveUnnecessaryChars(FileManagement.ReadFile(TEST_IMPLEMENTATION_CS_FILE_PATH));

            Assert.AreEqual(expectedContent, actualContent);
        }

        [TestMethod]
        public void ReadPythonScriptTest()
        {
            string actualContent = InterfaceConverter.ReadPythonScript(TEST_PYTHON_FILE_PATH);
            string expectedContent = FileManagement.ReadFile(TEST_PYTHON_FILE_PATH);
            
            Assert.AreEqual(expectedContent, actualContent);
        }

        [TestMethod]
        public void ParseCodeTest()
        {
            InterfaceData expectedInterfaceData = CreateInterfaceMockData();
            string script = InterfaceConverter.ReadPythonScript(TEST_PYTHON_FILE_PATH);
            InterfaceData actualInterfaceData = InterfaceConverter.ParseCode(script);
            actualInterfaceData.Namespace = "TestNamespace";

            Assert.AreEqual(expectedInterfaceData,actualInterfaceData);
        }

        private InterfaceData CreateInterfaceMockData()
        {
            return new InterfaceData()
            {
                Namespace = "TestNamespace",
                Name = "ITestInterfaceName",
                InterfaceMethodDatas = new System.Collections.Generic.List<InterfaceMethodData>()
                {
                    new InterfaceMethodData()
                    {
                        Name = "TestMethod",
                        Parameters = new System.Collections.Generic.List<string>(){ "first_param", "second_para"}
                    },
                    new InterfaceMethodData()
                    {
                        Name = "TestMethod2",
                        Parameters = new System.Collections.Generic.List<string>(){ "first_param", "second_para"}
                    },
                }
            };
        }

        private void FileSafeCreate(string path)
        {

            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        private string RemoveUnnecessaryChars(string text)
        {
            return Regex.Replace(text.Replace("\r", "").Replace("\t", ""), @"\s+", "");
        }
    }
}
