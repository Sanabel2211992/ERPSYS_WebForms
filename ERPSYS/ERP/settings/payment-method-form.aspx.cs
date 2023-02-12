using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class PaymentMethodForm : System.Web.UI.Page
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
                    GetPaymentMethod(Request.QueryString["id"].ToInt());
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

        protected void GetPaymentMethod(int paymentmethodId)
        {
            PaymentMethodClass paymentMethod = _setting.GetPaymentMethod(paymentmethodId);

            if (paymentMethod.PaymentMethodId <= 0)
            {
                Response.Redirect(string.Format("payment-method-list.aspx?e={0}", 1));
            }

            PaymentMethodId = paymentmethodId;
            txtMethodName.Text = paymentMethod.Name;
        }

        protected void AddPaymentMethod()
        {
            PaymentMethodClass method = new PaymentMethodClass();

            method.Name = txtMethodName.Text.ToTrimString();

            string rMessage;
            int paymentMethodId = _setting.AddPaymentMethod(method, out rMessage);


            if (rMessage != string.Empty || paymentMethodId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("payment-method-list.aspx?o={0}", 1), false);
        }

        protected void UpdatePaymentMethod()
        {
            PaymentMethodClass method = new PaymentMethodClass();

            method.PaymentMethodId = PaymentMethodId;
            method.Name = txtMethodName.Text.ToTrimString();
         
            string rMessage;
            _setting.UpdatePaymentMethod(method, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("payment-method-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddPaymentMethod();
                }
                else if (Operation == "edit" && PaymentMethodId > 0)
                {
                    UpdatePaymentMethod();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("payment-method-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int PaymentMethodId
        {
            get { return ViewState["PaymentMethodId"] != null ? ViewState["PaymentMethodId"].ToInt() : -1; }
            set { ViewState["PaymentMethodId"] = value; }
        }
    }
}