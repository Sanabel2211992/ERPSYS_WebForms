using ERPSYS.BLL;
using ERPSYS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.t
{
    public partial class ShowTextJQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool AddCategory(string name, string code)
        {
            ItemBLL item = new ItemBLL();
            ItemCategory category = new ItemCategory { Name = name, Code=code };

            string rMessage;
            item.AddCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                return false;
            }
           
            return true;
        }
    }
}