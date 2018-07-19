using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncP
{
    // manipulate collection via delegates

    delegate bool IsAGreatherThenB(object a, object b);
    class Program
    {
        //public static void Sort<T>(List<T> values, IsAGreatherThenB IsGreater)
        public static void Sort<T>(List<T> values, Func<object,object,bool> IsGreater)
        {
            for(int i = 0; i < values.Count; i++)
            {
                for(int j = i + 1; j < values.Count; j++)
                    if (IsGreater(values[i], values[j]))
                    {
                        object t = values[i];
                        values[i] = values[j];
                        values[j] = (T)t;
                    }
            }
        }

        public static void Afis<T>(List<T> a)
        {
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(a[i].ToString());
        }
        static void Main(string[] args)
        {
            IsAGreatherThenB CompareByAge = Person.AgeCompare;

            List<Person> Guests = new List<Person>
            {
                new Person("Ion", "Schimb", 18, 175),
                new Person("Vasile", "Vieru", 15, 162),
                new Person("Random", "Ciuvak", 22, 180),
                new Person("Mos", "Nicolae", 25, 189),
                new Person("Tester", "Test", 62, 177),
                new Person("Coffe", "Maniac", 40, 150),
            };

            Afis(Guests);

            //Sort(Guests, CompareByAge);
            Sort(Guests, Person.AgeCompare);

            Console.WriteLine();
            Afis(Guests);

            Sort(Guests, delegate(object a, object b)
            {
                return ((Person)a).Height > ((Person)b).Height;
            });

            Console.WriteLine();
            Afis(Guests);

            Sort(Guests, (a, b) =>
            {
                return ((Person)a).Name.CompareTo(((Person)b).Name) > 0;
            });

            Console.WriteLine();
            Afis(Guests);

            Sort(Guests, (a, b) => ((Person)a).Surname.CompareTo(((Person)b).Surname) > 0);

            Console.WriteLine();
            Afis(Guests);

            Console.WriteLine("\n");
            for(int i = 0; i < Guests.Count; i++)
            {
                Console.WriteLine("Name - {0} , has value = {1}", Guests[i].Name, Guests[i].Name.GetCode());
            }

            var adult = from p in Guests
                        where p.Age >= 18// && p.Height > 160
                        orderby p.Name
                        select p.Name + " " + p.Surname + " " + p.Age;

            Console.WriteLine("\n\n");
            foreach(string t in adult)
            {
                Console.WriteLine(t);
            }

            Console.ReadKey();
        }

    }
}
