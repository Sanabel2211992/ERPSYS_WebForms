using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.inventory
{
    public partial class TansferDelete : System.Web.UI.Page
    {
        readonly InventoryBLL _inventory = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteTransfer();
        }

        protected void DeleteTransfer()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int transferId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _inventory.DeleteTransfer(transferId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("transfer-preview.aspx?id={0}&e={1}", transferId, rMessageId));
                    }

                    Response.Redirect(string.Format("transfer-list.aspx?o={0}", 1));
                }
                else
                {
                    Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}