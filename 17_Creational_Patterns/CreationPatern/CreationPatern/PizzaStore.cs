namespace CreationPatern
{
    public abstract class PizzaStore
    {
        //PizzaFactory Factory;
        //public PizzaStore(PizzaFactory factory)
        //{
        //    Factory = factory;
        //}

        public Pizza OrderPizza(string type)
        {
            Pizza pizza;



            //pizza = PizzaFactory.CreatePizza(type);
            //pizza = Factory.GetPizza(type);
            pizza = CreatePizza(type);

            if (pizza != null)
            {
                pizza.Prepare();
                pizza.Bake();
                pizza.Cut();
                pizza.Box();
            }
            return pizza;
        }
        public abstract Pizza CreatePizza(string type);
    }
}
