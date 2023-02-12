using System;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SCM.PurchaseInvoice
{
    public partial class UCItemEdit : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetItemLookupTables();
        }

        protected void GetItemLookupTables()
        {
            if (DataItem != null) // mean it's not binding do it to reduse postback because in this control postback is always true
            {
                LookupBLL lookup = new LookupBLL();

                ddlUOM.DataTextField = "Name";
                ddlUOM.DataValueField = "UomId";
                ddlUOM.DataSource = lookup.GetUom();

                ddlUOM.DataBind();

                ddlUOM.SelectedValue = DataBinder.Eval(DataItem, "PurchaseUomId").ToString();
            }
        }

        //************************************** Properties ************************************//

        public decimal UnitPrice
        {
            get { return txtItemUnitPrice.Text.ToDecimal(3); }
        }

        public decimal Discount
        {
            get { return 0; }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(); }
        }

        public int UomId
        {
            get { return ddlUOM.SelectedValue.ToInt(); }
        }

        public object DataItem { get; set; }
    }
}