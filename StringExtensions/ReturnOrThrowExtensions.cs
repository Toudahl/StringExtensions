using System;

namespace Morts.StringExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReturnOrThrowExtensions
    {
        /// <summary>
        /// Will throw an exception if the input is either null, empty or whitespace only. Otherwise the input will be returned as is.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        public static string ReturnOrThrowIfNullEmptyOrWhitespace(this string input, string paramName)
        {
            input.ThrowIfNullEmptyOrWhitespace(paramName);
            return input;
        }

        /// <summary>
        /// Will throw an exception if the input is null. Otherwise the input will be returned as is.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal static string ReturnOrThrowIfNull(this string input, string paramName)
        {
            input.ThrowIfNull(paramName);
            return input;
        }

        /// <summary>
        /// Will throw an exception if the input is empty. Otherwise the input will be returned as is.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        internal static string ReturnOrThrowIfEmpty(this string input, string paramName)
        {
            input.ThrowIfEmpty(paramName);
            return input;
        }

        /// <summary>
        /// Will throw an exception if the input is whitespace only. Otherwise the input will be returned as is.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentException"></exception>
        internal static string ReturnOrThrowIfWhitespace(this string input, string paramName)
        {
            input.ThrowIfWhitespace(paramName);
            return input;
        }
    }
}
