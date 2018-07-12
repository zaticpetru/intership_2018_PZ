using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    class Program
    {

        static void DeleteEven(ref int[] a) // punctul 1
        {
            int j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 1) j++;
            }

            int[] b = new int[j];

            j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 1) b[j++] = a[i];
            }
            a = b;
        }

        static int FirstDigit(int n)
        {
            while (n > 10) n /= 10;
            return n;
        }

        static void InsertAfter(int digit, ref int[] a)
        {
            int j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (FirstDigit(a[i]) == digit) j++;
            }

            int[] b = new int[j + a.Length];

            j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                b[j++] = a[i];
                if (FirstDigit(a[i]) == digit) j++;                
            }
            a = b;
        }

        static void DeleteRepeat(ref int[] a)
        {
            int j = 0;
            int[] toDelete = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (toDelete[i] == 0)
                {
                    j++;
                    for (int k = i + 1; k < a.Length; k++) if (a[k] == a[i]) { toDelete[k] = 1;}
                }
            }

            int[] b = new int[j];

            j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (toDelete[i] == 0) b[j++] = a[i];
            }
            a = b;
        }

        static void Main(string[] args)
        {
            int[] test = { 2, 4, 6, 8, 221, 2, 13, 4, 31, 2, 44, 45, 44, 45 };

            for(int i = 0; i < test.Length; i++)
            {
                Console.Write(test[i] + " ");
            }

            //DeleteEven(ref test);
            //InsertAfter(4, ref test);
            DeleteRepeat(ref test);

            Console.WriteLine();
            for (int i = 0; i < test.Length; i++)
            {
                Console.Write(test[i] + " ");
            }

            Console.ReadKey();

        }
    }
}
