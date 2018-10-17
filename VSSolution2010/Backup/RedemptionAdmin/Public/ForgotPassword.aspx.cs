using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using Redemption;


namespace RedemptionAdmin.Admin
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetPasswordBut_Click(object sender, EventArgs e)
        {
            string aUsername = UserName.Text.Trim();
            try
            {
                string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ForgetPwdTimeout"])).Ticks.ToString();

                MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                  Hashtable aReplaceValues = new Hashtable();
                string reseturl = "";


                reseturl = ConfigurationManager.AppSettings["AdminSiteRootUrl"] + "/public/SetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);

                    aReplaceValues.Add("[/username/]", aUsername);
                    aReplaceValues.Add("[/resetpasswordurl/]", reseturl);
                    EmailManager.SendResetPasswordMailWeb(aMembershipUser.Email, aUsername, aReplaceValues);
                    Trace.Write(this.ToString(), "Reset password link sent to Admin user: " + aUsername);
               
                Response.Redirect("ForgotPasswordSent.aspx", false);

            }
            catch (Exception exc)
            {
                string errorMessage = "Exception occured while sending reset password link to user: " + aUsername + ". Exception details are: " + exc.ToString();
                Trace.Warn(this.ToString(), errorMessage);
                Logger.LogWarn(errorMessage, exc.GetType());
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            MembershipUser aMembershipUser = Membership.GetUser(UserName.Text.Trim());
            if (aMembershipUser != null)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}