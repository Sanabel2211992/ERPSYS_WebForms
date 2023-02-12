using System;
using ERPSYS.Helpers;
using ERPSYS.BLL;

namespace ERPSYS.Controls.Obsolete
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    lblTitle.Text = AppSettings.SystemTitle;
            //    lblVersion.Text = AppSettings.SystemVersion;

            //    LoadUserProfilePicture();
            //}
        }

        //public void LoadUserProfilePicture()
        //{
        //    if (RegisteredUser.HasProfilePicture && RegisteredUser.HasProfilePictureCache)
        //    {
        //        smallProfileImage.ImageUrl = RegisteredUser.ProfilePictureCacheUrl;
        //        header_user_big.ImageUrl = RegisteredUser.ProfilePictureCacheUrl;
        //    }
        //    else
        //    {
        //        smallProfileImage.ImageUrl = "~/ERP/resources/images/default-profile.png";
        //        header_user_big.ImageUrl = "~/ERP/resources/images/default-profile.png";
        //    }
        //}
    }
}