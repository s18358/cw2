using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace cw2
{
    public static class Converter
    
    {
        private static string _path;
        private static string _type;
        private static HashSet<Student> _hash;
        private static DateTime today = DateTime.Today;
        public static void Create(string p, string t, HashSet<Student> hash)
        {
            _path = p;
            _type = t;
            _hash = hash;

            switch (t)
            {
                case "xml":
                {
                    XMLmake();
                    break;
                }
                case "json":
                {
                    JSONmake();
                    break;
                }
            }
            
        }

        private static void JSONmake()
        {
            
        }

        private static void XMLmake()
        {
            XElement file = new XElement("uczelnia",
            new XAttribute("createdAt", today.ToString("dd.MM.yyyy")),
            new XAttribute("author", "Michal Warchal"), 
            new XElement("studenci",
            from stud in _hash
            select new XElement(
                new XElement("student",
                            new XAttribute("indexNumber", stud.Index),
                            new XElement("fname", stud.FirstName),
                            new XElement("lname", stud.LastName),
                            new XElement("birthdate", stud.BirthDate),
                            new XElement("email", stud.Email),
                            new XElement("mothersname", stud.Mother),
                            new XElement("fathersname", stud.Father),
                            new XElement("studies", 
                                new XElement("name", stud.Studies),
                                new XElement("mode", stud.StudType)
                                )
                            )
                        )
                    )
                );
            file.Save(_path);
        }
    }
}