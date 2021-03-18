using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class CheckoutTests
    {
        private readonly Checkout _sut;

        public CheckoutTests()
        {
            _sut = new Checkout();
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
    }
}