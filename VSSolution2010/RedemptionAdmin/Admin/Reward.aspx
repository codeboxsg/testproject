<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Reward.aspx.cs" Inherits="RedemptionAdmin.Admin.Reward" %>

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
                Manage Reward
            </h1>
        </div>
        <asp:Button ID="ShowCreateRewardBut" runat="server" Text="New Reward" OnClick="ShowCreateRewardBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Reward Details</h3>
            </div>
            <div class="row">
                <div class="left box">
                    Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="NameTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="NameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name."
                        ValidationGroup="form" CssClass="failureNotification"></asp:RequiredFieldValidator>
                </div>
            </div>
                                  <div class="row">
                <div class="left box">
                    Brief
                </div>
                <div class="right box">
                    <asp:TextBox ID="BriefTB" runat="server" ValidationGroup="form"  MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="BriefTB" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter the brief."
                        ValidationGroup="form" CssClass="failureNotification"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Description
                </div>
                <div class="right box">
                    <asp:TextBox ID="DescriptionTB" runat="server" ValidationGroup="form" TextMode="MultiLine"
                        Rows="5" Height="80px" Width="400" MaxLength="220"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="descriptionTB"
                            ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter the description."
                            CssClass="failureNotification" ValidationGroup="form" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rgConclusionValidator2" 
                                ControlToValidate="DescriptionTB" ErrorMessage="Please do not exceed 200 characters"
                                ValidationExpression="^[\s\S]{0,220}$" runat="server" SetFocusOnError="true" ValidationGroup="form" CssClass="failureNotification"/>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Reward Image<br />
                    289 x 168
                </div>
                <div class="right box">
                    <asp:Image ID="RewardImage" runat="server" Width="289" Height="168" />
                    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" OnFileUploaded="RadAsyncUpload1_FileUploaded">
                        <FileFilters>
                            <telerik:FileFilter Extensions="jpg,png,gif,jpeg" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <asp:CustomValidator runat="server" ID="RewardImageCV" CssClass="failureNotification"
                        ClientValidationFunction="Demo" ErrorMessage="Please upload your image." ValidateEmptyText="true"
                        ValidationGroup="form">
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
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Points
                </div>
                <div class="right box">
                    <asp:TextBox ID="PointsTB" runat="server" ValidationGroup="form"  MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="PointsTB" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the points."
                        ValidationGroup="form" CssClass="failureNotification" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="PointsTB" ID="RegularExpressionValidator1"
                        runat="server" ErrorMessage="Must be a number." ValidationGroup="form" CssClass="failureNotification"
                        Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Qty
                </div>
                <div class="right box">
                    <asp:Literal ID="QtyLit" runat="server"></asp:Literal>
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
                    <asp:Button ID="CreateRewardBut" runat="server" Text="Create Reward" OnClick="CreateRewardBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdateRewardBut" runat="server" Text="Update Reward" OnClick="UpdateRewardBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
            <div id="StockDiv" runat="server" class="row">
                <div class="row">
                    <h3>
                        Stock Details</h3>
                </div>
                <div class="row">
                    <div class="left box">
                        Stock
                    </div>
                    <div class="right box">
                        <asp:LinkButton ID="StockBut" runat="server" OnClick="StockBut_Click">In Stock</asp:LinkButton>
                                  <asp:LinkButton ID="OutStockBut" runat="server" OnClick="OutStockBut_Click">Out Stock</asp:LinkButton>
                                      <asp:LinkButton ID="ReturnStockBut" runat="server" OnClick="ReturnStockBut_Click">Return Stock</asp:LinkButton>                </div>
                </div>
            </div>
            <div class="row">
                <br />
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="RewardLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="RewardLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="rewardid,clientid">
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
                    <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="rewardid" HeaderText="Reward ID"
                        DataField="rewardid" SortExpression="rewardid" FilterControlAltText="Filter rewardid column">
                        <ItemTemplate>
                            <asp:Literal ID="RewardidLit" runat="server"></asp:Literal><br />
                            <asp:LinkButton CommandName="Edit2" Text="Manage" ID="LinkButton1" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn HeaderText="Client ID" DataField="clientid" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="Client Name" DataField="clientname" />
                    <telerik:GridBoundColumn HeaderText="Name" DataField="name" />
                             <telerik:GridBoundColumn HeaderText="Brief" DataField="brief" />
                    <telerik:GridBoundColumn HeaderText="Description" DataField="description" />
                    <telerik:GridBoundColumn HeaderText="imagepath" DataField="imagepath" />
                    <telerik:GridBoundColumn HeaderText="Points" DataField="points" />
                    <telerik:GridBoundColumn HeaderText="Qty" DataField="qty" />
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
