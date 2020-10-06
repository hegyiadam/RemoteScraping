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
            List<InterfaceMethodParameterData> parameterDatas = GetParameters();

            if (Name.Contains("_return"))
            {
                return "\t\tstring " + Name.Replace("_return", "") + "(" + ParametersPlainText(parameterDatas) + ");\n";
            }
            else
            {
                return "\t\tvoid " + Name + "(" + ParametersPlainText(parameterDatas) + ");\n";

            }
        }

        internal string GetImplementationPlainText()
        {
            string tabPrefix2 = "\t\t";
            string tabPrefix3 = "\t\t\t";
            List<InterfaceMethodParameterData> parameterDatas = GetParameters();
            string result = "";
            if (Name.Contains("_return"))
            {
                result += tabPrefix2 + "public string " + Name.Replace("_return", "") + "(" + ParametersPlainText(parameterDatas) + ")\n\t\t{\n";
            }
            else
            {
                result += tabPrefix2 + "public void " + Name + "(" + ParametersPlainText(parameterDatas) + ")\n\t\t{\n";
            }
            result += tabPrefix3+"string methodName = MethodInfo.GetCurrentMethod().Name;\n";
            result += tabPrefix3+"List<object> parameters = new List<object>();\n";
            foreach(InterfaceMethodParameterData param in parameterDatas)
            {
                result += tabPrefix3 + "parameters.Add("+param.Name+");\n";
            }
            if (Name.Contains("_return"))
            {
                result += tabPrefix3 + "return ApiInvocation.RunCommandOnPython(methodName, parameters);\n";
            }
            else
            {
                result += tabPrefix3 + "ApiInvocation.RunCommandOnPython(methodName, parameters);\n";
            }
            result += tabPrefix2 + "}\n";
            return result;
        }

        private string ParametersPlainText(List<InterfaceMethodParameterData> parameterDatas)
        {
            if (parameterDatas.Count == 0)
            {
                return "";
            }
            string paramsText = parameterDatas[0].ToString();
            for (int i = 1; i < Parameters.Count; i++)
            {
                paramsText += ", " + parameterDatas[i].ToString();
            }

            return paramsText;
        }

        

        private List<InterfaceMethodParameterData> GetParameters()
        {
            List<InterfaceMethodParameterData> parameterDatas = new List<InterfaceMethodParameterData>();
            
            foreach (string param in Parameters)
            {
                parameterDatas.Add(new InterfaceMethodParameterData(param));
            }
            return parameterDatas;
        }

    }


}
