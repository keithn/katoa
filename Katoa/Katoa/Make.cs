using System.Collections.Generic;
using System.Linq;

namespace Katoa
{
    public static class Make
    {
        public static List<T> Default<T>(int n, T value)
        {
            return Enumerable.Repeat(value, n).ToList();
        }

        public static List<int> FromTo(int start, int end)
        {
            return Enumerable.Range(start, end-start+1).ToList();
        }
    }
}