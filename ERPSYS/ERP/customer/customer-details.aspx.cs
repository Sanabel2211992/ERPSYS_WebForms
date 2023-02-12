using System;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.customer
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        readonly CustomerBLL _customer = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                GetItemLookupTables();

                if(Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetCustomerDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
            ddlPaymentTerms.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();
            ddlPaymentMethod.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetCustomerDetails(int customerId)
        {
            Customer customer = _customer.GetCustomer(customerId);

            if (customer.CustomerId <= 0)
            {
                Response.Redirect(string.Format("customer-list.aspx?e={0}", 1));
            }

            CustomerId = customer.CustomerId;
            txtCustomerName.Text =  customer.Name;
            txtCustomerNameAr.Text = customer.NameAr;
            txtRemarks.Text = customer.Remarks;
            ddlPaymentMethod.SelectedValue = customer.DefaultPaymentMethodId.ToString();
            ddlPaymentTerms.SelectedValue = customer.DefaultPaymentTermsId.ToString();
            txtAddress1.Text = customer.Address1;
            txtAddress2.Text = customer.Address2;
            txtCity.Text = customer.City;
            txtState.Text = customer.State;
            txtCountry.Text = customer.Country;
            txtPostalCode.Text = customer.PostalCode;
            txtContactName.Text = customer.ContactName;
            txtPhone.Text = customer.Phone;
            txtFax.Text = customer.Fax;
            txtEmail.Text =  customer.Email;
            cbIsActive.Checked = customer.IsActive;
        }

        protected void AddCustomer()
        {
            Customer customer = new Customer();

            customer.CustomerId = CustomerId;
            customer.Name = txtCustomerName.Text.ToTrimString();
            customer.NameAr = txtCustomerNameAr.Text.ToTrimString();
            customer.Remarks = txtRemarks.Text.ToTrimString();
            customer.DefaultPaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            customer.DefaultPaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            customer.Address1 = txtAddress1.Text.ToTrimString();
            customer.Address2 = txtAddress2.Text.ToTrimString();
            customer.City = txtCity.Text.ToTrimString();
            customer.State = txtState.Text.ToTrimString();
            customer.Country = txtCountry.Text.ToTrimString();
            customer.PostalCode = txtPostalCode.Text.ToTrimString();
            customer.ContactName = txtContactName.Text.ToTrimString();
            customer.Phone = txtPhone.Text.ToTrimString();
            customer.Fax = txtFax.Text.ToTrimString();
            customer.Email =txtEmail.Text.ToTrimString();
            customer.IsActive = cbIsActive.Checked;

            string rMessage;
            int customerId =_customer.AddCustomer(customer, out rMessage);


            if (rMessage != string.Empty || customerId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("customer-view.aspx?o={0}&id={1}", 1, customerId), false);
        }

        protected void UpdateCustomer()
        {
            Customer customer = new Customer();

            customer.CustomerId = CustomerId;
            customer.Name = txtCustomerName.Text.ToTrimString();
            customer.NameAr = txtCustomerNameAr.Text.ToTrimString();
            customer.Remarks = txtRemarks.Text.ToTrimString();
            customer.DefaultPaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            customer.DefaultPaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            customer.Address1 = txtAddress1.Text.ToTrimString();
            customer.Address2 = txtAddress2.Text.ToTrimString();
            customer.City = txtCity.Text.ToTrimString();
            customer.State = txtState.Text.ToTrimString();
            customer.Country = txtCountry.Text.ToTrimString();
            customer.PostalCode = txtPostalCode.Text.ToTrimString();
            customer.ContactName = txtContactName.Text.ToTrimString();
            customer.Phone = txtPhone.Text.ToTrimString();
            customer.Fax = txtFax.Text.ToTrimString();
            customer.Email =txtEmail.Text.ToTrimString();
            customer.IsActive = cbIsActive.Checked;

            string rMessage;
            _customer.UpdateCustomer(customer, out rMessage);

            if (rMessage != string.Empty || CustomerId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("customer-view.aspx?o={0}&id={1}", 2, CustomerId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!IsValid)
                    return;

                if(Operation == "new")
                {
                    AddCustomer();
                }
                else if (Operation == "edit" && CustomerId > 0)
                {
                    UpdateCustomer();
                }
            }

            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("customer-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int CustomerId
        {
            get { return ViewState["CustomerId"] != null ? ViewState["CustomerId"].ToInt() : -1; }
            set { ViewState["CustomerId"] = value; }
        }
    }
}