using ERPSYS.BLL;
using System;
using Telerik.Web.UI;

namespace ERPSYS.ERP.t
{
    public partial class searchItems : System.Web.UI.Page
    {
        protected void MyBtn_Click(object sender, EventArgs e)
        {

            rnMessage.Show(GeneralResources.GetStringFromResources("sales_quote_update_success"));
        }
        private void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                //the item is in edit mode    
                GridEditableItem editedItem = e.Item as GridEditableItem;
                //do something here 
            }
            else if (e.Item is GridDataItem)
            {
                //the item is in regular mode
                GridDataItem dataItem = e.Item as GridDataItem;
                //do something here 
            }
        }

        protected void rgQueue_UpdateCommand(object source, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            var Queue = (int)editableItem.GetDataKeyValue("Queue");
            var deleted = (Boolean)editableItem.GetDataKeyValue("Deleted");
            var sourceid = (int)editableItem.GetDataKeyValue("SourceID");
            //retrive entity form the Db
            //using (EnabledDataContext db = new EnabledDataContext())
            //{
            //    var queue = db.Queues.Single(n => n.Queue1 == Queue);
            //    if (queue != null)
            //    {
            //        //update entity's state
            //        editableItem.UpdateValues(queue);
            //        try
            //        {
            //            //submit chanages to Db
            //            db.SubmitChanges();
            //        }
            //        catch (System.Exception)
            //        {
            //        }
            //    }
            //}
        }
    }
}