using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.DialogBox.INV.Stock
{
    public partial class InvItemQty : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                ItemId = Request.QueryString["id"].ToInt();
            }
        }

        protected void rgInventoryQty_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgInventoryQty.DataSource = _item.GetStoreItemQuantityDialog(ItemId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
    }
}