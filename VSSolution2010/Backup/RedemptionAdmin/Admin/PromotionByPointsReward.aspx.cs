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
    public partial class PromotionByPointsReward : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["promotionid"] != null)
                {
                    int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var promotion = ClientManager.getPromotion(promotionid);

                PromotionBut.Text = "Promotion ("+promotion.name+")";
                }
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["promotionid"] != null)
            {
                int promotionid = int.Parse(Request.QueryString["promotionid"]);
                var promotion = ClientManager.getPromotion(promotionid);
                var x = ClientManager.getAllRewardsByClient(promotion.clientid);
                RadGrid1.DataSource = x;    
            }    
        }

        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                Session.Add("clientid", clientid);
          
            }
            if (e.CommandName == "Delete2")
            {
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                bool success = ClientManager.deleteClient(clientid);
                if (success)
                {
                

                    RadGrid1.Rebind();
                }
                else
                {
                 //  clientDetailErrorLit.Text = "Error Occurred deleting Client.";
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


        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    CheckBox AllowCB = e.Item.FindControl("AllowCB") as CheckBox;
                    int rewardid = (int)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["rewardid"];
                    int promotionid = -1;
                    if (Request.QueryString["promotionid"] != null)
                    {
                        promotionid = int.Parse(Request.QueryString["promotionid"]);
                    }
                    //Literal ClientidLit = e.Item.FindControl("ClientidLit") as Literal;
                    //ClientidLit.Text = clientid;

                    PromotionByPointReward promotionByPointReward = ClientManager.getPromotionByPointReward(promotionid, rewardid);
              
                    if (promotionByPointReward!=null)
                    {
                        AllowCB.Checked=true;
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
                int rewardid = (int)RadGrid1.MasterTableView.DataKeyValues[item.ItemIndex]["rewardid"];
                if (chkbx.Checked)
                {

                    ClientManager.insertPromotionByPointReward(promotionid, rewardid);
                    Logger.LogInfo(Membership.GetUser().UserName + "- associated promotion ID:" + promotionid
                           + " reward ID:" + rewardid
                   
                       , this.GetType());


                    //user_folder aUser_folder = new user_folder();
                    //aUser_folder.user_id = new Guid(aUserId);
                    //aUser_folder.folder_id = Convert.ToInt32(folderId);
                    //aUser_folder.Save();

                    //M1Bod.DAL.folder afolder = M1Bod.DAL.folder.SingleOrDefault(x => x.id == int.Parse(folderId));
                    //Logger.LogInfo(Membership.GetUser().UserName + " allow user :" + Membership.GetUser(new Guid(aUserId)) + " access to folder :" + afolder.foldername, this.GetType());
                }
                else
                {
                    ClientManager.deletePromotionByPointReward(promotionid, rewardid);
                    Logger.LogInfo(Membership.GetUser().UserName + "- removed association for promotion ID:" + promotionid
                       + " reward ID:" + rewardid

                   , this.GetType());
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

    }
}