using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using M1Bod.BL;
using M1Bod.DAL;

namespace M1BODIpadServer.Account
{
    public partial class WebForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetPasswordBut_Click(object sender, EventArgs e)
        {
            try
            {
                string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ForgetPwdTimeout"])).Ticks.ToString();

                string aUsername = UserName.Text.Trim();
                MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                string reseturl = ConfigurationManager.AppSettings["RootURL"] + "public/WebSetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);
                Hashtable aReplaceValues = new Hashtable();
                aReplaceValues.Add("[/username/]", aUsername);
                aReplaceValues.Add("[/resetpasswordurl/]", reseturl);

            
                //
                EmailManager.SendResetPasswordMailWeb(aMembershipUser.Email, aUsername, aReplaceValues);
                Response.Redirect("ForgotPasswordSent.aspx", false);

            }
            catch (Exception )
            { 
            
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