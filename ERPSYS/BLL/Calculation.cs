using ERPSYS.Helpers.Ext;

namespace ERPSYS.BLL
{
    public class Calculation
    {
        public static decimal GetNetPrice(decimal unitPrice, decimal discount, bool isDiscountRatio)
        {
            decimal netPrice;

            if (isDiscountRatio)
            {
                netPrice = (unitPrice * (1 - (discount))); // ex (0.06)
            }
            else
            {
                netPrice = (unitPrice - discount);
            }

            return netPrice;
        }

        public static decimal GetNetPrice(decimal unitPrice, decimal profit, decimal discount, bool isDiscountRatio)
        {
            decimal netPrice;

            if (isDiscountRatio)
            {
                netPrice = ((unitPrice * (1 + profit)) * (1 - (discount))); // ex (0.06)
            }
            else
            {
                netPrice = ((unitPrice * (1 + profit)) - discount);
            }

            return netPrice;
        }

        //public static decimal GetNetPrice(decimal unitPrice, decimal profit, decimal discount, bool isDiscountRatio, bool isRoundUp)
        //{
        //    decimal netPrice;

        //    if (isDiscountRatio)
        //    {
        //        netPrice = ((unitPrice * (1 + profit)) * (1 - (discount))); // ex (0.06)
        //    } 
        //    else
        //    {
        //        netPrice = ((unitPrice * (1 + profit)) - discount);
        //    }

        //    return isRoundUp ? netPrice.RoundUp() : netPrice;
        //}

        public static decimal GetLineTotal(decimal netPrice, decimal quantity)
        {

            return netPrice * quantity;
        }

        public static decimal GetSalesTaxAmount(decimal subTotal, decimal expenses, decimal discount, bool isDiscountRatio, decimal tax)
        {
            decimal total;

            tax = tax < 1 ? tax : 0;
            //subTotal += expenses;

            if (isDiscountRatio)
            {
                total = (subTotal * (1 - (discount)));
            }
            else
            {
                total = (subTotal - discount);
            }

            total += expenses;
            total = (total * tax);

            return total;
        }

        public static decimal GetGrandTotal(decimal subTotal, decimal discount, bool isDiscountRatio)
        {
            decimal total;

            if (isDiscountRatio)
            {
                total = (subTotal * (1 - (discount)));
            }
            else
            {
                total = (subTotal - discount);
            }

            return total;
        }

        //public static decimal GetGrandTotal(decimal subTotal, decimal expenses, decimal discount, bool isDiscountRatio)
        //{
        //    decimal total;

        //    subTotal += expenses;

        //    if (isDiscountRatio)
        //    {
        //        total = (subTotal * (1 - (discount)));
        //    }
        //    else
        //    {
        //        total = (subTotal - discount);
        //    }

        //    return total;
        //}

        public static decimal GetGrandTotal(decimal subTotal, decimal expenses, decimal discount, bool isDiscountRatio, decimal tax)
        {
            decimal total;

            tax = tax < 1 ? tax : 0;
            //subTotal += expenses;

            if (isDiscountRatio)
            {
                total = (subTotal * (1 - (discount)));
            }
            else
            {
                total = (subTotal - discount);
            }

            total += expenses;
            total = (total * (1 + (tax)));

            return total;
        }

    }
}
