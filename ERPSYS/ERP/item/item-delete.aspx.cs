using ERPSYS.BLL;
using System;
using System.Threading;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.ERP.item
{
    public partial class ItemDelete : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

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
                    GetItemDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("item-list.aspx?e={0}", 1));
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

        protected void GetItemDetails(int itemId)
        {
            Item item = _item.GetItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect(string.Format("item-list.aspx?e={0}", 1), false);
            }

            ItemId = itemId;
            lblItemCode.Text = item.ItemCode.ReplaceWhenNullOrEmpty("N/A");
            lblPartNumber.Text = item.PartNumber.ReplaceWhenNullOrEmpty("N/A");
            lblDescription.Text = item.Description.ReplaceWhenNullOrEmpty("N/A");
        }

        protected void Deleteitem()
        {
            try
            {
                string rMessage;
                int rMessageId;

                _item.DeleteItem(ItemId, out rMessage, out rMessageId);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("item-list.aspx?o={0}", 3));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Deleteitem();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-list.aspx?id"), false);
        }

        //************************************** Properties ************************************//
        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
    }
}