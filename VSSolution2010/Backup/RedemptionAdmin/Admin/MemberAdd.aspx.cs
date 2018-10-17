using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
using System.Collections;
using RedemptionAdmin;
namespace Redemption
{
    public partial class MemberAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["MembershipUser"] != null) //Session.Add("MembershipUser", aMembershipUser);
                //{
                //}
            }
        }

        protected void SignUpBut_Click(object sender, EventArgs e)
        {
            Page.Validate("SignUpVG");
            if (Page.IsValid)
            {
                //add Membership
                MembershipUser aMembershipUser;
                bool canInsertMembershipUser = false;
                try
                {
                    //string username = (string)Session["Username"];
                    //string password = (string)Session["Password"];
                    //bool memberDisclaimer = (bool)Session["MemberDisclaimerCB"];
                    //bool memberNewsletter = (bool)Session["MemberNewsletterCB"];
                    string username = MemberUsernameTB.Text.Trim();
                    string password = MemberPasswordTB.Text.Trim();
                    bool memberDisclaimer = MemberDisclaimerCB.Checked;
                    bool memberNewsletter = MemberNewsletterCB.Checked;

                    //find member in rewardhub db or create new user
                    aMembershipUser = Membership.GetUser(username);

                    if (aMembershipUser != null)
                    {
                        Trace.Warn(this.ToString(), "User found in RedemptionDB");
                        canInsertMembershipUser = true;
                    }
                    else
                    {
                        Trace.Warn(this.ToString(), "User not found in RedemptionDB. adding it");
                        aMembershipUser = Membership.CreateUser(username,
                           password, username);
                        canInsertMembershipUser = true;
                    }

                    if (!Roles.IsUserInRole(aMembershipUser.UserName, RedemptionData.UserRole.MEMBER.ToString()))
                    {
                        Roles.AddUserToRole(aMembershipUser.UserName, RedemptionData.UserRole.MEMBER.ToString());
                    }


                    if (canInsertMembershipUser)
                    {

                        #region add member
                        #region gender
                        bool gender;
                        if (MemberGenderRBL.SelectedValue == "1")
                        {
                            gender = true;
                        }
                        else
                        {
                            gender = false;
                        }
                        #endregion
                        bool canInsertMember = ClientManager.insertRedemptionMember(
                                                (Guid)aMembershipUser.ProviderUserKey,
                                                MemberFirstnameTB.Text.Trim(),
                                                MemberLastnameTB.Text.Trim(),
                                                MemberNricTB.Text.Trim(),
                                                gender,
                                                (DateTime)MemberDOBTB.SelectedDate,
                                                MemberMailingAddressTB.Text.Trim(),
                                                MemberContactnoTB.Text.Trim(),
                                                MemberPostalCodeTB.Text.Trim());
         

                        if (ChildDobTB.SelectedDate != null)
                        {
                            //add child
                            bool childGender;
                            if (ChildGenderRBL.SelectedValue == "1")
                            {
                                childGender = true;
                            }
                            else
                            {
                                childGender = false;
                            }
                            bool canInsertChild = ClientManager.insertRedemptionChild(
                                  (Guid)aMembershipUser.ProviderUserKey,
                                                ChildFirstnameTB.Text.Trim(),
                                               ChildLastnameTB.Text.Trim(),
                                               childGender,
                                               (DateTime)ChildDobTB.SelectedDate);
                        }
                        #endregion

                        Logger.LogInfo(Membership.GetUser().UserName + "- created member username:" + username

, this.GetType());
                        Response.Redirect("MemberAddAck.aspx");

                    }
                    else
                    {
                        Trace.Warn(this.ToString(), "user has already registered");
                        //user has already registered
                        ErrorLit.Text = "You have already registered, Please try to login to continue.";
                    }




                }
                catch (MembershipCreateUserException membershipCreateUserException)
                {
                    Trace.Warn(this.ToString(), "cannot insert MembershipUser");
                    Trace.Warn(this.ToString(), "membershipCreateUserException");
                    ErrorLit.Text = "cannot insert MembershipUser membershipCreateUserException";

                }


            }
        }


        private bool isNRICValid(string ic)
        {
            return NRICHelper.check(ic, NRICHelper.CheckType.NRICFIN);
        }

        protected void ICValidateCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string argsvalue = args.Value.Trim();
            args.IsValid = isNRICValid(argsvalue);
            //if (!args.IsValid)
            //{
            //    if (argsvalue.Length >= 5)
            //        args.IsValid = true;
            //    else
            //        args.IsValid = false;
            //}
        }

        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    }
}