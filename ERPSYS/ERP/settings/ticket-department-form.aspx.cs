using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System;
using System.Threading;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ticket_department_form : System.Web.UI.Page
    {
        readonly TicketBLLx _ticket = new TicketBLLx();

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
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetdepartmentDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
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

        protected void GetdepartmentDetails(int departmentId)
        {
            try
            {
                TicketDepartment department = _ticket.GetDepartmentDetails(departmentId);

                if (department.DepartmentId <= 0)
                {
                    Response.Redirect(string.Format("ticket-department-list.aspx?e={0}", 1));
                }

                DepartmentId = departmentId;
                txtDepartmentName.Text = department.Name;
                txtDescription.Text = department.Description;
                rblIsActive.SelectedValue = department.IsActive ? "true" : "false";

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void Adddepartment()
        {
            TicketDepartment department = new TicketDepartment();

            department.Name = txtDepartmentName.Text.ToTrimString();
            department.Description = txtDescription.Text.ToTrimString();
            department.IsActive = rblIsActive.SelectedValue == "true";

            string rMessage;
            int departmentId = _ticket.AddDepartment(department, out rMessage);

            if (rMessage != string.Empty || departmentId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("ticket-department-list.aspx?o={0}", 1), false);
        }

        protected void Updatedepartment()
        {
            TicketDepartment department = new TicketDepartment();

            department.DepartmentId = DepartmentId;
            department.Name = txtDepartmentName.Text.ToTrimString();
            department.Description = txtDescription.Text.ToTrimString();
            department.IsActive = rblIsActive.SelectedValue == "true";

            string rMessage;
            _ticket.UpdateDepartment(department, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("ticket-department-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    Adddepartment();
                }

                else if (Operation == "edit" && DepartmentId > 0)
                {
                    Updatedepartment();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ticket-department-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int DepartmentId
        {
            get { return ViewState["DepartmentId"] != null ? ViewState["DepartmentId"].ToInt() : -1; }
            set { ViewState["DepartmentId"] = value; }
        }
    }
}