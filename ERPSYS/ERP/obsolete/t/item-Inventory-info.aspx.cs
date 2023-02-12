using ERPSYS.BLL;
using ERPSYS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.t
{
    public partial class item_Inventory_info : System.Web.UI.Page
    {
        //SanabelBLL _item = new SanabelBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    rgInventoryItemList.DataSource = _item.GetItemInventory(Request.QueryString["id"].ToInt());
            //}
        }
    }
}