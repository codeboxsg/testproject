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
    public partial class Product : System.Web.UI.Page
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
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["clientid"] != null)
            {
                var x = ClientManager.getAllProductsByClientId(int.Parse(Request.QueryString["clientid"]));

                RadGrid1.DataSource = x;
            }
            else
            {
                var x = ClientManager.getAllProducts();

                RadGrid1.DataSource = x;
            }

        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                int productid = (int)((GridDataItem)e.Item).GetDataKeyValue("productid");
                loadClientDDL();
                var product = ClientManager.getProduct(productid);
                //ContactNameTB.Text = client.contactname;
                //NameTB.Text = client.name;
                //PhoneNoTB.Text = client.phoneno;

                clientDDL.SelectedValue = product.clientid.ToString();
                NameTB.Text = product.name;
                ModelTB.Text = product.model;
                PointsTB.Text = product.points.ToString();
                Session.Add("productid", productid);
                ClientDetailPnl.Visible = true;
               // ShowCreateProductBut.Visible = false;
                CreateProductBut.Visible = false;
                UpdateProductBut.Visible = true;
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

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreateProductBut.Visible = true;
            CreateProductBut.Visible = true;
        }

        protected void ShowCreateProductBut_Click(object sender, EventArgs e)
        {
            loadClientDDL();
            CreateProductBut.Visible = true;
            ClientDetailPnl.Visible = true;
            //ShowCreateProductBut.Visible = false;
            UpdateProductBut.Visible = false;
            if (Request.QueryString["clientid"] != null)
            {
                int clientid = int.Parse(Request.QueryString["clientid"]);

                clientDDL.SelectedValue = clientid.ToString();
            }
            //clear fields
            NameTB.Text = "";
            ModelTB.Text = "";
            PointsTB.Text = "";
        }

        protected void CreateProductBut_Click(object sender, EventArgs e)
        {
            bool success = false;
            int productid = -1;
            productid = ClientManager.insertProduct(
                NameTB.Text.Trim(), ModelTB.Text.Trim(),
                "", "",
                int.Parse(clientDDL.SelectedValue), int.Parse(PointsTB.Text.Trim()));

            if (productid>0)
            {
                Logger.LogInfo(Membership.GetUser().UserName + "- created product ID:" + productid
                    + " name:" + NameTB.Text.Trim()
               , this.GetType());

                ClientDetailPnl.Visible = false;
                ShowCreateProductBut.Visible = true;
                CreateProductBut.Visible = true;
                UpdateProductBut.Visible = true;
                ProductDetailErrorLit.Text = "";
                RadGrid1.Rebind();
            }
            else
            {
                ProductDetailErrorLit.Text = "Error Occurred creating Promotion.";
            }
        }

        protected void UpdateProductBut_Click(object sender, EventArgs e)
        {
            if (Session["productid"] != null)
            {
                int productid = (int)Session["productid"];

                bool success = ClientManager.updateProduct(
                    productid,
                     NameTB.Text.Trim(), ModelTB.Text.Trim(),
                    "", "",
                    int.Parse(clientDDL.SelectedValue), int.Parse(PointsTB.Text.Trim()));
                if (success)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- updated product ID:" + productid
                  + " name:" + NameTB.Text.Trim()
             , this.GetType());
                    ClientDetailPnl.Visible = false;
                    ShowCreateProductBut.Visible = true;
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
                    string productid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["productid"].ToString();
                    Literal ProductidLit = e.Item.FindControl("ProductidLit") as Literal;
                    ProductidLit.Text = productid;
                }
            }
            catch (Exception eee)
            { }
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