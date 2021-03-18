﻿using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class Checkout
    {
        private readonly List<string> _items;
        private readonly Dictionary<string, int> _priceList;
        private readonly Discount[] _discounts;

        public Checkout(
            Dictionary<string, int> priceList, 
            Discount[] discounts)
        {
            _items = new List<string>();
            _priceList = priceList;
            _discounts = discounts;

        }

        public int GetTotalPrice()
        {
            return GetBasicPricing() + MultibuyDiscounter.GetDiscount(_discounts, _items);
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