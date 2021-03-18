using System.Collections.Generic;
using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class CheckoutTests
    {
        private readonly Checkout _sut;

        public CheckoutTests()
        {
            _sut = new Checkout(new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 20}
            });
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("A", 50)]
        [InlineData("AA", 100)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        public void ItemsCostCorrespondsToPriceList(string skus, int expectedTotal)
        {
            foreach (var sku in skus.ToCharArray())
            {
                _sut.Scan(sku.ToString());
            }
            
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(expectedTotal, result);
        }
    }
}