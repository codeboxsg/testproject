using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using System.Web.Security;

namespace RedemptionAdmin
{
    public partial class MemberRedeemByProductAck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Check login
            //if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect(Config.loginUrl);
            //}
            if (!IsPostBack)
            {
                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];

                    UsernameHL.Text = Membership.GetUser(new Guid(userid)).UserName;
                    UsernameHL.NavigateUrl = "MemberClient.aspx?userid=" + userid;
                }
                if (Request.QueryString["clientid"] != null)
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    ClientLit.Text = ClientManager.getClient(clientid).name;
                }
            }
        }


        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    }
}