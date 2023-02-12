using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Services;
using Newtonsoft.Json;


namespace ERPSYS.ERP.t
{
    public partial class TestPage : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          [WebMethod]
        public void Chart(object sender, EventArgs e)
        {
            rhcAreaSeries.DataSource = JsonConvert.SerializeObject(_item.GetItemBomList("f", "", "", -1, -1, false));
        }

    }
}