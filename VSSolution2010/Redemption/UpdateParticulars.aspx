<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdateParticulars.aspx.cs" Inherits="Redemption.UpdateParticulars" %>

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
                        <li class="nav-one"><a href="claimpoints.aspx">CLAIM POINTS</a></li>
                        <li class="nav-two"><a href="status.aspx">REWARDS &amp; POINTS</a></li>
                        <li class="nav-four last"><a href="#" class="current">UPDATE PARTICULARS</a></li>
                    </ul>
                    <div class="list-wrap">
                        <div id="tabs1">
                            <div class="eleven columns">
                                <h4>
                                    Parent</h4>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberFirstnameTB" class="form1" placeholder="First Name" runat="server"
                                    ValidationGroup="SignUpVG" Enabled="false" CssClass="form1" MaxLength="60"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please enter your first name."
                                    ControlToValidate="MemberFirstnameTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                                    ValueToCompare="First Name"></asp:CompareValidator>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberLastnameTB" class="form1" placeholder="Last Name (Surname)"
                                    runat="server" ValidationGroup="SignUpVG"  Enabled="false" CssClass="form1" MaxLength="60"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please enter your last name."
                                    ControlToValidate="MemberLastnameTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                                    ValueToCompare="Last Name (Surname)"></asp:CompareValidator>
                            </div>
                            <div class="eleven columns">
                                <div class="form1 clearfix">
                                    <label for="male" style="padding-right: 10px;">
                                        Gender</label>
                                    <asp:RadioButtonList ID="MemberGenderRBL" runat="server" RepeatDirection="Horizontal"
                                        EnableTheming="False" Width="150px" RepeatLayout="Flow" CssClass="signup"  Enabled="false">
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="0">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="four columns">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select your gender."
                                    ControlToValidate="MemberGenderRBL" ValidationGroup="SignUpVG"></asp:RequiredFieldValidator>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberContactnoTB" class="form1" placeholder="Contact No" runat="server"
                                    ValidationGroup="SignUpVG" MaxLength="12"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please enter your contact no."
                                    ControlToValidate="MemberContactnoTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                                    ValueToCompare="Contact No" Display="Dynamic"></asp:CompareValidator><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="e.g. 91234567 or 612345678" 
                                    ControlToValidate="MemberContactnoTB" ValidationExpression="^\d{8}$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberNricTB" class="form1" placeholder="NRIC" runat="server" ValidationGroup="SignUpVG" MaxLength="12"  Enabled="false" CssClass="form1"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please enter your nric."
                                    ControlToValidate="MemberNricTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                                    ValueToCompare="NRIC"></asp:CompareValidator><asp:CustomValidator ID="ICValidateCV"
                                        runat="server" ErrorMessage="e.g. S1234567E" OnServerValidate="ICValidateCV_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="eleven columns">
                                <div class="form1 clearfix">
                                    <label class="date-form columns alpha">
                                        Date of Birth</label>
                                    <telerik:RadDateInput ID="MemberDOBTB" runat="server" Enabled="false" 
                                    DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" MinDate="1930-01-01"
                                    BackColor="#ECF4F7" ValidationGroup="SignUpVG">
                                    </telerik:RadDateInput>
                                    DD/MM/YYYY
                                </div>
                            </div>
                            <div class="four columns">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your date of birth."
                                    ControlToValidate="MemberDOBTB" ValidationGroup="SignUpVG"></asp:RequiredFieldValidator>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberMailingAddressTB" class="form1" placeholder="Mailing Address"
                                    runat="server" ValidationGroup="SignUpVG" Rows="3" Height="60px" MaxLength="400" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please enter your mailing address."
                                    ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                                    ValueToCompare="Mailing Address"></asp:CompareValidator><asp:regularexpressionvalidator
                 controltovalidate="MemberMailingAddressTB" errormessage="Maximum 400 characters are allowed." 
                            id="regComments" runat="server"  validationexpression="^[\s\S]{0,400}$" ValidationGroup="SignUpVG"></asp:regularexpressionvalidator>
                            </div>
                            <div class="eleven columns">
                                <asp:TextBox ID="MemberPostalCodeTB" class="form1" placeholder="Postal Code" runat="server"
                                    ValidationGroup="SignUpVG" MaxLength="6"></asp:TextBox>
                            </div>
                            <div class="four columns">
                                <asp:CompareValidator ID="CompareValidator8" runat="server" Display="Dynamic" ErrorMessage="Please enter your postal code."
                                    ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                                    ValueToCompare="Postal Code"></asp:CompareValidator><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator2" runat="server" ErrorMessage="e.g. 123456" 
                                    ControlToValidate="MemberPostalCodeTB" ValidationExpression="^\d{6}$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="eleven columns">
                        <h4>
                            Child</h4>
                    </div>
                    <div class="eleven columns">
                        <asp:TextBox ID="ChildFirstnameTB" class="form1 bg" placeholder="First Name" runat="server"
                            ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
                    </div>
                    <div class="eleven columns">
                        <asp:TextBox ID="ChildLastnameTB" class="form1 bg" placeholder="Last Name (Surname)"
                            runat="server" ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
                    </div>
                    <div class="eleven columns">
                        <div class="form1 bg clearfix">
                            <label for="male">
                                Gender </label>
                            <asp:RadioButtonList ID="ChildGenderRBL" runat="server" RepeatDirection="Horizontal"
                                EnableTheming="False" Width="150px" RepeatLayout="Flow" CssClass="signup">
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="0">Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="eleven columns">
                        <div class="form1 bg clearfix">
                            <label class="date-form columns alpha">
                                Date of Birth</label>
                            <telerik:RadDateInput ID="ChildDobTB" runat="server" 
                                DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" MinDate="1930-01-01"
                            BackColor="#f7f2ec" ValidationGroup="SignUpVG">
                            </telerik:RadDateInput>
                            DD/MM/YYYY
                        </div>
                    </div>
                    <hr class="style1" />
                    <div class="eleven columns">
                        <div class="sign-up">
                            <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                            <asp:LinkButton ID="UpdateBut" runat="server" CssClass="button-style" Text="Submit &rsaquo;"
                                ValidationGroup="SignUpVG" OnClick="UpdateBut_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
