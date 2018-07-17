#define RELEASE

using System;
using System.Diagnostics;

namespace MyDebugging
{
    class MyMath
    {
        public static long Power(int n, int p)
        {
            if (n == 0 && p == 0) throw new ArithmeticException("Zero la puterea zero nu are sens");
            if (p < 0) throw new Exception("Functia nu ridica la putere negativa");

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
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException("s","din cauza lui s");
            if (s.Contains(" ")) throw new ArgumentException("Argument cannot contain spaces");

            if (s == "666") throw new Exception("Diablo!!", new DivideByZeroException());

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
                //Console.WriteLine(MyMath.Power(0, 0));
                Console.WriteLine(MyMath.Power(6, -6));
            }
            catch (ArithmeticException e)
            {
                throw new Exception("Nu putem ridica la putere, eroare, pentru detalii vezi inner " , e);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
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


            var input = Console.ReadLine();
            int t;

            try
            {
                t = MyMath.ToInt(input);
                Console.WriteLine("Numarul introdus = {0}", t);
            }
            catch (ArgumentNullException e) when (input == String.Empty)
            {
                Console.WriteLine("stringul este empty!!!!!" + e.Message);
                throw new Exception("bla", e);
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
#if DEBUG
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw;
            }
#endif
#if (!DEBUG)
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
#endif
            finally
            {
                input = String.Empty;
                //Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
