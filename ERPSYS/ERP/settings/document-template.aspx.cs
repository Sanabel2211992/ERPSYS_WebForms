using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class DocumentTemplate : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

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
                LookupBLL lookup = new LookupBLL();

                ddlCompanyCode.DataTextField = "Code";
                ddlCompanyCode.DataValueField = "CompanyId";
                ddlCompanyCode.DataSource = lookup.GetSystemCompanyCode();
                ddlCompanyCode.DataBind();

                ddlCompanyCode.SelectedValue = UserSession.CompanyId.ToString();

                ddlDocumentTypes.DataTextField = "Name";
                ddlDocumentTypes.DataValueField = "DocTypeId";
                ddlDocumentTypes.DataSource = lookup.GetDocumentTypes();
                ddlDocumentTypes.DataBind();

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompanyCode.SelectedValue.ToInt() > 0)
            {
                GetTemplate();
            }
        }

        protected void ddlDocumentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDocumentTypes.SelectedValue.ToInt() > 0)
            {
                GetTemplate();
            }
        }

        protected void GetTemplate()
        {
            try
            {
                int companyId = ddlCompanyCode.SelectedValue.ToInt();
                int docTypeId = ddlDocumentTypes.SelectedValue.ToInt();

                DocumentTemplateClass doc = _setting.GetDocumentTemplate(companyId, docTypeId);

                txtRemark1.Text = doc.Remark1;
                txtRemark2.Text = doc.Remark2;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateTemplate()
        {
            DocumentTemplateClass doc = new DocumentTemplateClass();

            doc.CompanyId = ddlCompanyCode.SelectedValue.ToInt();
            doc.DocTypeId = ddlDocumentTypes.SelectedValue.ToInt();
            doc.Remark1 = txtRemark1.Text.ToTrimString();
            doc.Remark2 = txtRemark2.Text.ToTrimString();

            string rMessage;
            _setting.UpdateDocumentTemplate(doc, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                AppNotification.MessageBoxSuccess("Opertaion has been updated successfully");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateTemplate();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}