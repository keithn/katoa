using System;

namespace Katoa
{
    public static class StringTupleSplitExtensions
    {
        public static string[] SplitTuple(this string s, (string s1, string s2) tuple, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[]{tuple.s1, tuple.s2}, options);
        }

        public static string[] SplitTuple(this string s, (string s1, string s2, string s3) tuple, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[]{tuple.s1, tuple.s2, tuple.s3}, options);
        }

        public static string[] SplitTuple(this string s, (string s1, string s2, string s3, string s4) tuple, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[]{tuple.s1, tuple.s2, tuple.s3, tuple.s4}, options);
        }

        public static string[] SplitTuple(this string s, (string s1, string s2, string s3, string s4, string s5) tuple, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[]{tuple.s1, tuple.s2, tuple.s3, tuple.s4, tuple.s5}, options);
        }

        public static string[] SplitTuple(this string s, (string s1, string s2, string s3, string s4, string s5, string s6) tuple, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[]{tuple.s1, tuple.s2, tuple.s3, tuple.s4, tuple.s5, tuple.s6}, options);
        }
    }
}