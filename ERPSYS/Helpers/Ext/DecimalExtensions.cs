using System;
using ERPSYS.BLL;

namespace ERPSYS.Helpers.Ext
{
    public static class DecimalExtensions
    {
        private const decimal DefaultDecimalValue = 0;
        private const int DefaultRoundDigit = 2; // UserSession.RoundDigit;

        #region PercentageOf calculations

        public static decimal PercentageOf(this decimal number, int percent)
        {
            return number * percent / 100;
        }

        public static decimal PercentOf(this decimal position, int total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = position / total * 100;
            return result;
        }

        public static decimal PercentageOf(this decimal number, decimal percent)
        {
            return number * percent / 100;
        }

        public static decimal PercentOf(this decimal position, decimal total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = position / total * 100;
            return result;
        }

        public static decimal PercentageOf(this decimal number, long percent)
        {
            return number * percent / 100;
        }

        public static decimal PercentOf(this decimal position, long total)
        {
            decimal result = 0;
            if (position > 0 && total > 0)
                result = position / total * 100;
            return result;
        }

        #endregion

        private static string GetDecimalFormat(int fractions, bool bWithThousandPoint = true)
        {
            try
            {
                string doubleFormat;

                if (bWithThousandPoint)
                {
                    switch (fractions)
                    {
                        case 0:
                            doubleFormat = "#,##0";
                            break;
                        case 1:
                            doubleFormat = "#,##0.0";
                            break;
                        case 2:
                            doubleFormat = "#,##0.00";
                            break;
                        case 3:
                            doubleFormat = "#,##0.000";
                            break;
                        case 4:
                            doubleFormat = "#,##0.0000";
                            break;
                        case 5:
                            doubleFormat = "#,##0.00000";
                            break;
                        case 6:
                            doubleFormat = "#,##0.000000";
                            break;
                        case 7:
                            doubleFormat = "#,##0.0000000";
                            break;
                        case 8:
                            doubleFormat = "#,##0.00000000";
                            break;
                        case 9:
                            doubleFormat = "#,##0.000000000";
                            break;
                        case 10:
                            doubleFormat = "#,##0.0000000000";
                            break;
                        default:
                            doubleFormat = "#,##0.000";
                            break;
                    }
                }
                else
                {
                    switch (fractions)
                    {
                        case 0:
                            doubleFormat = "0";
                            break;
                        case 1:
                            doubleFormat = "0.0";
                            break;
                        case 2:
                            doubleFormat = "0.00";
                            break;
                        case 3:
                            doubleFormat = "0.000";
                            break;
                        case 4:
                            doubleFormat = "0.0000";
                            break;
                        case 5:
                            doubleFormat = "0.00000";
                            break;
                        case 6:
                            doubleFormat = "0.000000";
                            break;
                        case 7:
                            doubleFormat = "0.0000000";
                            break;
                        case 8:
                            doubleFormat = "0.00000000";
                            break;
                        case 9:
                            doubleFormat = "0.000000000";
                            break;
                        case 10:
                            doubleFormat = "0.0000000000";
                            break;
                        default:
                            doubleFormat = "0.000";
                            break;
                    }
                }
                return doubleFormat;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static decimal ToDecimal(this string text, int roundDigit = DefaultRoundDigit)
        {
            decimal num;
            return Math.Round(Decimal.TryParse(text, out num) ? num : DefaultDecimalValue, roundDigit);
        }

        public static decimal ToDecimal(this object text, int roundDigit = DefaultRoundDigit)
        {
            decimal num;
            return Math.Round(Decimal.TryParse(text.ToString(), out num) ? num : DefaultDecimalValue, roundDigit);
        }

        public static string ToDecimalFormat(this object text, int roundDigit = DefaultRoundDigit)
        {
            decimal num = Decimal.TryParse(text.ToString(), out num) ? num : DefaultDecimalValue;
            return num.ToString(GetDecimalFormat(roundDigit));
        }

        public static string ViewCostField(this string text)
        {
            return !RegisteredUser.HasCostView ? "******" : text;
        }

        public static decimal RoundUp(this decimal value)
        {
             return Math.Ceiling(value);
        }
    }
}
