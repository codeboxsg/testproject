<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Public.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="RedemptionAdmin.Public.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="pageTitle mb0">
      <!--<h2>Log In</h2>-->
      <p><strong>Please enter your username and password:</strong></p>
    </div>
    <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false" Visible="false">Register</asp:HyperLink>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
    RenderOuterTable="false" onloggedin="LoginUser_LoggedIn" 
    onloginerror="LoginUser_LoginError" >
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <div class="accountInfo">
                <p>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" 
                        ontextchanged="UserName_TextChanged" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="Enter your username" ToolTip="Enter your username"
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="LoginUserCV" 
                        ValidationGroup="LoginUserValidationGroup" ControlToValidate="UserName" 
                        EnableClientScript="false" Enabled="true"
                        runat="server" CssClass="failureNotification" Display="None"
                        ErrorMessage="You must be portal staff to login." 
                        onservervalidate="LoginUserCV_ServerValidate"></asp:CustomValidator>
                </p>
                <p>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="failureNotification" ErrorMessage="Enter your password" ToolTip="Enter your password"
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p class="mb10">
                    <!--<asp:CheckBox ID="RememberMe" runat="server" />-->
                    <!--<asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>-->
                </p>
                <p class="mb10"><asp:HyperLink ID="ForgotPasswordHL" class="link" runat="server" EnableViewState="false" NavigateUrl="forgotpassword.aspx">Forgot / Change Password</asp:HyperLink></p>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" />
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
