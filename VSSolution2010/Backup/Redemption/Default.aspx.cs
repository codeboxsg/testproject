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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EventListView_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllEventsByClientIdToday(Config.ClientId);
            EventListView.DataSource = x;


           // EventListView.AllowPaging = (x.Count > 3);
            
        }
        protected void EventListView_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            //  GoEventsHL
            RadListViewDataItem item = (RadListViewDataItem)e.Item;
            //string redemptionrewardid = (string)EventListView.MasterTableView.DataKeyValues[e.Item.ItemIndex]["redemptionrewardid"].ToString();
            string url = (string)e.Item.OwnerListView.DataKeyValues[item.DisplayIndex]["url"].ToString();
            HyperLink GoEventsHL = e.Item.FindControl("GoEventsHL") as HyperLink;
            GoEventsHL.NavigateUrl = url;
           

        }
        protected void GoEventsBut_Command(object sender, RadListViewCommandEventArgs e)
        {
            string url = e.CommandArgument.ToString();

            Response.Redirect(url);
        }
        protected void PromotionListView_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var x = ClientManager.getAllPromotionsByClientIdToday(Config.ClientId);
            PromotionListView.DataSource = x;
        }

        protected void GoRewardsBut_Command(object sender, RadListViewCommandEventArgs e)
        {
            string promotionid = e.CommandArgument.ToString();

            Response.Redirect(Config.RootRelativePath+"/rewards.aspx?promotionid=" + promotionid.ToString());
        }
       

       
        
    }
}
