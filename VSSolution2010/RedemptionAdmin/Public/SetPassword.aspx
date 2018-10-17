<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true"
    CodeBehind="SetPassword.aspx.cs" Inherits="RedemptionAdmin.SetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
     
	  <h2>Please set your password below:</h2>
    </div>
    <layouttemplate>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="VG" />
    <div class="accountInfo">
    <p>Min 8 characters. 1 must be a number and 1 must be an alphabet</p>
        <p>
            <asp:Label ID="NewPasswordLbl" runat="server"  AssociatedControlID="NewPasswordTB">New Password:</asp:Label>
            <asp:TextBox ID="NewPasswordTB" runat="server" CssClass="textEntry" TextMode="Password" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NewPasswordRFV" runat="server" ControlToValidate="NewPasswordTB" Display="Dynamic"
                CssClass="failureNotification" ErrorMessage="Please enter your password" ToolTip="Please enter your password"
                ValidationGroup="VG">*</asp:RequiredFieldValidator>   <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="NewPasswordTB" ValidationGroup="VG" 
                        Display="Dynamic" ErrorMessage="Please enter at least 8 characters. 1 must be a number and 1 must be an alphabet." ValidationExpression="^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"
                        CssClass="failureNotification">*
                    </asp:RegularExpressionValidator>  <%--1 alpha, 1 numeric, 1 upper "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"--%>
     
        </p>
		<br/>
		<br/>
       <p>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" AssociatedControlID="ConfirmPasswordTB">Confirm Password:</asp:Label>
            <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="textEntry" TextMode="Password" autocomplete="off"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ConfirmPasswordRFV" runat="server" ControlToValidate="ConfirmPasswordTB" Display="Dynamic"
                CssClass="failureNotification" ErrorMessage="Please enter the same password to confirm." ToolTip="Please enter the same password to confirm."
                ValidationGroup="VG">*</asp:RequiredFieldValidator><asp:CompareValidator ID="PasswordCOMPV" ControlToValidate="ConfirmPasswordTB" ControlToCompare="NewPasswordTB"
                                 CssClass="failureNotification" ValidationGroup="VG" SetFocusOnError="false"
                              Display="Dynamic" ErrorMessage="Passwords do not match" runat="server" Operator="Equal">*
                            </asp:CompareValidator>
        </p>
		<br/>
        <p class="submitButton">
            <asp:Button ID="ResetPasswordBut" runat="server" CommandName="ResetPassword" 
                Text="Submit" ValidationGroup="VG" onclick="ResetPasswordBut_Click" />
        </p>
    </div>
    </layouttemplate>
</asp:Content>
