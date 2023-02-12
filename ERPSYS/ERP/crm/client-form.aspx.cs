using System;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.crm
{
    public partial class ClientForm : System.Web.UI.Page
    {
        readonly CRMBLL _crm = new CRMBLL();
        readonly CustomerBLL _customer = new CustomerBLL();

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
                //pnlFill.Visible = false;
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetClientDetails(Request.QueryString["id"].ToInt());
                    lnkbtnFill.Visible = false;
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

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCustomerName.DataTextField = "Name";
            ddlCustomerName.DataValueField = "CustomerId";
            ddlCustomerName.DataSource = lookup.GetCustomer();
            ddlCustomerName.DataBind();
            ddlCustomerName.Items.Insert(0, new ListItem("-- Select Customer --", "-1"));
        }

        protected void GetClientDetails(int clientId)
        {
            Client client = _crm.GetClient(clientId);

            if (client.ClientId <= 0)
            {
                Response.Redirect(string.Format("client-list.aspx?e={0}", 1));
            }

            ClientId = client.ClientId;
            txtClientName.Text = client.Name;
            txtRemarks.Text = client.Remarks;
            txtAddress.Text = client.Address;
            txtCity.Text = client.City;
            txtCountry.Text = client.Country;
            txtPostalCode.Text = client.PostalCode;
            txtPhone.Text = client.Phone;
            txtMobile.Text = client.Mobile;             
            txtFax.Text = client.Fax;
            txtEmail.Text = client.Email;
            txtWebsite.Text = client.WebSite;
            cbIsActive.Checked = client.IsActive;
        }

        protected void AddClient()
        {
            Client client = new Client();

            client.Name = txtClientName.Text.ToTrimString();
            client.Remarks = txtRemarks.Text.ToTrimString();
            client.Address = txtAddress.Text.ToTrimString();
            client.City = txtCity.Text.ToTrimString();
            client.Country = txtCountry.Text.ToTrimString();
            client.PostalCode = txtPostalCode.Text.ToTrimString();
            client.Phone = txtPhone.Text.ToTrimString();
            client.Mobile = txtMobile.Text;
            client.Fax = txtFax.Text.ToTrimString();
            client.Email = txtEmail.Text.ToTrimString();
            client.IsActive = cbIsActive.Checked;
            client.WebSite = txtWebsite.Text.ToTrimString();

            string rMessage;
            int clientId = _crm.AddClient(client, out rMessage);

            if (rMessage != string.Empty || clientId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("client-preview.aspx?o={0}&id={1}", 1, clientId), false);
        }

        protected void UpdateClient()
        {
            Client client = new Client();

            client.ClientId = ClientId;
            client.Name = txtClientName.Text.ToTrimString();
            client.Remarks = txtRemarks.Text.ToTrimString();
            client.Address = txtAddress.Text.ToTrimString();
            client.City = txtCity.Text.ToTrimString();
            client.Country = txtCountry.Text.ToTrimString();
            client.PostalCode = txtPostalCode.Text.ToTrimString();
            client.Phone = txtPhone.Text.ToTrimString();
            client.Mobile = txtMobile.Text;
            client.Fax = txtFax.Text.ToTrimString();
            client.Email = txtEmail.Text.ToTrimString();
            client.IsActive = cbIsActive.Checked;
            client.WebSite = txtWebsite.Text.ToTrimString();

            string rMessage;
            _crm.UpdateClient(client, out rMessage);

            if (rMessage != string.Empty || ClientId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("client-preview.aspx?o={0}&id={1}", 2, ClientId), false);
        }

        protected void btnFill_Click(object sender, EventArgs e)
        {
            int CustemerId = ddlCustomerName.SelectedValue.ToInt();

            Customer custemer = _customer.GetCustomer(CustemerId);

            txtClientName.Text = custemer.Name;
            txtRemarks.Text = custemer.Remarks;
            txtAddress.Text = custemer.Address1;
            txtCity.Text = custemer.City;
            txtCountry.Text = custemer.Country;
            txtPostalCode.Text = custemer.PostalCode;
            txtPhone.Text = custemer.Phone;
            txtFax.Text = custemer.Fax;
            txtEmail.Text = custemer.Email;
            txtWebsite.Text = custemer.WebSite;
            cbIsActive.Checked = custemer.IsActive;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddClient();
                }
                else if (Operation == "edit" && ClientId > 0)
                {
                    UpdateClient();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ClientId >= 1)
            {
                Response.Redirect(string.Format("client-preview.aspx?id=" + ClientId), false);
            }
            else
            {
                Response.Redirect(string.Format("client-list.aspx"), false);
            }
        }

        protected void lnkbtnFill_Click(object sender, EventArgs e)
        {
            pnlFill.Visible = true;
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int ClientId
        {
            get { return ViewState["ClientId"] != null ? ViewState["ClientId"].ToInt() : -1; }
            set { ViewState["ClientId"] = value; }
        } 
    }
}