using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class JobOrderBLL
    {
        private readonly JobOrderDB _order = new JobOrderDB();

        //**************************************************************************************************************************//ENUM

        //public enum OrderStatus
        //{
        //    Draft = 1,
        //    Open = 2,
        //    Closed = 3,
        //    Canceled = 4
        //}

        //**************************************************************************************************************************//SELECT

        public DataTable GetJobOrderList(DateTime dateStart, DateTime dateEnd, string customerName, string orderNumber, int statusId)
        {
            return _order.GetJobOrderList(dateStart, dateEnd, customerName, orderNumber, statusId);
        }

        public JobOrder GetJobOrderHeader(int jobOrderId)
        {
            DataTable dt = _order.GetJobOrderHeader(jobOrderId);

            JobOrder jobOrder = new JobOrder();

            if (dt.Rows.Count == 0)
            {
                jobOrder.OrderId = -1;
                return jobOrder;
            }
           
            DataRow dr = dt.Rows[0];

            jobOrder.OrderId = dr["JobOrderId"].ToInt();
            jobOrder.OrderNumber = dr["OrderNumber"].ToString();
            jobOrder.OrderDate = dr["OrderDate"].ToDate();
            jobOrder.CustomerId = dr["CustomerId"].ToInt();
            jobOrder.CustomerName = dr["CustomerName"].ToString();
            jobOrder.ProjectName = dr["ProjectName"].ToString();
            jobOrder.Remarks = dr["Remarks"].ToString();
            jobOrder.SalesOrderId = dr["SalesOrderId"].ToInt();
            jobOrder.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
            jobOrder.StatusId = dr["StatusId"].ToInt();
            jobOrder.Status = dr["OrderStatus"].ToString();
            jobOrder.UserName = dr["UserName"].ToString();

            return jobOrder;
        }

        public List<JobOrderLine> GetJobOrderLines(int jobOrderId)
        {
            DataTable dtLines = _order.GetJobOrderLines(jobOrderId);

            List<JobOrderLine> lstLines = new List<JobOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new JobOrderLine();

                line.OrderId = drLine["JobOrderId"].ToInt();
                line.LineId = drLine["JobOrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Category = drLine["Category"].ToString();
                line.SubCategory = drLine["SubCategory"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.Remarks = drLine["Remarks"].ToString();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<JobOrderLine> GetJobOrderMainLines(int orderId)
        {
            DataTable dtLines = _order.GetJobOrderMainLines(orderId);

            List<JobOrderLine> lstLines = new List<JobOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new JobOrderLine();

                line.OrderId = drLine["JobOrderId"].ToInt();
                line.LineId = drLine["JobOrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<JobOrderLine> GetJobOrderSubLine(int orderId, int orderLineId)
        {
            DataTable dtLines = _order.GetJobOrderSubLine(orderId, orderLineId);

            List<JobOrderLine> lstLines = new List<JobOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new JobOrderLine();

                line.OrderId = drLine["JobOrderId"].ToInt();
                line.LineId = drLine["JobOrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetJobOrderCompactLines(int orderId)
        {
            return _order.GetJobOrderCompactLines(orderId);
        }

        public DataTable GetTransactionsList(int jobOrderId)
        {
            return _order.GetTransactionsList(jobOrderId);
        }

        public DataTable GetManufactureItemsList(int jobOrderId)
        {
            return _order.GetManufactureItemsList(jobOrderId);
        }

        public DataTable GetManufactureItem(int jobOrderId, int itemId)
        {
            return _order.GetManufactureItem(jobOrderId, itemId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateJobOrder(JobOrder order, out string rMsg)
        {
            return _order.CreateJobOrder(order, out rMsg);
        }

        public int CreateJobOrderFromSalesOrder(int salesOrderId, out string rMsg, out int rMessageId)
        {
            return _order.CreateJobOrderFromSalesOrder(salesOrderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateJobOrderHeader(JobOrder order, out string rMsg)
        {
            return _order.UpdateJobOrderHeader(order, out rMsg);
        }

        public int PostJobOrder(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.PostJobOrder(orderId, out rMsg, out rMessageId);
        }

        public int CancelJobOrder(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.CancelJobOrder(orderId, out rMsg, out rMessageId);
        }

        public int CloseJobOrder(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.CloseJobOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteJobOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteJobOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(JobOrderLine line, out string rMsg)
        {
            return _order.AddMainLine(line, out rMsg);
        }

        public void UpdateMainLine(JobOrderLine line, out string rMsg)
        {
            _order.UpdateMainLine(line, out rMsg);
        }

        public void DeleteMainLine(JobOrderLine line, out string rMsg)
        {
            _order.DeleteMainLine(line, out rMsg);
        }

        public int AddSubLine(JobOrderLine line, out string rMsg)
        {
            return _order.AddSubLine(line, out rMsg);
        }

        public void UpdateSubLine(JobOrderLine line, out string rMsg)
        {
            _order.UpdateSubLine(line, out rMsg);
        }

        public void DeleteSubLine(JobOrderLine line, out string rMsg)
        {
            _order.DeleteSubLine(line, out rMsg);
        }
    }
}