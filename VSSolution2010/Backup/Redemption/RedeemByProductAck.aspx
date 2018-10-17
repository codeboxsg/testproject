<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RedeemByProductAck.aspx.cs" Inherits="Redemption.RedeemByProductAck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main" role="main">
        <div id="LoggedInDiv" runat="server" visible="true" class="container">
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Claim Rewards</h4>
                </div>
            </div>
            <div class="sixteen columns">
                <div class="list-wrap">
                    <div id="tabs1">
                        <table>
                            <tr>
                                <td class="eleven columns">
                                    Thank you! Your submission has been sent.
                                </td>
                                <td class="four columns">
                                    <asp:Literal ID="MemberPointsBalanceLit" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
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
