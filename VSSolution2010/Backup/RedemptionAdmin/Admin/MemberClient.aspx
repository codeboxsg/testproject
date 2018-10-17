<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberClient.aspx.cs" Inherits="RedemptionAdmin.Admin.MemberClient" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:LinkButton ID="MembersBut" runat="server" OnClick="MembersBut_Click">Members</asp:LinkButton>
    &nbsp;&gt;
    <asp:Literal ID="UsernameLit" runat="server"></asp:Literal>
    <div class="row">
        <h1>
            Link Member to Client
        </h1>
    </div>
    <div class="row">
        <asp:Literal ID="EmailSendLit" runat="server"></asp:Literal>
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
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="clientid,siterelativepath">
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
                    <telerik:GridTemplateColumn HeaderText="Link" AllowFiltering="False" UniqueName="rewardid">
                        <ItemTemplate>
                            <asp:CheckBox ID="LinkCB" runat="server" AutoPostBack="true" OnCheckedChanged="LinkCB_CheckedChanged" />
                            <br />
                            <asp:LinkButton Visible="true" CommandName="resetpassword" Text="Reset Password"
                                ID="ResetBut" runat="server">         </asp:LinkButton>
                            <br />
                            <asp:LinkButton Visible="true" CommandName="claimpoints" Text="Claim Points" ID="ClaimPointsBut"
                                runat="server">         </asp:LinkButton>
                            <br />
                            <asp:LinkButton Visible="true" CommandName="redeemreward" Text="Redeem Reward" ID="RedeemRewardBut"
                                runat="server">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Client " DataField="name"
                     FilterControlAltText="Filter name column"
                     ReadOnly="true" SortExpression="name" UniqueName="name"  />
                    <telerik:GridBoundColumn HeaderText="Receive Newsletter" DataField="receivenewsletter" 
                    FilterControlAltText="Filter receivenewsletter column" AllowFiltering="false"
                     ReadOnly="true" SortExpression="receivenewsletter" UniqueName="receivenewsletter" />
                    <telerik:GridBoundColumn HeaderText="Points" DataField="pointbalance" AllowFiltering="false"
                     FilterControlAltText="Filter pointbalance column"
                     ReadOnly="true" SortExpression="pointbalance" UniqueName="pointbalance" />
                    <telerik:GridBoundColumn HeaderText="Date Modified" DataField="datemodified" DataType="System.DateTime"
                       FilterControlAltText="Filter datemodified column"
                     ReadOnly="true" SortExpression="datemodified" UniqueName="datemodified" />
                    <telerik:GridBoundColumn HeaderText="Date Entry" DataField="dateentry" DataType="System.DateTime"
                       FilterControlAltText="Filter dateentry column"
                     ReadOnly="true" SortExpression="dateentry" UniqueName="dateentry" />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
