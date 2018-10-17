<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SignUp.aspx.cs" Inherits="Redemption.SignUp" %>

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
    <div id="main" role="main" class="sign_up">
        <div class="container">
            <div class="sixteen columns">
                <div class="quote-text">
                    <div class="quote-bg1">
                        <div class="quote-bg2">
                            <p>"It's time to make the brighter choice for you and your family! Gain <br/>MC EduPerks
                            points with every purchase of our quality products and redeem your favourite gifts!"</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sixteen columns" id="signuppage">
                <div class="title bg3">
                    <h4>
                        Sign Up as Member!</h4>
                </div>
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
                        CssClass="failureNotification">
                    </asp:RegularExpressionValidator>
            </div>
            <div class="eleven columns">
                <asp:TextBox ID="MemberPasswordTB" class="form1" placeholder="Password" runat="server" Textmode="password"
                    ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MemberPasswordTB"
                    ValidationGroup="SignUpVG" Display="Dynamic" ErrorMessage="Please enter at least 8 characters. 1 must be a number and 1 must be an alphabet."
                    ValidationExpression="^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$" CssClass="failureNotification">
                </asp:RegularExpressionValidator>
                <%--1 alpha, 1 numeric, 1 upper "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])[A-Za-z0-9]{8,}$"--%>
            </div>
            <div class="eleven columns">
                <asp:TextBox ID="MemberPassword2TB" class="form1" placeholder="Re-enter Password" Textmode="password"
                    runat="server" ValidationGroup="SignUpVG"></asp:TextBox>
            </div>
            <div class="four columns">
                <asp:CompareValidator ID="CompareValidator10" runat="server" ErrorMessage="Passwords do not match. Please check."
                    ControlToValidate="MemberPassword2TB" ValidationGroup="SignUpVG" Operator="Equal"
                    ControlToCompare="MemberPasswordTB" CssClass="failureNotification">
                </asp:CompareValidator>
            </div>
			<hr/>
			<div class="eleven columns">
                <div class="disclaimer clearfix">
                    <asp:CheckBox ID="MemberDisclaimerCB" runat="server" Text="Disclaimer" 
                        />
                    <span>I have read and agreed to the <a href="terms.aspx" target="_blank">terms and conditions</a>.</span>
                   </div>
                <div class="newsletter clearfix">
                    <asp:CheckBox ID="MemberNewsletterCB" runat="server" CssClass="check" Text="Receive Newsletter" />
                    <span>I would like to receive the latest events and promotions.</span>
                </div>
            </div>    <div class="four columns">        </div> 
            <div class="eleven columns" style="margin-bottom:10px;">
                <div class="sign-up">
                     <span class="failureNotification"><asp:Literal ID="ErrorLit" runat="server" ></asp:Literal></span>
                    <asp:LinkButton ID="SignUpBut" runat="server" CssClass="button-style" Text="Next &rsaquo;"
                        OnClick="SignUpBut_Click" ValidationGroup="SignUpVG" />
                </div>
            </div>
			<hr/>
            <div class="sixteen columns">
				<div class="title bg3">
					<h4 id="howtoredeem">
						How to Redeem</h4>
				</div>
                <p>
                    Follow these simple steps to make your redemptions TODAY!<br/><br/>
					<img class="resize" src="img/banner-signup.gif" alt="" title=""/></p>
                    <ul>
                        <li>Step 1 - REGISTER: Fill in your email address (will be reflected as your user name)
                            and enter a password. </li>
                        <li>Step 2 – PARTICULARS: Complete the registration form that follows by filling in
                            your particulars.</li>
                        <li>Step 3 – UPLOAD RECEIPTS: Upload the scanned receipts* of your purchases from
                            bookstores** to your account. (Please ensure that the receipts are legible and reflect
                            the store name, date of purchase and item(s) purchased.)</li>
                        <li>Step 4 – SELECT REWARD: Select the various rewards available for redemption and
                            click ‘Redeem’.</li>
                        <li>Step 5 – REDEEM: Check that your points balance is sufficient and click ‘Submit’
                            to redeem the selected item(s).</li>
                        <li>Step 6 – COLLECT: An email will be sent to confirm your redemption with the redemption
                            details</li>
                    </ul>
				<p>
                    *Please allow three working days for your points to be updated.<br />
					**Participating merchants includes: <a target="_blank" href="http://www.noqstore.asia">NOQ Store</a>, POPULAR and Times The Bookshop outlets.
                </p>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
