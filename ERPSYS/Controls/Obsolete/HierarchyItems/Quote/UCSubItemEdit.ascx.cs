using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.Quote
{
    public partial class UCSubItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //************************************** Properties ************************************//

        public string DescriptionAs
        {
            get { return txtItemDescriptionAs.Text; }
        }

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

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(0); }
        }

        public object DataItem { get; set; }
    }
}