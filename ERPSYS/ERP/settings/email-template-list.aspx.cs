using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Threading;

namespace ERPSYS.ERP.settings
{
    public partial class EmailTemplateList : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("template_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("template_update_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetData()
        {
            try
            {
                if (Request.QueryString["tid"] != null && Request.QueryString["tid"] != string.Empty)
                {
                    TemplateTypeId = Request.QueryString["tid"].ToInt();
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgEmailTemplate_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgEmailTemplate_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEmailTemplateList();
        }

        private void GetEmailTemplateList()
        {
            try
            {
                rgEmailTemplate.DataSource = _mail.GetEmailTemplateList(TemplateTypeId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int TemplateTypeId
        {
            get { return ViewState["TemplateTypeId"] != null ? ViewState["TemplateTypeId"].ToInt() : -1; }
            set { ViewState["TemplateTypeId"] = value; }
        }
    }
}