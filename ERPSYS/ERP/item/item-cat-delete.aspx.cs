using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.item
{
    public partial class ItemCategoryDelete : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        protected void DeleteCategory()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int maincategoryId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _item.DeleteCategory(maincategoryId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("item-cat-list.aspx?id={0}&e={1}", maincategoryId, rMessageId));
                    }

                    Response.Redirect(string.Format("item-cat-list.aspx?o={0}", 3));
                }
                else if (Request.QueryString["mid"] != null && Request.QueryString["mid"] != string.Empty && Request.QueryString["sid"] != null && Request.QueryString["sid"] != string.Empty)
                {
                    int maincategoryId = Request.QueryString["mid"].ToInt();
                    int subcategoryId = Request.QueryString["sid"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _item.DeleteSubCategory(subcategoryId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("item-cat-sub-list.aspx?id={0}&e={1}", maincategoryId, rMessageId));
                    }

                    Response.Redirect(string.Format("item-cat-sub-list.aspx?id={0}&o={1}", maincategoryId, 3));
                }
                else
                {
                    Response.Redirect(string.Format("item-cat-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}