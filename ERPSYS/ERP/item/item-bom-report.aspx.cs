using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using System.Threading;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.item
{
    public partial class ItemBomReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemDataBind();
            }
        }

        protected void ItemDataBind()
        {
            try
            {
                Reports.Item.ItemBOM report = new Reports.Item.ItemBOM();
                if (Request["id"] != null)
                {
                    int itemId = Request["id"].ToInt();
                    if (itemId > 0)
                    {
                        report.ReportParameters[0].Value = itemId;
                    }
                }
                reportViewer.ReportSource = report;
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}