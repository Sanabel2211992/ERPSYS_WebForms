using System;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.BLL;
using System.Threading;
using Telerik.Web.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoicePro : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _salesinvoice = new SalesInvoiceBLL();
        readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();
        private List<ProformaInvoiceLine> _lstLines = new List<ProformaInvoiceLine>();

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
                GetItemLookupTables();
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetProformaInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
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

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetSalesLocation();
            ddlLocation.DataBind();
            ddlLocation.SelectedValue = _salesinvoice.DefaultLocationId.ToString();

        }

        protected void GetProformaInvoice(int invoiceId)
        {
            ProformaInvoice invoice = _invoice.GetProformaInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoiceId;
            UCDatePicker.DateValue = invoice.InvoiceDate;
            UCCustomerList.CustomerId = invoice.CustomerId;
            UCCustomerList.CustomerName = invoice.CustomerName;
            lblInvoiceNumber.Text = invoice.InvoiceNumber;
            ddlPaymentMethod.SelectedValue = invoice.PaymentMethodId.ToString();
            ddlPaymentTerms.SelectedValue = invoice.PaymentTermsId.ToString();
            txtRemarks.Text = invoice.Remarks;

            lblSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
            lblExpenses.Text = invoice.Expenses.ToDecimalFormat();
            lblDiscount.Text = invoice.Discount.ToDecimalFormat();
            lblGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();

            _lstLines = _invoice.GetProformaInvoiceLines(InvoiceId);

            //SettingsBLL setting = new SettingsBLL();
            //SystemPreferences preferences = setting.GetSystemPreferences(UserSession.CompanyId);
        }

        public List<ProformaInvoiceLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<ProformaInvoiceLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgProInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgProInvoice.DataSource = GetMainLines();
            }
        }

        protected void rgProInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgProInvoice_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgProInvoice.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    if (itemId == -1)
                    {
                        //item.Expanded = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void CreateSalesInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.CustomerId = UCCustomerList.CustomerId;
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();
            invoice.PurchaseOrder = txtCustomerPO.Text.ToTrimString();
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();

            string rMessage;
            var invoiceId = _salesinvoice.CreateSalesInvoiceFromProformaInvoice(invoice, InvoiceId, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", invoiceId), false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateSalesInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//
        private int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}


           
