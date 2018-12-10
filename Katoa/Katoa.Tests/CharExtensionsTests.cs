using Xunit;

namespace Katoa.Tests
{
    public class CharExtensionsTests
    {
        [Fact]
        public void SwapCase()
        {
            Assert.Equal('a', 'A'.SwapCase());
            Assert.Equal('A', 'a'.SwapCase());
            Assert.Equal('1', '1'.SwapCase());
        }
    }
}