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
    public partial class ReportStockSummary : System.Web.UI.Page
    {
        //https://github.com/telerik/aspnet-sdk/blob/master/Grid/ThreeRadGridsExport/ThreeRadGridsExport.aspx.cs
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var y = ClientManager.getAllClients();
                ClientDDL.DataTextField = "name";
                ClientDDL.DataValueField = "clientid";
                ClientDDL.DataSource = y;
                ClientDDL.DataBind();

                int promotionid = int.Parse(ClientDDL.SelectedValue);
                var x = ClientManager.getStockSummaryByClient(promotionid);
                RadGrid1.DataSource = x;
                RadGrid1.DataBind();
            }
        }

        protected void ClientDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int promotionid = int.Parse(ClientDDL.SelectedValue);
            var x = ClientManager.getStockSummaryByClient(promotionid);
            RadGrid1.DataSource = x;
            RadGrid1.DataBind();
        }
        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //var x = ClientManager.getStockSummary();
            //RadGrid1.DataSource = x;
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



        protected void Button1_Click(object sender, EventArgs e)
        {
            int clientid = int.Parse(ClientDDL.SelectedValue);
            String filename = "StockSummaryReport_" + ClientDDL.SelectedItem.Text +"_"+ DateTime.Today.ToString("dd/MM/yyyy")+ ".xls";

            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/vnd.ms-excel";

            string apath =  MapPath("~/temp.s");
            System.IO.StreamWriter vw = new System.IO.StreamWriter(apath, true);

            Response.Write("<br/>" + filename + "<br/>");
            Response.Write(WriteStockSummary(vw, clientid));

            Response.Write("<br/>In Stock<br/>");
            Response.Write(WriteInStock(vw, clientid));

            Response.Write("<br/>Out Stock<br/>");
            Response.Write(WriteOutStock(vw, clientid));


            Response.Write("<br/>Return Stock<br/>");
            Response.Write(WriteReturnStock(vw, clientid));

            vw.Close();
            Response.End();

        }

        private static string WriteStockSummary(System.IO.StreamWriter vw, int clientid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);


            var x = ClientManager.getStockSummaryByClient(clientid);
           // var x = ClientManager.getStockSummary();
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();         
            return stringWriter.ToString();
        }

        private static string WriteInStock(System.IO.StreamWriter vw, int clientid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockReceiveByClientid(clientid);
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();      
            return stringWriter.ToString();
        }

        private static string WriteOutStock(System.IO.StreamWriter vw, int clientid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockOutByClientid(clientid);
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }
        private static string WriteReturnStock(System.IO.StreamWriter vw, int clientid)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            var x = ClientManager.getStockReturnByClientid(clientid);
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = x;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            return stringWriter.ToString();
        }

     
        
    }
}