using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.Controls.Common
{
    public partial class UCMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMenu();
            }
        }

        private void LoadMenu()
        {
            try
            {
                MainMenu.LoadContentFile(GetMenuPath());
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private string GetMenuPath()
        {
            switch (UserSession.RoleId)
            {
                case 1:
                    return "~/Controls/resources/xml/menu/SysAdmin.xml";
                case 2:
                    return "~/Controls/resources/xml/menu/Admin.xml";
                case 3:
                    return "~/Controls/resources/xml/menu/Moderator.xml";
                case 4:
                    switch (UserSession.DepartmentId)
                    {
                        case 1:  // Sales
                            return "~/Controls/resources/xml/menu/Sales.xml";
                        case 2: // Estimation
                            return "~/Controls/resources/xml/menu/Estimation.xml";
                        case 3: // Accounting
                            return "~/Controls/resources/xml/menu/Accounting.xml";
                        case 4: // Store
                            return "~/Controls/resources/xml/menu/Store.xml";
                        case 5: // Production
                            return "~/Controls/resources/xml/menu/Production.xml";
                        case 6: // Management
                            return "~/Controls/resources/xml/menu/Management.xml";
                        case 7: // Operation
                            return "~/Controls/resources/xml/menu/Operation.xml";
                        default:
                            return "~/Controls/resources/xml/menu/Default.xml";
                    }
                case 5: // Retail User
                     return "~/Controls/resources/xml/menu/Retail.xml";
                default:
                    return "~/Controls/resources/xml/menu/Default.xml";
            }
        }
    }
}