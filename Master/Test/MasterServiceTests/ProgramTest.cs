using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterServiceTests
{
    [TestClass]
    public class ProgramTest
    {
        private const string EXE_PATH = @"..\MasterService.exe";
        private const string PROCESS_NAME = "MasterService";

        private const string TEST_URL = "http://localhost:3333/api/method/MethodOne/";

        [TestInitialize]
        public void TestInit()
        {
            Process.Start(EXE_PATH);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if(ProcessesWithName.Length != 0)
            {
                foreach (Process process in ProcessesWithName)
                {
                    process.Kill();
                }
            }
        }



        [TestMethod]
        public void StartProgram()
        {
            Assert.AreNotEqual(0, ProcessesWithName.Length);
        }

        [TestMethod]
        public void GetRequest()
        {
            string expectedText = "TestText";

            string responseString = GetRequest(TEST_URL + expectedText);

            Assert.AreEqual("\""+ expectedText + "\"", responseString);
            Assert.AreNotEqual(expectedText, responseString);
        }


        private string GetRequest(string url)
        {
            string responseString = "";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }

            return responseString;
        }

        private Process[] ProcessesWithName
        {
            get
            {
                return Process.GetProcessesByName(PROCESS_NAME);
            }
        }
    }
}
