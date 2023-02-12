using ERPSYS.BLL;
using System;
using System.Linq;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Collections.Generic;

namespace ERPSYS.ERP.scm
{
    public partial class RptScmAudit : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();
        private List<PurchaseInvoice> _lstPurchaseInvoice;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rgReport1_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgReport1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgReport1.DataSource = _scm.GetReport1(DateStart, DateEnd);
        }

        protected void rgReport2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            Tuple<List<GoodsReceipt>, List<PurchaseInvoice>> output = _scm.GetReport2(DateStart, DateEnd);
            _lstPurchaseInvoice = output.Item2;

            rgReport2.DataSource = output.Item1;
        }

        protected void rgReport2_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int goodsReceiptId = dataItem.GetDataKeyValue("GoodsReceiptId").ToInt();

            e.DetailTableView.DataSource = _lstPurchaseInvoice.Where(p => p.GoodsReceiptId == goodsReceiptId).ToList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;

                switch (ddlReports.SelectedValue)
                {
                    case "1":
                        rmpReports.SelectedIndex = 0;
                        rgReport1.Rebind();
                        break;
                    case "2":
                        rmpReports.SelectedIndex = 1;
                        rgReport2.Rebind();
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : "1/1/2900".ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }
    }
}