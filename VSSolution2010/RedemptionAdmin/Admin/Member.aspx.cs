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
    public partial class Member : System.Web.UI.Page
    {
        bool firstItemLoaded = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                firstItemLoaded = false;
            }
        }




        protected void CancelBut_Click(object sender, EventArgs e)
        {
            //ClientDetailPnl.Visible = false;
        }

        protected void RedemptionMemberRadGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllRedemptionMembers();
            RedemptionMemberRadGrid.DataSource = x;

        }

        protected void RedemptionMemberRadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "manage")
            {
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");

                Response.Redirect("MemberUpdate.aspx?userid=" + UserId.ToString());
            }

            //Reset password to be in link client page
            //if (e.CommandName == "resetpassword")
            //{
            //    Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");

            //    Response.Redirect("MemberResetPassword.aspx?userid=" + UserId.ToString());
            //}
            if (e.CommandName == "enable")
            {
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
                MembershipUser aMembershipUser = Membership.GetUser(UserId);
                LinkButton enableLB = e.Item.FindControl("enableLB") as LinkButton;
                aMembershipUser.IsApproved = !aMembershipUser.IsApproved;
                Membership.UpdateUser(aMembershipUser);
                RedemptionMemberRadGrid.Rebind();
                //if (aMembershipUser.IsApproved)
                //{ enableLB.Text = "Disable"; }
                //else { enableLB.Text = "Enable"; }
                //TBA
                if (aMembershipUser.IsApproved)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- disabled member username:" + aMembershipUser.UserName
                    , this.GetType());
                }
                else
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- enabled member username:" + aMembershipUser.UserName
                    , this.GetType());
                }
            }

            if (e.CommandName == "unlock")
            {
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
                MembershipUser aMembershipUser = Membership.GetUser(UserId);
                aMembershipUser.UnlockUser();
                Membership.UpdateUser(aMembershipUser);
                RedemptionMemberRadGrid.Rebind();
                //if (aMembershipUser.IsApproved)
                //{ enableLB.Text = "Disable"; }
                //else { enableLB.Text = "Enable"; }
                //TBA
                Logger.LogInfo(Membership.GetUser().UserName + "- unlock member username:" + aMembershipUser.UserName
                   , this.GetType());
            }

            if (e.CommandName == "linkclient")
            {
                Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");

                Response.Redirect("MemberClient.aspx?userid=" + UserId.ToString());
            }



        }

        protected void RedemptionMemberRadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    //string redemptionrewardid = (string)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionrewardid"].ToString();
                    //int status = (int)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["status"];
                    //int modeofcollection = (int)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["modeofcollection"];
                    //int rewardpoints = (int)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardpoints"];
                    //int type = (int)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["type"];
                    //string productname = RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productname"].ToString();
                    //GridDataItem dataBoundItem = e.Item as GridDataItem;
                    //   HyperLink ReceiptHL = e.Item.FindControl("ReceiptHL") as HyperLink;
                    Label NoteLbl = e.Item.FindControl("NoteLbl") as Label;
                    //    ReceiptHL.NavigateUrl = Config.UploadInvoiceRelativePath + dataBoundItem["receiptpath"].Text;
                    LinkButton enableLB = e.Item.FindControl("enableLB") as LinkButton;
                    Guid UserId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
                    MembershipUser aMembershipUser = Membership.GetUser(UserId);
                    if (aMembershipUser.IsApproved)
                    { enableLB.Text = "Disable"; }
                    else { enableLB.Text = "Enable"; }
                    LinkButton unlockLB = e.Item.FindControl("unlockLB") as LinkButton;
                    if (aMembershipUser.IsLockedOut)
                    { unlockLB.Visible = true; }
                    else { unlockLB.Visible = false; }
                    GridDataItem dataBoundItem = e.Item as GridDataItem;

                    bool gender = (bool)RedemptionMemberRadGrid.MasterTableView.DataKeyValues[e.Item.ItemIndex]["gender"];


                    if (gender)
                    {
                        dataBoundItem["gender"].Text = "M";
                    }
                    else
                    {
                        dataBoundItem["gender"].Text = "F";
                    }

                    //switch (status)
                    //{
                    //    //case (int)RedemptionRewardState.PENDING_PROCESS:
                    //    //    //RedemptionRewardState.PENDING_PROCESS.ToString()
                    //    //    dataBoundItem["status"].Text = RedemptionRewardState.PENDING_PROCESS.ToString();//"Processing";

                    //    //    break;
                    //    case (int)RedemptionRewardState.PENDING_DELIVERY:
                    //        //RedemptionRewardState.PROCESSED.ToString()
                    //        dataBoundItem["status"].Text = RedemptionRewardState.PENDING_DELIVERY.ToString();//"Approved";

                    //        break;
                    //    case (int)RedemptionRewardState.PENDING_COLLECTION:
                    //        //RedemptionRewardState.REDEEMED.ToString()
                    //        dataBoundItem["status"].Text = RedemptionRewardState.PENDING_COLLECTION.ToString();//"Redeemed";

                    //        break;
                    //    case (int)RedemptionRewardState.DELIVERED:
                    //        //RedemptionRewardState.PENDING_PROCESS.ToString()
                    //        dataBoundItem["status"].Text = RedemptionRewardState.DELIVERED.ToString();//"Processing";

                    //        break;
                    //    case (int)RedemptionRewardState.COLLECTED:
                    //        //RedemptionRewardState.PENDING_PROCESS.ToString()
                    //        dataBoundItem["status"].Text = RedemptionRewardState.COLLECTED.ToString();//"Processing";

                    //        break;
                    //    case (int)RedemptionRewardState.ARRANGING_DELIVERY:
                    //        //RedemptionRewardState.PENDING_PROCESS.ToString()
                    //        dataBoundItem["status"].Text = RedemptionRewardState.ARRANGING_DELIVERY.ToString();//"Processing";

                    //        break;
                    //}

                    //switch (modeofcollection)
                    //{
                    //    case 0:
                    //        //CollectionMode.PICK_UP
                    //        dataBoundItem["modeofcollection"].Text = "Self Collect";

                    //        break;
                    //    case 1:
                    //        //CollectionMode.DELIVERY
                    //        dataBoundItem["modeofcollection"].Text = "Delivery";

                    //        break;
                    //}

                    //switch (type)
                    //{
                    //    case 0:
                    //        //by points
                    //        NoteLbl.Text = "- " + rewardpoints + " points";
                    //        dataBoundItem["type"].Text = PromotionType.BY_POINT.ToString();
                    //        break;
                    //    case 1:
                    //        //by product
                    //        NoteLbl.Text = productname;
                    //        dataBoundItem["type"].Text = PromotionType.BY_PRODUCT.ToString();
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

        protected void ResellerDDL2_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
        }

        protected void NewMemberBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberAdd.aspx");
        }


    }
}