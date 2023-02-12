using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class MaterialTransferBLL
    {
        private readonly MaterialTransferDB _transfer = new MaterialTransferDB();

        //**************************************************************************************************************************//SELECT

        public MaterialTransfer GetMaterialTransferHeader(int transferId)
        {
            DataTable dt = _transfer.GetMaterialTransferHeader(transferId);

            MaterialTransfer order = new MaterialTransfer();

            if (dt.Rows.Count == 0)
            {
                order.MaterialTransferId = -1;
                return order;
            }

            DataRow dr = dt.Rows[0];

            order.MaterialTransferId = dr["MaterialTransferId"].ToInt();
            order.MaterialTransferNumber = dr["MaterialTransferNumber"].ToString();
            order.JobOrderId = dr["JobOrderId"].ToInt();
            order.JobOrderNumber = dr["JobOrderNumber"].ToString();
            order.ProjectName = dr["ProjectName"].ToString();
            order.OrderId = dr["OrderId"].ToInt();
            order.OrderNumber = dr["OrderNumber"].ToString();
            order.OrderTypeId = dr["OrderTypeId"].ToInt();
            order.OrderType = dr["OrderType"].ToString();
            order.FromLocationId = dr["FromLocationId"].ToInt();
            order.FromLocation = dr["FromLocation"].ToString();
            order.ToLocationId = dr["ToLocationId"].ToInt();
            order.ToLocation = dr["ToLocation"].ToString();
            order.TransferTypeId = dr["Direction"].ToInt();
            order.TransferType = dr["TransferType"].ToString();
            order.Remarks = dr["Remarks"].ToString();
            order.StatusId = dr["StatusId"].ToInt();
            order.Status = dr["RequestStatus"].ToString();
            order.PreparedBy = dr["PreparedBy"].ToString();
            order.PreparedDate = dr["PreparedDate"].ToDate();

            return order;
        }

        public List<MaterialTransferLine> GetMaterialTransferLines(int transferId)
        {
            DataTable dtLines = _transfer.GetMaterialTransferLines(transferId);

            List<MaterialTransferLine> lstLines = new List<MaterialTransferLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new MaterialTransferLine();

                line.MaterialTransferId = drLine["MaterialTransferId"].ToInt();
                line.LineId = drLine["LineId"].ToInt();

                line.OrderId = drLine["OrderId"].ToInt();
                line.OrderItemId = drLine["OrderItemId"].ToInt();
                line.OrderItemQuantity = drLine["OrderItemQuantity"].ToDecimal();

                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Category = drLine["Category"].ToString();
                line.SubCategory = drLine["SubCategory"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.TotalQuantity = drLine["TotalQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetMaterialTransferLinesQuantityCheck(int transferId)
        {
            return _transfer.GetMaterialTransferLinesQuantityCheck(transferId);
        }

        //**************************************************************************************************************************//UPDATE

        public void PostMaterialTransfer(int transferId, out string rMsg, out int rMessageId)
        {
            _transfer.PostMaterialTransfer(transferId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteMaterialTransfer(int transferId, out string rMsg, out int rMessageId)
        {
            _transfer.DeleteMaterialTransfer(transferId, out rMsg, out rMessageId);
        }

        //*************************************************************************************************************************//LINES

        public int AddMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            return _transfer.AddMaterialTransferLine(line, out rMsg);
        }

        public void UpdateMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            _transfer.UpdateMaterialTransferLine(line, out rMsg);
        }

        public void DeleteMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            _transfer.DeleteMaterialTransferLine(line, out rMsg);
        }
    }
}