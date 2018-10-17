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
using System.Data;

namespace RedemptionAdmin.Admin
{
    public partial class RedemptionByProduct : System.Web.UI.Page
    {
        // bool firstItemLoaded = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load reseller ddl
                var x = ClientManager.getAllResellers();
                ResellerDDL2.DataTextField = "name";
                ResellerDDL2.DataValueField = "resellerid";
                ResellerDDL2.DataSource = x;
                ResellerDDL2.DataBind();

                ResellerDDL2.Items.Insert(0, new RadComboBoxItem("-select-", string.Empty));

                //load reseller ddl
                var y = ClientManager.getAllPromotionsByProduct();
                PromotionDDL.DataTextField = "name";
                PromotionDDL.DataValueField = "promotionid";
                PromotionDDL.DataSource = y;
                PromotionDDL.DataBind();


                PromotionDDL.Items.Insert(0, new RadComboBoxItem("-select-", string.Empty));


                //  firstItemLoaded = false;
            }
            PurchaseDateRadDatePicker.MaxDate = DateTime.Today.Date.AddDays(1).AddMilliseconds(-1);
      
        }
        protected void ReceiptRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionByProductReceipt();
            ReceiptRadGrid.DataSource = x;
        }

        protected void loadRedemptionByProductReceipt(int redemptionbyproductreceiptid)
        {
            var redemptionByProductReceipt = ClientManager.getRedemptionByProductReceipt(redemptionbyproductreceiptid);
            ReceiptidLit.Text = redemptionByProductReceipt.redemptionbyproductreceiptid.ToString();
            var client = ClientManager.getClient(redemptionByProductReceipt.clientid);
            ClientNameLit.Text = client.name;
            MembershipUser member = Membership.GetUser(redemptionByProductReceipt.UserId);
            UseridLit.Text = member.UserName;
            var promotion = ClientManager.getPromotion(redemptionByProductReceipt.promotionid);
            InvoiceNoTB.Text = redemptionByProductReceipt.invoiceno;
            //   PromotionLit.Text = promotion.name;
            PromotionDDL.SelectedValue = redemptionByProductReceipt.promotionid.ToString();
            ResellerDDL2.SelectedValue = redemptionByProductReceipt.resellerid.ToString();
            PurchaseDateRadDatePicker.SelectedDate = redemptionByProductReceipt.purchasedate;
            StatusDDL.SelectedValue = redemptionByProductReceipt.status.ToString();

            ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + redemptionByProductReceipt.receiptpath;

            bool canEdit;
            if ((redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.PROCESSED) ||
                (redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.DUPLICATE) ||
                (redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.REJECTED))
            {
                //  RedemptionDetailsEditPnl.Visible = false;
                canEdit = false;
                if (Roles.IsUserInRole("Admin"))
                {
                    canEdit = true;
                }
            }
            else
            {
                // RedemptionDetailsEditPnl.Visible = true;
                canEdit = true;
            }
            InvoiceNoTB.Enabled = canEdit;
            PromotionDDL.Enabled = false;
            ResellerDDL2.Enabled = canEdit;
            PurchaseDateRadDatePicker.Enabled = canEdit;
            StatusDDL.Enabled = canEdit;
            UpdateReceiptBut.Enabled = canEdit;
            RedemptionDetailsEditPnl.Visible = canEdit;
            serialnoTB.Text = "";
            bool showRedemptionDetails = false;
            if ((redemptionByProductReceipt.resellerid == null) ||
                (redemptionByProductReceipt.invoiceno == null) ||
                (redemptionByProductReceipt.purchasedate == null))
            {
                showRedemptionDetails = false;
            }
            else
            {
                showRedemptionDetails = true;
            }

            RedemptionDetailsPnl.Visible = showRedemptionDetails;
            // int resellerIndex= ResellerDDL2.FindItemIndexByValue(redemptionbypointreceipt.resellerid.ToString());
            // ResellerDDL2.SelectedValue = redemptionbypointreceipt.resellerid.ToString();
            //  InvoiceNoTB.Text = redemptionbypointreceipt.invoiceno;//todo
            // PurchaseDateRadDatePicker.SelectedDate = redemptionbypointreceipt.purchasedate;//todo
            // totalpointsLit.Text = redemptionbypointreceipt.totalpoints.ToString();//todo


            //   ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + redemptionReward.receiptpath;

            //var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
            //ReceiptItemRadGrid.DataSource = x;
            //ReceiptItemRadGrid.Rebind();

            //load productddl
            //var y = ClientManager.getAllProductsByPromotionid(redemptionByProductReceipt.promotionid);
            ////var y = ClientManager.getAllProductsByPromotionid(redemptionByProductReceipt.promotionid);

            //ProductDDL.DataTextField = "model";
            //ProductDDL.DataValueField = "productid";
            //ProductDDL.DataSource = y;

            //ProductDDL.DataBind();
            //ProductDDL.Items.Insert(0, new RadComboBoxItem("-select-", string.Empty));

            var z = ClientManager.getAllProductRewardsByPromotionid(redemptionByProductReceipt.promotionid);

            ProductDDL2.DataSource = z;
            ProductDDL2.DataBind();

            //load rewardfgrid
            // int redemptionbyproductreceiptid = int.Parse(ReceiptidLit.Text);
            var x = ClientManager.getAllRedemptionRewardsByReceiptId(redemptionbyproductreceiptid);
            RedemptionRewardRadGrid.DataSource = x;
            RedemptionRewardRadGrid.Rebind();


            AddItemBut.CommandArgument = redemptionByProductReceipt.redemptionbyproductreceiptid.ToString();
            UpdateReceiptBut.CommandArgument = redemptionByProductReceipt.redemptionbyproductreceiptid.ToString();





        }
        protected void ReceiptRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "Process")
            {
                int redemptionbyproductreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbyproductreceiptid");
                loadRedemptionByProductReceipt(redemptionbyproductreceiptid);
                ClientDetailPnl.Visible = true;
                //loadClientDDL();
                //var promotion = ClientManager.getPromotion(promotionid);

                //clientDDL.SelectedValue =  promotion.clientid.ToString();
                //startDateTB.SelectedDate = promotion.startdate;
                //endDateTB.SelectedDate=promotion.enddate;
                //graceDateTB.SelectedDate = promotion.gracedate;
                //PrefixTB.Text = promotion.prefix;
                //NameTB.Text = promotion.name;
                //Session.Add("promotionid", promotionid);
                //ClientDetailPnl.Visible = true;
                //ShowCreatePromotionBut.Visible = false;
                //CreatePromotionBut.Visible = false;
                //UpdatePromotionBut.Visible = true;
                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
        }
        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            RedemptionDetailsEditPnl.Visible = false;
            RedemptionDetailsPnl.Visible = false;
        }

        protected void ReceiptRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {

                    int redemptionbyproductreceiptid = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionbyproductreceiptid"];
                    int status = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    LinkButton ProcessBut = e.Item.FindControl("ProcessBut") as LinkButton;
                    Literal redemptionbyproductreceiptidLit = e.Item.FindControl("redemptionbyproductreceiptidLit") as Literal;
                    redemptionbyproductreceiptidLit.Text = redemptionbyproductreceiptid.ToString();

                    switch (status)
                    {
                        case (int)RedemptionByProductReceiptState.PENDING_PROCESS:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionByProductReceiptState.PENDING_PROCESS+"-"+RedemptionByProductReceiptState.PENDING_PROCESS.ToString();//"Processing";
                            ProcessBut.Text = "Manage";
                            break;
                        case (int)RedemptionByProductReceiptState.PROCESSED:
                            //RedemptionRewardState.PROCESSED.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionByProductReceiptState.PROCESSED+"-"+RedemptionByProductReceiptState.PROCESSED.ToString();//"Approved";
                            ProcessBut.Text = "View";
                            break;
                        case (int)RedemptionByProductReceiptState.DUPLICATE:
                            //RedemptionRewardState.REDEEMED.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionByProductReceiptState.DUPLICATE+"-"+RedemptionByProductReceiptState.DUPLICATE.ToString();//"Redeemed";
                            ProcessBut.Text = "View";
                            break;
                        case (int)RedemptionByProductReceiptState.REJECTED:
                            //RedemptionRewardState.REDEEMED.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionByProductReceiptState.REJECTED + "-" + RedemptionByProductReceiptState.REJECTED.ToString();//"Redeemed";
                            ProcessBut.Text = "View";
                            break;
                        case (int)RedemptionByProductReceiptState.VOID:
                            //RedemptionRewardState.REDEEMED.ToString()
                            dataBoundItem["status"].Text =(int)RedemptionByProductReceiptState.VOID+"-"+ RedemptionByProductReceiptState.VOID.ToString();//"Redeemed";
                            ProcessBut.Text = "View";
                            break;

                    }
                    HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;

                    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;

                    ////load first item
                    //if (!firstItemLoaded)
                    //{
                    //    firstItemLoaded = true;
                    //    //int redemptionbypointreceiptid = (int)(ReceiptItemRadGrid.Items[0]).GetDataKeyValue("redemptionbypointreceiptid");
                    //    loadRedemptionByProductReceipt(redemptionbyproductreceiptid);
                    //}
                }
            }
            catch (Exception exc)
            {
                string errorMessage = "Exception occurred while binding the data item in the page. Details are: " + exc.ToString();
                Trace.Warn(this.ToString(), errorMessage, exc);
            }
        }

        protected void RedemptionRewardRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int redemptionbyproductreceiptid = int.Parse(ReceiptidLit.Text);
            var x = ClientManager.getAllRedemptionRewardsByReceiptId(redemptionbyproductreceiptid);
            RedemptionRewardRadGrid.DataSource = x;
            //  RedemptionRewardRadGrid.Rebind();

        }
        protected void RedemptionRewardRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //if (e.CommandName == "delete2")
            //{
            //    int redemptionbypointreceiptItemid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptitemid");
            //    int redemptionbypointreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptid");

            //    ClientManager.deleteRedemptionByPointReceiptItem(redemptionbypointreceiptItemid);
            //    var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
            //    ReceiptItemRadGrid.DataSource = x;
            //    ReceiptItemRadGrid.Rebind();

            //    List<RedemptionByPointReceiptItem> list = (List<RedemptionByPointReceiptItem>)x;
            //    int total = 0;
            //    foreach (RedemptionByPointReceiptItem item in list)
            //    {
            //        total += item.productpoints;
            //    }
            //  //  totalpointsLit.Text = total.ToString();
            //    ClientManager.updateRedemptionByPointReceiptPoint(redemptionbypointreceiptid, total);

            //}

            if (e.CommandName == "SendRedemptionEmail")
            {
                int redemptionrewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionrewardid");
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
                ApplicationServices.RedemptionReward redemptionReward = ClientManager.getRedemptionReward(redemptionrewardid);
                //send email
                bool canSendEmail;
                RedemptionMember redemptionMember = ClientManager.getRedemptionMember((Guid)Membership.GetUser(UserId).ProviderUserKey);
                var client = ClientManager.getClient(clientid);
                string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;

                Hashtable values = new Hashtable();

                var redemptionByPointTransaction = ClientManager.getRedemptionByPointTransaction(
                  redemptionbyproductreceiptid);


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
                    //    case (int)RedemptionRewardState.PENDING_PROCESS:
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

            }
        }
        protected void RedemptionRewardRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {

                    int modeofcollection = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["modeofcollection"];
                    int status = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    int rewardpoints = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardpoints"];
                    int type = (int)RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["type"];
                    string productname = RedemptionRewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productname"].ToString();
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                    LinkButton DeleteBut = e.Item.FindControl("DeleteBut") as LinkButton;
                    LinkButton SendApprovalEmailBut = e.Item.FindControl("SendApprovalEmailBut") as LinkButton;
                    DeleteBut.Visible = RedemptionDetailsEditPnl.Visible;
                    SendApprovalEmailBut.Visible = RedemptionDetailsEditPnl.Visible;
                    switch (modeofcollection)
                    {
                        case 0:
                            //CollectionMode.PICK_UP
                            dataBoundItem["modeofcollection"].Text = "Self Collect";

                            break;
                        case 1:
                            //CollectionMode.DELIVERY
                            dataBoundItem["modeofcollection"].Text = "Delivery";

                            break;
                    }

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
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.COLLECTED+"-"+RedemptionRewardState.COLLECTED.ToString();//"Processing";

                            break;
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.ARRANGING_DELIVERY+"-"+RedemptionRewardState.ARRANGING_DELIVERY.ToString();//"Processing";

                            break;
                        case (int)RedemptionRewardState.VOID:
                            //RedemptionRewardState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = (int)RedemptionRewardState.VOID + "-" + RedemptionRewardState.VOID.ToString();//"Processing";

                            break;
                    }

                    switch (type)
                    {
                        case 0:
                            //by points
                            NoteLbl.Text = "- " + rewardpoints + " points";
                            dataBoundItem["type"].Text = PromotionType.BY_POINT.ToString();
                            break;
                        case 1:
                            //by product
                            NoteLbl.Text = productname;
                            dataBoundItem["type"].Text = PromotionType.BY_PRODUCT.ToString();
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

        protected void AddItemBut_Click(object sender, EventArgs e)
        {
            int redemptionbyproductreceiptid = int.Parse(AddItemBut.CommandArgument);
            //******** wrap this in a transaction!!
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                try
                {       // RedemptionData.ClientManager.Product2 ss = (RedemptionData.ClientManager.Product2)ProductDDL2.SelectedItem.DataItem;
                    string temp = ProductDDL2.SelectedValue;
                    string[] idArray = temp.Split('|');
                    //  Response.Write("<br>1:" );


                    //   Response.Write("<br>2redemptionbyproductreceiptid:" + redemptionbyproductreceiptid);
                    //  int productid = int.Parse(ProductDDL.SelectedValue);
                    int productid = int.Parse(idArray[0]);
                    int rewardid = int.Parse(idArray[1]);
                    //   Response.Write("<br>3:" + productid);
                    var product = ClientManager.getProduct(productid);
                    //   Response.Write("<br>4:" + product.productid);
                    var redemptionByProductReceipt = ClientManager.getRedemptionByProductReceipt(redemptionbyproductreceiptid);
                    //   Response.Write("<br>redemptionbyproductreceiptid:" + redemptionbyproductreceiptid);
                    //var promotionByProductProductReward = ClientManager.getPromotionByProductProductRewardByPromotionIdProductId(redemptionByProductReceipt.promotionid, productid);
                    //   Response.Write("<br>redemptionbyproductreceiptid:" + redemptionbyproductreceiptid);
                    var reward = ClientManager.getReward(rewardid);
                    //Response.Write("<br>redemptionbyproductreceiptid:" + redemptionbyproductreceiptid);
                    //Response.Write("<br>productid:" + productid);
                    //Response.Write("<br>product:" + product.productid);
                    //Response.Write("<br>redemptionByProductReceipt:" + redemptionByProductReceipt.redemptionbyproductreceiptid);
                    ////Response.Write("<br>promotionByProductProductReward:" + promotionByProductProductReward.productid);
                    //Response.Write("<br>redemptionByProductReceipt:" + redemptionByProductReceipt.redemptionbyproductreceiptid);
                    //Response.Write("<br>reward:" + reward.rewardid);
                    //Response.Write("<br>serialnoTB.Text.Trim():" + serialnoTB.Text.Trim());
                    //Response.Write("<br>redemptionByProductReceipt.remarks:" + redemptionByProductReceipt.remarks);
                   bool enoughstock= ClientManager.canReduceRewardQtyBy1(reward.rewardid);
                   if (enoughstock)
                   {



                       int status;

                       if (redemptionByProductReceipt.modeofcollection == (int)CollectionMode.DELIVERY)
                       {
                           status = (int)RedemptionRewardState.ARRANGING_DELIVERY;
                       }
                       else
                       {
                           status = (int)RedemptionRewardState.PENDING_COLLECTION;

                       }

                       int redemptionRewardid = ClientManager.insertRedemptionReward(
                           redemptionByProductReceipt.clientid, redemptionByProductReceipt.UserId,
                           redemptionByProductReceipt.promotionid,
                           redemptionByProductReceipt.promotionname,
                           product.productid, product.name,
                           reward.rewardid, reward.name, 0,
                           redemptionByProductReceipt.modeofcollection,
                          serialnoTB.Text.Trim(), redemptionByProductReceipt.remarks,
                      (int)PromotionType.BY_PRODUCT, status,
                      redemptionbyproductreceiptid);

                       //reduce the reward qty by 1
                       ClientManager.reduceRewardQtyBy1(reward.rewardid);
                       AddItemErrorLit.Text = "";

                       Logger.LogInfo(Membership.GetUser().UserName + "- added Redemption Receipt ID(ByProduct):" + redemptionbyproductreceiptid
                        , this.GetType());
                   }
                   else {
                       AddItemErrorLit.Text = "Cannot add redemption. Not enough stock for this reward.";
                   }
                    scope.Complete();
                }
                catch (Exception ee)
                { 
                
                }
                var x = ClientManager.getAllRedemptionRewardsByReceiptId(redemptionbyproductreceiptid);
                RedemptionRewardRadGrid.DataSource = x;
                RedemptionRewardRadGrid.Rebind();
          
            }
            /*      int redemptionbypointreceiptid = int.Parse(AddItemBut.CommandArgument);
                  int productid = int.Parse(ProductDDL.SelectedValue);
                  var product = ClientManager.getProduct(productid);
                  ClientManager.insertRedemptionByPointReceiptItem(
                  redemptionbypointreceiptid,
                       productid,
                       serialnoTB.Text.Trim(),
                       product.points,
                       product.model);

                  //reload item grid
                  var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
                  ReceiptItemRadGrid.DataSource = x;
                  ReceiptItemRadGrid.Rebind();

                  //reset fields for add
                  ProductDDL.SelectedIndex = 0;
                  serialnoTB.Text = "";

                  //update receipt
                  //get For each 


                  List<RedemptionByPointReceiptItem> list = (List<RedemptionByPointReceiptItem>)x;
                  int total = 0;
                  foreach (RedemptionByPointReceiptItem item in list)
                  {
                      total += item.productpoints;
                  }
                  totalpointsLit.Text = total.ToString();
                  ClientManager.updateRedemptionByPointReceiptPoint(redemptionbypointreceiptid, total);
      */
        }

        protected void DuplicateReceiptBut_Click(object sender, EventArgs e)
        {
            int redemptionbyproductreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                bool approveRedemptionByPointReceipt = ClientManager.duplicateRedemptionByProductReceipt(
                                  redemptionbyproductreceiptid);
                scope.Complete();
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;
                RedemptionDetailsEditPnl.Visible = false;
                RedemptionDetailsPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Duplicate status is set for Receipt ID(ByProduct):" + approveRedemptionByPointReceipt
                , this.GetType());
            }
        }
        protected void RejectReceiptBut_Click(object sender, EventArgs e)
        {
            int redemptionbyproductreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                bool approveRedemptionByPointReceipt = ClientManager.rejectRedemptionByProductReceipt(
                      redemptionbyproductreceiptid);
                scope.Complete();
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;
                RedemptionDetailsEditPnl.Visible = false;
                RedemptionDetailsPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Reject status is set for Receipt ID(ByProduct):" + approveRedemptionByPointReceipt
                , this.GetType());
            }
        }

        protected void UpdateReceiptBut_Click(object sender, EventArgs e)
        {
            Page.Validate("form");
            if (Page.IsValid)
            {

                int redemptionbyproductreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
                var db = new ApplicationServices.ApplicationServicesDB();
                using (var scope = db.GetTransaction())
                {
                    ClientManager.updateRedemptionByProductReceipt(
            redemptionbyproductreceiptid,
               int.Parse(StatusDDL.SelectedValue),
             InvoiceNoTB.Text.Trim(), int.Parse(ResellerDDL2.SelectedValue),
               PurchaseDateRadDatePicker.SelectedDate,
                int.Parse(PromotionDDL.SelectedValue), PromotionDDL.SelectedItem.Text);


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
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;
                RedemptionDetailsEditPnl.Visible = false;
                RedemptionDetailsPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Updated Receipt ID(ByProduct):" + redemptionbyproductreceiptid
, this.GetType());
            }
        }

        protected void InvoiceNoTBCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string invoiceno = args.Value.Trim();

            int receiptid = int.Parse(ReceiptidLit.Text);
            RedemptionData.ClientManager.DuplicateInvoiceByProduct duplicateInvoiceByProduct =
                ClientManager.findRedemptionRewardIdWithInvoiceNo(receiptid, invoiceno);

            if (duplicateInvoiceByProduct.redemptionrewardid != 0)
            {
                args.IsValid = false;
                InvoiceNoTBCV.ErrorMessage =
                    "Duplicate Invoice found for Redemption ID: "
                    + duplicateInvoiceByProduct.redemptionrewardid + " , Receipt ID: "
                    + duplicateInvoiceByProduct.redemptionbyproductreceiptid;

            }
            else
            {
                args.IsValid = true;
            }

        }

        protected void ProductDDL_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            //e.
            //e.Item.Text = "";
        }

        protected void ProductDDL2_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            //set the Text and Value property of every item
            //here you can set any other properties like Enabled, ToolTip, Visible, etc.
            //  e.Item.Text = ((DataRowView)e.Item.DataItem)["model"].ToString();
            //   e.Item.Value = ((DataRowView)e.Item.DataItem)["productid"].ToString();
            //  e.Item.Text = ((DataRowView)e.Item.DataItem)["model"].ToString();
            var s = (RedemptionData.ClientManager.ProductReward)e.Item.DataItem;
            e.Item.Text = s.productname + " : " + s.productmodel + " : " + s.productid
                + " | " + s.rewardname + " : " + s.rewardid;
            e.Item.Value = s.productid.ToString() + "|" + s.rewardid.ToString();

        }

        protected void ProductDDL2_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            ////get all customers whose name starts with e.Text
            //string sql = "SELECT * from Customers WHERE ContactName LIKE '" + e.Text + "%'";

            //SessionDataSource1.SelectCommand = sql;
            //RadComboBox1.DataBind();
        }
        protected void ProductDDL2_DataBound(object sender, EventArgs e)
        {
            ////set the initial footer label
            //((Literal)RadComboBox1.Footer.FindControl("RadComboItemsCount")).Text = Convert.ToString(RadComboBox1.Items.Count);
        }
    }
}