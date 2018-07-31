namespace CreationPatern
{
    public class PizzaFactory
    {
        public static Pizza CreateMoldovaPeperoniPizza(int quantity)
        {
            if(quantity > 2)
                throw new System.Exception()

            return new Pizza("Moldova type Peperoni", "Mamaliga", "Neapolitan Style", 950, 95);
        }

        public static Pizza CreateAmericanRondoPizza()
        {
            return new Pizza("Really American Rondo", "Mexican", "NewYork Style", 888, 105);
        }
        public static Pizza CreateItalianoPizza()
        {
            return new Pizza("Italiano Classico Pizza", "No", "Sicilian Style", 1500, 250);
        }

    }
}
