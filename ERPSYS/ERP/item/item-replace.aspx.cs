using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System.Data;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ERPSYS.ERP.item
{
    public partial class item_replace : System.Web.UI.Page
    {
     
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void rsbItemRep_Load(object sender, EventArgs e)
        {
            rsbItemRep.DataSource = new DataTable();
        }

        protected void rsbItemAlt_Load(object sender, EventArgs e)
        {
            rsbItemAlt.DataSource = new DataTable();
        }

        protected void rsbItemRep_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                OldItemId = e.Value.ToInt();
                lblDescriptionRep.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                lblPartNumberRep.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                lblItemCodeRep.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                pnlOldItem.Visible = true;
            }
        }

        protected void rsbItemAlt_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                NewItemId = e.Value.ToInt();
                lblDescriptionAlt.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                lblPartNumberAlt.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                lblItemCodeAlt.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                pnlNewItem.Visible = true;
            }
        }

        protected void rsbItemRep_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {

            string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

            rsbItemRep.DataSource = _item.GetItemBomSearchBox2(-1, -1, -1, -1, search);
        }

        protected void rsbItemAlt_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {

            string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

            rsbItemAlt.DataSource = _item.GetItemBomSearchBox2(-1, -1, -1, -1, search);
        }

        protected void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                string remarks = txtRemarks.Text.ToString();
                string rMessage;
                _item.ReplaceItem(OldItemId, NewItemId, remarks, out rMessage);

                if (rMessage != string.Empty )
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }
                else
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_replaced_success"));
                }
                
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        public int OldItemId
        {
            get { return ViewState["OldItemId"] != null ? ViewState["OldItemId"].ToInt() : -1; }
            set { ViewState["OldItemId"] = value; }
        }
        public int NewItemId
        {
            get { return ViewState["NewItemId"] != null ? ViewState["NewItemId"].ToInt() : -1; }
            set { ViewState["NewItemId"] = value; }
        }
    }
}