using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.EST.Quote
{
    public partial class UCGroupSubItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //************************************** Properties ************************************//

        public decimal UnitPrice
        {
            get { return txtItemUnitPrice.Text.ToDecimal(); }
        }

        public decimal Profit
        {
            get { return txtItemProfit.Text.ToDecimal(); }
        }

        public decimal Discount
        {
            get { return txtItemDiscount.Text.ToDecimal(); }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }
    }
}