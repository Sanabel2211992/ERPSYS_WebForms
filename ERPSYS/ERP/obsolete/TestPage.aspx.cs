using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace ERPSYS.ERP.obsolete
{
    public partial class TestPage : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();
       protected void Page_Load(object sender, EventArgs e)
        {
            rhcAreaSeries.DataSource = _item.GetItemBomList("f","","",-1,-1,false);
        }
    }
}