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
    }
}