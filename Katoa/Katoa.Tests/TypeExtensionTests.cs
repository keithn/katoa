using Xunit;

namespace Katoa.Tests
{
    public class TypeExtensionTests
    {
        [Fact]
        public void IsNumeric()
        {
            Assert.True(((int)12).GetType().IsNumeric());
            Assert.True(((byte)12).GetType().IsNumeric());
            Assert.True(((decimal)12).GetType().IsNumeric());
            Assert.True(((float)12).GetType().IsNumeric());
            Assert.True(((long)12).GetType().IsNumeric());
            Assert.False((12.ToString()).GetType().IsNumeric());
        }

    }
}