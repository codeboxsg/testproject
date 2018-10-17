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
    public partial class Receipt : System.Web.UI.Page
    {
        //bool firstItemLoaded = true;
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

                // firstItemLoaded = false;
            }

            PurchaseDateRadDatePicker.MaxDate = DateTime.Today.Date.AddDays(1).AddMilliseconds(-1);
        }
        protected void ReceiptRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
            ReceiptRadGrid.DataSource = x;
        }

        protected void loadRedemptionByPointReceipt(int redemptionbypointreceiptid)
        {
            var redemptionByProductReceipt = ClientManager.getRedemptionByPointReceipt(redemptionbypointreceiptid);
            ReceiptIdLit.Text = redemptionbypointreceiptid.ToString();
            var client = ClientManager.getClient(redemptionByProductReceipt.clientid);
            ClientNameLbl.Text = client.name;
            MembershipUser member = Membership.GetUser(redemptionByProductReceipt.UserId);
            UseridLit.Text = member.UserName;
            // int resellerIndex= ResellerDDL2.FindItemIndexByValue(redemptionbypointreceipt.resellerid.ToString());
            ResellerDDL2.SelectedValue = redemptionByProductReceipt.resellerid.ToString();
            InvoiceNoTB.Text = redemptionByProductReceipt.invoiceno;//todo
            PurchaseDateRadDatePicker.SelectedDate = redemptionByProductReceipt.purchasedate;//todo
            totalpointsLit.Text = redemptionByProductReceipt.totalpoints.ToString();//todo


            ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + redemptionByProductReceipt.receiptpath;

            bool canEdit;
            if ((redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.PROCESSED) ||
                (redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.DUPLICATE) ||
                (redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.REJECTED) ||
                (redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.VOID))
            {
                canEdit = false;


                //UpdateReceiptBut.Visible = false;
                //AddItemBut.Visible = false;
            }
            else
            {
                canEdit = true;
                //UpdateReceiptBut.Visible = true;
                //AddItemBut.Visible = true;
            }
            if ((redemptionByProductReceipt.status == (int)RedemptionByPointReceiptState.PROCESSED))
            {

                if (Roles.IsUserInRole("Admin"))
                {
                    VoidBut.Visible = true;
                }
                else
                {
                    VoidBut.Visible = false;
                }

            }
            else
            {
                VoidBut.Visible = false;
            }

            InvoiceNoTB.Enabled = canEdit;
            CustomPointsTB.Enabled = canEdit;
            ResellerDDL2.Enabled = canEdit;
            PurchaseDateRadDatePicker.Enabled = canEdit;
            UpdateReceiptBut.Enabled = canEdit;
            RedemptionDetailsEditPnl.Visible = canEdit;
            serialnoTB.Text = "";
            DuplicateBut.Enabled = canEdit;
            RejectBut.Enabled = canEdit;

            var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
            ReceiptItemRadGrid.DataSource = x;
            ReceiptItemRadGrid.Rebind();

            //load productddl
            var y = ClientManager.getAllProductsByClientId(redemptionByProductReceipt.clientid);

            ProductDDL.DataTextField = "model";
            ProductDDL.DataValueField = "productid";
            ProductDDL.DataSource = y;

            ProductDDL.DataBind();
            ProductDDL.Items.Insert(0, new RadComboBoxItem("-select-", string.Empty));

            AddItemBut.CommandArgument = redemptionbypointreceiptid.ToString();
            UpdateReceiptBut.CommandArgument = redemptionbypointreceiptid.ToString();


        }
        protected void ReceiptRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "Process")
            {
                int redemptionbypointreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptid");
                loadRedemptionByPointReceipt(redemptionbypointreceiptid);
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
            if (e.CommandName == "SendApprovalEmail")
            {
                int redemptionbypointreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptid");
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");

                MembershipUser membershipUser = Membership.GetUser(UserId);
                var redemptionbypointreceipt = ClientManager.getRedemptionByPointReceipt(redemptionbypointreceiptid);
                var client = ClientManager.getClient(redemptionbypointreceipt.clientid);

                //http://rewardshub.dev1.codebox1.com/mc/mc/logo.gif <-- wrong
                //http://rewardshub.dev1.codebox1.com/mc/img/logo.gif
                string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                Hashtable values = new Hashtable();
                values.Add("[/logo/]", emailpath);
                values.Add("[/SiteRootUrl/]", Config.MainSiteRootUrl + client.siterelativepath);
                var redemptionMember = ClientManager.getRedemptionMember(UserId);
                bool canSendEmail = EmailManager.SendClaimPointApprovalMail(
                                          membershipUser.Email,
                                          redemptionMember.firstname,
                                          values, client.clientid, this.Response);

                EmailSendLit.Text = "Claim Points email is sent for Receipt ID:" + redemptionbypointreceiptid;

                Logger.LogInfo(Membership.GetUser().UserName + "- Claim Points email is sent for Receipt ID(ClaimPoints):" + redemptionbypointreceiptid
                   , this.GetType());
            }
        }
        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
        }

        protected void ReceiptRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {

                    int redemptionbypointreceiptid = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionbypointreceiptid"];
                    int status = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    string receiptpath = (string)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["receiptpath"];
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    LinkButton SendApprovalEmailBut = e.Item.FindControl("SendApprovalEmailBut") as LinkButton;
                    LinkButton ProcessBut = e.Item.FindControl("ProcessBut") as LinkButton;
                    Literal redemptionbypointreceiptidLit = e.Item.FindControl("redemptionbypointreceiptidLit") as Literal;
                    redemptionbypointreceiptidLit.Text = redemptionbypointreceiptid.ToString();

                    switch (status)
                    {
                        case (int)RedemptionByPointReceiptState.PENDING_PROCESS:
                            dataBoundItem["status"].Text = (int)RedemptionByPointReceiptState.PENDING_PROCESS + "-" + RedemptionByPointReceiptState.PENDING_PROCESS.ToString();
                            SendApprovalEmailBut.Visible = false;
                            ProcessBut.Text = "Manage";
                            dataBoundItem["purchasedate"].Text = "";

                            break;
                        case (int)RedemptionByPointReceiptState.PROCESSED:
                            dataBoundItem["status"].Text = (int)RedemptionByPointReceiptState.PROCESSED + "-" + RedemptionByPointReceiptState.PROCESSED.ToString();
                            SendApprovalEmailBut.Visible = true;
                            ProcessBut.Text = "View";

                            break;
                        case (int)RedemptionByPointReceiptState.DUPLICATE:
                            dataBoundItem["status"].Text = (int)RedemptionByPointReceiptState.DUPLICATE + "-" + RedemptionByPointReceiptState.DUPLICATE.ToString();
                            SendApprovalEmailBut.Visible = false;
                            ProcessBut.Text = "View";
                            dataBoundItem["purchasedate"].Text = "";
                            break;
                        case (int)RedemptionByPointReceiptState.REJECTED:
                            dataBoundItem["status"].Text = (int)RedemptionByPointReceiptState.REJECTED + "-" + RedemptionByPointReceiptState.REJECTED.ToString();
                            SendApprovalEmailBut.Visible = false;
                            ProcessBut.Text = "View";
                            dataBoundItem["purchasedate"].Text = "";
                            break;
                        case (int)RedemptionByPointReceiptState.VOID:
                            dataBoundItem["status"].Text = (int)RedemptionByPointReceiptState.VOID + "-" + RedemptionByPointReceiptState.VOID.ToString();
                            SendApprovalEmailBut.Visible = false;
                            ProcessBut.Text = "View";
                            dataBoundItem["purchasedate"].Text = "";
                            break;
                    }
                    HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;

                    //    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;
                    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + receiptpath;

                    ////load first item
                    //if (!firstItemLoaded)
                    //{
                    //    firstItemLoaded = true;
                    //    //int redemptionbypointreceiptid = (int)(ReceiptItemRadGrid.Items[0]).GetDataKeyValue("redemptionbypointreceiptid");
                    //    loadRedemptionByPointReceipt(redemptionbypointreceiptid);
                    //}
                }
            }
            catch (Exception exc)
            {
                string errorMessage = "Exception occurred while binding the data item in the page. Details are: " + exc.ToString();
                Trace.Warn(this.ToString(), errorMessage, exc);
            }
        }

        protected void ReceiptItemRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(0);
            //ReceiptItemRadGrid.DataSource = x;
            int redemptionbypointreceiptid = int.Parse(ReceiptIdLit.Text);
            var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
            ReceiptItemRadGrid.DataSource = x;
            // ReceiptItemRadGrid.Rebind();
        }
        protected void ReceiptItemRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "delete2")
            {
                int redemptionbypointreceiptItemid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptitemid");
                int redemptionbypointreceiptid = (int)((GridDataItem)e.Item).GetDataKeyValue("redemptionbypointreceiptid");

                ClientManager.deleteRedemptionByPointReceiptItem(redemptionbypointreceiptItemid);
                var x = ClientManager.getAllRedemptionByPointReceiptReceiptId(redemptionbypointreceiptid);
                ReceiptItemRadGrid.DataSource = x;
                ReceiptItemRadGrid.Rebind();

                List<RedemptionByPointReceiptItem> list = (List<RedemptionByPointReceiptItem>)x;
                int total = 0;
                foreach (RedemptionByPointReceiptItem item in list)
                {
                    total += item.productpoints;
                }
                totalpointsLit.Text = total.ToString();
                ClientManager.updateRedemptionByPointReceiptPoint(redemptionbypointreceiptid, total);


            }
        }
        protected void ReceiptItemRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {

                    int redemptionbypointreceiptid = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionbypointreceiptid"];
                    LinkButton DeleteBut = e.Item.FindControl("DeleteBut") as LinkButton;
                    DeleteBut.Visible = RedemptionDetailsEditPnl.Visible;

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
            Page.Validate("addproduct");
            if (Page.IsValid)
            {
                int redemptionbypointreceiptid = int.Parse(AddItemBut.CommandArgument);
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
            }
        }

        protected void ProductDDL_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {

        }
        protected void DuplicateReceiptBut_Click(object sender, EventArgs e)
        {
            int redemptionbypointreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                bool approveRedemptionByPointReceipt = ClientManager.duplicateRedemptionByPointReceipt(
                                  redemptionbypointreceiptid);
                scope.Complete();
                var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
                ReceiptRadGrid.DataSource = x;
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Duplicate status is set for Receipt ID(ClaimPoints):" + redemptionbypointreceiptid
             , this.GetType());
            }
        }
        protected void RejectReceiptBut_Click(object sender, EventArgs e)
        {
            int redemptionbypointreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                bool approveRedemptionByPointReceipt = ClientManager.rejectRedemptionByPointReceipt(
                      redemptionbypointreceiptid);
                scope.Complete();
                var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
                ReceiptRadGrid.DataSource = x;
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Reject status is set for Receipt ID(ClaimPoints):" + redemptionbypointreceiptid
          , this.GetType());
            }
        }
        protected void VoidReceiptBut_Click(object sender, EventArgs e)
        {

            //only admin can void
            //when void add transaction by minusing points back to user account
            //if status is processed. 
            //else
            //just change status to void. 
            int redemptionbypointreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
            var db = new ApplicationServices.ApplicationServicesDB();
            using (var scope = db.GetTransaction())
            {
                bool approveRedemptionByPointReceipt = ClientManager.voidRedemptionByPointReceipt(
                       redemptionbypointreceiptid,
                       int.Parse(ResellerDDL2.SelectedValue),
                       InvoiceNoTB.Text.Trim(),
                       (DateTime)PurchaseDateRadDatePicker.SelectedDate);
                RedemptionByPointReceipt redemptionByPointReceipt = ClientManager.getRedemptionByPointReceipt(redemptionbypointreceiptid);
                RedemptionMemberClient redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                    redemptionByPointReceipt.UserId,
                    redemptionByPointReceipt.clientid);
                int newPointBalance = redemptionMemberClient.pointbalance - redemptionByPointReceipt.totalpoints;
                string notes = "Receipt ID:" + redemptionByPointReceipt.redemptionbypointreceiptid +
                " | Points:" + -redemptionByPointReceipt.totalpoints;

                int insertRedemptionByPointTransaction = ClientManager.insertRedemptionByPointTransaction(
                   redemptionByPointReceipt.UserId,
                   redemptionByPointReceipt.clientid,
                   (int)RedemptionByPointTransactionType.VOID,
                   -redemptionByPointReceipt.totalpoints,
                   newPointBalance,
                   notes);
                bool updateRedemptionMemberClientBalance = ClientManager.updateRedemptionMemberClientBalance(
                     redemptionByPointReceipt.UserId,
                    redemptionByPointReceipt.clientid,
                    newPointBalance);

                if ((insertRedemptionByPointTransaction != -1) &&
                  updateRedemptionMemberClientBalance)
                {
                    scope.Complete();
                }
                var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
                ReceiptRadGrid.DataSource = x;
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Void status is set for Receipt ID(ClaimPoints):" + redemptionbypointreceiptid
                    + " points are removed from member"
      , this.GetType());
            }

        }
        protected void UpdateReceiptBut_Click(object sender, EventArgs e)
        {
            Page.Validate("form");
            if (Page.IsValid)
            {
                int redemptionbypointreceiptid = int.Parse(UpdateReceiptBut.CommandArgument);
                var db = new ApplicationServices.ApplicationServicesDB();
                using (var scope = db.GetTransaction())
                {
                    bool approveRedemptionByPointReceipt = ClientManager.approveRedemptionByPointReceipt(
                         redemptionbypointreceiptid,
                         int.Parse(ResellerDDL2.SelectedValue),
                         InvoiceNoTB.Text.Trim(),
                         (DateTime)PurchaseDateRadDatePicker.SelectedDate);
                    //textbox is filled so take balance from custom points tb
                    if (CustomPointsTB.Text.Trim().Count() > 0)
                    {
                        ClientManager.updateRedemptionByPointReceiptPoint(
                             redemptionbypointreceiptid,
                             int.Parse(CustomPointsTB.Text));
                    }

                    RedemptionByPointReceipt redemptionByPointReceipt = ClientManager.getRedemptionByPointReceipt(redemptionbypointreceiptid);
                    RedemptionMemberClient redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                        redemptionByPointReceipt.UserId,
                        redemptionByPointReceipt.clientid);


                    int newPointBalance = redemptionMemberClient.pointbalance + redemptionByPointReceipt.totalpoints;
                    //RedemptionByPointTransaction
                    string notes = "Receipt ID:" + redemptionByPointReceipt.redemptionbypointreceiptid +
                        " | Points:" + redemptionByPointReceipt.totalpoints;
                    int insertRedemptionByPointTransaction = ClientManager.insertRedemptionByPointTransaction(
                         redemptionByPointReceipt.UserId,
                         redemptionByPointReceipt.clientid,
                         (int)RedemptionByPointTransactionType.DEBIT,
                         redemptionByPointReceipt.totalpoints,
                         newPointBalance,
                         notes);
                    bool updateRedemptionMemberClientBalance = ClientManager.updateRedemptionMemberClientBalance(
                         redemptionByPointReceipt.UserId,
                        redemptionByPointReceipt.clientid,
                        newPointBalance);

                    /*
                    MembershipUser membershipUser = Membership.GetUser(redemptionByPointReceipt.UserId);
                    Hashtable values = new Hashtable();
                    values.Add("[/logo/]", Config.EmailLogoUrl);
                    var redemptionMember = ClientManager.getRedemptionMember(redemptionByPointReceipt.UserId);
                    bool canSendEmail = EmailManager.SendClaimPointApprovalMail(
                                              membershipUser.Email,
                                              redemptionMember.firstname,
                                              values);
                    */
                    if (approveRedemptionByPointReceipt &&
                        (insertRedemptionByPointTransaction != -1) &&
                        updateRedemptionMemberClientBalance)
                    { scope.Complete(); }

                }

                //reload radgrid
                var x = ClientManager.getAllRedemptionByPointReceiptPendingProcess();
                ReceiptRadGrid.DataSource = x;
                ReceiptRadGrid.Rebind();
                ClientDetailPnl.Visible = false;

                Logger.LogInfo(Membership.GetUser().UserName + "- Processed status is set and points assigned for Receipt ID(ClaimPoints):" + redemptionbypointreceiptid
                , this.GetType());
            }

        }

        protected void InvoiceNoTBCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string invoiceno = args.Value.Trim();

            int receiptid = int.Parse(ReceiptIdLit.Text);
            RedemptionData.ClientManager.DuplicateInvoiceByPoint duplicateInvoiceByPoint =
                ClientManager.findDuplicateInvoiceIdWithInvoiceNo(receiptid, invoiceno);

            if (duplicateInvoiceByPoint.redemptionbypointreceiptid != 0)
            {
                args.IsValid = false;
                InvoiceNoTBCV.ErrorMessage =
                    "Duplicate Invoice found for Receipt ID: "
                    + duplicateInvoiceByPoint.redemptionbypointreceiptid;

            }
            else
            {
                args.IsValid = true;
            }

        }

        //protected void PointsOptionRBL_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (PointsOptionRBL.SelectedIndex == 0)
        //    {
        //        PointsPnl.Visible = false;
        //        ProductPnl.Visible = true;
        //    }
        //    else
        //    {
        //        PointsPnl.Visible = true;
        //        ProductPnl.Visible = false;
        //    }
        //}


    }
}