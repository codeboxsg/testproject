using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Redemption
{
    public partial class members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check login
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Config.loginUrl);
            }

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //is loggedin
                NotLoggedInDiv.Visible = false;
                LoggedInDiv.Visible = true;
            }
            else
            {
                NotLoggedInDiv.Visible = true;
                LoggedInDiv.Visible = false;
            }
        }
    }
}