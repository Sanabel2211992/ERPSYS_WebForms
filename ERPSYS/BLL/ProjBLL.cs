using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System;

namespace ERPSYS.BLL
{
    public class ProjBLL
    {
        private readonly ProjDB _proj = new ProjDB();

        //***************************************************************************************************//SELECT

        public DataTable GetProjectList(DateTime dateStart, DateTime dateEnd ,string projectName, int projectStatusId)
        {
            return _proj.GetProjectList(dateStart, dateEnd, projectName, projectStatusId);
        }

        internal Proj GetProject(int projectId)
        {
            DataTable dt = _proj.GetProject(projectId);

            Proj project = new Proj();

            if (dt.Rows.Count == 0)
            {
                project.ProjectId = -1;
                return project;
            }

            DataRow dr = dt.Rows[0];

            project.ProjectId = projectId;

            project.ProjectName = dr["Name"].ToString();
            project.StartDate = dr["StartDate"].ToDate();
            project.EndDate = dr["EndDate"].ToDate();
            project.Remarks = dr["Remarks"].ToString();
            project.ExpensesTotal = dr["ExpensesTotal"].ToDecimal();
            project.SalesTotal = dr["SalesTotal"].ToDecimal();
            project.UserName = dr["UserName"].ToString();
            project.StatusId = dr["StatusId"].ToInt();
            project.Status = dr["ProjectStatus"].ToString();
            project.CustomerId = dr["CustomerId"].ToInt();
            project.CustomerName = dr["CustomerName"].ToString();
            return project;
        }

        public DataTable GetProjectItemSearchBox(string search)
        {
            return _proj.GetProjectItemSearchBox(search);
        }

        //***************************************************************************************************//INSERT
       
        public int CreateProject(Proj proj, out string rMsg)
        {
            return _proj.CreateProject(proj, out rMsg);
        }

        //***************************************************************************************************//UPDATE
        public int UpdateProjectHeader(Proj proj, out string rMsg)
        {
            return _proj.UpdateProjectHeader(proj, out rMsg);
        }

        //***************************************************************************************************//DELETE



        //***************************************************************************************************//PARCHASELINES  
        public DataTable GetPurchaseInvoiceList(string invoiceNumber)
        {
            return _proj.GetPurchaseInvoiceList(invoiceNumber);
        }

        public DataTable GetProjectPurchaseList(int projectId)
        {
            return _proj.GetProjectPurchaseList(projectId);
        }

        public int AddPurchaseLine(ProjPurchase line, out string rMsg)
        {
            return _proj.AddPurchaseLine(line, out rMsg);
        }

        public void UpdatePurchaseLine(ProjPurchase line, out string rMsg)
        {
            _proj.UpdatePurchaseLine(line, out rMsg);
        }

        public void DeletePurchaseLine(ProjPurchase line, out string rMsg)
        {
            _proj.DeletePurchaseLine(line, out rMsg);
        }

        public int CreatePurchaseFromPurchaseInvoice(int projectId, int purchaseInvoiceId, string xmlLines, out string rMsg)
        {
            return _proj.CreatePurchaseFromPurchaseInvoice(projectId, purchaseInvoiceId, xmlLines, out rMsg);
        }

        //***************************************************************************************************//SALESLINES  

        public DataTable GetSalesInvoiceList(string invoiceNumber)
        {
            return _proj.GetSalesInvoiceList(invoiceNumber);
        }

        public DataTable GetProjectSalesList(int projectId)
        {
            return _proj.GetProjectSalesList(projectId);
        }

        public int AddSalesLine(ProjSales line, out string rMsg)
        {
            return _proj.AddSalesLine(line, out rMsg);
        }

        public void UpdateSalesLine(ProjSales line, out string rMsg)
        {
            _proj.UpdateSalesLine(line, out rMsg);
        }

        public void DeleteSalesLine(ProjSales line, out string rMsg)
        {
            _proj.DeleteSalesLine(line, out rMsg);
        }

        public int CreateSalesFromSalesInvoice(int projectId, int SalesInvoiceId, string xmlLines, out string rMsg)
        {
            return _proj.CreateSalesFromSalesInvoice(projectId, SalesInvoiceId, xmlLines, out rMsg);
        }

        //***************************************************************************************************//EXPENSESLINES

        public DataTable GetProjectExpensesList(int projectId)
        {
            return _proj.GetProjectExpensesList(projectId);
        }

        public int AddExpenseLine(ProjExpense line, out string rMsg)
        {
            return _proj.AddExpenseLine(line, out rMsg);
        }

        public void UpdateExpenseLine(ProjExpense line, out string rMsg)
        {
            _proj.UpdateExpenseLine(line, out rMsg);
        }

        public void DeleteExpenseLine(ProjExpense line, out string rMsg)
        {
            _proj.DeleteExpenseLine(line, out rMsg);
        }

        //***************************************************************************************************//VISITLINES

        public DataTable GetProjectVisitList(int projectId)
        {
            return _proj.GetProjectVisitList(projectId);
        }

        public int AddVisitLine(ProjVisitLine line, out string rMsg)
        {
            return _proj.AddVisitLine(line, out rMsg);
        }

        public void UpdateVisitLine(ProjVisitLine line, out string rMsg)
        {
            _proj.UpdateVisitLine(line, out rMsg);
        }

        public void DeleteVisitLine(ProjVisitLine line, out string rMsg)
        {
            _proj.DeleteVisitLine(line, out rMsg);
        }

        //***************************************************************************************************//SALESLINES

        public DataTable GetProjectSaleList(int projectId)
        {
            return _proj.GetProjectSaleList(projectId);
        }

        public int AddSaleLine(ProjSaleLine line, out string rMsg)
        {
            return _proj.AddSaleLine(line, out rMsg);
        }

        public void UpdateSaleLine(ProjSaleLine line, out string rMsg)
        {
            _proj.UpdateSaleLine(line, out rMsg);
        }

        public void DeleteSaleLine(ProjSaleLine line, out string rMsg)
        {
            _proj.DeleteSaleLine(line, out rMsg);
        }
    }
}