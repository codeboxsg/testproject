<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Receipt.aspx.cs" Inherits="RedemptionAdmin.Admin.Receipt" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Process Claim Points
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
                <asp:Literal ID="ReceiptIdLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Client
            </div>
            <div class="right box">
                <asp:Literal ID="ClientNameLbl" runat="server"></asp:Literal>
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
                <telerik:RadComboBox ID="ResellerDDL2" runat="server" OnItemDataBound="ResellerDDL2_ItemDataBound"
                    ValidationGroup="form">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="ResellerDDL2" ID="RequiredFieldValidator3"
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
                Invoice No
            </div>
            <div class="right box">
                <asp:TextBox ID="InvoiceNoTB" runat="server" ValidationGroup="form"></asp:TextBox><asp:RequiredFieldValidator
                    ControlToValidate="InvoiceNoTB" Display="Dynamic" ID="RequiredFieldValidator1"
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
                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the purchase date."
                    ValidationGroup="form"></asp:RequiredFieldValidator>
            </div>
        </div>
        
        
    
           <asp:Panel ID="ProductPnl" Visible="true" runat="server">
        <div class="row">
            <h3>
                Purchased Product Details</h3>
        </div>
        <asp:Panel ID="RedemptionDetailsEditPnl" Visible="false" runat="server">
            <div class="row">
                <div class="left box">
                    Product Model
                </div>
                <div class="right box">
                    <telerik:RadComboBox ID="ProductDDL" runat="server" MarkFirstMatch="true" EnableLoadOnDemand="true"
                        HighlightTemplatedItems="true" OnItemDataBound="ProductDDL_ItemDataBound" ValidationGroup="addproduct">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="ProductDDL" ID="RequiredFieldValidator2"
                        runat="server" InitialValue="-select-" ErrorMessage="Please select a product model."
                        ValidationGroup="addproduct"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Serial No
                </div>
                <div class="right box">
                    <asp:TextBox ID="serialnoTB" runat="server" ValidationGroup="addproduct" MaxLength="35"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="AddItemBut" runat="server" Text="Add Product" OnClick="AddItemBut_Click"
                        ValidationGroup="addproduct" />
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="left box">
            </div>
            <div class="right box">
                <telerik:RadGrid ID="ReceiptItemRadGrid" runat="server" AllowPaging="True" GridLines="None"
                    EnableLinqExpressions="false" OnItemCommand="ReceiptItemRadGrid_ItemCommand"
                    OnItemDataBound="ReceiptItemRadGrid_ItemDataBound" OnNeedDataSource="ReceiptItemRadGrid_NeedDataSource"
                    AllowSorting="True" AutoGenerateColumns="False">
                    <MasterTableView DataKeyNames="redemptionbypointreceiptitemid,redemptionbypointreceiptid">
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="redemptionbypointreceiptid" DataType="System.Int32"
                                FilterControlAltText="Filter redemptionbypointreceiptid column" HeaderText="Receipt ID(Claim Points)"
                                ReadOnly="True" SortExpression="redemptionbypointreceiptid" UniqueName="redemptionbypointreceiptid"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="productmodel" FilterControlAltText="Filter productmodel column"
                                HeaderText="Model" SortExpression="productmodel" UniqueName="productmodel">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="productpoints" FilterControlAltText="Filter productpoints column"
                                HeaderText="Points" SortExpression="productpoints" UniqueName="productpoints">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="serialno" FilterControlAltText="Filter serialno column"
                                HeaderText="Serial no" SortExpression="serialno" UniqueName="serialno">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                                HeaderText="Date" SortExpression="dateentry" UniqueName="dateentry">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="LinkColumn" HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="delete2" Text="Remove" ID="DeleteBut" runat="server">
                                    </asp:LinkButton>
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
        <div class="row">
            <div class="left box">
                Total points
            </div>
            <div class="right box">
                <asp:Literal ID="totalpointsLit" runat="server"></asp:Literal>
            </div>
        </div>
        </asp:Panel>
               <asp:Panel ID="PointsPnl" Visible="true" runat="server">
             <div class="row">
            <h3>
                Points Only</h3>
        </div>
        <div class="row">
                <div class="left box">
                    Custom Points<br />(This will overwrite the total points above.)
                </div>
                <div class="right box">
                    <telerik:RadNumericTextBox ID="CustomPointsTB" runat="server" ValidationGroup="form" MaxLength="8"
                        DataType="System.Int32" MinValue="1">
                        <NumberFormat AllowRounding="true" DecimalDigits="0" />
                    </telerik:RadNumericTextBox>
                 
                </div>
            </div>
        </asp:Panel>
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
                <asp:Button ID="UpdateReceiptBut" runat="server" Text="Assign points and approve receipt"
                    ValidationGroup="form" OnClick="UpdateReceiptBut_Click" />
                <asp:Button ID="DuplicateBut" runat="server" Text="Duplicate" OnClick="DuplicateReceiptBut_Click" />
                <asp:Button ID="RejectBut" runat="server" Text="Reject" OnClick="RejectReceiptBut_Click" />
                <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                    OnClick="CancelBut_Click" />
                <asp:Button ID="VoidBut" runat="server" Text="Void and remove points from member"
                    OnClick="VoidReceiptBut_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Literal ID="EmailSendLit" runat="server"></asp:Literal>
    <telerik:RadGrid ID="ReceiptRadGrid" runat="server" AllowPaging="True" GridLines="None"
        EnableLinqExpressions="false" AllowFilteringByColumn="true" OnItemCommand="ReceiptRadGrid_ItemCommand"
        OnItemDataBound="ReceiptRadGrid_ItemDataBound" OnNeedDataSource="ReceiptRadGrid_NeedDataSource"
        AllowSorting="True" AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="redemptionbypointreceiptid,status,UserId,receiptpath">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn AllowFiltering="true" FilterControlAltText="Filter redemptionbypointreceiptid column"
                    SortExpression="redemptionbypointreceiptid" UniqueName="redemptionbypointreceiptid"
                    DataField="redemptionbypointreceiptid" HeaderText="Receipt ID(Claim Points)">
                    <ItemTemplate>
                        <asp:Literal ID="redemptionbypointreceiptidLit" runat="server"></asp:Literal><br />
                        <asp:LinkButton CommandName="Process" Text="Manage" ID="ProcessBut" runat="server">
                        </asp:LinkButton><br />
                        <asp:LinkButton CommandName="SendApprovalEmail" Text="Send Approval Email" ID="SendApprovalEmailBut"
                            runat="server">
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
                <telerik:GridBoundColumn DataField="invoiceno" FilterControlAltText="Filter invoiceno column"
                    HeaderText="Invoice no" SortExpression="invoiceno" UniqueName="invoiceno">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="purchasedate" FilterControlAltText="Filter purchasedate column"
                    HeaderText="Purchase Date" SortExpression="purchasedate" UniqueName="purchasedate"
                    DataFormatString="{0:dd/MM/yyyy}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                    HeaderText="Status" SortExpression="status" UniqueName="status">
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
