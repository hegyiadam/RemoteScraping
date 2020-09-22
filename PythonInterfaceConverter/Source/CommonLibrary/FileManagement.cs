using System.IO;
using System.Reflection;
using System.Text;

namespace CommonLibrary
{
    public class FileManagement
    {
        private const char NEW_LINE_STRING = '\n';
        
        public static void WriteFile(string filePath, string content)
        {
            string[] lines = content.Split(NEW_LINE_STRING);
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                int allLinesCount = lines.Length;
                int lastLineIndex = allLinesCount - 1;
                for (int i = 0; i < allLinesCount; i++)
                {
                    outputFile.Write(lines[i]);
                    if(i != lastLineIndex)
                    {
                        outputFile.Write(NEW_LINE_STRING);
                    }
                }
            }
        }

        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        public static string GetAssemblyTextResource(Assembly assembly, string resourceName)
        {
            string path = Path.GetDirectoryName(assembly.Location);
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            
        }
    }
}
