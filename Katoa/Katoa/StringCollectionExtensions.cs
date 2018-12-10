using System.Collections.Generic;
using System.Linq;

namespace Katoa
{
    public static class StringCollectionExtensions
    {
        public static IEnumerable<string> Trim(this IEnumerable<string> c)
        {
            return c.Select(s => s.Trim());
        }
        public static IEnumerable<int[]> ExtractInts(this string[] strings)
        {
            return strings.Select(s => s.ExtractInts());
        }
    }
}