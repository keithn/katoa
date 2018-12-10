using System;
using System.Linq;
using Xunit;

namespace Katoa.Tests
{
    public class ListGeneratorTests
    {
        [Fact]
        public void MakeWithDefault()
        {
            var list = Make.Default(10, 9);
            Assert.Equal(10, list.Count);
            Assert.True(list.All(v => v == 9));
        }

        [Fact]
        void MakeFromTo()
        {
            var list = Make.FromTo(5, 10);
            Assert.Equal(5, list.Count);
            Assert.Equal(5, list.First());
            Assert.Equal(9, list.Last());
        }

    }
}