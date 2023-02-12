using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Threading;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.proj
{
    public partial class proj_visit : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetProjectDetails(Request.QueryString["id"].ToInt());
                    UCDatePicker.DateValue = DateTime.Today;
                }
                else
                {
                    Response.Redirect(string.Format("proj-list.aspx?e={0}", 1));
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

        protected void GetProjectDetails(int projectId)
        {
            Proj project = _proj.GetProject(projectId);

            if (project.ProjectId <= 0)
            {
                Response.Redirect("proj-list.aspx?e=1", false);
            }

            ProjectId = project.ProjectId;

            lbProjectName.Text = project.ProjectName;
            lblStartDate.Text = project.StartDate.ToDateString();
            lblEndDate.Text = project.EndDate.ToDateString();
            lblRemarks.Text = project.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = project.Status;

            hlnkCustomerName.Text = project.CustomerName.ReplaceWhenNullOrEmpty("N/A");
            if (project.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", project.CustomerId);
                hlnkCustomerName.Enabled = true;
            }
        }
        protected void CreateProjectVisitLine()
        {
            try
            {
                ProjVisitLine line = new ProjVisitLine();

                line.ProjectId = ProjectId;
                line.Date = UCDatePicker.DateValue;
                line.EmployeeName = txtEmployeeName.Text.ToTrimString();
                line.Remarks = txtRemarks.Text.ToTrimString();

                string rMessage;
                _proj.AddVisitLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    Response.Redirect(string.Format("proj-preview.aspx?id={0}&o={1}", ProjectId, 2, false));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                    CreateProjectVisitLine();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-preview.aspx?id={0}", ProjectId), false);
        }

        //************************************** Properties ************************************//

        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }

    }
}