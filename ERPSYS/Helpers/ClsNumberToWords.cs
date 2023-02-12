using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.Helpers
{
    public class NumberToWords
    {
        public static string GetAmountInWords(decimal amount, int currencyId)
        {
            CurrencyBLL currency = new CurrencyBLL();
            CurrencyProperties cp = currency.GetCurrencyProperties(currencyId);

            return AmountToWords(amount.ToString(CultureInfo.InvariantCulture), cp.Name, cp.FractionName, cp.FractionDigit, cp.FractionValue);
        }

        private static bool IsDouble(string valueInDouble)
        {
            double amount;
            bool isDouble = Double.TryParse(valueInDouble, out amount);
            if (!isDouble)
            {
                return false;
            }
            return true;
        }

        private static string Left(string str, int count)
        {
            if (string.IsNullOrEmpty(str) || count < 1)
                return str;
            else
                return str.Substring(0, Math.Min(count, str.Length));
        }

        private static string AmountToWords(string nAmount, string bigName2, string smallName2, int roundDigit2, int roundFactor2, string wAmount = "", object nSet = null)
        {
            //Let's make sure entered value is numeric
            if (!IsDouble(nAmount))
            {
                return "Please Enter Numbers Only";
            }

            string tempDecValue = string.Empty;

            if (nAmount.IndexOf(".", StringComparison.Ordinal) > 0) tempDecValue = nAmount.Substring(nAmount.IndexOf(".", StringComparison.Ordinal));

            //Removing the decimal value from nAmount
            if (tempDecValue != string.Empty) { nAmount = nAmount.Replace(tempDecValue, string.Empty); }

            try
            {
                int intAmount = Int32.Parse(nAmount);

                if (intAmount > 0)
                {

                    nSet = (((double)intAmount.ToString().Length / (double)3) > (Convert.ToInt64((double)intAmount.ToString().Length / (double)3)) ? Convert.ToInt64((double)intAmount.ToString().Length / (double)3) + 1 : Convert.ToInt64((double)intAmount.ToString().Length / (double)3));

                    int eAmount = Int32.Parse(Left(intAmount.ToString().Trim(), (intAmount.ToString().Trim().Length - ((Int32.Parse(nSet.ToString()) - 1) * 3))));
                    int multiplier = (int)Math.Pow(10, (((Int32.Parse(nSet.ToString()) - 1) * 3)));

                    //These are the worded values
                    string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                    string[] teens = { "", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                    string[] tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                    string[] hmbt = { "", "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion" };

                    intAmount = eAmount;

                    int nHundred = intAmount / 100;
                    intAmount = intAmount % 100;
                    int nTen = intAmount / 10;
                    intAmount = intAmount % 10;
                    int nOne = intAmount / 1;

                    if (nHundred > 0) wAmount = wAmount + ones[nHundred] + " Hundred ";

                    if (nTen > 0)
                    {
                        if (nTen == 1 & nOne > 0)
                        {
                            wAmount = wAmount + teens[nOne] + " ";
                        }
                        else
                        {
                            wAmount = wAmount + tens[nTen] + (nOne > 0 ? "-" : " ");
                            if (nOne > 0) wAmount = wAmount + ones[nOne] + " ";
                        }
                    }
                    else
                    {
                        if (nOne > 0)
                            wAmount = wAmount + ones[nOne] + " ";
                    }

                    wAmount = wAmount + hmbt[Int32.Parse(nSet.ToString())] + " ";
                    wAmount = AmountToWords(Convert.ToString(Convert.ToInt64(nAmount) - (eAmount * multiplier)) + tempDecValue, bigName2, smallName2, roundDigit2, roundFactor2, wAmount, Int32.Parse(nSet.ToString()) - 1);
                }
                else
                {
                    if (nAmount == "0")
                    {
                        nAmount = nAmount + tempDecValue;
                         tempDecValue = string.Empty;
                    }

                    if ((Math.Round(double.Parse(nAmount), roundDigit2) * (roundFactor2 + 1)) > 0)
                        wAmount = AmountToWords(Convert.ToString(Math.Round(double.Parse(nAmount), roundDigit2) * roundFactor2), bigName2, smallName2, roundDigit2, roundFactor2, wAmount.Trim() + " " + bigName2 + " And ", 1) + " " + smallName2;
                }
            }
            catch (Exception)
            {
                return "!#ERROR_ENCOUNTERED";
            }

            //Trap null values
            if ((wAmount == null))
               wAmount = string.Empty;
            else
                wAmount = wAmount.IndexOf(bigName2, StringComparison.Ordinal) > 0 ? wAmount.Trim() : wAmount.Trim() + " " + bigName2;

            return wAmount;
        }

    }

}