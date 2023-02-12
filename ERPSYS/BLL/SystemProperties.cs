
namespace ERPSYS.BLL
{
    public class SystemProperties
    {
        public static bool HasSalesTax
        {
            get { return UserSession.HasSalesTax; }
        }

        public static decimal SalesTaxValue
        {
            get { return UserSession.HasSalesTax ? UserSession.SalesTaxValue : 0; }
        }
    }
}