using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

namespace RedemptionAdmin.Public
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //Check login
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Config.AdminSiteRootUrl + "/admin/client.aspx");
            }
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Logger.LogInfo(LoginUser.UserName + " logged in", this.GetType());
            Response.Redirect(Config.AdminSiteRootUrl + "/admin/client.aspx");
        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LoginUserCV_ServerValidate(object source, ServerValidateEventArgs args)
        {

          //  Trace.Write(this.ToString(), LoginUser.UserName + " logging in, checking if it is iPadUser...");
            if (Roles.IsUserInRole(LoginUser.UserName, "Admin") || Roles.IsUserInRole(LoginUser.UserName, "Staff"))
            {
                args.IsValid = true;
                //Trace.Warn(this.ToString(), LoginUser.UserName + " is iPad user, will not login.");
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void LoginUser_LoginError(object sender, EventArgs e)
        {
            // Does there exist a User account for this user?
            MembershipUser usrInfo = Membership.GetUser(LoginUser.UserName);
            if (usrInfo != null)
            {
                // Is this user locked out?
                if (usrInfo.IsLockedOut)
                {
                    LoginUser.FailureText = "user is locked out";//Properties.Settings.Default.UserLockedOutMessage;
                }
            }
        }

    }
}
