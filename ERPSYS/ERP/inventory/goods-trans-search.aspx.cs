using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.inventory
{
    public partial class GoodsTransSearch : System.Web.UI.Page
    {
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void BindData()
        {
            rgGoodsList.Rebind();
        }

        protected void rgGoodsList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgGoodsList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetStoreItem();
        }

        private void GetStoreItem()
        {
            try
            {
                if (Description == string.Empty && ItemCode == string.Empty && PartNumber == string.Empty)
                {
                    rgGoodsList.DataSource = new DataTable();
                    return;
                }

                rgGoodsList.DataSource = _inv.GetStoreItem(Description, ItemCode, PartNumber);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Description = txtDescription.Text.ToTrimString();
                ItemCode = txtItemCode.Text.ToTrimString();
                PartNumber = txtPartNumber.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public string Description
        {
            get { return ViewState["Description"] != null ? ViewState["Description"].ToString() : ""; }
            set { ViewState["Description"] = value; }
        }

        public string ItemCode
        {
            get { return ViewState["ItemCode"] != null ? ViewState["ItemCode"].ToString() : ""; }
            set { ViewState["ItemCode"] = value; }
        }

        public string PartNumber
        {
            get { return ViewState["PartNumber"] != null ? ViewState["PartNumber"].ToString() : ""; }
            set { ViewState["PartNumber"] = value; }
        }
    }
}