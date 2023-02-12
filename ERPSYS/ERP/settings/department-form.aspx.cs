using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System;
using System.Threading;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class DepartmentForm : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

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
                    GetDepartmentDetails(Request.QueryString["id"].ToInt());
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

        protected void GetDepartmentDetails(int departmentId)
        {
            try
            {
                Department department = _setting.GetDepartment(departmentId);

                if (department.DepartmentId <= 0)
                {
                    Response.Redirect(string.Format("department-list.aspx?e={0}", 1));
                }

                DepartmentId = departmentId;
                txtDepartmentName.Text = department.Name;
                txtDescription.Text = department.Description;
                txtRemark.Text = department.Remark;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddDepartment()
        {
            Department department = new Department();

            department.Name = txtDepartmentName.Text.ToTrimString();
            department.Description = txtDescription.Text.ToTrimString();
            department.Remark = txtRemark.Text.ToTrimString();

            string rMessage;
           int departmentId = _setting.AddDepartment(department, out rMessage);

            if (rMessage != string.Empty || departmentId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("department-list.aspx?o={0}", 1), false);
        }

        protected void UpdateDepartment()
        {
            Department department = new Department();

            department.DepartmentId = DepartmentId;
            department.Name = txtDepartmentName.Text.ToTrimString();
            department.Description = txtDescription.Text.ToTrimString();
            department.Remark = txtRemark.Text.ToTrimString();

            string rMessage;
             _setting.UpdateDepartment(department, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("department-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddDepartment();
                }
                else if (Operation == "edit" && DepartmentId > 0)
                {
                    UpdateDepartment();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("department-list.aspx"), false);
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