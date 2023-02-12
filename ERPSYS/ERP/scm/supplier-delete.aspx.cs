using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.scm
{
    public partial class supplier_delete : System.Web.UI.Page
    {
        readonly SupplierBLL _supplier = new SupplierBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteSupplier();
        }

        protected void DeleteSupplier()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int supplierId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _supplier.DeleteSupplier(supplierId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("supplier-list.aspx?id={0}&e={1}", supplierId, rMessageId));
                    }

                    Response.Redirect(string.Format("supplier-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("supplier-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}