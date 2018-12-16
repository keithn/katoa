using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string Range(this string s, (int, int) range)
        {
            var start = range.Item1 < 0 ? s.Length + range.Item1 : range.Item1;
            var end = range.Item2 < 0 ? s.Length + range.Item2 : range.Item2;

            if (end < start )
            {
                return s.Substring(end, start - end).Reverse();
            }
            return s.Substring(start, end - start);
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

        public static string Repeat(this string s, int count)
        {
            var sb = new StringBuilder();
            for(int i =0 ; i <count; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static string[] ToStringArray(this string s)
        {
            return s.ToCharArray().Select(c => c.ToString()).ToArray();
        }

        public static IEnumerable<string> Chunk(this string s, int size)
        {
            for (int i = 0; i < s.Length; i += size)
                yield return s.Substring(i, Math.Min(size, s.Length - i));
        }

        public static string After(this string s, string after)
        {
            int start = s.IndexOf(after, 0, StringComparison.Ordinal);
            if (start == -1)  return ""; 
            start += after.Length;
            return s.Remove(0, start);
        }

        public static string Before(this string s, string before)
        {
            int start = s.IndexOf(before, 0, StringComparison.Ordinal);
            if (start == -1) return "";
            return s.Remove(start);
        }
    }
}