using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.item
{
    public partial class ItemType : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GetTypeList();
        }

        private void GetTypeList()
        {
            try
            {
                rgTypeList.DataSource = _item.GetTypeList();
                rgTypeList.DataBind();
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}