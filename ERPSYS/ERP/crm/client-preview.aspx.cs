using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Drawing;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.crm
{
    public partial class ClientPreview : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

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
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("contact_id_not_exist"));
                        break;

                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("client_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("client_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("contact_add_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("contact_update_success"));
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
                    GetClientView(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("client-list.aspx?e={0}", 1));
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

        protected void GetClientView(int clientId)
        {
            Client client = _client.GetClient(clientId);

            if (client.ClientId <= 0)
            {
                Response.Redirect(string.Format("client-list.aspx?e={0}", 1));
            }

            ClientId = client.ClientId;
            lblClientName.Text = client.Name;
            lblAddress.Text = client.Address.ReplaceWhenNullOrEmpty("N/A");
            lblCity.Text = client.City.ReplaceWhenNullOrEmpty("N/A");
            lblCountry.Text = client.Country.ReplaceWhenNullOrEmpty("N/A");
            lblPostalCode.Text = client.PostalCode.ReplaceWhenNullOrEmpty("N/A");
            lblPhone.Text = client.Phone.ReplaceWhenNullOrEmpty("N/A");
            lblMobile.Text = client.Mobile.ReplaceWhenNullOrEmpty("N/A");
            lblFax.Text = client.Fax.ReplaceWhenNullOrEmpty("N/A");
            lblEmail.Text = client.Email.ReplaceWhenNullOrEmpty("N/A");
            lblWebsite.Text = client.WebSite.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = client.IsActive ? "Active" : "InActive";
            lblRemarks.Text = client.Remarks.ReplaceWhenNullOrEmpty("N/A");

            lblStatus.Text = client.IsActive ? "Active" : "Inactive";

            if (client.IsActive)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font.Bold = true;
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font.Bold = true;
            }
            GetContactList();
        }

        private void GetContactList()
        {
            try
            {
                rgContactList.DataSource = _client.GetContactList(ClientId, "");
                rgContactList.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void DeleteContact(int contactId)
        {
            try
            {
                string rMessage;
                _client.DeleteContact(contactId, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                }

                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("contact_delete_success"));
            }

            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (button.CommandName.ToString() == "delete")
            {
                DeleteContact(button.CommandArgument.ToInt());
                GetContactList();
            }
        }

        protected void rgContactList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgContactList.DataSource = _client.GetContactList(ClientId, "");
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("contact-form.aspx?n=new&id={0}", ClientId), false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("client-form.aspx?o=edit&id={0}", ClientId), false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("client-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        public int ClientId
        {
            get { return ViewState["ClientId"] != null ? ViewState["ClientId"].ToInt() : -1; }
            set { ViewState["ClientId"] = value; }
        }
    }
}