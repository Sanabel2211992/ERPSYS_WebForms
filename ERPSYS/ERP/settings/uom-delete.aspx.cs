using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class UnitOfMeasureDelete : System.Web.UI.Page
    {
        readonly SettingsBLL _unit = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteUnitOfMeasure();
        }

        protected void DeleteUnitOfMeasure()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int unitId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _unit.DeleteUnitOfMeasure(unitId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("uom-list.aspx?id={0}&e={1}", unitId, rMessageId));
                    }

                    Response.Redirect(string.Format("uom-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("uom-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}