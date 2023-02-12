using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class TicketSettingsForm : System.Web.UI.Page
    {
        readonly TicketBLLx _ticket = new TicketBLLx();
        readonly LookupBLL _lookup = new LookupBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetItemLookupTables();
                BindData();
            }
        }

        protected void GetItemLookupTables()
        {
            try
            {
                ddlSystemEmail.DataTextField = "EmailDisplayName";
                ddlSystemEmail.DataValueField = "EmailId";
                ddlSystemEmail.DataSource = _lookup.GetEmailSettings();
                ddlSystemEmail.DataBind();
                ddlSystemEmail.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            GetTicketSettings();
        }

        private void GetTicketSettings()
        {
            try
            {
                TicketSettings settings = _ticket.GetTicketSettings();

                txtURL.Text = settings.URL;
                txtSiteName.Text = settings.SiteName;
                ddlSystemEmail.SelectedValue = settings.EmailId.ToString();
                txtToAddress.Text = settings.ToMail;
                txtCCAddress.Text = settings.CcMail;
                txtBCCAddress.Text = settings.BccMail;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void UpdateTicketSettings()
        {
            TicketSettings settings = new TicketSettings();

            settings.URL = txtURL.Text.ToTrimString();
            settings.SiteName = txtSiteName.Text.ToTrimString();
            settings.EmailId = ddlSystemEmail.SelectedValue.ToInt();
            settings.ToMail = txtToAddress.Text.ToTrimString();
            settings.CcMail = txtCCAddress.Text.ToTrimString();
            settings.BccMail = txtBCCAddress.Text.ToTrimString();


            string rMessage;
            _ticket.UpdateTicketSettings(settings, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("ticket_settings_update_success"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateTicketSettings();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}