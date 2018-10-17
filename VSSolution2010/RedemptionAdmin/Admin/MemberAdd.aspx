<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberAdd.aspx.cs" Inherits="Redemption.MemberAdd" %>

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
                Add Member</h1>
        </div>
        <div class="eleven columns">
            <h4>
                Login Details</h4>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberUsernameTB" class="form1" placeholder="Email (Username)" runat="server"
                ValidationGroup="SignUpVG"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Please enter your email address. "
                ControlToValidate="MemberUsernameTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                ValueToCompare="Email (Username)" CssClass="failureNotification" Display="Dynamic"></asp:CompareValidator><asp:RegularExpressionValidator
                    ID="EmailREV" runat="server" ControlToValidate="MemberUsernameTB" ValidationGroup="SignUpVG"
                    Display="Dynamic" ErrorMessage="e.g. someone@email.com" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,3}$"
                    CssClass="failureNotification" >
                </asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server" ErrorMessage="Please enter Email (Username)." Display="Dynamic" ControlToValidate="MemberUsernameTB"
                     ValidationGroup="SignUpVG"  CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberPasswordTB" class="form1" placeholder="Password" runat="server"
                ValidationGroup="SignUpVG"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="MemberPasswordTB"
                ValidationGroup="SignUpVG" Display="Dynamic" ErrorMessage="Please enter at least 8 characters. 1 must be a number and 1 must be an alphabet."
                ValidationExpression="^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"   CssClass="failureNotification">
            </asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                    runat="server" ErrorMessage="Please enter Password." Display="Dynamic" ControlToValidate="MemberPasswordTB"
                     ValidationGroup="SignUpVG"  CssClass="failureNotification"></asp:RequiredFieldValidator>
            <%--1 alpha, 1 numeric, 1 upper "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"--%>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberPassword2TB" class="form1" placeholder="Re-enter Password"
                runat="server" ValidationGroup="SignUpVG"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator10" runat="server" ErrorMessage="Passwords do not match. Please check."
                ControlToValidate="MemberPassword2TB" ValidationGroup="SignUpVG" Operator="Equal"
                ControlToCompare="MemberPasswordTB" CssClass="failureNotification">
            </asp:CompareValidator>
        </div>
        <hr />
        <div class="eleven columns">
            <div class="disclaimer clearfix">
                <asp:CheckBox ID="MemberDisclaimerCB" runat="server" Text="Disclaimer" />
                <span>I agree to the <a href="terms.aspx" target="_blank">terms and conditions</a></span>
            </div>
            <div class="newsletter clearfix">
                <asp:CheckBox ID="MemberNewsletterCB" runat="server" CssClass="check" Text="Receive Newsletter" />
                <span>Receive Newsletter</span>
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
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please enter your first name."  CssClass="failureNotification"
                ControlToValidate="MemberFirstnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                ValueToCompare="First Name"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3"  CssClass="failureNotification"
                    runat="server" ErrorMessage="Please enter your first name." Display="Dynamic" ControlToValidate="MemberFirstnameTB"
                     ValidationGroup="SignUpVG"></asp:RequiredFieldValidator><asp:RegularExpressionValidator  CssClass="failureNotification"
                    ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only characters and space"  Display="Dynamic"
                    ControlToValidate="MemberFirstnameTB" ValidationExpression="^[a-zA-Z_\s]*$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberLastnameTB" class="form1" placeholder="Last Name (Surname)"
                runat="server" ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please enter your last name."  CssClass="failureNotification"
                ControlToValidate="MemberLastnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                ValueToCompare="Last Name (Surname)"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator4"  CssClass="failureNotification"
                    runat="server" ErrorMessage="Please enter your last name."  ControlToValidate="MemberLastnameTB" Display="Dynamic"
                     ValidationGroup="SignUpVG"></asp:RequiredFieldValidator><asp:RegularExpressionValidator  CssClass="failureNotification"
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select your gender."  CssClass="failureNotification"
                ControlToValidate="MemberGenderRBL" ValidationGroup="SignUpVG"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberContactnoTB" class="form1" placeholder="Contact No" runat="server"
                ValidationGroup="SignUpVG" MaxLength="12"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please enter your contact no." CssClass="failureNotification"
                ControlToValidate="MemberContactnoTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                ValueToCompare="Contact No" ></asp:CompareValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="e.g. 91234567 or 612345678" Display="Dynamic" CssClass="failureNotification"
                    ControlToValidate="MemberContactnoTB" ValidationExpression="^\d{8}$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator7"  CssClass="failureNotification"
                    runat="server" ErrorMessage="Please enter your Contact No."  ControlToValidate="MemberContactnoTB" Display="Dynamic"
                     ValidationGroup="SignUpVG"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberNricTB" class="form1" placeholder="NRIC" runat="server" ValidationGroup="SignUpVG"
                MaxLength="12"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please enter your nric." Display="Dynamic"  CssClass="failureNotification"
                ControlToValidate="MemberNricTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                ValueToCompare="NRIC"></asp:CompareValidator><asp:CustomValidator ID="ICValidateCV"
                    ControlToValidate="MemberNricTB" runat="server" ErrorMessage="e.g. S1234567E" Display="Dynamic" CssClass="failureNotification"
                    OnServerValidate="ICValidateCV_ServerValidate"></asp:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator8"  CssClass="failureNotification"
                    runat="server" ErrorMessage="Please enter your NRIC."  ControlToValidate="MemberNricTB" Display="Dynamic"
                     ValidationGroup="SignUpVG"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <div class="form1 clearfix">
                <label class="date-form columns alpha">
                    Date of Birth</label>
                <telerik:RadDateInput ID="MemberDOBTB" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                    MinDate="1930-01-01" ValidationGroup="SignUpVG">
                </telerik:RadDateInput>
                DD/MM/YYYY
            </div>
        </div>
        <div class="four columns">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your date of birth."
                ControlToValidate="MemberDOBTB" ValidationGroup="SignUpVG"  Display="Dynamic" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberMailingAddressTB" class="form1" placeholder="Mailing Address"
                runat="server" ValidationGroup="SignUpVG" Rows="3" Height="60px" MaxLength="400"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please enter your mailing address."
                ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic" 
                ValueToCompare="Mailing Address"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter your Mailing Address."
                ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG"  Display="Dynamic" CssClass="failureNotification"></asp:RequiredFieldValidator><asp:regularexpressionvalidator
                 controltovalidate="MemberMailingAddressTB" errormessage="Maximum 400 characters are allowed." 
                            id="regComments" runat="server"  CssClass="failureNotification" validationexpression="^[\s\S]{0,400}$" ValidationGroup="SignUpVG"></asp:regularexpressionvalidator>
    
        </div>
        <div class="eleven columns">
            <asp:TextBox ID="MemberPostalCodeTB" class="form1" placeholder="Postal Code" runat="server"
                ValidationGroup="SignUpVG" MaxLength="6"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator8" runat="server" Display="Dynamic" ErrorMessage="Please enter your postal code."
                ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG" Operator="NotEqual"  CssClass="failureNotification"
                ValueToCompare="Postal Code"></asp:CompareValidator><asp:RegularExpressionValidator CssClass="failureNotification"  Display="Dynamic"
                    ID="RegularExpressionValidator2" runat="server" ErrorMessage="e.g. 123456" ControlToValidate="MemberPostalCodeTB"
                    ValidationExpression="^\d{6}$" ValidationGroup="SignUpVG"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter your postal code."
                ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG"  Display="Dynamic" CssClass="failureNotification"></asp:RequiredFieldValidator>
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
                    Gender
                </label>
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
                <telerik:RadDateInput ID="ChildDobTB" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                    MinDate="1930-01-01" ValidationGroup="SignUpVG">
                </telerik:RadDateInput>
                DD/MM/YYYY
            </div>
        </div>
        <hr />
        <div class="eleven columns">
            <div class="sign-up">
                <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                <asp:LinkButton ID="SignUpBut" runat="server" CssClass="button-style" Text="Submit"
                    OnClick="SignUpBut_Click" ValidationGroup="SignUpVG" />
            </div>
        </div>
    </div>
    <!-- container -->
</asp:Content>
