<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberRedeemByProduct.aspx.cs" Inherits="RedemptionAdmin.MemberRedeemByProduct" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                            Please complete the form below
                        </td>
                        <td class="eleven columns">
                        </td>
                    </tr>
                    <tr>
                        <td class="four columns">
                            Upload Receipt Here
                        </td>
                        <td class="eleven columns">
                            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" OnFileUploaded="RadAsyncUpload1_FileUploaded">
                                <FileFilters>
                                    <telerik:FileFilter Extensions="jpg,png,gif,jpeg" />
                                </FileFilters>
                            </telerik:RadAsyncUpload>
                            <asp:CustomValidator runat="server" ID="CustomValidator" CssClass="failureNotification"
                                ClientValidationFunction="Demo" ErrorMessage="Please upload your receipt." ValidateEmptyText="true">
                            </asp:CustomValidator>
                            <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
                            <script type="text/javascript">
                                function Demo(sender, args) {
                                    var upload = $find("<%= RadAsyncUpload1.ClientID %>");

                                    if (upload.getUploadedFiles().length != 0)
                                        args.IsValid = true;
                                    else
                                        args.IsValid = false;
                                }
                            </script>
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
                    <tr id="tr1" runat="server">
                        <td class="four columns">
                            Mode of Collection
                        </td>
                        <td class="eleven columns">
                            <asp:RadioButtonList ID="CollectionModeRBL" runat="server" RepeatDirection="Horizontal"
                                EnableTheming="False" Width="300px" RepeatLayout="Flow" CssClass="redemption">
                                <asp:ListItem Value="0">Pick Up</asp:ListItem>
                                <asp:ListItem Value="1">Delivery</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CollectionModeRBL"
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
            <hr class="style1" />
            <div class="sixteen columns">
                <div class="member-submit">
                    <asp:LinkButton ID="RedeemBut" CssClass="button-style" runat="server" OnClick="RedeemBut_Click">Submit &rsaquo;</asp:LinkButton>
                </div>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
