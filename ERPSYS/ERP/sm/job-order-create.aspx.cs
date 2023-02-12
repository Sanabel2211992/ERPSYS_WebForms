using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderCreate : System.Web.UI.Page
    {
        readonly JobOrderBLL _order = new JobOrderBLL();

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
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void CreateJobOrder()
        {
            JobOrder order = new JobOrder();

            order.CustomerId = UCCustomer.CustomerId;
            order.OrderDate = UCDatePicker.DateValue;
            order.ProjectName = txtProjectName.Text.ToTrimString();
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var orderId = _order.CreateJobOrder(order, out rMessage);

            if (rMessage != string.Empty || orderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("job-order-form.aspx?id={0}", orderId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateJobOrder();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("job-order-list.aspx"), false);
        }
    }
}