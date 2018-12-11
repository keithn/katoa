using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Katoa
{
    public static class StringExtensions
    {
        private static readonly Regex _extractIntRegex = new Regex(@"([+-]?\d+)", RegexOptions.Compiled);

        public static string SwapCase(this string s)
        {
            return string.Join("", s.Select(CharExtensions.SwapCase));
        }

        public static string[] Lines(this string s,
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return s.Split(new[] {'\r', '\n'}, options);
        }

        public static string[] SplitChars(this string s, string chars,
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries, bool trim = true)
        {
            return s.Split(chars.ToArray(), options).Select(v => trim ? v.Trim() : v).ToArray();
        }

        public static string[] Extract(this string s, string regexFragment)
        {
            return new Regex($"({regexFragment})").Matches(s)
                .SelectMany(m => m.Captures.Select(v => v.Value))
                .ToArray();
        }

        public static int[] ExtractInts(this string s)
        {
            var matches = _extractIntRegex.Matches(s);
            return matches.SelectMany(m => m.Captures.Select(v => int.Parse(v.Value))).ToArray();
        }

        public static string Between(this string s,string before, string after)
        {
            var start = s.IndexOf(before);
            return s.Substring(start+1, s.IndexOf(after)-start-1);
        }

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