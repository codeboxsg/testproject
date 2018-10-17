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
    public partial class Promotion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["promotionid"] != null)
                {
                    int promotionid = (int)Session["promotionid"];
                    LoadPromotionDetails(promotionid);
                }
            }
        }

        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllPromotions();
            RadGrid1.DataSource = x;
        }


        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                Session.Remove("Promofilename");


                int promotionid = (int)((GridDataItem)e.Item).GetDataKeyValue("promotionid");
                Session.Add("promotionid", promotionid);

                LoadPromotionDetails(promotionid);

                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
            if (e.CommandName == "Delete2")
            {
                int promotionid = (int)((GridDataItem)e.Item).GetDataKeyValue("promotionid");
                // bool success = ClientManager.deleteClient(clientid);
                //if (success)
                //{
                //    RadGrid1.Rebind();
                //}
                //else
                //{
                //    promotionDetailErrorLit.Text = "Error Occurred deleting Promotion.";
                //}


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

        private void LoadPromotionDetails(int promotionid)
        {
            loadClientDDL();
            var promotion = ClientManager.getPromotion(promotionid);

            clientDDL.SelectedValue = promotion.clientid.ToString();
            startDateTB.SelectedDate = promotion.startdate;
            endDateTB.SelectedDate = promotion.enddate;
           // graceDateTB.SelectedDate = promotion.gracedate;
            PrefixTB.Text = promotion.prefix;
            TypeRBL.SelectedValue = promotion.type.ToString();
            NameTB.Text = promotion.name;
            BriefTB.Text = promotion.brief;
            DescriptionTB.Text = promotion.description;
            PromotionImage.Visible = true;
            PromotionImage.ImageUrl = Config.UploadPromoVirtualPath + promotion.imagepath;
            PromotionImageCV.EnableClientScript = false;

            ClientDetailPnl.Visible = true;
            ShowCreatePromotionBut.Visible = false;
            CreatePromotionBut.Visible = false;
            UpdatePromotionBut.Visible = true;

            if (promotion.type == (int)PromotionType.BY_POINT)
            {
                LinkByPointsDiv.Visible = true;
                LinkByProductDiv.Visible = false;
            }
            else
            {
                LinkByPointsDiv.Visible = false;
                LinkByProductDiv.Visible = true;
            }
        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreatePromotionBut.Visible = true;
            CreatePromotionBut.Visible = true;
        }

        protected void ShowCreatePromotionBut_Click(object sender, EventArgs e)
        {
            loadClientDDL();
            CreatePromotionBut.Visible = true;
            ClientDetailPnl.Visible = true;
            ShowCreatePromotionBut.Visible = false;
            UpdatePromotionBut.Visible = false;
     
            LinkByPointsDiv.Visible = false;
            LinkByProductDiv.Visible = false;


            //clear fields

            clientDDL.ClearSelection();
            startDateTB.SelectedDate = null;
            endDateTB.SelectedDate = null;
            //graceDateTB.SelectedDate = null;
            PrefixTB.Text = "";
            TypeRBL.ClearSelection(); 
            NameTB.Text = "";
            BriefTB.Text = "";
            DescriptionTB.Text = "";
            PromotionImage.Visible = false;
            PromotionImage.ImageUrl = "";
            PromotionImage.Visible = false;
            PromotionImageCV.EnableClientScript = true;
      
        }

        protected void CreatePromotionBut_Click(object sender, EventArgs e)
        {
            bool success = false;
            int promotionid = -1;
            if (startDateTB.SelectedDate != null || endDateTB.SelectedDate != null )
            {
                promotionid = ClientManager.insertPromotion(int.Parse(clientDDL.SelectedValue),
                                (DateTime)startDateTB.SelectedDate,
                               (DateTime)endDateTB.SelectedDate, DateTime.Today,
                               PrefixTB.Text.Trim(), NameTB.Text.Trim(), BriefTB.Text.Trim(),
                               DescriptionTB.Text.Trim(), Session["Promofilename"].ToString(),
                               int.Parse(TypeRBL.SelectedValue)); 
                //success = ClientManager.insertPromotion(int.Parse(clientDDL.SelectedValue),
                //                 (DateTime)startDateTB.SelectedDate,
                //                (DateTime)endDateTB.SelectedDate, (DateTime)graceDateTB.SelectedDate,
                //                PrefixTB.Text.Trim(), NameTB.Text.Trim(), BriefTB.Text.Trim(),
                //                DescriptionTB.Text.Trim(), Session["Promofilename"].ToString(),
                //                int.Parse(TypeRBL.SelectedValue));

                Session.Remove("Promofilename");
                if (promotionid != -1)
                    success = true;
            }

            if (success)
            {
                Logger.LogInfo(Membership.GetUser().UserName + "- create promotion ID:" + promotionid
               , this.GetType());

                ClientDetailPnl.Visible = false;
                ShowCreatePromotionBut.Visible = true;
                CreatePromotionBut.Visible = true;
                UpdatePromotionBut.Visible = true;
                promotionDetailErrorLit.Text = "";
                RadGrid1.Rebind();
            }
            else
            {
                promotionDetailErrorLit.Text = "Error Occurred creating Promotion.";
            }
        }

        protected void UpdatePromotionBut_Click(object sender, EventArgs e)
        {
            if (Session["promotionid"] != null)
            {
                int promotionid = (int)Session["promotionid"];

                string filename = "";
                if (Session["Promofilename"] != null)
                {
                    filename = Session["Promofilename"].ToString();
                }
                else
                {
                    filename = PromotionImage.ImageUrl.Remove(0, Config.UploadPromoVirtualPath.Length);
                }
                bool success = ClientManager.updatePromotion(promotionid,
                            int.Parse(clientDDL.SelectedValue), (DateTime)startDateTB.SelectedDate,
                               (DateTime)endDateTB.SelectedDate, DateTime.Today,
                               PrefixTB.Text.Trim(), NameTB.Text.Trim(), BriefTB.Text.Trim(),
                                DescriptionTB.Text.Trim(), filename,
                                int.Parse(TypeRBL.SelectedValue));
                //bool success = ClientManager.updatePromotion(promotionid,
                //         int.Parse(clientDDL.SelectedValue), (DateTime)startDateTB.SelectedDate,
                //            (DateTime)endDateTB.SelectedDate, (DateTime)graceDateTB.SelectedDate,
                //            PrefixTB.Text.Trim(), NameTB.Text.Trim(), BriefTB.Text.Trim(),
                //             DescriptionTB.Text.Trim(), filename,
                //             int.Parse(TypeRBL.SelectedValue));
                Session.Remove("Promofilename");
                if (success)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- update promotion ID:" + promotionid
                    , this.GetType());
                    ClientDetailPnl.Visible = false;
                    ShowCreatePromotionBut.Visible = true;
                    promotionDetailErrorLit.Text = "";
                    RadGrid1.Rebind();
                }
                else
                {
                    promotionDetailErrorLit.Text = "Error Occurred updating Promotion.";
                }
            }

        }

        protected void loadClientDDL()
        {
            var x = ClientManager.getAllClients();
            clientDDL.DataSource = x;
            clientDDL.DataTextField = "name";
            clientDDL.DataValueField = "clientid";
            clientDDL.DataBind();
        }

        protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //check file size
            //if (e.File.ContentLength < 5000)
            //{          
            //}
            string filename = DateTime.Now.ToString("yyyyMMdd") + "_" + Guid.NewGuid().ToString() + e.File.GetExtension();

            var physicalSavePath = MapPath(Config.UploadPromoVirtualPath) + filename;
            //Save physical file on disk
            e.File.SaveAs(physicalSavePath, true);

            //Add filename to session
            Session.Add("Promofilename", filename);

        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

            try
            {
                if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
                    e.Item != null && e.Item.DataItem != null)
                {
                    string promotionid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["promotionid"].ToString();
                    int type = (int)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["type"];
                    Literal PromoidLit = e.Item.FindControl("PromoidLit") as Literal;
                    PromoidLit.Text = promotionid;
                    GridDataItem dataBoundItem = e.Item as GridDataItem;
                 
                    switch (type)
                    {
                        case (int)PromotionType.BY_POINT:
                            dataBoundItem["type"].Text = PromotionType.BY_POINT.ToString();
                       ;
                            break;
                        case (int)PromotionType.BY_PRODUCT:
                            dataBoundItem["type"].Text = PromotionType.BY_PRODUCT.ToString();
                          
                            break;
                    }
                }
            }
            catch (Exception eee)
            { }

        }

        protected void RewardsBut_Click(object sender, EventArgs e)
        {
            if (Session["promotionid"] != null)
            {
                Response.Redirect("PromotionByPointsReward.aspx?promotionid=" + Session["promotionid"]);
            }
        }
        protected void ProductBut_Click(object sender, EventArgs e)
        {
            if (Session["promotionid"] != null)
            {
                Response.Redirect("PromotionByPointsProduct.aspx?promotionid=" + Session["promotionid"]);
            }
        }
        protected void ProductAndRewardBut_Click(object sender, EventArgs e)
        {
            if (Session["promotionid"] != null)
            {
                Response.Redirect("PromotionByProductProductReward.aspx?promotionid=" + Session["promotionid"]);
            }
        }


    }
}