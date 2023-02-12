using System.Collections.Generic;
using System.Data;
using System.Linq;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SystemBLL
    {
        private readonly SystemDB _system = new SystemDB();

        //**************************************************************************************************************************//SELECT

        public List<SystemPage> GetSystemPages()
        {
            DataTable dtPages = _system.GetSystemPages();

            return (from DataRow dr in dtPages.Rows
                select new SystemPage
                {
                    PageId = dr["PageId"].ToInt(), Name = dr["PageName"].ToString(), DisplayName = dr["DisplayName"].ToString(), IsPublic = dr["IsPublic"].ToBool()
                }).ToList();
        }

    }
}