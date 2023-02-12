using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Threading;
using ERPSYS.Controls.Common;
using System.Collections;
using ERPSYS.Controls.HierarchyItems.PROJ;

namespace ERPSYS.ERP.proj
{
    public partial class ProjPreview : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgProjectPurchaseList, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgProjectSalesList, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgProjectExpenseList, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgProjectVisitList, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
            }

            if (!IsPostBack)
            {
                BindData();
                ShowMessages();
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

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("proj_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("proj_purchase_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("proj_visit_add_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("proj_sales_add_success"));
                        break;
                }
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
            lblStatus.Text = project.Status;
            lblEndDate.Text = project.EndDate.ToDateString();
            txtProjectName.Text = project.ProjectName;
            UCDatePicker.DateValue = project.StartDate;
            txtRemarks.Text = project.Remarks;
            txtCustomerName.Text = project.CustomerName;
        }

        protected void UpdateProjectHeader()
        {
            Proj proj = new Proj();

            proj.ProjectId = ProjectId;
            proj.StartDate = UCDatePicker.DateValue;
            proj.CustomerId = hfCustomerId.Value.ToInt();
            proj.CustomerName = txtCustomerName.Text.ToTrimString();
            proj.ProjectName = txtProjectName.Text.ToTrimString();
            proj.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var projectId = _proj.UpdateProjectHeader(proj, out rMessage);

            if (rMessage != string.Empty || projectId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("proj_update_success"));
        }


        //**************  Purchase Operations *****************//
        protected void rgProjectPurchaseList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgProjectPurchaseList.DataSource = _proj.GetProjectPurchaseList(ProjectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectPurchaseList_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                int PurchaseLineId = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["PurchaseId"].ToInt();
                decimal UnitPrice = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["UnitPrice"].ToDecimal();
                decimal Quantity = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["Quantity"].ToDecimal();

                ProjPurchase expense = new ProjPurchase();

                if (e.Item is GridDataItem && e.Item.IsInEditMode)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    RadNumericTextBox rntxtUnitPrice = (RadNumericTextBox)item.FindControl("txtUnitPrice");
                    RadNumericTextBox rntxtQuantity = (RadNumericTextBox)item.FindControl("txtQuantity");
                    if (rntxtUnitPrice.Text.IsNotNullOrEmpty())
                    {
                        expense.UnitPrice = rntxtUnitPrice.Text.ToDecimal();
                    }
                    else
                    {
                        expense.UnitPrice = UnitPrice;
                    }
                    if (rntxtQuantity.Text.IsNotNullOrEmpty())
                    {
                        expense.Quantity = rntxtQuantity.Text.ToDecimal();
                    }
                    else
                    {
                        expense.Quantity = Quantity;
                    }
                }

                expense.PurchaseId = PurchaseLineId;
                expense.ProjectId = ProjectId;

                string rMessage;
                _proj.UpdatePurchaseLine(expense, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Expense");
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectPurchaseList_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem dItem = ((GridEditableItem)(e.Item));
                int expenseLineId = dItem.GetDataKeyValue("PurchaseId").ToInt();

                ProjPurchase line = new ProjPurchase();

                line.ProjectId = ProjectId;
                line.PurchaseId = expenseLineId;

                string rMessage;
                _proj.DeletePurchaseLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Expense");
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }


        //**************  Sales Operations *****************//
        protected void rgProjectSalesList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgProjectSalesList.DataSource = _proj.GetProjectSalesList(ProjectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectSalesList_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;
                int SalesLineId = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["SalesId"].ToInt();
                decimal UnitPrice = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["UnitPrice"].ToDecimal();
                decimal Quantity = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["Quantity"].ToDecimal();

                ProjSales expense = new ProjSales();

                if (e.Item is GridDataItem && e.Item.IsInEditMode)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    RadNumericTextBox rntxtUnitPrice = (RadNumericTextBox)item.FindControl("txtUnitPrice");
                    RadNumericTextBox rntxtQuantity = (RadNumericTextBox)item.FindControl("txtQuantity");
                    if (rntxtUnitPrice.Text.IsNotNullOrEmpty())
                    {
                        expense.UnitPrice = rntxtUnitPrice.Text.ToDecimal();
                    }
                    else
                    {
                        expense.UnitPrice = UnitPrice;
                    }
                    if (rntxtQuantity.Text.IsNotNullOrEmpty())
                    {
                        expense.Quantity = rntxtQuantity.Text.ToDecimal();
                    }
                    else
                    {
                        expense.Quantity = Quantity;
                    }
                }

                expense.SalesId = SalesLineId;
                expense.ProjectId = ProjectId;

                string rMessage;
                _proj.UpdateSalesLine(expense, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Expense");
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectSalesList_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem dItem = ((GridEditableItem)(e.Item));
                int expenseLineId = dItem.GetDataKeyValue("SalesId").ToInt();

                ProjSales line = new ProjSales();

                line.ProjectId = ProjectId;
                line.SalesId = expenseLineId;

                string rMessage;
                _proj.DeleteSalesLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Expense");
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }


        //**************  Expenses Operations *****************//

        protected void rgProjectExpenseList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgProjectExpenseList.DataSource = _proj.GetProjectExpensesList(ProjectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectExpenseList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgProjectExpenseList.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/PROJ/UCAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;

                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/PROJ/UCEdit.ascx";
                    break;
            }
        }

        protected void rgProjectExpenseList_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            try
            {
                string description = ((UCAdd)uc).Description;
                decimal amount = ((UCAdd)uc).Amount;

                AddExpenseLine(description, amount);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectExpenseList_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int expenseId = eItem.GetDataKeyValue("ExpenseLineId").ToInt();
                string description = ((UCEdit)uc).Description;
                decimal amount = ((UCEdit)uc).Amount;

                UpdateExpenseLine(expenseId, description, amount);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectExpenseList_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                int lineId = dItem.GetDataKeyValue("ExpenseLineId").ToInt();

                DeleteExpenseLine(lineId);
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddExpenseLine(string description, decimal amount)
        {
            ProjExpense line = new ProjExpense();

            line.ProjectId = ProjectId;
            line.Description = description;
            line.Amount = amount;

            string rMessage;
            _proj.AddExpenseLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("proj_expense_add_success"), "Add Expense");
            }

            rgProjectExpenseList.Rebind();
        }

        protected void UpdateExpenseLine(int expenseId, string description, decimal amount)
        {
            ProjExpense line = new ProjExpense();

            line.ProjectId = ProjectId;
            line.ExpenseId = expenseId;
            line.Description = description;
            line.Amount = amount;

            string rMessage;
            _proj.UpdateExpenseLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("proj_expense_update_success"), "Update Expense");
            }
        }

        protected void DeleteExpenseLine(int expenseId)
        {
            ProjExpense line = new ProjExpense();

            line.ExpenseId = expenseId;
            line.ProjectId = ProjectId;

            string rMessage;
            _proj.DeleteExpenseLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("proj_expense_delete_success"), "Delete Expense");
            }
        }

        //**************  Visit Operations *****************//

        protected void rgProjectVisitList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgProjectVisitList.DataSource = _proj.GetProjectVisitList(ProjectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectVisitList_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem editItem = e.Item as GridEditableItem;
                Hashtable newValues = new Hashtable();
                e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editItem);

                int VisitId = newValues["VisitId"].ToInt();
                DateTime Date = newValues["Date"].ToDate();
                string EmployeeName = newValues["EmployeeName"].ToString();
                string Remarks = newValues["Remarks"].ToString();

                ProjVisitLine visit = new ProjVisitLine();

                visit.VisitId = VisitId;
                visit.ProjectId = ProjectId;
                visit.Date = Date;
                visit.EmployeeName = EmployeeName;
                visit.Remarks = Remarks;

                string rMessage;
                _proj.UpdateVisitLine(visit, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("proj_visit_updat_success"), "Update Visit");
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProjectVisitList_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem dItem = ((GridEditableItem)(e.Item));
                int visitLineId = dItem.GetDataKeyValue("VisitId").ToInt();

                ProjVisitLine line = new ProjVisitLine();

                line.ProjectId = ProjectId;
                line.VisitId = visitLineId;

                string rMessage;
                _proj.DeleteVisitLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("proj_visit_delete_success"), "Delete Visit");
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }


        //************** Buttons Click *****************//

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
                    Response.Redirect(string.Format("proj-list.aspx"), false);
                    break;
                case "edit":
                    Response.Redirect(string.Format("proj-form.aspx?o=edit&id={0}", ProjectId), false);
                    break;
                case "detailsreport":
                    Response.Redirect(string.Format("proj-details-report.aspx?id={0}", ProjectId), false);
                    break;
                case "summaryreport":
                    Response.Redirect(string.Format("proj-summary-report.aspx?id={0}", ProjectId), false);
                    break;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (!IsValid)
                    return;

                UpdateProjectHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAddPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-purchase.aspx?o=edit&id={0}", ProjectId), false);
        }

        protected void lnkbtnAddSales_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-sales.aspx?o=edit&id={0}", ProjectId), false);
        }

        protected void lnkbtnAddVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("proj-visit.aspx?o=edit&id={0}", ProjectId), false);
        }

        //************************************** Properties ************************************//

        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }
    }
}