using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using System.Data;

namespace ERPSYS.ERP.settings
{
    public partial class GeneralOperations : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdateProfilePicturesCache_Click(object sender, EventArgs e)
        {
            DataTable dt = _user.GetUsersProfilePictures(); 

            foreach (DataRow dr in dt.Rows) 
            {
                if (dr["UserImage"].ToBytes().Length > 0)
                {
                    UserProfileBLL.UpdateProfilePictureToCache(dr["UserImage"].ToBytes(), dr["UserId"].ToString());
                    UserProfileBLL.UpdateProfileSmallPictureToCache(dr["UserId"].ToString(), 35, 35);
                }
            }

            AppNotification.MessageBoxSuccess("Users Images Saved In the Server successfully.");
        }
    }
}