using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4
{
    class Program
    {

        static void FindNames(ref string a)
        {
            string[] words = a.Split(' ');

            int r = 0;
            foreach(string t in words)
            {
                if (t[0] >= 'A' && t[0] <= 'Z') { Console.WriteLine(t); r++; }
            }

            string[] rs = new string[r];

            r = 0;
            foreach (string t in words)
            {
                if (t[0] >= 'A' && t[0] <= 'Z') { rs[r++] = t; }
            }

            a  = string.Join("!!!!!!!!!!!\n", rs);
        }

        static void Main(string[] args)
        {
            string list = "Eu cu Vasioc si cu Liolic am dat examenele de stat";

            Console.WriteLine(list+"\n\n");
            FindNames(ref list);

            Console.WriteLine(list);
            Console.ReadKey();
        }
    }
}
