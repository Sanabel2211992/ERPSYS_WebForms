using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class DeliveryReceiptPost : System.Web.UI.Page
    {
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostDeliveryReceipt();
        }

        protected void PostDeliveryReceipt()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int receiptId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;
                    _delivery.PostDeliveryReceipt(receiptId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("delivery-receipt-preview.aspx?id={0}&e={1}", receiptId, rMessageId));
                    }

                    Response.Redirect(string.Format("delivery-receipt-preview.aspx?id={0}&o=2", receiptId));
                }
                else
                {
                    Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }   
    }
}