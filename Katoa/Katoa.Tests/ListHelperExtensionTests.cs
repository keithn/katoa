using System.Collections.Generic;
using Xunit;

namespace Katoa.Tests
{
    public class EnumerableHelperExtensionTests
    {
        [Fact]
        public void MinMax()
        {
            var list = new[] {4, 5, 6, 7, 8};

            var (min, max) = list.MinMax();

            Assert.Equal(4, min);
            Assert.Equal(8, max);
        }

        [Fact]
        public void MinMaxWithSelectors()
        {
            var list = new List<int[]> {new[] {4, 14}, new[] {5, 15}, new[] {6, 16}};

            var (min, max) = list.MinMax(l => l[0], l => l[1]);

            Assert.Equal(4, min);
            Assert.Equal(16, max);
        }


        [Fact]
        public void MatchesFrom()
        {
            Assert.True(new[]{1,2,3,4,5,6,7}.MatchesFrom(2, new[]{3,4,5}));
            Assert.False(new[]{1,2,3,4,1,6,7}.MatchesFrom(2, new[]{3,4,5}));
            Assert.True(new[]{1,2,3,4,1,6,7}.MatchesFrom(2, new[]{3,4,5}, 0, 2));
            Assert.True(new[]{1,2,3,4,1,6,7}.MatchesFrom(-2, new[]{6,7}));
        }

    }
}