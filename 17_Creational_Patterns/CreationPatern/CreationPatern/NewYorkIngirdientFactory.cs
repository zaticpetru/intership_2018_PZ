namespace CreationPatern
{
    public class NewYorkIngirdientFactory : PizzaIngredientFactory
    {
        public string createSauce()
        {
            return "NewYork luxury sauce";
        }

        public int setPrice()
        {
            return 999;
        }

        public int setWeight()
        {
            return 500;
        }
    }
}
