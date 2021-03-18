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

        [Fact]
        public void EmptyBasketPriceIsZero()
        {
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(0, result);
        }

        [Fact]
        public void SingleACosts50()
        {
            _sut.Scan("A");
            
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(50, result);
        }

        [Fact]
        public void TwoAsCost100()
        {
            _sut.Scan("A");
            _sut.Scan("A");
            
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(100, result);
        }

        [Fact]
        public void SingleBCosts30()
        {
            _sut.Scan("B");
            
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(30, result);
        }

        [Fact]
        public void SingleCCosts20()
        {
            _sut.Scan("C");
            
            var result = _sut.GetTotalPrice();
            
            Assert.Equal(20, result);
        }
    }
}