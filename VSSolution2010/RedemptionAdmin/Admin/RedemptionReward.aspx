<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RedemptionReward.aspx.cs" Inherits="RedemptionAdmin.Admin.RedemptionReward" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Process Redemption
        </h1>
    </div>
    <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
        <div class="row">
            <h3>
                Redemption Details</h3>
        </div>
        <div class="row">
            <div class="left box">
                Redemption ID
            </div>
            <div class="right box">
                <asp:Literal ID="RedemptionidLit" runat="server"></asp:Literal>
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
                First Name
            </div>
            <div class="right box">
                <asp:Literal ID="FirstNameLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Last Name
            </div>
            <div class="right box">
                <asp:Literal ID="LastNameLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                NRIC
            </div>
            <div class="right box">
                <asp:Literal ID="NRICLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Contact No
            </div>
            <div class="right box">
                <asp:Literal ID="ContactNoLit" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Redemption
            </div>
            <div class="right box">
                <telerik:RadComboBox ID="CollectionModeRBL" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="Self Collect" Value="0" />
                        <telerik:RadComboBoxItem runat="server" Text="Delivery" Value="1" />
                    </Items>
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="row">
            <div class="left box">
                Status
            </div>
            <div class="right box">
                <telerik:RadComboBox ID="StatusDDL" runat="server">
                    <Items>
                        <%--  <telerik:RadComboBoxItem runat="server" Text="Pending Process" Value="0" />--%>
                        <telerik:RadComboBoxItem runat="server" Text="Arranging Delivery" Value="5" />
                        <telerik:RadComboBoxItem runat="server" Text="Pending Delivery" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="Delivered" Value="3" />
                        <telerik:RadComboBoxItem runat="server" Text="Pending Collection" Value="2" />
                        <telerik:RadComboBoxItem runat="server" Text="Collected" Value="4" />
                    </Items>
                </telerik:RadComboBox>
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
                <asp:Button ID="UpdateRedemptionBut" runat="server" Text="Update Redemption" ValidationGroup="form"
                    OnClick="UpdateRedemptionBut_Click" />
                     <asp:Button ID="DeleteBut" runat="server" Text="Delete and return stock." OnClick="DeleteBut_Click" />
                
            </div>
        </div>
    </asp:Panel>
    <asp:Literal ID="EmailSendLit" runat="server"></asp:Literal>
    <telerik:RadGrid ID="RedemptionRewardRadGrid" runat="server" AllowFilteringByColumn="True"
        AllowPaging="True" GridLines="None" OnItemCommand="RedemptionRewardRadGrid_ItemCommand" EnableLinqExpressions="false"
        OnItemDataBound="RedemptionRewardRadGrid_ItemDataBound" OnNeedDataSource="RedemptionRewardRadGrid_NeedDataSource"
        AllowSorting="True" AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="clientid,redemptionrewardid,status,modeofcollection,rewardpoints,type,productid,serialno,productname,redemptionbyproductreceiptid,UserId,rewardname">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
             <telerik:GridTemplateColumn AllowFiltering="true" UniqueName="redemptionrewardid" FilterControlAltText="Filter redemptionrewardid column"
                    HeaderText="Redemption ID" ReadOnly="True" SortExpression="redemptionrewardid"  DataField="redemptionrewardid" >
                    <ItemTemplate> 
                    <asp:Literal ID="redemptionrewardidLit" runat="server"></asp:Literal><br />
                        <asp:LinkButton CommandName="process" Text="Manage" ID="LinkButton1" runat="server">
                        </asp:LinkButton><br />
                        <asp:LinkButton CommandName="SendRedemptionEmail" Text="Send Redemption Email" ID="SendApprovalEmailBut"
                            runat="server"></asp:LinkButton>
                            <asp:HyperLink ID="PrintFriendlyHL" Target="_blank" runat="server">Print Friendly</asp:HyperLink>
  
                            
                    </ItemTemplate>
                </telerik:GridTemplateColumn>         
                <telerik:GridBoundColumn DataField="redemptionrewardid" DataType="System.Int32" FilterControlAltText="Filter redemptionrewardid column"
                    HeaderText="Redemption ID" ReadOnly="True" SortExpression="redemptionrewardid"
                    UniqueName="redemptionrewardidx" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="promotionid" FilterControlAltText="Filter promotionid column"
                    HeaderText="promotionid" ReadOnly="true" SortExpression="promotionid" UniqueName="promotionid"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="promotionname" FilterControlAltText="Filter promotionname column"
                    HeaderText="Promotion" ReadOnly="true" SortExpression="promotionname" UniqueName="promotionname"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="rewardname" FilterControlAltText="Filter rewardname column"
                    HeaderText="Reward" ReadOnly="true" SortExpression="rewardname" UniqueName="rewardname"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="productid" FilterControlAltText="Filter productid column"
                    HeaderText="productid" ReadOnly="true" SortExpression="productid" UniqueName="productid"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="productname" FilterControlAltText="Filter productname column"
                    HeaderText="Product" ReadOnly="true" SortExpression="productname" UniqueName="productname"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                    HeaderText="Status" ReadOnly="True" SortExpression="status" UniqueName="status"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Items Purchased / Points Deducted" DataField="Value"
                    AllowFiltering="False" AutoPostBackOnFilter="True" UniqueName="Value">
                    <ItemTemplate>
                        <asp:Label ID="NoteLbl" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="modeofcollection" FilterControlAltText="Filter modeofcollection column"
                    HeaderText="Redemption" SortExpression="modeofcollection" UniqueName="modeofcollection"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="type" FilterControlAltText="Filter type column"
                    HeaderText="Type" SortExpression="type" UniqueName="type" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="remarks" FilterControlAltText="Filter remarks column"
                    HeaderText="Remarks" SortExpression="remarks" UniqueName="remarks" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                    HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry">
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
