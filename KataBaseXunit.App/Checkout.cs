﻿using System.Collections.Generic;
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
            var countOfAs = _items
                .Count(sku => sku == "A");
            return -countOfAs / 3 * 20;
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
}