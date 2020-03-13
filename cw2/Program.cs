using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace cw2
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            
            var adr = @"data.csv"; 
            var dest = @"result.xml";
            var ext = @"xml";
            var arguments = new int[3];
            // zrobic foreach na args i przypisac wartosci do switcha gdyby wprowadzne dane potane przy execute nie były po kolej 

            if(args[0].EndsWith(".csv")) {
                adr = args[0];
            } else {
                Logger.Argerror(args[0]);
            }
            
            // spisac wszystko z pliku
            // przejsc przez dane i wywalic/zalogowac duplikaty i logowac do pliku
            // przygotowac dane do xml/json
            // seriazlizacja
            // zmakniecie logow i zapisanie
            // zapisanie do pliku
        }
    }
}