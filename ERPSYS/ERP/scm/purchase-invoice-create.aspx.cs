using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoiceCreate : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

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
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();

            ddlCurrency.SelectedValue = UserSession.CurrencyId.ToString();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "Locationid";
            ddlLocation.DataSource = lookup.GetPurchaseInvoiceLocation();
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        void CreatePurchaseInvoice()
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

            purchaseInvoice.InvoiceDate = UCDate.DateValue;
            purchaseInvoice.SupplierId = UCSupplier.SupplierId;
            purchaseInvoice.SupplierName = UCSupplier.SupplierName;
            purchaseInvoice.PurchaseOrderNumber = txtPurchaseOrderNumber.Text.ToTrimString();
            purchaseInvoice.SupplierInvoiceNumber = txtSupplierInvoice.Text.ToTrimString();
            purchaseInvoice.LocationId = ddlLocation.SelectedValue.ToInt();
            purchaseInvoice.CurrencyId = ddlCurrency.SelectedValue.ToInt();
            purchaseInvoice.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var invoiceId = _scm.CreatePurchaseInvoice(purchaseInvoice, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("purchase-invoice-form.aspx?id={0}", invoiceId));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreatePurchaseInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("purchase-invoice-list.aspx"));
        }
    }
}