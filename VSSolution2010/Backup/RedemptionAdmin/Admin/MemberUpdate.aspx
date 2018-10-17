<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberUpdate.aspx.cs" Inherits="Redemption.MemberUpdate" %>

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
                Update Member
            </h1>
        </div>
        <div class="eleven columns">
            <h4>
                Parent</h4>
        </div>
        <div class="eleven columns">
            First Name<br />
            <asp:TextBox ID="MemberFirstnameTB" class="form1" placeholder="First Name" runat="server"
                ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please enter your first name."
                ControlToValidate="MemberFirstnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" CssClass="failureNotification"
                ValueToCompare="First Name" Display="Dynamic"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ErrorMessage="Please enter your first name." Display="Dynamic" ControlToValidate="MemberFirstnameTB"
                     ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3" runat="server" ErrorMessage="Only characters and space"  Display="Dynamic"
                    ControlToValidate="MemberFirstnameTB" ValidationExpression="^[a-zA-Z_\s]*$" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RegularExpressionValidator>
            </div>
        <div class="eleven columns">
            Last Name<br />
            <asp:TextBox ID="MemberLastnameTB" class="form1" placeholder="Last Name (Surname)"
                runat="server" ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Please enter your last name."
                ControlToValidate="MemberLastnameTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                ValueToCompare="Last Name (Surname)" CssClass="failureNotification"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server" ErrorMessage="Please enter your last name."  ControlToValidate="MemberLastnameTB"
                     ValidationGroup="SignUpVG" Display="Dynamic" CssClass="failureNotification"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only characters and space"  Display="Dynamic"
                    ControlToValidate="MemberLastnameTB" ValidationExpression="^[a-zA-Z_\s]*$" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RegularExpressionValidator>
        </div>
        <div class="eleven columns">
            <div class="form1 clearfix">
                <label for="male" style="padding-right: 10px;">
                    Gender</label><br />
                <asp:RadioButtonList ID="MemberGenderRBL" runat="server" RepeatDirection="Horizontal"
                    EnableTheming="False" Width="150px" RepeatLayout="Flow" CssClass="signup">
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="0">Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="four columns">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select your gender."
                ControlToValidate="MemberGenderRBL" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            Contact No<br />
            <asp:TextBox ID="MemberContactnoTB" class="form1" placeholder="Contact No" runat="server"
                ValidationGroup="SignUpVG" MaxLength="12"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Please enter your contact no."
                ControlToValidate="MemberContactnoTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                ValueToCompare="Contact No" Display="Dynamic" CssClass="failureNotification"></asp:CompareValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" ErrorMessage="e.g. 91234567 or 612345678"  Display="Dynamic"
                    ControlToValidate="MemberContactnoTB" ValidationExpression="^\d{8}$" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server" ErrorMessage="Please enter your contact no."  ControlToValidate="MemberContactnoTB" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            NRIC<br />
            <asp:TextBox ID="MemberNricTB" class="form1" placeholder="NRIC" runat="server" ValidationGroup="SignUpVG"
                MaxLength="12"></asp:TextBox>
        </div>
        <div class="four columns">
             <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Please enter your nric."
                ControlToValidate="MemberNricTB" ValidationGroup="SignUpVG" Operator="NotEqual" Display="Dynamic"
                ValueToCompare="NRIC" CssClass="failureNotification"></asp:CompareValidator><asp:CustomValidator ID="ICValidateCV" Display="Dynamic"
                    ControlToValidate="MemberNricTB" runat="server" ErrorMessage="e.g. S1234567E" ValidationGroup="SignUpVG"
                    OnServerValidate="ICValidateCV_ServerValidate" CssClass="failureNotification"></asp:CustomValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                    runat="server" ErrorMessage="Please enter your nric."  ControlToValidate="MemberNricTB" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            <div class="form1 clearfix">
                <label class="date-form columns alpha">
                    Date of Birth</label><br />
                <telerik:RadDateInput ID="MemberDOBTB" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                    MinDate="1930-01-01" ValidationGroup="SignUpVG">
                </telerik:RadDateInput>
                DD/MM/YYYY
            </div>
        </div>
        <div class="four columns">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your date of birth."
                ControlToValidate="MemberDOBTB" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <div class="eleven columns">
            Address<br />
            <asp:TextBox ID="MemberMailingAddressTB" class="form1" placeholder="Mailing Address"
                runat="server" ValidationGroup="SignUpVG" Rows="3" Height="60px" MaxLength="400"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="Please enter your mailing address." Display="Dynamic"
                ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                ValueToCompare="Mailing Address" CssClass="failureNotification"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                    runat="server" ErrorMessage="Please enter your mailing address."  ControlToValidate="MemberMailingAddressTB" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator><asp:regularexpressionvalidator
                 controltovalidate="MemberMailingAddressTB" errormessage="Maximum 400 characters are allowed." 
                            id="regComments" runat="server"  CssClass="failureNotification" validationexpression="^[\s\S]{0,400}$" ValidationGroup="SignUpVG"></asp:regularexpressionvalidator>
        </div>
        <div class="eleven columns">
            Postal Code<br />
            <asp:TextBox ID="MemberPostalCodeTB" class="form1" placeholder="Postal Code" runat="server"
                ValidationGroup="SignUpVG" MaxLength="6"></asp:TextBox>
        </div>
        <div class="four columns">
            <asp:CompareValidator ID="CompareValidator8" runat="server" Display="Dynamic" ErrorMessage="Please enter your postal code."
                ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG" Operator="NotEqual"
                ValueToCompare="Postal Code" CssClass="failureNotification"></asp:CompareValidator><asp:RegularExpressionValidator  Display="Dynamic"
                    ID="RegularExpressionValidator2" runat="server" ErrorMessage="e.g. 123456" ControlToValidate="MemberPostalCodeTB"
                    ValidationExpression="^\d{6}$" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                    runat="server" ErrorMessage="Please enter your postal code."  ControlToValidate="MemberPostalCodeTB" ValidationGroup="SignUpVG" CssClass="failureNotification"></asp:RequiredFieldValidator>
        </div>
        <hr />
        <div class="eleven columns">
            <h4>
                Child</h4>
        </div>
        <div class="eleven columns">
            First Name<br />
            <asp:TextBox ID="ChildFirstnameTB" class="form1 bg" placeholder="First Name" runat="server"
                ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
        </div>
        <div class="eleven columns">
            Last Name<br />
            <asp:TextBox ID="ChildLastnameTB" class="form1 bg" placeholder="Last Name (Surname)"
                runat="server" ValidationGroup="SignUpVG" MaxLength="60"></asp:TextBox>
        </div>
        <div class="eleven columns">
            <div class="form1 bg clearfix">
                <label for="male">
                    Gender
                </label>
                <br />
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
                <br />
                <telerik:RadDateInput ID="ChildDobTB" runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                    MinDate="1930-01-01" ValidationGroup="SignUpVG">
                </telerik:RadDateInput>
                DD/MM/YYYY
            </div>
        </div>
        <hr class="style1" />
        <div class="eleven columns">
            <div class="sign-up">
                <asp:Literal ID="ErrorLit" runat="server"></asp:Literal>
                <asp:LinkButton ID="UpdateBut" runat="server" Text="Submit" 
                    OnClick="UpdateBut_Click" ValidationGroup="SignUpVG" />
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
