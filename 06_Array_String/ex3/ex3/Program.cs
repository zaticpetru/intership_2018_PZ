using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    class Program
    {

        static void DublicateChar(ref string s, char c)
        {
            int k = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == c) k++;
            }
            char[] response = new char[s.Length + k];

            k = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == c) response[k++] = s[i];
                response[k++] = s[i];
            }

            s = new string(response);
        }
        static void Main(string[] args)
        {
            string test = "sarmisegetusa";

            Console.WriteLine(test);
            DublicateChar(ref test, 's');
            Console.WriteLine(test);

            Console.ReadKey();
        }
    }
}
