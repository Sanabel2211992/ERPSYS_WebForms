using System;
using System.IO;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class Profile : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GetCompanyProfile();
        }

        private void GetCompanyProfile()
        {
            try
            {
                CompanyProfile company = _setting.GetCompanyProfile(UserSession.CompanyId);

                txtName.Text = company.Name;
                txtPhone.Text = company.Phone;
                txtFax.Text = company.Fax;
                txtEmail.Text = company.Email;
                txtWebsite.Text = company.WebSite;
                txtAddress1.Text = company.Address1;
                txtAddress2.Text = company.Address2;
                txtCity.Text = company.City;
                txtState.Text = company.State;
                txtCountry.Text = company.Country;
                txtPostalCode.Text = company.PostalCode;
                txtTaxNumber.Text = company.TaxNumber;

                if (company.PictureFileAttachmentName.Length > 0)
                {
                    LogoName = company.PictureFileAttachmentName;
                    string filename = company.PictureFileAttachmentName;
                    string relativePath = CommonMember.AttachmentSystemFolderPath;
                    imgLogo.ImageUrl = relativePath + filename;
                }
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateComapnyProfile()
        {
            CompanyProfile company = new CompanyProfile();

            if (!string.IsNullOrEmpty(TempLogoName))
            {
                string fileName = TempLogoName;
                string extension = Path.GetExtension(fileName);
                string id = Guid.NewGuid().ToString();
                string tempfileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), TempLogoName);
                string fileLocation = string.Format("{0}{1}{2}", Server.MapPath(CommonMember.AttachmentSystemFolderPath), id, extension);
                File.Copy(tempfileLocation, fileLocation);

                company.PictureFileAttachmentName = string.Format("{0}{1}", id, extension);
                company.PictureFileAttachmentData = ImageHandle.ImageToByte(fileLocation);
            }
            else if (!string.IsNullOrEmpty(LogoName))
            {
                company.PictureFileAttachmentName = LogoName;
                company.PictureFileAttachmentData = null; // don't update the logo attachment row 
            }

            company.CompanyId = UserSession.CompanyId;
            company.Name = txtName.Text;
            company.Phone = txtPhone.Text;
            company.Fax = txtFax.Text;
            company.Email = txtEmail.Text;
            company.WebSite = txtWebsite.Text;
            company.Address1 = txtAddress1.Text;
            company.Address2 = txtAddress2.Text;
            company.City = txtCity.Text;
            company.State = txtState.Text;
            company.Country = txtCountry.Text;
            company.PostalCode = txtPostalCode.Text;
            company.TaxNumber = txtTaxNumber.Text;
            company.PictureFileAttachmentId = 1;
            company.PictureFileAttachmentType = FileAttachmentTypes.Image;

            string rMessage;
            int i = _setting.UpdateCompanyProfile(company, out rMessage);

            if (i > 0)
            {
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("settings_company_update_success"));
            }
            else
            {
                AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("settings_company_update_failed"));
            }
        }

        private void UpdateLogoImage()
        {

            if (fuLogo.HasFile)
            {
                string filename = Path.GetFileName(fuLogo.PostedFile.FileName);
                string relativePath = CommonMember.AttachmentUploadTempFolderPath;
                fuLogo.SaveAs(Server.MapPath(relativePath + filename));
                TempLogoName = filename;
                imgLogo.ImageUrl = relativePath + filename;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateLogoImage();
                UpdateComapnyProfile();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ERP/main/home.aspx", false);
        }

        //************************************** Properties ************************************//

        private string TempLogoName
        {
            get { return ViewState["TempLogoName"] != null ? ViewState["TempLogoName"].ToString() : "";}
            set { ViewState["TempLogoName"] = value; }
        }

        private string LogoName
        {
            get { return ViewState["LogoName"] != null ? ViewState["LogoName"].ToString() : ""; }
            set { ViewState["LogoName"] = value; }
        }
    }
}