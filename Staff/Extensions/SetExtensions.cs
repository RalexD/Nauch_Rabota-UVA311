// <copyright file="SetExtensions.cs" company="МИИТ_УВА-311">
// Copyright (c) МИИТ_УВА-311. All rights reserved.
// </copyright>

namespace Staff.Extensions
{
    using System.Collections.Generic;

    public static class SetExtensions
    {
        public static bool? TryAdd<T>(this ISet<T> set, T value)
            where T : class
        {
            return value is null
                ? null
                : set.Add(value);
        }
    }
}
