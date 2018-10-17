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
    public partial class Client1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["clientid"] != null)
                {
                    try
                    {
                        int clientid = int.Parse(Session["clientid"].ToString());
                        LoadClientDetail(clientid);
                    }
                    catch (Exception eee)
                    { }

                }
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllClients();
            RadGrid1.DataSource = x;
        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                Session.Add("clientid", clientid);
                LoadClientDetail(clientid);
                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
            if (e.CommandName == "Delete2")
            {
                int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                bool success = ClientManager.deleteClient(clientid);
                if (success)
                {
                      Logger.LogInfo(Membership.GetUser().UserName + "- deleted client ID:" + clientid
                          , this.GetType());
                    RadGrid1.Rebind();
                }
                else
                {
                    clientDetailErrorLit.Text = "Error Occurred deleting Client.";
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

        private void LoadClientDetail(int clientid)
        {
            var client = ClientManager.getClient(clientid);
            ContactNameTB.Text = client.contactname;
            NameTB.Text = client.name;
            PhoneNoTB.Text = client.phoneno;
            SiteRelativePathTB.Text = client.siterelativepath;
            LogoImageNameTB.Text = client.logoimagename;
            EmailphysicalpathTB.Text = client.emailphysicalpath;

            ClientDetailPnl.Visible = true;
            //ShowCreateClientBut.Visible = false;
            CreateClientBut.Visible = false;
            UpdateClientBut.Visible = true;
            ProductsDiv.Visible = true;
            RewardsDiv.Visible = true;
        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreateClientBut.Visible = true;
            CreateClientBut.Visible = true;
        }

        protected void ShowCreateClientBut_Click(object sender, EventArgs e)
        {
            CreateClientBut.Visible = true;
            ClientDetailPnl.Visible = true;
           // ShowCreateClientBut.Visible = false;
            UpdateClientBut.Visible = false;
            ProductsDiv.Visible = false;
            RewardsDiv.Visible = false;

            //clear fields
            NameTB.Text = "";
            ContactNameTB.Text = "";
            PhoneNoTB.Text = "";
            SiteRelativePathTB.Text = "";
            LogoImageNameTB.Text = "";
        }

        protected void CreateClientBut_Click(object sender, EventArgs e)
        {
            int clientid = ClientManager.insertClient(
                    ContactNameTB.Text.Trim(),
                    NameTB.Text.Trim(), PhoneNoTB.Text.Trim(),
                    LogoImageNameTB.Text.Trim(), SiteRelativePathTB.Text.Trim(),
                    EmailphysicalpathTB.Text.Trim());
            if (clientid>0)
            {
                Logger.LogInfo(Membership.GetUser().UserName + "- created client ID:" + clientid
                    + " name:" + NameTB.Text.Trim()
                , this.GetType());
                ClientDetailPnl.Visible = false;
                ShowCreateClientBut.Visible = true;
                CreateClientBut.Visible = true;
                UpdateClientBut.Visible = true;
                clientDetailErrorLit.Text = "";
                RadGrid1.Rebind();
            }
            else
            {
                clientDetailErrorLit.Text = "Error Occurred creating Client.";
            }
        }

        protected void UpdateClientBut_Click(object sender, EventArgs e)
        {
            if (Session["clientid"] != null)
            {
                int clientid = (int)Session["clientid"];

                bool success = ClientManager.updateClient(
                    clientid, ContactNameTB.Text.Trim(), 
                    NameTB.Text.Trim(), PhoneNoTB.Text.Trim(),
                    LogoImageNameTB.Text.Trim(), SiteRelativePathTB.Text.Trim(),
                    EmailphysicalpathTB.Text.Trim());
                if (success)
                {
                    ClientDetailPnl.Visible = false;
                    ShowCreateClientBut.Visible = true;
                    clientDetailErrorLit.Text = "";
                    RadGrid1.Rebind();
                    Logger.LogInfo(Membership.GetUser().UserName + "- updated client ID:" + clientid
                       + " name:" + NameTB.Text.Trim()
                  , this.GetType());
                }
                else
                {
                    clientDetailErrorLit.Text = "Error Occurred updating Client.";
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
                    string clientid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["clientid"].ToString();
                    Literal ClientidLit = e.Item.FindControl("ClientidLit") as Literal;
                    ClientidLit.Text = clientid;
                }
            }
            catch (Exception eee)
            { }
        }

        protected void ProductsLB_Click(object sender, EventArgs e)
        {
            if (Session["clientid"] != null)
            {
                Response.Redirect("product.aspx?clientid=" + Session["clientid"]);
            }
        }

        protected void RewardsLB_Click(object sender, EventArgs e)
        {
            if (Session["clientid"] != null)
            {
                Response.Redirect("reward.aspx?clientid=" + Session["clientid"]);
            }
        }
   
        
    }
}