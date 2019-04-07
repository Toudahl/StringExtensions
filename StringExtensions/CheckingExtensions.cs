using System;

namespace Morts.StringExtensions
{
    public static class CheckingExtensions
    {
        /// <summary>
        /// Will indicate if the string is null or not
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNull(this string input) => input is null;

        /// <summary>
        /// Will indicate if the string is empty or not.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static bool IsEmpty(this string input) => input.Length == 0;

        /// <summary>
        /// Will indicate if the string is empty or not.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static bool IsWhitespace(this string input)
        {
            var lastCharIndex = input.Length;
            var firstCharIndex = 0;

            while (true)
            {
                if (lastCharIndex > firstCharIndex)
                {
                    lastCharIndex--;
                }

                if (!char.IsWhiteSpace(input[firstCharIndex]) || !char.IsWhiteSpace(input[lastCharIndex]))
                {
                    return false;
                }

                if (firstCharIndex >= lastCharIndex)
                {
                    return true;
                }

                firstCharIndex++;
            }
        }

        /// <summary>
        /// Will indicate if the string is null, empty or whitespace
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullEmptyOrWhitespace(this string input) =>
            input.IsNull() || input.IsEmpty() || input.IsWhitespace();

    }
}
