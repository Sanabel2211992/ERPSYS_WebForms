using ERPSYS.BLL;
using System;
using System.Threading;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.ERP.item
{
    public partial class ItemBomDelete : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteItemBomLines();
        }
        private void DeleteItemBomLines()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["tid"] != null && Request.QueryString["tid"] != string.Empty)
                {
                    int itemId = Request.QueryString["id"].ToInt();
                    int typeId = Request.QueryString["tid"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _item.DeleteItemBomLines(itemId, typeId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("item-bom-form.aspx?id={0}&e={1}", itemId, rMessageId));
                    }

                    Response.Redirect(string.Format("item-bom-form.aspx?id={0}&o={1}", itemId, 2));
                }
                else
                {
                    Response.Redirect(string.Format("item-bom-list.aspx?id?e={0}", 1));      
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}