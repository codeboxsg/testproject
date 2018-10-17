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

namespace Redemption
{
    public partial class RedeemByPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check login
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Config.loginUrl);
            }

            if (!IsPostBack)
            {
                LoggedInDiv.Visible = true;

                if (Request.QueryString["rewardid"] != null && Request.QueryString["promotionid"] != null)
                {

                    //var redemptionMember = ClientManager.getRedemptionMember(
                    //    (Guid)aMembershipUser.ProviderUserKey);
                    var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                (Guid)Membership.GetUser().ProviderUserKey, Config.ClientId);

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

        protected void ReeemBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["rewardid"] != null && Request.QueryString["promotionid"] != null)
            {
                var db = new ApplicationServices.ApplicationServicesDB();
                using (var scope = db.GetTransaction())
                {

                    int rewardid = int.Parse(Request.QueryString["rewardid"]);
                    int promotionid = int.Parse(Request.QueryString["promotionid"]);

                    var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                             (Guid)Membership.GetUser().ProviderUserKey, Config.ClientId);

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
                          Config.ClientId, (Guid)Membership.GetUser().ProviderUserKey,
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
                        int RedemptionByPointTransactionid= ClientManager.insertRedemptionByPointTransaction(
                  (Guid)Membership.GetUser().ProviderUserKey,
                   Config.ClientId,
                  (int)RedemptionByPointTransactionType.REDEMPTION,
                  reward.points,
                  newPointBalance,
                  notes);

                        //update redemptionreward the redemption id
                        ClientManager.updateRedemptionRewardTransactionId(
                            redemptionrewardid, RedemptionByPointTransactionid);


                        //update redemptionmember point balance
                        ClientManager.updateRedemptionMemberClientBalance(
                    (Guid)Membership.GetUser().ProviderUserKey,
                    Config.ClientId,
                    newPointBalance);

                        scope.Complete();
                        //send email
                        bool canSendEmail;
                        RedemptionMember redemptionMember = ClientManager.getRedemptionMember((Guid)Membership.GetUser().ProviderUserKey);
                                
                        Client client = ClientManager.getClient(Config.ClientId);
                        string emailLogoUrl = Config.SiteRootUrl  + client.logoimagename;
                        Hashtable values = new Hashtable();
                        values.Add("[/logo/]", emailLogoUrl);
                        values.Add("[/SubmissionDate/]", DateTime.Now.ToString("dd/MM/yyyy"));
                        values.Add("[/RedemptionNo/]", redemptionrewardid);
                        values.Add("[/ApprovedBy/]", "System");
                        values.Add("[/MemberName/]", redemptionMember.firstname + " " + redemptionMember.lastname);
                        values.Add("[/NRICNo/]", redemptionMember.NRIC);
                        values.Add("[/ContactNo/]", redemptionMember.contactno);
                        values.Add("[/DeliveryAddress/]", redemptionMember.mailingaddress + ", Singapore "+redemptionMember.postalcode);
                        values.Add("[/PointsDeducted/]", reward.points);
                        values.Add("[/BalancePoints/]", newPointBalance);
                        values.Add("[/RedemptionItem/s/]", reward.name);
                        values.Add("[/OutstandingQuantity/]", "1");
                        switch (int.Parse(CollectionModeRBL.SelectedValue))
                        {
                            case (int)CollectionMode.PICK_UP:
                                canSendEmail = EmailManager.SendRedemptionByPointsSelfCollectMail(
                                                         Membership.GetUser().Email,
                                                         redemptionMember.firstname,
                                                         values, this.Response);

                                break;
                            case (int)CollectionMode.DELIVERY:
                                canSendEmail = EmailManager.SendRedemptionByPointsDeliveryMail(
                                                         Membership.GetUser().Email,
                                                         redemptionMember.firstname,
                                                         values, this.Response);
                                break;
                        }

                        Response.Redirect("RedeemByPointsAck.aspx");
                    }
                    else
                    {
                        //not enough points
                    }
                }
            }
        }

    }
}