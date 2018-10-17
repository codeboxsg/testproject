<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Client.aspx.cs" Inherits="RedemptionAdmin.Admin.Client1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Manage Client
        </h1>
    </div>
    <div class="row">
        <asp:Button ID="ShowCreateClientBut" runat="server" Text="New Client" OnClick="ShowCreateClientBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Client Details</h3>
            </div>
            <div class="row">
                <div class="left box">
                    Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="NameTB" runat="server" ValidationGroup="form"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="NameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Contact Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="ContactNameTB" runat="server" ValidationGroup="form"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="ContactNameTB" ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Please enter the contact name." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Phone No
                </div>
                <div class="right box">
                    <asp:TextBox ID="PhoneNoTB" runat="server" ValidationGroup="form"  MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="PhoneNoTB" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the phone no."
                        CssClass="failureNotification" ValidationGroup="form" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="e.g. 91234567 or 612345678" 
                                    ControlToValidate="PhoneNoTB" ValidationExpression="^\d{8}$" ValidationGroup="form"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <h3>
                    Technical Details</h3>
            </div>
                        <div class="row">
                <div class="left box">
                    Site Relative Path
                </div>
                <div class="right box">
                    <asp:TextBox ID="SiteRelativePathTB" runat="server" ValidationGroup="form"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="SiteRelativePathTB" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the site relative path."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
                        <div class="row">
                <div class="left box">
                 Logo Image Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="LogoImageNameTB" runat="server" ValidationGroup="form"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="LogoImageNameTB" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter the logo image name."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
                            <div class="row">
                <div class="left box">
               Email Physical Path
                </div>
                <div class="right box">
                    <asp:TextBox ID="EmailphysicalpathTB" runat="server" ValidationGroup="form"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="emailphysicalpathTB" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter the logo image name."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Literal ID="clientDetailErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div id="ProductsDiv" runat="server" class="row">
                <div class="left box">
                    Products
                </div>
                <div class="right box">
                    <asp:LinkButton ID="ProductsLB" runat="server" OnClick="ProductsLB_Click">Products</asp:LinkButton>
                </div>
            </div>
            <div id="RewardsDiv" runat="server" class="row">
                <div class="left box">
                    Rewards
                </div>
                <div class="right box">
                    <asp:LinkButton ID="RewardsLB" runat="server" OnClick="RewardsLB_Click">Rewards</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="CreateClientBut" runat="server" Text="Create Client" OnClick="CreateClientBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdateClientBut" runat="server" Text="Update Client" OnClick="UpdateClientBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="ClientLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="ClientLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="clientid">
                <CommandItemSettings ShowExportToCsvButton="true" ShowAddNewRecordButton="false">
                </CommandItemSettings>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
                <HeaderStyle Font-Bold="true" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn AllowFiltering="true" UniqueName="clientid" HeaderText="Client ID"  DataType="System.Int32"
                        DataField="clientid" SortExpression="clientid" FilterControlAltText="Filter clientid column">
                        <ItemTemplate>
                            <asp:Literal ID="ClientidLit" runat="server"></asp:Literal><br />
                            <asp:LinkButton CommandName="Edit2" Text="Manage" ID="LinkButton1" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Name" DataField="name" />
                    <telerik:GridBoundColumn HeaderText="Contact Name" DataField="contactname" />
                    <telerik:GridBoundColumn HeaderText="Phone No" DataField="phoneno" />
                    <telerik:GridBoundColumn HeaderText="Date Modified" DataField="datemodified" DataType="System.DateTime"
                       />
                    <telerik:GridBoundColumn HeaderText="Date Entry" DataField="dateentry" DataType="System.DateTime"
                         />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
