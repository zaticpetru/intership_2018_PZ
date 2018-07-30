using System;

namespace CreationPatern
{
    public class MoldovaPeperoniPizza : Pizza
    {

        public override void Bake()
        {
            Console.WriteLine("Bake Moldova style PeperoniPizza");
        }

        public override void Box()
        {
            Console.WriteLine("Box Moldova style PeperoniPizza");
        }

        public override void Cut()
        {
            Console.WriteLine("Cut Moldova style PeperoniPizza");
        }

        public override void Prepare()
        {
            Console.WriteLine("Prepare Moldova style PeperoniPizza");
        }
    }
}
