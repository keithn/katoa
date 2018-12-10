using System;
using System.Collections.Generic;
using System.Linq;

namespace Katoa
{
    public static class EnumerableHelperExtension
    {
        public static (T, T) MinMax<T>(this ICollection<T> c)
        {
            return (c.Min(), c.Max());
        }

        public static (T,T) MinMax<T,X>(this ICollection<X> c, Func<X,T> minSelect, Func<X, T> maxSelect)
        {
            return (c.Min(minSelect), c.Max(maxSelect));
        }
    }
}