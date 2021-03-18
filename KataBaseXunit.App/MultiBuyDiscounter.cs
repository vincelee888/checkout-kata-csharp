using System.Collections.Generic;
using System.Linq;

namespace KataBaseXunit.App
{
    public class MultiBuyDiscounter
    {
        private readonly Discount[] _discounts;

        public MultiBuyDiscounter(Discount[] discounts)
        {
            _discounts = discounts;
        }

        public int GetDiscount(IReadOnlyCollection<string> items)
        {
            var totalDiscount = 0;
            
            foreach (var discount in _discounts)
            {
                var countOfAs = items
                    .Count(sku => sku == discount.Sku);
                totalDiscount += -countOfAs / discount.TotalItemsToQualify * discount.DiscountAmount;
            }
            
            return totalDiscount;
        }
    }
}