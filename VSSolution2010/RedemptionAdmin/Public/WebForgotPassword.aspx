<%@ Page Title="" Language="C#" MasterPageFile="~/Pub.Master" AutoEventWireup="true"
    CodeBehind="WebForgotPassword.aspx.cs" Inherits="M1BODIpadServer.Account.WebForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
      <h2>Forgot password</h2>
    </div>
    <layouttemplate>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="VG" />
    <div class="accountInfo">
        <p>
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Display="Dynamic"
                CssClass="failureNotification"  ErrorMessage="Enter your username" ToolTip="Enter your username"
                ValidationGroup="VG" >*</asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" 
                ValidationGroup="VG"     CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="Username is not found. Please try again." ControlToValidate="UserName" 
                 onservervalidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
        </p>
        <p class="submitButton">
           <br />
            <asp:Button ID="ResetPasswordBut" runat="server" CommandName="ResetPassword" 
                Text="Reset Password" ValidationGroup="VG" onclick="ResetPasswordBut_Click" />
        </p>
    </div>
    </layouttemplate>
</asp:Content>
