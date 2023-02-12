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
    public partial class ProjSalesForm : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

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

        protected void rblSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblSalesType.SelectedValue)
            {
                case "Product":
                    pnlProduct.Visible = true;
                    pnlSalesInvoiceSearch.Visible = false;
                    break;
                case "Sales":
                    pnlSalesInvoiceSearch.Visible = true;
                    pnlProduct.Visible = false;
                    break;
            }
        }

        protected void rsbSalesInvoice_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            rsbSalesInvoice.DataSource = _proj.GetSalesInvoiceList(e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString());
        }

        protected void rsbSalesInvoice_Load(object sender, EventArgs e)
        {
            rsbSalesInvoice.DataSource = new DataTable();
        }

        protected void GetSalesInvoiceItemLines(int invoiceId)
        {
            pnlSalesInvoiceDetails.Visible = true;
 
            rgSalesInvoice.DataSource = _invoice.GetSalesInvoiceLines(invoiceId);
            rgSalesInvoice.DataBind();
        }

        protected void rsbSalesInvoice_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                lblInvoiceDate.Text = ((Dictionary<string, object>)e.DataItem)["InvoiceDate"].ToDate().ToDateString();
                lblCustomerName.Text = ((Dictionary<string, object>)e.DataItem)["CustomerName"].ToString();

                InvoiceId = e.Value.ToInt();

                GetSalesInvoiceItemLines(InvoiceId);
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((GridItem)((CheckBox)sender).NamingContainer).Selected = ((CheckBox)sender).Checked;

            bool checkHeader = rgSalesInvoice.MasterTableView.Items.Cast<GridDataItem>().All(dataItem => ((CheckBox)dataItem.FindControl("cbItem")).Checked);
            GridHeaderItem headerItem = rgSalesInvoice.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null) ((CheckBox)headerItem.FindControl("cbAllItems")).Checked = checkHeader;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in rgSalesInvoice.MasterTableView.Items.Cast<GridDataItem>().Where(dataItem => headerCheckBox != null).Where(dataItem => headerCheckBox != null && dataItem.Cells[17].Text.ToInt() != 3))
            {
                if (headerCheckBox != null)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = headerCheckBox.Checked;
                    //((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;
                    dataItem.Selected = headerCheckBox.Checked;
                }
            }
        }

        private DataTable ProjectSalesMultiLineTable(string tableName = "")
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

        private DataTable GetProjectSalesMultiLineTable()
        {
            DataTable dt = ProjectSalesMultiLineTable("tblLines");

            foreach (GridDataItem item in rgSalesInvoice.Items)
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

        protected void CreateProjectSalesMultiLine()
        {
            DataTable dtLines = GetProjectSalesMultiLineTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                AppNotification.MessagePanelWarning("No items selected", "Warning");
                return;
            }

            string rMessage;
            var invoiceId = _proj.CreateSalesFromSalesInvoice(ProjectId, InvoiceId, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("proj-preview.aspx?o=edit&id={0}", ProjectId), false);
        }

        protected void CreateProjectSalesOneLine()
        {
            try
            {
                ProjSales line = new ProjSales();

                line.ProjectId = ProjectId;
                line.ItemId = UCItemAdd.ItemId;
                line.PartNumber = UCItemAdd.PartNumber;
                line.ItemCode = UCItemAdd.ItemCode;
                line.Description = UCItemAdd.Description;
                line.DescriptionAs = UCItemAdd.Description;
                line.UnitPrice = UCItemAdd.UnitPrice;
                line.Quantity = UCItemAdd.Quantity;

                string rMessage;
                _proj.AddSalesLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    Response.Redirect(string.Format("proj-preview.aspx?id={0}&o={1}", ProjectId, 3, false));
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

                if (rblSalesType.SelectedItem.Value == "Product")
                {
                    CreateProjectSalesOneLine();
                }
                else
                {
                    CreateProjectSalesMultiLine();
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

        public int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}