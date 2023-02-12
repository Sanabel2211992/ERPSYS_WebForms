using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.Custom
{
    public partial class UCRawMaterialItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        protected void InitializeComponent()
        {
            txtQuantity.Text = @"1".ToDecimalFormat(2);
            txtStockQuantity.Text = @"0".ToDecimalFormat(2);
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        {
            ItemBLL item = new ItemBLL();
            rsbItem.DataSource = item.GetRawMaterialItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void rsbItem_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                hfCategory.Value = ((Dictionary<string, object>)e.DataItem)["Category"].ToString();
                hfSubCategory.Value = ((Dictionary<string, object>)e.DataItem)["SubCategory"].ToString();
                hfUOM.Value = ((Dictionary<string, object>)e.DataItem)["UOM"].ToString();
                txtStockQuantity.Text = ((Dictionary<string, object>)e.DataItem)["AvailableQuantity"].ToDecimal().ToString();
            }
        }

        public string ValidationGroup
        {
            set
            {
                cvItem.ValidationGroup = value;
                cvQuantity1.ValidationGroup = value;
                rfvQuanitiy.ValidationGroup = value;
            }
        }

        public void ClearFields()
        {
            hfItemID.Value = string.Empty;
            hfCategory.Value = string.Empty;
            hfSubCategory.Value = string.Empty;
            txtDescription.Text = string.Empty;
            rsbItem.Text = string.Empty;
            txtPartNumber.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtQuantity.Text = @"1".ToDecimalFormat(2);
            txtStockQuantity.Text = @"0".ToDecimalFormat(2);
            hfUOM.Value = string.Empty;
        }

        //************************************** Properties ************************************//

        public int ItemID
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public string PartNumber
        {
            get { return txtPartNumber.Text; }
        }

        public string ItemCode
        {
            get { return txtItemCode.Text; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
        }

        public decimal Quantity
        {
            get { return txtQuantity.Text.ToDecimal(); }
        }

        public decimal AvailableQuantity
        {
            get { return txtStockQuantity.Text.ToDecimal(); }
        }

        public string Category
        {
            get { return hfCategory.Value; }
        }

        public string SubCategory
        {
            get { return hfSubCategory.Value; }
        }

        public string UOM
        {
            get { return hfUOM.Value; }
        }
    }
}