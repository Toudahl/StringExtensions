using System;

namespace Morts.StringExtensions
{
    public static class ThrowingExtensions
    {
        /// <summary>
        /// Will throw if the string is null
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNull(this string input, string paramName)
        {
            if(input.IsNull()) throw new ArgumentNullException(paramName,$"{paramName} cannot be null");
        }

        /// <summary>
        /// Throw if the string is empty. Will not throw if null.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ThrowIfEmpty(this string input, string paramName)
        {
            if (input?.Length == 0) throw new ArgumentException($"{paramName} cannot be empty", paramName);
        }

        /// <summary>
        /// Throw if the string is whitespace only. Will not throw if null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ThrowIfWhitespace(this string input, string paramName)
        {
            if (input is null || input.Length == 0) return;

            if (input.IsWhitespace())
            {
                throw new ArgumentException($"{paramName} cannot be whitespace only", paramName);
            }
        }

        /// <summary>
        /// Will throw an exception if the input is either null, empty or whitespace only
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        public static void ThrowIfNullEmptyOrWhitespace(this string input, string paramName)
        {
            input.ThrowIfNull(paramName);
            input.ThrowIfEmpty(paramName);
            input.ThrowIfWhitespace(paramName);
        }
    }
}
