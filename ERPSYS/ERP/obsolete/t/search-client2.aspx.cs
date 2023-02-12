using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.ERP.t
{
    public partial class search_client2 : System.Web.UI.Page
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
            if (rcbClient.SelectedValue.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        protected void rcbContact_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dtContactList = _client.GetContactList(rcbClient.SelectedValue.ToInt(), e.Text);

            foreach (DataRow dataRow in dtContactList.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["ContactName"];
                item.Value = dataRow["ContactId"].ToString();
                rcbContact.Items.Add(item);
                item.DataBind();
            }
        }

        protected void cvContact_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rcbContact.SelectedValue.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public int ClientId
        {
            get { return hfClientId.Value.ToInteger(); }
        }
    }
}