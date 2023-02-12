using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.Quote
{
    public partial class UCMainItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ItemType == "Single")
            {
                pnlSingle.Visible = true;
                pnlGroup.Visible = false;

            }
            else if (ItemType == "Group")
            {
                pnlSingle.Visible = false;
                pnlGroup.Visible = true;
            }
        }

        //************************************** Properties ************************************//

        private string ItemType
        {
            get { return hfItemID.Value.ToInteger() == -1 ? "Group" : "Single"; }
        }

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public string DescriptionAs
        {
            get { return ItemType == "Single" ? txtsMainItemDescription.Text.ToTrimString() : txtgMainItemDescription.Text.ToTrimString(); }
        }

        public decimal UnitPrice
        {
            get { return ItemType == "Single" ? txtsMainItemUnitPrice.Text.ToDecimal() : txtgMainItemUnitPrice.Text.ToDecimal(); }
        }

        public decimal Profit
        {
            get { return ItemType == "Single" ? txtsMainItemProfit.Text.ToDecimal() : 0; }
        }
        public decimal Discount
        {
            get { return ItemType == "Single" ? txtsMainItemDiscount.Text.ToDecimal() : 0; }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }

        public decimal Quantity
        {
            get { return ItemType == "Single" ? txtsMainItemQuantity.Text.ToDecimal(2) : txtgMainItemQuantity.Text.ToDecimal(0); }
        }
        public object DataItem { get; set; }
    }
}