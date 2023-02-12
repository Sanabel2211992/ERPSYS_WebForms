using System;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.item
{
    public partial class latest_item : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_update_success"));
                        break;

                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_delete_success"));
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
            rgItemList.Rebind();
        }

        protected void rgItemList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgItemList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
            }
        }

        protected void rgItemList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgItemList.DataSource = _item.GetLatestItemList(ProductSearch);
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
                ProductSearch = txtProductSearch.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//
        public string ProductSearch
        {
            get { return ViewState["ProductSearch"] != null ? ViewState["ProductSearch"].ToString() : ""; }
            set { ViewState["ProductSearch"] = value; }
        }
    }
}