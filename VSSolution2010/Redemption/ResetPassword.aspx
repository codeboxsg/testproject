<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ResetPassword.aspx.cs" Inherits="Redemption.ResetPassword" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="main" role="main">
        <div class="container">

            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                             Reset Password</h4>
                </div>
            </div>

           
            <div class="eleven columns">
                <asp:TextBox ID="NewPasswordTB" class="form1" placeholder="New Password" runat="server"
                    ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Please enter your new password."
                    ControlToValidate="NewPasswordTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="New Password" CssClass="failureNotification" Display="Dynamic"></asp:CompareValidator><asp:RegularExpressionValidator
                        ID="EmailREV" runat="server" ControlToValidate="NewPasswordTB" ValidationGroup="SignUpVG"
                        Display="Dynamic" ErrorMessage="Password should be at least 8 characters" ValidationExpression="^.{8,}$"
                        CssClass="failureNotification">
                    </asp:RegularExpressionValidator>  <asp:CustomValidator Display="Dynamic" CssClass="failureNotification"
                     ID="ChangePasswordCV" runat="server" ControlToValidate="NewPasswordTB" ValidationGroup="SignUpVG"
                ErrorMessage="Your account is Locked out, because of too many login failed attempts. Please contact administrator."></asp:CustomValidator>
            </div>
       <div class="eleven columns">
                <asp:TextBox ID="ConfirmPasswordTB" class="form1" placeholder="Confirm Password" runat="server"
                    ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please reconfirm you password. "
                    ControlToValidate="ConfirmPasswordTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="Confirm Password" CssClass="failureNotification" Display="Dynamic"></asp:CompareValidator>
                    <asp:CompareValidator
                        ID="CompareValidator2" runat="server" 
                        ControlToValidate="ConfirmPasswordTB" ControlToCompare="NewPasswordTB" ValidationGroup="SignUpVG"
                        Display="Dynamic" ErrorMessage="Passwords do not match." 
                        CssClass="failureNotification">
                    </asp:CompareValidator>
            </div>
       
            <hr />

            <div class="eleven columns">
                <div class="sign-up">
                    <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                    <asp:LinkButton ID="SignUpBut" runat="server" CssClass="button-style" Text="Next &rsaquo;"
                        OnClick="SignUpBut_Click" ValidationGroup="SignUpVG" />
                </div>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
