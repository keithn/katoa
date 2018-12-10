using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Katoa.Tests
{
    public class LinkedListExtensionsTests
    {
        [Fact]
        public void Rotate()
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4 });

            Assert.Equal(4, list.First.Rotate(1).Value);
            Assert.Equal(2, list.First.Rotate(-1).Value);
            Assert.Equal(3, list.First.Rotate(-2).Value);

            var c = list.First.Rotate(1);

            Assert.Equal(3, c.Rotate(1).Value);
            Assert.Equal(1, c.Rotate(-1).Value);
        }
        
        [Fact]
        public void Remove()
        {
            var list = new LinkedList<int>(new[] { 1, 2, 3, 4 });

            var c = list.First.Rotate(-1);

            Assert.Equal(3, c.Remove().Value);
        }
    }
}
