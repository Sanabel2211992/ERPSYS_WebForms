using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.crm
{
    public partial class ContactForm : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GetLookupContactTypeTables();
            if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                Operation = "edit";
                GetContactDetails(Request.QueryString["id"].ToInt());
            }
            else if (Request.QueryString["n"] == "new" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                Operation = "new";
                ClientId = Request.QueryString["id"].ToInt();
            }
        }

        protected void GetLookupContactTypeTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "ContactTypeId";
            ddlType.DataSource = lookup.ContactType();
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("-- Select Unit --", "-1"));
        }

        protected void GetContactDetails(int contactId)
        {
            Contact contact = _client.GetContact(contactId);

            if (contact.ContactId <= 0)
            {
                Response.Redirect(string.Format("client-preview.aspx?e={0}", 1));
            }
            ClientId = contact.ClientId;
            ContactId = contact.ContactId;
            txtContactName.Text = contact.Name;
            txtJobTitle.Text = contact.JobTitle;
            ddlNameTitle.SelectedValue = contact.NameTitle;
            ddlType.SelectedValue = contact.ContactTypeId.ToString();
            txtRemarks.Text = contact.Remarks;
            txtAddress.Text = contact.Address;
            txtCity.Text = contact.City;
            txtCountry.Text = contact.Country;
            txtPostalCode.Text = contact.PostalCode;
            txtPhone.Text = contact.Phone;
            txtMobile.Text = contact.Mobile;
            txtFax.Text = contact.Fax;
            txtEmail1.Text = contact.Email1;
            txtEmail2.Text = contact.Email2;
            cbIsActive.Checked = contact.IsActive;
        }

        protected void AddContact()
        {
            Contact contact = new Contact();

            contact.ClientId = ClientId;
            contact.Name = txtContactName.Text.ToTrimString();
            contact.NameTitle = ddlNameTitle.SelectedValue.ToString();
            contact.JobTitle = txtJobTitle.Text.ToTrimString();
            contact.ContactTypeId = ddlType.Text.ToInt();
            contact.City = txtCity.Text.ToTrimString();
            contact.Country = txtCountry.Text.ToTrimString();
            contact.Address = txtAddress.Text.ToTrimString();
            contact.PostalCode = txtPostalCode.Text.ToTrimString();
            contact.Phone = txtPhone.Text.ToTrimString();
            contact.Mobile = txtMobile.Text.ToTrimString();
            contact.Fax = txtFax.Text.ToTrimString();
            contact.Email1 = txtEmail1.Text.ToTrimString();
            contact.Email2 = txtEmail2.Text.ToTrimString();
            contact.IsActive = cbIsActive.Checked;
            contact.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            int contactId = _client.AddContact(contact, out rMessage);

            if (rMessage != string.Empty || contactId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("client-preview.aspx?o={0}&id={1}", 3, ClientId), false);
        }

        protected void UpdateContact()
        {
            Contact contact = new Contact();

            contact.ContactId = ContactId;
            contact.ClientId = ClientId;
            contact.Name = txtContactName.Text.ToTrimString();
            contact.NameTitle = ddlNameTitle.SelectedValue.ToString();
            contact.JobTitle = txtJobTitle.Text.ToString();
            contact.ContactTypeId = ddlType.Text.ToInt();
            contact.City = txtCity.Text.ToTrimString();
            contact.Country = txtCountry.Text.ToTrimString();
            contact.Address = txtAddress.Text.ToTrimString();
            contact.PostalCode = txtPostalCode.Text.ToTrimString();
            contact.Phone = txtPhone.Text.ToTrimString();
            contact.Mobile = txtMobile.Text;
            contact.Fax = txtFax.Text.ToTrimString();
            contact.Email1 = txtEmail1.Text.ToTrimString();
            contact.Email2 = txtEmail2.Text.ToTrimString();
            contact.IsActive = cbIsActive.Checked;
            contact.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _client.UpdateContact(contact, out rMessage);

            if (rMessage != string.Empty || ContactId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("client-preview.aspx?o={0}&id={1}", 4, ClientId), false);
        }

        protected void btnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {

                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddContact();
                }
                else if (Operation == "edit" && ContactId > 0)
                {
                    UpdateContact();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
             Response.Redirect(string.Format("client-preview.aspx?id=" + ClientId), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int ContactId
        {
            get { return ViewState["ContactId"] != null ? ViewState["ContactId"].ToInt() : -1; }
            set { ViewState["ContactId"] = value; }
        }

        public int ClientId
        {
            get { return ViewState["ClientId"] != null ? ViewState["ClientId"].ToInt() : -1; }
            set { ViewState["ClientId"] = value; }
        }
    }
}