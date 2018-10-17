<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberRedeemByPoints.aspx.cs" Inherits="RedemptionAdmin.MemberRedeemByPoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="sixteen columns">
            <asp:LinkButton ID="MembersBut" runat="server" OnClick="MembersBut_Click">Members</asp:LinkButton>
            &nbsp;&gt;
            <asp:HyperLink ID="UsernameHL" runat="server"></asp:HyperLink>
            &nbsp;&gt;
            <asp:Literal ID="ClientLit" runat="server"></asp:Literal>
            <h1>
                Member Claim Rewards
            </h1>
        </div>
    </div>
    <div id="main" role="main">
        <div id="LoggedInDiv" runat="server" visible="false" class="container">
            <div class="sixteen columns">
                <div class="title bg2">
                    <h4>
                        Claim Rewards</h4>
                </div>
            </div>
            <div class="sixteen columns">
                <table>
                    <tr>
                        <td class="four columns">
                            Points Available
                        </td>
                        <td class="eleven columns">
                            <asp:Literal ID="MemberPointsBalanceLit" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="four columns">
                            Item to Redeem
                        </td>
                        <td class="eleven columns">
                            <asp:Literal ID="RedeemItemLit" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="four columns">
                            Balance Points
                        </td>
                        <td class="eleven columns">
                            <asp:Literal ID="RemaindingPointBalanceLit" runat="server"></asp:Literal>
                            <asp:Literal ID="NoPointsLit" Visible="false" runat="server" Text="*You do not have enough points"></asp:Literal>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="four columns">
                            Mode of Collection
                        </td>
                        <td class="eleven columns">
                            <asp:RadioButtonList ID="CollectionModeRBL" runat="server" RepeatDirection="Horizontal"
                                EnableTheming="False" Width="300px" RepeatLayout="Flow" CssClass="redemption">
                                <asp:ListItem Value="0">Pick Up</asp:ListItem>
                                <asp:ListItem Value="1">Delivery</asp:ListItem>
                            </asp:RadioButtonList>  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CollectionModeRBL"
                                CssClass="failureNotification" runat="server" ErrorMessage="Please select a mode of collection"></asp:RequiredFieldValidator>
           
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="four columns">
                            Remarks (if any)
                        </td>
                        <td class="eleven columns">
                            <asp:TextBox ID="RemarksTB" TextMode="MultiLine" Wrap="true" Rows="3" Height="60px"
                                Width="290px" runat="server" MaxLength="400"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <hr class="style1" id="tr3" runat="server" />
            <div class="sixteen columns" id="tr4" runat="server">
                <div class="member-submit">
                    <asp:LinkButton ID="RedeemBut" runat="server" CssClass="button-style" Text="Submit &rsaquo;"
                        OnClick="ReeemBut_Click" />
                </div>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
