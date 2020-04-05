using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverterLibrary
{
    public class ApiInvocation
    {
        public static void RunCommandOnPython(string methodName, List<string> parameters)
        {
            string url = GetUrlAddressForMethod(methodName);
            string json = CreateJsonFromParameters(parameters);
            HttpWebRequest request = CreateJsonPostRequest(url, json);
            string result = GetResponseFromRequest(request);

        }

        private static string GetResponseFromRequest(HttpWebRequest request)
        {
            string result = "";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private static HttpWebRequest CreateJsonPostRequest(string url, string jsonBody)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
            }
            return httpWebRequest;
        }

        private static string CreateJsonFromParameters(List<string> parameters)
        {
            string json = "{\"params\": [";

            if (parameters.Count > 0)
            {
                json += "\"" + parameters[0] + "\"";
                if (parameters.Count > 1)
                {
                    for (int i = 1; i < parameters.Count; i++)
                    {
                        json += ",\"" + parameters[i] + "\"";
                    }
                }
            }

            json += "]}";
            return json;
        }


        private static string GetUrlAddressForMethod(string cmdName)
        {
            string prefix = ConfigurationManager.AppSettings["PythonRestApi_ProtocollPrefix"];
            string host = ConfigurationManager.AppSettings["PythonRestApi_Host"];
            string port = ConfigurationManager.AppSettings["PythonRestApi_Port"];
            string cmdURL = ConfigurationManager.AppSettings["CommandPath"];
            string url = prefix + "://" + host + ":" + port + "/" + cmdURL + "/" + cmdName;
            return url;
        }
    }
}
