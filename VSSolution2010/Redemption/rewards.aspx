<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rewards.aspx.cs" Inherits="Redemption.rewards" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="banner columns">
            <img class="resize" src="img/banner-promotion.jpg" alt="" title="" />
        </div>
    </div>
    <div id="main" role="main">
        <div class="container promotions">
        	<div class="sixteen columns">
                <div class="quote-text"><div class="quote-bg1"><div class="quote-bg2">
                    <p>"Learning with Marshall Cavendish Education is more fun!"</p>
                </div></div></div>
            </div>
            <div class="sixteen columns">
                <div class="title bg5">
                    <h4>
                        Rewards Catalogue
                        <asp:Literal ID="PromotionNameLit" runat="server"></asp:Literal></h4>
                </div>
            </div>
            <div class="clearfix">
                <telerik:RadListView runat="server" ID="FloatedTilesListView" AllowPaging="True"
                    DataKeyNames="rewardid,promotionid" OnNeedDataSource="FloatedTilesListView_NeedDataSource"
                    OnItemCommand="GoClaimsBut_Command" OnItemDataBound="FloatedTilesListView_ItemDataBound">
                    <ItemTemplate>
                        <div class="one-third column">
                            <div class="box">
                                <div class="box-image">
                                    <img src="<%# Redemption.Config.RewardRelativePath %><%# Eval("imagepath") %>" alt=""
                                        title="" />
                                    <div class="arrow">
                                        &nbsp;</div>
                                </div>
                                <div class="box-info">
                                    <h6>
                                        <%# Eval("name") %></h6><%# Eval("brief") %>
                                    <p>
                                        <%# Eval("promotionname")%></p>
                                    <p>
                                        <%# Eval("description") %></p>
                                    <p>
                                        <asp:Literal ID="PointsLit" runat="server"><b>Points Required :</b>   points</asp:Literal>
                                    </p>
                                    <p>
                                        <asp:Literal ID="QtyLit" runat="server">Qty: xx available</asp:Literal></p>					
                                    <div class="box_button"><asp:LinkButton ID="GoClaimsBut" runat="server" CommandArgument='<%# Eval("rewardid") %>'
                                    CssClass="button-style-5" Text="Redeem" /></div>
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
                                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="FloatedTilesListView"
                                    PageSize="6" Visible='<%# Container.PageCount != 1%>'>
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
        </div>
        <!-- container -->
    </div>
</asp:Content>
