using System;
namespace CreationPatern
{
    class Program
    {
        static void Main(string[] args)
        {
            ChococlateBoiler t = ChococlateBoiler.GetInstance();

            Pizza[] Order = new Pizza[] {PizzaFactory.CreateMoldovaPeperoniPizza(),
                                        PizzaFactory.CreateItalianoPizza(),
                                        PizzaFactory.CreateAmericanRondoPizza(),
                                        new Pizza("Custom Pizza","Improvization", "Large", 450, 99) };
            foreach(Pizza x in Order)
            {
                Console.WriteLine(x.ToString() + "\n");
            }

            Console.ReadKey();
        }
    }
}
