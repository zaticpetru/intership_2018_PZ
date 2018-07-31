namespace CreationPatern
{
    public class Pizza
    {
        private string Sauce;
        private string Dough;
        private string Name;
        private int Weight;
        private int Price;

        public Pizza(string name, string sauce, string dough, int weight, int price)
        {
            Sauce = sauce;
            Name = name;
            Weight = weight;
            Price = price;
            Dough = dough;
        }

        //public void SetName(string name) => Name = name;
        public string GetName() => Name;
        public int GetPrice() => Price;
        public int GetWeight() => Weight;

        public override string ToString()
        {
            return "Name: " + Name
                  + "\nDough: " + Dough
                  + "\nSauce: " + Sauce
                  + "\nWeight: " + Weight
                  + "g\nPrice: " + Price + " Lei";
        }

        //public abstract void Prepare();
        //public abstract void Bake();
        //public abstract void Cut();
        //public abstract void Box();
    }
}
