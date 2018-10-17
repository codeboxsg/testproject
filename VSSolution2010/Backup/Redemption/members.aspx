<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="members.aspx.cs" Inherits="Redemption.members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner-member.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main">
        <div id="LoggedInDiv" runat="server" visible="false" class="container">
            <div class="sixteen columns">
            	<div class="quote-text"><div class="quote-bg1"><div class="quote-bg2">
                    Over here, you can edit and update your particulars, view your MCE points and transaction history at a glance. You can upload your recipts here as well. 
                </div></div></div>
            </div>
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Member's Area</h4>
                </div>
            </div>
            <div class="sixteen columns">
                <div id="tabs">
                    <ul class="nav">
                        <li class="nav-one"><a href="#tabs1" class="current">REDEMPTION</a></li>
                        <li class="nav-two"><a href="#tabs2">HISTORY</a></li>
                        <li class="nav-three"><a href="#tabs3">POINTS</a></li>
                        <li class="nav-four last"><a href="#tabs4">UPDATE</a></li>
                    </ul>
                    <div class="list-wrap">
                        <div id="tabs1">
                            <table>
                                <tr>
                                    <td class="four columns">
                                        Points Available
                                    </td>
                                    <td class="eleven columns">
                                        0
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Items to Redeem
                                    </td>
                                    <td class="eleven columns">
                                        $20 NTUC Voucher
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Balance Points
                                    </td>
                                    <td class="eleven columns">
                                        0
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Upload Receipt Here
                                    </td>
                                    <td class="eleven columns">
                                        [ Upload File ]
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Mode of Collection
                                    </td>
                                    <td class="eleven columns">
                                        Pick Up - $0
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Remarks (if any)
                                    </td>
                                    <td class="eleven columns">
                                    </td>
                                </tr>
                            </table>
                            <p class="nine columns">
                                You can also whatsapp your receipt to us! We will process your claim within 3 working
                                days and we will send you a link to download and print the redemption letter.</p>
                        </div>
                        <div id="tabs2" class="hide">
                            <p>
                                Coming soon</p>
                        </div>
                        <div id="tabs3" class="hide">
                            <p>
                                Coming soon</p>
                        </div>
                        <div id="tabs4" class="hide">
                            <p>
                                Coming soon</p>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="style1" />
            <div class="sixteen columns">
                <div class="member-submit">
                    <a href="#" class="button-style">Submit &rsaquo;</a></div>
            </div>
        </div>
        <div id="NotLoggedInDiv" runat="server" visible="false" class="container">
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Member's Area</h4>
                </div>
            </div>
            <div class="sixteen columns">
                Please login to continue.
                <br /><br />
            </div>
           
        </div>
        <!-- container -->
    </div>
</asp:Content>
