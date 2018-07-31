using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CSharpFeatureas
{
    class Crujca
    {
        public string Name { get; }
        public string MadeIn { get; }
        public string Material { get; }
        public string FiledWith { get; }

        public bool IsCool { get; } = true;

        public Crujca(string filedWith = "Nothing", string madeIN = "Moldova", string material = "Mednaia" , string name = "Crujca")
        {
            FiledWith = filedWith ?? throw new ArgumentNullException(nameof(filedWith));
            MadeIn = madeIN;
            Material = material;
            Name = name;
        }

        public override string ToString()
                => $"{nameof(Name)} = {Name}\n" +
                   $"{nameof(MadeIn)} = {MadeIn}\n" +
                   $"{nameof(Material)} = {Material}\n" +
                   $"{nameof(FiledWith)} = {FiledWith}\n";
        
    }
    class Program
    {
        static int Multiply(int a, int b, int c = 1, int d = 1, int e = 1)
        {
            return a * b * c * d * e;
            //optional parameters
        }

        static int Sum(params int[] arr)
        {
            return arr.Sum();
            //array of params
        }

        static void CW(dynamic t)
        {
            WriteLine(t);
        }

        static void Main(string[] args)
        {
            WriteLine($"2 * 3 = {Multiply(2, 3)}");
            WriteLine($"2 * 3 * -4 = {Multiply(2, 3, -4)}");
            WriteLine($"2 * 3 * 4 * 5 = {Multiply(2, 3, 4, 5)}");
            WriteLine($"21 * 13 * 33 * 4 * 6 = {Multiply(21, 13, 33, 4, 6)}");

            WriteLine($"sum of 10 random numbers = {Sum(10, 23, 1, 36, 2, 234, 65, 13, 455, 54, 53, 54, 54, 21, 2, 54)}");

            Crujca[] Servis = { //new Crujca(filedWith: null),
                                new Crujca(material: "porcelan", filedWith:"Lapte"),
                                new Crujca(filedWith: "jin", name: "Obshaia"),
                                new Crujca(filedWith: "Shampanie", name: "Bocal", material:"Hrustali", madeIN:"France")};


            WriteLine();
            foreach (Crujca crujca in Servis)
                CW(crujca.ToString());


            dynamic dynamicVariable = 100;
            WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = "Hello World!!";
            WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = true;
            WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = DateTime.Now;
            WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            var testInitializers = new Dictionary<int, string>()
            {
                {1,"first" },
                {3,"third" }
            };

            var testInitializers2 = new Dictionary<int, string>()
            {
                [2] = "second",
                [4] = "fourth"
            };

            testInitializers = testInitializers.Concat(testInitializers2)
                                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var t in testInitializers) CW(t.ToString());

            string test = null;
            WriteLine("test is =  " + (test?.Length ?? 0) );

            void square(int x, out int res)
            {
                res = x * x;
            }

            int y = 4;
            square(y, out int fourInSquare);
            WriteLine($"4^2 = {fourInSquare}");

            object[] ObjectArray = { "Anna", 9.3, 5.4f, 222, 21, "ala" };

            int Summa = 0;
            int StringCount = 0;

            foreach(object i in ObjectArray)
            {
                if (i is int value)
                    Summa += value;

                string j = i as string;

                if (j != null)
                    StringCount++;

            }

            WriteLine("Strign count in object array = {0}", StringCount);
            WriteLine("Sum of integers in object array = {0}", Summa);

            ReadKey();
        }
    }
}