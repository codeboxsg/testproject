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
    public partial class SignUpExisting : System.Web.UI.Page
    {
        protected bool isValidUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MembershipUser"] != null) //Session.Add("MembershipUser", aMembershipUser);
                {
                    MembershipUser aMembershipUser = (MembershipUser)Session["MembershipUser"];

                    string username = (string)Session["Username"];
                    string password = (string)Session["Password"];

                    if (isValidUser(username, password))
                    {
                        bool memberDisclaimer = (bool)Session["MemberDisclaimerCB"];
                        bool memberNewsletter = (bool)Session["MemberNewsletterCB"];

                        bool canInsertMemberClient = ClientManager.insertRedemptionMemberClient(
                                (Guid)aMembershipUser.ProviderUserKey,
                                Config.ClientId,
                                memberDisclaimer,
                                memberNewsletter);
                        //send email out 
                        //get members 
                        var redemptionMember = ClientManager.getRedemptionMember(
                       (Guid)aMembershipUser.ProviderUserKey);
                        Hashtable values = new Hashtable();
                        bool canSendEmail = EmailManager.SendSignUpMail(
                               aMembershipUser.Email,
                               redemptionMember.firstname,
                               values, this.Response);

                        if (!canSendEmail)
                        {
                            //end signupemailerror
                        }
                        loginDiv.Visible = false;
                        AddedDiv.Visible = true;

                        Session.Remove("MemberDisclaimerCB");
                        Session.Remove("MemberNewsletterCB");
                        Session.Remove("Username");
                        Session.Remove("Password");
                        Session.Add("SignUpType", "existing");

                        FormsAuthentication.SetAuthCookie(username, true);
                        Response.Redirect("SignUpAck.aspx");
                    }
                    else
                    {
                        //invalid password therefore need to enter them again to continue
                        MemberUsernameLit.Text = username;

                        loginDiv.Visible = true;
                        AddedDiv.Visible = false;
                    }

                }
            }
        }

        protected void LoginBut_Click(object sender, EventArgs e)
        {
            if ((Page.IsValid) && 
                (Session["MembershipUser"] != null)) //Session.Add("MembershipUser", aMembershipUser);
            {
                MembershipUser aMembershipUser = (MembershipUser)Session["MembershipUser"];

                string username = (string)Session["Username"];

                if (isValidUser(username, MemberPasswordTB.Text.Trim()))
                {

                    bool memberDisclaimer = (bool)Session["MemberDisclaimerCB"];
                    bool memberNewsletter = (bool)Session["MemberNewsletterCB"];

                    bool canInsertMemberClient = ClientManager.insertRedemptionMemberClient(
                            (Guid)aMembershipUser.ProviderUserKey,
                            Config.ClientId,
                            memberDisclaimer,
                            memberNewsletter);
                    //send email out 
                    //get members 
                    var redemptionMember = ClientManager.getRedemptionMember(
                        (Guid)aMembershipUser.ProviderUserKey);

                    Hashtable values = new Hashtable();
                    bool canSendEmail = EmailManager.SendSignUpMail(
                           aMembershipUser.Email,
                           redemptionMember.firstname,
                           values,this.Response);

                    if (!canSendEmail)
                    {
                        //end signupemailerror
                    }

                    Session.Add("SignUpType", "existing");
                    FormsAuthentication.SetAuthCookie(username, true);
                    Response.Redirect("SignUpAck.aspx");
                }
                else
                {
                    ErrorLit.Text = "Your login attempt was not successful. Please try again.";
                }

            }
        }

    }
}