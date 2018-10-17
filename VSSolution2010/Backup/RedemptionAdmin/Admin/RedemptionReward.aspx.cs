using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using System.Web.Security;
using ApplicationServices;
using System.Collections;

namespace RedemptionAdmin.Admin
{
    public partial class RedemptionReward : System.Web.UI.Page
    {
      //  bool firstItemLoaded = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // firstItemLoaded = false;
            }
        }


        protected void loadRedemptionReward(int redemptionrewardid)
        {
            var redemptionreward = ClientManager.getRedemptionReward(redemptionrewardid);
            RedemptionidLit.Text = redemptionreward.redemptionrewardid.ToString();
            var client = ClientManager.getClient(redemptionreward.clientid);
            var redemptionMember = ClientManager.getRedemptionMember(redemptionreward.UserId);
            ClientNameLit.Text = client.name;
            MembershipUser member = Membership.GetUser(redemptionreward.UserId);
            UseridLit.Text = member.UserName;
            FirstNameLit.Text = redemptionMember.firstname;
            LastNameLit.Text = redemptionMember.lastname;
            NRICLit.Text = redemptionMember.NRIC;
            ContactNoLit.Text = redemptionMember.contactno;
            var promotion = ClientManager.getPromotion(redemptionreward.promotionid);
            //    InvoiceNoTB.Text = redemptionByProductReceipt.invoiceno;
            PromotionLit.Text = promotion.name;
            //    PromotionDDL.SelectedValue = redemptionByProductReceipt.promotionid.ToString();
            //    ResellerDDL2.SelectedValue = redemptionByProductReceipt.resellerid.ToString();
            //   PurchaseDateRadDatePicker.SelectedDate = redemptionByProductReceipt.purchasedate;
            StatusDDL.SelectedValue = redemptionreward.status.ToString();
            // int resellerIndex= ResellerDDL2.FindItemIndexByValue(redemptionbypointreceipt.resellerid.ToString());
            // ResellerDDL2.SelectedValue = redemptionbypointreceipt.resellerid.ToString();
            //  InvoiceNoTB.Text = redemptionbypointreceipt.invoiceno;//todo
            // PurchaseDateRadDatePicker.SelectedDate = redemptionbypointreceipt.purchasedate;//todo
            // totalpointsLit.Text = redemptionbypointreceipt.totalpoints.ToString();//todo
            CollectionModeRBL.SelectedValue = redemptionreward.modeofcollection.ToString();

            //   ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + redemptionReward.receiptpath;

            //var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
            //ReceiptItemRadGrid.DataSource = x;
            //ReceiptItemRadGrid.Rebind();

            //load productddl
            var y = ClientManager.getAllProductsByPromotionid(redemptionreward.promotionid);
            //var y = ClientManager.getAllProductsByPromotionid(redemptionByProductReceipt.promotionid);



            //load rewardfgrid
            // int redemptionbyproductreceiptid = int.Parse(ReceiptidLit.Text);
            //var x = ClientManager.getAllRedemptionRewardsByReceiptId(redemptionbyproductreceiptid);
            //RedemptionRewardRadGrid.DataSource = x;
            RedemptionRewardRadGrid.Rebind();


            UpdateRedemptionBut.CommandArgument = redemptionreward.redemptionrewardid.ToString();

            if (Roles.IsUserInRole("Admin"))
            {
                DeleteBut.Visible = true;
            }
            else
            {
                DeleteBut.Visible = false;
            }
        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            //ClientDetailPnl.Visible = false;
        }

        protected void RedemptionRewardRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionRewards();
            RedemptionRewardRadGrid.DataSource = x;

        }

        protected void RedemptionRewardRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "process")
            {
                EmailSendLit.Text = "";
                int redemptionrewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionrewardid");

                loadRedemptionReward(redemptionrewardid);
                ClientDetailPnl.Visible = true;


            }
            if (e.CommandName == "SendRedemptionEmail")
            {

                int redemptionrewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionrewardid");
                string rewardname = ((GridDataItem)e.Item).GetDataKeyValue("rewardname").ToString();
                string productname = ((GridDataItem)e.Item).GetDataKeyValue("productname").ToString();
                string serialno = ((GridDataItem)e.Item).GetDataKeyValue("serialno").ToString();
                int type = (int)((GridDataItem)e.Item).GetDataKeyValue("type");
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                int status = (int)((GridDataItem)e.Item).GetDataKeyValue("status");
                int modeofcollection = (int)((GridDataItem)e.Item).GetDataKeyValue("modeofcollection");
                int redemptionbyproductreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbyproductreceiptid");
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
                MembershipUser AdminembershipUser = Membership.GetUser();
                MembershipUser membershipUser = Membership.GetUser(UserId);

                //send email
                bool canSendEmail;
                RedemptionMember redemptionMember = ClientManager.getRedemptionMember((Guid)Membership.GetUser(UserId).ProviderUserKey);
                var client = ClientManager.getClient(clientid);
                string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                Hashtable values = new Hashtable();

                var redemptionByPointTransaction = ClientManager.getRedemptionByPointTransaction(
                  redemptionbyproductreceiptid);

                if (type == (int)PromotionType.BY_POINT)
                {
                    //by point
                    int rewardpoints = (int)((GridDataItem)e.Item).GetDataKeyValue("rewardpoints");
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

                    switch (status)
                    {
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:                          
                      //  case (int)RedemptionRewardState.PENDING_PROCESS:
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                            values.Add("[/RedemptionItem/s/]", rewardname);
                            values.Add("[/OutstandingQuantity/]", "1");
                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                        case (int)RedemptionRewardState.COLLECTED:
                            values.Add("[/RedemptionItem/s/]", rewardname);
                            values.Add("[/OutstandingQuantity/]", "0");
                            break;
                    }

                    switch (modeofcollection)
                    {
                        case (int)CollectionMode.PICK_UP:
                            canSendEmail = EmailManager.SendRedemptionByPointsSelfCollectMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);

                            break;
                        case (int)CollectionMode.DELIVERY:
                            canSendEmail = EmailManager.SendRedemptionByPointsDeliveryMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                            break;
                    }

                    EmailSendLit.Text = "Redemption email is sent for Redemption ID:" + redemptionrewardid;
                }
                else
                {
                    //by product
                    var redemptionByProductReceipt = ClientManager.getRedemptionByProductReceipt(redemptionbyproductreceiptid);
                    var reseller = ClientManager.getReseller((int)redemptionByProductReceipt.resellerid);

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

                    switch (status)
                    {
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:                      
                       // case (int)RedemptionRewardState.PENDING_PROCESS:
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                            values.Add("[/RedemptionItem/s/]", rewardname);
                            values.Add("[/OutstandingQuantity/]", "1");
                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                        case (int)RedemptionRewardState.COLLECTED:
                            values.Add("[/RedemptionItem/s/]", rewardname);
                            values.Add("[/OutstandingQuantity/]", "0");
                            break;
                    }

                    switch (modeofcollection)
                    {
                        case (int)CollectionMode.PICK_UP:
                            canSendEmail = EmailManager.SendRedemptionByProductsSelfCollectMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);

                            break;
                        case (int)CollectionMode.DELIVERY:
                            canSendEmail = EmailManager.SendRedemptionByProductsDeliveryMail(
                                                     membershipUser.UserName,
                                                     redemptionMember.firstname,
                                                     values, client.clientid, this.Response);
                            break;
                    }

                    EmailSendLit.Text = "Redemption email is sent for Redemption ID:" + redemptionrewardid;

                    Logger.LogInfo(Membership.GetUser().UserName + "- Redemption email is sent for Redemption ID:" + redemptionrewardid
 , this.GetType());
                }
            }


            //if (e.CommandName == "PrintFriendly")
            //{
            //    int redemptionrewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionrewardid");
            //    //Session.Add("RedemptionPrintFrieldly", "lalalalalala");
            //    Response.Redirect("RedemptionPrintFriendly.aspx?redemptionrewardid=" + redemptionrewardid);
            //}
        }

        protected void RedemptionRewardRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    string redemptionrewardid = (string)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionrewardid"].ToString();
                    int status = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    int modeofcollection = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["modeofcollection"];
                    int rewardpoints = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardpoints"];
                    int type = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["type"];
                    string productname = RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productname"].ToString();
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    //   HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;
                    Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                    //    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;
                    Literal redemptionrewardidLit = e.Item.FindControl("redemptionrewardidLit") as Literal;
                    HyperLink PrintFriendlyHL = e.Item.FindControl("PrintFriendlyHL") as HyperLink;
                    redemptionrewardidLit.Text = redemptionrewardid;
                    PrintFriendlyHL.NavigateUrl= "RedemptionPrintFriendly.aspx?redemptionrewardid=" + redemptionrewardid;
                    switch (status)
                    {
                        //case (int)RedemptionRewardState.PENDING_PROCESS:
                        //    //RedemptionRewardState.PENDING_PROCESS.ToString()
                        //    dataBoundItem["status"].Text = RedemptionRewardState.PENDING_PROCESS.ToString();//"Processing";

                        //    break;
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                            //RedemptionRewardState.PROCESSED.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.PENDING_DELIVERY+"-"+RedemptionRewardState.PENDING_DELIVERY.ToString();//"Approved";

                            break;
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                            //RedemptionRewardState.REDEEMED.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.PENDING_COLLECTION+"-"+RedemptionRewardState.PENDING_COLLECTION.ToString();//"Redeemed";

                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.DELIVERED+"-"+RedemptionRewardState.DELIVERED.ToString();//"Processing";

                            break;
                        case (int)RedemptionRewardState.COLLECTED:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text =(int)RedemptionRewardState.COLLECTED+"-"+ RedemptionRewardState.COLLECTED.ToString();//"Processing";

                            break;
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text =(int)RedemptionRewardState.ARRANGING_DELIVERY+"-"+ RedemptionRewardState.ARRANGING_DELIVERY.ToString();//"Processing";

                            break;
                        case (int)RedemptionRewardState.VOID:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.VOID + "-" + RedemptionRewardState.VOID.ToString();//"Processing";

                            break;
                    }

                    switch (modeofcollection)
                    {
                        case 0:
                            //CollectionMode.PICK_UP
                            dataBoundItem["modeofcollection"].Text = 0+"-"+ "Self Collect";

                            break;
                        case 1:
                            //CollectionMode.DELIVERY
                            dataBoundItem["modeofcollection"].Text = 1 + "-" + "Delivery";

                            break;
                    }

                    switch (type)
                    {
                        case 0:
                            //by points
                            NoteLbl.Text = "- " + rewardpoints + " points";
                            dataBoundItem["type"].Text = 0 + "-" + PromotionType.BY_POINT.ToString();
                            break;
                        case 1:
                            //by product
                            NoteLbl.Text = productname;
                            dataBoundItem["type"].Text = 1 + "-" + PromotionType.BY_PRODUCT.ToString();
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                string errorMessage = "Exception occurred while binding the data item in the page. Details are: " + exc.ToString();
                Trace.Warn(this.ToString(), errorMessage, exc);
            }
        }

        protected void ResellerDDL2_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
        }
        protected void DeleteBut_Click(object sender, EventArgs e)
        {
            int redemptionrewardid = int.Parse(UpdateRedemptionBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                ApplicationServices.RedemptionReward redemptionReward = ClientManager.getRedemptionReward(redemptionrewardid);

                int rewardid = redemptionReward.rewardid;
                     var redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                            redemptionReward.UserId, redemptionReward.clientid);
                   
                //add stock back to reward balance
                ClientManager.increaseRewardQtyBy1(rewardid);

                //if by points
                if (redemptionReward.type == (int)PromotionType.BY_POINT)
                { 
                      int newPointBalance = redemptionMemberClient.pointbalance + redemptionReward.rewardpoints;

                    //return points 
                ClientManager.updateRedemptionMemberClientBalance(redemptionReward.UserId,
                    redemptionReward.clientid,
                    newPointBalance);
                string notes = "VOID | Redemption ID:" + redemptionReward.redemptionrewardid + " | Points:" + redemptionReward.rewardpoints;
                    //add void transaction
                ClientManager.insertRedemptionByPointTransaction(
                      redemptionReward.UserId,
                   redemptionReward.clientid,
                   (int)RedemptionByPointTransactionType.DEBIT,
                  redemptionReward.rewardpoints,
                   newPointBalance,
                   notes);

                }

                ClientManager.deleteRedemptionReward(
               redemptionrewardid);
                ClientDetailPnl.Visible = false;

                scope.Complete();
                Logger.LogInfo(Membership.GetUser().UserName + "- deleted and return stock for Redemption ID:" + redemptionrewardid
, this.GetType());
            }
  
            RedemptionRewardRadGrid.Rebind();
        }
        protected void UpdateRedemptionBut_Click(object sender, EventArgs e)
        {
            int redemptionrewardid = int.Parse(UpdateRedemptionBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                ClientManager.updateRedemptionRedemptionReward(
                    redemptionrewardid,
                   int.Parse(CollectionModeRBL.SelectedValue), int.Parse(StatusDDL.SelectedValue));

                ClientDetailPnl.Visible = false;


                //        ClientManager.updateRedemptionByProductReceipt(
                //redemptionbyproductreceiptid,
                //   int.Parse(StatusDDL.SelectedValue),
                // InvoiceNoTB.Text.Trim(), int.Parse(ResellerDDL2.SelectedValue),
                //   PurchaseDateRadDatePicker.SelectedDate,
                //    int.Parse(PromotionDDL.SelectedValue), PromotionDDL.SelectedItem.Text);


                /*    ClientManager.approveRedemptionByPointReceipt(
                        redemptionbypointreceiptid,
                        int.Parse(ResellerDDL2.SelectedValue),
                        InvoiceNoTB.Text.Trim(),
                        (DateTime)PurchaseDateRadDatePicker.SelectedDate);
                    RedemptionByPointReceipt redemptionByPointReceipt = ClientManager.getRedemptionByPointReceipt(redemptionbypointreceiptid);
                    RedemptionMemberClient redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                        redemptionByPointReceipt.UserId,
                        redemptionByPointReceipt.clientid);
                    int newPointBalance = redemptionMemberClient.pointbalance + redemptionByPointReceipt.totalpoints;

                    //RedemptionByPointTransaction
                    string notes = "Receipt ID:" + redemptionByPointReceipt.redemptionbypointreceiptid +
                        " | Points:" + redemptionByPointReceipt.totalpoints;
                    ClientManager.insertRedemptionByPointTransaction(
                        redemptionByPointReceipt.UserId,
                        redemptionByPointReceipt.clientid,
                        (int)RedemptionByPointTransactionType.DEBIT,
                        redemptionByPointReceipt.totalpoints,
                        newPointBalance,
                        notes);
                    ClientManager.updateRedemptionMemberClientBalance(
                        redemptionByPointReceipt.UserId,
                       redemptionByPointReceipt.clientid,
                       newPointBalance);
                    */
                scope.Complete();
            }
            //reload radgrid
            // var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
            //ReceiptRadGrid.DataSource = x;
            // ReceiptRadGrid.Rebind();
            RedemptionRewardRadGrid.Rebind();

            Logger.LogInfo(Membership.GetUser().UserName + "- updated Redemption ID:" + redemptionrewardid
, this.GetType());
        }
    }
}