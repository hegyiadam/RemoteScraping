# Python Converter
## What is python converter?
Converter is a command line application written in C#.
## Why is it needed?
To run Python script from DotNet code a Python REST Api (Flask) is implemented. Pyhton is the host the DotNet code is the client. In the communicaion the C# code is generic because it has no other logic than just POST request creation to the REST Api. In python the basic structure on the edge of the component is a interface which includes all the callable commands. This means that the DotNet code needs to be cosistent with the python interface. Converter creates a consistent interface in DotNet using the python code and also creates an implementation which is basicly the parametrized call of the python function.

## How to use?

To use the converter prepare your DotNet target by createing the interface and the implementation
_This is necessary because Visual Studio would not add the new generated file to the project by creating the file the file will be attached to the project_
Then call the executable converter file. You can use the following parameters:
```
PythonInterfaceConverter.exe full <python_filepath> <interface_filepath> <implementation_filepath> <namespace>
PythonInterfaceConverter.exe inter <python_filepath> <interface_filepath> <namespace>
PythonInterfaceConverter.exe impl <python_filepath> <implementation_filepath> <namespace>

python_filepath : absolute path to source python interface file (python class name needs to start with "I" letter)
interface_filepath : absolute path to the target .cs file which will be the interface
implementation_filepath : absolute path to the target the target .cs file which will be the implementation

For implementation the converter removes the "I" letter from the name of the interface
```
You can reach this help by using ? in command line argument.

## Automated usage

Command line application is not too helpful if we need to write all parameters every time. By using Visual Studio Pre-build steps you can automate the refresh of the implementation:
- Open your project's properties ( Right click on the project name -> Properties)
- Open "Build Events" tab
- In the "Pre-build event command line" you can give the command you want to run before every build

## Coding guideline

Parsable Python code is required to code creation. That is why you should follow the guidelines bellow:
- Use interface as the source of your createion. This means start the class name with "I" letter and do not implement the methods only pass them. Also to make sure your code will be parsed properly keep your interface code as pure as possible.
- Use type prefixes: i_ for integers; b_ for bools; d_ for decimal numbers (the values without prefix will be detected as strings) _Prefixes will be removed in code generation so do not use names with only prefix difference_