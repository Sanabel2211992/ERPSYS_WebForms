using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoiceDelete : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();    

        protected void Page_Load(object sender, EventArgs e)
        {
            DeletePurchaseInvoice();
        }

        protected void DeletePurchaseInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int purchaseInvoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _scm.DeletePurchaseInvoice(purchaseInvoiceId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("purchase-invoice-preview.aspx?id={0}&e={1}", purchaseInvoiceId, rMessageId));
                    }

                    Response.Redirect(string.Format("purchase-invoice-list.aspx?o={0}", 1));
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