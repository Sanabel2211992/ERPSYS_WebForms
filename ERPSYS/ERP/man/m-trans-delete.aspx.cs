using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class MaterialTransferDelete : System.Web.UI.Page
    {
        readonly MaterialTransferBLL _transfer = new MaterialTransferBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteRawMaterialRequest();
        }

        protected void DeleteRawMaterialRequest()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["tid"] != null && Request.QueryString["tids"] != string.Empty && Request.QueryString["oid"] != null && Request.QueryString["oid"] != string.Empty)
                {
                    int transferId = Request.QueryString["id"].ToInt();
                    int orderTypeId = Request.QueryString["tid"].ToInt();
                    int orderId = Request.QueryString["oid"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _transfer.DeleteMaterialTransfer(transferId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("m-trans-preview.aspx?id={0}&e={1}", transferId, rMessageId));
                    }

                    if (orderTypeId == 1)
                    {
                        Response.Redirect(string.Format("prod-order-preview.aspx?id={0}&o={1}", orderId, 31));
                    }          
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}