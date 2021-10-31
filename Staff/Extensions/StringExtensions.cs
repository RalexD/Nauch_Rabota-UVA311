using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimorNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty() ? null : trimmed;
        }
    }
}
