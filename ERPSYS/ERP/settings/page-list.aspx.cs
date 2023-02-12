using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.settings
{
    public partial class PageList : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

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
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("page_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("page_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("page_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("page_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("page_delete_success"));
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

            ddlAccessType.DataTextField = "Name";
            ddlAccessType.DataValueField = "AccessTypeId";
            ddlAccessType.DataSource = lookup.GetPageAccessType();
            ddlAccessType.DataBind();

            ddlAccessType.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgPageList.Rebind();
        }

        protected void rgPageList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgPageList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetPagesList();
        }

        private void GetPagesList()
        {
            try
            {
                rgPageList.DataSource = _setting.GetPageList(PageName, StatusId, AccessTypeId);
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
                PageName = txtPageName.Text.ToTrimString();
                StatusId = ddlPageStatus.SelectedValue.ToInt();
                AccessTypeId = ddlAccessType.SelectedValue.ToInt();        

              BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPageList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                int accessTypeId = dataItem["AccessTypeId"].Text.ToInt();

                switch (accessTypeId)
                {
                    case 1: //Public
                        dataItem["AccessType"].ForeColor = System.Drawing.Color.Green;
                        break;
                    case 2: //Restricted
                        dataItem["AccessType"].ForeColor = System.Drawing.Color.Red;
                        break;
                }
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("page-form.aspx", false);
        }

        //************************************** Properties ************************************//

        public string PageName
        {
            get { return ViewState["PageName"] != null ? ViewState["PageName"].ToString() : ""; }
            set { ViewState["PageName"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }

        public int AccessTypeId
        {
            get { return ViewState["AccessTypeId"] != null ? ViewState["AccessTypeId"].ToInt() : -1; }
            set { ViewState["AccessTypeId"] = value; }
        }
    }
}