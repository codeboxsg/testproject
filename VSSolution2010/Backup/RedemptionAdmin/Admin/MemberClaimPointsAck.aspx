<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberClaimPointsAck.aspx.cs" Inherits="Redemption.MemberClaimPointsAck" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="sixteen columns">
            <asp:LinkButton ID="MembersBut" runat="server" OnClick="MembersBut_Click">Members</asp:LinkButton>
            <h1>
                Member Claim Point
            </h1>
        </div>
        <div class="sixteen columns">
          Submission has been sent.
        </div>
    <!-- container -->
    </div>
</asp:Content>
