using System.Collections.Generic;

namespace Katoa
{
    public static class Ascii
    {
        public static string Lower = "abcdefghijklmnopqrstuvwxyz";
        public static string Upper = Lower.ToUpper();
        public static string Letters = Lower+Upper;
        public static string Digits = "0123456789";
    }
}