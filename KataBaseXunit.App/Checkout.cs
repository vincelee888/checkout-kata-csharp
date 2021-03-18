using System.Collections.Generic;
using System.Linq;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private readonly List<string> _items;
        private readonly Dictionary<string, int> _priceList;

        public Checkout(Dictionary<string, int> priceList)
        {
            _items = new List<string>();
            _priceList = priceList;
        }

        public int GetTotalPrice()
        {
            return GetBasicPricing() + 
                   GetDiscount();
        }

        private int GetDiscount()
        {
            var aDiscountDefinition = new Discount("A", 3, 20);
            var countOfAs = _items
                .Count(sku => sku == aDiscountDefinition.Sku);
            var discountA = -countOfAs / aDiscountDefinition.TotalItemsToQualify * aDiscountDefinition.DiscountAmount;
            
            var countOfBs = _items
                .Count(sku => sku == "B");
            var discountB = -countOfBs / 2 * 15;
            
            return discountA + discountB;
        }

        private int GetBasicPricing()
        {
            var totalPrice = 0;

            foreach (var item in _items)
            {
                if (_priceList.ContainsKey(item))
                {
                    totalPrice += _priceList[item];
                }
            }

            return totalPrice;
        }

        public void Scan(string sku)
        {
            _items.Add(sku);
        }
    }

    internal readonly struct Discount
    {
        public string Sku { get; }
        public int TotalItemsToQualify { get; }
        public int DiscountAmount { get; }

        public Discount(string sku, int totalItemsToQualify, int discountAmount)
        {
            Sku = sku;
            TotalItemsToQualify = totalItemsToQualify;
            DiscountAmount = discountAmount;
        }
    }
}