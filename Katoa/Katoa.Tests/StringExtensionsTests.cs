using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Katoa.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Extract()
        {
            Assert.Equal(new []{"10", "11"}, "one 10 two 11".Extract(@"\d+"));
            Assert.Equal(new []{"one", "two"}, "one 10 two 11".Extract(@"[a-zA-Z]+"));
        }

        [Fact]
        public void FileAndToFile()
        {
            "blah".ToFile("blah.txt");
            Assert.Equal("blah", "blah.txt".File());
        }

        [Fact]
        public void FileLines()
        {
            "blah\r\nFoo".ToFile("blah.txt");
            Assert.Equal(new []{"blah", "Foo"}, "blah.txt".FileLines());
        }

        [Fact]
        public void FileIntsCombo()
        {
            "1 2,blah\r\nFoo 3 4".ToFile("blah.txt");
            Assert.Equal(new List<int[]>{new[]{1,2},new[]{3,4}},"blah.txt".FileLines().ExtractInts());
        }

        [Fact]
        public void ExtractInts()
        {
            Assert.Equal(new[] {1, 2, 3, -10, 20}, "blah blah 1 x y 2 3 n=-10,20".ExtractInts());
            Assert.Equal(new[] {7, 6, -1, -1}, "position=< 7,  6> velocity=<-1, -1>".ExtractInts());
        }

        [Fact]
        public void SwapCase()
        {
            Assert.Equal("aBcDeFg", "AbCdEfG".SwapCase());
        }

        [Fact]
        public void Lines()
        {
            Assert.Equal(new[] {"A", "B", "C"}, "A\nB\r\nC".Lines());
        }

        [Fact]
        public void SplitTuple()
        {
            Assert.Equal(new[] {"one", "two", "three"}, "oneandtwothenthree".SplitTuple(("and", "then")));
            Assert.Equal(new[] {"one", "two", "three", "four"},
                "oneandtwothenthreeorfour".SplitTuple(("and", "then", "or")));

            Assert.Equal(new[] {"one", "two", "three", "four", "five"},
                "oneandtwothenthreeorfouroverfive".SplitTuple(("and", "then", "or", "over")));

            Assert.Equal(new[] {"one", "two", "three", "four", "five", "six"},
                "oneandtwothenthreeorfouroverfivefoosix".SplitTuple(("and", "then", "or", "over", "foo")));

            Assert.Equal(new[] {"one", "two", "three", "four", "five", "six", "seven"},
                "oneandtwothenthreeorfouroverfivefoosixbarseven".SplitTuple(("and", "then", "or", "over", "foo", "bar")));
        }

        [Fact]
        public void SplitChars()
        {
            Assert.Equal(new[] {"one", "two", "three"}, "one two,three".SplitChars(" ,"));
        }

        [Fact]
        public void Between()
        {
            Assert.Equal("1518-09-04 00:00", "[1518-09-04 00:00] Guard #3433 begins shift".Between("[","]"));
        }

        [Fact]
        public void Repeat()
        {
            Assert.Equal("abcabcabc", "abc".Repeat(3));
        }

        [Fact]
        void ToStringArray()
        {
            Assert.Equal(new []{"a","b", "c"}, "abc".ToStringArray());
        }
    }
}