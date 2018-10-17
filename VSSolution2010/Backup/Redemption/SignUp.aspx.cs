using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
namespace Redemption
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBut_Click(object sender, EventArgs e)
        {
            if (MemberDisclaimerCB.Checked)
            {
                if (Page.IsValid)
                {
                    //add Membership
                    MembershipUser aMembershipUser;


                    //find member in rewardhub db or create new user
                    aMembershipUser = Membership.GetUser(MemberUsernameTB.Text.Trim());

                    Session.Add("MemberDisclaimerCB", MemberDisclaimerCB.Checked);
                    Session.Add("MemberNewsletterCB", MemberNewsletterCB.Checked);


                    if (aMembershipUser == null)
                    {
                        // not found in rewardhub                
                        Session.Add("Username", MemberUsernameTB.Text.Trim());
                        Session.Add("Password", MemberPasswordTB.Text.Trim());


                        //continue signup to rewardhub and client site
                        Response.Redirect("SignupNew.aspx");
                    }
                    else
                    {
                        //found in rewards hub

                        //check if found in client site
                        var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                                (Guid)aMembershipUser.ProviderUserKey,
                                Config.ClientId);

                        if (redemptionMemberClient == null)
                        {
                            ////not found in client site continue to add user to client site
                            //bool canInsertMemberClient = ClientManager.insertRedemptionMemberClient(
                            //        (Guid)aMembershipUser.ProviderUserKey,
                            //        Config.ClientId,
                            //        MemberDisclaimerCB.Checked,
                            //        MemberNewsletterCB.Checked);
                            //  if (canInsertMemberClient)
                            {
                                Session.Add("MembershipUser", aMembershipUser);
                                Session.Add("Username", MemberUsernameTB.Text.Trim());
                                Session.Add("Password", MemberPasswordTB.Text.Trim());

                                Response.Redirect("SignUpExisting.aspx");
                            }
                            //  else
                            {
                                //      ErrorLit.Text = "You are registered to RewardsHub but there is an issue adding you to this site.";
                            }
                        }
                        else
                        {
                            //found in client site cannot continue
                            ErrorLit.Text = "You have already registered, Please try to login to continue.";
                        }
                    }
                }
             
            }
            else
            {
                ErrorLit.Text = "Please agree to the terms and conditions.";
            }
  
        }

        protected void MemberDisclaimerCB_CheckedChanged(object sender, EventArgs e)
        {
            if (MemberDisclaimerCB.Checked)
            { SignUpBut.Enabled = true; }
            else { SignUpBut.Enabled = false; }
        }

        protected void MemberDisclaimerCB_CheckedChanged1(object sender, EventArgs e)
        {

        }

    }
}