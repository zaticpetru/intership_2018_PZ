namespace CreationPatern
{
    public class ChococlateBoiler
    {
        private bool empty;
        private bool boiled;
        private static ChococlateBoiler instance = null;
        private static readonly object padlook = new object();

        private ChococlateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChococlateBoiler GetInstance()
        {
            if (instance == null)
            {
                lock (padlook)
                {
                    if(instance == null)
                    {
                        instance = new ChococlateBoiler();
                    }
                }
            }
            return instance;
        }

        public void Fill()
        {
            if (IsEmpty())
            {
                empty = false;
                boiled = false;
            }
        }
        public void Drain()
        {
            if(!IsEmpty() && IsBoiled())
            {
                empty = true;
            }
        }
        public void Boil()
        {
            if(!IsEmpty() && !IsBoiled())
            {
                boiled = true;
            }
        }

        public bool IsEmpty() => empty;
        public bool IsBoiled() => boiled;
    }
}
