using System;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SM.DeliveryReceipt
{
    public partial class UCMainItemAdjust : System.Web.UI.UserControl
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

                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = lookup.GetDeliveryReceiptLocation();
                ddlLocation.DataBind();

                ddlLocation.SelectedValue = DataBinder.Eval(DataItem, "LocationId").ToString();
            }
        }

        //************************************** Properties ************************************//

        public int LocationId
        {
            get { return ddlLocation.SelectedValue.ToInt(); }
        }

        public object DataItem { get; set; }
    }
}