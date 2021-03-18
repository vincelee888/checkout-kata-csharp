using System.Collections.Generic;

namespace KataBaseXunit.App
{
    public class BasicPricer
    {
        private readonly Dictionary<string, int> _priceList;

        public BasicPricer(Dictionary<string, int> priceList)
        {
            _priceList = priceList;
        }

        public int GetBasicPricing(IEnumerable<string> items)
        {
            var totalPrice = 0;

            foreach (var item in items)
            {
                if (_priceList.ContainsKey(item))
                {
                    totalPrice += _priceList[item];
                }
            }

            return totalPrice;
        }
    }
}