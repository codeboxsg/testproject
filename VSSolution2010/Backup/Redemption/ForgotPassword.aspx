<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="Redemption.ForgotPassword" %>

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
                             Forgot Password</h4>
                </div>
            </div>

           
            <div class="eleven columns">
                <asp:TextBox ID="MemberUsernameTB" class="form1" placeholder="Email (Username)" runat="server"
                    ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Please enter your email address. "
                    ControlToValidate="MemberUsernameTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="Email (Username)" CssClass="failureNotification" Display="Dynamic"></asp:CompareValidator><asp:RegularExpressionValidator
                        ID="EmailREV" runat="server" ControlToValidate="MemberUsernameTB" ValidationGroup="SignUpVG"
                        Display="Dynamic" ErrorMessage="e.g. someone@email.com" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,3}$"
                        CssClass="failureNotification">
                    </asp:RegularExpressionValidator>
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
