using System;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SM.SalesInvoice
{
    public partial class UCSubItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RoleId == 5)
            {
                cbSpecialItem.Visible = false;
                txtItemUnitPrice.ReadOnly = true;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (DataBinder.Eval(DataItem, "IsSpecialRecord").ToBool())
            {
                GetItemLookupTables();
                ddlLocation.SelectedValue = DataBinder.Eval(DataItem, "LocationId").ToString();
                pnlSpecialItem.Visible = true;
            }
        }
        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetDeliveryReceiptLocation();
            ddlLocation.DataBind();
        }

        protected void cbSpecialItem_CheckedChanged(object sender, EventArgs e)
        {
            pnlSpecialItem.Visible = cbSpecialItem.Checked;
            GetItemLookupTables();
        }

        //************************************** Properties ************************************//

        public string DescriptionAs
        {
            get { return txtItemDescriptionAs.Text.ToTrimString(); }
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
            get { return txtItemQuantity.Text.ToDecimal(); }
        }

        public bool IsSpecialRecord
        {
            get { return cbSpecialItem.Checked; }
        }

        public int LocationId
        {
            get { return cbSpecialItem.Checked ? ddlLocation.SelectedValue.ToInt() : -1; }
        }

        public object DataItem { get; set; }
    }
}