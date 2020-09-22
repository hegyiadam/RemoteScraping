using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using CommonLibrary;
using PythonInterfaceConverterLibrary;

namespace PythonInterfaceConverter
{
    public class Program
    {
        private const string HELP_COMMAND_STRING = "?";
        private const string FULL_CONVERT_COMMAND_STRING = "full";
        private const string INTERFACE_CONVERT_COMMAND_STRING = "inter";
        private const string IMPLEMENTATION_CONVERT_COMMAND_STRING = "impl";

        public static void Main(string[] args)
        {
            try
            {
                CommandSeparator(args);
            }
            catch (Exception e)
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

            string commandString = args[0];
            switch (commandString)
            {
                case HELP_COMMAND_STRING:
                    HelpCommand();
                    break;
                case FULL_CONVERT_COMMAND_STRING:
                    FullCommand(args);
                    break;
                case INTERFACE_CONVERT_COMMAND_STRING:
                    InterfaceCommand(args);
                    break;
                case IMPLEMENTATION_CONVERT_COMMAND_STRING:
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
            string commandString = args[0];
            switch (commandString)
            {
                case IMPLEMENTATION_CONVERT_COMMAND_STRING:
                    return ClassifieImplementationCommandArgs(args);
                case INTERFACE_CONVERT_COMMAND_STRING:
                    return ClassifieInterfaceCommandArgs(args);
                case FULL_CONVERT_COMMAND_STRING:
                    return ClassifieFullCommandArgs(args);
            }

            throw new ArgumentException(String.Join(",",args));
        }

        private static ClassifiedArgs ClassifieImplementationCommandArgs(string[] args)
        {
            ClassifiedArgs classifiedArgs = new ClassifiedArgs()
            {
                PythonSourceFilePath = args[1],
                ImplementationTargetFilePath = args[2],
                Namespace = args[3]
            };
            return classifiedArgs;
        }
        private static ClassifiedArgs ClassifieInterfaceCommandArgs(string[] args)
        {
            ClassifiedArgs classifiedArgs = new ClassifiedArgs()
            {
                PythonSourceFilePath = args[1],
                InterfaceTargetFilePath = args[2],
                Namespace = args[3]
            };
            return classifiedArgs;
        }
        private static ClassifiedArgs ClassifieFullCommandArgs(string[] args)
        {
            ClassifiedArgs classifiedArgs = new ClassifiedArgs()
            {
                PythonSourceFilePath = args[1],
                InterfaceTargetFilePath = args[2],
                ImplementationTargetFilePath = args[3],
                Namespace = args[4]
            };
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
