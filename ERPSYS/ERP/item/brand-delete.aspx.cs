using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.item
{
    public partial class BrandDelete : System.Web.UI.Page
    {
        readonly ItemBLL _brand = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteBrand();
        }

        protected void DeleteBrand()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int brandId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _brand.DeleteBrand(brandId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("brand-list.aspx?id={0}&e={1}", brandId, rMessageId));
                    }

                    Response.Redirect(string.Format("brand-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("brand-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}