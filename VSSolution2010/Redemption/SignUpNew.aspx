<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SignUpNew.aspx.cs" Inherits="Redemption.SignUpNew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner-signup.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main">
        <div class="container">
            <div class="sixteen columns">
                <h3 class="color">
                    ABOUT MARSHALL CAVENDISH EDUCATION</h3>
                <p style="font-size:14px;">
                    At Marshall Cavendish Education, we also believe in keeping in touch with our customers
                    and adding value to their learning and teaching experience. With MCE EduPerks, you
                    can enjoy quality products and get rewarded for it at the same time.</p>
            </div>
            <div class="sixteen columns">
                <div class="title bg3">
                    <h4>
                        Sign Up as Member!</h4>
                </div>
            </div>
            <div class="eleven columns">
                <h4>
                    Parent</h4>
            </div>
            <div class="eleven columns">
                <asp:TextBox ID="MemberFirstnameTB" class="form1" placeholder="First Name" runat="server"
                    ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please enter your first name."
                    ControlToValidate="MemberFirstnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                    ValueToCompare="First Name"></asp:CompareValidator><asp:RegularExpressionValidator  
                    ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only characters and space"  Display="Dynamic"
                    ControlToValidate="MemberFirstnameTB" ValidationExpression="^[a-zA-Z_\s]*$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
            </div>
            <div class="eleven columns">
                <asp:TextBox ID="MemberLastnameTB" class="form1" placeholder="Last Name (Surname)"
                    runat="server" ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please enter your last name."
                    ControlToValidate="MemberLastnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                    ValueToCompare="Last Name (Surname)"></asp:CompareValidator><asp:RegularExpressionValidator  
                    ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only characters and space"  Display="Dynamic"
                    ControlToValidate="MemberLastnameTB" ValidationExpression="^[a-zA-Z_\s]*$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
            </div>
            <div class="eleven columns">
                <div class="form1 clearfix">
                    <label for="male" style="padding-right: 10px;">
                        Gender</label>
                    <asp:RadioButtonList ID="MemberGenderRBL" runat="server" RepeatDirection="Horizontal"
                        EnableTheming="False" Width="150px" RepeatLayout="Flow" CssClass="signup">
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
                <asp:TextBox ID="MemberNricTB" class="form1" placeholder="NRIC" runat="server" ValidationGroup="SignUpVG" MaxLength="12"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please enter your nric." Display="Dynamic"
                    ControlToValidate="MemberNricTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="NRIC"></asp:CompareValidator><asp:CustomValidator ID="ICValidateCV" ControlToValidate="MemberNricTB"
                        runat="server" ErrorMessage="e.g. S1234567E" OnServerValidate="ICValidateCV_ServerValidate" ValidationGroup="SignUpVG"></asp:CustomValidator>
            </div>
            <div class="eleven columns">
                <div class="form1 clearfix">
                    <label class="date-form columns alpha">
                        Date of Birth</label>
                    <telerik:RadDateInput ID="MemberDOBTB" runat="server" 
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
                    runat="server" ValidationGroup="SignUpVG" Rows="3" Height="60px"  MaxLength="400" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please enter your mailing address."
                    ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                    ValueToCompare="Mailing Address"></asp:CompareValidator><asp:regularexpressionvalidator
                 controltovalidate="MemberMailingAddressTB" errormessage="Maximum 400 characters are allowed." 
                            id="regComments" runat="server"   validationexpression="^[\s\S]{0,400}$" ValidationGroup="SignUpVG"></asp:regularexpressionvalidator>
            </div>
            <div class="eleven columns">
                <asp:TextBox ID="MemberPostalCodeTB" class="form1" placeholder="Postal Code" runat="server"
                    ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator8" runat="server" Display="Dynamic" ErrorMessage="Please enter your postal code."
                    ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                    ValueToCompare="Postal Code"></asp:CompareValidator><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator2" runat="server" ErrorMessage="e.g. 123456" 
                                    ControlToValidate="MemberPostalCodeTB" ValidationExpression="^\d{6}$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
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
            <hr />
            <div class="eleven columns">
                <div class="sign-up">
                    <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                    <asp:LinkButton ID="SignUpBut" runat="server" CssClass="button-style" Text="Submit &rsaquo;"
                        OnClick="SignUpBut_Click" ValidationGroup="SignUpVG" />
                </div>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
