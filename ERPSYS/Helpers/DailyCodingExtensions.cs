using System;
using System.Text.RegularExpressions;

namespace ERPSYS.Helpers
{
    public static class Extensions
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static string FormatString(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool Match(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        public static void Raise(this EventHandler eventHandler, object sender, EventArgs e)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static void Raise<T>(this EventHandler<T> eventHandler, object sender, T e)
           where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public static long ToInt16(this string value)
        {
            Int16 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int16.TryParse(value, out result);

            return result;
        }

        public static long ToInt32(this string value)
        {
            Int32 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int32.TryParse(value, out result);

            return result;
        }

        public static long ToInt64(this string value)
        {
            Int64 result = 0;

            if (!string.IsNullOrEmpty(value))
                Int64.TryParse(value, out result);

            return result;
        }
    }
}