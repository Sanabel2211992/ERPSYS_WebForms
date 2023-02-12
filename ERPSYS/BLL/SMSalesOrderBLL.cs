using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SalesOrderBLL
    {
        private readonly SalesOrderDB _order = new SalesOrderDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetSalesOrderList(DateTime dateStart, DateTime dateEnd, string customerName, string orderNumber, int orderStatusId)
        {
            return _order.GetSalesOrderList(dateStart, dateEnd, customerName, orderNumber, orderStatusId);
        }

        public DataTable GetOpenSalesOrderList()
        {
            return _order.GetOpenSalesOrderList();
        }

        public SalesOrder GetSalesOrderHeader(int orderId)
        {
            DataTable dt = _order.GetSalesOrderHeader(orderId);

            SalesOrder order = new SalesOrder();

            if (dt.Rows.Count == 0)
            {
                order.OrderId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.OrderId = orderId;
            order.OrderNumber = dr["OrderNumber"].ToString();
            order.OrderDate = dr["OrderDate"].ToDate();
            order.CustomerId = dr["CustomerId"].ToInt();
            order.CustomerName = dr["CustomerName"].ToString();
            order.CustomerNameAr = dr["CustomerNameAr"].ToString();
            order.PurchaseOrder = dr["PurchaseOrder"].ToString();
            order.ProjectName = dr["ProjectName"].ToString();
            order.CurrencyId = dr["CurrencyId"].ToInt();
            order.CurrencyCode = dr["CurrencyCode"].ToString();
            order.Remarks = dr["Remarks"].ToString();
            order.Expenses = dr["Expenses"].ToDecimal();
            order.Discount = dr["Discount"].ToDecimal();
            order.Tax = dr["Tax"].ToDecimal();
            order.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            order.SubTotal = dr["SubTotal"].ToDecimal();
            order.GrandTotal = dr["GrandTotal"].ToDecimal();
            order.IsContainGroup = dr["IsContainGroup"].ToBool();
            order.QuoteId = dr["QuoteId"].ToInt();
            order.QuoteNumber = dr["QuoteNumber"].ToString();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["OrderStatus"].ToString();
            order.UserId = dr["UserId"].ToInt();
            order.UserName = dr["UserName"].ToString();


            return order;
        }

        public List<SalesOrderLine> GetSalesOrderLines(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderLines(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();
                line.UnitCost = drLine["UnitCost"].ToDecimal();
                line.TotalCost = drLine["TotalCost"].ToDecimal();
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderMainLines(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderMainLines(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderSubLine(int orderId, int orderLineId)
        {
            DataTable dtLines = _order.GetSalesOrderSubLine(orderId, orderLineId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderDeliveredLines(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderDeliveredLines(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.DeliveredQuantity = drLine["DeliveredQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();
                line.StockQuantity = drLine["StockQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderLinesStatus(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderLinesStatus(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.DeliveredQuantity = drLine["DeliveredQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderMasterLinesStatus(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderMasterLinesStatus(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.LineId = drLine["OrderLineId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.DeliveredQuantity = drLine["DeliveredQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesOrderLine> GetSalesOrderLinesCombinedStatus(int orderId)
        {
            DataTable dtLines = _order.GetSalesOrderLinesCombinedStatus(orderId);

            List<SalesOrderLine> lstLines = new List<SalesOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesOrderLine();

                line.OrderId = drLine["OrderId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.DeliveredQuantity = drLine["DeliveredQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();
                line.StockQuantity = drLine["StockQuantity"].ToDecimal();
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetSalesOrderDeliveryReceipts(int orderId)
        {
            return _order.GetSalesOrderDeliveryReceipts(orderId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesOrder(SalesOrder order, out string rMsg)
        {
            return _order.CreateSalesOrder(order, out rMsg);
        }

        public int CreateSalesOrderFromSalesQuotation(SalesOrder order, int quoteId, out string rMsg)
        {
            return _order.CreateSalesOrderFromSalesQuotation(order, quoteId, out rMsg);
        }

        public int CloneSalesOrder(int salesOrderId, out string rMsg)
        {
            return _order.CloneSalesOrder(salesOrderId, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesOrderHeader(SalesOrder order, out string rMsg)
        {
            return _order.UpdateSalesOrderHeader(order, out rMsg);
        }

        public int UpdateSalesOrderSummary(int orderId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            return _order.UpdateSalesOrderSummary(orderId, expenses, discount, tax, out rMsg);
        }

        public int PostSalesOrder(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.PostSalesOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteSalesOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(SalesOrderLine line, out string rMsg)
        {
            return _order.AddMainLine(line, out rMsg);
        }

        public void UpdateMainLine(SalesOrderLine line, out string rMsg)
        {
            _order.UpdateMainLine(line, out rMsg);
        }

        public void DeleteMainLine(SalesOrderLine line, out string rMsg)
        {
            _order.DeleteMainLine(line, out rMsg);
        }

        public int AddSubLine(SalesOrderLine line, out string rMsg)
        {
            return _order.AddSubLine(line, out rMsg);
        }

        public void UpdateSubLine(SalesOrderLine line, out string rMsg)
        {
            _order.UpdateSubLine(line, out rMsg);
        }

        public void DeleteSubLine(SalesOrderLine line, out string rMsg)
        {
            _order.DeleteSubLine(line, out rMsg);
        }

        public void MoveLineUp(SalesOrderLine line, out string rMsg)
        {
            _order.MoveLineUp(line, out rMsg);
        }

        public void MoveLineDown(SalesOrderLine line, out string rMsg)
        {
            _order.MoveLineDown(line, out rMsg);
        }

        public void ExcludeLineFromGroup(SalesOrderLine line, out string rMsg)
        {
            _order.ExcludeLineFromGroup(line, out rMsg);
        }
    }
}