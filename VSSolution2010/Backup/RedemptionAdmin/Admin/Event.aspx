<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Event.aspx.cs" Inherits="RedemptionAdmin.Admin.Event" %>

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
                Manage Event
            </h1>
        </div>
        <asp:Button ID="ShowCreateEventBut"  runat="server" Text="New Event" OnClick="ShowCreateEventBut_Click" />
        <asp:Panel ID="ClientDetailPnl" Visible="false" runat="server">
            <div class="row">
                <h3>
                    Event Details</h3>
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
                    <asp:TextBox ID="BriefTB" runat="server" ValidationGroup="form" MaxLength="35"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="BriefTB" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the brief."
                        ValidationGroup="form" CssClass="failureNotification"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Description
                </div>
                <div class="right box">
                    <asp:TextBox ID="DescriptionTB" runat="server" ValidationGroup="form" TextMode="MultiLine"
                        Rows="5" Height="80px" Width="400"  MaxLength="220"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="descriptionTB"
                            ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ErrorMessage="Please enter the description."
                            CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator><asp:regularexpressionvalidator controltovalidate="DescriptionTB" errormessage="Maximum 220 characters are allowed." 
                            id="regComments" runat="server"  CssClass="failureNotification" validationexpression="^[\s\S]{0,220}$" ValidationGroup="form"> </asp:regularexpressionvalidator>
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    URL
                </div>
                <div class="right box">
                    <asp:TextBox ID="UrlTB" runat="server" ValidationGroup="form"  MaxLength="500"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="UrlTB" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the url."
                        CssClass="failureNotification" ValidationGroup="form"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="UrlTB"
                ValidationGroup="form" Display="Dynamic" ErrorMessage="e.g. http://www.google.com"
                ValidationExpression="(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?" CssClass="failureNotification">
            </asp:RegularExpressionValidator>
              
                </div>
            </div>
            <div class="row">
                <div class="left box">
                    Event Image<br />
                    289 x 168
                </div>
                <div class="right box">
                    <asp:Image ID="EventImage" runat="server" Width="289" Height="168" />
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
                    <asp:RequiredFieldValidator ControlToValidate="startDateTB" ID="RequiredFieldValidator4" Display="Dynamic"
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
                    <asp:RequiredFieldValidator ControlToValidate="endDateTB" ID="RequiredFieldValidator5" Display="Dynamic"
                        runat="server" ErrorMessage="Please select the end date." CssClass="failureNotification"
                        ValidationGroup="form"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                            runat="server"  ErrorMessage="Must be later that start date." ValidationGroup="form" 
                            ControlToValidate="startDateTB" ControlToCompare="endDateTB"
                             CssClass="failureNotification" Operator="LessThanEqual"></asp:CompareValidator>
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
                    <asp:Button ID="CreateEventBut" runat="server" Text="Create Event" OnClick="CreateEventBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="UpdateEventBut" runat="server" Text="Update Event" OnClick="UpdateEventBut_Click"
                        ValidationGroup="form" />
                    <asp:Button ID="CancelBut" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="CancelBut_Click" />
                </div>
            </div>
            <div class="row">
                <br />
            </div>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" OnItemCommand="RadGrid1_ItemCommand" EnableLinqExpressions="false"
            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="True" OnNeedDataSource="RadGrid1_NeedDataSource1"
            ExportSettings-FileName="EventLists" ExportSettings-IgnorePaging="true" CellSpacing="0"
            GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound">
            <GroupingSettings CaseSensitive="false" />
            <ExportSettings FileName="EventLists" IgnorePaging="True">
            </ExportSettings>
            <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="TopAndBottom" DataKeyNames="eventid,clientid">
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
                    <telerik:GridTemplateColumn AllowFiltering="true" UniqueName="eventid" HeaderText="Event ID"
                        DataField="eventid" SortExpression="eventid" FilterControlAltText="Filter eventid column">
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
                    <telerik:GridBoundColumn HeaderText="Url" DataField="url" />
                    <telerik:GridBoundColumn HeaderText="Start Date" DataField="startdate" DataType="System.DateTime" />
                    <telerik:GridBoundColumn HeaderText="End Date" DataField="enddate" DataType="System.DateTime" />
                    <telerik:GridBoundColumn HeaderText="Date Modified" DataField="datemodified" DataType="System.DateTime" />
                    <telerik:GridBoundColumn HeaderText="Date Entry" DataField="dateentry" DataType="System.DateTime" />
                </Columns>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
</asp:Content>
