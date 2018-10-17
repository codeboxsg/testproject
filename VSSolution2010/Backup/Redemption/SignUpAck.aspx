<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SignUpAck.aspx.cs" Inherits="Redemption.SignUpAck" %>

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
          
            <div class="sixteen columns">
                <div class="title bg3">
                    <h4>
                        Sign Up&nbsp; as Member!</h4>
                </div>
            </div>
            <div id="ExistingDiv" runat="server" class="sixteen columns">
                <p>
                    You are an existing member of Rewardshub and you have successfully registered!</p>
            </div>
            <div id="NewDiv" runat="server" class="sixteen columns">
                <p>
                    Registration is successful.
					You will be receiving an email confirmation shortly.<br/>
					Please be informed that the email may end up in your spam folder. Do keep a lookout.<br/>
					If you do not receive any email from us within the next three hours, do drop us a note at <a href="mailto:mceduperks@sg.marshallcavendish.com">mceduperks@sg.marshallcavendish.com</a></p>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
