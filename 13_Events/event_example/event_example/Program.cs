using System;
using System.Windows;

namespace event_example
{
    //public delegate void PriceChangedHandler(int oldPrice, int newPrice);

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly int LastPrice;
        public readonly int NewPrice;
        public PriceChangedEventArgs(int lastPrice, int newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class Stock
    {
        string Symbol;
        int price;
        public Stock(string symbol) { Symbol = symbol; }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (price == value) return;

                int oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice,price));
            }
        }

        
    }
    class Program
    {
        //WeakEventManager
        static void Main(string[] args)
        {
            Stock stock = new Stock("THPW")
            {
                Price = 2710
            };
            // Register with the PriceChanged event
            stock.PriceChanged += Stock_PriceChanged;
            stock.Price = 3159;

            Console.ReadLine(); 
        }

        static void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if (e.NewPrice - e.LastPrice  > 1)
                Console.WriteLine("Alert, 10% stock price increase!");
        }

    }
}
