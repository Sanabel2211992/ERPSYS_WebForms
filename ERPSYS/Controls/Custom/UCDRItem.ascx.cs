using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.Custom
{
    public partial class UCDRItem : System.Web.UI.UserControl
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
            txtAvailableQuantity.Text = "0".ToDecimal(0).ToString();
            txtQuantity.Text = "1".ToDecimal(0).ToString();
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        {
            ItemBLL item = new ItemBLL();
            rsbItem.DataSource = item.GetDeliveryReceiptItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString(), LocationId);
        }

        protected void rsbItem_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();

                txtDescriptionAs.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtAvailableQuantity.Text = ((Dictionary<string, object>)e.DataItem)["AvailableQuantity"].ToDecimal(0).ToString();
            }
        }
        public string ValidationGroup
        {
            set
            {
                cvItem.ValidationGroup = value;
                rfvdescriptionAs.ValidationGroup = value;
                rfvQuantity.ValidationGroup = value;
                cvQuantity.ValidationGroup = value;
                cvCheck.ValidationGroup = value;
            }
        }

        public void ClearFields()
        {
            hfItemID.Value = string.Empty;
            txtDescription.Text = string.Empty;
            rsbItem.Text = string.Empty;
            txtPartNumber.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtDescriptionAs.Text = string.Empty;
            txtAvailableQuantity.Text = "0".ToDecimal(0).ToString();
            txtQuantity.Text = "1".ToDecimal(0).ToString();
        }

        //************************************** Properties ************************************//

        public int LocationId
        {
            get { return hfLocationId.Value.ToInt(); }
            set { hfLocationId.Value = value.ToString(); }
        }

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

        public string DescriptionAs
        {
            get { return txtDescriptionAs.Text; }
        }

        public decimal AvailableQuantity
        {
            get { return txtAvailableQuantity.Text.ToDecimal(0); }
        }

        public decimal Quantity
        {
            get { return txtQuantity.Text.ToDecimal(0); }
        }
    }
}