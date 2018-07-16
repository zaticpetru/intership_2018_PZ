using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex5
{
    class Program
    {

        static int Power(int b, int p)
        {
            if (p == 0) return 1;
            return (b * Power(b, p - 1));
        }
        static void Main(string[] args)
        {
            int b;
            bool isNum;
            do
            {
                Console.Write("Enter base:");
                isNum = int.TryParse(Console.ReadLine(), out b);
            } while (!isNum);

            int p;
            do
            {
                Console.Write("Enter power:");
                isNum = int.TryParse(Console.ReadLine(), out p);
            } while (!isNum);

           

            Console.WriteLine(Power(b, p));

            Console.ReadKey();
        }
    }
}
