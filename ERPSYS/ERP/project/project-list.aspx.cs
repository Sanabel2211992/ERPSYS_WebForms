using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.ERP.project
{
    public partial class project_list : System.Web.UI.Page
    {
        readonly ProjectBLL _project = new ProjectBLL();
        private readonly SystemBLL _system = new SystemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                //_system.GetPageList();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("project_id_not_exist"));
                        break;
                    //case "4":
                    //    AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("project_delete_failed"));
                    //    break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("project_add_success"));
                        break;
                    //case "3":
                    //    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("project_delete_success"));
                    //    break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgProjectsList.Rebind();
        }

        protected void rgProject_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgProject_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetProjectsList();
        }

        private void GetProjectsList()
        {
            try
            {
                rgProjectsList.DataSource = _project.ProjectsList(ProjectName);
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
                ProjectName = txtProjectName.Text.ToTrimString();
                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("project-form.aspx");
        }

        //************************************** Properties ************************************//

        public string ProjectName
        {
            get { return ViewState["ProjectName"] != null ? ViewState["ProjectName"].ToString() : ""; }
            set { ViewState["ProjectName"] = value; }
        }
    }
}