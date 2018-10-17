<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Member.aspx.cs" Inherits="RedemptionAdmin.Admin.Member" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Member
        </h1>
    </div>
    <asp:Button Text="New Member" ID="NewMemberBut" runat="server" OnClick="NewMemberBut_Click">
    </asp:Button>
    <asp:Literal ID="EmailSendLit" runat="server"></asp:Literal>
    <telerik:RadGrid ID="RedemptionMemberRadGrid" runat="server" AllowFilteringByColumn="True" EnableLinqExpressions="false"
        AllowPaging="True" GridLines="None" OnItemCommand="RedemptionMemberRadGrid_ItemCommand"
    ExportSettings-FileName="Members" ExportSettings-IgnorePaging="true"     OnItemDataBound="RedemptionMemberRadGrid_ItemDataBound" OnNeedDataSource="RedemptionMemberRadGrid_NeedDataSource"
        AllowSorting="True" AutoGenerateColumns="False">
        <MasterTableView  DataKeyNames="UserId,gender" CommandItemDisplay="TopAndBottom" >
            <CommandItemSettings ShowExportToCsvButton="true" ShowAddNewRecordButton="false">
                </CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="LinkColumn" HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="manage" Text="Edit" ID="LinkButton1" runat="server">
                        </asp:LinkButton><br />
                        <asp:LinkButton CommandName="linkclient" Text="Client" ID="LinkButton4" runat="server">
                        </asp:LinkButton>
                        <asp:LinkButton CommandName="enable" Text="Enable/disable" ID="enableLB" runat="server">
                        </asp:LinkButton>
                        <asp:LinkButton CommandName="unlock" Text="Unlock" ID="unlockLB" runat="server">
                        </asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="UserName"  FilterControlAltText="Filter UserName column"
                    HeaderText="Email (Username)" SortExpression="UserName" UniqueName="UserName"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserId" DataType="System.Int32" FilterControlAltText="Filter UserId column"
                    HeaderText="UserId ID" ReadOnly="True" SortExpression="UserId" UniqueName="UserId"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="firstname" FilterControlAltText="Filter firstname column"
                    HeaderText="First Name" ReadOnly="true" SortExpression="firstname" UniqueName="firstname"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="lastname" FilterControlAltText="Filter lastname column"
                    HeaderText="Last Name" ReadOnly="true" SortExpression="lastname" UniqueName="lastname"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="contactno" FilterControlAltText="Filter contactno column"
                    HeaderText="Contact No" ReadOnly="true" SortExpression="contactno" UniqueName="contactno"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NRIC" FilterControlAltText="Filter NRIC column"
                    HeaderText="NRIC" ReadOnly="true" SortExpression="NRIC" UniqueName="NRIC" Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="gender" FilterControlAltText="Filter gender column"
                    HeaderText="Gender" ReadOnly="true" SortExpression="gender" UniqueName="gender"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dateofbirth" DataType="System.DateTime" FilterControlAltText="Filter dateofbirth column"
                    HeaderText="DOB" SortExpression="dateofbirth" UniqueName="dateofbirth">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="mailingaddress" FilterControlAltText="Filter mailingaddress column"
                    HeaderText="Address" ReadOnly="True" SortExpression="mailingaddress" UniqueName="mailingaddress"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="postalcode" FilterControlAltText="Filter postalcode column"
                    HeaderText="Postcode" ReadOnly="True" SortExpression="postalcode" UniqueName="postalcode"
                    Visible="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="datemodified" DataType="System.DateTime" FilterControlAltText="Filter datemodified column"
                    HeaderText="Entry Date" SortExpression="datemodified" UniqueName="datemodified"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dateentry" DataType="System.DateTime" FilterControlAltText="Filter dateentry column"
                    HeaderText="Entry Date" SortExpression="dateentry" UniqueName="dateentry">
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
