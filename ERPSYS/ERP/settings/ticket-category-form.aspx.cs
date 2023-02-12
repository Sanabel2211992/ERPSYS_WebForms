using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System;
using System.Threading;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ticket_category_form : System.Web.UI.Page
    {
        readonly TicketBLLx _ticket = new TicketBLLx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetCategoryDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetCategoryDetails(int categoryId)
        {
            try
            {
                TicketCategory category = _ticket.GetCategoryDetails(categoryId);

                if (category.CategoryId <= 0)
                {
                    Response.Redirect(string.Format("ticket-category-list.aspx?e={0}", 1));
                }

                CategoryId = categoryId;
                txtCategoryName.Text = category.Name;
                txtDescription.Text = category.Description;
                rblIsActive.SelectedValue = category.IsActive ? "true" : "false";

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddCategory()
        {
            TicketCategory category = new TicketCategory();

            category.Name = txtCategoryName.Text.ToTrimString();
            category.Description = txtDescription.Text.ToTrimString();
            category.IsActive = rblIsActive.SelectedValue == "true";

            string rMessage;
            int categoryId = _ticket.AddCategory(category, out rMessage);

            if (rMessage != string.Empty || categoryId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("ticket-category-list.aspx?o={0}", 1), false);
        }

        protected void UpdateCategory()
        {
            TicketCategory category = new TicketCategory();

            category.CategoryId = CategoryId;
            category.Name = txtCategoryName.Text.ToTrimString();
            category.Description = txtDescription.Text.ToTrimString();
            category.IsActive = rblIsActive.SelectedValue == "true";

            string rMessage;
            _ticket.UpdateCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("ticket-category-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddCategory();
                }

                else if (Operation == "edit" && CategoryId > 0)
                {
                    UpdateCategory();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ticket-category-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }
    }
}