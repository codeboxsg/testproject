<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddUser.aspx.cs" Inherits="RedemptionAdmin.AddUser" %>
    
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="pageTitle mb0">
        <h2>
            Add New User</h2>
        <p>
            Use the form below to create a new account.</p>
    </div>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="VG" />
    <table>
        <tr>
            <td>
                <div class="accountInfo">
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="failureNotification" ErrorMessage="Enter a username" ToolTip="Enter a username"
                            ValidationGroup="VG">*</asp:RequiredFieldValidator><asp:CustomValidator ID="UserNameCV"
                                runat="server" ErrorMessage="Username exist. Please select a different username"
                                ValidationGroup="VG" CssClass="failureNotification" ToolTip="Username exist. Please select a different username"
                                OnServerValidate="UserNameCV_ServerValidate">*</asp:CustomValidator>
                    </p>
                    <p>
                        <asp:Label ID="EmailLbl" runat="server" AssociatedControlID="EmailTB">Email:</asp:Label>
                        <asp:TextBox ID="EmailTB" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRFV" runat="server" ControlToValidate="EmailTB"
                            CssClass="failureNotification" ErrorMessage="Enter a email" ToolTip="Enter a email"
                            ValidationGroup="VG">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailREV" runat="server" ControlToValidate="EmailTB"
                            ValidationGroup="VG" Display="Dynamic" ErrorMessage="e.g. someone@hotmail.com"
                            ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,3}$">
                        </asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label Visible="true" ID="RoleLbl" runat="server">Role:</asp:Label>
                        <telerik:radcombobox id="RoleDDL" runat="server" viewstatemode="Enabled" autopostback="True">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Admin" Value="Admin" />
                                <telerik:RadComboBoxItem runat="server" Text="Staff" Value="Staff" />
                            </Items>
                        </telerik:radcombobox>
                        <asp:RequiredFieldValidator ID="MobileRFV" runat="server" ControlToValidate="RoleDDL"
                            CssClass="failureNotification" ErrorMessage="Select the role." ToolTip="Select the role."
                            ValidationGroup="VG">*</asp:RequiredFieldValidator>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="CreateBut" runat="server" CommandName="Create" Text="Create" ValidationGroup="VG"
                            OnClick="CreateBut_Click" />
                        <span class="or">or</span>
                        <asp:HyperLink ID="CancelHL" class="linkRed" runat="server" NavigateUrl="~/admin/UserList.aspx">Cancel</asp:HyperLink>
                    </p>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
