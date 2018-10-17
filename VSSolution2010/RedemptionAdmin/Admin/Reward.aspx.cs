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
    public partial class Reward : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["clientid"] != null)
                {
                    var client = ClientManager.getClient(int.Parse(Request.QueryString["clientid"]));
                    ClientBut.Text = "Client (" + client.name + ")";

                }

                if (Session["rewardid"] != null)
                {
                    int rewardid = int.Parse(Session["rewardid"].ToString());
                    LoadRewardDetail(rewardid);

                }
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["clientid"] != null)
            {
                var x = ClientManager.getAllRewardsByClientid(int.Parse(Request.QueryString["clientid"]));
                RadGrid1.DataSource = x;
            }
            else
            {
                var x = ClientManager.getAllRewards();
                RadGrid1.DataSource = x;
            }

        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                Session.Remove("Rewardfilename");
                

                int rewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("rewardid");
                Session.Add("rewardid", rewardid);
                LoadRewardDetail(rewardid);
                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
            if (e.CommandName == "Delete2")
            {
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("productid");
                bool success = ClientManager.deleteClient(clientid);
                if (success)
                {
                    RadGrid1.Rebind();
                }
                else
                {
                    ProductDetailErrorLit.Text = "Error occurred deleting product.";
                }


                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
            //if (e.CommandName == "Block")
            //{
            //    Guid userId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
            //    setStatusForUser(userId, true);
            //    RadGrid1.Rebind();
            //}
            //else if (e.CommandName == "UnBlock")
            //{
            //    Guid userId = (Guid)((GridDataItem)e.Item).GetDataKeyValue("UserId");
            //    setStatusForUser(userId, false);
            //    RadGrid1.Rebind();
            //}
        }

        private void LoadRewardDetail(int rewardid)
        {

            loadClientDDL();
            var reward = ClientManager.getReward(rewardid);

            clientDDL.SelectedValue = reward.clientid.ToString();
            NameTB.Text = reward.name;
            BriefTB.Text = reward.brief;
            DescriptionTB.Text = reward.description;
            QtyLit.Text = reward.qty.ToString();
            PointsTB.Text = reward.points.ToString();
            RewardImage.Visible = true;
            RewardImage.ImageUrl = Config.UploadRewardVirtualPath + reward.imagepath;
            RewardImageCV.EnableClientScript = false;


            ClientDetailPnl.Visible = true;
           // ShowCreateRewardBut.Visible = false;
            CreateRewardBut.Visible = false;
            UpdateRewardBut.Visible = true;
            StockDiv.Visible = true;
        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreateRewardBut.Visible = true;
            CreateRewardBut.Visible = true;
        }

        protected void ShowCreateRewardBut_Click(object sender, EventArgs e)
        {
            loadClientDDL();
            CreateRewardBut.Visible = true;
            ClientDetailPnl.Visible = true;
            //ShowCreateRewardBut.Visible = false;
            RewardImage.Visible = false;
            RewardImageCV.EnableClientScript = true;
            UpdateRewardBut.Visible = false;
            if (Request.QueryString["clientid"] != null)
            {
                int clientid = int.Parse(Request.QueryString["clientid"]);

                clientDDL.SelectedValue = clientid.ToString();
            }
            //clear fields
            NameTB.Text = "";
            DescriptionTB.Text = "";

            PointsTB.Text = "";
            BriefTB.Text = "";
            QtyLit.Text = "";
            StockDiv.Visible = false;

        }
        protected void StockBut_Click(object sender, EventArgs e)
        {
            if (Session["rewardid"] != null)
            {
                int rewardid = (int)Session["rewardid"];
                Response.Redirect("stockreceive.aspx?rewardid=" + rewardid);
            }
        }
        protected void OutStockBut_Click(object sender, EventArgs e)
        {
            if (Session["rewardid"] != null)
            {
                int rewardid = (int)Session["rewardid"];
                Response.Redirect("StockOut.aspx?rewardid=" + rewardid);
            }
        }
        protected void ReturnStockBut_Click(object sender, EventArgs e)
        {
            if (Session["rewardid"] != null)
            {
                int rewardid = (int)Session["rewardid"];
                Response.Redirect("Stockreturn.aspx?rewardid=" + rewardid);
            }
        }
        protected void CreateRewardBut_Click(object sender, EventArgs e)
        {
            bool success = false;
            int rewardid = -1;
            // string imagepath ="";
            rewardid = ClientManager.insertReward(
                int.Parse(clientDDL.SelectedValue), NameTB.Text.Trim(), BriefTB.Text.Trim(),
                DescriptionTB.Text.Trim(), Session["Rewardfilename"].ToString(),
                int.Parse(PointsTB.Text.Trim()), 0);
            Session.Remove("Rewardfilename");
            if (rewardid >0)
            {
                Logger.LogInfo(Membership.GetUser().UserName + "- created reward ID:" + rewardid
                  + " name:" + NameTB.Text.Trim()
             , this.GetType());

                ClientDetailPnl.Visible = false;
                ShowCreateRewardBut.Visible = true;
                CreateRewardBut.Visible = true;
                UpdateRewardBut.Visible = true;
                ProductDetailErrorLit.Text = "";
                RadGrid1.Rebind();
            }
            else
            {
                ProductDetailErrorLit.Text = "Error Occurred creating Promotion.";
            }
        }

        protected void UpdateRewardBut_Click(object sender, EventArgs e)
        {
            if (Session["rewardid"] != null)
            {
                int rewardid = (int)Session["rewardid"];
                string filename = "";
                if (Session["Rewardfilename"] != null)
                {
                    filename = Session["Rewardfilename"].ToString();
                }
                else
                {
                    filename = RewardImage.ImageUrl.Remove(0, Config.UploadRewardVirtualPath.Length);
                }
                bool success = ClientManager.updateReward(
                    rewardid,
                    int.Parse(clientDDL.SelectedValue), NameTB.Text.Trim(),BriefTB.Text.Trim(),
                    DescriptionTB.Text.Trim(), filename,
                    int.Parse(PointsTB.Text.Trim()), int.Parse(QtyLit.Text.Trim()));
                Session.Remove("Rewardfilename");
                if (success)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- updated reward ID:" + rewardid
                  + " name:" + NameTB.Text.Trim()
             , this.GetType());
                    ClientDetailPnl.Visible = false;
                    ShowCreateRewardBut.Visible = true;
                    ProductDetailErrorLit.Text = "";
                    RadGrid1.Rebind();
                }
                else
                {
                    ProductDetailErrorLit.Text = "Error Occurred updating Client.";
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
                    string rewardid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardid"].ToString();
                    Literal RewardidLit = e.Item.FindControl("RewardidLit") as Literal;
                    RewardidLit.Text = rewardid;
                }
            }
            catch (Exception eee)
            { }
        }
        protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //check file size
            //if (e.File.ContentLength < 5000)
            //{          
            //}
            string filename = DateTime.Now.ToString("yyyyMMdd") + "_" + Guid.NewGuid().ToString() + e.File.GetExtension();

            var physicalSavePath = MapPath(Config.UploadRewardVirtualPath) + filename;
            //Save physical file on disk
            e.File.SaveAs(physicalSavePath, true);

            //Add filename to session
            Session.Add("Rewardfilename", filename);

        }
        protected void loadClientDDL()
        {
            var x = ClientManager.getAllClients();
            clientDDL.DataSource = x;
            clientDDL.DataTextField = "name";
            clientDDL.DataValueField = "clientid";
            clientDDL.DataBind();
        }
        protected void ClientBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["clientid"] != null)
            {
                int clientid = int.Parse(Request.QueryString["clientid"]);
                Session.Add("clientid", clientid);
                Response.Redirect("client.aspx");
            }
        }

    }
}