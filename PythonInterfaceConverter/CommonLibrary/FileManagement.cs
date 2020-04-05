using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class FileManagement
    {
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }
        public static void WriteFile(string path, string content)
        {
            string[] lines = content.Split('\n');
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }

        }

    }
}
