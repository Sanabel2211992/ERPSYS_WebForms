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
    public partial class TransferList : System.Web.UI.Page
    {
        readonly InventoryBLL _inventory = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetLookupTables();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("inv_transfer_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_id_not_exist"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_post_failed"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlTransferStatus.DataTextField = "Name";
            ddlTransferStatus.DataValueField = "TransferStatusId";
            ddlTransferStatus.DataSource = lookup.GetSalesTransferStatus();
            ddlTransferStatus.DataBind();

            ddlTransferStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgTransferList.Rebind();
        }

        protected void rgTransferList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgTransferList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgTransferList.DataSource = GetPurchaseOrderList();
        }

        private DataTable GetPurchaseOrderList()
        {
            try
            {
                return _inventory.GetStockTransferList(TransferNumber, JobOrderNumber, TransferStatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null; 
        }

        protected void rgTransferList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["TransferStatus"].Text;

                switch (statusId)
                {
                    case 1: //DRAFT
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //POSTED
                        imgStatus.ImageUrl = "../resources/images/status/posted.png";
                        break;
                }
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

                case "add":
                    Response.Redirect("~/ERP/inventory/transfer-create.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetPurchaseOrderList();

                dt.Columns.Remove("TransferId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("PostUserId");

                dt.Columns["TransferNumber"].ColumnName = "Transfer Number";
                dt.Columns["PostedUserName"].ColumnName = "Posted By";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["TransferStatus"].ColumnName = "Status";
                dt.Columns["FromLocation"].ColumnName = "From Stock";
                dt.Columns["ToLocation"].ColumnName = "To Stock";
                dt.Columns["JobOrderNumber"].ColumnName = "Job Order Number";
                dt.Columns["TransferDescription"].ColumnName = "Description";
                dt.Columns["TransferDate"].ColumnName = "Date";

                excel.ExportExcel(dt, ExcelType.Xls, "Stock Transfer History", "Stock_Transfer_History");
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
                TransferNumber = txtTransferNumber.Text.ToTrimString();
                JobOrderNumber = txtJobOrderNumber.Text.ToTrimString();
                TransferStatusId = ddlTransferStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ERP/inventory/transfer-create.aspx", false);
        //}

        //************************************** Properties ************************************//

        public string TransferNumber
        {
            get { return ViewState["TransferNumber"] != null ? ViewState["TransferNumber"].ToString() : ""; }
            set { ViewState["TransferNumber"] = value; }
        }

        public string JobOrderNumber
        {
            get { return ViewState["JobOrderNumber"] != null ? ViewState["JobOrderNumber"].ToString() : ""; }
            set { ViewState["JobOrderNumber"] = value; }
        }

        public int TransferStatusId
        {
            get { return ViewState["TransferStatusId"] != null ? ViewState["TransferStatusId"].ToInt() : -1; }
            set { ViewState["TransferStatusId"] = value; }
        }
    }
}