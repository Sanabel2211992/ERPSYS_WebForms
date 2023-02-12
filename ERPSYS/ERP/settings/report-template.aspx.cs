using System;
using System.IO;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ReportTemplate : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLookupTables();
            }
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCompanyList.DataTextField = "Name";
            ddlCompanyList.DataValueField = "CompanyId";
            ddlCompanyList.DataSource = lookup.GetSystemCompanay();
            ddlCompanyList.DataBind();
            ddlCompanyList.SelectedValue = UserSession.CompanyId.ToString();

            GetCompanyPrintTempalte(ddlCompanyList.SelectedValue.ToInt());
        }

        protected void ddlCompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = ddlCompanyList.SelectedValue.ToInt();

            if (companyId > 0)
            {
                GetCompanyPrintTempalte(companyId);
            }
        }

        private void GetCompanyPrintTempalte(int companyId)
        {
            try
            {
                CompanyPrintTemplate companyTemplate = _setting.GetCompanyPrintReportTemplate(companyId);

                string relativePath = CommonMember.SystemPrintFolderPath;
                imgHeaderRight.ImageUrl = relativePath + companyTemplate.HeaderRightImageName;
                imgHeaderCenter.ImageUrl = relativePath + companyTemplate.HeaderCenterImageName;
                imgHeaderLeft.ImageUrl = relativePath + companyTemplate.HeaderLeftImageName;
                imgFooter.ImageUrl = relativePath + companyTemplate.FooterImageName;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnUploadHeaderRight_Click(object sender, EventArgs e)
        {
            if (!fuHeaderRight.HasFile)
            {
                AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                return;
            }

            string filename = Path.GetFileName(fuHeaderRight.PostedFile.FileName);
            string relativePath = CommonMember.AttachmentUploadTempFolderPath;
            fuHeaderRight.SaveAs(Server.MapPath(relativePath + filename));
            TempHeaderRightName = filename;
            imgHeaderRight.ImageUrl = relativePath + filename;
        }

        protected void btnSubmitHeaderRight_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TempHeaderRightName))
            {
                string fileName = TempHeaderRightName;
                string extension = Path.GetExtension(fileName);
                string id = Guid.NewGuid().ToString();
                string tempfileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), TempHeaderRightName);
                string fileLocation = string.Format("{0}{1}{2}", Server.MapPath(CommonMember.SystemPrintFolderPath), id, extension);
                File.Copy(tempfileLocation, fileLocation);

                string pictureFileName = string.Format("{0}{1}", id, extension);

                UpdatePrintTemplate(1, pictureFileName);
            }
        }

        protected void btnRemoveHeaderRight_Click(object sender, EventArgs e)
        {
            DeletePrintTemplate(1);
        }

        protected void btnUploadHeaderCenter_Click(object sender, EventArgs e)
        {
            if (!fuHeaderCenter.HasFile)
            {
                AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                return;
            }

            string filename = Path.GetFileName(fuHeaderCenter.PostedFile.FileName);
            string relativePath = CommonMember.AttachmentUploadTempFolderPath;
            fuHeaderCenter.SaveAs(Server.MapPath(relativePath + filename));
            TempHeaderCenterName = filename;
            imgHeaderCenter.ImageUrl = relativePath + filename;
        }

        protected void btnSubmitHeaderCenter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TempHeaderCenterName))
            {
                string fileName = TempHeaderCenterName;
                string extension = Path.GetExtension(fileName);
                string id = Guid.NewGuid().ToString();
                string tempfileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), TempHeaderCenterName);
                string fileLocation = string.Format("{0}{1}{2}", Server.MapPath(CommonMember.SystemPrintFolderPath), id, extension);
                File.Copy(tempfileLocation, fileLocation);

                string pictureFileName = string.Format("{0}{1}", id, extension);

                UpdatePrintTemplate(2, pictureFileName);
            }
        }

        protected void btnRemoveHeaderCenter_Click(object sender, EventArgs e)
        {
            DeletePrintTemplate(2);
        }

        protected void btnUploadHeaderLeft_Click(object sender, EventArgs e)
        {
            if (!fuHeaderLeft.HasFile)
            {
                AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                return;
            }

            string filename = Path.GetFileName(fuHeaderLeft.PostedFile.FileName);
            string relativePath = CommonMember.AttachmentUploadTempFolderPath;
            fuHeaderLeft.SaveAs(Server.MapPath(relativePath + filename));
            TempHeaderLeftName = filename;
            imgHeaderLeft.ImageUrl = relativePath + filename;
        }

        protected void btnSubmitHeaderLeft_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TempHeaderLeftName))
            {
                string fileName = TempHeaderLeftName;
                string extension = Path.GetExtension(fileName);
                string id = Guid.NewGuid().ToString();
                string tempfileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), TempHeaderLeftName);
                string fileLocation = string.Format("{0}{1}{2}", Server.MapPath(CommonMember.SystemPrintFolderPath), id, extension);
                File.Copy(tempfileLocation, fileLocation);

                string pictureFileName = string.Format("{0}{1}", id, extension);

                UpdatePrintTemplate(3, pictureFileName);
            }
        }

        protected void btnRemoveHeaderLeft_Click(object sender, EventArgs e)
        {
            DeletePrintTemplate(3);
        }

        protected void btnUploadFooter_Click(object sender, EventArgs e)
        {
            if (!fuFooter.HasFile)
            {
                AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                return;
            }

            string filename = Path.GetFileName(fuFooter.PostedFile.FileName);
            string relativePath = CommonMember.AttachmentUploadTempFolderPath;
            fuFooter.SaveAs(Server.MapPath(relativePath + filename));
            TempFooterName = filename;
            imgFooter.ImageUrl = relativePath + filename;
        }

        protected void btnSubmitFooter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TempFooterName))
            {
                string fileName = TempFooterName;
                string extension = Path.GetExtension(fileName);
                string id = Guid.NewGuid().ToString();
                string tempfileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), TempFooterName);
                string fileLocation = string.Format("{0}{1}{2}", Server.MapPath(CommonMember.SystemPrintFolderPath), id, extension);
                File.Copy(tempfileLocation, fileLocation);

                string pictureFileName = string.Format("{0}{1}", id, extension);

                UpdatePrintTemplate(4, pictureFileName);
            }
        }

        protected void btnRemoveFooter_Click(object sender, EventArgs e)
        {
            DeletePrintTemplate(4);
        }

        protected void UpdatePrintTemplate(int imagePosition, string imageName)
        {
            try
            {
                int companyId = ddlCompanyList.SelectedValue.ToInt();

                string rMessage;
                _setting.UpdateCompanyPrintReportTemplate(companyId, imagePosition, imageName, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess("Image Updated Successfully");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);

            }
        }

        protected void DeletePrintTemplate(int imagePosition)
        {
            try
            {
                int companyId = ddlCompanyList.SelectedValue.ToInt();

                string rMessage;
                _setting.RemoveCompanyPrintReportTemplate(companyId, imagePosition, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess("Image Removed Successfully");

                GetCompanyPrintTempalte(ddlCompanyList.SelectedValue.ToInt());
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);

            }
        }

        //************************************** Properties ************************************//

        private string TempHeaderRightName
        {
            get { return ViewState["TempHeaderRightName"] != null ? ViewState["TempHeaderRightName"].ToString() : ""; }
            set { ViewState["TempHeaderRightName"] = value; }
        }

        private string TempHeaderCenterName
        {
            get { return ViewState["TempHeaderCenterName"] != null ? ViewState["TempHeaderCenterName"].ToString() : ""; }
            set { ViewState["TempHeaderCenterName"] = value; }
        }

        private string TempHeaderLeftName
        {
            get { return ViewState["TempHeaderLeftName"] != null ? ViewState["TempHeaderLeftName"].ToString() : ""; }
            set { ViewState["TempHeaderLeftName"] = value; }
        }

        private string TempFooterName
        {
            get { return ViewState["TempFooterName"] != null ? ViewState["TempFooterName"].ToString() : ""; }
            set { ViewState["TempFooterName"] = value; }
        }
    }
}