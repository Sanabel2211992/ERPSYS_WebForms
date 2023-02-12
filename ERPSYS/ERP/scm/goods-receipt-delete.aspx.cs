using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptDelete : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteGoodsReceiptNote();
        }

        protected void DeleteGoodsReceiptNote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int goodsReceiptId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _scm.DeleteGoodsReceiptNote(goodsReceiptId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("goods-receipt-preview.aspx?id={0}&e={1}", goodsReceiptId, rMessageId));
                    }

                    Response.Redirect(string.Format("goods-receipt-list.aspx?o={0}", 1));
                }
                else
                {
                    Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}