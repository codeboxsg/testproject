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

namespace Redemption
{
    public partial class Status : System.Web.UI.Page
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
               RedemptionMemberClient redemptionMemberClient = ClientManager.getRedemptionMemberClient(
                   (Guid)Membership.GetUser().ProviderUserKey,
                   Config.ClientId);
               CurrentPointsLit.Text = redemptionMemberClient.pointbalance.ToString();
            }
        }
        #region RewardRadGrid
        protected void RewardRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionRewardByUserIdClientId(
                (Guid)Membership.GetUser().ProviderUserKey,
                Config.ClientId);
            RewardRadGrid.DataSource = x;
        }
        protected void RewardRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {


        }
        protected void RewardRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    string redemptionrewardid = (string)RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionrewardid"].ToString();
                    int status = (int)RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    int modeofcollection = (int)RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["modeofcollection"];
                    int rewardpoints = (int)RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardpoints"];
                    int type = (int)RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["type"];
                    string productname = RewardRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productname"].ToString(); 
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                 //   HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;
                    Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                //    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;

                    switch (status)
                    {
                        //case (int)RedemptionRewardState.PENDING_PROCESS:
                      
                        //    //dataBoundItem["status"].Text = RedemptionRewardState.PENDING_PROCESS.ToString();//"Processing";
                        //    dataBoundItem["status"].Text = "Processing";
                        //    break;
                        case (int)RedemptionRewardState.PENDING_DELIVERY:
                        
                            //dataBoundItem["status"].Text = RedemptionRewardState.PROCESSED.ToString();//"Approved";
                            dataBoundItem["status"].Text = "Pending Delivery";
                            break;
                        case (int)RedemptionRewardState.ARRANGING_DELIVERY:

                            //dataBoundItem["status"].Text = RedemptionRewardState.PROCESSED.ToString();//"Approved";
                            dataBoundItem["status"].Text = "Arranging Delivery";
                            break;
                        case (int)RedemptionRewardState.PENDING_COLLECTION:
                           
                            //dataBoundItem["status"].Text = RedemptionRewardState.PENDING_COLLECTION.ToString();//"Redeemed";
                            dataBoundItem["status"].Text = "Pending Collection";
                            break;
                        case (int)RedemptionRewardState.DELIVERED:
                        
                            //dataBoundItem["status"].Text = RedemptionRewardState.DELIVERED.ToString();//"Processing";
                            dataBoundItem["status"].Text = "Delivered";
                            break;
                        case (int)RedemptionRewardState.COLLECTED:
           
                           // dataBoundItem["status"].Text = RedemptionRewardState.COLLECTED.ToString();//"Processing";
                            dataBoundItem["status"].Text = "Collected";
                                                       break;
                        case (int)RedemptionRewardState.VOID:

                                                       // dataBoundItem["status"].Text = RedemptionRewardState.COLLECTED.ToString();//"Processing";
                                                       dataBoundItem["status"].Text = "Void";
                                                       break;
                    }
                   

                    switch (modeofcollection)
                    {
                        case (int)CollectionMode.PICK_UP:
                           //CollectionMode.PICK_UP
                            dataBoundItem["modeofcollection"].Text = "Self Collect";

                            break;
                        case (int)CollectionMode.DELIVERY:
                            //CollectionMode.DELIVERY
                            dataBoundItem["modeofcollection"].Text = "Delivery";
                       
                            break;                  
                    }

                    switch (type)
                    {
                        case 0:
                            //by points
                            NoteLbl.Text = "- " + rewardpoints + " points";
                            break;
                        case 1:
                            //by product
                            NoteLbl.Text = productname;
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

        #endregion

        #region PointRadGrid
        protected void PointRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionByPointTransactionByUserId(
                (Guid)Membership.GetUser().ProviderUserKey,
                Config.ClientId);
            PointRadGrid.DataSource = x;
        }

        protected void PointRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {}

        protected void PointRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    string redemptionbypointtransactionid = (string)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionbypointtransactionid"].ToString();
                   // int status = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    //GridDataItem dataBoundItem = e.Item as GridDataItem;
                    //HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;
                    //Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                    //ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;

                    //switch (status)
                    //{
                    //    case 0:
                    //        //RedemptionByPointReceiptState.PENDING_PROCESS.ToString()
                    //        dataBoundItem["status"].Text = "Processing";

                    //        break;
                    //    case 1:
                    //        //RedemptionByPointReceiptState.PROCESSED.ToString()
                    //        dataBoundItem["status"].Text = "Approved";
                    //        NoteLbl.Text = "Claimed " + " points";
                    //        break;
                    //}
                }
            }
            catch (Exception exc)
            {
                string errorMessage = "Exception occurred while binding the data item in the page. Details are: " + exc.ToString();
                Trace.Warn(this.ToString(), errorMessage, exc);
            }
        }

        #endregion

        #region ReceiptRadGrid
      
        protected void ReceiptRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionByPointReceiptByUserIdClientId(
                (Guid)Membership.GetUser().ProviderUserKey,
                Config.ClientId);
            ReceiptRadGrid.DataSource = x;
        }

        protected void ReceiptRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        { }

        protected void ReceiptRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    string redemptionbypointreceiptid = (string)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionbypointreceiptid"].ToString();
                    int status = (int)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    string totalpoints = (string)ReceiptRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["totalpoints"].ToString();
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                    HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;
                    Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;

                    switch (status)
                    {
                        case 0:
                            //RedemptionByPointReceiptState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = "Processing";

                            break;
                        case 1:
                            //RedemptionByPointReceiptState.PROCESSED.ToString()
                            dataBoundItem["status"].Text = "Approved";
                            NoteLbl.Text = "Claimed " + totalpoints + " points";
                            break;
                        case 2:
                            //RedemptionByPointReceiptState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = "Duplicate";

                            break;
                        case 3:
                            //RedemptionByPointReceiptState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = "Rejected";

                            break;
                        case 4:
                            //RedemptionByPointReceiptState.PENDING_PROCESS.ToString()
                            dataBoundItem["status"].Text = "Void";

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
       #endregion


    }
}