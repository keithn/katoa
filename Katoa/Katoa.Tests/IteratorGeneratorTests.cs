using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Katoa.Tests
{
    public class IteratorGeneratorTests
    {
        [Fact]
        public void XYIteration()
        {
            var list = Iterator.XY(10, 10, (x, y) => (x, y)).ToList();
            Assert.Equal(100, list.Count);
            Assert.Equal((0,0), list.First());

            var bucket = new List<(int, int)>();
            Iterator.XY(10, 10, (x,y) => bucket.Add((x,y)));

            Assert.Equal(100, bucket.Count);
            Assert.Equal((0,0), bucket.First());
        }
        [Fact]
        public void YXIteration()
        {
            var list = Iterator.YX(10, 10, (x, y) => (x, y)).ToList();
            Assert.Equal(100, list.Count);
            Assert.Equal((0,0), list.First());

            var bucket = new List<(int, int)>();
            Iterator.YX(10, 10, (x,y) => bucket.Add((x,y)));

            Assert.Equal(100, bucket.Count);
            Assert.Equal((0,0), bucket.First());
        }

        [Fact]
        public void xXyYIteration()
        {
            var list = Iterator.xXyY(5, 5, 10, 10, (x, y) => (x, y)).ToList();
            Assert.Equal(25, list.Count);
            Assert.Equal((5,5), list.First());

            var rows = new List<int>();
            var bucket = new List<(int, int)>();
            Iterator.xXyY(5, 5, 10, 10, (x, y) => bucket.Add((x, y)), x => rows.Add(x) );
            Assert.Equal(25, bucket.Count);
            Assert.Equal((5,5), bucket.First());
            Assert.Equal(5, rows.Count);
        }
        [Fact]
        public void yYxXIteration()
        {
            var list = Iterator.yYxX(5, 5, 10, 10, (x, y) => (x, y)).ToList();
            Assert.Equal(25, list.Count);
            Assert.Equal((5,5), list.First());

            var rows = new List<int>();
            var bucket = new List<(int, int)>();
            Iterator.yYxX(5, 5, 10, 10, (x, y) => bucket.Add((x, y)), y => rows.Add(y) );
            Assert.Equal(25, bucket.Count);
            Assert.Equal((5,5), bucket.First());
            Assert.Equal(5, rows.Count);
        }
    }
}