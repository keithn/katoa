using System;
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
            Iterator.yYxX(5, 5, 10, 10, (x, y) =>
            {
                bucket.Add((x, y));
            }, y => rows.Add(y) );
            Assert.Equal(25, bucket.Count);
            Assert.Equal((5,5), bucket.First());
            Assert.Equal(5, rows.Count);
        }


        [Fact]
        public void ForUp()
        {
            var list = new List<int>();
            (1,10).For(i =>
            {
                list.Add(i);
            });
            Assert.Equal(10, list.Count);
            Assert.Equal(new[]{1,2,3,4,5,6,7,8,9,10},list.ToArray());
        }

        [Fact]
        public void ForWithStep()
        {
            var list = new List<int>();
            (1,10,2).For(i =>
            {
                list.Add(i);
            });
            Assert.Equal(5, list.Count);
            Assert.Equal(new[]{1,3,5,7,9},list.ToArray());
        }

        [Fact]
        public void ForDown()
        {
            var list = new List<int>();
            (10,1).For(i =>
            {
                list.Add(i);
            });
            Assert.Equal(10, list.Count);
            Assert.Equal(new[]{10,9,8,7,6,5,4,3,2,1},list.ToArray());
        }

        [Fact]
        void ForCollection()
        {
            var result = new List<int>();
            var list = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            list.For(i =>
            {
                result.Add(i);
            });
            Assert.Equal(10, result.Count);
            Assert.Equal(new[]{0, 1,2,3,4,5,6,7,8,9},result.ToArray());
        }

    }
}