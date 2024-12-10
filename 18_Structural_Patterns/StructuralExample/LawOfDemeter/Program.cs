using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeter
{
    class Testing
    {
        public void DoSomethingBad() { }
    }
    class Testing2
    {
        public int DoSomeGood() { return 1; }
    }

    class Gooood
    {
        private Testing MyTesting;

        public void Example(Testing2 testing2)
        {
            Random Random = new Random();

            //okay to call methods of objects that we recive in arguments
            int i = testing2.DoSomeGood();

            //okay to call methods of methods we create
            MyTesting = new Testing();
            MyTesting.DoSomethingBad();

            //okay directly held component objects
            Random.Next(200);

            //okay to call own methods
            DoAnything();
        }//////////////////////////////gooooood example of law

        private void DoAnything()
        {

        }
    }

    class Bad
    {
        public Testing Testing { get; set; }
    }

    class VeryBad
    {
        public Bad Bad { get; set; }
    }
    class Program
    {

        
        static void Main(string[] args)
        {
            VeryBad VV = new VeryBad();
            VV.Bad.Testing.DoSomethingBad(); // bad example of law
        }
    }
}
