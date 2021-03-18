using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private readonly List<string> _items;

        public Checkout()
        {
            _items = new List<string>();
        }

        public int GetTotalPrice()
        {
            var priceList = new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 20},
            };
            
            var totalPrice = 0;
            
            foreach (var item in _items)
            {
                if (priceList.ContainsKey(item))
                {
                    totalPrice += priceList[item];
                }
            }
            
            return totalPrice;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }
    }
}