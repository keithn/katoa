using System;
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

    }
}