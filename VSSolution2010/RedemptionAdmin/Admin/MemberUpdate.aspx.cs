using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
using ApplicationServices;
using RedemptionAdmin;

namespace Redemption
{
    public partial class MemberUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];


                    MembershipUser aMembershipUser = Membership.GetUser(new Guid(userid));
                    var redemptionMember = ClientManager.getRedemptionMember((Guid)aMembershipUser.ProviderUserKey);
                    MemberFirstnameTB.Text = redemptionMember.firstname;
                    MemberLastnameTB.Text = redemptionMember.lastname;
                    if (redemptionMember.gender)
                    {
                        MemberGenderRBL.SelectedValue = "1";
                    }
                    else
                    {
                        MemberGenderRBL.SelectedValue = "0";
                    }
                    MemberContactnoTB.Text = redemptionMember.contactno;
                    MemberNricTB.Text = redemptionMember.NRIC;
                    MemberDOBTB.SelectedDate = redemptionMember.dateofbirth;
                    MemberMailingAddressTB.Text = redemptionMember.mailingaddress;
                    MemberPostalCodeTB.Text = redemptionMember.postalcode;


                    RedemptionChild redemptionChild = ClientManager.getRedemptionChildByMemberUserId((Guid)aMembershipUser.ProviderUserKey);

                    if (redemptionChild.childid > 0)
                    {
                        ChildFirstnameTB.Text = redemptionChild.firstname;
                        ChildLastnameTB.Text = redemptionChild.lastname;
                        if (redemptionChild.gender)
                        {
                            ChildGenderRBL.SelectedValue = "1";
                        }
                        else
                        {
                            ChildGenderRBL.SelectedValue = "0";
                        }
                        ChildDobTB.SelectedDate = redemptionChild.dateofbirth;
                    }

                }

            }
        }

        protected void UpdateBut_Click(object sender, EventArgs e)
        {
            Page.Validate("SignUpVG");
            if (Page.IsValid)
            {
                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];
                    MembershipUser aMembershipUser = Membership.GetUser(new Guid(userid));
                    string username = aMembershipUser.UserName;
                    //update Membership
                    // MembershipUser aMembershipUser = Membership.GetUser(userid);
                    bool gender;
                    if (MemberGenderRBL.SelectedValue == "1")
                    {
                        gender = true;
                    }
                    else
                    {
                        gender = false;
                    }
                    bool canInsertMember = ClientManager.updateRedemptionMember(
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
                        RedemptionChild redemptionChild = ClientManager.getRedemptionChildByMemberUserId((Guid)aMembershipUser.ProviderUserKey);

                        if (redemptionChild.childid > 0)
                        {
                            bool canInsertChild = ClientManager.updateRedemptionChild(
                                  redemptionChild.childid,
                                    (Guid)aMembershipUser.ProviderUserKey,
                                                  ChildFirstnameTB.Text.Trim(),
                                                 ChildLastnameTB.Text.Trim(),
                                                 childGender,
                                                 (DateTime)ChildDobTB.SelectedDate);
                        }
                        else
                        {
                            bool canInsertChild = ClientManager.insertRedemptionChild(
                            (Guid)aMembershipUser.ProviderUserKey,
                                          ChildFirstnameTB.Text.Trim(),
                                         ChildLastnameTB.Text.Trim(),
                                         childGender,
                                         (DateTime)ChildDobTB.SelectedDate);

                        }
                    }

                    if (canInsertMember)
                    {
                        Logger.LogInfo(Membership.GetUser().UserName + "- updated member username:" + username

                            , this.GetType());
                        Response.Redirect("MemberUpdateAck.aspx");
                    }

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