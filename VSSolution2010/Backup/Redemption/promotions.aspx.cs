using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;

namespace Redemption
{
    public partial class promotions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PromotionListView_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllPromotionsByClientIdToday(Config.ClientId);
            PromotionListView.DataSource = x;
        }
        protected void GoRewardsBut_Command(object sender, RadListViewCommandEventArgs e)
        {
            string promotionid = e.CommandArgument.ToString();

            Response.Redirect(Config.RootRelativePath + "/rewards.aspx?promotionid=" + promotionid.ToString());
        }
    }
}