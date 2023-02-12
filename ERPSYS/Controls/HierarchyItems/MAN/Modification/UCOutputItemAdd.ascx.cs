using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.MAN.Modification
{
    public partial class UCOutputItemAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        {
            ItemBLL item = new ItemBLL();
            rsbItem.DataSource = item.GetModificationItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void rsbItem_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                txtStockQuantity.Text = ((Dictionary<string, object>)e.DataItem)["StockQuantity"].ToDecimalFormat(0);
                txtQuantity.Text = @"1";
            }
        }

        public string ValidationGroup
        {
            set
            {
                cvItem.ValidationGroup = value;
                cvQuantity.ValidationGroup = value;
                rfvQuanitiy.ValidationGroup = value;
            }
        }

        public void ClearFields()
        {
            hfItemID.Value = string.Empty;
            txtDescription.Text = string.Empty;
            rsbItem.Text = string.Empty;
            txtPartNumber.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtStockQuantity.Text = string.Empty;
            txtQuantity.Text = @"1";
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public decimal Quantity
        {
            get { return txtQuantity.Text.ToDecimal(3); }
        }
    }
}