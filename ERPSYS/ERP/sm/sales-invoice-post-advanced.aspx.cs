using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoicePostAdvanced : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

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
                    GetSalesInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
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

        protected void GetSalesInvoice(int invoiceId)
        {
            SettingsBLL setting = new SettingsBLL();
            SystemSettings preferences = setting.GetSystemSettings();

            if (!preferences.SetSalesInvoiceReferenceManually)
            {
                Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", invoiceId));
            }

            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            if (invoice.StatusId != 1)
            {
                Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&e={1}", invoiceId, 5));
            }

            InvoiceId = invoice.InvoiceId;
            lblCustomerName.Text = invoice.CustomerName;
            lblCustomerPO.Text = invoice.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = invoice.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = invoice.InvoiceDate;
        }

        protected void PostSalesInvoice()
        {
            try
            {
                string rMessage;
                int rMessageId;

                int invoiceSeq = txtInvoiceSequence.Value.ToInt();
                DateTime invoiceDate = UCDatePicker.DateValue;

                _invoice.PostSalesInvoiceAdvanced(InvoiceId, invoiceSeq, invoiceDate, out rMessage, out rMessageId);

                if (rMessage != string.Empty)
                {
                    Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&e={1}", InvoiceId, rMessageId));
                }

                Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", InvoiceId, 2), false);
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            PostSalesInvoice();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", InvoiceId));
        }

        //************************************** Properties ************************************//

        public int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}