<%@ Page Title="MC EduPerks" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Redemption._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner2.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main" class="home_style">
        <div class="container">
            <div class="six columns taglines home">
                <h3 class="color" style="font-size:24px;">
                    MC EduPerks: A Brighter Choice</h3>
                <p style="font-size:12px;">
                    Choose quality educational products and enjoy even more benefits with MC EduPerks! At Marshall Cavendish Education , we believe in adding value to our customers' learning and teaching experience, so we are giving you more! With MC EduPerks, it is now easier to make the brighter choice for the whole family!
					Find out how <a href="signup.aspx#howtoredeem">here</a>.</p>
            </div>
            <div class="ten columns">
                <div class="quote-text"><div class="quote-bg1"><div class="quote-bg2">
                    <p>"Preferred Assessment Books from the Leading Textbook Publisher."</p>
                </div></div></div>
            </div>
            <div class="sixteen columns">
                <div class="title bg1">
                    <h4>
                        Highlights</h4>
                </div>
            </div>
                 <div class="clearfix">
                <telerik:RadListView runat="server" ID="EventListView" AllowPaging="True"
                    DataKeyNames="eventid,url" OnNeedDataSource="EventListView_NeedDataSource"
        
                         onitemdatabound="EventListView_ItemDataBound">
                    <ItemTemplate>
                        <div class="one-third column">
                            <div class="box brand">
                                <div class="box-image">
                                    <img src="<%# Redemption.Config.EventRelativePath %><%# Eval("imagepath") %>" alt="" title="" />
                                    <div class="arrow">
                                        &nbsp;</div>
                                </div>
                                <div class="box-info">
                                    <h6>
                                        <span>
                                            <%# Eval("name") %></span></h6>
                                            <%# Eval("brief") %>
                                    <p>
                                        <%# Eval("description") %></p>
                                   <div class="box_button"> <asp:HyperLink Target="_blank"  Class="button-style" ID="GoEventsHL" runat="server">More Info</asp:HyperLink></div>
                                        
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="RadListView RadListView_<%# Container.Skin %>">
                            <div class="rlvEmpty">
                                There are no items to be displayed.</div>
                        </div>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <div class="RadListView RadListViewFloated RadListView_<%# Container.Skin %>" dir="ltr">
                            <div class="rlvFloated rlvAutoScroll">
                                <div id="itemPlaceholder" runat="server">
                                </div>
                            </div>
                           
                            <div class="sixteen columns" dir="rtl">
                       
                                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="EventListView"
                                    PageSize="3" Visible='<%# Container.PageCount != 1%>'>
                                <Fields>
                                        <asp:TemplatePagerField>
                                            <PagerTemplate>
                                                <span style="display: block; padding: 0px 5px;" dir="rtl"></span>
                                            </PagerTemplate>
                                        </asp:TemplatePagerField>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowNextPageButton="false"
                                            PreviousPageText="Prev"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField ButtonCount="3"></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ShowLastPageButton="False" ShowPreviousPageButton="false">
                                        </asp:NextPreviousPagerField>
                                        <asp:TemplatePagerField>
                                            <PagerTemplate>
                                            </PagerTemplate>
                                        </asp:TemplatePagerField>
                                    </Fields>
                                </asp:DataPager>
                                <br />
                            </div>
                        </div>
                    </LayoutTemplate>
                </telerik:RadListView>
                <br />
            </div>
           
            <div class="sixteen columns">
                <div class="title bg4">
                    <h4>
                        Latest Promotions</h4>
                </div>
            </div>
            <div class="clearfix">
                <telerik:RadListView runat="server" ID="PromotionListView" AllowPaging="True"
                    DataKeyNames="promotionid" OnNeedDataSource="PromotionListView_NeedDataSource"
                     OnItemCommand="GoRewardsBut_Command">
                    <ItemTemplate>
                        <div class="one-third column">
                            <div class="box brand">
                                <div class="box-image">
                                    <img src="<%# Redemption.Config.PromoRelativePath %><%# Eval("imagepath") %>" alt="" title="" />
                                    <div class="arrow">
                                        &nbsp;</div>
                                </div>
                                <div class="box-info">
                                    <h6>
                                        <span>
                                            <%# Eval("name") %></span></h6>
                                              <%# Eval("brief") %>
                                    <p>
                                        <%# Eval("description") %></p>
                                   
                                         
                                     <div class="box_button"><asp:LinkButton ID="GoRewardsBut" runat="server"   CommandArgument='<%# Eval("promotionid") %>' 
                                        CssClass="button-style" Text="Redeem" />  </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="RadListView RadListView_<%# Container.Skin %>">
                            <div class="rlvEmpty">
                                There are no items to be displayed.</div>
                        </div>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <div class="RadListView RadListViewFloated RadListView_<%# Container.Skin %>" dir="ltr">
                            <div class="rlvFloated rlvAutoScroll">
                                <div id="itemPlaceholder" runat="server">
                                </div>
                            </div>
                           
                            <div class="sixteen columns" dir="rtl">
                            <a href="promotions.aspx">View more</a>
                                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="PromotionListView"
                                    PageSize="3" Visible='<%# Container.PageCount != 1%>'>
                                    <Fields>
                                      
                                    </Fields>
                                </asp:DataPager>
                                <br />
                            </div>
                        </div>
                    </LayoutTemplate>
                </telerik:RadListView>
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
