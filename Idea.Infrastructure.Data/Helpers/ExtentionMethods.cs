using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Infrastructure.Data.Helpers
{
    public static class ExtentionMethods
    {
        public static int ParseInt(this string value, int defaultIntValue = 0)
        {
            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

        public static int? ParseNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseInt();
        }

        public static decimal ParseDecimal(this string value, decimal defaultDecimalValue = 0)
        {
            decimal parsedDecimal;
            if (decimal.TryParse(value, out parsedDecimal))
            {
                return parsedDecimal;
            }

            return defaultDecimalValue;
        }

        public static decimal? ParseNullableDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseDecimal();
        }

        public static bool ParseBool(this string value, bool defaultBoolValue = false)
        {
            bool parsedBool;
            if (bool.TryParse(value, out parsedBool))
            {
                return parsedBool;
            }

            return defaultBoolValue;
        }

        public static bool? ParseNullableBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseBool();
        }

        public static long ParseLong(this string value, long defaultLongValue = 0)
        {
            long parsedLong;
            if (long.TryParse(value, out parsedLong))
            {
                return parsedLong;
            }

            return defaultLongValue;
        }

        public static long? ParseNullableLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseLong();
        }

        public static DateTime ParseDateTime(this string value)
        {
            return Convert.ToDateTime(value);
        }

        public static DateTime? ParseNullableDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return Convert.ToDateTime(value);
        }
    }
}
