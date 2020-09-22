using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MasterConnection
{
    public class MasterConnection
    {
        public static void RunCommand(string methodName, object parameter)
        {
            string url = GetUrlAddressForMethod(methodName);
            string json = CreateJsonFromParameters(parameter);
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

            WebResponse webResponse = httpWebRequest.GetResponse();

            return httpWebRequest;
        }

        private static string CreateJsonFromParameters(object parameter)
        {
            string json = JsonConvert.SerializeObject(parameter);
            return json;
        }


        private static string GetUrlAddressForMethod(string cmdName)
        {
            return "http://localhost:3333/api/method/" + cmdName;
        }
    }
}
