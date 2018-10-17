using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Security;
using RedemptionAdmin;
using RedemptionData;


namespace RedemptionAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!BL.OTPManager.OTPIsActive())
            //{
            //    RadGrid1.Columns[Properties.Settings.Default.MobileUsersListMobileColIndex].Visible = false;
            //}
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

            if (e.CommandName == "enable")
            {
                string aUsername = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["UserName"].ToString();
                MembershipUser aMembershipUser = Membership.GetUser(aUsername);

                aMembershipUser.IsApproved = !aMembershipUser.IsApproved;
                if (aMembershipUser.IsApproved)
                    Logger.LogInfo(Membership.GetUser().UserName + "- enabled user :" + aMembershipUser.UserName, this.GetType());
                else
                    Logger.LogInfo(Membership.GetUser().UserName + "- disabled user :" + aMembershipUser.UserName, this.GetType());

                Membership.UpdateUser(aMembershipUser);
                var x = ClientManager.getAllAdminUsers();
                RadGrid1.DataSource = x;
                RadGrid1.DataBind();
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if ((e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem) &&
           e.Item != null && e.Item.DataItem != null)
            {
                string aUsername = (string)RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["UserName"].ToString();
                LinkButton enableLB = e.Item.FindControl("enableLB") as LinkButton;
                HyperLink ResetPasswordHL = e.Item.FindControl("ResetPasswordHL") as HyperLink;
                HyperLink SetPasswordHL = e.Item.FindControl("SetPasswordHL") as HyperLink;
                HyperLink EditHL = e.Item.FindControl("EditHL") as HyperLink;

                MembershipUser aMembershipUser = Membership.GetUser(aUsername);
                if (aMembershipUser.IsApproved)
                { enableLB.Text = "Disable"; }
                else { enableLB.Text = "Enable"; }

                ResetPasswordHL.NavigateUrl = "resetpassword.aspx?username=" + aUsername;
                SetPasswordHL.NavigateUrl = "usersetpassword.aspx?username=" + aUsername;
                EditHL.NavigateUrl = "edituser.aspx?username=" + aUsername;
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllAdminUsers();
            RadGrid1.DataSource = x;

        }
    }
}