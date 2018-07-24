using System;

namespace genericEX
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyGenericArray<int>(40);
            test[0] = 1;
            Console.WriteLine("my test[{0}] = {1}", 0, test[0]);
            for (int i = 1; i < test.Length; i++)
            {
                test[i] = i;
                test[i] += test[i - 1];
                Console.WriteLine("my test[{0}] = {1}", i, test[i]);
            }
            test.Swap(0,test.Length - 1);
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine("my test[{0}] = {1}", i, test[i]);
            }

            var testString = new MyGenericArray<string>(5);
            for (int i = 0; i < testString.Length; i++)
            {
                testString[i] = "tester" + i;
                Console.WriteLine("my testString[{0}] = {1}", i, testString[i]);
            }
            //teststring.swap(out teststring[0], );
            testString.Swap(0, 3);
            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine("my testString[{0}] = {1}", i, testString[i]);
            }


            var t = new MyGenericArray<int>();
            t.Add(1); t.Add(1); t.Add(1); t.Add(1); t.Add(1);
            Console.Write(t.Length + " " + t.size);

            Console.ReadKey();
        }
    }
}
