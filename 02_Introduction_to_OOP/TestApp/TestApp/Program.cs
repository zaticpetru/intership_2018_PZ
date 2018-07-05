using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Ion = new Human("Vaaanea");
            Human Alex = new Human("Alexx");

            Ion.Sing();
            Alex.Sing();

            Console.ReadKey();
        }
    }
}
