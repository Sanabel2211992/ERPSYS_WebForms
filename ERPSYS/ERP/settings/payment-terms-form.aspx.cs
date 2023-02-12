using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class PaymentTermsForm : System.Web.UI.Page
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
                cbIsActive.Checked = true;

                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetPaymentTerms(Request.QueryString["id"].ToInt());
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

        protected void GetPaymentTerms(int paymentTermsId)
        {
            PaymentTermsClass paymentTerms = _setting.GetPaymentTerms(paymentTermsId);

            if (paymentTerms.PaymentTermsId <= 0)
            {
                Response.Redirect(string.Format("payment-terms-list.aspx?e={0}", 1));
            }

            PaymentTermsId = paymentTermsId;
            txtPaymentName.Text = paymentTerms.PaymentName;
            txtDaysDue.Text = paymentTerms.DaysDue.ToString();
            cbIsActive.Checked = paymentTerms.IsActive;
        }

        protected void AddPayment()
        {
            PaymentTermsClass payment = new PaymentTermsClass();

            payment.PaymentName = txtPaymentName.Text.ToTrimString();
            payment.DaysDue = txtDaysDue.Text.ToInt();
            payment.IsActive = cbIsActive.Checked;

            string rMessage;
            int paymentTermsId = _setting.AddPayment(payment, out rMessage);

            if (rMessage != string.Empty || paymentTermsId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("payment-terms-list.aspx?o={0}", 1), false);
        }

        protected void UpdatePaymentTerms()
        {
            PaymentTermsClass payment = new PaymentTermsClass();

            payment.PaymentTermsId = PaymentTermsId;
            payment.PaymentName = txtPaymentName.Text.ToTrimString();
            payment.DaysDue = txtDaysDue.Text.ToInt();
            payment.IsActive = cbIsActive.Checked;

            string rMessage;
            _setting.UpdatePaymentTerms(payment, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("payment-terms-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddPayment();
                }
                else if (Operation == "edit" && PaymentTermsId > 0)
                {
                    UpdatePaymentTerms();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("payment-terms-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int PaymentTermsId
        {
            get { return ViewState["PaymentTermsId"] != null ? ViewState["PaymentTermsId"].ToInt() : -1 ; }
            set { ViewState["PaymentTermsId"] = value; }
        }
    }
}