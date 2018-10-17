<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StockOut.aspx.cs" Inherits="RedemptionAdmin.Admin.StockOut" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="row">
            <asp:LinkButton ID="ClientBut" runat="server" OnClick="ClientBut_Click"></asp:LinkButton>
            >
            <asp:LinkButton ID="RewardBut" runat="server" OnClick="RewardBut_Click"></asp:LinkButton>
        </div>
        <div class="row">
            <h1>
                Manage Stock
            </h1>
        </div>
        <asp:Button ID="ShowCreateStockReceiveBut" runat="server" Text="New out stock"
            OnClick="ShowCreateStockReceiveBut_Click" />
        <asp:Panel ID="ClientDetailPnl" runat="server">
            <div class="row">
                <div class="left box">
                    <h3>
                        Out Stock</h3>
                </div>
                <div class="right box">
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Reward
                </div>
                <div class="right box">
                    <asp:Literal ID="RewardLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Recipient
                </div>
                <div class="right box">
                    <asp:DropDownList ID="CompanyDDL" runat="server" ValidationGroup="form" Visible="false">
                    </asp:DropDownList >
                     <asp:TextBox ID="CompanyTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="CompanyTB" ID="RequiredFieldValidator3"
                        runat="server" ErrorMessage="Please enter the recipient." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Out Qty
                </div>
                <div class="right box">
                    <asp:Literal ID="QtyLit" runat="server"></asp:Literal>
                      <telerik:RadNumericTextBox ID="QtyTB" runat="server" ValidationGroup="form" MaxLength="8"
                        DataType="System.Int32" MinValue="1">
                        <NumberFormat AllowRounding="true" DecimalDigits="0" />
                    </telerik:RadNumericTextBox><asp:RequiredFieldValidator
                        ControlToValidate="QtyTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the in qty."
                        CssClass="failureNotification" ValidationGroup="form" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ControlToValidate="QtyTB" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Must be a number."
                            ValidationGroup="form" CssClass="failureNotification" Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Reference No
                </div>
                <div class="right box">
                    <asp:TextBox ID="InvoiveTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="InvoiveTB" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the reference no."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Remarks
                </div>
                <div class="right box">
                    <asp:TextBox ID="RemarksTB" runat="server" ValidationGroup="form" TextMode="MultiLine"
                        Rows="5" Height="80px" Width="400" MaxLength="400"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                  <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="CreateStockReceiveBut" runat="server" Text="Create out stock"
                        OnClick="CreateStockReceiveBut_Click" ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
        
                </div>
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="RewardLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="RewardLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="stockoutid">
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
                    <telerik:GridBoundColumn HeaderText="Stock Out ID" DataField="stockoutid" />
                    <telerik:GridBoundColumn HeaderText="reward " DataField="rewardname" />
                    <telerik:GridBoundColumn HeaderText="company " DataField="companyname" />
                    <telerik:GridBoundColumn HeaderText="Qty" DataField="qty" />
                    <telerik:GridBoundColumn HeaderText="balance" DataField="balance" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="reference no" DataField="invoice" />
                    <telerik:GridBoundColumn HeaderText="Remarks " DataField="remarks" />
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
