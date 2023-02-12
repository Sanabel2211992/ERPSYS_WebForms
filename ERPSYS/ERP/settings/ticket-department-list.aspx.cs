using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ticket_department_list : System.Web.UI.Page
    {
        readonly TicketBLLx _ticket = new TicketBLLx();

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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("ticket_department_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("ticket_department_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("ticket_department_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("ticket_department_update_success"));
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
            rgTicketDepartmentList.Rebind();
        }

        protected void rgTicketDepartmentList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgTicketDepartmentList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetTicketDepartmentList();
        }
        private void GetTicketDepartmentList()
        {
            try
            {
                rgTicketDepartmentList.DataSource = _ticket.GetTicketDepartmentList();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ticket-department-form.aspx", false);
        }
    }
}