using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace cw2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //obsluga argumentow wejscia
            var input = new string[3] {@"..\..\..\dane.csv", @"..\..\..\result.xml", "xml"};
            var count = 0;
            var amount = args.Length;
            if (args.Length > 0 && args.Length <= 3)
            {
                foreach (var arg in args)
                {
                    if (arg.EndsWith(".csv"))
                    {
                        input[0] = arg;
                        count++;
                    }
                    else if (arg.EndsWith(".xml") || arg.EndsWith(".json"))
                    {
                        input[1] = arg;
                        count++;
                    }
                    else if (arg == "xml" || arg == ".json")
                    {
                        input[2] = arg;
                        count++;
                    }
                }
            } else if (args.Length > 3)
            {
                Console.WriteLine("Niepoprawana ilosc argumentow. Zamykanie programu");
                Logger.Log("Ilosc argumentow wejsciowych przekracza 3");
                Logger.Close();
                Environment.Exit(-2);
            }
            if (count != amount)
            {
                Console.WriteLine("Blad w argumentach przy wywolaniu");
                Logger.Log("Argumenty wywolania nieprawidlowe");
                Logger.Close();
                Environment.Exit(-2);
            }
            // weryfikacja i spisanie z pliku csv
            
            var path = input[0];
            
            if (!File.Exists(path))
            {
                Logger.Log("Plik " + input[0] + " nie istnieje");
                Logger.Close();
                throw new FileNotFoundException("Plik " + input[0] + " nie istnieje");
            }

            var lines = File.ReadLines(path);
            
            //stworzenie listy z danych z pliku z odrzuceniem niepoprwanych danych
            List<Student> list = new List<Student>();

            foreach (var line in lines)
            {
                Console.WriteLine(line);
                int commas = line.Split(',').Length - 1; //sprawdzanie ilosci przecinkow
                if (commas == 8 && !line.Contains(",,") && !line.Contains(", ,"))
                {
                    var student = new Student(line);
                    list.Add(student);
                } else {
                    Logger.Log("Niepoprwane dane studenta " + line);
                }
                
            }
            // przejsc przez dane i wywalic/zalogowac duplikaty i logowac do pliku
            var hash = new HashSet<Student>(new Duplikat());
            foreach (var s in list)
            {
                if (!hash.Add(s))
                {
                    Logger.Log("Dane studenta znajduja sie juz w plik : " + s.ToString());
                }
            }


            // przygotowac dane do xml/json
            // seriazlizacja
            // zmakniecie logow i zapisanie
            // zapisanie do pliku
            
            Logger.Close();
        }
    }
}