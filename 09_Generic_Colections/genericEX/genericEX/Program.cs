using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericEX
{

    public class MyGenericArray<T>
    {
        private int size;
        private T[] a;
        public MyGenericArray(int size)
        {
            try
            {
                this.size = size;
                a = new T[size];
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured while creating array", e);
            }
        }
        public T this[int i]
        {
            get
            {
                if (i < size && i >= 0) return a[i];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < size && i >= 0) a[i] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        public void Swap(int indexL, int indexR)
        {
            if (indexL >= size && indexL < 0) throw new IndexOutOfRangeException("indexL = " + indexL + " when size = " + size);
            if (indexR >= size && indexR < 0) throw new IndexOutOfRangeException("indexR = " + indexR + " when size = " + size);

            T temp = a[indexL];
            a[indexL] = a[indexR];
            a[indexR] = temp;
        }

        public int Length { get => size; }

        //public void Swap(ref T left, ref T right)
        //{
        //    if (left == null) throw new ArgumentNullException("left", "left member null");
        //    if (right == null) throw new ArgumentNullException("right", "right member null");

        //    T temp = left;
        //    left = right;
        //    right = temp;
        //}
    }
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

            Console.ReadKey();
        }
    }
}
