using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using PythonInterfaceConverter.Source.CommonLibrary;
using PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary;

namespace PythonInterfaceConverter.Source.PythonInterfaceConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CommandSeparator(args);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------");
                HelpInfo();
            }
        }

        private static void CommandSeparator(string[] args)
        {

            if (args.Length == 0)
            {
                WrongParameterInfo();
                return;
            }

            string command = args[0];
            switch (command)
            {
                case "?":
                    HelpCommand();
                    break;
                case "full":
                    FullCommand(args);
                    break;
                case "inter":
                    InterfaceCommand(args);
                    break;
                case "impl":
                    ImplementationCommand(args);
                    break;
                default:
                    WrongParameterInfo();
                    break;
            }
        }

        private static void HelpCommand()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = ConfigurationManager.AppSettings.Get("HelpTextResourceName");

            string helpText = FileManagement.GetAssemblyTextResource(assembly, resourceName);

            Console.WriteLine(helpText);
        }

        private static void ImplementationCommand(string[] args)
        {
            ClassifiedArgs classifiedArgs = ParseArgs(args);
            ConvertPythonClassImplementation(classifiedArgs);
        }

        private static void InterfaceCommand(string[] args)
        {
            ClassifiedArgs classifiedArgs = ParseArgs(args);
            ConvertPythonClassInterface(classifiedArgs);
        }

        private static void FullCommand(string[] args)
        {
            ClassifiedArgs classifiedArgs = ParseArgs(args);
            ConvertPythonClassFull(classifiedArgs);
        }



        private static void WrongParameterInfo()
        {
            Console.WriteLine("Bad parameter usage!");
            HelpInfo();
        }

        private static void HelpInfo()
        {
            Console.WriteLine("Use \"PythonInterfaceConverter.exe ?\" to get help");
        }

        private static void Helper()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string helpText = FileManagement.ReadFile(path + "HelpText.txt");
            Console.WriteLine(helpText);
        }

        private static void ConvertPythonClassFull(ClassifiedArgs classifiedArgs)
        {
            ConvertPythonClassInterface(classifiedArgs);
            ConvertPythonClassImplementation(classifiedArgs);
        }
        private static void ConvertPythonClassInterface(ClassifiedArgs classifiedArgs)
        {
            InterfaceData interfaceData = ParsePythonCode(classifiedArgs);
            InterfaceConverter.WriteDotNetInterface(classifiedArgs.InterfaceTargetFilePath, interfaceData);
        }
        private static void ConvertPythonClassImplementation(ClassifiedArgs classifiedArgs)
        {
            InterfaceData interfaceData = ParsePythonCode(classifiedArgs);
            InterfaceConverter.WriteDotNetImplementation(classifiedArgs.ImplementationTargetFilePath, interfaceData);
        }

        private static InterfaceData ParsePythonCode(ClassifiedArgs classifiedArgs)
        {
            string pythonCode = InterfaceConverter.ReadPythonScript(classifiedArgs.PythonSourceFilePath);
            InterfaceData interfaceData = InterfaceConverter.ParseCode(pythonCode);
            interfaceData.Namespace = classifiedArgs.Namespace;
            return interfaceData;
        }

        private static ClassifiedArgs ParseArgs(string[] args)
        {
            ClassifiedArgs classifiedArgs = new ClassifiedArgs();
            if (args.Length == 4)
            {
                classifiedArgs.PythonSourceFilePath = args[1];
                if(args[0] == "impl")
                {
                    classifiedArgs.ImplementationTargetFilePath = args[2];
                }
                else
                {
                    classifiedArgs.InterfaceTargetFilePath = args[2];
                }
                classifiedArgs.Namespace = args[3];
            }
            if (args.Length == 5)
            {
                classifiedArgs.PythonSourceFilePath = args[1];
                classifiedArgs.InterfaceTargetFilePath = args[2];
                classifiedArgs.ImplementationTargetFilePath = args[3];
                classifiedArgs.Namespace = args[4];
            }
            return classifiedArgs;
        }
        private struct ClassifiedArgs
        {
            public string PythonSourceFilePath;
            public string InterfaceTargetFilePath;
            public string ImplementationTargetFilePath;
            public string Namespace;
        }
    }
}
