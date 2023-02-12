using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.inventory
{
    public partial class GoodsTrans : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();
        readonly InventoryBLL _inv = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetItemTransaction(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("~/ERP/item/item-list.aspx?e={0}", 1), false);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemTransaction(int itemId)
        {
            Item item = _item.GetItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect(string.Format("~/ERP/item/item-list.aspx?e={0}", 1));
            }

            ItemId = item.ItemId;
            lblItemCode.Text = item.ItemCode;
            lblPartNumber.Text = item.PartNumber;
            lblDescription.Text = item.Description;

           rgGoodsTransaction.Rebind();
        }

        protected void rgGoodsTransaction_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgGoodsTransaction.DataSource = _inv.GetStoreItemTransaction(ItemId);
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