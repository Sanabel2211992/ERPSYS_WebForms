using System;
using System.Web;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class AuthorizationBLL
    {
        //public static void CheckUserAuthorization(string pageName)
        //{
        //    if (pageName != "" && pageName != "not-authorize")
        //    {
        //        if (!CheckAuthorizationBypageId(pageName))
        //        {
        //            //ClsLogging.WriteInfoMessage(string.Format("User not authorize to access {0} page.", pageName));
        //            HttpContext.Current.Server.Transfer("~/ERP/session/not-authorize.aspx");
        //        }
        //    }
        //}

        //private static bool CheckAuthorizationBypageId(string pageName)
        //{
        //    try
        //    {
        //        if (UserSession.AuthorizePages == null)
        //        {
        //            KickOut();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        KickOut();
        //    }

        //    return IsAuthorize(ApplicationSettings.GetPageId(pageName));
        //}

        //private static bool IsAuthorize(int pageId)
        //{
        //    return UserSession.AuthorizePages.Contains(pageId.ToString());
        //}

        public static void CheckUserAuthorization(string pageName)
        {
            CheckAuthorization(pageName);
        }

        private static void CheckAuthorization(string pageName)
        {
            try
            {
                if (UserSession.AuthorizePages == null)
                {
                    KickOut();
                }
            }
            catch (Exception)
            {
                KickOut();
            }

            SystemPage page = ApplicationSettings.GetSystemPage(pageName);

            if (page.PageId <= 0)
            {
                PageNotFound();
            }

            if (!IsAuthorize(page))
            {
                AccessDenied();
            }
        }

        private static bool IsAuthorize(SystemPage page)
        {
            if (page.IsPublic)
            {
                return true;
            }

            return UserSession.AuthorizePages.Contains(page.PageId.ToString());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void PageNotFound()
        {
            HttpContext.Current.Server.Transfer("~/ERP/system/not-found.aspx");
        }

        private static void AccessDenied()
        {
            HttpContext.Current.Server.Transfer("~/ERP/system/access-denied.aspx");
        }

        public static void KickOut()
        {
            UserSession.Clear();
            HttpContext.Current.Response.Redirect("~/ERP/session/login.aspx");
        }

        public static void LogOut()
        {
            ClsLogging.WriteInfoMessage("User LogOut");
            UserSession.Clear();
            HttpContext.Current.Response.Redirect("~/ERP/session/login.aspx");
        }
    }
}