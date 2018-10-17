using System
;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RedemptionData;
using ApplicationServices;

namespace Redemption
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  if (!IsPostBack)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    LoginUser.Visible = false;
                    LoggedInDiv.Visible = true;
                    NameHL.Text = Membership.GetUser().UserName;
                    SignupLi.Visible = false;
                }
                else
                {
                    LoginUser.Visible = true;
                    LoggedInDiv.Visible = false;
                    SignupLi.Visible = true;
                }
            }
        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Logger.LogInfo(Membership.GetUser().UserName + " logged out", this.GetType());
        }

        //protected void LoginUser_LoggedIn(object sender, EventArgs e)
        //{
        //    //MembershipUser aMembershipUser = Membership.GetUser(LoginUser.UserName);
        //    //Session.Add("MembershipUser", aMembershipUser);
        //}

        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect(Config.RootRelativePath + "/default.aspx");
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool userValidInDB = Membership.ValidateUser(LoginUser.UserName.Trim(), LoginUser.Password.Trim());
            bool userValidInClient = false;
            if (userValidInDB)
            {
                MembershipUser aMembershipUser = Membership.GetUser(LoginUser.UserName);

                //check if found in client site
                var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                        (Guid)aMembershipUser.ProviderUserKey,
                        Config.ClientId);

                if (redemptionMemberClient != null)
                {
                    userValidInClient = true;
                }

                if (userValidInClient)
                {
                    FormsAuthentication.SetAuthCookie(LoginUser.UserName.Trim(), false);
                    e.Authenticated = true;
                    Session.Add("MembershipUser", aMembershipUser);
                }
            }
        }
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            MembershipUser aMembershipUser = Membership.GetUser(LoginUser.UserName);
            Session.Add("MembershipUser", aMembershipUser);

            if ((Request.QueryString["rewardid"] != null) && (Request.QueryString["promotionid"] != null))
            {
                int rewardid = int.Parse(Request.QueryString["rewardid"]);
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                Reward reward = ClientManager.getReward(rewardid);
                Promotion promotion = ClientManager.getPromotion(promotionid);

                if (promotion.type == (int)PromotionType.BY_POINT)
                {
                    Response.Redirect(Config.RootRelativePath + "/RedeemByPoints.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);
                }
                if (promotion.type == (int)PromotionType.BY_PRODUCT)
                {
                    Response.Redirect(Config.RootRelativePath + "/RedeemByProduct.aspx?rewardid=" + rewardid + "&promotionid=" + promotionid);
                }
            }
            else
            {
                Response.Redirect(Config.RootRelativePath + "/status.aspx");
            }
        }


    }
}
