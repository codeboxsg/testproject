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
namespace Redemption
{
    public partial class rewards : System.Web.UI.Page
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
                var x = ClientManager.getAllRewardsByClient2(Config.ClientId);
                FloatedTilesListView.DataSource = x;
            }
        }
        //hide button if qty of redeem item is 0
        protected void GoClaimsBut_Command(object sender, RadListViewCommandEventArgs e)
        {
            RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
            int rewardid = (int)item.GetDataKeyValue("rewardid");
            int promotionid = (int)item.GetDataKeyValue("promotionid");

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
                    Response.Redirect(Config.RootRelativePath + "/RedeemByPoints.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);

                }
                if (promotion.type == (int)PromotionType.BY_PRODUCT)
                {
                    //go to upload receipt to complete the redemption
                    Response.Redirect(Config.RootRelativePath + "/RedeemByProduct.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);

                }
            }
            else
            {

                if (promotion.type == (int)PromotionType.BY_POINT)
                {
                    //go to members screen points
                    //ask user to login or sign up
                    Response.Redirect(Config.RootRelativePath + "/login.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);

                }
                if (promotion.type == (int)PromotionType.BY_PRODUCT)
                {
                    //go to upload receipt to complete the redemption
                    Response.Redirect(Config.RootRelativePath + "/login.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);
                }
            }

            //Response.Redirect("/rewards.aspx?promotionid=" + promotionid.ToString());

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
                QtyLit.Text = "Qty : " + reward.qty + " available";
            }
            else
            {
                GoClaimsBut.Visible = true;
                GoClaimsBut.Text = "Fully Redeemed";
                GoClaimsBut.Enabled = false;
                QtyLit.Visible = false;
            }
            if (promotion.type == (int)PromotionType.BY_POINT)
            {
                PointsLit.Text = "<b>Points Required :</b> " + reward.points + " points";
            }
            else
            {
                PointsLit.Text = "";
            }

        }
    }
}