using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace M1BODIpadServer.Public
{
    public partial class afterlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

            if (Roles.IsUserInRole("superadministrator"))
                Response.Redirect("~/superadmin/managegroup.aspx",true);
            if (Roles.IsUserInRole("siteadministrator"))
                Response.Redirect("~/admin/SelectCurrentGroup.aspx", true);

            Response.Redirect("~/public/login.aspx", true);

        }
    }
}