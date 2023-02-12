using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class UnitOfMeasureDetails : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetUnitOfMeasure(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetUnitOfMeasure(int unitId)
        {
            UnitOfMeasure unit = _setting.GetUnitOfMeasure(unitId);

            if (unit.UomId <= 0)
            {
                Response.Redirect(string.Format("uom-list.aspx?e={0}", 1));
            }

            UnitId = unitId;

            txtUnitName.Text = unit.UnitName;
            txtUnitCode.Text = unit.UnitCode;
        }

        protected void AddUnitOfMeasure()
        {
            UnitOfMeasure unit = new UnitOfMeasure();

            unit.UnitName = txtUnitName.Text.ToTrimString();
            unit.UnitCode = txtUnitCode.Text.ToTrimString();

            string rMessage;
            int unitId = _setting.AddUnitOfMeasure(unit, out rMessage);

            if (rMessage != string.Empty || unitId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("uom-list.aspx?o={0}", 1), false);
        }

        protected void UpdateUnitOfMeasure()
        {
            UnitOfMeasure unit = new UnitOfMeasure();

            unit.UomId = UnitId;
            unit.UnitName = txtUnitName.Text.ToTrimString();
            unit.UnitCode = txtUnitCode.Text.ToTrimString();

            string rMessage;
            _setting.UpdateUnitOfMeasure(unit, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("uom-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddUnitOfMeasure();
                }
                else if (Operation == "edit" && UnitId > 0)
                {
                    UpdateUnitOfMeasure();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("uom-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int UnitId
        {
            get { return ViewState["UnitId"] != null ? ViewState["UnitId"].ToInt() : -1; }
            set { ViewState["UnitId"] = value; }
        }
    }
}