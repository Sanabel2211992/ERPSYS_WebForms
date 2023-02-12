using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using System.Threading;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using ERPSYS.Controls.Common;
using Telerik.Web.UI;
using System.Web.UI;
using ERPSYS.Controls.HierarchyItems.PROJ;

namespace ERPSYS.ERP.proj
{
    public partial class ProjForm : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
  
         //************************************** Properties ************************************//
        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }

        
    }
}
