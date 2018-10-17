<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Audit.aspx.cs" Inherits="M1BODIpadServer.SuperAdmin.Audit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="pageTitle">
        <h2>
            Audit Log</h2>
      
    </div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" GridLines="None"
       AllowFilteringByColumn="true"    
	   ExportSettings-FileName="Audit" ExportSettings-IgnorePaging="true"
        AllowSorting="True" AutoGenerateColumns="False" 
         onneeddatasource="RadGrid1_NeedDataSource">
        <MasterTableView  DataKeyNames="id" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings  ShowExportToCsvButton="true" ShowAddNewRecordButton="false"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="id" DataType="System.Int32" FilterControlAltText="Filter id column"
                    HeaderText="id" ReadOnly="True" SortExpression="id" UniqueName="id" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Date" FilterControlAltText="Filter Date column" DataType="System.DateTime"
                    HeaderText="Date" SortExpression="Date" UniqueName="Date" AllowFiltering="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Message"  FilterControlAltText="Filter Message column"
                    HeaderText="Message" SortExpression="Message" UniqueName="Message" >
                </telerik:GridBoundColumn>
             
            </Columns>
         
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="SELECT top 1000 [id] ,[Date],[Message] FROM [auditlog] where level='info' order by id desc"></asp:SqlDataSource>
    
</asp:Content>
