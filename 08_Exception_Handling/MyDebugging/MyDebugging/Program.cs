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
            if (p < 0) throw new ArgumentException(nameof(p), "Functia nu ridica la putere negativa");

            long t = 1;
            for (int i = 0; i < p; i++)
                t *= n;

            return t;
        }

        public static void ItIsMouse(ConsoleKey c)
        {
            if (c != ConsoleKey.RightArrow) throw new MouseNotFoundException("Asta-i nui mouse");
            Console.WriteLine("Molodet, ai gasit !!!");
        }

        public static int ToInt(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException(nameof(s), "din cauza lui s");
            if (s.Contains(" ")) throw new ArgumentException("Argument cannot contain spaces");

            if (s == "666") throw new Exception("Diablo!!", new DivideByZeroException());

            int rs;
            if (Int32.TryParse(s, out rs))
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
        string NameOfPc { get; set; }
        public MouseNotFoundException() { }
        public MouseNotFoundException(string message) : base(message) { }
        public MouseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }

    class Account
    {
        private bool active;
        public bool IsActive { get; }
        public int money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0) active = false;
                else active = true;
                money = value;
            }
        }
    }

    class DB
    {
        public static void SaveToDb(string inf)
        {
            try
            {
                //DBConnection.Save();
            }
            catch
            {
                // Roll back the DB changes so they aren't corrupted on ANY exception

                //DBConnection.Rollback();

                // Re-throw the exception, it's critical that the user knows that it failed to save
                throw;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                DB.SaveToDb("lala");
            }
            catch
            {
                Console.WriteLine("Failed to save inf in DB");
            }


            Console.ReadKey();
        }
    }
}
