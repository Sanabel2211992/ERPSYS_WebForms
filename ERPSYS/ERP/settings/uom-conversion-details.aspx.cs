using System;
using System.Data;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class UnitOfMeasureConversionDetails : System.Web.UI.Page
    {
        readonly SettingsBLL _uom = new SettingsBLL();

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
                GetLookupUomTables();

                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetUnitOfMeasureConversionRule(Request.QueryString["id"].ToInt());
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

        protected void GetLookupUomTables()
        {
            LookupBLL lookup = new LookupBLL();

            DataTable dtUom = lookup.GetUom();

            ddlUOMFrom.DataTextField = "Name";
            ddlUOMFrom.DataValueField = "UomId";
            ddlUOMFrom.DataSource = dtUom;
            ddlUOMFrom.DataBind();
            ddlUOMFrom.Items.Insert(0, new ListItem("-- Select Unit --", "-1"));

            ddlUOMTo.DataTextField = "Name";
            ddlUOMTo.DataValueField = "UomId";
            ddlUOMTo.DataSource = dtUom;
            ddlUOMTo.DataBind();
            ddlUOMTo.Items.Insert(0, new ListItem("-- Select Unit --", "-1"));
        }

        protected void GetUnitOfMeasureConversionRule(int conversionId)
        {
            UnitOfMeasureConversionRule unit = _uom.GetUnitOfMeasureConversionRule(conversionId);

            if (unit.ConversionId <= 0)
            {
                Response.Redirect(string.Format("uom-conversion-list.aspx?e={0}", 1));
            }

            ConversionId = unit.ConversionId;
            ddlUOMFrom.SelectedValue = unit.FromUomId.ToString();
            ddlUOMTo.SelectedValue = unit.ToUomId.ToString();
            txtFactor.Text = unit.UomFactor.ToDecimalFormat();
        }

        protected void AddUnitOfMeasureConversionRule()
        {
            UnitOfMeasureConversionRule unit = new UnitOfMeasureConversionRule();

            unit.FromUomId = ddlUOMFrom.SelectedValue.ToInt();
            unit.ToUomId = ddlUOMTo.SelectedValue.ToInt();
            unit.UomFactor = txtFactor.Text.ToDecimal();

            if (unit.FromUomId == unit.ToUomId)
            {
                AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("uom_conversion_to_form_identical"));
                return;
            }

            string rMessage;
            _uom.AddUnitOfMeasureConversionRule(unit, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("uom-conversion-list.aspx?o={0}&id={1}", 1, ConversionId), false);
        }

        protected void UpdateUnitOfMeasureConversionRule()
        {
            UnitOfMeasureConversionRule unit = new UnitOfMeasureConversionRule();

            unit.ConversionId = ConversionId;
            unit.FromUomId = ddlUOMFrom.SelectedValue.ToInt();
            unit.ToUomId = ddlUOMTo.SelectedValue.ToInt();
            unit.UomFactor = txtFactor.Text.ToDecimal();

            if (unit.FromUomId == unit.ToUomId)
            {
                AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("uom_conversion_to_form_identical"));
                return;
            }

            string rMessage;
            _uom.UpdateUnitOfMeasureConversionRule(unit, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("uom-conversion-list.aspx?o={0}&id={1}", 2, ConversionId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddUnitOfMeasureConversionRule();
                }
                else if (Operation == "edit" && ConversionId > 0)
                {
                    UpdateUnitOfMeasureConversionRule();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("uom-conversion-list.aspx");
        }

        //************************************** Properties ************************************//
        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int ConversionId
        {
            get { return ViewState["ConversionId"] != null ? ViewState["ConversionId"].ToInt() : -1; }
            set { ViewState["ConversionId"] = value; }
        }
    }
}