<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberClaimPoints.aspx.cs" Inherits="Redemption.MemberClaimPoints" %>

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
                Member Claim Point
            </h1>
        </div>
        <div class="sixteen columns">
            <table>
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
                            ClientValidationFunction="Demo" ErrorMessage="Please upload your receipt." ValidateEmptyText="true"
                            ValidationGroup="claimpoints">
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
        <div class="sixteen columns">
            <asp:LinkButton ID="ClaimPointBut" CssClass="button-style" runat="server" OnClick="ClaimPointBut_Click"
                ValidationGroup="claimpoints">Submit &rsaquo;</asp:LinkButton>
        </div>
    </div>
</asp:Content>
