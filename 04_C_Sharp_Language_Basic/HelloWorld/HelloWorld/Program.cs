

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class testReference
    {
        public int a;
        public int b;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 9;
            double c = 6.32;
            float d = 333.33f;

            Console.WriteLine("Hello World! I'm C#,\nhere you can see some of my basic results: " + a + b + "  " +  (c + d) + " --- > {0}", Math.Round(c + d, 2));

            d = (float)c;
            c++; 
            Console.WriteLine("\nAfter d = c, and c ++ we have:\nc = {0} , d = {1}", Math.Round(c,2), Math.Round(d, 2));



            Console.ReadKey();
        }
    }
}
