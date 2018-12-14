using Xunit;

namespace Katoa.Tests
{
    public class TestNumberExtensions
    {
        [Fact]
        public void ToDigits()
        {
            Assert.Equal(new[]{1,2,3}, 123.ToDigits());
        }

    }
}