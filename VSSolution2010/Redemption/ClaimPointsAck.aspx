<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ClaimPointsAck.aspx.cs" Inherits="Redemption.ClaimPointsAck" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="main" role="main">
        <div id="LoggedInDiv" runat="server" visible="true" class="container">
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Member's Area</h4>
                </div>
            </div>
            <div class="sixteen columns">
                <div id="tabs">
                    <ul class="nav">
                        <li class="nav-one"><a href="#" class="current">CLAIM POINTS</a></li>
                        <li class="nav-two"><a href="status.aspx">REWARDS &amp; POINTS</a></li>
                        <li class="nav-four last"><a href="updateparticulars.aspx">UPDATE PARTICULARS</a></li>
                    </ul>
                    <div class="list-wrap">
                        <div id="tabs1">
                            <table>
                                <tr>
                                    <td class="eleven columns">
                                        Thank you! Your submission has been sent.
                                    </td>
                                    <td class="four columns">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <!-- container -->
    </div>
</asp:Content>
