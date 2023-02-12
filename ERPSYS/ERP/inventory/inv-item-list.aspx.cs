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
    public partial class InventoryItemList : System.Web.UI.Page
    {
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetItemLookupTables();
            }
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
            rgInvItemList.Rebind();
        }

        protected void rgInvItemList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgInvItemList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgInvItemList.DataSource = GetStockItemList();
            rgInvItemList.Columns.FindByUniqueName("Cost").Visible = RegisteredUser.HasCostView;
        }

        private DataTable GetStockItemList()
        {
            try
            {
                return _inv.GetStoreItemList(Description, ItemCode, PartNumber, LocationId, IsZero);
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

                dt.Columns.Remove("InventoryId");
                dt.Columns.Remove("ItemId");

                if (!RegisteredUser.HasCostView)
                {
                    dt.Columns.Remove("UnitCost");
                }
                else
                {
                    dt.Columns["UnitCost"].ColumnName = "Unit Cost";
                }
                dt.Columns["PartNumber"].ColumnName = "Part Number";
                dt.Columns["ItemCode"].ColumnName = "Catalog Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Current Stock", "Current_Stock");
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
                LocationId = ddlLocation.SelectedValue.ToInt();
                IsZero = cbIsZero.Checked;

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

        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : ddlLocation.SelectedValue.ToInt(); }
            set { ViewState["LocationId"] = value; }
        }

        public bool IsZero
        {
            get { return ViewState["IsZero"] != null && ViewState["IsZero"].ToBool(); }
            set { ViewState["IsZero"] = value; }
        }
    }
}