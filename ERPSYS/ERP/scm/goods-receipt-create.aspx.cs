using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptCreate : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();
        LookupBLL lookup = new LookupBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                UCOrderDate.DateValue = DateTime.Today;
                GetItemLookupTables();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {


            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetGoodsReceiptLocation();
            ddlLocation.DataBind();

            ddlLocation.SelectedValue = _scm.DefaultGoodsReceivedLocationId.ToString();
        }

        protected void cbConsignedGoods_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConsignedGoods.Checked)
            {
                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = lookup.GetGoodsConsignedLocation();
                ddlLocation.DataBind();

                ddlLocation.SelectedValue = _scm.DefaultGoodsConsignedLocationId.ToString();
            }
            else
            {
                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = lookup.GetGoodsReceiptLocation();
                ddlLocation.DataBind();

                ddlLocation.SelectedValue = _scm.DefaultGoodsReceivedLocationId.ToString();
            }
        }

        void CreateGoodsReceiptNote()
        {
            GoodsReceipt goodsReceipt = new GoodsReceipt();

            goodsReceipt.ReceiptDate = UCOrderDate.DateValue;
            goodsReceipt.SupplierId = UCSupplier.SupplierId;
            goodsReceipt.SupplierName = UCSupplier.SupplierName.ToTrimString();
            //goodsReceipt.SupplierInvoiceNumber = txtSupplierInvoice.Text.ToTrimString();
            goodsReceipt.LocationId = ddlLocation.SelectedValue.ToInt();
            goodsReceipt.IsConsignedGoods = cbConsignedGoods.Checked;
            goodsReceipt.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var grnId = _scm.CreateGoodsReceiptNote(goodsReceipt, out rMessage);

            if (rMessage != string.Empty || grnId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("goods-receipt-form.aspx?id={0}", grnId));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateGoodsReceiptNote();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("goods-receipt-list.aspx"));
        }
    }
}