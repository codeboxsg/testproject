<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportRedemption.aspx.cs" Inherits="RedemptionAdmin.Admin.ReportRedemption" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="row">
            <h1>
              Redemption Report
            </h1>
        </div>       
         <div class="row">
            <div class="left box">
              Start Date
            </div>
            <div class="right box">
                <telerik:RadDatePicker ID="StartDateRadDatePicker" runat="server">
                </telerik:RadDatePicker>
            </div>
        </div>
                 <div class="row">
            <div class="left box">
              End Date
            </div>
            <div class="right box">
                <telerik:RadDatePicker ID="EndDateRadDatePicker" runat="server">
                </telerik:RadDatePicker>
            </div>
        </div>
                   <div class="row">
            <div class="left box">
              Promotion
            </div>
            <div class="right box">
                   <telerik:RadComboBox ID="PromotionDDL" runat="server" 
                 ViewStateMode="Enabled"   OnItemDataBound="PromotionDDL_ItemDataBound" AutoPostBack="true">
                </telerik:RadComboBox>
            </div>
        </div>
         <asp:Button ID="Button1" runat="server" Text="Export" 
            onclick="Button1_Click" />
        <telerik:RadGrid ID="RadGrid1" Visible="false" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="False" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="StockSummaryReport" ExportSettings-IgnorePaging="true"
            CellSpacing="0" GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="StockSummaryReport" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="rewardid">
                <CommandItemSettings ShowExportToCsvButton="true" ShowAddNewRecordButton="false">
                </CommandItemSettings>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
                <HeaderStyle Font-Bold="true" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Reward ID" DataField="redemptionrewardid" />
                    <telerik:GridBoundColumn HeaderText="Reward Name" DataField="rewardname" />
                 
                    <telerik:GridBoundColumn HeaderText="Client Id" DataField="clientid" />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>

</asp:Content>
