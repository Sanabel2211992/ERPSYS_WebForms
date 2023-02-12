using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.proj
{
    public partial class ProjCreate : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                UCDatePicker.DateValue = DateTime.Today;
                txtCustomerName.Attributes.Add("readonly", "readonly");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void CreateProject()
        {
            Proj proj = new Proj();

            proj.StartDate = UCDatePicker.DateValue;
            //proj.EndDate = UCEndDatePicker.DateValue;
            proj.CustomerId = hfCustomerId.Value.ToInt();
            proj.CustomerName = txtCustomerName.Text.ToTrimString();
            proj.ProjectName = txtProjectName.Text.ToTrimString();
            proj.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var projectId = _proj.CreateProject(proj, out rMessage);

            if (rMessage != string.Empty || projectId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("proj-form.aspx?id={0}", projectId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateProject();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-list.aspx"), false);
        }
    }
}