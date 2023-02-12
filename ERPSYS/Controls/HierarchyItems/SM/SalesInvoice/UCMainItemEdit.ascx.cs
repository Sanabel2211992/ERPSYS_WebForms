using System;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SM.SalesInvoice
{
    public partial class UCMainItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RoleId == 5)
            {
                cbSpecialItem.Visible = false;
                txtsMainItemUnitPrice.ReadOnly = true;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Type == "Single")
            {
                pnlSingle.Visible = true;
                pnlGroup.Visible = false;
                if (DataBinder.Eval(DataItem, "IsSpecialRecord").ToBool())
                {
                    GetItemLookupTables();
                    ddlLocation.SelectedValue = DataBinder.Eval(DataItem, "LocationId").ToString();
                    pnlSpecialItem.Visible = true;
                }
            }
            else if (Type == "Group")
            {
                pnlSingle.Visible = false;
                pnlGroup.Visible = true;
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

        private string Type
        {
            get { return hfItemID.Value.ToInteger() == -1 ? "Group" : "Single"; }
        }

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public string DescriptionAs
        {
            get { return Type == "Single" ? txtsMainItemDescription.Text.ToTrimString() : txtgMainItemDescription.Text.ToTrimString(); }
        }

        public decimal UnitPrice
        {
            get { return Type == "Single" ? txtsMainItemUnitPrice.Text.ToDecimal() : txtgMainItemUnitPrice.Text.ToDecimal(); }
        }

        public decimal Profit
        {
            get { return Type == "Single" ? txtsMainItemProfit.Text.ToDecimal() : 0; }
        }

        public decimal Discount
        {
            get { return Type == "Single" ? txtsMainItemDiscount.Text.ToDecimal() : 0; }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }

        public decimal Quantity
        {
            get { return Type == "Single" ? txtsMainItemQuantity.Text.ToDecimal(0) : txtgMainItemQuantity.Text.ToDecimal(0); }
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