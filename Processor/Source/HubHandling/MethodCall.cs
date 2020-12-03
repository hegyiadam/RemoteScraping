using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public class MethodCall
    {
        public MethodCall(string functionName, object[] parameters)
        {
            MethodName = functionName;
            Parameters = ConvertParametersToString(parameters);
        }

        public string MethodName { get; set; }
        public string Parameters { get; set; }

        private static string ConvertParametersToString(object[] parameters)
        {
            return string.Join(",", parameters);
        }
    }
}
