using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary
{
    class InterfaceMethodParameterData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public InterfaceMethodParameterData(string parameter)
        {

            if (parameter.Length <= 2)
            {
                StringParam(parameter);
            }
            string prefix = parameter.Substring(0, 2);
            string typedParam = "";
            switch (prefix)
            {
                case "i_":
                    IntParam(parameter);
                    break;
                case "d_":
                    DecimalParam(parameter);
                    break;
                case "b_":
                    BoolParam(parameter);
                    break;
                default:
                    StringParam(parameter);
                    break;
            }
        }
        private void IntParam(string parameter)
        {
            Type = "int";
            Name = RemovePrefix(parameter);
        }
        private void BoolParam(string parameter)
        {
            Type = "bool";
            Name = RemovePrefix(parameter);
        }
        private void DecimalParam(string parameter)
        {
            Type = "double";
            Name = RemovePrefix(parameter);
        }

        private void StringParam(string parameter)
        {
            Type = "string";
            Name = parameter;
        }

        private string RemovePrefix(string parameter)
        {
            return parameter.Substring(2, parameter.Length - 2);
        }

        public override string ToString()
        {
            return Type + " " + Name;
        }
    }
}
