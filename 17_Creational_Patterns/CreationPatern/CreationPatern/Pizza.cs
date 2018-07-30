namespace CreationPatern
{
    public abstract class Pizza
    {
        protected string Sauce;
        protected string Name;
        protected int Weight;
        protected int Price;

        public void SetName(string name) => Name = name;
        public string GetName() => Name;
        public int GetPrice() => Price;
        public int GetWeight() => Weight;

        public abstract void Prepare();
        public abstract void Bake();
        public abstract void Cut();
        public abstract void Box();
    }
}
