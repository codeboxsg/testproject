using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using RedemptionData;
using System.Web.Security;
using ApplicationServices;
using System.Collections;
namespace RedemptionAdmin
{
    public partial class MemberRedeemByProduct : System.Web.UI.Page
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
                //is loggedin

                LoggedInDiv.Visible = true;
                if ((Request.QueryString["rewardid"] != null) && (Request.QueryString["promotionid"] != null))
                {
                    int rewardid = int.Parse(Request.QueryString["rewardid"]);
                    var reward = ClientManager.getReward(rewardid);
                    RedeemItemLit.Text = reward.name;
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

            RadAsyncUpload1.TargetFolder = "~/img/invoice";
        }

        protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //check file size
            //if (e.File.ContentLength < 5000)
            //{          
            //}
            string filename = DateTime.Now.ToString("yyyyMMdd") + "_" + Guid.NewGuid().ToString() + e.File.GetExtension();
            Session.Add("filename", filename);
            var physicalSavePath = MapPath(Config.UploadInvoiceVirtualPath) + filename;
            //Save physical file on disk
            e.File.SaveAs(physicalSavePath, true);

            //Add receipt to uploaded iamge
            //create upload receipt record




        }



        protected void RedeemBut_Click(object sender, EventArgs e)
        {
            if ((Request.QueryString["rewardid"] != null) && (Request.QueryString["promotionid"] != null))
            {
                if ((Request.QueryString["userid"] != null) && (Request.QueryString["clientid"] != null))
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    Guid userid = new Guid(Request.QueryString["userid"]);
                    var db = new ApplicationServices.ApplicationServicesDB();
                    using (var scope = db.GetTransaction())
                    {
                        int rewardid = int.Parse(Request.QueryString["rewardid"]);
                        int promotionid = int.Parse(Request.QueryString["promotionid"]);
                        var reward = ClientManager.getReward(rewardid);
                        var promotion = ClientManager.getPromotion(promotionid);
                        PromotionByProductProductReward promotionByProductProductReward = ClientManager.getPromotionByProductProductRewardByPromotionIdRewardId(promotionid, rewardid);
                        var product = ClientManager.getProduct(promotionByProductProductReward.productid);

                        var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                            userid, clientid);

                        //get receipt path
                        string filename = Session["filename"].ToString();
                        Session.Remove("filename");
                        //insert redemptionbyproductreceipt
                        int redemptionbyproductreceiptid = ClientManager.insertRedemptionByProductReceipt(
                         clientid, userid,
                         filename, (int)RedemptionByProductReceiptState.PENDING_PROCESS,
                         "", -1,
                         null,
                        promotion.promotionid, promotion.name,
                        int.Parse(CollectionModeRBL.SelectedValue), RemarksTB.Text.Trim());

                        MembershipUser user = Membership.GetUser(userid);
                        //reduce qty of reward by 1
                        //   ClientManager.reduceRewardQtyBy1(reward.rewardid);
                        var client = ClientManager.getClient(clientid);
                        string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                        //  string emailLogoUrl = Config.SiteRootUrl + client.logoimagename;

                        Hashtable values = new Hashtable();
                        values.Add("[/logo/]", emailpath);
                        var redemptionMember = ClientManager.getRedemptionMember((Guid)Membership.GetUser().ProviderUserKey);
                        //bool canSendEmail = EmailManager.SendClaimProductAckMail(
                        //                          user.Email,
                        //                          redemptionMember.firstname,
                        //                          values, clientid,this.Response);


                        scope.Complete();

                        Logger.LogInfo(Membership.GetUser().UserName + "- submitted redeemp by product username :"

, this.GetType());
                        Response.Redirect("MemberRedeemByProductAck.aspx?clientid=" + clientid);
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