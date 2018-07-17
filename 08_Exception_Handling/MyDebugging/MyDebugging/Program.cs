#define RELEASE

using System;
using System.Diagnostics;
using System.Threading;

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

    class Server
    {
        private readonly static int serverSize;
        private static int numberOfPlayers;
        private static bool IsActive = true;

        static Server(){
            serverSize = 3;
            numberOfPlayers = 0;
        }

        public static void ChangeActiveStatus()
        {
            IsActive = !IsActive;
        }

        private bool IsConnected = false;
        public void Connect()
        {
            if (!IsConnected) {
                if (IsActive) {
                    if (numberOfPlayers < serverSize)
                    {
                        numberOfPlayers++;
                        IsConnected = true;
                    }
                    else throw new Exception("Unable to connect, server full");
                }else throw new Exception("Unable to connect, server inactive");
            }
        }

        public void Disconect()
        {
            if (IsConnected)
            {
                numberOfPlayers--;
                IsConnected = false;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {

            Server My = new Server();
            Server My1 = new Server();
            Server My2 = new Server();
            Server My3 = new Server();


            My1.Connect();
            My2.Connect();
            My3.Connect();

            bool test = true;

            Thread thread1 = new Thread(new ThreadStart(Method1));
            thread1.IsBackground = true;
            thread1.Start();

            while (test)
            {
                try
                {
                    My.Connect();
                    Console.WriteLine("You are succesefully connected to server ;)");
                    test = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Unable to connect, server error: "  + e.Message + ",\ntry to reconnect?(y/n)");
                    My3.Disconect();
                    if (Console.ReadKey().Key != ConsoleKey.Y) test = false;
                }
            }

            Console.ReadLine();
        }

        static void Method1()
        {
            while (true)
            {
                Server.ChangeActiveStatus();
                Thread.Sleep(5000);
            }
        }
    }
}
