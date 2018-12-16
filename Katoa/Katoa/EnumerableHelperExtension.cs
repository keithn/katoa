using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Katoa
{
    public static class EnumerableHelperExtension
    {
        public static (T, T) MinMax<T>(this ICollection<T> c)
        {
            return (c.Min(), c.Max());
        }

        public static (T,T) MinMax<T,X>(this ICollection<X> c, Func<X,T> minSelect, Func<X, T> maxSelect = null)
        {
            if (maxSelect == null) maxSelect = minSelect;
            return (c.Min(minSelect), c.Max(maxSelect));
        }

        /// <summary>
        /// Do the collections Match from a specific location in each collection, supports negative offset to index from the end
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="offset"></param>
        /// <param name="other"></param>
        /// <param name="otherOffset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool MatchesFrom<T>(this ICollection<T> c, int offset, ICollection<T> other, int otherOffset =0, int? count = null)
         where T : IComparable
        {
            if (offset < 0) offset = c.Count + offset;
            if (otherOffset < 0) otherOffset = other.Count + otherOffset;
            if (count == null) count = other.Count - otherOffset;
            if (other.Count < otherOffset+count) return false;
            if (c.Count < offset + count) return false;
            for (int i = 0; i < count; i++)
            {
                if (c.ElementAt(i + offset).CompareTo(other.ElementAt(i)) != 0) return false;
            }
            return true;
        }


        public static T Pop<T>(this IList<T> l)
        {
            var t = l[0];
            l.RemoveAt(0);
            return t;
        }

        public static IList<T> Push<T>(this IList<T> l, T item)
        {
            l.Insert(0, item);
            return l;
        }

        public static IList<T> Remove<T>(this IList<T> l, Func<T, bool> predicate)
        {
            return l.Remove((t, i) => predicate(t));
        }

        public static IList<T> Remove<T>(this IList<T> l, Func<T,int, bool> predicate)
        {
            int offset = 0;
            var indexes = l.Select((t, i) => (t, i)).Where((t => predicate(t.Item1, t.Item2))).ToList();
            foreach (var tuple in indexes)
            {
                l.RemoveAt(tuple.Item2 + offset);
                offset--;
            }
            return l;
        }

    }
}