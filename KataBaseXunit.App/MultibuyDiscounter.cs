using System.Collections.Generic;
using System.Linq;
using KataBaseXunit.App;

static internal class MultibuyDiscounter
{
    public static int GetDiscount(IEnumerable<Discount> discounts, IReadOnlyCollection<string> items)
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