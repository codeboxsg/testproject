using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
using System.Configuration;
using System.Collections;
namespace Redemption
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string aTickStr = Crypt.simpleDecrypt(Request["2"].ToString());
                if (!isTimeOut(aTickStr))
                {
                    string aUsername = Crypt.simpleDecrypt(Request["1"].ToString());
                    MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                }
                else
                {
                    //timedout
                    Response.Redirect("timeout.aspx");
                }
            }
            catch (Exception exc)
            {
                Trace.Warn(this.ToString(), "Exception occured", exc);
                Response.Redirect("timeout.aspx");
            }
        }

        protected void SignUpBut_Click(object sender, EventArgs e)
        {
            try
            {
                string aTickStr = Crypt.simpleDecrypt(Request["2"].ToString());
                if (!isTimeOut(aTickStr))
                {
                    string aUsername = Crypt.simpleDecrypt(Request["1"].ToString());
                    MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                    //Validation is user is locked out is also done here:
                    if (aMembershipUser.IsLockedOut)
                    {
                        Trace.Warn(this.ToString(), "The user is locked out");
                        ChangePasswordCV.IsValid = false;
                        Logger.LogWarn("User " + aMembershipUser.UserName + " is locked out.", this.GetType());
                    }
                    else
                    {
                        string temp = aMembershipUser.ResetPassword();
                        aMembershipUser.ChangePassword(temp, NewPasswordTB.Text);
                        Membership.UpdateUser(aMembershipUser);

                        Trace.Write(this.ToString(), "User password has been updated.");
                        Logger.LogInfo(aMembershipUser.UserName + " Reset Password", this.GetType());

                        //If user is Super Admin, redirects to WebPasswordSet instead

                        Trace.Write(this.ToString(), "Redirecting user to WebPasswordSet.aspx page...");
                        Response.Redirect("ResetPasswordAck.aspx", false);

                    }
                }
                else
                {
                    //timedout
                    Response.Redirect("timeout.aspx");
                }
            }
            catch (Exception ee)
            {
                Trace.Warn(this.ToString(), "Exception occured", ee);
                Logger.Log(ee, this.GetType());
            }
        }


        //5/16/2010 11:08:17 PM 
        private bool isTimeOut(string aTickStr)
        {
            bool aTimeOut = false;
            try
            {

                long aURLDateSTr = long.Parse(aTickStr);
                //5/16/2010 11:08:17 PM +15 > 11:08
                if (aURLDateSTr < DateTime.Now.Ticks)
                    aTimeOut = true;
                else
                    aTimeOut = false;

            }
            catch (Exception exc)
            {
                Trace.Warn(this.ToString(), "Exception occured", exc);
                //   Logger.log(ee);
            }
            return aTimeOut;
        }


    }
}