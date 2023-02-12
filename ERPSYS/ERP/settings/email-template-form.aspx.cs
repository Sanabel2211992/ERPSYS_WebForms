using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class EmailTemplateForm : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
                BindData();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                txtEmailBody.ToolsFile = CommonMember.EditorToolBarFilePath;
                txtEmailBody.CssFiles.Add(CommonMember.EditorCSSFilePath);
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
                    GetEmailTemplate(Request.QueryString["tid"].ToInt(), Request.QueryString["id"].ToInt());
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

        protected void GetEmailTemplate(int typeId, int templateId)
        {
            EmailTemplate template = _mail.GetEmailTemplate(typeId, templateId);

            if (template.TemplateId <= 0)
            {
                Response.Redirect(string.Format("email-template-list.aspx?e={0}", 1));
            }
            TemplateTypeId = template.TemplateTypeId;
            TemplateId = template.TemplateId;
            lblTemplateName.Text = template.Name;
            txtEmailSubject.Text = template.Subject;
            txtEmailBody.Content = template.Body;
            rblIsActive.SelectedValue = template.IsActive ? "true" : "false";
        }

        protected void UpdateEmailTemplate()
        {
            EmailTemplate template = new EmailTemplate();
            template.TemplateTypeId = TemplateTypeId;
            template.TemplateId = TemplateId;
            template.Subject = txtEmailSubject.Text.ToTrimString();
            template.Body = txtEmailBody.Content.ToTrimString();
            template.IsActive = rblIsActive.SelectedValue == "true";

            string rMessage;
            _mail.UpdateEmailTemplate(template, out rMessage);

            if (rMessage != string.Empty || TemplateId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("email-template-list.aspx?o={0}&tid={1}", 2, TemplateTypeId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateEmailTemplate();
            }

            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("email-template-list.aspx?tid={0}", TemplateTypeId), false);
        }

        //************************************** Properties ************************************//

        public int TemplateTypeId
        {
            get { return ViewState["TemplateTypeId"] != null ? ViewState["TemplateTypeId"].ToInt() : -1; }
            set { ViewState["TemplateTypeId"] = value; }
        }

        public int TemplateId
        {
            get { return ViewState["TemplateId"] != null ? ViewState["TemplateId"].ToInt() : -1; }
            set { ViewState["TemplateId"] = value; }
        }
    }
}