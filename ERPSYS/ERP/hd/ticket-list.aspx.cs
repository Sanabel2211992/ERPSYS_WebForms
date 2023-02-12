using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.IO;

namespace ERPSYS.ERP.hd
{
    public partial class ticket_list : System.Web.UI.Page
    {
        readonly TicketBLLx _ticket = new TicketBLLx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetLookupTables();
            }
        }

        private void ShowMessages()
        {
            try
            {
                //switch (Request.QueryString["o"])
                //{
                //    case "3":
                //        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources(""));
                //        break;
                //}
                //switch (Request.QueryString["e"])
                //{
                //    case "1":
                //        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources(""));
                //        break;
                //}
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLookupTables()
        {
            //LookupBLL lookup = new LookupBLL();

            //ddlTicketStatus.DataTextField = "Name";
            //ddlTicketStatus.DataValueField = "StatusId";
            //ddlTicketStatus.DataSource = lookup.GetS();
            //ddlTicketStatus.DataBind();
            //ddlTicketStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgTicketList.Rebind();
        }

        private void GetTicketList()
        {
            try
            {
                rgTicketList.DataSource = _ticket.GetTicketList(DateStart, DateEnd, TicketNumber, StatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgTicketList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgTicketList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GetTicketList();
        }

        protected void rgTicketList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                System.Web.UI.WebControls.Image imgUser = (System.Web.UI.WebControls.Image)dataItem.FindControl("imgUser");

                imgUser.ImageUrl = UserProfileBLL.GetProfileSmallPicture(dataItem["EntryUserId"].Text);
            }

            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                //get the Hyperlink using the Column uniqueName
                HyperLink hyperLink = (HyperLink)dataItem["TicketNumber"].Controls[0];
                string ticketId = dataItem["TicketId"].Text;
                hyperLink.NavigateUrl = string.Format("ticket-form.aspx?id={0}", ticketId);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ticket-create.aspx", false);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;
                TicketNumber = txtTicketNumber.Text.ToTrimString();
                StatusId = ddlTicketStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : "1/1/2900".ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

        public string TicketNumber
        {
            get { return ViewState["TicketNumber"] != null ? ViewState["TicketNumber"].ToString() : ""; }
            set { ViewState["TicketNumber"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["OrderStatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
    }
}