using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionAdmin;


namespace RedemptionAdmin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Properties.Settings.Default.OTPIsActive)
            //{
            //    MobileLabel.Visible = false;
            //    MobileRFV.Enabled = false;
            //    MobileRFV.Visible = false;
            //    MobileREV.Enabled = false;
            //    MobileREV.Visible = false;
            //    MobileTB.Visible = false;
            //}
            if (!IsPostBack)
            {
                string aUsername = Request["username"].ToString();
                MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                EmailTB.Text = aMembershipUser.Email;
                UserNameLbl.Text = aUsername;
                string[] ss = Roles.GetRolesForUser();
                RoleDDL.SelectedValue = ss[0];
                //if (Properties.Settings.Default.OTPIsActive)
                //{
                //    MobileTB.Text = UserDataManager.GetUserMobile(aMembershipUser).Body; ;
                //}
            }
        }

        protected void UpdateBut_Click(object sender, EventArgs e)
        {
            Page.Validate("VG");
            if (Page.IsValid)
            {

                string aUsername = Request["username"].ToString();
                MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                aMembershipUser.Email = EmailTB.Text.Trim();
                Membership.UpdateUser(aMembershipUser);

                //update role here
                string[] ss = { "Staff", "Admin" };
                try
                {
                    Roles.RemoveUserFromRole(aUsername, "Staff");
                }
                catch { } try
                {
                    Roles.RemoveUserFromRole(aUsername, "Admin");
                }
                catch { }

                Roles.AddUserToRole(aUsername, RoleDDL.SelectedValue);
                //   Logger.LogInfo(Membership.GetUser().UserName + " updated user :" + aMembershipUser.UserName + "  email : " + EmailTB.Text.Trim(), this.GetType());
                Response.Redirect("UserList.aspx", false);
                //Changed in 2013-Mar-8, if OTP is active, then updates the mobile no.

                //if (Properties.Settings.Default.OTPIsActive)
                //{
                //    UserDataManager.SetUserMobile(aMembershipUser, MobileTB.Text.Trim());
                //}
                Logger.LogInfo(Membership.GetUser().UserName + "- updated user :" + aMembershipUser.UserName
                    + "  email : " + EmailTB.Text.Trim()
                   + "  role : " + RoleDDL.SelectedValue, this.GetType());
                // Logger.LogInfo(Membership.GetUser().UserName + " updated user :" + aMembershipUser.UserName + "  email : " + EmailTB.Text.Trim() + (Properties.Settings.Default.OTPIsActive ? " mobileNo: " + MobileTB.Text.Trim() : ""), this.GetType());
                Response.Redirect("userlist.aspx");
            }
            else
            {
                Trace.Warn(this.ToString(), "Page is not valid, update of user did not proceed.");
            }
        }

        protected void CancelLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlist.aspx", false);
        }
    }
}