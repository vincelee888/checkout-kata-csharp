using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class Tests
    {
        private readonly Foo _sut;

        public Tests()
        {
            _sut = new Foo();
        }

        [Fact]
        public void Test()
        {
            var result = _sut.Bar();
            Assert.Equal("Baz", result);
        }
    }
}