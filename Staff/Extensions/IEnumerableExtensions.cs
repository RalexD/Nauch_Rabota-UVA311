// <copyright file="IEnumerableExtensions.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator = ", ") => string.Join(separator, collection);
    }
}
