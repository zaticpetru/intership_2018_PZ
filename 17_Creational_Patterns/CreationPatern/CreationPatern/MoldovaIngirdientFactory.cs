namespace CreationPatern
{
    public class MoldovaIngirdientFactory : PizzaIngredientFactory
    {
        public string createSauce()
        {
            return "Moldavian mamaliga sauce";
        }

        public int setPrice()
        {
            return 199;
        }

        public int setWeight()
        {
            return 900;
        }
    }
}
