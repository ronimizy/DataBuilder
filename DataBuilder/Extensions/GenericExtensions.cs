using System.Globalization;

namespace DataBuilder.Extensions
{
    internal static class GenericExtensions
    {
        private static readonly NumberFormatInfo FormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ".",
        };
        
        public static string ToJsonString<T>(this T value)
        {
            if (value is null)
                return "null";

            if (value is bool b)
                return b ? "true" : "false";

            if (value is char c)
                return $"\"{c}\"";

            if (value is float f)
                return f.ToString(FormatInfo);

            if (value is double d)
                return d.ToString(FormatInfo);

            if (value.GetType().IsPrimitive)
                return value.ToString();

            return $"\"{value.ToString()}\"";
        }
    }
}