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
    public partial class InventoryItemHistoryList : System.Web.UI.Page
    {
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeForm();
                GetItemLookupTables();             
            }
        }

        protected void InitializeForm()
        {
            UCDateRange.StartDate = DateTime.Now.AddDays(-7).ToDate();
            UCDateRange.EndDate = DateTime.Now.ToDate();
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetLocation();
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlLocation.SelectedValue = UserSession.LocationId.ToString();
        }

        private void BindData()
        {
            rgInvItemHistoryList.Rebind();
        }

        protected void rgInvItemHistoryList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgInvItemHistoryList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetStockItemList();
        }

        private void GetStockItemList()
        {
            try
            {
                rgInvItemHistoryList.DataSource = GetStoreItemHistoryList();
                rgInvItemHistoryList.Columns.FindByUniqueName("Cost").Visible = RegisteredUser.HasCostView;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private DataTable GetStoreItemHistoryList()
        {
            try
            {
                return _inv.GetStoreItemHistoryList(DateStart, DateEnd, Description, ItemCode, PartNumber, LocationId);
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
                DataTable dt = GetStoreItemHistoryList();

                dt.Columns.Remove("ItemId");
                dt.Columns.Remove("InventoryId");

                if (!RegisteredUser.HasCostView)
                {
                    dt.Columns.Remove("UnitCost");
                }

                dt.Columns["LogDate"].ColumnName = "Date";
                dt.Columns["PartNumber"].ColumnName = "Part Number";
                dt.Columns["ItemCode"].ColumnName = "Catalog Number";

                if (RegisteredUser.HasCostView)
                {
                    dt.Columns["UnitCost"].ColumnName = "Unit Cost";
                }

                dt.Columns["UOM"].ColumnName = "Unit";

                excel.ExportExcel(dt, ExcelType.Xls, "Products History", "Products_History");
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
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;
                Description = txtDescription.Text.ToTrimString();
                ItemCode = txtItemCode.Text.ToTrimString();
                PartNumber = txtPartNumber.Text.ToTrimString();
                LocationId = ddlLocation.SelectedValue.ToInt();

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

        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : ddlLocation.SelectedValue.ToInt(); }
            set { ViewState["LocationId"] = value; }
        }
    }
}