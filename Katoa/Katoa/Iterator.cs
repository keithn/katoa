using System;
using System.Collections.Generic;

namespace Katoa
{
    public static class Iterator
    {
        public static void Run<T>(this IEnumerable<T> l)
        {
            foreach (var _ in l) ;
        }

        public static void XY(int maxX, int maxY, Action<int, int> f, Action<int>  each = null)
        {
            xXyY(0, 0, maxX, maxY, f, each);
        }

        public static IEnumerable<R> XY<R>(int maxX, int maxY, Func<int, int, R> f, Action<int>  each = null)
        {
            return xXyY(0, 0, maxX, maxY, f, each);
        }

        public static void xXyY(int minX, int minY, int maxX, int maxY, Action<int, int> f, Action<int>  each = null)
        {
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    f(x, y);
                }
                each?.Invoke(x);
            }
        }

        public static IEnumerable<R> xXyY<R>(int minX, int minY, int maxX, int maxY, Func<int, int, R> f, Action<int> each = null)
        {
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    yield return f(x, y);
                }
                each?.Invoke(x);
            }
        }

        public static IEnumerable<R> yYxX<R>(int minY, int minX, int maxY, int maxX, Func<int, int, R> f, Action<int> each = null)
        {
            return xXyY(minY, minX, maxY, maxX, (y,x) => f(x,y), each);
        }

        public static void yYxX(int minY, int minX, int maxY, int maxX, Action<int, int> f, Action<int> each = null)
        {
            xXyY(minY, minX, maxY, maxX, (y,x) => f(x,y), each);
        }

        public static void YX(int maxX, int maxY, Action<int, int> f, Action<int>  each = null)
        {
            XY(maxY, maxX, (y, x) => f(x, y), each);
        }

        public static IEnumerable<R> YX<R>(int maxX, int maxY, Func<int, int, R> f, Action<int>  each = null)
        {
            return XY(maxY, maxX, (y,x) => f(x,y), each);
        }

    }
}