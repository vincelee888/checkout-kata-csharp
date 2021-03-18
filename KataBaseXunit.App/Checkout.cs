using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private readonly List<string> _items;
        private readonly IDiscounter _discounter;
        private readonly BasicPricer _basicPricer;

        public Checkout(IDiscounter discounter, BasicPricer basicPricer)
        {
            _items = new List<string>();
            _discounter = discounter;
            _basicPricer = basicPricer;
        }

        public int GetTotalPrice()
        {
            return _basicPricer.GetBasicPricing(_items) + 
                   _discounter.GetDiscount(_items);
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }
    }
}