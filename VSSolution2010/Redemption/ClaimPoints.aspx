<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ClaimPoints.aspx.cs" Inherits="Redemption.ClaimPoints" %>

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
                                    <td class="four columns">
                                        Please submit your receipts here
                                    </td>
                                    <td class="eleven columns">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="four columns">
                                        Upload Receipt
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
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="style1" />
            <div class="sixteen columns">
                <div class="member-submit">
                    <asp:LinkButton ID="ClaimPointBut" CssClass="button-style" runat="server" OnClick="ClaimPointBut_Click">Submit &rsaquo;</asp:LinkButton>
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
        </div>
        
        <!-- container -->
    </div>
</asp:Content>
