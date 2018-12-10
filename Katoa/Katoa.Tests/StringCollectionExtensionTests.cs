using System.Collections.Generic;
using Xunit;

namespace Katoa.Tests
{
    public class StringCollectionExtensionTests
    {
        [Fact]
        public void Trim()
        {
            Assert.Equal(new []{"one", "two", "three"}, new []{" one", " two ", "three "}.Trim());
        }

        [Fact]
        public void ExtractInts()
        {
            Assert.Equal(new List<int[]>{new[]{1,2},new[]{3,4}}, new[] {"blah 1,2", "3 wah 4"}.ExtractInts());
        }
    }
}