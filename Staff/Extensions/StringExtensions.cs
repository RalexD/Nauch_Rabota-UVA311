namespace String.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullorEmpty(this string value) => string.IsNullOrEmpty(value);

        public static string TrimorNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullorEmpty() ? null : trimmed; 
        }
    }
}
