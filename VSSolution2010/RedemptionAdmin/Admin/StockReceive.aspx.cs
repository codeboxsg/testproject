using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using System.Web.Security;

namespace RedemptionAdmin.Admin
{
    public partial class StockReceive : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["rewardid"] != null)
                {
                    int rewardid = int.Parse(Request.QueryString["rewardid"]);
                    var reward = ClientManager.getReward(rewardid);
                    RewardLit.Text = reward.name;

                    var client = ClientManager.getClient(reward.clientid);
                    ClientBut.Text = "Client (" + client.name + ")";
                    RewardBut.Text = "Reward (" + reward.name + ")";

                }
                loadCompanyDDL();
            }
        }

        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["rewardid"] != null)
            {
                int rewardid = int.Parse(Request.QueryString["rewardid"]);
                var x = ClientManager.getAllStockReceiveByRewardId(rewardid);
                RadGrid1.DataSource = x;
            }
        }

        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreateStockReceiveBut.Visible = true;
            // CreateProductBut.Visible = true;
            ShowCreateStockReceiveBut.Visible = true;
        }

        protected void CreateStockReceiveBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["rewardid"] != null)
            {
                int inQty = -1;
                bool success = false;
                var db = new ApplicationServices.ApplicationServicesDB();
                using (var scope = db.GetTransaction())
                {

                    var reward = ClientManager.getReward(int.Parse(Request.QueryString["rewardid"]));

                    inQty = int.Parse(QtyTB.Text.Trim());
                    // int newBalance = reward.qty + inQty;

                    success = ClientManager.insertStockReceive(
                         int.Parse(Request.QueryString["rewardid"]), reward.name,
                    -1, CompanyTB.Text.Trim(),
                    int.Parse(QtyTB.Text.Trim()), inQty,
                     InvoiveTB.Text.Trim(), RemarksTB.Text.Trim());

                    ClientManager.updateRewardQtyBy(
                        reward.rewardid, inQty);
                    scope.Complete();
                }
                if (success)
                {
                    ProductDetailErrorLit.Text = "";

                    int rewardid = int.Parse(Request.QueryString["rewardid"]);
                    var x = ClientManager.getAllStockReceiveByRewardId(rewardid);
                    RadGrid1.DataSource = x;

                    RadGrid1.Rebind();

                    ClientDetailPnl.Visible = false;

                    ShowCreateStockReceiveBut.Visible = true;

                    Logger.LogInfo(Membership.GetUser().UserName + "- stock receive reward ID:" + rewardid
                    + " in Qty:" + inQty
                    , this.GetType());

                }
                else
                {
                    ProductDetailErrorLit.Text = "Error Occurred updating reward qty.";
                }
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //try
            //{
            //    if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
            //        e.Item != null && e.Item.DataItem != null)
            //    {
            //        string rewardid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardid"].ToString();
            //        Literal RewardidLit = e.Item.FindControl("RewardidLit") as Literal;
            //        RewardidLit.Text = rewardid;
            //    }
            //}
            //catch (Exception eee)
            //{ }
        }



        protected void loadCompanyDDL()
        {
            var x = ClientManager.getAllResellers();
            CompanyDDL.DataSource = x;
            CompanyDDL.DataTextField = "name";
            CompanyDDL.DataValueField = "resellerid";
            CompanyDDL.DataBind();
        }

        protected void ShowCreateStockReceiveBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = true;
            QtyTB.Text = "";
            InvoiveTB.Text = "";
            RemarksTB.Text = "";
            CompanyDDL.ClearSelection();
            //  ShowCreateStockReceiveBut.Visible = false;
        }

        protected void ClientBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["rewardid"] != null)
            {
                int rewardid = int.Parse(Request.QueryString["rewardid"]);
                var reward = ClientManager.getReward(rewardid);

                //  int clientid = int.Parse(Request.QueryString["clientid"]);
                Session.Add("clientid", reward.clientid);
                Response.Redirect("client.aspx");
            }
        }
        protected void RewardBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["rewardid"] != null)
            {
                int rewardid = int.Parse(Request.QueryString["rewardid"]);
                // int clientid = int.Parse(Request.QueryString["clientid"]);
                var reward = ClientManager.getReward(rewardid);


                var client = ClientManager.getClient(reward.clientid);
                Session.Add("rewardid", rewardid);
                Response.Redirect("reward.aspx?clientid=" + reward.clientid);
            }
        }
    }
}