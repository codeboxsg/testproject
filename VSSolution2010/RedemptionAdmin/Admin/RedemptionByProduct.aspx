<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RedemptionByProduct.aspx.cs" Inherits="RedemptionAdmin.Admin.RedemptionByProduct" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Process Redemption by Products
        </h1>
    </div>
    <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
        <div class="row">
            <h3>
                Receipt Details</h3>
        </div>
        <div class="row">
            <div class="left box">
                Receipt ID
            </div>
            <div class="right box">
                <asp:Literal ID="ReceiptidLit" runat="server"></asp:Literal>
            </div>
            <div class="row">
                <div class="left box">
                    Client
                </div>
                <div class="right box">
                    <asp:Literal ID="ClientNameLit" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Promotion
            </div>
            <div class="right box">
                <asp:Literal ID="PromotionLit" runat="server"></asp:Literal>
                <telerik:RadComboBox ID="PromotionDDL" runat="server" Enabled="false">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Userid
            </div>
            <div class="right box">
                <asp:Literal ID="UseridLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Reseller
            </div>
            <div class="right box">
                <telerik:RadComboBox ID="ResellerDDL2" runat="server" ValidationGroup="form">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="ResellerDDL2" ID="RequiredFieldValidator2"
                    runat="server" InitialValue="-select-" ErrorMessage="Please select a reseller."
                    ValidationGroup="form"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Receipt
            </div>
            <div class="right box">
                <asp:HyperLink ID="ReceiptHL" Target="_blank" runat="server">View</asp:HyperLink>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Status
            </div>
            <div class="right box">
                <telerik:RadComboBox ID="StatusDDL" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Pending Process" Value="0" />
                        <telerik:RadComboBoxItem runat="server" Text="Processed" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Duplicate" Value="2" />
                                       <telerik:RadComboBoxItem runat="server" Text="Rejected" Value="3" />     </Items>
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Invoice No
            </div>
            <div class="right box">
                <asp:TextBox ID="InvoiceNoTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="InvoiceNoTB" ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="Please enter the invoice no." ValidationGroup="form"></asp:RequiredFieldValidator><asp:CustomValidator
                        ID="InvoiceNoTBCV" ControlToValidate="InvoiceNoTB" runat="server" ErrorMessage=""
                        OnServerValidate="InvoiceNoTBCV_ServerValidate" ValidationGroup="form"></asp:CustomValidator>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Purchase Date
            </div>
            <div class="right box">
                <telerik:RadDatePicker ID="PurchaseDateRadDatePicker" runat="server" ValidationGroup="form">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="PurchaseDateRadDatePicker"
                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the purchase date."
                    ValidationGroup="form"></asp:RequiredFieldValidator>
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
                <asp:Button ID="UpdateReceiptBut" runat="server" Text="Update Receipt" ValidationGroup="form"
                    OnClick="UpdateReceiptBut_Click" />
                  <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                    OnClick="CancelBut_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="RedemptionDetailsPnl" Visible="false" runat="server">
        <div class="row">
            <h3>
                Redemptions Details</h3>
        </div>
        <asp:Panel ID="RedemptionDetailsEditPnl" Visible="false" runat="server">
            <div class="row">
                <div class="left box">
                    Product - Reward
                </div>
                <div class="right box">
                    <telerik:RadComboBox runat="server" ID="ProductDDL2" Height="190px" Width="420px"
                        MarkFirstMatch="true" EnableLoadOnDemand="true" HighlightTemplatedItems="true"
                        OnDataBound="ProductDDL2_DataBound" OnItemDataBound="ProductDDL2_ItemDataBound"
                        OnItemsRequested="ProductDDL2_ItemsRequested">
                        <HeaderTemplate>
                            <ul>
                                <li class="col1">Product : Model :ID</li>
                                <li class="col2">Reward : ID</li>
                            </ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <ul>
                                <li class="col1">
                                    <%# DataBinder.Eval(Container.DataItem, "productname")%>
                                    :
                                    <%# DataBinder.Eval(Container.DataItem, "productmodel")%>
                                    :
                                    <%# DataBinder.Eval(Container.DataItem, "productid")%></li>
                                <li class="col2">
                                    <%# DataBinder.Eval(Container.DataItem, "rewardname")%>
                                    :
                                    <%# DataBinder.Eval(Container.DataItem, "rewardid")%></li>
                            </ul>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Serial No
                </div>
                <div class="right box">
                    <asp:TextBox ID="serialnoTB" runat="server" MaxLength="35"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="AddItemBut" runat="server" Text="Add Redemption" OnClick="AddItemBut_Click" />
                    <br />
                    <asp:Literal ID="AddItemErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="left box">
            </div>
            <div class="right box">
                <asp:Literal ID="EmailSendLit" runat="server"></asp:Literal>
                <telerik:RadGrid ID="RedemptionRewardRadGrid" runat="server" AllowPaging="True" GridLines="None"
                    EnableLinqExpressions="false" OnItemCommand="RedemptionRewardRadGrid_ItemCommand"
                    OnItemDataBound="RedemptionRewardRadGrid_ItemDataBound" OnNeedDataSource="RedemptionRewardRadGrid_NeedDataSource"
                    AllowSorting="True" AutoGenerateColumns="False">
                    <MasterTableView DataKeyNames="clientid,redemptionrewardid,status,modeofcollection,rewardpoints,type,productid,serialno,productname,redemptionbyproductreceiptid,UserId">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="redemptionrewardid" DataType="System.Int32" FilterControlAltText="Filter redemptionrewardid column"
                                HeaderText="Redemption ID" ReadOnly="True" SortExpression="redemptionrewardid"
                                UniqueName="redemptionrewardid" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="rewardname" FilterControlAltText="Filter rewardname column"
                                HeaderText="Reward" ReadOnly="true" SortExpression="rewardname" UniqueName="rewardname"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                                HeaderText="Status" ReadOnly="True" SortExpression="status" UniqueName="status"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                                HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Items Purchased" DataField="Value" AllowFiltering="False"
                                AutoPostBackOnFilter="True" UniqueName="Value">
                                <ItemTemplate>
                                    <asp:Label ID="NoteLbl" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="modeofcollection" FilterControlAltText="Filter modeofcollection column"
                                HeaderText="Redemption" SortExpression="modeofcollection" UniqueName="modeofcollection"
                                Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="remarks" FilterControlAltText="Filter remarks column"
                                HeaderText="Remarks" SortExpression="remarks" UniqueName="remarks" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="LinkColumn" HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton Visible="false" CommandName="delete2" Text="Delete" ID="DeleteBut" runat="server">
                                    </asp:LinkButton>
                                    <asp:LinkButton CommandName="SendRedemptionEmail" Text="Send Redemption Email" ID="SendApprovalEmailBut"
                                        runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </div>
    </asp:Panel>
    <telerik:RadGrid ID="ReceiptRadGrid" runat="server" AllowPaging="True" GridLines="None"
        EnableLinqExpressions="false" AllowFilteringByColumn="true" OnItemCommand="ReceiptRadGrid_ItemCommand"
        OnItemDataBound="ReceiptRadGrid_ItemDataBound" OnNeedDataSource="ReceiptRadGrid_NeedDataSource"
        AllowSorting="True" AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="redemptionbyproductreceiptid,status">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn AllowFiltering="true" SortExpression="redemptionbyproductreceiptid"
                    DataField="redemptionbyproductreceiptid" UniqueName="redemptionbyproductreceiptid"
                    FilterControlAltText="Filter redemptionbyproductreceiptid column" HeaderText="Receipt ID(Product)">
                    <ItemTemplate>
                        <asp:Literal ID="redemptionbyproductreceiptidLit" runat="server"></asp:Literal><br />
                        <asp:LinkButton CommandName="Process" Text="Manage" ID="ProcessBut" runat="server">
                        </asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Receipt" DataField="Value" AllowFiltering="False"
                    AutoPostBackOnFilter="True" UniqueName="Value">
                    <ItemTemplate>
                        <asp:HyperLink ID="ReceiptHL" runat="server" Target="_blank" class="link">View</asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="receiptpath" FilterControlAltText="Filter receiptpath column"
                    HeaderText="Receipt2" SortExpression="receiptpath" UniqueName="receiptpath" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="invoiceno" FilterControlAltText="Filter invoiceno column"
                    HeaderText="Invoice no" SortExpression="invoiceno" UniqueName="invoiceno">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="purchasedate" FilterControlAltText="Filter purchasedate column"
                    HeaderText="Purchase Date" SortExpression="purchasedate" UniqueName="purchasedate"
                    DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                    HeaderText="Status" SortExpression="status" UniqueName="status">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="remarks" FilterControlAltText="Filter remarks column"
                    HeaderText="Remarks" SortExpression="remarks" UniqueName="remarks">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                    HeaderText="Date" SortExpression="dateentry" UniqueName="dateentry">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="firstname" FilterControlAltText="Filter firstname column"
                    HeaderText="First Name" SortExpression="firstname" UniqueName="firstname" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="lastname" FilterControlAltText="Filter lastname column"
                    HeaderText="Last Name" SortExpression="lastname" UniqueName="lastname" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NRIC" FilterControlAltText="Filter NRIC column"
                    HeaderText="NRIC" SortExpression="NRIC" UniqueName="NRIC" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="contactno" FilterControlAltText="Filter contactno column"
                    HeaderText="Contact No" SortExpression="contactno" UniqueName="contactno" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="clientname" FilterControlAltText="Filter clientname column"
                    HeaderText="Client" SortExpression="clientname" UniqueName="clientname" Visible="true">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
</asp:Content>
