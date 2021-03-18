﻿using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private readonly List<string> _items;
        private readonly Dictionary<string, int> _priceList;
        private readonly Discount[] _discounts;
        private readonly MultibuyDiscounter _discounter;

        public Checkout(
            Dictionary<string, int> priceList, 
            Discount[] discounts, MultibuyDiscounter discounter)
        {
            _items = new List<string>();
            _priceList = priceList;
            _discounts = discounts;

            _discounter = discounter;
        }

        public int GetTotalPrice()
        {
            return GetBasicPricing() + _discounter.GetDiscount(_discounts, _items);
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

    public readonly struct Discount
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