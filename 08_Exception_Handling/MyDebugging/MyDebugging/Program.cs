using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDebugging
{
    class MyMath
    {
        public static long Power(int n, int p)
        {
            if (n == 0 && p == 0) throw new ArithmeticException("Zero la puterea zero nu are sens");
            if (p < 0) throw new ArithmeticException("Functia nu ridica la putere negativa");

            long t = 1;
            for (int i = 0; i < p; i++) t *= n;

            return t;
        }

        public static void ItIsMouse(ConsoleKey c)
        {
            if (c != ConsoleKey.RightArrow) throw new MouseNotFoundException("Asta-i nui mouse");
            Console.WriteLine("Molodet, ai gasit !!!");
        }

        public static int ToInt(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException("Argument cannot be null, empty or withespace");
            if (s.Contains(" ")) throw new ArgumentException("Argument cannot contain spaces");

            int rs;
            if(Int32.TryParse(s, out rs))
            {
                return rs;
            }
            else
            {
                throw new FormatException("Cannot prase to integer the : " + s);
            }
        }
    }

    

    class MouseNotFoundException : Exception
    {
        public MouseNotFoundException() { }
        public MouseNotFoundException(string message) : base(message) { }
        public MouseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(MyMath.Power(0, 0));
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Nu putem ridica la putere, eroare: " + e.Message);
            }

            ConsoleKeyInfo c = Console.ReadKey();
            try
            {
                MyMath.ItIsMouse(c.Key);
            }
            catch(MouseNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }


            string input = Console.ReadLine();
            int t;

            try
            {
                t = MyMath.ToInt(input);
                Console.WriteLine("Numarul introdus = {0}", t);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                input = String.Empty;
            }

            Console.ReadKey();
        }
    }
}
