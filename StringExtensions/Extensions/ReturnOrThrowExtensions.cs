using System;
using System.Diagnostics.CodeAnalysis;

namespace Morts.StringExtensions
{
    /// <summary>
    /// Extension methods that either returns the value, or throws an exception detailing the problem with the input.
    /// </summary>
    public static class ReturnOrThrowExtensions
    {
        /// <summary>
        /// Will throw an exception if the input is either null, empty or whitespace only. Otherwise the input will be returned as is.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string ReturnOrThrowIfNullEmptyOrWhitespace([NotNull] this string? input, string paramName)
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
        internal static string ReturnOrThrowIfNull([NotNull] this string? input, string paramName)
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
