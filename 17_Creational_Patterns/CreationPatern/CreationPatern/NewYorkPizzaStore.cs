namespace CreationPatern
{
    public class NewYorkPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory = new NewYorkIngirdientFactory();

            switch (type.ToLower())
            {
                //case "peperoni": pizza = new NewYorkPeperoniPizza(); break;
                //case "rondo": pizza = new NewYorkRondoPizza(); break;
                case "peperoni": pizza = new PeperoniPizza(ingredientFactory); pizza.SetName("New York Peperoni"); break;
                case "rondo": pizza = new RondoPizza(ingredientFactory); pizza.SetName("New York Rondo");  break;
            }

            return pizza;
        }
    }
}
