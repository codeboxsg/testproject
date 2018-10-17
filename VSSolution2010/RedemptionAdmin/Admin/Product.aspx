<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="RedemptionAdmin.Admin.Product" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="row">
            <div class="left box">
                <asp:LinkButton ID="ClientBut" runat="server" OnClick="ClientBut_Click"></asp:LinkButton>
            </div>
            <div class="right box">
            </div>
        </div>
        <div class="row">
            <h1>
                Manage Product
            </h1>
        </div>
        <asp:Button ID="ShowCreateProductBut" runat="server" Text="New Product" OnClick="ShowCreateProductBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <div class="left box">
                    <h3>
                        Product Details</h3>
                </div>
                <div class="right box">
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="NameTB" runat="server" ValidationGroup="form"  MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="NameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name."
                        ValidationGroup="form" CssClass="failureNotification"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Model
                </div>
                <div class="right box">
                    <asp:TextBox ID="ModelTB" runat="server" ValidationGroup="form"  MaxLength="220"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="ModelTB" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the model."
                        ValidationGroup="form" CssClass="failureNotification"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Points
                </div>
                <div class="right box">
                    <asp:TextBox ID="PointsTB" runat="server" ValidationGroup="form"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="PointsTB" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the points."
                        ValidationGroup="form" CssClass="failureNotification" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="PointsTB" ID="RegularExpressionValidator1"
                        runat="server" ErrorMessage="Must be a number." ValidationGroup="form" CssClass="failureNotification"
                        Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Client
                </div>
                <div class="right box">
                    <asp:DropDownList ID="clientDDL" runat="server" ValidationGroup="form" Enabled="false">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="clientDDL" ID="RequiredFieldValidator6"
                        runat="server" ErrorMessage="Please select a client." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Literal ID="ProductDetailErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="CreateProductBut" runat="server" Text="Create Product" OnClick="CreateProductBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdateProductBut" runat="server" Text="Update Product" OnClick="UpdateProductBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="ProductLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="ProductLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="productid,clientid">
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
                    <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="productid" HeaderText="Product ID"
                        DataField="productid" SortExpression="productid" FilterControlAltText="Filter productid column">
                        <ItemTemplate>
                            <asp:Literal ID="ProductidLit" runat="server"></asp:Literal><br />
                            <asp:LinkButton CommandName="Edit2" Text="Manage" ID="LinkButton1" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Client ID" DataField="clientid" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="Client Name" DataField="clientname" />
                    <telerik:GridBoundColumn HeaderText="Name" DataField="name" />
                    <telerik:GridBoundColumn HeaderText="Model" DataField="model" />
                    <telerik:GridBoundColumn HeaderText="Description" DataField="description" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="imagepath" DataField="imagepath" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="Points" DataField="points" />
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
