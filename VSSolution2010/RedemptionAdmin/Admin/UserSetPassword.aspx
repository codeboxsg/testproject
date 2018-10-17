<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserSetPassword.aspx.cs" Inherits="RedemptionAdmin.UserSetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle mb0">
      <h2>Set Password /download App</h2>
      <p>Send set password email to this user.</p>
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
        <p class="mb10">
            <asp:Label ID="EmailLbl" runat="server">Email:</asp:Label>
            <asp:Label ID="EmailLbl2" runat="server" class="bold"></asp:Label>
        </p>
        <p class="submitButton width320">
            <asp:Button ID="SendResetBut" runat="server" CommandName="SendReset" Text="Send set password email"
                ValidationGroup="VG" OnClick="SendResetBut_Click" />
            <span class="or">or</span>
            <asp:LinkButton class="linkRed" ID="CancelLB" runat="server" onclick="CancelLB_Click">Cancel</asp:LinkButton>
        </p>
    </div>
        </td>
      </tr>
    </table>
</asp:Content>
