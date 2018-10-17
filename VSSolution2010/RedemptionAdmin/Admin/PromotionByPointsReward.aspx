<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PromotionByPointsReward.aspx.cs" Inherits="RedemptionAdmin.Admin.PromotionByPointsReward" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:LinkButton ID="PromotionBut" runat="server" OnClick="PromotionBut_Click"></asp:LinkButton><br />
        <div class="row">
            <h1>
                Associate Rewards
            </h1>
        </div>
        <br />
        Select the rewards to link to the promotion.<br />
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="ClientLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="ClientLists" IgnorePaging="True">
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
                    <telerik:GridTemplateColumn HeaderText="Link" AllowFiltering="False" HeaderStyle-Width="45"
                        UniqueName="rewardid">
                        <ItemTemplate>
                            <asp:CheckBox ID="AllowCB" runat="server" AutoPostBack="true" OnCheckedChanged="AllowCB_CheckedChanged" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Reward ID" DataField="rewardid" />
                    <telerik:GridBoundColumn HeaderText="Name" DataField="name" />
                            <telerik:GridBoundColumn HeaderText="Points" DataField="points" />
                    <telerik:GridBoundColumn HeaderText="Description" DataField="description" Visible="false" />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
