<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportStockSummary.aspx.cs" Inherits="RedemptionAdmin.Admin.ReportStockSummary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="row">
            <h1>
                Stock Summary Report
            </h1>
        </div>
        <div class="row">
            <div class="left box">
                Client
            </div>
            <div class="right box">
                <asp:DropDownList ID="ClientDDL" runat="server" ValidationGroup="form" AutoPostBack="true"
                    onselectedindexchanged="ClientDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="left box">
            </div>
            <div class="right box">
                <asp:Button ID="Button1" runat="server" Text="Export" OnClick="Button1_Click" />
            </div>
        </div>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
         Visible="false"    AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="False" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="MemberList" ExportSettings-IgnorePaging="true"
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
                    <telerik:GridBoundColumn HeaderText="Reward ID" DataField="rewardid" />
                    <telerik:GridBoundColumn HeaderText="Reward Name" DataField="name" />
                    <telerik:GridBoundColumn HeaderText="AvailableBalanceFromReward" DataField="AvailableBalanceFromReward" />
                    <telerik:GridBoundColumn HeaderText="AvailableBalanceCalculated" DataField="AvailableBalanceCalculated" />
                    <telerik:GridBoundColumn HeaderText="Total In" DataField="TotalIn" />
                    <telerik:GridBoundColumn HeaderText="Total Out" DataField="TotalOut" />
                    <telerik:GridBoundColumn HeaderText="Total Return" DataField="TotalReturn" />
                    <telerik:GridBoundColumn HeaderText="Redemption" DataField="Redemption" />
                    <telerik:GridBoundColumn HeaderText="Redeemed" DataField="Redeemed" />
                    <telerik:GridBoundColumn HeaderText="Outstanding" DataField="Outstanding" />
                    <telerik:GridBoundColumn HeaderText="Physical Balance" DataField="PhysicalBalance" />
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
