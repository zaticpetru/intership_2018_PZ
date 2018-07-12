using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        static void DeleteZero(ref int[,] a)
        {
            bool zero = true;
            int I = a.GetLength(0);
            int J = a.GetLength(1);
            bool[] deleteI = new bool[I];
            bool[] deleteJ = new bool[J];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                zero = true;
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    //Console.Write(a[i, j]);
                    if (a[i, j] != 0) { zero = false; continue; }
                }
                deleteI[i] = zero;
                if (zero) I--;
                //Console.WriteLine();
            }

            for (int j = 0; j < a.GetLength(1); j++) 
            {
                zero = true;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    //Console.Write(a[i, j]);
                    if (a[i, j] != 0) { zero = false; continue; }
                }
                deleteJ[j] = zero;
                if (zero) J--;
                //Console.WriteLine();
            }

            int[,] b = new int[I, J];
            int bi;
            int bj;

            bi = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (deleteI[i]) continue;
                bj = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (deleteJ[j]) continue;
                    b[bi, bj] = a[i,j];
                    bj++;
                }
                bi++;
            }
            a = b;

        }
        
        static void Main(string[] args)
        {
            int[,] test = { { 2, 3, 0, 4 }, { 4, 5, 0, 6 }, { 0, 0, 0, 0 } };

            //Console.WriteLine(test.GetLength(0));
            //Console.WriteLine(test.GetLength(1));

            for (int i = 0; i < test.GetLength(0); i++)
            {
                for (int j = 0; j < test.GetLength(1); j++)
                {
                    Console.Write(test[i, j] + " ");
                }
                Console.WriteLine();
            }

            DeleteZero(ref test);
            Console.WriteLine();

            for (int i = 0; i < test.GetLength(0); i++)
            {
                for (int j = 0; j < test.GetLength(1); j++)
                {
                    Console.Write(test[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
