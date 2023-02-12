using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Collections.Generic;

namespace ERPSYS.ERP.proj
{
    public partial class ProjPurchases : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetProjectDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("proj-list.aspx?e={0}", 1));
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

        protected void GetProjectDetails(int projectId)
        {
            Proj project = _proj.GetProject(projectId);

            if (project.ProjectId <= 0)
            {
                Response.Redirect("proj-list.aspx?e=1", false);
            }

            ProjectId = project.ProjectId;

            lbProjectName.Text = project.ProjectName;
            lblStartDate.Text = project.StartDate.ToDateString();
            lblEndDate.Text = project.EndDate.ToDateString();
            lblRemarks.Text = project.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = project.Status;

            hlnkCustomerName.Text = project.CustomerName.ReplaceWhenNullOrEmpty("N/A");
            if (project.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", project.CustomerId);
                hlnkCustomerName.Enabled = true;
            }
        }

        protected void rblPurchasesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblPurchasesType.SelectedValue)
            {
                case "Product":
                    pnlProduct.Visible = true;
                    pnlPurchaseInvoiceSearch.Visible = false;
                    break;
                case "Purchase":
                    pnlPurchaseInvoiceSearch.Visible = true;
                    pnlProduct.Visible = false;
                    break;
            }
        }

        protected void rsbPurchaseInvoice_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            rsbPurchaseInvoice.DataSource = _proj.GetPurchaseInvoiceList(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void rsbPurchaseInvoice_Load(object sender, EventArgs e)
        {
            rsbPurchaseInvoice.DataSource = new DataTable();
        }

        protected void GetPurchaseInvoiceItemLines(int invoiceId)
        {
            pnlPurchaseInvoiceDetails.Visible = true;
 
            rgPurchaseInvoice.DataSource = _scm.GetPurchaseInvoiceLines(invoiceId);
            rgPurchaseInvoice.DataBind();
        }

        protected void rsbPurchaseInvoice_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                lblInvoiceDate.Text = ((Dictionary<string, object>)e.DataItem)["InvoiceDate"].ToDate().ToDateString();
                lblSupplierName.Text = ((Dictionary<string, object>)e.DataItem)["SupplierName"].ToString();

                PurchaseInvoiceId = e.Value.ToInt();

                GetPurchaseInvoiceItemLines(PurchaseInvoiceId);
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((GridItem)((CheckBox)sender).NamingContainer).Selected = ((CheckBox)sender).Checked;

            bool checkHeader = rgPurchaseInvoice.MasterTableView.Items.Cast<GridDataItem>().All(dataItem => ((CheckBox)dataItem.FindControl("cbItem")).Checked);
            GridHeaderItem headerItem = rgPurchaseInvoice.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null) ((CheckBox)headerItem.FindControl("cbAllItems")).Checked = checkHeader;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in rgPurchaseInvoice.MasterTableView.Items.Cast<GridDataItem>().Where(dataItem => headerCheckBox != null).Where(dataItem => headerCheckBox != null && dataItem.Cells[17].Text.ToInt() != 3))
            {
                if (headerCheckBox != null)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = headerCheckBox.Checked;
                    //((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;
                    dataItem.Selected = headerCheckBox.Checked;
                }
            }
        }

        private DataTable ProjectPurchaseMultiLineTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
            dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("IsPercentDiscount", typeof(bool)));
            dt.Columns.Add(new DataColumn("NetPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TotalPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("UomId", typeof(int)));

            return dt;
        }

        private DataTable GetProjectPurchaseMultiLineTable()
        {
            DataTable dt = ProjectPurchaseMultiLineTable("tblLines");

            foreach (GridDataItem item in rgPurchaseInvoice.Items)
            {
                if (((CheckBox)item.FindControl("cbItem")).Checked)
                {
                    //decimal netPrice = ((RadNumericTextBox)item.FindControl("txtNetPrice")).Text.ToDecimal();
                    //decimal quantity = ((RadNumericTextBox)item.FindControl("txtQuantity")).Text.ToDecimal();

                    //if ((netPrice <= 0))
                    //{
                    //    throw new Exception("Invalid item price");
                    //}
                    //if ((quantity <= 0))
                    //{
                    //    throw new Exception("Invalid item quantity");
                    //}

                    var dr = dt.NewRow();
                    dr["ItemId"] = item.Cells[5].Text.ToInt();
                    //dr["Quantity"] = quantity;
                    //dr["UnitPrice"] = netPrice;
                    dr["Discount"] = 0;
                    dr["IsPercentDiscount"] = 1;
                    //dr["NetPrice"] = netPrice;
                    //dr["TotalPrice"] = Calculation.GetLineTotal(netPrice, quantity);
                    dr["UomId"] = item.Cells[16].Text.ToInt();

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        protected void CreateProjectPurchaseMultiLine()
        {
            DataTable dtLines = GetProjectPurchaseMultiLineTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                AppNotification.MessagePanelWarning("No items selected", "Warning");
                return;
            }

            string rMessage;
            var invoiceId = _proj.CreatePurchaseFromPurchaseInvoice(ProjectId, PurchaseInvoiceId, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("proj-preview.aspx?o=edit&id={0}", ProjectId), false);
        }

        protected void CreateProjectPurchaseOneLine()
        {
            try
            {
                ProjPurchase line = new ProjPurchase();

                line.ProjectId = ProjectId;
                line.ItemId = UCItemAdd.ItemId;
                line.PartNumber = UCItemAdd.PartNumber;
                line.ItemCode = UCItemAdd.ItemCode;
                line.Description = UCItemAdd.Description;
                line.DescriptionAs = UCItemAdd.Description;
                line.UnitPrice = UCItemAdd.UnitPrice;
                line.Quantity = UCItemAdd.Quantity;

                string rMessage;
                _proj.AddPurchaseLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    Response.Redirect(string.Format("proj-preview.aspx?id={0}&o={1}", ProjectId, 1, false));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (rblPurchasesType.SelectedItem.Value == "Product")
                {
                    CreateProjectPurchaseOneLine();
                }
                else
                {
                    CreateProjectPurchaseMultiLine();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-preview.aspx?id={0}", ProjectId), false);
        }

        //************************************** Properties ************************************//

        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }

        public int PurchaseInvoiceId
        {
            get { return ViewState["PurchaseInvoiceId"] != null ? ViewState["PurchaseInvoiceId"].ToInt() : -1; }
            set { ViewState["PurchaseInvoiceId"] = value; }
        }
    }
}