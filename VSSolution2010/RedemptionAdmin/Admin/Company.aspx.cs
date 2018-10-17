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
    public partial class Company : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["clientid"] != null)
                //{
                //    try
                //    {
                //        int clientid = int.Parse(Session["clientid"].ToString());
                //        LoadClientDetail(clientid);
                //    }
                //    catch (Exception eee)
                //    { }

                //}
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllResellers();
            RadGrid1.DataSource = x;
        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                int resellerid = (int)((GridDataItem)e.Item).GetDataKeyValue("resellerid");
                Session.Add("resellerid", resellerid);
                LoadResellerDetail(resellerid);
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

        private void LoadResellerDetail(int resellerid)
        {
            var reseller = ClientManager.getReseller(resellerid);

            NameTB.Text = reseller.name;



            ClientDetailPnl.Visible = true;
            ShowCreateClientBut.Visible = false;
            CreateClientBut.Visible = false;
            UpdateClientBut.Visible = true;

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
            ShowCreateClientBut.Visible = false;
            UpdateClientBut.Visible = false;


            //clear fields
            NameTB.Text = "";

        }

        protected void CreateClientBut_Click(object sender, EventArgs e)
        {
            int resellerid = ClientManager.insertReseller(NameTB.Text.Trim());
            if (resellerid > 0)
            {
                ClientDetailPnl.Visible = false;
                ShowCreateClientBut.Visible = true;
                CreateClientBut.Visible = true;
                UpdateClientBut.Visible = true;
                clientDetailErrorLit.Text = "";
                RadGrid1.Rebind();

                Logger.LogInfo(Membership.GetUser().UserName + "- created company ID:" + resellerid
                 + " name:" + NameTB.Text.Trim()
            , this.GetType());
            }
            else
            {
                clientDetailErrorLit.Text = "Error Occurred creating Reseller.";
            }
        }

        protected void UpdateClientBut_Click(object sender, EventArgs e)
        {
            if (Session["resellerid"] != null)
            {
                int resellerid = (int)Session["resellerid"];

                bool success = ClientManager.updateReseller(resellerid, NameTB.Text.Trim());
                if (success)
                {
                    ClientDetailPnl.Visible = false;
                    ShowCreateClientBut.Visible = true;
                    clientDetailErrorLit.Text = "";
                    RadGrid1.Rebind();

                    Logger.LogInfo(Membership.GetUser().UserName + "- updated company ID:" + resellerid
                     + " name:" + NameTB.Text.Trim()
                     , this.GetType());
                }
                else
                {
                    clientDetailErrorLit.Text = "Error Occurred updating Reseller.";
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
                    string resellerid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["resellerid"].ToString();
                    Literal ReselleridLit = e.Item.FindControl("ReselleridLit") as Literal;
                    ReselleridLit.Text = resellerid;
                }
            }
            catch (Exception eee)
            { }
        }




    }
}