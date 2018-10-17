<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="promotions.aspx.cs" Inherits="Redemption.promotions" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner-redemption.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main">
        <div class="container products">
        	<div class="sixteen columns">
                <div class="quote-text"><div class="quote-bg1"><div class="quote-bg2">
                    Enjoy quality products and get rewarded for it at the same time with MC EduPerks!
                </div></div></div>
            </div>
            <div class="sixteen columns">
                <div class="title bg4">
                    <h4>
                        Promotions</h4>
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
                                            <%# Eval("name") %></span></h6>  <%# Eval("brief") %>
                                    <p>
                                        <%# Eval("description") %></p>
                                    <div class="box_button"><asp:LinkButton ID="GoRewardsBut" runat="server"   CommandArgument='<%# Eval("promotionid") %>' 
                                        CssClass="button-style" Text="Redeem" /></div>     
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
                                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="PromotionListView"
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
            </div>
            <div class="sixteen columns">
                <br />
            </div>
        </div>
        <!-- container -->
    </div>
</asp:Content>
