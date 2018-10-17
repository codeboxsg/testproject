using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace Redemption
{
    public partial class MemberAddAck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Check login
            //if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect(Config.loginUrl);
            //}

          
        }
        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    


    }
}