using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ProductionOrderBLL
    {
        private readonly ProductionOrderDB _order = new ProductionOrderDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetProductionOrderList(DateTime dateStart, DateTime dateEnd, string joborderNumber, int statusId)
        {
            return _order.GetProductionOrderList(dateStart, dateEnd, joborderNumber, statusId);
        }

        public ProductionOrder GetProductionOrderHeader(int orderId)
        {
            DataTable dt = _order.GetProductionOrderHeader(orderId);

            ProductionOrder order = new ProductionOrder();

            if (dt.Rows.Count == 0)
            {
                order.ProductionOrderId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.ProductionOrderId = dr["ProductionOrderId"].ToInt();
            order.ProductionOrderNumber = dr["OrderNumber"].ToString();
            order.OrderType = dr["OrderType"].ToString();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.ProjectName = dr["ProjectName"].ToString();
            order.StartDate = dr["StartDate"].ToDate();
            order.EndDate = dr["EndDate"].ToDate();
            order.RawMaterialLocation = dr["RMLocation"].ToString();
            order.ProductionLocation = dr["PMLocation"].ToString();
            order.EstimatedDays = dr["WorkingDays"].ToInt();
            order.Remarks = dr["Remarks"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["OrderStatus"].ToString();
            order.UserName = dr["UserName"].ToString();
            order.OrderDate = dr["OrderDate"].ToDate();
            return order;
        }

        public List<ProductionOrderLine> GetProductionOrderLines(int orderId)
        {
            DataTable dtLines = _order.GetProductionOrderLines(orderId);

            List<ProductionOrderLine> lstLines = new List<ProductionOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ProductionOrderLine();

                line.ProductionOrderId = drLine["ProductionOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Category = drLine["Category"].ToString();
                line.SubCategory = drLine["SubCategory"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.Remarks = drLine["Remarks"].ToString();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<ProductionOrderBomLine> GetProductionOrderBomLines(int orderId)
        {
            DataTable dtLines = _order.GetProductionOrderBomLines(orderId);

            List<ProductionOrderBomLine> lstLines = new List<ProductionOrderBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ProductionOrderBomLine();

                line.ProductionOrderId = drLine["ProductionOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Category = drLine["Category"].ToString();
                line.SubCategory = drLine["SubCategory"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetProductionOrderBomLinesQuantityCheck(int orderId)
        {
            return _order.GetProductionOrderBomLinesQuantityCheck(orderId);
        }

        public DataTable GetOrderRawMaterialRequestList(int orderId)
        {
            return _order.GetProductionOrderMaterialTransferList(orderId);
        }

        public DataTable GetOrderRawMaterialRequestLines(int orderId)
        {
            return _order.GetProductionOrderMaterialTransferLines(orderId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateProductionOrder(ProductionOrder order, ProductionOrderLine line, out string rMsg)
        {
            return _order.CreateProductionOrder(order, line, out rMsg);
        }

        public void AddProductRawMaterials(int orderId, int itemId, out string rMsg)
        {
            _order.AddProductRawMaterials(orderId, itemId, out rMsg);
        }

        public int CreateRawMaterialTransfer(MaterialTransfer request, out string rMsg)
        {
            return _order.CreateRawMaterialTransfer(request, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public void PostProductionOrder(ProductionOrder order, out string rMsg)
        {
            _order.PostProductionOrder(order, out rMsg);
        }

        public void CancelProductionOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.CancelProductionOrder(orderId, out rMsg, out rMessageId);
        }

        public void CloseFullyProductionOrder(ProductionOrder order, out string rMsg)
        {
            _order.CloseFullyProductionOrder(order, out rMsg);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteProductionOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteProductionOrder(orderId, out rMsg, out rMessageId);
        }

        public void DeleteProductRawMaterials(int orderId, int itemId, out string rMessage)
        {
            _order.DeleteProductRawMaterials(orderId,itemId, out rMessage);
        }

        //**************************************************************************************************************************//LINES

        public void UpdateOrderLine(ProductionOrderLine line, out string rMsg)
        {
            _order.UpdateOrderLine(line, out rMsg);
        }

        public int AddRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            return _order.AddRawMaterialLine(line, out rMsg);
        }

        public void UpdateRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            _order.UpdateRawMaterialLine(line, out rMsg);
        }

        public void DeleteRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            _order.DeleteRawMaterialLine(line, out rMsg);
        }
    }
}