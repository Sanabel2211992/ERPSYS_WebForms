using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.scm
{
    public partial class SupplierView : System.Web.UI.Page
    {
        readonly SupplierBLL _supplier = new SupplierBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                BindData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("supplier_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("supplier_update_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSupplierView(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("supplier-list.aspx?e={0}", 1));
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

        protected void GetSupplierView(int supplierId)
        {
            Supplier supplier = _supplier.GetSupplier(supplierId);

            if (supplier.SupplierId <= 0)
            {
                Response.Redirect(string.Format("supplier-list.aspx?e={0}", 1));
            }

            SupplierId = supplier.SupplierId;
            lblSupplierName.Text = supplier.Name;
            lblSupplierNameAr.Text = supplier.NameAr.ReplaceWhenNullOrEmpty("N/A");
            lblPaymentTerms.Text = supplier.DefaultPaymentTerms;
            lblAddress1.Text = supplier.Address1.ReplaceWhenNullOrEmpty("N/A");
            //lblAddress2.Text = supplier.Address2.ReplaceWhenNullOrEmpty("N/A");
            lblCity.Text = supplier.City.ReplaceWhenNullOrEmpty("N/A");
            //lblState.Text = supplier.State.ReplaceWhenNullOrEmpty("N/A");
            lblCountry.Text = supplier.Country.ReplaceWhenNullOrEmpty("N/A");
            lblPostalCode.Text = supplier.PostalCode.ReplaceWhenNullOrEmpty("N/A");
            lblContact.Text = supplier.ContactName.ReplaceWhenNullOrEmpty("N/A");
            lblPhone.Text = supplier.Phone.ReplaceWhenNullOrEmpty("N/A");
            lblFax.Text = supplier.Fax.ReplaceWhenNullOrEmpty("N/A");
            lblEmail.Text = supplier.Email.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = supplier.IsActive ? "Active" : "Inactive";
            lblCurrency.Text = supplier.CurrencyCode;
            lblRemarks.Text = supplier.Remarks.ReplaceWhenNullOrEmpty("N/A");
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
            Response.Redirect(string.Format("supplier-list.aspx"), false);
                    break;
                case "edit":
            Response.Redirect(string.Format("supplier-details.aspx?o=edit&id={0}", SupplierId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int SupplierId
        {
            get { return ViewState["SupplierId"] != null ? ViewState["SupplierId"].ToInt() : -1; }
            set { ViewState["SupplierId"] = value; }
        }
    }
}