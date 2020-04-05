using CommonLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverterLibrary
{
    public static class InterfaceConverter
    {
        public static void WriteDotNetInterface(string dotNetInterfacePath, InterfaceData interfaceData)
        {
            WriteTextToFile(dotNetInterfacePath, interfaceData.GetInterfacePlainText());
        }
        public static void WriteDotNetImplementation(string dotNetInterfacePath, InterfaceData interfaceData)
        {
            WriteTextToFile(dotNetInterfacePath, interfaceData.GetImplementationPlainText());
        }

        public static string ReadPythonScript(string pythonScriptPath)
        {
            return FileManagement.ReadFile(pythonScriptPath);
        }

        public static InterfaceData ParseCode(string pythonCode)
        {
            InterfaceData interfaceData = new InterfaceData();

            interfaceData.Name = StringManipulator.GetTextBetweenBorderTexts(pythonCode, "class ", ":");
            interfaceData.InterfaceMethodDatas = ParseAllMethods(pythonCode);

            return interfaceData;
        }


        private static InterfaceMethodData ParseMethodData(string header)
        {
            InterfaceMethodData interfaceMethodData = new InterfaceMethodData();
            interfaceMethodData.Name = StringManipulator.GetTextEndedWith(header, "(");
            string parameters = StringManipulator.GetTextBetweenBorderTexts(header, "(", ")");
            interfaceMethodData.Parameters.AddRange(parameters.Split(','));
            return interfaceMethodData;
        }

        private static string[] GetHeaders(string pythonCode)
        {
            string[] defSplit = pythonCode.Split(new string[] { "def " }, StringSplitOptions.None);
            string[] headers = new string[defSplit.Length - 1];
            for (int i = 1; i < defSplit.Length; i++)
            {
                string chunk = defSplit[i];
                string header = StringManipulator.GetTextEndedWith(chunk, ":");
                headers[i - 1] = header;
            }
            return headers;
        }


        private static void WriteTextToFile(string path, string text)
        {
            FileManagement.WriteFile(path, text);
        }
        private static List<InterfaceMethodData> ParseAllMethods(string pythonCode)
        {
            List<InterfaceMethodData> interfaceMethodDatas = new List<InterfaceMethodData>();
            string[] headers = GetHeaders(pythonCode);
            foreach (string header in headers)
            {
                InterfaceMethodData interfaceMethodData = ParseMethodData(header);
                interfaceMethodDatas.Add(interfaceMethodData);
            }

            return interfaceMethodDatas;
        }
    }
}
