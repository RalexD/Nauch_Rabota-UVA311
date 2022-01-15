// <copyright file="StringExtensions.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    /// <summary>
    /// Коллекция методов расширений для типа <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <inheritdoc cref="string.IsNullOrEmpty"/>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimorNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty()
                ? null
                : trimmed;
        }
    }
}
