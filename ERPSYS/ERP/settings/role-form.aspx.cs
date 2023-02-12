using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System;
using System.Threading;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class RoleForm : System.Web.UI.Page
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
                    GetRoleDetails(Request.QueryString["id"].ToInt());
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

        protected void GetRoleDetails(int roleId)
        {
            try
            {
                Role role = _setting.GetRole(roleId);

                if (role.RoleId <= 0)
                {
                    Response.Redirect(string.Format("role-list.aspx?e={0}", 1));
                }

                RoleId = roleId;
                txtRoleName.Text = role.Name;
                txtDescription.Text = role.Description;
                txtRemark.Text = role.Remark;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void AddRole()
        {
            Role role = new Role();

            role.Name = txtRoleName.Text.ToTrimString();
            role.Description = txtDescription.Text.ToTrimString();
            role.Remark = txtRemark.Text.ToTrimString();

            string rMessage;
            int roleId = _setting.AddRole(role, out rMessage);

            if (rMessage != string.Empty || roleId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("role-list.aspx?o={0}", 1), false);
        }

        protected void UpdateRole()
        {
            Role role = new Role();

            role.RoleId = RoleId;
            role.Name = txtRoleName.Text.ToTrimString();
            role.Description = txtDescription.Text.ToTrimString();
            role.Remark = txtRemark.Text.ToTrimString();

            string rMessage;
            _setting.UpdateRole(role, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("role-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddRole();
                }
                else if (Operation == "edit" && RoleId > 0)
                {
                    UpdateRole();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("role-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int RoleId
        {
            get { return ViewState["RoleId"] != null ? ViewState["RoleId"].ToInt() : -1; }
            set { ViewState["RoleId"] = value; }
        }
    }
}