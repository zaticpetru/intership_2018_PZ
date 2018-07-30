using System;

namespace CreationPatern
{
    public class NewYorkPeperoniPizza : Pizza
    {

        public override void Bake()
        {
            Console.WriteLine("Bake NewYork style PeperoniPizza");
        }

        public override void Box()
        {
            Console.WriteLine("Box NewYork style PeperoniPizza");
        }

        public override void Cut()
        {
            Console.WriteLine("Cut NewYork style PeperoniPizza");
        }

        public override void Prepare()
        {
            Console.WriteLine("Prepare NewYork style PeperoniPizza");
        }
    }
}
