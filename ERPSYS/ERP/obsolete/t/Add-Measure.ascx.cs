using ERPSYS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using Telerik.Web.UI;


namespace ERPSYS.ERP.t
{
    public partial class Add_Measure : System.Web.UI.UserControl
    {
        readonly SettingsBLL _setting = new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddUnitMeasure()
        {
            //UnitOfMeasure unit = new UnitOfMeasure();

            //unit.UnitName = txtNameMeasure.Text.ToTrimString();
            //string rMessage;
            //int unitId = _setting.AddUnitofMeasure(unit, out rMessage);

            //if (rMessage != string.Empty || unitId <= 0)
            //{
            //    AppNotification.MessageBoxFailed(rMessage);
            //    return;
            //}
        }
        protected void btnSaveMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                AddUnitMeasure();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}