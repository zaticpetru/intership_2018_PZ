using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person("Samuel", "Adam", "USA", 2909, Ocupation.Driver, 50),
                new Person("Hugo", "Ball", "Russia", 8546, Ocupation.Teacher, 22),
                new Person("Vasilica", "Popescu", "Moldova", 2008, Ocupation.NoOcupation, 12),
                new Person("Tony", "Benn", "UK", 5545, Ocupation.Programer, 31),
                new Person("Ludvic", "Bethoven", "Moldova", 2003, Ocupation.NoOcupation, 96),
                new Person("Iulius", "Cesar", "Moldova", 2001, Ocupation.Programer, 27),
                new Person("Ivan", "Vasileveci", "Russia", 8574, Ocupation.Plumber, 50),
                new Person("Tina", "Ferguson", "USA", 2909, Ocupation.Driver, 45),
                new Person("Anna", "Bunescu", "Moldova", 2009, Ocupation.Teacher, 34),
                new Person("Ford", "Fisher", "USA", 2960, Ocupation.NoOcupation, 10),
                new Person("Ford", "Fisher", "USA", 2960, Ocupation.NoOcupation, 10),
                new Person("Daria", "Pliu", "Russia", 8546, Ocupation.NoOcupation, 40, new List<string> {"Denis", "Masha", "Ira"})
            };

            List<Country> countries = new List<Country>
            {
                new Country("Moldova","Mamaliga"),
                new Country("USA","White House"),
                new Country("Russia", "Balalaica"),
                new Country("UK","BigBang")
            };

            IEnumerable<Person> qWhere = people//.Take(3) // will take first three persons in list, then filter them by ocupation
                                               .Where(person => person.tOcupation != Ocupation.NoOcupation)
                                               .Take(3) // take first 3 persons with ocupation
                                               .Skip(1);// skip first person with ocupation
            //foreach (Person p in qWhere) Console.WriteLine(p.ToString() + "\n");

            IEnumerable<Person> qWhile = people.SkipWhile(person => person.BirthContury != "UK")
                                               .TakeWhile(person => person.Age > 18);
            //foreach (Person p in qWhile) Console.WriteLine(p.ToString() + "\n");

            IEnumerable<string> qDistinct = people//.Distinct() // uncoment Distinct for no repeat names
                                                  .Select(person => person.Name + " " + person.Surname);
            //foreach (string p in qDistinct) Console.WriteLine(p + "\n");



            var qSelectMany = people.Where(person => person.Parent())
                                    .SelectMany(parent => parent.Childrens, (parent, children) => new { parent, children });
            //foreach (var p in qSelectMany) Console.WriteLine(p);


            var qJoin = countries.GroupJoin(people,
                        country => country.Name,
                        person => person.BirthContury,
                        (c, p) => new
                        {
                            Country = c.Name,
                            Specific = c.Specific,
                            LiveIn = p.Select(pl => pl.Name + " " + pl.Surname)
                        }
                        );

            //foreach(var t in qJoin)
            //{
            //    Console.WriteLine(t.Country + " - enjoy " + t.Specific);

            //    foreach (string p in t.LiveIn)
            //        Console.WriteLine("    " + p);

            //    Console.WriteLine();
            //}

            var qZip = people.Zip(people.Skip(1), (f, s) => f.Name + " is precedend to " + s.Name);

            //foreach (string t in qZip)
            //    Console.WriteLine(t);

            //Console.ReadKey();
        }
    }
}
