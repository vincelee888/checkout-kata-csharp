using System.Collections.Generic;
using System.Linq;

namespace KataBaseXunit.App
{
    public interface IDiscounter
    {
        int GetDiscount(IReadOnlyCollection<string> items);
    }

    public class MultiBuyDiscounter : IDiscounter
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
                var count = items.Count(sku => sku == discount.Sku);
                totalDiscount += -count / discount.TotalItemsToQualify * discount.DiscountAmount;
            }
            
            return totalDiscount;
        }
    }
}