using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.ERP.lab
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

        protected void btnMoveUp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton upbtn = (ImageButton)sender;
                GridDataItem item = (GridDataItem)upbtn.NamingContainer;
                int index = item.ItemIndex;
                if (index-1 != -1)
                {
                    int movedItemId = rgProjectsList.MasterTableView.DataKeyValues[index]["ProjectId"].ToInt();
                    int beforeItemId = rgProjectsList.MasterTableView.DataKeyValues[index - 1]["ProjectId"].ToInt();

                    string rMsg;
                    _project.Move(movedItemId, beforeItemId, out rMsg);

                    if (rMsg != string.Empty)
                    {
                        AppNotification.MessagePanelFailed(rMsg, "Failed");
                    }
                    rgProjectsList.Rebind();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnMoveDown_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton downbtn = (ImageButton)sender;
                GridDataItem item = (GridDataItem)downbtn.NamingContainer;
                int index = item.ItemIndex;
                if (index + 1 < rgProjectsList.Items.Count)
                {
                    int movedItemId = rgProjectsList.MasterTableView.DataKeyValues[index]["ProjectId"].ToInt();
                    int afterItemId = rgProjectsList.MasterTableView.DataKeyValues[index + 1]["ProjectId"].ToInt();

                    string rMsg;
                    _project.Move(movedItemId, afterItemId, out rMsg);

                    if (rMsg != string.Empty)
                    {
                        AppNotification.MessagePanelFailed(rMsg, "Failed");
                    }
                    rgProjectsList.Rebind();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public string ProjectName
        {
            get { return ViewState["ProjectName"] != null ? ViewState["ProjectName"].ToString() : ""; }
            set { ViewState["ProjectName"] = value; }
        }
    }
}