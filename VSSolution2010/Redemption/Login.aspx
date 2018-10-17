<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Redemption.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
		<div class="quote-text"><div class="quote-bg1"><div class="quote-bg2">
		<p>"Log in to view or update your profile, as well as redeem your favourite gifts!"</p>
		</div></div></div>
        <div class="login login-page five columns ">
         <h4>
                       Login</h4>
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
                OnLoggedIn="LoginUser_LoggedIn"  onauthenticate="LoginUser_Authenticate">
                <LayoutTemplate>
                    <asp:TextBox ID="UserName" runat="server" CssClass="form1" placeholder="Email (Username)"
                        ValidationGroup="LoginUserVG2"></asp:TextBox>
                    <asp:TextBox ID="Password" runat="server" CssClass="form1" TextMode="Password" placeholder="Password "
                        ValidationGroup="LoginUserVG2"></asp:TextBox>
                    <asp:LinkButton ID="LoginButton" Width="45" CssClass="button-style3" runat="server"
                        CommandName="Login" Text="Login" ValidationGroup="LoginUserVG2" />
                     <br />
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:CompareValidator Display="Dynamic" ID="CompareValidator5" runat="server" ErrorMessage="Email is required."
                        ControlToValidate="UserName" ValidationGroup="LoginUserVG2" Operator="NotEqual"
                        CssClass="failureNotification" ValueToCompare="Email (Username)"></asp:CompareValidator>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Password is required." ControlToValidate="Password" ValidationGroup="LoginUserVG2"
                        CssClass="failureNotification"></asp:RequiredFieldValidator>
					<span style="margin-bottom: -10px"><a href="ForgotPassword.aspx">Forgot Password</a> | <a href="signup.aspx">
                        Sign Up</a></span>
                    <br />
                    <br />
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
</asp:Content>
