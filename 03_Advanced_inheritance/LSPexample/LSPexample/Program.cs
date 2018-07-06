using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPexample
{

    class BadParent
    {
        public virtual double Divide(double a, double b)
        {
            return a / b;
        }
    }

    class BadChildren : BadParent
    {
       public override double Divide(double a, double b)
        {
            int x = (int)a;
            int y = (int)b;

            return x / y;
        }
    }


    class GoodParent
    {
        public virtual void GiveMeMyBike(int bike)
        {
            if (bike > 10) bike = 10;
            while (bike-- > 0)
            {
                Console.Write("Bike");
            }
        }
    }

    class GoodChildren : GoodParent
    {
        public override void GiveMeMyBike(int bike)
        {
            if (bike < 0) bike *= -1;
            if (bike > 10) bike = 10;

            while (bike-- > 0)
            {
                Console.Write("Bike");
            }
        }
    }

    class Program
    { 
        static void Test(BadParent t)
        {
            Console.WriteLine(t.Divide(5, 2));
        }

        static void Test2(GoodParent t)
        {
            t.GiveMeMyBike(90);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            BadParent a = new BadParent();
            BadChildren b = new BadChildren();

            GoodParent c = new GoodParent();
            GoodChildren d = new GoodChildren();

            Test(a);
            Test(b);

            Test2(c);
            Test2(d);

            Console.ReadKey();
        }

        
    }
}
