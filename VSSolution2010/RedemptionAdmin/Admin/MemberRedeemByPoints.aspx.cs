using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using System.Web.Security;
using System.Collections;
using ApplicationServices;

namespace RedemptionAdmin
{
    public partial class MemberRedeemByPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Check login
            //if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect(Config.loginUrl);
            //}

            if (!IsPostBack)
            {
                LoggedInDiv.Visible = true;
                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];

                    UsernameHL.Text = Membership.GetUser(new Guid(userid)).UserName;
                    UsernameHL.NavigateUrl = "MemberClient.aspx?userid=" + userid;
                }
                if (Request.QueryString["clientid"] != null)
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    ClientLit.Text = ClientManager.getClient(clientid).name;
                }
                if (Request.QueryString["rewardid"] != null && Request.QueryString["promotionid"] != null)
                {
                    if ((Request.QueryString["userid"] != null) && (Request.QueryString["clientid"] != null))
                    {
                        int clientid = int.Parse(Request.QueryString["clientid"]);

                        //var redemptionMember = ClientManager.getRedemptionMember(
                        //    (Guid)aMembershipUser.ProviderUserKey);
                        var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                  new Guid(Request.QueryString["userid"]), clientid);

                        int rewardid = int.Parse(Request.QueryString["rewardid"]);
                        int promotionid = int.Parse(Request.QueryString["promotionid"]);
                        var reward = ClientManager.getReward(rewardid);
                        RedeemItemLit.Text = reward.name + "  - " + reward.points + " points";
                        MemberPointsBalanceLit.Text = redemptionMemberClient.pointbalance.ToString();

                        int balancepoints = redemptionMemberClient.pointbalance - reward.points;

                        if (balancepoints >= 0)
                        {
                            RemaindingPointBalanceLit.Text = balancepoints.ToString();
                        }
                        else
                        {
                            tr1.Visible = false;
                            tr2.Visible = false;
                            tr3.Visible = false;
                            tr4.Visible = false;
                            NoPointsLit.Visible = true;
                        }
                    }
                }




            }
        }

        protected void ReeemBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["rewardid"] != null && Request.QueryString["promotionid"] != null)
            {
                if ((Request.QueryString["userid"] != null) && (Request.QueryString["clientid"] != null))
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    var db = new ApplicationServices.ApplicationServicesDB();
                    using (var scope = db.GetTransaction())
                    {

                        int rewardid = int.Parse(Request.QueryString["rewardid"]);
                        int promotionid = int.Parse(Request.QueryString["promotionid"]);
                        Guid userid = new Guid(Request.QueryString["userid"]);
                        var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                                  userid, clientid);

                        var reward = ClientManager.getReward(rewardid);
                        var promotion = ClientManager.getPromotion(promotionid);
                        int newPointBalance = redemptionMemberClient.pointbalance - reward.points;

                        //check before transaction
                        if (newPointBalance >= 0)
                        {
                            int redemptionRewardState = -1;
                            switch (int.Parse(CollectionModeRBL.SelectedValue))
                            {
                                case (int)CollectionMode.PICK_UP:
                                    redemptionRewardState = (int)RedemptionRewardState.PENDING_COLLECTION;
                                    break;
                                case (int)CollectionMode.DELIVERY:
                                    redemptionRewardState = (int)RedemptionRewardState.PENDING_DELIVERY;
                                    break;
                            }

                            //insert redemptinoreward item
                            int redemptionrewardid = ClientManager.insertRedemptionReward(
                             clientid, userid,
                             promotion.promotionid, promotion.name,
                             -1, "",
                             reward.rewardid, reward.name, reward.points,
                             int.Parse(CollectionModeRBL.SelectedValue), "", RemarksTB.Text.Trim(),
                             (int)PromotionType.BY_POINT, redemptionRewardState, -1);

                            //reduce qty of reward by 1
                            ClientManager.reduceRewardQtyBy1(reward.rewardid);

                            //add entry to point transactino
                            string notes = "Redemption ID:" + redemptionrewardid +
                       " | Points:" + reward.points;
                            int RedemptionByPointTransactionid = ClientManager.insertRedemptionByPointTransaction(
                      userid,
                       clientid,
                      (int)RedemptionByPointTransactionType.REDEMPTION,
                      reward.points,
                      newPointBalance,
                      notes);

                            //update redemptionreward the redemption id
                            ClientManager.updateRedemptionRewardTransactionId(
                                redemptionrewardid, RedemptionByPointTransactionid);


                            //update redemptionmember point balance
                            ClientManager.updateRedemptionMemberClientBalance(
                         userid,
                        clientid,
                        newPointBalance);

                            scope.Complete();
                            //send email
                            bool canSendEmail;
                            RedemptionMember redemptionMember = ClientManager.getRedemptionMember(userid);
                            MembershipUser user = Membership.GetUser(userid);
                            Client client = ClientManager.getClient(clientid);
                            string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;

                            //    string emailLogoUrl = Config.SiteRootUrl + client.logoimagename;
                            Hashtable values = new Hashtable();
                            values.Add("[/logo/]", emailpath);
                            values.Add("[/SubmissionDate/]", DateTime.Now.ToString("dd/MM/yyyy"));
                            values.Add("[/RedemptionNo/]", redemptionrewardid);
                            values.Add("[/ApprovedBy/]", "System");
                            values.Add("[/MemberName/]", redemptionMember.firstname + " " + redemptionMember.lastname);
                            values.Add("[/NRICNo/]", redemptionMember.NRIC);
                            values.Add("[/ContactNo/]", redemptionMember.contactno);
                            values.Add("[/DeliveryAddress/]", redemptionMember.mailingaddress + ", Singapore " + redemptionMember.postalcode);
                            values.Add("[/PointsDeducted/]", reward.points);
                            values.Add("[/BalancePoints/]", newPointBalance);
                            values.Add("[/RedemptionItem/s/]", reward.name);
                            values.Add("[/OutstandingQuantity/]", "1");
                            switch (int.Parse(CollectionModeRBL.SelectedValue))
                            {
                                case (int)CollectionMode.PICK_UP:
                                    canSendEmail = EmailManager.SendRedemptionByPointsSelfCollectMail(
                                                             user.Email,
                                                             redemptionMember.firstname,
                                                             values, clientid, this.Response);

                                    break;
                                case (int)CollectionMode.DELIVERY:
                                    canSendEmail = EmailManager.SendRedemptionByPointsDeliveryMail(
                                                             user.Email,
                                                             redemptionMember.firstname,
                                                             values, clientid, this.Response);
                                    break;
                            }
                            Logger.LogInfo(Membership.GetUser().UserName + "- submitted redeem by points username :"

    , this.GetType());

                            Response.Redirect("MemberRedeemByPointsAck.aspx?clientid=" + clientid);
                        }
                        else
                        {
                            //not enough points
                        }
                    }
                }
            }
        }
        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    }
}