using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace cw2
{
    public class Logger
    {
        public static StringBuilder tekst = new StringBuilder();
        
        public static void Argerror(string s)
        {
            tekst.Append(DateTime.UtcNow + " : Niepoprwany Argument wprowadzono -  " + s);
            throw new System.ArgumentException("Wprowadzony argument jest niepoprawny");
        }
    }
}