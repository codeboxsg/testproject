<%@ Page Title="" Language="C#" MasterPageFile="~/PubNoLogin.Master" AutoEventWireup="true"
    CodeBehind="WebResetPassword.aspx.cs" Inherits="M1BODIpadServer.Account.WebResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
      <h2>Please reset your Keppel Board Web Portal password below:</h2>
    </div>
    <layouttemplate>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="VG" />
    <div class="accountInfo">
        <p>
            <asp:Label ID="NewPasswordLbl" runat="server"  AssociatedControlID="NewPasswordTB">New Password (Min 6 chars):</asp:Label>
            <asp:TextBox ID="NewPasswordTB" runat="server" CssClass="textEntry"  TextMode="Password" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NewPasswordRFV" runat="server" ControlToValidate="NewPasswordTB"
                CssClass="failureNotification" ErrorMessage="Please enter your password" ToolTip="Please enter your password"
                ValidationGroup="VG">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ValidationGroup="VG" ID="PasswordREV"
                              runat="server" ControlToValidate="NewPasswordTB" Display="Dynamic"
                              ForeColor="" ErrorMessage="Password should be at least 6 characters" ValidationExpression="^.{6,}$"
                              SetFocusOnError="true"></asp:RegularExpressionValidator>
        </p>
		<br>
		<br>
        <p>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" AssociatedControlID="ConfirmPasswordTB">Confirm Password (Min 6 chars):</asp:Label>
            <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="textEntry" TextMode="Password" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ConfirmPasswordRFV" runat="server" ControlToValidate="ConfirmPasswordTB"
                CssClass="failureNotification" ErrorMessage="Please re-enter your password" ToolTip="Please re-enter your password"
                ValidationGroup="VG">*</asp:RequiredFieldValidator><asp:CompareValidator ID="PasswordCOMPV" ControlToValidate="ConfirmPasswordTB" ControlToCompare="NewPasswordTB"
                              ForeColor="" ValidationGroup="VG" SetFocusOnError="false"
                              Display="Dynamic" ErrorMessage="Passwords do not match" runat="server" Operator="Equal">
                            </asp:CompareValidator>
        </p>
		<br>
        <p class="submitButton">
            <asp:Button ID="ResetPasswordBut" runat="server" CommandName="ResetPassword" 
                Text="Submit" ValidationGroup="VG" onclick="ResetPasswordBut_Click" />
        </p>
    </div>
    </layouttemplate>
</asp:Content>
