using System.Linq;

namespace Katoa
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Converts a number to an array of ints with the digits of that number
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] ToDigits<T>(this T n)
            where T : struct   // struct is unfortunate as there is no good way to identify numbers
                               // see https://stackoverflow.com/questions/32664/is-there-a-constraint-that-restricts-my-generic-method-to-numeric-types
        {
            if(!n.GetType().IsNumeric()) return new int[0];
            return n.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();
        }

    }
}