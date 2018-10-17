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
namespace Redemption
{
    public partial class ClaimPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check login
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Config.loginUrl);
            }

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
                string filename=DateTime.Now.ToString("yyyyMMdd")+"_"+ Guid.NewGuid().ToString() + e.File.GetExtension();

                var physicalSavePath = MapPath(Config.UploadInvoiceVirtualPath) + filename;
             //Save physical file on disk
             e.File.SaveAs(physicalSavePath, true);

                //Add receipt to uploaded iamge
            //create upload receipt record
           

             ClientManager.insertRedemptionByPointReceipt(
                 (Guid)Membership.GetUser().ProviderUserKey,
                 filename,
                 Config.ClientId,
                 (int)RedemptionByPointReceiptState.PENDING_PROCESS,0,0,"",null);

             var client = ClientManager.getClient(Config.ClientId);
             string emailLogoUrl = Config.SiteRootUrl  + client.logoimagename;
         
             Hashtable values = new Hashtable();
             values.Add("[/logo/]", emailLogoUrl);
             values.Add("[/SiteRootUrl/]", Config.SiteRootUrl);
             var redemptionMember = ClientManager.getRedemptionMember((Guid)Membership.GetUser().ProviderUserKey);
             bool canSendEmail = EmailManager.SendClaimPointAckMail(
                                       Membership.GetUser().Email,
                                       redemptionMember.firstname,
                                       values, this.Response);

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



        protected void ClaimPointBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClaimPointsAck.aspx");
        }


    }
}