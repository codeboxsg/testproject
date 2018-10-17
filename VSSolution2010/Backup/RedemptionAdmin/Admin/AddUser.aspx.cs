using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionAdmin;
using ApplicationServices;


namespace RedemptionAdmin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateBut_Click(object sender, EventArgs e)
        {
            Page.Validate("VG");
            if (Page.IsValid)
            {
                int ran = new Random().Next();
                MembershipUser aMembershipUser = Membership.CreateUser(UserName.Text.Trim(), "0o9i8u7y", EmailTB.Text.Trim());
                aspnet_UsersInRole aaspnet_UsersInRole = new aspnet_UsersInRole();
                // aaspnet_UsersInRole.UserId=aMembershipUser.
                //   Roles.AddUserToRole(aMembershipUser.UserName, "iPadUser");

                //Changed in 2013-Mar-8, if OTP is active, then updates the mobile no.

                // UserDataManager.SetUserMobile(aMembershipUser, MobileTB.Text.Trim());

                Roles.AddUserToRole(UserName.Text.Trim(), RoleDDL.SelectedValue);

                Logger.LogInfo(Membership.GetUser().UserName + "- created user :" + aMembershipUser.UserName
                    + "  email : " + EmailTB.Text.Trim()
                   + "  role : " + RoleDDL.SelectedValue, this.GetType());
                Response.Redirect("userlist.aspx");
            }
            else
            {
                Trace.Warn(this.ToString(), "Page is not valid, creation of user did not proceed.");
            }
        }

        protected void UserNameCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Membership.GetUser(UserName.Text.Trim()) != null)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}