using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class MaterialTransferDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetMaterialTransferHeader(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_MaterialTransfer_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMaterialTransferLines(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_MaterialTransfer_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMaterialTransferLinesQuantityCheck(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_MaterialTransfer_Lines_QuantityCheck_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//UPDATE

        public void PostMaterialTransfer(int transferId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_MaterialTransfer_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("request_rm_inactive");
                    rMsgId = 21;    
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("request_rm_no_records");
                    rMsgId = 22;
                    break;
                case 11:
                    rMsg = GeneralResources.GetStringFromResources("request_rm_insufficient_quantity");
                    rMsgId = 23;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    rMsgId = -1;
                    break;
            }
        }

        //****************************************************************************************************************************//DELETE

        public void DeleteMaterialTransfer(int transferId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_MaterialTransfer_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("request_rm_inactive");
                    rMsgId = 32;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.MaterialTransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderItemId", line.OrderItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderItemQuantity", line.OrderItemQuantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_MaterialTransfer_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("request_rm_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("request_rm_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_main_item_exists");
                        break;
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }

            return newId;
        }

        public void UpdateMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.MaterialTransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_MaterialTransfer_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("request_rm_inactive");
                        break;
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }
        }

        public void DeleteMaterialTransferLine(MaterialTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.MaterialTransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_MaterialTransfer_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("request_rm_inactive");
                        break;
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }
        }
    }
}