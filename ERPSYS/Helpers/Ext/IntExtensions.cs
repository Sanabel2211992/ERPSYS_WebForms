using System;

namespace ERPSYS.Helpers.Ext
{
    public static class IntExtensions
    {
        private const int DefaultIntValue = -1;

        public static bool IsInt(this object text)
        {
            int num;
            return int.TryParse(text.ToString(), out num);
        }

        public static bool IsInt(this decimal number)
        {
            return (number == Math.Round(number, 0));
        }

        public static int ToInt(this object text)
        {
            int num;
            if (text == null)
                return DefaultIntValue;
            return int.TryParse(text.ToString(), out num) ? num : DefaultIntValue;
        }

        public static int ToInt(this object text, int defaultVal)
        {
            int num;
            return int.TryParse(text.ToString(), out num) ? num : defaultVal;
        }

        public static string ToString(this int? value, string defaultvalue)
        {
            if (value == null)
                return defaultvalue;
            return value.Value.ToString();
        }

        #region PercentageOf calculations

        public static decimal PercentageOf(this int number, int percent)
        {
            return (decimal)(number * percent / 100);
        }

        public static decimal PercentOf(this int position, int total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
        }

        public static decimal PercentOf(this int? position, int total)
        {
            if (position == null)
                return 0;

            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
        }

        public static decimal PercentageOf(this int number, float percent)
        {
            return (decimal)(number * percent / 100);
        }

        public static decimal PercentOf(this int position, float total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
        }

        public static decimal PercentageOf(this int number, double percent)
        {
            return (decimal)(number * percent / 100);
        }

        public static decimal PercentOf(this int position, double total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)((decimal)position / (decimal)total * 100);
            return result;
        }

        public static decimal PercentageOf(this int number, decimal percent)
        {
            return (decimal)(number * percent / 100);
        }

        public static decimal PercentOf(this int position, decimal total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
        }

        public static decimal PercentageOf(this int number, long percent)
        {
            return (decimal)(number * percent / 100);
        }

        public static decimal PercentOf(this int position, long total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = (decimal)position / (decimal)total * 100;
            return result;
        }

        #endregion
    }
}
