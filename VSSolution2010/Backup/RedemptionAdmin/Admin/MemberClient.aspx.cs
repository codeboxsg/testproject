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
using System.Configuration;
using Redemption;

namespace RedemptionAdmin.Admin
{
    public partial class MemberClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["userid"] != null)
                {
                    try
                    {
                        string userid = Request.QueryString["userid"];
                        UsernameLit.Text = Membership.GetUser(new Guid(userid)).UserName;
                       
                    }
                    catch (Exception eee)
                    { }
                }
            }
        }

        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["userid"] != null)
            {
                string userid = Request.QueryString["userid"];
                //var x = ClientManager.get();
                //var x = ClientManager.getAllClientsRedemptionMember(new Guid(userid));
                var x = ClientManager.getAllClients();
                RadGrid1.DataSource = x;

                //var promotion = ClientManager.getPromotion(promotionid);
                //var x = ClientManager.getAllRewardsByClient(promotion.clientid);
                //RadGrid1.DataSource = x;
            }
        }

        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "resetpassword")
            {
                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];
                    MembershipUser aMembershipUser = Membership.GetUser(new Guid(userid));
                    string reseturl = "";
                    string aUsername = aMembershipUser.UserName;
                    int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                    var client = ClientManager.getClient(clientid);
                    //  string siterelativepath = (string)((GridDataItem)e.Item).GetDataKeyValue("siterelativepath");
                    //   Response.Redirect("MemberSetPassword.aspx?userid=" + UserId.ToString());
                    if (EmailManager.ClientEmailConfig.Count == 0)
                    {
                        EmailManager.LoadClientEmailValues(this.Response);
                    }
                    Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];


                    string aTickStr = DateTime.Now.AddSeconds(Convert.ToDouble(emailconfig["ForgetPwdTimeout"])).Ticks.ToString();
                    //   string emailpath = Config.MainSiteRootUrl +  client.siterelativepath + client.logoimagename;
                    string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;

                    reseturl = Config.MainSiteRootUrl + client.siterelativepath + "/ResetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);
                    //  string reseturl = ConfigurationManager.AppSettings["RootURL"] + "public/SetPassword.aspx?1=" + Crypt.simpleEncrypt(aUsername) + "&2=" + Crypt.simpleEncrypt(aTickStr);
                    Hashtable aReplaceValues = new Hashtable();
                    aReplaceValues.Add("[/logo/]", emailpath);
                    aReplaceValues.Add("[/username/]", aUsername);
                    aReplaceValues.Add("[/resetpasswordurl/]", reseturl);

                    //get group admin group
                    //  aspnet_User aaspnet_User = aspnet_User.SingleOrDefault(x => x.UserName == Membership.GetUser().UserName);
                    // admin_group aadmin_group = admin_group.SingleOrDefault(x => x.user_id == aaspnet_User.UserId);

                    //edited for multi group admin
                    //  group aGroup = group.SingleOrDefault(x => x.id == Convert.ToInt32(Session["CurrentAdminGroup"]));
                    // group aGroup = group.SingleOrDefault(x => x.id == aadmin_group.group_id);

                    EmailManager.SendClientResetPasswordMail(aMembershipUser.Email, aUsername, aReplaceValues, clientid, this.Response);
                    EmailSendLit.Text = "Reset Password email is sent for Username: " + aUsername;

                    Logger.LogInfo(Membership.GetUser().UserName + "- set password username :" + aMembershipUser.UserName, this.GetType());

                }
            }
            if (e.CommandName == "claimpoints")
            {
                if (Request.QueryString["userid"] != null)
                {
                    int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                    Response.Redirect("MemberClaimPoints.aspx?userid=" + Request.QueryString["userid"] + "&clientid=" + clientid);
                }
            }
            if (e.CommandName == "redeemreward")
            {
                if (Request.QueryString["userid"] != null)
                {
                    int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                    Response.Redirect("MemberRewards.aspx?userid=" + Request.QueryString["userid"] + "&clientid=" + clientid);
                }
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    LinkButton ResetBut = e.Item.FindControl("ResetBut") as LinkButton;
                    LinkButton ClaimPointsBut = e.Item.FindControl("ClaimPointsBut") as LinkButton;
                    LinkButton RedeemRewardBut = e.Item.FindControl("RedeemRewardBut") as LinkButton;
                    CheckBox LinkCB = e.Item.FindControl("LinkCB") as CheckBox;
                    //Guid UserID = (Guid)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["userid"];
                    int clientid = (int)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["clientid"];
                    if (Request.QueryString["userid"] != null)
                    {
                        string UserID = Request.QueryString["userid"];
                        var y = ClientManager.getRedemptionMemberClient(new Guid(UserID), clientid);

                        //int promotionid = -1;
                        //if (Request.QueryString["promotionid"] != null)
                        //{
                        //    promotionid = int.Parse(Request.QueryString["promotionid"]);
                        //}
                        ////Literal ClientidLit = e.Item.FindControl("ClientidLit") as Literal;
                        ////ClientidLit.Text = clientid;

                        //PromotionByPointReward promotionByPointReward = ClientManager.getPromotionByPointReward(promotionid, rewardid);

                        if (y != null)
                        {
                            ClaimPointsBut.Visible = true;
                            RedeemRewardBut.Visible = true;
                            ResetBut.Visible = true;
                            LinkCB.Enabled = false;
                            LinkCB.Checked = true;
                            dataBoundItem["receivenewsletter"].Text = y.receivenewsletter.ToString();
                            dataBoundItem["pointbalance"].Text = y.pointbalance.ToString();

                        }
                        else
                        {
                            ClaimPointsBut.Visible = false;
                            RedeemRewardBut.Visible = false;
                            ResetBut.Visible = false;
                            LinkCB.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception eee)
            { }
        }
        protected void LinkCB_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                //   string folderId = Request["id"].ToString();
                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];

                    CheckBox chkbx = (CheckBox)sender;
                    GridDataItem item = (GridDataItem)chkbx.NamingContainer;
                    int clientid = (int)RadGrid1.MasterTableView.DataKeyValues[item.ItemIndex]["clientid"];
                    if (chkbx.Checked)
                    {
                        // link member to client
                        bool success = ClientManager.insertRedemptionMemberClient(
                            new Guid(userid), clientid, false, false);

                        MembershipUser aMembershipUser = Membership.GetUser(new Guid(userid));
                        Logger.LogInfo(Membership.GetUser().UserName + "- linked  username :" 
                            + aMembershipUser.UserName
                           + "client ID :"
                            + clientid
                            , this.GetType());

                    }
                    else
                    {
                        // unlink member to client
                        bool success = ClientManager.deleteRedemptionMemberClient(
                       new Guid(userid), clientid);
                    }

                    RadGrid1.Rebind();

                }
            }
            catch (Exception)
            { }

        }
        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }
    }
}