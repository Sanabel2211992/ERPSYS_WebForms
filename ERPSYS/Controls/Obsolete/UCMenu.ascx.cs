using System;
using ERPSYS.BLL;

namespace ERPSYS.Controls.Obsolete
{
    public partial class UCMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    MainMenu.LoadContentFile(GetMenuPath());
            //}
        }

       //private static string GetMenuPath()
       //{
       //    switch (UserSession.RoleId)
       //    {
       //        case 1:
       //            return "~/Controls/resources/xml/MenuSysAdmin.xml";
       //        case 2:
       //            return "~/Controls/resources/xml/MenuAdmin.xml";
       //        case 3:
       //            return "~/Controls/resources/xml/MenuAdmin.xml";
       //        case 4:
       //            switch (UserSession.DepartmentId)
       //            {
       //                //case 1:  //Managements
       //                //    return "~/Controls/resources/xml/MenuUser.xml";
       //                //case 2: //Sales
       //                //    return "~/Controls/resources/xml/MenuUser.xml";
       //                //case 3: //Operations
       //                //    return "~/Controls/resources/xml/MenuUser.xml";
       //                //case 4: //Estimation
       //                //    return "~/Controls/resources/xml/MenuUser.xml";
       //                case 5: //Accounting
       //                    return "~/Controls/resources/xml/MenuUser.xml";
       //                case 6: //Store
       //                    return "~/Controls/resources/xml/MenuStore.xml";
       //                default:
       //                    return "~/Controls/resources/xml/MenuUser.xml";
       //            }
       //        default:
       //            return "~/Controls/resources/xml/MenuUser.xml";
       //    }
       //}
    }
}