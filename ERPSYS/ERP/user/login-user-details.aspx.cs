using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System.IO;
using System.Linq;
using System.Web;
using ERPSYS.Helpers.Ext;
using ERPSYS.Controls.Common;

namespace ERPSYS.ERP.user
{
    public partial class LoginUserDetails : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

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
                txtUserSignature.ToolsFile = CommonMember.EditorToolBarFilePath;
                txtUserSignature.CssFiles.Add(CommonMember.EditorCSSFilePath);
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
                GetLoginUserAccount();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetLoginUserAccount()
        {
            int userId = UserSession.UserId;
            LoginUserAccount userAccount = _user.GetLoginUserAccount(userId);

            if (userAccount.UserId <= 0)
            {
                Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
            }

            txtMobile.Text = userAccount.Mobile;
            txtEmail.Text = userAccount.Email;
            txtUserSignature.Content = userAccount.UserSignature;
            imgUserImage.ImageUrl = userAccount.UserImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(userAccount.UserImage.ImageData, userAccount.UserImage.ImageType) : "~/ERP/resources/images/default-profile.png";
        }

        protected void UpdateLoginUserAccount()
        {
            var loginUserAccount = new LoginUserAccount();

            loginUserAccount.UserId = UserSession.UserId;
            loginUserAccount.Mobile = txtMobile.Text.ToTrimString();
            loginUserAccount.Email = txtEmail.Text.ToTrimString();
            loginUserAccount.UserSignature = txtUserSignature.Content.ToTrimString();

            FileImage profileimage = new FileImage();

            if (cbRemoveImage.Checked)
            {
                profileimage.IsUpdated = true;
                profileimage.ImageData = null;
                profileimage.ImageType = null;
            }
            else if (fuUserImage.HasFile)
            {

                string ext = Path.GetExtension(fuUserImage.FileName);
                string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;

                if (ext != null && !allowedExtenstions.Contains(ext.ToLower()))
                {
                    AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_ext_not_allowed"));
                    return;
                }

                var maxFileSize = CommonMember.MaxFileSizeProfilePicture;
                var fileSize = (fuUserImage.PostedFile.ContentLength / (decimal)1024);

                if (fileSize > maxFileSize)
                {
                    AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_size_exceed"));
                    return;
                }

                HttpPostedFile postimg = fuUserImage.PostedFile;

                profileimage.IsUpdated = true;
                profileimage.ImageData = ImageHandle.ImageToByte(fuUserImage.PostedFile);
                profileimage.ImageType = Path.GetExtension(postimg.FileName);

                imgUserImage.ImageUrl = ImageHandle.ImageFromByte(profileimage.ImageData, profileimage.ImageType);
            }

            loginUserAccount.UserImage = profileimage;

            string rMessage;
            _user.UpdateLoginUserAccount(loginUserAccount, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            if (cbRemoveImage.Checked)
            {
                imgUserImage.ImageUrl = "~/ERP/resources/images/default-profile.png";
                UserProfileBLL.RemoveProfilePictureFromCache(RegisteredUser.UserId.ToString());
                UserProfileBLL.RemoveProfileSmallPictureFromCache(RegisteredUser.UserId.ToString());

                UserSession.UpdateProfileHasPictureSession(false);
            }
            else if (fuUserImage.HasFile)
            {
                UserProfileBLL.UpdateProfilePictureToCache(profileimage.ImageData, RegisteredUser.UserId.ToString());
                UserProfileBLL.UpdateProfileSmallPictureToCache(RegisteredUser.UserId.ToString(), 35, 35);

                UserSession.UpdateProfileHasPictureSession(true);
            }

            if (profileimage.IsUpdated)
            {
                var pageHandler = HttpContext.Current.CurrentHandler;
                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
                if (masterPage != null)
                {
                    UCHeader ucHeader = (UCHeader)masterPage.FindControl("UCHeader");
                    ucHeader.LoadUserProfilePicture();
                }
            }

            AppNotification.MessageBoxSuccess(Notifications.GetMessage("user_profile_update_success"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateLoginUserAccount();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../main/home.aspx"));
        }
    }
}