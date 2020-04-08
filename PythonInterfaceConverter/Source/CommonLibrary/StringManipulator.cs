using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonInterfaceConverter.Source.CommonLibrary
{
    static public class StringManipulator
    {
        public static string GetTextEndedWith(string source, string end)
        {
            int pTo = source.IndexOf(end);
            return source.Substring(0, pTo);
        }

        public static string GetTextBetweenBorderTexts(string source, string start, string end)
        {
            int pFrom = source.IndexOf(start) + start.Length;
            int pTo = source.IndexOf(end);

            String result = source.Substring(pFrom, pTo - pFrom);
            return result;
        }
    }
}
