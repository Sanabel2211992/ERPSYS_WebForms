using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.customer
{
    public partial class CustomerView : System.Web.UI.Page
    {
        readonly CustomerBLL _customer = new CustomerBLL();

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
                 if (Request.QueryString["o"] == "1") // customer add 
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("customer_add_success"));
                }
                else if (Request.QueryString["o"] == "2") // customer update
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("customer_update_success"));
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
                    GetCustomerView(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("customer-list.aspx?e={0}", 1));
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

        protected void GetCustomerView(int customerId)
        {
            Customer customer = _customer.GetCustomer(customerId);

            if (customer.CustomerId <= 0)
            {
                Response.Redirect(string.Format("customer-list.aspx?e={0}", 1));
            }

            CustomerId = customer.CustomerId;
            lblCustomerName.Text = customer.Name;
            lblCustomerNameAr.Text = customer.NameAr.ReplaceWhenNullOrEmpty("N/A");
            lblPaymentMethod.Text = customer.DefaultPaymentMethod.ReplaceWhenNullOrEmpty("N/A");
            lblPaymentTerms.Text = customer.DefaultPaymentTerms.ReplaceWhenNullOrEmpty("N/A");
            lblAddress1.Text = customer.Address1.ReplaceWhenNullOrEmpty("N/A");
            lblAddress2.Text = customer.Address2.ReplaceWhenNullOrEmpty("N/A");
            lblCity.Text = customer.City.ReplaceWhenNullOrEmpty("N/A");
            lblState.Text = customer.State.ReplaceWhenNullOrEmpty("N/A");
            lblCountry.Text = customer.Country.ReplaceWhenNullOrEmpty("N/A");
            lblPostalCode.Text = customer.PostalCode.ReplaceWhenNullOrEmpty("N/A");
            lblContact.Text = customer.ContactName.ReplaceWhenNullOrEmpty("N/A");
            lblPhone.Text = customer.Phone.ReplaceWhenNullOrEmpty("N/A");
            lblFax.Text = customer.Fax.ReplaceWhenNullOrEmpty("N/A");
            lblEmail.Text = customer.Email.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = customer.IsActive ? "Active" : "InActive";
            lblRemarks.Text = customer.Remarks.ReplaceWhenNullOrEmpty("N/A");
        }
       
        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
            Response.Redirect(string.Format("customer-list.aspx"), false);
                    break;
                case "edit":
            Response.Redirect(string.Format("customer-details.aspx?o=edit&id={0}", CustomerId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int CustomerId
        {
            get { return ViewState["CustomerId"] != null ? ViewState["CustomerId"].ToInt() : -1; }
            set { ViewState["CustomerId"] = value; }
        }
    }
}