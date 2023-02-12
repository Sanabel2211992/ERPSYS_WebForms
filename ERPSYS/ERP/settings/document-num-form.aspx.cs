using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class DocumentNumForm : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

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
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetDocInformation(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("document-num.aspx?e={0}", 1), false);
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

        protected void GetDocInformation(int docTypeId)
        {
            DocumentClass doc = _setting.GetDocInformation(docTypeId);

            if (doc.DocTypeId <= 0)
            {
                Response.Redirect(string.Format("document-num.aspx?e={0}", 1));
            }

            DocTypeId = docTypeId;
            lblDocumentName.Text = doc.Name;
            txtNextNumber.Text = doc.NextNumber.ToString();
            txtMinDigits.Text = doc.MinDigits.ToString();
            txtPrefix.Text = doc.Prefix;
            txtSuffix.Text = doc.Suffix;
        }

        protected void UpdateDocInformaion()
        {
            DocumentClass doc = new DocumentClass();

            doc.DocTypeId = DocTypeId;
            doc.NextNumber = txtNextNumber.Text.ToInt();
            doc.MinDigits = txtMinDigits.Text.ToInt();
            doc.Prefix = txtPrefix.Text.ToTrimString();
            doc.Suffix = txtSuffix.Text.ToTrimString();

            string rMessage;
            _setting.UpdateDocInformaion(doc, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("document-num.aspx?o={0}", 1), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "edit" && DocTypeId > 0)
                {
                    UpdateDocInformaion();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("document-num.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int DocTypeId
        {
            get { return ViewState["DocTypeId"] != null ? ViewState["DocTypeId"].ToInt() : -1; }
            set { ViewState["DocTypeId"] = value; }
        }
    }
}