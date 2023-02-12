using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class AssemblyOrderBLL
    {
        private readonly AssemblyOrderDB _order = new AssemblyOrderDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetAssemblyOrderList(DateTime dateStart, DateTime dateEnd, string orderNumber, string assemblyItem, int orderStatusId)
        {
            return _order.GetAssemblyOrderList(dateStart, dateEnd, orderNumber, assemblyItem, orderStatusId);
        }

        public AssemblyOrder GetAssemblyOrderHeader(int orderId)
        {
            DataTable dt = _order.GetAssemblyOrderHeader(orderId);

            AssemblyOrder order = new AssemblyOrder();

            if (dt.Rows.Count == 0)
            {
                order.AssemblyOrderId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.AssemblyOrderId = orderId;
            order.AssemblyOrderNumber = dr["AssemblyOrderNumber"].ToString();
            order.OrderDate = dr["OrderDate"].ToDate();
            order.ItemLocationId = dr["ItemLocationId"].ToInt();
            order.ItemLocation = dr["ItemLocation"].ToString();
            order.BomLocationId = dr["BomLocationId"].ToInt();
            order.BomLocation = dr["BomLocation"].ToString();
            order.Remarks = dr["Remarks"].ToString();
            order.ItemId = dr["ItemId"].ToInt();
            order.PartNumber = dr["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
            order.ItemCode = dr["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
            order.Description = dr["Description"].ToString().ReplaceWhenNullOrEmpty("-");
            order.Quantity = dr["Quantity"].ToDecimal();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.UserName = dr["DisplayName"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["OrderStatus"].ToString();

            return order;
        }
        
        public List<AssemblyBomLine> GetAssemblyOrderBomLines(int orderId)
        {
            DataTable dtLines = _order.GetAssemblyOrderBomLines(orderId);

            List<AssemblyBomLine> lstLines = new List<AssemblyBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new AssemblyBomLine();

                line.AssemblyOrderId = drLine["AssemblyOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.ItemBomId = drLine["ItemBomId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Uom = drLine["Uom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<AssemblyBomLine> GetAssemblyOrderBomLinesStatus(int orderId)
        {
            DataTable dtLines = _order.GetAssemblyOrderBomLinesStatus(orderId);

            List<AssemblyBomLine> lstLines = new List<AssemblyBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new AssemblyBomLine();

                line.AssemblyOrderId = drLine["AssemblyOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.ItemBomId = drLine["ItemBomId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.RequestedQuantity = drLine["RequestedQuantity"].ToDecimal();
                line.StockQuantity = drLine["StockQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        //**************************************************************************************************************************//INSERT

        public int CreateAssemblyOrder(AssemblyOrder order , out string rMsg)
        {
            return _order.CreateAssemblyOrder(order, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateAssemblyOrderHeader(AssemblyOrder order, out string rMsg)
        {
            return _order.UpdateAssemblyOrderHeader(order, out rMsg);
        }

        public int PostAssemblyOrder(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.PostAssemblyOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteAssemblyOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteAssemblyOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddBomLine(AssemblyBomLine line, out string rMsg)
        {
            return _order.AddBomLine(line, out rMsg);
        }

        public void UpdateBomLine(AssemblyBomLine line, out string rMsg)
        {
            _order.UpdateBomLine(line, out rMsg);
        }

        public void DeleteBomLine(AssemblyBomLine line, out string rMsg)
        {
            _order.DeleteBomLine(line, out rMsg);
        }


        //**************************************************************************************************************************//SELECT
        public DataTable GetAssemblyOrderListX(DateTime dateStart, DateTime dateEnd, string orderNumber, int orderStatusId)
        {
            return _order.GetAssemblyOrderListX(dateStart, dateEnd, orderNumber, orderStatusId);
        }

        public DataTable GetAssemblyOrderLineX(int orderId)
        {
            return _order.GetAssemblyOrderLineX(orderId);
        }

        public AssemblyOrder GetAssemblyOrderHeaderX(int orderId)
        {
            DataTable dt = _order.GetAssemblyOrderHeaderX(orderId);

            AssemblyOrder order = new AssemblyOrder();

            if (dt.Rows.Count == 0)
            {
                order.AssemblyOrderId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.AssemblyOrderId = orderId;
            order.AssemblyOrderNumber = dr["AssemblyOrderNumber"].ToString();
            order.OrderDate = dr["OrderDate"].ToDate();
            order.ItemLocationId = dr["ItemLocationId"].ToInt();
            order.ItemLocation = dr["ItemLocation"].ToString();
            order.BomLocationId = dr["BomLocationId"].ToInt();
            order.BomLocation = dr["BomLocation"].ToString();
            order.Remarks = dr["Remarks"].ToString();
            order.ItemId = dr["ItemId"].ToInt();
            order.PartNumber = dr["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
            order.ItemCode = dr["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
            order.Description = dr["Description"].ToString().ReplaceWhenNullOrEmpty("-");
            order.Quantity = dr["Quantity"].ToDecimal();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.ProjectName = dr["ProjectName"].ToString();
            order.UserName = dr["DisplayName"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["OrderStatus"].ToString();

            return order;
        }

        public List<AssemblyBomLine> GetAssemblyOrderBomLinesX(int orderId)
        {
            DataTable dtLines = _order.GetAssemblyOrderBomLinesX(orderId);

            List<AssemblyBomLine> lstLines = new List<AssemblyBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new AssemblyBomLine();

                line.AssemblyOrderId = drLine["AssemblyOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.ItemBomId = drLine["ItemBomId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Category = drLine["Category"].ToString();
                line.SubCategory = drLine["SubCategory"].ToString();
                line.Uom = drLine["Uom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.RequestedQuantity = drLine["TotalQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetAssemblyOrderBomLinesQuantityCheckX(int orderId)
        {
            return _order.GetAssemblyOrderBomLinesQuantityCheckX(orderId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateAssemblyOrderX(AssemblyOrder order, out string rMsg)
        {
            return _order.CreateAssemblyOrderX(order, out rMsg);
        }

        public void AddAssemblyOrderProductMaterialsX(int orderId, int itemId, out string rMsg)
        {
            _order.AddAssemblyOrderProductMaterialsX(orderId, itemId, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateAssemblyOrderHeaderX(AssemblyOrder order, out string rMsg)
        {
            return _order.UpdateAssemblyOrderHeaderX(order, out rMsg);
        }

        public int PostAssemblyOrderX(int orderId, out string rMsg, out int rMessageId)
        {
            return _order.PostAssemblyOrderX(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteAssemblyOrderX(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteAssemblyOrderX(orderId, out rMsg, out rMessageId);
        }

        public void DeleteAssemblyOrderProductMaterialsX(int orderId, int itemId, out string rMessage)
        {
            _order.DeleteAssemblyOrderProductMaterialsX(orderId, itemId, out rMessage);
        }

        //**************************************************************************************************************************//LINES

        public void UpdateOrderLineX(AssemblyOrder line, out string rMsg)
        {
            _order.UpdateOrderLineX(line, out rMsg);
        }

        public int AddBomLineX(AssemblyBomLine line, out string rMsg)
        {
            return _order.AddBomLineX(line, out rMsg);
        }

        public void UpdateBomLineX(AssemblyBomLine line, out string rMsg)
        {
            _order.UpdateBomLineX(line, out rMsg);
        }

        public void DeleteBomLineX(AssemblyBomLine line, out string rMsg)
        {
            _order.DeleteBomLineX(line, out rMsg);
        }

    }
}