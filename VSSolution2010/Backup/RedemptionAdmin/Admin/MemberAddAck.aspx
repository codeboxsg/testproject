<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberAddAck.aspx.cs" Inherits="Redemption.MemberAddAck" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="LoggedInDiv" runat="server" visible="true" class="container">
        <div class="sixteen columns">
                         <h4>
                      <asp:LinkButton ID="MembersBut" runat="server" OnClick="MembersBut_Click">Members</asp:LinkButton>
       </h4>
            <table>
                <tr>
                    <td class="eleven columns">
                      Member Added.
                    </td>
                    <td class="four columns">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- container -->
</asp:Content>
