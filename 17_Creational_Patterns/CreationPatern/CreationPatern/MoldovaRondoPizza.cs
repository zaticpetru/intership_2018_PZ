using System;

namespace CreationPatern
{
    public class MoldovaRondoPizza : Pizza
    {
        public override void Bake()
        {
            Console.WriteLine("Bake Moldova style RondoPizza");
        }

        public override void Box()
        {
            Console.WriteLine("Box Moldova style RondoPizza");
        }

        public override void Cut()
        {
            Console.WriteLine("Cut Moldova style RondoPizza");
        }

        public override void Prepare()
        {
            Console.WriteLine("Prepare Moldova style RondoPizza");
        }
    }
}
