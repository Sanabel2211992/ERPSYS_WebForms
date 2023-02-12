using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.ERP.t
{
    public partial class search_client3 : System.Web.UI.Page
    {
       readonly CRMBLL crm = new CRMBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rsbClient_Load(object sender, EventArgs e)
        {
            rsbClient.DataSource = new DataTable();
        }

        protected void rsbClient_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            rsbClient.DataSource = crm.GetClientItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        }

        protected void rsbClient_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                ClientId = e.Value.ToInteger();
            }
        }

        protected void rsbContact_Load(object sender, EventArgs e)
        {
            rsbContact.DataSource = new DataTable();
        }

        protected void rsbContact_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            rsbContact.DataSource = crm.GetContactItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"), ClientId);
        }

        //************************************** Properties ************************************//
        public int ClientId
        {
            get { return ViewState["ClientId"] != null ? ViewState["ClientId"].ToInt() : -1; }
            set { ViewState["ClientId"] = value; }
        }
    }
}