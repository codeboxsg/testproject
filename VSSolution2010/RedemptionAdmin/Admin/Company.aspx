<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Company.aspx.cs" Inherits="RedemptionAdmin.Admin.Company" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Manage Reseller
        </h1>
    </div>
    <div class="row">
        <asp:Button ID="ShowCreateClientBut" runat="server" Text="New Reseller" OnClick="ShowCreateClientBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Reseller Details</h3>
            </div>
            <div class="row">
                <div class="left box">
                    Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="NameTB" runat="server" ValidationGroup="form" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="NameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Literal ID="clientDetailErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="CreateClientBut" runat="server" Text="Create Reseller" OnClick="CreateClientBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdateClientBut" runat="server" Text="Update Reseller" OnClick="UpdateClientBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="CompanyLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="CompanyLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="resellerid">
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
                    <telerik:GridTemplateColumn AllowFiltering="true" UniqueName="resellerid" HeaderText="Reseller ID"
                        DataField="resellerid" SortExpression="resellerid" FilterControlAltText="Filter resellerid column">
                        <ItemTemplate>
                            <asp:Literal ID="ReselleridLit" runat="server"></asp:Literal><br />
                            <asp:LinkButton CommandName="Edit2" Text="Manage" ID="LinkButton1" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Name" DataField="name" />
                    <telerik:GridBoundColumn HeaderText="Date Modified" DataField="datemodified" DataType="System.DateTime"
                        />
                    <telerik:GridBoundColumn HeaderText="Date Entry" DataField="dateentry" DataType="System.DateTime"
                         />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
