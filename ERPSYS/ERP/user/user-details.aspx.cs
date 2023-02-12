using System;
using System.Linq;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.IO;
using System.Web;

namespace ERPSYS.ERP.user
{
    public partial class UserDetails : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
                GetLookupTables();
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

        protected void GetLookupTables()
        {
            try
            {
                LookupBLL lookup = new LookupBLL();

                ddlRole.DataTextField = "Name";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataSource = lookup.GetRoleList();
                ddlRole.DataBind();

                ddlDepartment.DataTextField = "Name";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataSource = lookup.GetDepartmentList();
                ddlDepartment.DataBind();

                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = lookup.GetLocation();
                ddlLocation.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {

          if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                Operation = "edit";
                GetUserDetails(Request.QueryString["id"].ToInt());
            }
            else
            {
                Operation = "new";
                imgUserImage.ImageUrl = "~/ERP/resources/images/default-profile.png";
            }
        }

        private void GetUserDetails(int userId)
        {
            UserAccount userAccount = _user.GetUser(userId);

            if (userAccount.UserId <= 0)
            {
                Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
            }

            UserId = userId;
            txtDisplayName.Text = userAccount.DisplayName;
            txtUsername.Text = userAccount.UserName;
            txtUsertitle.Text = userAccount.UserTitle;
            txtEmail.Text = userAccount.EmailAddress;
            txtMobile.Text = userAccount.Mobile;
            txtUserSignature.Content = userAccount.UserSignature;
            ddlRole.SelectedValue = userAccount.RoleId.ToString();
            ddlDepartment.SelectedValue = userAccount.DepratmentId.ToString();
            ddlLocation.SelectedValue = userAccount.LocationId.ToString();
            cbIsActive.Checked = userAccount.IsActive;
            imgUserImage.ImageUrl = userAccount.UserImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(userAccount.UserImage.ImageData, userAccount.UserImage.ImageType) : "~/ERP/resources/images/default-profile.png";

            pnlPassowrd.Visible = false;
        }

        //private string GetRandomImage(string path)
        //{
        //    string file = null;
        //    if (!string.IsNullOrEmpty(path))
        //    {
        //        var extensions = new[] { ".png", ".jpg" };
        //        try
        //        {
        //            var di = new DirectoryInfo(path);
        //            var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
        //            Random r = new Random();
        //            var fileInfos = rgFiles as FileInfo[] ?? rgFiles.ToArray();
        //            file = fileInfos.ElementAt(r.Next(0, fileInfos.Count())).FullName;
        //        }
        //        catch
        //        {
        //            // ignored
        //        }
        //    }
        //    return file;
        //}

        private void AddUserDetails()
        {
            var userAccount = new UserAccount();

            userAccount.DisplayName = txtDisplayName.Text.ToTrimString();
            userAccount.UserName = txtUsername.Text.ToTrimString();
            userAccount.UserTitle = txtUsertitle.Text.ToTrimString();
            userAccount.Password = txtPassword.Text.ToTrimString();
            userAccount.IsActive = cbIsActive.Checked;
            userAccount.LocationId = ddlLocation.SelectedValue.ToInt();
            userAccount.RoleId = ddlRole.SelectedValue.ToInt();
            userAccount.DepratmentId = ddlDepartment.SelectedValue.ToInt();
            userAccount.EmailAddress = txtEmail.Text.ToTrimString();
            userAccount.Mobile = txtMobile.Text.ToTrimString();
            userAccount.UserSignature = txtUserSignature.Content.ToTrimString();

            FileImage profileimage = new FileImage();

            if (fuUserImage.HasFile)
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
            //else
            //{
            //    FileStream fileStream = new FileStream(GetRandomImage(HttpContext.Current.Server.MapPath(CommonMember.SystemProfilePictrureSmallCachePath + "RandomImage/")), FileMode.Open, FileAccess.Read);
            //    string extension = Path.GetExtension(fileStream.Name);
            //    byte[] buffer = new byte[fileStream.Length];
            //    fileStream.Read(buffer, 0, (int)fileStream.Length);
            //    fileStream.Close();

            //    profileimage.IsUpdated = true;
            //    profileimage.ImageData = buffer;
            //    profileimage.ImageType = extension;

            //    imgUserImage.ImageUrl = ImageHandle.ImageFromByte(profileimage.ImageData, profileimage.ImageType);
            //}            

            userAccount.UserImage = profileimage;

            string rMessage;
            int userId = _user.AddUser(userAccount, out rMessage);

            if (rMessage != string.Empty || userId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            if (profileimage.IsUpdated)
            {
                UserProfileBLL.UpdateProfilePictureToCache(profileimage.ImageData, userId.ToString());
                UserProfileBLL.UpdateProfileSmallPictureToCache(userId.ToString(), 35, 35);
            }

            Response.Redirect(string.Format("user-list.aspx?o={0}", 1));
        }

        private void UpdateUserDetails()
        {           
            var userAccount = new UserAccount();

            userAccount.UserId = UserId;
            userAccount.DisplayName = txtDisplayName.Text.ToTrimString();
            userAccount.UserName = txtUsername.Text.ToTrimString();
            userAccount.UserTitle = txtUsertitle.Text.ToTrimString();
            userAccount.IsActive = cbIsActive.Checked;
            userAccount.LocationId = ddlLocation.SelectedValue.ToInt();
            userAccount.RoleId = ddlRole.SelectedValue.ToInt();
            userAccount.DepratmentId = ddlDepartment.SelectedValue.ToInt();
            userAccount.EmailAddress = txtEmail.Text.ToTrimString();
            userAccount.Mobile = txtMobile.Text.ToTrimString();
            userAccount.UserSignature = txtUserSignature.Content.ToTrimString();

            FileImage profileimage = new FileImage();

            if (fuUserImage.HasFile)
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

            userAccount.UserImage = profileimage;

            string rMessage;
            _user.UpdateUser(userAccount, out rMessage);

            if (rMessage != string.Empty || UserId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            if (profileimage.IsUpdated)
            {
                UserProfileBLL.UpdateProfilePictureToCache(profileimage.ImageData, UserId.ToString());
                UserProfileBLL.UpdateProfileSmallPictureToCache(UserId.ToString(), 35, 35);
            }

            Response.Redirect(string.Format("user-list.aspx?o={0}", 2));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new" && UserId == -1)
                {
                    AddUserDetails();
                }
                else if (Operation == "edit" && UserId > 0)
                {
                    UpdateUserDetails();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("user-list.aspx"));
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int UserId
        {
            get { return ViewState["UserId"] != null ? ViewState["UserId"].ToInt() : -1; }
            set { ViewState["UserId"] = value; }
        }
    }
}