using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.inventory
{
    public partial class InventoryItemTransList : System.Web.UI.Page
    {
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeForm();
            }
        }

        protected void InitializeForm()
        {
            UCDateRange.StartDate = DateTime.Now.AddDays(-7).ToDate();
            UCDateRange.EndDate = DateTime.Now.ToDate();
        }

        private void BindData()
        {
            rgInvItemTransList.Rebind();
        }

        private DataTable GetStockItemList()
        {
            try
            {
                return _inv.GetStoreItemTransactionList(DateStart, DateEnd, Description, ItemCode, PartNumber);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
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
                DataTable dt = GetStockItemList();

                dt.Columns.Remove("TransactionId");
                dt.Columns.Remove("ItemId");

                if (!RegisteredUser.HasCostView)
                {
                    dt.Columns.Remove("AverageCostBefore");
                    dt.Columns.Remove("AverageCostAfter");
                }

                dt.Columns["TransactionDate"].ColumnName = "Date";
                dt.Columns["PartNumber"].ColumnName = "Part Number";
                dt.Columns["VoucherType"].ColumnName = "Voucher Type";
                if (RegisteredUser.HasCostView)
                {
                    dt.Columns["AverageCostBefore"].ColumnName = "Cost Before";
                    dt.Columns["AverageCostAfter"].ColumnName = "Cost After";
                }
                dt.Columns["QuantityBefore"].ColumnName = "Quantity Before";
                dt.Columns["QuantityAfter"].ColumnName = "Unit";
                dt.Columns["UOM"].ColumnName = "Quantity After";

                excel.ExportExcel(dt, ExcelType.Xls, "Products Transaction", "Products_Transaction");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgInvItemTransList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgInvItemTransList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgInvItemTransList.DataSource = GetStockItemList();
            rgInvItemTransList.Columns.FindByUniqueName("Cost").Visible = RegisteredUser.HasCostView;
        }

      
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;
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

        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : DateTime.Now.AddDays(-7).ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : DateTime.Now.ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

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