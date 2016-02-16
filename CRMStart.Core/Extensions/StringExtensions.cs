using System.Diagnostics;

namespace CRMStart.Core.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}