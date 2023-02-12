using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ApplicationSettings
    {
        //private static DataTable PageTable
        //{
        //    get { return ((DataTable)HttpContext.Current.Application.Contents["PageTable"]); }
        //    set { HttpContext.Current.Application.Contents["PageTable"] = value; }
        //}

        //public static void ResetSystemPageList()
        //{
        //    PageTable = new DataTable();
        //    GetSystemPageList();
        //}

        //private static void GetSystemPageList()
        //{
        //    SettingsBLL setting = new SettingsBLL();
        //    PageTable = setting.GetSystemPageList();
        //}

        //public static int GetPageId(string pageName)
        //{
        //    if (PageTable == null)
        //    {
        //        GetSystemPageList();
        //    }

        //    int pageId = -1;
        //    DataTable dtPages = PageTable;

        //    if (dtPages != null && dtPages.Select("Name = '" + pageName + "'").Length > 0)
        //    {
        //        pageId = dtPages.Select("Name = '" + pageName + "'")[0]["PageId"].ToInt();
        //    }

        //    return pageId;
        //}

        //public static string GetPageDisplayName(string pageName)
        //{
        //    if (PageTable == null)
        //    {
        //        GetSystemPageList();
        //    }

        //    string displayName = "";
        //    var dtPages = PageTable;

        //    if (dtPages != null && dtPages.Select("Name = '" + pageName + "'").Length > 0)
        //    {
        //        displayName = dtPages.Select("Name = '" + pageName + "'")[0]["DisplayName"].ToString();
        //    }

        //    return displayName;
        //}

        private static List<SystemPage> SystemPagesList
        {
            get { return ((List<SystemPage>)HttpContext.Current.Application.Contents["SystemPages"]); }
            set { HttpContext.Current.Application.Contents["SystemPages"] = value; }
        }

        private static void GetSystemPages()
        {
            SystemBLL system = new SystemBLL();
            SystemPagesList = system.GetSystemPages();
        }

        public static void ResetSystemPages()
        {
            GetSystemPages();
        }

        public static SystemPage GetSystemPage(string pageName)
        {
            if (SystemPagesList == null)
            {
                SystemBLL system = new SystemBLL();
                SystemPagesList = system.GetSystemPages();
            }

            return SystemPagesList.FirstOrDefault(x => x.Name == pageName);
        }

        public static int GetSystemPageId(string pageName)
        {
            if (SystemPagesList == null)
            {
                SystemBLL system = new SystemBLL();
                SystemPagesList = system.GetSystemPages();
            }

            return SystemPagesList.Where(x => x.Name == pageName).Select(x => x.PageId).SingleOrDefault();
        }

        public static string GetPageDisplayName(string pageName)
        {
            if (SystemPagesList == null)
            {
                SystemBLL system = new SystemBLL();
                SystemPagesList = system.GetSystemPages();
            }

            return SystemPagesList.Where(x => x.Name == pageName).Select(x => x.DisplayName).SingleOrDefault();
        }
    }
}