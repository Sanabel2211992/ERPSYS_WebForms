using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ModificationOrderBLL
    {
        private readonly ModificationOrderDB _order = new ModificationOrderDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetModificationOrderList(DateTime dateStart, DateTime dateEnd, string joborderNumber, int statusId)
        {
            return _order.GetModificationOrderList(dateStart, dateEnd, joborderNumber, statusId);
        }

        public ModificationOrder GetModificationOrderHeader(int orderId)
        {
            DataTable dt = _order.GetModificationOrderHeader(orderId);

            ModificationOrder order = new ModificationOrder();

            if (dt.Rows.Count == 0)
            {
                order.ModificationOrderId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.ModificationOrderId = dr["ModificationOrderId"].ToInt();
            order.OrderTypeId = dr["OrderTypeId"].ToInt();
            order.ModificationOrderNumber = dr["OrderNumber"].ToString();
            order.OrderType = dr["OrderType"].ToString();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.ProjectName = dr["ProjectName"].ToString();
            order.Remarks = dr["Remarks"].ToString();
            order.StartDate = dr["StartDate"].ToDate();
            order.EndDate = dr["EndDate"].ToDate();
            order.OrderDate = dr["OrderDate"].ToDate();
            order.InputLocationId = dr["InputLocationId"].ToInt();
            order.InputLocation = dr["InputLocation"].ToString();
            order.OutputLocationId = dr["OutputLocationId"].ToInt();
            order.OutputLocation = dr["OutputLocation"].ToString();
            order.BomLocationId = dr["BomLocationId"].ToInt();
            order.BomLocation = dr["BomLocation"].ToString();
            order.EstimatedDays = dr["WorkingDays"].ToInt();
            order.Remarks = dr["Remarks"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["OrderStatus"].ToString();
            order.UserName = dr["UserName"].ToString();

            return order;
        }

        public List<ModificationOrderLine> GetInputModificationOrderLines(int orderId)
        {
            DataTable dtLines = _order.GetInputModificationOrderLines(orderId);

            List<ModificationOrderLine> lstLines = new List<ModificationOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ModificationOrderLine();

                line.ModificationOrderId = drLine["ModificationOrderId"].ToInt();
                line.LineId = drLine["ModificationOrderLineId"].ToInt();
                line.InputItemId = drLine["ItemId"].ToInt();
                line.InputPartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.InputItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.InputDescription = drLine["Description"].ToString();
                line.InputCategory = drLine["Category"].ToString();
                line.InputSubCategory = drLine["SubCategory"].ToString();
                line.InputQuantity = drLine["Quantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<ModificationOrderLine> GetOutputModificationOrderLines(int orderId)
        {
            DataTable dtLines = _order.GetOutputModificationOrderLines(orderId);

            List<ModificationOrderLine> lstLines = new List<ModificationOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ModificationOrderLine();

                line.ModificationOrderId = drLine["ModificationOrderId"].ToInt();
                line.LineId = drLine["ModificationOrderLineId"].ToInt();
                line.OutputItemId = drLine["ItemId"].ToInt();
                line.OutputPartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.OutputItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.OutputDescription = drLine["Description"].ToString();
                line.OutputCategory = drLine["Category"].ToString();
                line.OutputSubCategory = drLine["SubCategory"].ToString();
                line.OutputQuantity = drLine["Quantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetModificationOrderBomLinesQuantityCheck(int orderId)
        {
            return _order.GetModificationOrderBomLinesQuantityCheck(orderId);
        }

        public List<ModificationOrderBomLine> GetModificationOrderBomLines(int orderId)
        {
            DataTable dtLines = _order.GetModificationOrderBomLines(orderId);

            List<ModificationOrderBomLine> lstLines = new List<ModificationOrderBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ModificationOrderBomLine();

                line.ModificationOrderId = drLine["ModificationOrderId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();
                line.ItemBomId = drLine["ItemId"].ToInt();
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

        //**************************************************************************************************************************//INSERT

        public int CreateModificationOrder(ModificationOrder order, ModificationOrderLine line, out string rMsg)
        {
            return _order.CreateModificationOrder(order, line, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateModificationOrderHeader(ModificationOrder order, out string rMsg)
        {
            return _order.UpdateModificationOrderHeader(order, out rMsg);
        }

        public int PostModificationOrder(ModificationOrder order, out string rMsg)
        {
            return _order.PostModificationOrder(order, out rMsg);
        }

        internal void CancelModificationOrder(int orderId, out string rMessage, out int rMessageId)
        {
            _order.CancelModificationOrder(orderId, out rMessage, out rMessageId);
        }

        public void CloseFullyModificationOrder(ModificationOrder order, out string rMsg)
        {
            _order.CloseFullyModificationOrder(order, out rMsg);
        }

        //****************************************************************************************************************************//DELETE

        public void DeleteModificationOrder(int orderId, out string rMsg, out int rMessageId)
        {
            _order.DeleteModificationOrder(orderId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public void UpdateInputOrderLine(ModificationOrderLine line, out string rMsg)
        {
            _order.UpdateInputOrderLine(line, out rMsg);
        }

        public void UpdateOutputOrderLine(ModificationOrderLine line, out string rMsg)
        {
            _order.UpdateOutputOrderLine(line, out rMsg);
        }

        public int AddRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            return _order.AddRawMaterialLine(line, out rMsg);
        }

        public void UpdateRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            _order.UpdateRawMaterialLine(line, out rMsg);
        }

        public void DeleteRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            _order.DeleteRawMaterialLine(line, out rMsg);
        }

    }
}