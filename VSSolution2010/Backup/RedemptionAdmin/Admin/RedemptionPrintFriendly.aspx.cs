using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ApplicationServices;
using RedemptionData;
using System.Collections;

namespace RedemptionAdmin.Admin
{
    public partial class RedemptionPrintFriendly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["RedemptionPrintFrieldly"] != null)
            //{
            //    string RedemptionPrintFrieldly = "";
            //    if (!IsPostBack)
            //    {
            //         RedemptionPrintFrieldly = Session["RedemptionPrintFrieldly"].ToString();
            //        Session.Remove("RedemptionPrintFrieldly");
            //        ViewState["RedemptionPrintFrieldly"] = RedemptionPrintFrieldly;

            //        Response.Write(RedemptionPrintFrieldly);
            //    }
            //    else {
            //        RedemptionPrintFrieldly = ViewState["RedemptionPrintFrieldly"].ToString();
            //        Response.Write(RedemptionPrintFrieldly);
            //    }
            //}


            if (Request.QueryString["redemptionrewardid"] != null)
            {
                int redemptionrewardid = int.Parse(Request.QueryString["redemptionrewardid"]);
                string output = "NA";
                ApplicationServices.RedemptionReward redemptionReward = ClientManager.getRedemptionReward(redemptionrewardid);
              //  Response.Write("1");
                       
                string productname = redemptionReward.productname;
                string serialno = redemptionReward.serialno;
                int type = redemptionReward.type;
                int clientid = redemptionReward.clientid;
                int status = redemptionReward.status;
                //Response.Write("2"); 
                int modeofcollection = redemptionReward.modeofcollection;
                int redemptionbyproductreceiptid = (int)redemptionReward.redemptionbyproductreceiptid;
                Guid UserId = redemptionReward.UserId;
                MembershipUser AdminembershipUser = Membership.GetUser();
                MembershipUser membershipUser = Membership.GetUser(UserId);
             //   Response.Write("3");
                //send email
                bool canSendEmail;
                RedemptionMember redemptionMember = ClientManager.getRedemptionMember(UserId);
                var client = ClientManager.getClient(clientid);
                string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                Hashtable values = new Hashtable();

                var redemptionByPointTransaction = ClientManager.getRedemptionByPointTransaction(
                  redemptionbyproductreceiptid);
              //  Response.Write("34");
                if (type == (int)PromotionType.BY_POINT)
                {
                    //by point
                    int rewardpoints = (int)redemptionReward.rewardpoints;
                    values.Add("[/logo/]", emailpath);
                    values.Add("[/SubmissionDate/]", DateTime.Now.ToString("dd/MM/yyyy"));
                    values.Add("[/RedemptionNo/]", redemptionrewardid);
                    values.Add("[/ApprovedBy/]", AdminembershipUser.UserName);
                    values.Add("[/MemberName/]", redemptionMember.firstname + " " + redemptionMember.lastname);
                    values.Add("[/NRICNo/]", redemptionMember.NRIC);
                    values.Add("[/ContactNo/]", redemptionMember.contactno);
                    values.Add("[/DeliveryAddress/]", redemptionMember.mailingaddress + ", Singapore " + redemptionMember.postalcode);
                    values.Add("[/PointsDeducted/]", rewardpoints);
                    values.Add("[/BalancePoints/]", redemptionByPointTransaction.balance);
                   // Response.Write("5");
                    switch (status)
                    {
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:
                        //  case (int)RedemptionRewardState.PENDING_PROCESS:
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                            values.Add("[/RedemptionItem/s/]", redemptionReward.rewardname);
                            values.Add("[/OutstandingQuantity/]", "1");
                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                        case (int)RedemptionRewardState.COLLECTED:
                            values.Add("[/RedemptionItem/s/]", redemptionReward.rewardname);
                            values.Add("[/OutstandingQuantity/]", "0");
                            break;
                    }
                   // Response.Write("6");
                    switch (modeofcollection)
                    {
                        case (int)CollectionMode.PICK_UP:
                            output = EmailManager.getRedemptionByPointsSelfCollectMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                           // output = "1";
                            break;
                        case (int)CollectionMode.DELIVERY:
                            output = EmailManager.getRedemptionByPointsDeliveryMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                       
                            break;
                    }
                }
                else
                {
                    //by product
                    var redemptionByProductReceipt = ClientManager.getRedemptionByProductReceipt(redemptionbyproductreceiptid);
                    var reseller = ClientManager.getReseller((int)redemptionByProductReceipt.resellerid);
                  //  Response.Write("8");
                    values.Add("[/logo/]", emailpath);
                    values.Add("[/SubmissionDate/]", DateTime.Now.ToString("dd/MM/yyyy"));
                    values.Add("[/RedemptionNo/]", redemptionrewardid);
                    values.Add("[/ApprovedBy/]", AdminembershipUser.UserName);
                    values.Add("[/MemberName/]", redemptionMember.firstname + " " + redemptionMember.lastname);
                    values.Add("[/NRICNo/]", redemptionMember.NRIC);
                    values.Add("[/ContactNo/]", redemptionMember.contactno);
                    values.Add("[/DeliveryAddress/]", redemptionMember.mailingaddress + ", Singapore " + redemptionMember.postalcode);
                    values.Add("[/Reseller/]", reseller.name);
                    values.Add("[/InvoiceNo/]", redemptionByProductReceipt.invoiceno);
                    values.Add("[/ItemPurchased/]", productname);
                    values.Add("[/ItemSerialNo/]", serialno);
                    values.Add("[/ItemQty/]", 1);
                  //  Response.Write("9");
                    switch (status)
                    {
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:
                        // case (int)RedemptionRewardState.PENDING_PROCESS:
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                            values.Add("[/RedemptionItem/s/]", redemptionReward.rewardname);
                            values.Add("[/OutstandingQuantity/]", "1");
                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                        case (int)RedemptionRewardState.COLLECTED:
                            values.Add("[/RedemptionItem/s/]", redemptionReward.rewardname);
                            values.Add("[/OutstandingQuantity/]", "0");
                            break;
                    }

                    switch (modeofcollection)
                    {
                        case (int)CollectionMode.PICK_UP:
                            output = EmailManager.getRedemptionByProductsSelfCollectMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                           // Response.Write("10");
                            break;
                        case (int)CollectionMode.DELIVERY:
                            output = EmailManager.getRedemptionByProductsDeliveryMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                           // Response.Write("11");
                            break;
                    }

                }


                Response.Write(output);

            }
        }
    }
}