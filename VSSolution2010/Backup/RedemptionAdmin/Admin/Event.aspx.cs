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
    public partial class Event : System.Web.UI.Page
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

                if (Session["eventid"] != null)
                {
                    int eventid = int.Parse(Session["eventid"].ToString());
                    LoadEventDetail(eventid);

                }
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Request.QueryString["clientid"] != null)
            {
                var x = ClientManager.getAllEventsByClientId(int.Parse(Request.QueryString["clientid"]));
                RadGrid1.DataSource = x;
            }
            else
            {
                var x = ClientManager.getAllEvents();
                RadGrid1.DataSource = x;
            }

        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit2")
            {
                Session.Remove("Rewardfilename");


                int eventid = (int)((GridDataItem)e.Item).GetDataKeyValue("eventid");
                Session.Add("eventid", eventid);
                LoadEventDetail(eventid);
                //     int clientid = (int)((GridDataItem)e.Item).GetDataKeyValue("clientid");
                //     bool success = ClientManager.updateClient(clientid,ContactNameTB.Text.Trim(), NameTB.Text.Trim(), PhoneNoTB.Text.Trim());
                // if (success)
                //{
                //     RadGrid1.Rebind();
            }
            if (e.CommandName == "Delete2")
            {
                int eventid = (int)((GridDataItem)e.Item).GetDataKeyValue("eventid");
                bool success = ClientManager.deleteEvent(eventid);
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

        private void LoadEventDetail(int eventid)
        {

            loadClientDDL();
            var anevent = ClientManager.getEvent(eventid);
 

            clientDDL.SelectedValue = anevent.clientid.ToString();
            NameTB.Text = anevent.name;
            DescriptionTB.Text = anevent.description;
            BriefTB.Text = anevent.brief;
            EventImage.Visible = true;
            EventImage.ImageUrl = Config.UploadEventVirtualPath + anevent.imagepath;
            RewardImageCV.EnableClientScript = false;
            UrlTB.Text = anevent.url;
            startDateTB.SelectedDate = anevent.startdate;
            endDateTB.SelectedDate = anevent.enddate;
            ClientDetailPnl.Visible = true;
            ShowCreateEventBut.Visible = false;
            CreateEventBut.Visible = false;
            UpdateEventBut.Visible = true;
         
        }

        protected void CancelBut_Click(object sender, EventArgs e)
        {
            ClientDetailPnl.Visible = false;
            ShowCreateEventBut.Visible = true;
            CreateEventBut.Visible = true;
        }

        protected void ShowCreateEventBut_Click(object sender, EventArgs e)
        {
            loadClientDDL();
            CreateEventBut.Visible = true;
            ClientDetailPnl.Visible = true;
            ShowCreateEventBut.Visible = false;
            EventImage.Visible = false;
            RewardImageCV.EnableClientScript = true;
            UpdateEventBut.Visible = false;
            if (Request.QueryString["clientid"] != null)
            {
                int clientid = int.Parse(Request.QueryString["clientid"]);

                clientDDL.SelectedValue = clientid.ToString();
            }
            //clear fields
            NameTB.Text = "";
            DescriptionTB.Text = "";

            BriefTB.Text = "";
            UrlTB.Text = "";
            startDateTB.Clear();
            endDateTB.Clear();

        }
       

        protected void CreateEventBut_Click(object sender, EventArgs e)
        {
            int eventid = -1;
            bool success = false;
            // string imagepath ="";
            eventid = ClientManager.insertEvent(
                int.Parse(clientDDL.SelectedValue),
                NameTB.Text.Trim(), BriefTB.Text.Trim(),
                DescriptionTB.Text.Trim(), Session["Rewardfilename"].ToString(),
                UrlTB.Text.Trim(),
               (DateTime)startDateTB.SelectedDate, (DateTime)endDateTB.SelectedDate);
            Session.Remove("Rewardfilename");
            if (eventid>0)
            {
                Logger.LogInfo(Membership.GetUser().UserName + "- created event ID:" + eventid
+ " name:" + NameTB.Text.Trim()
, this.GetType());

                ClientDetailPnl.Visible = false;
                ShowCreateEventBut.Visible = true;
                CreateEventBut.Visible = true;
                UpdateEventBut.Visible = true;
                ProductDetailErrorLit.Text = "";
                RadGrid1.Rebind();
            }
            else
            {
                ProductDetailErrorLit.Text = "Error Occurred creating Event.";
            }
        }

        protected void UpdateEventBut_Click(object sender, EventArgs e)
        {
            if (Session["eventid"] != null)
            {
                int eventid = (int)Session["eventid"];
                string filename = "";
                if (Session["Rewardfilename"] != null)
                {
                    filename = Session["Rewardfilename"].ToString();
                }
                else
                {
                    filename = EventImage.ImageUrl.Remove(0, Config.UploadEventVirtualPath.Length);
                }

                bool success = ClientManager.updateEvent(
                    eventid,int.Parse(clientDDL.SelectedValue),
                NameTB.Text.Trim(), BriefTB.Text.Trim(),
                DescriptionTB.Text.Trim(), filename,
                UrlTB.Text.Trim(),
               (DateTime)startDateTB.SelectedDate, (DateTime)endDateTB.SelectedDate);

              
                Session.Remove("Rewardfilename");
                if (success)
                {
                    Logger.LogInfo(Membership.GetUser().UserName + "- updated event ID:" + eventid
 + " name:" + NameTB.Text.Trim()
 , this.GetType());

                    ClientDetailPnl.Visible = false;
                    ShowCreateEventBut.Visible = true;
                    ProductDetailErrorLit.Text = "";
                    RadGrid1.Rebind();
                }
                else
                {
                    ProductDetailErrorLit.Text = "Error Occurred updating Event.";
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
                    string eventid = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["eventid"].ToString();
                    Literal RewardidLit = e.Item.FindControl("RewardidLit") as Literal;
                    RewardidLit.Text = eventid;
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

            var physicalSavePath = MapPath(Config.UploadEventVirtualPath) + filename;
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