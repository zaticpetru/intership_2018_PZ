namespace CreationPatern
{
    public class PizzaFactory
    {
        public static Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
        
            switch (type.ToLower())
            {
                case "peperoni" : pizza = new MoldovaPeperoniPizza(); break;
                case "rondo": pizza = new MoldovaRondoPizza(); break;
            }

            return pizza;
        }

        public Pizza GetPizza(string type)
        {
            Pizza pizza = null;

            switch (type.ToLower())
            {
                case "peperoni": pizza = new MoldovaPeperoniPizza(); break;
                case "rondo": pizza = new MoldovaRondoPizza(); break;
            }

            return pizza;
        }
    }
}
