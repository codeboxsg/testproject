<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SignUpExisting.aspx.cs" Inherits="Redemption.SignUpExisting" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner-signup.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main">
        <div class="container">
            <div class="six columns">
                <h3 class="color">
                    ABOUT MARSHALL CAVENDISH EDUCATION</h3>
                <p>
                    At Marshall Cavendish Education, we also believe in keeping in touch with our customers
                    and adding value to their learning and teaching experience. With MCE Rewards, you
                    can enjoy quality products and get rewarded for it at the same time.</p>
            </div>
            <div class="ten columns">
                <div class="quote-text">
                    <img class="resize" src="img/img-text-sub.gif" alt="" title="" />
                </div>
            </div>
            <div class="sixteen columns">
                <div class="title bg3">
                    <h4>
                        Sign Up&nbsp; as Member!</h4>
                </div>
            </div>
            <div id="AddedDiv" runat="server" class="sixteen columns">
                <p>
                    You are an existing member of Rewardshub and you have been added to this site.</p>
            </div>
               <div id="loginDiv" runat="server" class="sixteen columns">
                 <p>
                    You are an existing member of Rewardshub. Please login to continue.</p>
                     <div class="eleven columns">
                <h4>
                    Login</h4>
            </div>
                       <div class="eleven columns">
                       <div class="form1 clearfix">
                           <asp:Literal ID="MemberUsernameLit" runat="server"></asp:Literal>
            </div>    </div>
            <div class="four columns">
              
            </div>
              <div class="eleven columns">
                <asp:TextBox ID="MemberPasswordTB" class="form1" placeholder="Password" runat="server"
                    ValidationGroup="SignUpVG" CssClass="form1"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="Please enter your password."
                    ControlToValidate="MemberPasswordTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="Password" ></asp:CompareValidator>
            </div>
                        <div class="eleven columns">
                <div class="sign-up">
                    <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                    <asp:LinkButton ID="SignUpBut" runat="server" CssClass="button-style" Text="Login &rsaquo;"
                        OnClick="LoginBut_Click" ValidationGroup="SignUpVG" />
                </div>
            </div>
        </div>
         
        </div>
        <!-- container -->
    </div>
</asp:Content>
