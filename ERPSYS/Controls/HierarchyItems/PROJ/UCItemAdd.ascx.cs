using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.HierarchyItems.PROJ
{
    public partial class UCItemAdd : System.Web.UI.UserControl
    {
        readonly ProjBLL _proj = new ProjBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDescription.Text = Request.Form[txtDescription.UniqueID];
            txtPartNumber.Text = Request.Form[txtPartNumber.UniqueID];
            txtItemCode.Text = Request.Form[txtItemCode.UniqueID];
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //GetItemLookupTables();

            txtUnitPrice.Text = "0".ToDecimalFormat();
            txtQuantity.Text = "1".ToDecimalFormat();
        }

        //protected void GetItemLookupTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlUOM.DataTextField = "Name";
        //    ddlUOM.DataValueField = "UomId";
        //    ddlUOM.DataSource = lookup.GetUom();

        //    ddlUOM.DataBind();

        //    ddlUOM.SelectedValue = "1";
        //}

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                //hfPurchaseUomId.Value = ((Dictionary<string, object>)e.DataItem)["PurchaseUomId"].ToString();
                //ddlUOM.SelectedValue = ((Dictionary<string, object>)e.DataItem)["PurchaseUomId"].ToString();
                txtUnitPrice.Text = "0".ToDecimalFormat();
                txtQuantity.Text = "1".ToDecimalFormat();
            }
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            rsbItem.DataSource = _proj.GetProjectItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfItemID.Value.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public string Description
        {
            get { return txtDescription.Text.ToTrimString(); }
        }

        public string PartNumber
        {
            get { return txtPartNumber.Text.ToTrimString(); }
        }

        public string ItemCode
        {
            get { return txtItemCode.Text.ToTrimString(); }
        }

        //public int UomId
        //{
        //    get { return ddlUOM.SelectedValue.ToInt(); }
        //}

        public decimal UnitPrice
        {
            get { return txtUnitPrice.Text.ToDecimal(); }
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
            get { return txtQuantity.Text.ToDecimal(); }
        }
    }
}