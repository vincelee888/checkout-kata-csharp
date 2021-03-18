using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private List<string> _items;

        public Checkout()
        {
            _items = new List<string>();
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;
            
            foreach (var item in _items)
            {
                if (item == "A") totalPrice = 50;
            }
            
            return totalPrice;
        }

        public void Scan(string s)
        {
            _items.Add(s);
        }
    }
}