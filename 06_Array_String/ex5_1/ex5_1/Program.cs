using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex5_1
{
    class Program
    {

        static char[] Normalize(string s)
        {
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' || s[i] == ',' || s[i] == '.' || s[i] == '!' || s[i] == '?' || s[i] == '\t' || s[i] == '\n') k++;
            }
            char[] NoSp = new char[s.Length - k];

            k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' || s[i] == ',' || s[i] == '.' || s[i] == '!' || s[i] == '?' || s[i] == '\t' || s[i] == '\n') continue;
                NoSp[k++] = s[i];
            }
            return NoSp;
        }

        static bool Palindrom(char[] NoSp)
        {
            int k = NoSp.Length;
            bool rs = true;

            Stack st = new Stack();
            for (int i = 0; i < k / 2; i++) st.Push(NoSp[i]);
            for (int i = k/2 + (k%2); i < k; i++) if((char)st.Pop() != NoSp[i]) rs = false;

            return rs;
        }
        static void Main(string[] args)
        {
            string s = "ab     a";
            Console.WriteLine("{0} is {1} palindrom", new string(Normalize(s)), (Palindrom(Normalize(s)) ? "a" : "not a"));

            Console.ReadKey();
        }
    }
}
