using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using RedemptionData;
using System.Web.Security;
using System.Collections;
using RedemptionAdmin;
namespace Redemption
{
    public partial class MemberClaimPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["userid"] != null)
                {
                    string userid = Request.QueryString["userid"];

                    UsernameHL.Text = Membership.GetUser(new Guid(userid)).UserName;
                    UsernameHL.NavigateUrl = "MemberClient.aspx?userid=" + userid;
                }
                if (Request.QueryString["clientid"] != null)
                {
                    int clientid = int.Parse(Request.QueryString["clientid"]);
                    ClientLit.Text = ClientManager.getClient(clientid).name;
                }

            }
            ////Check login
            //if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect(Config.loginUrl);
            //}

            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    //is loggedin
            //    NotLoggedInDiv.Visible = false;
            //    LoggedInDiv.Visible = true;
            //}
            //else
            //{
            //    NotLoggedInDiv.Visible = true;
            //    LoggedInDiv.Visible = false;
            //}

            RadAsyncUpload1.TargetFolder = "~/img/invoice";
        }

        protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //check file size
            //if (e.File.ContentLength < 5000)
            //{          
            //}
            if ((Request.QueryString["userid"] != null) || (Request.QueryString["clientid"] != null))
            {
                string userid = Request.QueryString["userid"];
                MembershipUser aMembershipUser = Membership.GetUser(new Guid(userid));
                int clientId = int.Parse(Request.QueryString["clientid"]);
                string filename = DateTime.Now.ToString("yyyyMMdd") + "_" + Guid.NewGuid().ToString() + e.File.GetExtension();

                var physicalSavePath = MapPath(Config.UploadInvoiceVirtualPath) + filename;
                //Save physical file on disk
                e.File.SaveAs(physicalSavePath, true);

                //Add receipt to uploaded iamge
                //create upload receipt record


                ClientManager.insertRedemptionByPointReceipt(
                 (Guid)aMembershipUser.ProviderUserKey,
                    filename,
                   clientId,
                    (int)RedemptionByPointReceiptState.PENDING_PROCESS, 0, 0, "", null);

                var client = ClientManager.getClient(clientId);

                string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                Hashtable values = new Hashtable();
                values.Add("[/logo/]", emailpath);
                var redemptionMember = ClientManager.getRedemptionMember((Guid)aMembershipUser.ProviderUserKey);
                //bool canSendEmail = EmailManager.SendClaimPointAckMail(
                //                          aMembershipUser.Email,
                //                          redemptionMember.firstname,
                //                          values, client.clientid, this.Response);


                Logger.LogInfo(Membership.GetUser().UserName + "- submitted claimpoint username :"
                    + aMembershipUser.UserName
                   + "client ID :"
                    + clientId
                    , this.GetType());


                //string emailpath = Config.MainSiteRootUrl + client.siterelativepath + client.logoimagename;
                //Hashtable values = new Hashtable();
                //values.Add("[/logo/]", emailpath);
                //var redemptionMember = ClientManager.getRedemptionMember(UserId);
                //bool canSendEmail = EmailManager.SendClaimPointApprovalMail(
                //                          membershipUser.Email,
                //                          redemptionMember.firstname,
                //                          values, client.emailphysicalpath);


                // e.IsValid = true;
                /*
                BtnSubmit.Visible = false;
                RefreshButton.Visible = true;
                RadAsyncUpload1.Visible = false;
 
                var liItem = new HtmlGenericControl("li");
                liItem.InnerText = e.File.FileName;
            
 
                if (totalBytes < MaxTotalBytes)
                {
                    // Total bytes limit has not been reached, accept the file
                    e.IsValid = true;
                    totalBytes += e.File.ContentLength;
                }
                else
                {
                    // Limit reached, discard the file
                    e.IsValid = false;
                }
 
                if (e.IsValid)
                {
 
                    ValidFiles.Visible = true;
                    ValidFilesList.Controls.AddAt(0, liItem);
 
                }
                else
                {
                 
                    InvalidFiles.Visible = true;
                    InValidFilesList.Controls.AddAt(0, liItem);
                }*/
            }
        }


        protected void ClaimPointBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberClaimPointsAck.aspx");
        }
        protected void MembersBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("member.aspx");
        }

    }
}