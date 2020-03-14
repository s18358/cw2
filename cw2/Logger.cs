using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace cw2
{
    public static class Logger
    {
        private static StringBuilder Tekst = new StringBuilder();
        
        public static void Log(string s)
        {
            Tekst.Append(DateTime.UtcNow + " : " + s + "\r\n");
        }

        public static void Close()
        {
            var output = Tekst.ToString();
            StreamWriter OutputFile = new StreamWriter(@"..\..\..\log.txt");
            OutputFile.Write(Tekst);
            OutputFile.Close();
        }
    }
}