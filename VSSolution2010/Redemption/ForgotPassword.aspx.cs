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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBut_Click(object sender, EventArgs e)
        {
            Page.Validate("SignUpVG");
            if (Page.IsValid)
            {
                //add Membership
                //  MembershipUser aMembershipUser;


                //find member in rewardhub db or create new user
                //  aMembershipUser = Membership.GetUser(MemberUsernameTB.Text.Trim());
                string aUsername = MemberUsernameTB.Text.Trim();
                try
                {
                    string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ForgetPwdTimeout"])).Ticks.ToString();
                   // string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(EmailManager.emailconfig["ForgetPwdTimeout"])).Ticks.ToString();
                    
                    MembershipUser aMembershipUser = Membership.GetUser(aUsername);

                    if (aMembershipUser != null)
                    {
                        Hashtable aReplaceValues = new Hashtable();
                        string reseturl = "";

                        var client = ClientManager.getClient(Config.ClientId);
                        string emailLogoUrl = Config.SiteRootUrl  + client.logoimagename;
         
                        reseturl = Config.SiteRootUrl + "/ResetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);
                        aReplaceValues.Add("[/logo/]", emailLogoUrl);
                        aReplaceValues.Add("[/username/]", aUsername);
                        aReplaceValues.Add("[/resetpasswordurl/]", reseturl);
                        EmailManager.SendResetPasswordMailWeb(aUsername, aUsername, aReplaceValues,this.Response);
                        Trace.Write(this.ToString(), "Reset password link sent to  user: " + aUsername);

                        Response.Redirect("ForgotPasswordSent.aspx", false);
                    }
                    else {
                        ErrorLit.Text = "Sorry but can cannot find your email. Please retry.";
                    }

                }
                catch (Exception exc)
                {
                    string errorMessage = "Exception occured while sending reset password link to user: " + aUsername + ". Exception details are: " + exc.ToString();
                    Trace.Warn(this.ToString(), errorMessage);
                    //  Logger.LogWarn(errorMessage, exc.GetType());
                }
            }
        }


         
        

    }
}