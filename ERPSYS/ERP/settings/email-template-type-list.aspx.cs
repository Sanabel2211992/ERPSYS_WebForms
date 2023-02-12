using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class EmailTemplateTypeList : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rgEmailTemplateType_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgEmailTemplateType_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEmailTemplateTypeList();
        }

        private void GetEmailTemplateTypeList()
        {
            try
            {
                rgEmailTemplateType.DataSource = _mail.GetEmailTemplateTypeList();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}