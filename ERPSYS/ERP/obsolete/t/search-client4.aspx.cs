using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.t
{
    public partial class search_client4 : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rcbClient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dtClientList = _client.GetClientList(e.Text);

            foreach (DataRow dataRow in dtClientList.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["Name"];
                item.Value = dataRow["ClientId"].ToString();
                rcbClient.Items.Add(item);
                item.DataBind();
            }
        }

        protected void cvClient_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            txtContactName.Text = "";

            if (rcbClient.SelectedValue.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }
    }
}