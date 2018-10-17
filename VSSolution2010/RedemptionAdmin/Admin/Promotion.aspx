<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Promotion.aspx.cs" Inherits="RedemptionAdmin.Admin.Promotion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <h1>
            Manage Promotion
        </h1>
    </div>
    <div>
        <asp:Button ID="ShowCreatePromotionBut" runat="server" Text="New Promotion" OnClick="ShowCreatePromotionBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Promotion Details</h3>
            </div>
            <div class="row">
                <div class="left box">
                    Name
                </div>
                <div class="right box">
                    <asp:TextBox ID="NameTB" runat="server" ValidationGroup="form" Width="400" MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="NameTB" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the name."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
                        <div class="row">
                <div class="left box">
                    Brief
                </div>
                <div class="right box">
                    <asp:TextBox ID="BriefTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
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
                            ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter the description." Display="Dynamic"
                            CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator><asp:regularexpressionvalidator controltovalidate="DescriptionTB" errormessage="Maximum 220 characters are allowed." 
                            id="regComments" runat="server"  CssClass="failureNotification" validationexpression="^[\s\S]{0,220}$" ValidationGroup="form"> </asp:regularexpressionvalidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Promotion Image<br />
                    289 x 168
                </div>
                <div class="right box">
                    <asp:Image ID="PromotionImage" runat="server" Width="289" Height="168" />
                    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" OnFileUploaded="RadAsyncUpload1_FileUploaded">
                        <FileFilters>
                            <telerik:FileFilter Extensions="jpg,png,gif,jpeg" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <asp:CustomValidator runat="server" ID="PromotionImageCV" CssClass="failureNotification"
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
                    Client
                </div>
                <div class="right box">
                    <asp:DropDownList ID="clientDDL" runat="server" ValidationGroup="form">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="clientDDL" ID="RequiredFieldValidator6"
                        runat="server" ErrorMessage="Please select a client." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Start Date
                </div>
                <div class="right box">
                    <telerik:RadDatePicker ID="startDateTB" runat="server" ValidationGroup="form">
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ControlToValidate="startDateTB" ID="RequiredFieldValidator2"
                        runat="server" ErrorMessage="Please select the start date." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    End Date
                </div>
                <div class="right box">
                    <telerik:RadDatePicker ID="endDateTB" runat="server" ValidationGroup="form">
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ControlToValidate="endDateTB" ID="RequiredFieldValidator3" Display="Dynamic"
                        runat="server" ErrorMessage="Please select the end date." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                            runat="server"  ErrorMessage="Must be later that start date." ValidationGroup="form" 
                            ControlToValidate="startDateTB" ControlToCompare="endDateTB" Operator="LessThan"></asp:CompareValidator>
                </div>
            </div>
          
     
            <div class="row">
                <div class="left box">
                    Prefix
                </div>
                <div class="right box">
                    <asp:TextBox ID="PrefixTB" runat="server" ValidationGroup="form" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="PrefixTB" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter the prefix."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Type
                </div>
                <div class="right box">
                    <asp:RadioButtonList ID="TypeRBL" runat="server" RepeatDirection="Horizontal" EnableTheming="False"
                        Width="300px" RepeatLayout="Flow" CssClass="redemption">
                        <asp:ListItem Value="0">By Points</asp:ListItem>
                        <asp:ListItem Value="1">By Product</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TypeRBL"
                        CssClass="failureNotification" runat="server" ErrorMessage="Please select a type."
                        ValidationGroup="form"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Literal ID="promotionDetailErrorLit" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                </div>
                <div class="right box">
                    <asp:Button ID="CreatePromotionBut" runat="server" Text="Create Promotion" OnClick="CreatePromotionBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdatePromotionBut" runat="server" Text="Update Promotion" OnClick="UpdatePromotionBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
            <div id="LinkByPointsDiv" runat="server" visible="false" class="row">
                        <div class="row">
                <h3>
                    Link Details</h3>
            </div>
                <div class="left box">
                    Associate
                </div>
                <div class="right box">
                    <asp:LinkButton ID="RewardsBut" runat="server" OnClick="RewardsBut_Click">Link Rewards</asp:LinkButton>
                    <asp:LinkButton ID="ProductBut" Visible="false" runat="server" OnClick="ProductBut_Click">Link Products</asp:LinkButton>
                </div>
            </div>
            <div id="LinkByProductDiv" runat="server" visible="false" class="row">
                         <div class="row">
                <h3>
                    Link Details</h3>
            </div>   <div class="left box">
                    Associate
                </div>
                <div class="right box">
                    <asp:LinkButton ID="ProductAndRewardBut" runat="server" OnClick="ProductAndRewardBut_Click">Link Products & Rewards</asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand"   EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="PromotionLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="PromotionLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="type,promotionid"
                Width="900px">
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
                    <telerik:GridTemplateColumn AllowFiltering="true" UniqueName="promotionid" HeaderText="Promotion ID"
                        DataField="promotionid" SortExpression="promotionid" FilterControlAltText="Filter promotionid column">
                        <ItemTemplate>
                            <asp:Literal ID="PromoidLit" runat="server"></asp:Literal><br />
                            <asp:LinkButton CommandName="Edit2" Text="Manage" ID="LinkButton1" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>             
                    <telerik:GridBoundColumn DataField="type" FilterControlAltText="Filter type column"
                    HeaderText="Type" SortExpression="type" UniqueName="type">
                </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn HeaderText="Client" DataField="clientid" Visible="false" />
                    <telerik:GridBoundColumn HeaderText="Client Name" DataField="clientname" />
                       <telerik:GridBoundColumn HeaderText="Name" DataField="name" />

                       <telerik:GridBoundColumn HeaderText="Brief" DataField="brief" />
                             <telerik:GridBoundColumn HeaderText="Description" DataField="description" />
                    <telerik:GridBoundColumn HeaderText="Start Date" DataField="startdate" DataType="System.DateTime"
                         />
                    <telerik:GridBoundColumn HeaderText="End Date" DataField="enddate" DataType="System.DateTime"
                        />
             
                    <telerik:GridBoundColumn HeaderText="Prefix" DataField="prefix" Visible="false" />
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
