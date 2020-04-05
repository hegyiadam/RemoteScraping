using System;
using System.IO;
using System.Reflection;
using CommonLibrary;
using PythonInterfaceConverterLibrary;

namespace PythonInterfaceConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CommandSeparator(args);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR");
                WrongParameterInfo();
                Console.WriteLine(e.InnerException);
            }
            #if DEBUG
            Console.ReadKey();
            #endif
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
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string helpText = FileManagement.ReadFile(path + @"\PythonInterfaceConverter_HelpText.txt");
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
