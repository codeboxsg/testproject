<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Status.aspx.cs" Inherits="Redemption.Status" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="main" role="main">
        <div class="container products">
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Member's Area</h4>
                </div>
            </div>
            <div class="sixteen columns">
                <div id="tabs">
                    <ul class="nav">
                        <li class="nav-one"><a href="claimpoints.aspx">CLAIM POINTS</a></li>
                        <li class="nav-two"><a href="#" class="current">REWARDS &amp; POINTS</a></li>
                        <li class="nav-four last"><a href="updateparticulars.aspx">UPDATE PARTICULARS</a></li>
                    </ul>
                    <div class="list-wrap">
                        <div id="tabs1">
                            <!--Reward Summary Start-->
                            <div class="title ">
                                <h5>
                                    Reward Summary</h5>
                            </div>
                            <telerik:RadGrid ID="RewardRadGrid" runat="server" AllowPaging="True" GridLines="None"
                                OnItemCommand="RewardRadGrid_ItemCommand" OnItemDataBound="RewardRadGrid_ItemDataBound"
                                OnNeedDataSource="RewardRadGrid_NeedDataSource" AllowSorting="True" AutoGenerateColumns="False">
                                <MasterTableView DataKeyNames="redemptionrewardid,status,modeofcollection,rewardpoints,type,productname">
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
                                            HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry" DataFormatString="{0:dd/MM/yyyy}">
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
                                        <telerik:GridBoundColumn DataField="remarks" FilterControlAltText="Filter remarks column"
                                            HeaderText="Remarks" SortExpression="remarks" UniqueName="remarks" Visible="true">
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
                            <!--Reward Summary Start-->
                            <div class="title ">
                                <h5>
                                    Point History</h5>
                                (Current Balance
                                <asp:Literal ID="CurrentPointsLit" runat="server"></asp:Literal>
                                points)
                            </div>
                            <telerik:RadGrid ID="PointRadGrid" runat="server" AllowPaging="True" GridLines="None"
                                OnItemCommand="PointRadGrid_ItemCommand" OnItemDataBound="PointRadGrid_ItemDataBound"
                                OnNeedDataSource="PointRadGrid_NeedDataSource" AllowSorting="True" AutoGenerateColumns="False">
                                <MasterTableView DataKeyNames="redemptionbypointtransactionid">
                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="redemptionbypointtransactionid" DataType="System.Int32"
                                            FilterControlAltText="Filter redemptionbypointtransactionid column" HeaderText="Transaction ID"
                                            ReadOnly="True" SortExpression="redemptionbypointtransactionid" UniqueName="redemptionbypointtransactionid"
                                            Visible="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="points" DataType="System.Int32" FilterControlAltText="Filter points column"
                                            HeaderText="Points" ReadOnly="True" SortExpression="points" UniqueName="points"
                                            Visible="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="balance" DataType="System.Int32" FilterControlAltText="Filter balance column"
                                            HeaderText="Balance" ReadOnly="True" SortExpression="balance" UniqueName="balance"
                                            Visible="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="dateentry"  FilterControlAltText="Filter dateentry column"
                                            HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="notes" FilterControlAltText="Filter notes column"
                                            HeaderText="Details" SortExpression="notes" UniqueName="notes" Visible="true">
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
                            <!--Claim Points Start-->
                            <div class="title ">
                                <h5>
                                    Claim Points</h5>
                            </div>
                            <telerik:RadGrid ID="ReceiptRadGrid" runat="server" AllowPaging="True" GridLines="None"
                                OnItemCommand="ReceiptRadGrid_ItemCommand" OnItemDataBound="ReceiptRadGrid_ItemDataBound"
                                OnNeedDataSource="ReceiptRadGrid_NeedDataSource" AllowSorting="True" AutoGenerateColumns="False">
                                <MasterTableView DataKeyNames="redemptionbypointreceiptid,status,totalpoints">
                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="redemptionbypointreceiptid" DataType="System.Int32"
                                            FilterControlAltText="Filter redemptionbypointreceiptid column" HeaderText="Receipt ID"
                                            ReadOnly="True" SortExpression="redemptionbypointreceiptid" UniqueName="redemptionbypointreceiptid"
                                            Visible="true">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Uploaded Receipts" DataField="Value" AllowFiltering="False"
                                            AutoPostBackOnFilter="True" UniqueName="Value">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="ReceiptHL" runat="server" Target="_self" class="link">View</asp:HyperLink>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="receiptpath" FilterControlAltText="Filter receiptpath column"
                                            HeaderText="Receipt2" SortExpression="receiptpath" UniqueName="receiptpath" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                                            HeaderText="Status" SortExpression="status" UniqueName="status">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                                            HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Points Awarded" DataField="Value" AllowFiltering="False"
                                            AutoPostBackOnFilter="True" UniqueName="Value">
                                            <ItemTemplate>
                                                <asp:Label ID="NoteLbl" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
