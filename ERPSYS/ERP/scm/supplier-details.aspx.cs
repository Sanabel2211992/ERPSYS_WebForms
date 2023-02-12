using System;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class SupplierDetails : System.Web.UI.Page
    {
        readonly SupplierBLL _supplier = new SupplierBLL();

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
                    GetSupplierDetails(Request.QueryString["id"].ToInt());
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
            ddlPaymentTerms.Items.Insert(0, new ListItem("--Select One--", "-1"));

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, new ListItem("--Select One--", "-1"));
        }

        protected void GetSupplierDetails(int supplierId)
        {
            Supplier supplier = _supplier.GetSupplier(supplierId);

            if (supplier.SupplierId <= 0)
            {
                Response.Redirect(string.Format("supplier-list.aspx?e={0}", 1));
            }

            SupplierId = supplier.SupplierId;
            txtSupplierName.Text =  supplier.Name;
            txtSupplierNameAr.Text = supplier.NameAr;
            txtRemarks.Text = supplier.Remarks;
            ddlPaymentTerms.SelectedValue = supplier.DefaultPaymentTermsId.ToString();
            txtAddress1.Text = supplier.Address1;
            txtCity.Text = supplier.City;
            //txtState.Text = supplier.State;
            txtCountry.Text = supplier.Country;
            txtPostalCode.Text = supplier.PostalCode;
            txtContactName.Text = supplier.ContactName;
            txtPhone.Text = supplier.Phone;
            txtFax.Text = supplier.Fax;
            txtEmail.Text =  supplier.Email;
            cbIsActive.Checked = supplier.IsActive;
            ddlCurrency.SelectedValue = supplier.CurrencyId.ToString();
        }

        protected void AddSupplier()
        {
            Supplier supplier = new Supplier();

            supplier.SupplierId = SupplierId;
            supplier.Name = txtSupplierName.Text.ToTrimString();
            supplier.NameAr = txtSupplierNameAr.Text.ToTrimString();
            supplier.Remarks = txtRemarks.Text.ToTrimString();
            supplier.DefaultPaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            supplier.Address1 = txtAddress1.Text.ToTrimString();
            supplier.City = txtCity.Text.ToTrimString();
            //supplier.State = txtState.Text.ToTrimString();
            supplier.Country = txtCountry.Text.ToTrimString();
            supplier.PostalCode = txtPostalCode.Text.ToTrimString();
            supplier.ContactName = txtContactName.Text.ToTrimString();
            supplier.Phone = txtPhone.Text.ToTrimString();
            supplier.Fax = txtFax.Text.ToTrimString();
            supplier.Email =txtEmail.Text.ToTrimString();
            supplier.IsActive = cbIsActive.Checked;
            supplier.CurrencyId = ddlCurrency.SelectedValue.ToInt();
           
            string rMessage;
            int supplierId  =_supplier.AddSupplier(supplier, out rMessage);

            if (rMessage != string.Empty || supplierId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("supplier-view.aspx?o=1&id={0}", supplierId), false);
        }

        protected void UpdateSupplier()
        {
            Supplier supplier = new Supplier();

            supplier.SupplierId = SupplierId;
            supplier.Name = txtSupplierName.Text.ToTrimString();
            supplier.NameAr = txtSupplierNameAr.Text.ToTrimString();
            supplier.Remarks = txtRemarks.Text.ToTrimString();
            supplier.DefaultPaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            supplier.Address1 = txtAddress1.Text.ToTrimString();
            supplier.City = txtCity.Text.ToTrimString();
            //supplier.State = txtState.Text.ToTrimString();
            supplier.Country = txtCountry.Text.ToTrimString();
            supplier.PostalCode = txtPostalCode.Text.ToTrimString();
            supplier.ContactName = txtContactName.Text.ToTrimString();
            supplier.Phone = txtPhone.Text.ToTrimString();
            supplier.Fax = txtFax.Text.ToTrimString();
            supplier.Email = txtEmail.Text.ToTrimString();
            supplier.IsActive = cbIsActive.Checked;
            supplier.CurrencyId = ddlCurrency.SelectedValue.ToInt();

            string rMessage;
            _supplier.UpdateSupplier(supplier, out rMessage);

            if (rMessage != string.Empty || SupplierId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("supplier-view.aspx?o=2&id={0}", SupplierId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!IsValid)
                    return;

                if(Operation == "new")
                {
                    AddSupplier();
                }
                else if (Operation == "edit" && SupplierId > 0)
                {
                    UpdateSupplier();
                }
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("supplier-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int SupplierId
        {
            get { return ViewState["SupplierId"] != null ? ViewState["SupplierId"].ToInt() : -1; }
            set { ViewState["SupplierId"] = value; }
        }
    }
}