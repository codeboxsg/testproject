using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RedemptionAdmin
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Roles.IsUserInRole("Staff"))
            {
             NavigationMenu.Items.Remove(NavigationMenu.FindItem("User"));
             NavigationMenu.Items.Remove(NavigationMenu.FindItem("ReportRedemption"));
             NavigationMenu.Items.Remove(NavigationMenu.FindItem("ReportStockSummary"));
             NavigationMenu.Items.Remove(NavigationMenu.FindItem("ReportMember"));
             NavigationMenu.Items.Remove(NavigationMenu.FindItem("Audit"));
            }
        }
    }
}
