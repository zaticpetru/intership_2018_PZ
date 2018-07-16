using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_overloading
{

    class Angle{
        private int degrees;
        private int minutes;
        private int seconds;


        public Angle(int deg, int min, int sec) {
            degrees = deg;
            minutes = min;
            seconds = sec;
            ToNormal();
        }

        private int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return seconds;
                    case 1: return minutes;
                    case 2: return degrees;
                    default: throw new IndexOutOfRangeException("Attemp to retrive element " + i);
                }
            }
            set
            {
                switch (i)
                {
                    case 0: seconds = value; break;
                    case 1: minutes = value; break;
                    case 2: degrees = value; break;
                    default: throw new IndexOutOfRangeException("Attemp to set element " + i);
                }
            }
        }

        public static Angle operator +(Angle l, Angle r) => new Angle(l.degrees + r.degrees, l.minutes + r.minutes, l.seconds + r.seconds);
        public static Angle operator -(Angle l, Angle r) => new Angle(l.degrees - r.degrees, l.minutes - r.minutes, l.seconds - r.seconds);
        public static Angle operator *(Angle l, int c) => new Angle(l.degrees * c, l.minutes * c, l.seconds * c);
        public static Angle operator /(int c, Angle l) => new Angle(l.degrees / c, l.minutes / c, l.seconds / c);
        public static bool operator ==(Angle l, Angle r) => (l.degrees == r.degrees) && (l.minutes == r.minutes) && (l.seconds == r.seconds);
        public static bool operator !=(Angle l, Angle r) => (l.degrees == r.degrees) && (l.minutes == r.minutes) && (l.seconds == r.seconds);
        public static bool operator >(Angle l, Angle r)
        {
            if (l.degrees > r.degrees) return true;
            if (l.degrees < r.degrees) return false;
            if (l.minutes > r.minutes) return true;
            if (l.minutes < r.minutes) return false;
            if (l.seconds > r.seconds) return true;
            return false;
        }
        public static bool operator <(Angle l, Angle r)
        {
            if (l.degrees < r.degrees) return true;
            if (l.degrees > r.degrees) return false;
            if (l.minutes < r.minutes) return true;
            if (l.minutes > r.minutes) return false;
            if (l.seconds < r.seconds) return true;
            return false;
        }
        public static bool operator >=(Angle l, Angle r) => (l == r) || (l > r);
        public static bool operator <=(Angle l, Angle r) => (l == r) || (l < r);

        public IEnumerator GetEnumerator()
        {
            yield return this[0];
            yield return this[1];
            yield return this[2];
        }
        private void ToNormal() {
            for(int i = 0; i < 2; i++)
            {
                if(this[i] / 60 != 0)
                {
                    this[i + 1] += this[i] / 60;
                    this[i] %= 60;
                }
            }
        }

        public override string ToString()
        {
            return (degrees + "° " + minutes + "\' " + seconds + "\"");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(0, 0, -30);
            Angle b = new Angle(0, -0, -31);
            //a.ToNormal();
            Console.WriteLine((a + b).ToString());
            Console.ReadKey();
        }
    }
}
