using Xunit;

namespace Katoa.Tests
{
    public class AsciiTests
    {
        [Fact]
        public void TestConstants()
        {
            Assert.Equal("abcdefghijklmnopqrstuvwxyz", Ascii.Lower);
            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ", Ascii.Upper);
            Assert.Equal("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", Ascii.Letters);
            Assert.Equal("0123456789", Ascii.Digits);
        }

    }
}