using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.crm
{
    public partial class ClientList : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("client_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("client_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("client_delete_success"));
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
            rgClientList.Rebind();
        }

        protected void rgClientList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgClientList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetClientList();
        }

        private void GetClientList()
        {
            try
            {
                rgClientList.DataSource = _client.GetClientList(ClientName);
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
                ClientName = txtName.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("client-form.aspx", false);
        }

        //************************************** Properties ************************************//
        public string ClientName
        {
            get { return ViewState["ClientName"] != null ? ViewState["ClientName"].ToString() : ""; }
            set { ViewState["ClientName"] = value; }
        }
    }
}