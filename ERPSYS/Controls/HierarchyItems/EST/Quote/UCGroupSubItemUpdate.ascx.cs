using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.HierarchyItems.EST.Quote
{
    public partial class UCGroupSubItemUpdate : System.Web.UI.UserControl
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
            txtItemUnitPrice.Text = "0".ToDecimalFormat();
            txtItemProfit.Text = "0".ToDecimalFormat();
            txtItemDiscount.Text = "0".ToDecimalFormat();
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            ItemBLL item = new ItemBLL();
            rsbItem.DataSource = item.GetSalesQuoteItemSearchBoxByQuote(Request.QueryString["id"].ToInt(), e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemUnitPrice.Text = ((Dictionary<string, object>)e.DataItem)["UnitPrice"].ToDecimalFormat();
                txtItemPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
            }
        }

        protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfItemID.Value.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        public void ClearFields()
        {
            hfItemID.Value = string.Empty;
            txtItemDescription.Text = string.Empty;
            rsbItem.Text = string.Empty;
            txtItemPartNumber.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemUnitPrice.Text = "0".ToDecimalFormat();
            txtItemProfit.Text = "0".ToDecimalFormat();
            txtItemDiscount.Text = "0".ToDecimalFormat();
        }

        //************************************** Properties ************************************//
        public string ValidationGroup
        {
            set
            {
                cvItem.ValidationGroup = value;
                rfvItemUnitPrice.ValidationGroup = value;
                cvItemUnitPrice.ValidationGroup = value;
                rfvItemProfit.ValidationGroup = value;
                cvItemProfit1.ValidationGroup = value;
                cvItemProfit2.ValidationGroup = value;
                rfvItemDiscount.ValidationGroup = value;
                cvItemDiscount1.ValidationGroup = value;
                cvItemDiscount2.ValidationGroup = value;
            }
        }

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
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
    }
}