using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;


namespace ERPSYS.ERP.t.Grid
{
    public partial class ContextMenu : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            //rgUserList.HeaderContextMenu.ItemCreated += this.HeaderContextMenu_ItemCreated;
        }
        //private void HeaderContextMenu_ItemCreated(object sender, RadMenuEventArgs e)
        //{

        //    //switch ((e.Item.Text))
        //    //{
        //    //    case "Group By":
        //    //        e.Item.Visible = false;
        //    //         break;

        //    //    case "Ungroup":
        //    //        e.Item.Visible = false;
        //    //        break;

        //    //    case "Sort Ascending":
        //    //        e.Item.Visible = false;
        //    //         break;

        //    //    case "Sort Descending":
        //    //        e.Item.Visible = false;
        //    //        break;

        //    //    case "Clear Sorting":
        //    //        e.Item.Visible = false;
        //    //        break;

        //    //    //case "Columns":
                    
        //    //    //    break;

        //    //}
        //}

        protected void rgUserList_Init(object sender, EventArgs e)
        {
            //var grid = (RadGrid)sender;
            //grid.PageSize = CommonMember.GridPageSize;
            rgUserList.HeaderContextMenu.ItemCreated += HeaderContextMenu_ItemCreated;
        }

        void HeaderContextMenu_ItemCreated(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value.Contains("Item"))
            {
                var checkBox = e.Item.Controls[0] as CheckBox;
                if (checkBox != null) checkBox.Enabled = false;
            }
        } 

        protected void rgUserList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetUserList();
        }

        private void GetUserList()
        {
            try
            {
                //rgUserList.DataSource = _user.GetUserList(Name, DepartmentId, StatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }


        //************************************** Properties ************************************//

        public string Name
        {
            get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
            set { ViewState["Name"] = value; }
        }

        public int DepartmentId
        {
            get { return ViewState["DepartmentId"] != null ? ViewState["DepartmentId"].ToInt() : -1; }
            set { ViewState["DepartmentId"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }

        protected void rgUserList_PreRender(object sender, EventArgs e)
        {
            //if (rgUserList.EditIndexes.Count > 0 || rgUserList.MasterTableView.IsItemInserted)
            //{
            //    GridColumn col1 = rgUserList.MasterTableView.GetColumn("EditCommandColumn");
            //    col1.Visible = true;
            //}
            //else
            //{
            //    GridColumn col2 = rgUserList.MasterTableView.GetColumn("EditCommandColumn");
            //    col2.Visible = false;
            //}
        }
    }
}