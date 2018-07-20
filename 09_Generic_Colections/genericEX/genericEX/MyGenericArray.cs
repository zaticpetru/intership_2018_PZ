using System;

namespace genericEX
{
    public class MyGenericArray<T>
    {
        public int size { get; private set; }
        public const int MaxSize = 2147483647;
        private int pow = 2;
        public int count { get; private set; }
        private T[] a;
        public MyGenericArray(int size)
        {
            try
            {
                this.size = size;
                count = size;
                a = new T[size];
            }
            catch (Exception e)
            {
                throw new Exception("Exception occured while creating array", e);
            }
        }

        public MyGenericArray()
        {
            size = 4;
            count = 0;
            a = new T[4];
        }

        public void Add(T item)
        {
            if (count < size) a[count++] = item;
            else
            {
                pow++;
                if (pow > 31)
                {
                    throw new OverflowException("Too big array!!!");
                }
                else if (pow == 31) size = MaxSize;
                else size = 1 << pow;

                T[] b = new T[size];
                a.CopyTo(b, 0);
                a = b;
                a[count++] = item;
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

        public int Length { get => count; }

        //public void Swap(ref T left, ref T right)
        //{
        //    if (left == null) throw new ArgumentNullException("left", "left member null");
        //    if (right == null) throw new ArgumentNullException("right", "right member null");

        //    T temp = left;
        //    left = right;
        //    right = temp;
        //}
    }
}
