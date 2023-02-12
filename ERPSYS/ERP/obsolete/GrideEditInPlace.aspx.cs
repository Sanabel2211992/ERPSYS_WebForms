using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace ERPSYS.ERP.obsolete
{
    public partial class GrideEditInPlace : System.Web.UI.Page
    {

        readonly SettingsBLL _setting = new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("department_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("department_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("department_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("department_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("department_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgDepartmentList.Rebind();
        }

        protected void rgDepartmentList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgDepartmentList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetDepartmentList();
        }
        private void GetDepartmentList()
        {
            try
            {
                rgDepartmentList.DataSource = _setting.GetDepartmentList(Department);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Department = txtDepartmentName.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgDepartmentList_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eeditedItem = e.Item as GridEditableItem;
            int DepartmentId = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["DepartmentId"].ToInt();
            string Name = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["Name"].ToString();
            string Description = (eeditedItem["Description"].Controls[0] as TextBox).Text;
            string Remark = (eeditedItem["Remark"].Controls[0] as TextBox).Text;

            try
            {
                Department department = new Department();

                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    RadNumericTextBox Descriptionx = (RadNumericTextBox)item.FindControl("txtDescription");
                    department.Description = Descriptionx.Text.ToString();
                }

                department.DepartmentId = DepartmentId;
                department.Name = Name;
                department.Description = Description;
                department.Remark = Remark;

                string rMessage;
                _setting.UpdateDepartment(department, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;

                }
                //AppNotification.MessagePanelSuccess("Done");

            }
            catch (Exception ex)
            {
                rgDepartmentList.Controls.Add(new LiteralControl("Unable to update Product Name. Reason: " + ex.Message)); e.Canceled = true;
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("department-form.aspx", false);
        }

        //************************************** Properties ************************************//
        public string Department
        {
            get { return ViewState["Department"] != null ? ViewState["Department"].ToString() : ""; }
            set { ViewState["Department"] = value; }
        }



    }
}