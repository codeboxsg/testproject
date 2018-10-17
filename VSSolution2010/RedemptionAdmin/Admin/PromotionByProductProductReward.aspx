<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PromotionByProductProductReward.aspx.cs" Inherits="RedemptionAdmin.Admin.PromotionByProductProductReward" %>

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
                Associate Product and Reward
            </h1>
        </div>
        <br />
        Select the product and the reward to link to the promotion.<br />
        <br />
        <asp:Button ID="AddRewardProductBut" runat="server" Text="Add Reward Product" OnClick="AddRewardProductBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Product and Reward Details</h3>
            </div>
            <div class="row">
                <div class="left box">
                    Product
                </div>
                <div class="right box">
                    <asp:DropDownList ID="ProductDDL" runat="server" ValidationGroup="form">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="ProductDDL" ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="Please select a product." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Reward
                </div>
                <div class="right box">
                    <asp:DropDownList ID="RewardDDL" runat="server" ValidationGroup="form">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="RewardDDL" ID="RequiredFieldValidator6"
                        runat="server" ErrorMessage="Please select a reward." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Literal ID="promotionDetailErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <asp:Button ID="InsertRewardProductBut" runat="server" Text="Insert Reward Product"
                OnClick="InsertRewardProductBut_Click" />
            <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                OnClick="CancelBut_Click" />
        </asp:Panel>
        <br />
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
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="productid,rewardid">
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
                    <telerik:GridTemplateColumn HeaderText="Link" AllowFiltering="False" HeaderStyle-Width="50"
                        UniqueName="rewardid">
                        <ItemTemplate>
                            <asp:LinkButton CommandName="Delete2" Text="Remove" ID="RemoveBut" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Product ID" DataField="productid" />
                    <telerik:GridBoundColumn HeaderText="Product Name" DataField="productname" />
                    <telerik:GridBoundColumn HeaderText="Reward ID" DataField="rewardid" />
                    <telerik:GridBoundColumn HeaderText="Reward Name" DataField="rewardname" />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
