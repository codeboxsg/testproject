using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;
using ApplicationServices;
using System.Web.Security;

namespace RedemptionAdmin.Admin
{
    public partial class PromotionByProductProductReward : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["promotionid"] != null)
                {
                    int promotionid = int.Parse(Request.QueryString["promotionid"]);
                    var promotion = ClientManager.getPromotion(promotionid);

                    PromotionBut.Text = "Promotion (" + promotion.name + ")";
                }

                loadRewardDDL();
                loadProductDDL();
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var promotionByProductProductReward = ClientManager.getAllPromotionByProductProductRewardByPromotionId(promotionid);
                //var x = ClientManager.getAllProductsByClientId(promotion.clientid);
                RadGrid1.DataSource = promotionByProductProductReward;
            }
        }

        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "Delete2")
            {
                if (Request.QueryString["promotionid"] != null)
                {
                    int promotionid = int.Parse(Request.QueryString["promotionid"]);
                    int rewardid = (int)((GridDataItem)e.Item).GetDataKeyValue("rewardid");
                    int productid = (int)((GridDataItem)e.Item).GetDataKeyValue("productid");
                    bool success = ClientManager.deletePromotionByProductProductReward(
                          promotionid, rewardid, productid);
                    if (success)
                    {
                        Logger.LogInfo(Membership.GetUser().UserName + "- removed association for promotion ID:" + promotionid
                            + " reward ID:" + rewardid
                            + " product ID:" + productid
                        , this.GetType());

                        RadGrid1.Rebind();
                    }
                    else
                    {
                        //  clientDetailErrorLit.Text = "Error Occurred deleting Client.";
                    }
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
                    CheckBox AllowCB = e.Item.FindControl("AllowCB") as CheckBox;
                    int productid = (int)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productid"];
                    int promotionid = -1;
                    if (Request.QueryString["promotionid"] != null)
                    {
                        promotionid = int.Parse(Request.QueryString["promotionid"]);
                    }
                    //Literal ClientidLit = e.Item.FindControl("ClientidLit") as Literal;
                    //ClientidLit.Text = clientid;

                    PromotionByPointProduct promotionByPointProduct = ClientManager.getPromotionByPointProduct(promotionid, productid);

                    if (promotionByPointProduct != null)
                    {
                        AllowCB.Checked = true;
                    }

                }
            }
            catch (Exception eee)
            { }
        }

        //protected void ProductsLB_Click(object sender, EventArgs e)
        //{
        //    if (Session["clientid"] != null)
        //    {
        //        Response.Redirect("product.aspx?clientid=" + Session["clientid"]);
        //    }
        //}

        //protected void RewardsLB_Click(object sender, EventArgs e)
        //{
        //    if (Session["clientid"] != null)
        //    {
        //        Response.Redirect("reward.aspx?clientid=" + Session["clientid"]);
        //    }
        //}

        protected void AllowCB_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                //   string folderId = Request["id"].ToString();
                int promotionid = -1;
                if (Request.QueryString["promotionid"] != null)
                {
                    promotionid = int.Parse(Request.QueryString["promotionid"]);
                }
                CheckBox chkbx = (CheckBox)sender;
                GridDataItem item = (GridDataItem)chkbx.NamingContainer;
                int productid = (int)RadGrid1.MasterTableView.DataKeyValues[item.ItemIndex]["productid"];
                if (chkbx.Checked)
                {

                    ClientManager.insertPromotionByPointProduct(promotionid, productid);
                    //user_folder aUser_folder = new user_folder();
                    //aUser_folder.user_id = new Guid(aUserId);
                    //aUser_folder.folder_id = Convert.ToInt32(folderId);
                    //aUser_folder.Save();

                    //M1Bod.DAL.folder afolder = M1Bod.DAL.folder.SingleOrDefault(x => x.id == int.Parse(folderId));
                    //Logger.LogInfo(Membership.GetUser().UserName + " allow user :" + Membership.GetUser(new Guid(aUserId)) + " access to folder :" + afolder.foldername, this.GetType());
                }
                else
                {
                    ClientManager.deletePromotionByPointProduct(promotionid, productid);

                    //                //remove user folder record
                    //                user_folder aUser_folder = user_folder.SingleOrDefault(x => x.user_id == new Guid(aUserId) && x.folder_id == Convert.ToInt32(folderId));
                    //                //aUser_folder.Delete();
                    //                new SubSonic.Query.Delete<user_folder>(new M1Bod.DAL.M1BodDBDB().DataProvider)
                    //.Where<user_folder>(x => x.user_id == new Guid(aUserId) && x.folder_id == Convert.ToInt32(folderId)).Execute();

                    //                M1Bod.DAL.folder afolder = M1Bod.DAL.folder.SingleOrDefault(x => x.id == int.Parse(folderId));
                    //                Logger.LogInfo(Membership.GetUser().UserName + " removed user :" + Membership.GetUser(new Guid(aUserId)) + " access to folder :" + afolder.foldername, this.GetType());

                }
            }
            catch (Exception)
            { }

        }

        protected void PromotionBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                Session.Add("promotionid", promotionid);
            }

            Response.Redirect("promotion.aspx");
        }


        protected void loadProductDDL()
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var promotion = ClientManager.getPromotion(promotionid);

                var x = ClientManager.getAllProductsByClientId(promotion.clientid);
                ProductDDL.DataSource = x;
                ProductDDL.DataTextField = "name";
                ProductDDL.DataValueField = "productid";
                ProductDDL.DataBind();
            }
        }

        protected void loadRewardDDL()
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var promotion = ClientManager.getPromotion(promotionid);

                var x = ClientManager.getAllRewardsByClient(promotion.clientid);
                RewardDDL.DataSource = x;
                RewardDDL.DataTextField = "name";
                RewardDDL.DataValueField = "rewardid";
                RewardDDL.DataBind();
            }
        }

        protected void InsertRewardProductBut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                bool success = ClientManager.insertPromotionByProductProductReward(
                        promotionid,
                        int.Parse(RewardDDL.SelectedValue),
                        int.Parse(ProductDDL.SelectedValue));

                if (success)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- associate for promotion ID:" + promotionid
                         + " reward ID:" + int.Parse(RewardDDL.SelectedValue)
                         + " product ID:" + int.Parse(ProductDDL.SelectedValue)
                     , this.GetType());

                    ClientDetailPnl.Visible = false;
                    AddRewardProductBut.Visible = true;
                    promotionDetailErrorLit.Text = "";
                    RadGrid1.Rebind();
                }
                else
                {
                    promotionDetailErrorLit.Text = "Cannot insert duplicate entry.";
                }
            }
        }
        protected void AddRewardProductBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = true;
            promotionDetailErrorLit.Text = "";
            AddRewardProductBut.Visible = false;
        }
        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            AddRewardProductBut.Visible = true;
        }
    }
}