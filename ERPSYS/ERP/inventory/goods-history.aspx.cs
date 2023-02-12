using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.inventory
{
    public partial class GoodsHistory : System.Web.UI.Page
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
            ddlLocation.DataSource = lookup.GetGoodsLocation();
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgGoodsHistoryList.Rebind();
        }

        protected void rgGoodsHistoryList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgGoodsHistoryList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetGoodsHistory();
        }

        private void GetGoodsHistory()
        {
            try
            {
                rgGoodsHistoryList.DataSource = _inv.GetStoreHistory(LogDate, Description, ItemCode, PartNumber, LocationId);
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
                LogDate = UCDatePicker.DateValue;
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

        public DateTime LogDate
        {
            get { return ViewState["LogDate"] != null ? ViewState["LogDate"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["LogDate"] = value; }
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