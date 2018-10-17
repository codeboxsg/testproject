using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using System.Dynamic;
using ApplicationServices;
using System.Web.Security;
namespace Redemption
{
    public partial class MemberRewards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["promotionid"] != null)
                {
                    int promotionid = int.Parse(Request.QueryString["promotionid"]);
                    var promotion = ClientManager.getPromotion(promotionid);

                    PromotionNameLit.Text = "- " + promotion.name;

                } 
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
            }

        }
        protected void FloatedTilesListView_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var x = ClientManager.getAllRewardsByPromotion(promotionid);
                FloatedTilesListView.DataSource = x;
            }
            else
            {
                if (Request.QueryString["clientid"] != null)
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    var x = ClientManager.getAllRewardsByClient2(clientid);
                    FloatedTilesListView.DataSource = x;
                }
            }
        }
        //hide button if qty of redeem item is 0
        protected void GoClaimsBut_Command(object sender, RadListViewCommandEventArgs e)
        {
            RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
            int rewardid = (int)item.GetDataKeyValue("rewardid");
            int promotionid = (int)item.GetDataKeyValue("promotionid");
            if ((Request.QueryString["userid"] != null) && (Request.QueryString["clientid"] != null))
            {

                // int rewardid = int.Parse(e.CommandArgument.ToString());
                var reward = ClientManager.getReward(rewardid);
                var promotion = ClientManager.getPromotion(promotionid);

                //Check logged in first
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //logged in 

                    if (promotion.type == (int)PromotionType.BY_POINT)
                    {
                        //go to members screen points
                        Response.Redirect("MemberRedeemByPoints.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid + "&userid=" + Request.QueryString["userid"] + "&clientid=" + Request.QueryString["clientid"]);

                    }
                    if (promotion.type == (int)PromotionType.BY_PRODUCT)
                    {
                        //go to upload receipt to complete the redemption
                        Response.Redirect("MemberRedeemByProduct.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid + "&userid=" + Request.QueryString["userid"] + "&clientid=" + Request.QueryString["clientid"]);

                    }
                }
                else
                {

                    //if (promotion.type == (int)PromotionType.BY_POINT)
                    //{
                    //    //go to members screen points
                    //    //ask user to login or sign up
                    //    Response.Redirect(Config.RootRelativePath + "/login.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);

                    //}
                    //if (promotion.type == (int)PromotionType.BY_PRODUCT)
                    //{
                    //    //go to upload receipt to complete the redemption
                    //    Response.Redirect(Config.RootRelativePath + "/login.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);
                    //}
                }

                //Response.Redirect("/rewards.aspx?promotionid=" + promotionid.ToString());
            }
        }

        protected void FloatedTilesListView_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            RadListViewDataItem item = e.Item as RadListViewDataItem;
            int rewardid = (int)item.GetDataKeyValue("rewardid");
            int promotionid = (int)item.GetDataKeyValue("promotionid");
            var promotion = ClientManager.getPromotion(promotionid);

            Reward reward = ClientManager.getReward(rewardid);
            Literal QtyLit = e.Item.FindControl("QtyLit") as Literal;
            Literal PointsLit = e.Item.FindControl("PointsLit") as Literal;

            LinkButton GoClaimsBut = e.Item.FindControl("GoClaimsBut") as LinkButton;
            if (reward.qty > 0)
            {
                GoClaimsBut.Visible = true;
                QtyLit.Text = "Qty: " + reward.qty + " available";
            }
            else
            {
                GoClaimsBut.Visible = false;
                QtyLit.Text = "Fully Redeemed";
            }
            if (promotion.type == (int)PromotionType.BY_POINT)
            {
                PointsLit.Text = "<b>Points Required :</b>" + reward.points + "   points";
            }
            else
            {
                PointsLit.Text = "";
            }

        }

        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    }
}