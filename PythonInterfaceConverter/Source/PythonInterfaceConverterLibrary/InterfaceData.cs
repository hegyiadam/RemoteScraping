using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverter.Source.PythonInterfaceConverterLibrary
{
    public class InterfaceData
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<InterfaceMethodData> InterfaceMethodDatas { get; set; } = new List<InterfaceMethodData>();

        internal string GetInterfacePlainText()
        {
            string result = "namespace " + Namespace + "\n{\n\tpublic interface " + Name + "\n\t{\n";
            foreach (InterfaceMethodData data in InterfaceMethodDatas)
            {
                result += data.GetInterfacePlainText();
            }
            result += "\t}\n}";
            return result;
        }
        internal string GetImplementationPlainText()
        {
            string basicUsings = "using PythonInterfaceConverterLibrary;\nusing System.Collections.Generic;\nusing System.Reflection;\n\n";
            string result = basicUsings + "namespace " + Namespace + "\n{\n\tpublic class " + Name.Remove(0,1) + " : "+Name+"\n\t{\n";
            foreach (InterfaceMethodData data in InterfaceMethodDatas)
            {
                result += data.GetImplementationPlainText();
            }
            result += "\t}\n}";
            return result;
        }

        public override bool Equals(object obj)
        {
            InterfaceData interfaceData = (InterfaceData)obj;
            return GetInterfacePlainText().Equals(interfaceData.GetInterfacePlainText());
        }
    }
}
