using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input should be a non-negative integer.", nameof(n));
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            int length = items.Length;

            if (length == 0)
            {
                return string.Empty;
            }

            if (length == 1)
            {
                return items[0];
            }

            if (length == 2)
            {
                return $"{items[0]} and {items[1]}";
            }

            string result = string.Join(", ", items.Take(length - 1)) + $" and {items[length - 1]}";
            return result;
        }
    }
}