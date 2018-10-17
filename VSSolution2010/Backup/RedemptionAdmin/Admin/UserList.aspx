<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserList.aspx.cs" Inherits="RedemptionAdmin.UserList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="pageTitle">
        <h2>
            User Management</h2>
        <asp:HyperLink ID="HyperLink1" class="button" runat="server" NavigateUrl="~/admin/AddUser.aspx">Add New User</asp:HyperLink>
    </div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True"  EnableLinqExpressions="false"
        GridLines="None" OnItemCommand="RadGrid1_ItemCommand" 
        OnItemDataBound="RadGrid1_ItemDataBound" 
        onneeddatasource="RadGrid1_NeedDataSource">
        <MasterTableView AutoGenerateColumns="False"  DataKeyNames="UserId,UserName,LoweredEmail" CommandItemDisplay="TopAndBottom">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="UserId" DataType="System.Guid" Visible="false"
                    FilterControlAltText="Filter UserId column" HeaderText="UserId" SortExpression="UserId"
                    UniqueName="UserId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter UserName column"
                    HeaderText="UserName" SortExpression="UserName" UniqueName="UserName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LoweredEmail" FilterControlAltText="Filter LoweredEmail column"
                    HeaderText="Email" SortExpression="LoweredEmail" UniqueName="LoweredEmail">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RoleName" FilterControlAltText="Filter RoleName column"
                    HeaderText="Role" SortExpression="RoleName" UniqueName="RoleName">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="" DataField="Value" AllowFiltering="False"
                    AutoPostBackOnFilter="True" UniqueName="Value">
                    <ItemTemplate>
                        <asp:LinkButton ID="enableLB" runat="server" CommandName="enable" class="link">Disable</asp:LinkButton>
                        <asp:HyperLink ID="EditHL" runat="server" Target="_self" class="link">Edit</asp:HyperLink>
                        <asp:HyperLink ID="ResetPasswordHL" Visible="false" runat="server" Target="_self" class="link">Reset Password</asp:HyperLink>
                        <asp:HyperLink ID="SetPasswordHL" runat="server" Target="_self" class="link">Set Password </asp:HyperLink>
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
   
    <telerik:RadAjaxManager runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
