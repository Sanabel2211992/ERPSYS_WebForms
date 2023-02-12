using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.inventory
{
    public partial class GoodsReceivedStore : System.Web.UI.Page
    {
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("goods_received_item_id_not_exist"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgInvItemList.Rebind();
        }

        private DataTable GetGoodsReceivedStoreList()
        {
            try
            {
                return _inv.GetGoodsReceivedStoreItems(Description, ItemCode, PartNumber);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgInvItemList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgInvItemList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgInvItemList.DataSource = GetGoodsReceivedStoreList();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "export":
                    ExportToExcelFile();
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetGoodsReceivedStoreList();

                dt.Columns.Remove("ItemId");
                dt.Columns.Remove("InventoryId");

                dt.Columns["PartNumber"].ColumnName = "Part Number";
                dt.Columns["ItemCode"].ColumnName = "Catalog Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Received Goods Store", "Received_Goods");
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