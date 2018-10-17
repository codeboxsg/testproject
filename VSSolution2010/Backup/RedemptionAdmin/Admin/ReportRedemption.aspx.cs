using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RedemptionData;

using System.IO;
namespace RedemptionAdmin.Admin
{
    public partial class ReportRedemption : System.Web.UI.Page
    {
        //https://github.com/telerik/aspnet-sdk/blob/master/Grid/ThreeRadGridsExport/ThreeRadGridsExport.aspx.cs
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
                //testing setup
                DateTime fromDate = new DateTime(2013, 1, 29);            
                DateTime toDate = new DateTime(2013, 12, 29);

                StartDateRadDatePicker.SelectedDate = fromDate;
                EndDateRadDatePicker.SelectedDate = toDate;

                var x = ClientManager.getAllPromotions();
                PromotionDDL.DataTextField = "name";
                PromotionDDL.DataValueField = "promotionid";
                PromotionDDL.DataSource = x;
                PromotionDDL.DataBind();

                //var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(
                //    (DateTime)StartDateRadDatePicker.SelectedDate,(DateTime) EndDateRadDatePicker.SelectedDate,
                //    int.Parse(PromotionDDL.SelectedValue));
                //RadGrid1.DataSource = x;
            }
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int i;
            if (int.TryParse(PromotionDDL.SelectedValue.ToString(),out  i))
            {
                var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(
                          (DateTime)StartDateRadDatePicker.SelectedDate, (DateTime)EndDateRadDatePicker.SelectedDate,
                           int.Parse(PromotionDDL.SelectedValue));
                RadGrid1.DataSource = x;
            }
        }
        protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
           
    
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

        protected void PromotionDDL_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
        
        }    

        protected void Button1_Click(object sender, EventArgs e)
        {
           // int clientid = int.Parse(ClientDDL.SelectedValue);
            String filename = "Redemptions_" + PromotionDDL.SelectedItem.Text + "_" + DateTime.Today.ToString("dd/MM/yyyy") + ".xls";


            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/vnd.ms-excel";

            string apath = MapPath("~/temp.s");
            System.IO.StreamWriter vw = new System.IO.StreamWriter(apath, true);

           // StringWriter stringWriter = WriteStockSummary(vw);

            Response.Write("<br/>" + filename + "<br/>");
            //Response.Write("<br/><br/>");
            Response.Write("<br/>Period: " + ((DateTime)StartDateRadDatePicker.SelectedDate).ToString("dd/MM/yyyy")
              + " - " + ((DateTime)EndDateRadDatePicker.SelectedDate).ToString("dd/MM/yyyy") + "<br/>");

            var promotion = ClientManager.getPromotion(int.Parse(PromotionDDL.SelectedValue));
            PromotionType pt = (PromotionType)promotion.type;
            Response.Write("Type: " + pt.ToString() + "<br/>");
            if (pt == PromotionType.BY_POINT)
            {
                int totalPointsRedeemed = ClientManager.getTotalPointsRedeemedByPromotionPeriod((DateTime)StartDateRadDatePicker.SelectedDate,
                    ((DateTime)EndDateRadDatePicker.SelectedDate).AddDays(1),
                    int.Parse(PromotionDDL.SelectedValue));
                Response.Write("Total points Redeemed: " + totalPointsRedeemed + "<br/>");
            }
            int claimTotal;
            string redemptions = WriteRedemption(vw, (DateTime)StartDateRadDatePicker.SelectedDate,
                ((DateTime)EndDateRadDatePicker.SelectedDate).AddDays(1),
                int.Parse(PromotionDDL.SelectedValue), out claimTotal);
            Response.Write("Total number of Claims: " + claimTotal + "<br/><br/>");

            Response.Write("<br/>Rewards<br/>");
            Response.Write(WriteRewards(vw, (DateTime)StartDateRadDatePicker.SelectedDate,
               ((DateTime)EndDateRadDatePicker.SelectedDate).AddDays(1),
                int.Parse(PromotionDDL.SelectedValue)));

            if (pt == PromotionType.BY_PRODUCT)
            {
                Response.Write("<br/>Products<br/>");
                Response.Write(WriteProducts(vw, (DateTime)StartDateRadDatePicker.SelectedDate,
                    ((DateTime)EndDateRadDatePicker.SelectedDate).AddDays(1),
                    int.Parse(PromotionDDL.SelectedValue)));
            }

           


            Response.Write("<br/>Redemptions<br/>");
            Response.Write(redemptions);

          

          //  Response.Write("<br/>Out Stock<br/>");
          //  Response.Write(WriteOutStock(vw));


           // Response.Write("<br/>Return Stock<br/>");
          //  Response.Write(WriteReturnStock(vw));

            vw.Close();
            Response.End();

        }
        private static string WriteProducts(System.IO.StreamWriter vw, DateTime fromDate, DateTime toDate, int promotionid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            //var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(
            //       (DateTime)StartDateRadDatePicker.SelectedDate, (DateTime)EndDateRadDatePicker.SelectedDate);
            //RadGrid1.DataSource = x;
            //DateTime fromDate = new DateTime(2013, 1, 29);
            //DateTime toDate = new DateTime(2013, 12, 29);
            var x = ClientManager.getAllViewRedemptionRewardProductSummaryByPromotionPeriod(fromDate, toDate,
                    promotionid);

            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);

            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }
        private static string WriteRewards(System.IO.StreamWriter vw, DateTime fromDate, DateTime toDate, int promotionid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            //var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(
            //       (DateTime)StartDateRadDatePicker.SelectedDate, (DateTime)EndDateRadDatePicker.SelectedDate);
            //RadGrid1.DataSource = x;
            //DateTime fromDate = new DateTime(2013, 1, 29);
            //DateTime toDate = new DateTime(2013, 12, 29);
            var x = ClientManager.getAllViewRedemptionRewardRewardsSummaryByPromotionPeriod(fromDate, toDate,
                    promotionid);

            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();
          
            DataGrd.RenderControl(htmlWrite);

            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }
        private static string WriteRedemption(System.IO.StreamWriter vw, DateTime fromDate, DateTime toDate,int promotionid,out int count)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            //var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(
            //       (DateTime)StartDateRadDatePicker.SelectedDate, (DateTime)EndDateRadDatePicker.SelectedDate);
            //RadGrid1.DataSource = x;
            //DateTime fromDate = new DateTime(2013, 1, 29);
            //DateTime toDate = new DateTime(2013, 12, 29);
            var x = ClientManager.getAllRedemptionRewardsByPromotionPeriod(fromDate, toDate,
                    promotionid);
         
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();
            count = x.Count;

            DataGrd.RenderControl(htmlWrite);

            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();         
            return stringWriter.ToString();
        }
        /*
        private static string WriteInStock(System.IO.StreamWriter vw)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockReceive();
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();      
            return stringWriter.ToString();
        }

        private static string WriteOutStock(System.IO.StreamWriter vw)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockOut();
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }
        private static string WriteReturnStock(System.IO.StreamWriter vw)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockReturn();
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }
         * */
        
    }
}