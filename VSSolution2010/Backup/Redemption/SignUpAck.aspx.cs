using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
using System.Collections;
namespace Redemption
{
    public partial class SignUpAck : System.Web.UI.Page
    {
        protected bool isValidUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SignUpType"] != null) //Session.Add("MembershipUser", aMembershipUser);
                {
                    if (Session["SignUpType"].ToString().Equals("new"))
                    {
                        // if new 
                        NewDiv.Visible = true;
                        ExistingDiv.Visible = false;
                    } 
                    if (Session["SignUpType"].ToString().Equals("existing"))
                    {
                        //if existing
                        NewDiv.Visible = false;
                        ExistingDiv.Visible = true;
                    }

                    Session.Remove("SignUpType");
                    
                }
            }
        }

     

    }
}