using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.HierarchyItems.MAN.Material
{
    public partial class UCRItemAdd : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                MaterialTransferId = Request.QueryString["id"].ToInt();
            }
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            try
            {
                string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

                rsbItem.DataSource = _item.GetMaterialTransferReturnItemSearchBox(MaterialTransferId, search);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                txtStockQuantity.Text = ((Dictionary<string, object>)e.DataItem)["StockQuantity"].ToDecimalFormat(0);
                txtItemQuantity.Text = "1".ToDecimalFormat(0);
            }
        }

        public void ResetFields()
        {
            txtItemQuantity.Text = "1".ToDecimalFormat(0);
        }

        protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (hfItemID.Value.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public int MaterialTransferId;

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(3); }
        }

        public object DataItem { get; set; }
    }
}