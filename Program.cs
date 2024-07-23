using System;
using System.Collections.Generic;
using System.IO;
using SeDeAssn.Models;
using System.Text.Json;
using System.Configuration;

namespace SeDEAssn
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"].ToString();

        static void Main(string[] args)
        {
            List<Person> persons;

            if (File.Exists(path))
            {
                string jsonData1 = File.ReadAllText(path);
                persons = JsonSerializer.Deserialize<List<Person>>(jsonData1);
            }
            else
            {
                persons = GeneratePersons();
                string jsonData1 = JsonSerializer.Serialize(persons);
                File.WriteAllText(path, jsonData1);



            }

            DisplayPersons(persons);
        }

        static List<Person> GeneratePersons()
        {
            //            //Serializer(person);
            //Deserialize();
            //        }

            //        static void Serializer(Person person)
            //        {
            //            using (StreamWriter sw = new StreamWriter(path))
            //            {
            //                sw.WriteLine(JsonSerializer.Serialize(person));
            //            }

            //        }
            return new List<Person>
            {


                new Person { Id = 1, Name = "Allen", Email = "allen@gmail.com\n" },
                new Person { Id = 2, Name = "Alex", Email = "alex@gmail.com\n" },
                new Person { Id = 3, Name = "brimstone", Email = "brim@gmail.com\n" },
                new Person { Id = 4, Name = "Mary", Email = "mary@gmail.com\n" },
                new Person { Id = 5, Name = "Allen2", Email = "Allen2@gmail.com\n" }
            };
        }

        static void DisplayPersons(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine($"Total persons: {persons.Count}");
        }
    }
}
