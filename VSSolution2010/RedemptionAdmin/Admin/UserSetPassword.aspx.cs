using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Collections;
using System.Configuration;
using Redemption;
using ApplicationServices;
using RedemptionAdmin;


namespace RedemptionAdmin
{
    public partial class UserSetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string aUsername = Request["username"].ToString();
            MembershipUser aMembershipUser = Membership.GetUser(aUsername);
            EmailLbl2.Text = aMembershipUser.Email;
            UserNameLbl.Text = aUsername;
        }

        protected void SendResetBut_Click(object sender, EventArgs e)
        {
            string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ForgetPwdTimeout"])).Ticks.ToString();

            string aUsername = Request["username"].ToString();
            MembershipUser aMembershipUser = Membership.GetUser(aUsername);
            string reseturl = ConfigurationManager.AppSettings["AdminSiteRootUrl"] + "/public/SetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);
            Hashtable aReplaceValues = new Hashtable();
            aReplaceValues.Add("[/username/]", aUsername);
            aReplaceValues.Add("[/resetpasswordurl/]", reseturl);

            //get group admin group
          //  aspnet_User aaspnet_User = aspnet_User.SingleOrDefault(x => x.UserName == Membership.GetUser().UserName);
           // admin_group aadmin_group = admin_group.SingleOrDefault(x => x.user_id == aaspnet_User.UserId);
           
            //edited for multi group admin
          //  group aGroup = group.SingleOrDefault(x => x.id == Convert.ToInt32(Session["CurrentAdminGroup"]));
            // group aGroup = group.SingleOrDefault(x => x.id == aadmin_group.group_id);

            EmailManager.SetPasswordMailWeb(aMembershipUser.Email, aUsername, aReplaceValues);

            Logger.LogInfo(Membership.GetUser().UserName + "- set password user :" + aMembershipUser.UserName, this.GetType());

            Response.Redirect("userlist.aspx", false);
        }

        protected void CancelLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlist.aspx", false);
        }
    }
}