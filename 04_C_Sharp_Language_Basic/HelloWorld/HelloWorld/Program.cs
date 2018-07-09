using System;
using System.Threading;

namespace HelloWorld
{
    class TestReference
    {
        public int a;
        public int b;

        static int test;
        static TestReference()
        {
            test = 0;
            Console.WriteLine("\n\nYou just create a TestReference\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 9;
            double c = 6.32;
            float d = 333.33f;

            Console.WriteLine("Hello World! I'm C#,\nhere you can see some of my basic results: " + a + b + "  " +  (c + d) + " --- > {0}", Math.Round(c + d, 2));

            d = (float)c;
            c++; 
            Console.WriteLine("\nAfter d = c, and c ++ we have:\nc = {0} , d = {1}, \n This was a value example\n\n", Math.Round(c,2), Math.Round(d, 2));

            TestReference t1 = new TestReference();

            t1.a = 5;
            t1.b = 6;

            TestReference t2 = t1;

            t2.a += 5;
            t1.b += 4;

            Console.WriteLine("first t1.a = 5, t1.b = 6, after t2 = t1, t2.a +=5, t1.b += 4, we have:");
            Console.WriteLine("t1.a = {0}, t1.b = {1},\nt2.a = {2}, t2.b = {3}\n This was a reference example",t1.a,t1.b,t2.a,t2.b);

            TestReference t3 = new TestReference();

            t3.a = 1;
            t3.b = 1;

            Console.WriteLine("\n\ndistance between t2 and t3 = {0}", Math.Round(Distance(t2, t3),3));

            int test = 4;
            RefExample(ref test); // must be initialised


            int test2;
            OutExample(out test2); // can be uninitialised

            int i = 123;      // a value type
            object o = i;     // boxing
            int j = (int)o;   // unboxing


            Thread t = new Thread(new ThreadStart(MyThreadMethod));

            Console.WriteLine("The thread's state is: " + t.ThreadState.ToString());
            t.Start(); // can be aborted, background, running, suspended, unstarted
            Console.WriteLine("The thread's state is: " + t.ThreadState.ToString());

            t.IsBackground = true;

            Console.WriteLine("The thread's background status is: " + t.IsBackground.ToString());


            Thread thread1 = new Thread(new ThreadStart(Method1));

            Thread thread2 = new Thread(new ThreadStart(Method2));

            thread1.Priority = ThreadPriority.Normal;

            thread2.Priority = ThreadPriority.BelowNormal;

            thread2.Start();

            thread1.Start();

            Console.WriteLine("Number of processors on this machine:" + Environment.ProcessorCount);
        Console.ReadKey();
        }

    static void MyThreadMethod()
    {

        Console.WriteLine("Hello World!");

    }
    static void Method1()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("First thread: " + i);
        }
    }

    static void Method2()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Second thread: " + i);
        }
    }
    private static double Distance(TestReference a, TestReference b)
        {
            double r = Math.Sqrt(((a.a - b.a) * (a.a - b.a) + (a.b - b.b) * (a.b - b.b)));
            return r;
        }

        private static void RefExample(ref int a)
        {
            // a = 3, with ref we can change the value of arguments
            Console.WriteLine(a);
        }

        private static void OutExample (out int a)
        {
            a = 5; // with out modifier we must modify the argument
            Console.WriteLine(a);
        }
    }
}
