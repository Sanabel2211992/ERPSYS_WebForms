using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.t
{
    public partial class GetImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void txtGetImage_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "HandlerImage.ashx?id=" + id.Text; 

        }

    }
}