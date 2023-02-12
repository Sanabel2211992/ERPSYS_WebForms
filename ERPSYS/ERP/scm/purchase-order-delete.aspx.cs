using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderDelete : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();    

        protected void Page_Load(object sender, EventArgs e)
        {
            DeletePurchaseOrder();
        }

        protected void DeletePurchaseOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int purchaseOrderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _scm.DeletePurchaseOrder(purchaseOrderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("purchase-order-preview.aspx?id={0}&e={1}", purchaseOrderId, rMessageId));
                    }

                    Response.Redirect(string.Format("purchase-order-list.aspx?o={0}", 1));
                }
                else
                {
                    Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}