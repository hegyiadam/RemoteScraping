using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverterLibrary
{
    public class InterfaceMethodData
    {
        public string Name { get; set; }
        public List<string> Parameters { get; set; } = new List<string>();
        internal string GetInterfacePlainText()
        {
            return "\t\tvoid " + Name + "(string " + String.Join(", string", Parameters) + ");\n";
        }

        internal string GetImplementationPlainText()
        {
            string tabPrefix2 = "\t\t";
            string tabPrefix3 = "\t\t\t";
            string result = tabPrefix2 + "public void " + Name + "(string " + String.Join(", string", Parameters) + ")\n\t\t{\n";
            result += tabPrefix3+"string methodName = MethodInfo.GetCurrentMethod().Name;\n";
            result += tabPrefix3+"List<string> parameters = new List<string>();\n";
            foreach(string param in Parameters)
            {
                result += tabPrefix3 + "parameters.Add("+param+");\n";
            }
            result += tabPrefix3 + "ApiInvocation.RunCommandOnPython(methodName, parameters);\n";
            result += tabPrefix2 + "}\n";
            return result;
        }
    }
}
