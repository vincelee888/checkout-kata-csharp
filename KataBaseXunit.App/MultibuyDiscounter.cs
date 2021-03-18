using System.Collections.Generic;
using System.Linq;

namespace KataBaseXunit.App
{
    public class MultibuyDiscounter
    {
        public int GetDiscount(IEnumerable<Discount> discounts, IReadOnlyCollection<string> items)
        {
            var totalDiscount = 0;
            
            foreach (var discount in discounts)
            {
                var countOfAs = items
                    .Count(sku => sku == discount.Sku);
                totalDiscount += -countOfAs / discount.TotalItemsToQualify * discount.DiscountAmount;
            }
            
            return totalDiscount;
        }
    }
}