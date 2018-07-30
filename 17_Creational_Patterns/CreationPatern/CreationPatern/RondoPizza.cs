namespace CreationPatern
{
    public class RondoPizza : Pizza
    {
        PizzaIngredientFactory IngredientFactory;

        public RondoPizza(PizzaIngredientFactory ingredientFactory)
        {
            IngredientFactory = ingredientFactory;
        }

        public override void Bake()
        {
            throw new System.NotImplementedException();
        }

        public override void Box()
        {
            throw new System.NotImplementedException();
        }

        public override void Cut()
        {
            throw new System.NotImplementedException();
        }

        public override void Prepare()
        {
            Sauce = IngredientFactory.createSauce();
            Price = IngredientFactory.setPrice();
            Weight = IngredientFactory.setWeight();
        }
    }
}
