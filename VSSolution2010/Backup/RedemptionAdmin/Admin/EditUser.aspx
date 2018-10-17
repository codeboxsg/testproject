<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditUser.aspx.cs" Inherits="RedemptionAdmin.EditUser" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="pageTitle mb0">
        <h2>
            Edit User</h2>
        <p>
            Update details of this user</p>
    </div>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="VG" />
    <table>
        <tr>
            <td>
                <div class="accountInfo">
                    <p class="mb10">
                        <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
                        <asp:Label ID="UserNameLbl" runat="server" class="bold"></asp:Label>
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
                        <telerik:RadComboBox ID="RoleDDL" runat="server" ViewStateMode="Enabled" AutoPostBack="True">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Admin" Value="Admin" />
                                <telerik:RadComboBoxItem runat="server" Text="Staff" Value="Staff" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="MobileRFV" runat="server" ControlToValidate="RoleDDL"
                            CssClass="failureNotification" ErrorMessage="Select the role." ToolTip="Select the role."
                            ValidationGroup="VG">*</asp:RequiredFieldValidator>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="CreateBut" runat="server" CommandName="Update" Text="Update" ValidationGroup="VG"
                            OnClick="UpdateBut_Click" />
                        <span class="or">or </span>
                        <asp:HyperLink ID="CancelHL" class="linkRed" runat="server" NavigateUrl="~/admin/UserList.aspx">Cancel</asp:HyperLink>
                    </p>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
