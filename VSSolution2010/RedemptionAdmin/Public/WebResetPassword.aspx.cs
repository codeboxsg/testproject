using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

namespace M1BODIpadServer.Account
{
    public partial class WebResetPassword : System.Web.UI.Page
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
            catch (Exception )
            { }
            //   Response.Write(aUsername);
        }

        protected void ResetPasswordBut_Click(object sender, EventArgs e)
        {
            try
            {


                string aTickStr = Crypt.simpleDecrypt(Request["2"].ToString());
                if (!isTimeOut(aTickStr))
                {
                    string aUsername = Crypt.simpleDecrypt(Request["1"].ToString());
                    MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                    string temp = aMembershipUser.ResetPassword();
                    aMembershipUser.ChangePassword(temp, NewPasswordTB.Text);
                    Membership.UpdateUser(aMembershipUser);

                    Logger.LogInfo(aMembershipUser.UserName + " Reset Password", this.GetType());

                    Response.Redirect("webpasswordreset.aspx", false);
                }
                else
                {
                    //timedout
                    Response.Redirect("timeout.aspx");
                }
            }
            catch (Exception ee)
            {
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
            catch (Exception )
            {
                //   Logger.log(ee);
            }
            return aTimeOut;
        }
    }
}