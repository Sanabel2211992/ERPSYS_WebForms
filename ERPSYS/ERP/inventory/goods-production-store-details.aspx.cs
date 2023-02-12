using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.inventory
{
    public partial class goods_production_store_details : System.Web.UI.Page
    {
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
                    GetItem(Request.QueryString["id"].ToInt());
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

        protected void GetItem(int itemId)
        {
            ItemBLL itemBll = new ItemBLL();
            Item item = itemBll.GetItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect(string.Format("goods-production-store.aspx?e={0}", 1));
            }

            ItemId = item.ItemId;
            lblItemCode.Text = item.ItemCode;
            lblPartNumber.Text = item.PartNumber;
            lblDescription.Text = item.Description;
        }

        protected void rgGoodsProItem_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgGoodsProItem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgGoodsProItem.DataSource = _inv.GetGoodsProductionStoreItemDetails(ItemId);
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
    }
}