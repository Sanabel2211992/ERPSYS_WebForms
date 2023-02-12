using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoicePost : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostPurchaseInvoice();

        }

        protected void PostPurchaseInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int purchaseInvoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _scm.PostPurchaseInvoice(purchaseInvoiceId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("purchase-invoice-preview.aspx?id={0}&e={1}", purchaseInvoiceId, rMessageId));
                    }

                    Response.Redirect(string.Format("purchase-invoice-preview.aspx?id={0}&o=1", purchaseInvoiceId));
                }
                else
                {
                    Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}