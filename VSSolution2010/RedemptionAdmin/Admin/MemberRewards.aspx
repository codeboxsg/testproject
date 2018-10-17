<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberRewards.aspx.cs" Inherits="Redemption.MemberRewards" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/skeleton.css" rel="stylesheet" type="text/css" />
    <style>
    .box-image img {
width: 100%;
}
.promotions .box {
background: #e45317;
color: #fff;
}
.box {
	margin:15px 5px;
	-moz-box-shadow:    0px 0px 7px 0px #999;
	-webkit-box-shadow: 0px 0px 7px 0px #999;
	box-shadow:         0px 0px 7px 0px #999;
}
.box-image {
display: block;
width: 100%;
height: 168px;
position: relative;
margin: 0 auto;
overflow: hidden;
}
.promotions .box-info {
min-height: 218px;
position: relative;
}
.box-info {
padding: 0 10px 32px 10px;
}
.promotions .box-info {
min-height: 218px;
position: relative;
}
.box_button{position: absolute; bottom: 10px; left: 10px;}
 .box-info {
	padding:0 10px 32px 10px;
}

.box-info h6 {
	margin-top:5px;
}

.box-info h6 span {
	font-weight:700;
}

.box-info p {
	margin:20px 0;
}
	.promotions .box {
		background:#e45317;
		color:#fff;
	}
	.box-info
	.promotions .box-image .arrow {
		background:url(../img/sub/arrow.png) no-repeat left bottom;
	}
	
	.promotions .box-info h6 {
		font-weight:bold;
		color:#fff;
	}
	
	.promotions .box-info p {
		margin:10px 0;
	}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="sixteen columns">
            <asp:LinkButton ID="MembersBut" runat="server" OnClick="MembersBut_Click">Members</asp:LinkButton>
            &nbsp;&gt;
            <asp:HyperLink ID="UsernameHL" runat="server"></asp:HyperLink>
            &nbsp;&gt;
            <asp:Literal ID="ClientLit" runat="server"></asp:Literal>
            <h1>
                Member Claim Rewards
            </h1>
        </div>
    </div>
    <div id="main" role="main">
        <div class="container promotions">
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
                                    <img src="<%# RedemptionAdmin.Config.RewardRelativePath %><%# Eval("imagepath") %>"
                                        alt="" title="" />
                                    <div class="arrow">
                                        &nbsp;</div>
                                </div>
                                <div class="box-info">
                                    <h6>
                                        <%# Eval("name") %></h6>
                                    <%# Eval("brief") %>
                                    <p>
                                        <%# Eval("promotionname")%></p>
                                    <p>
                                        <%# Eval("description") %></p>
                                    <p>
                                        <asp:Literal ID="PointsLit" runat="server"><b>Points Required :</b>   points</asp:Literal>
                                    </p>
                                    <p>
                                        <asp:Literal ID="QtyLit" runat="server">Qty: xx available</asp:Literal></p>
                                    <div class="box_button">
                                        <asp:LinkButton ID="GoClaimsBut" runat="server" CommandArgument='<%# Eval("rewardid") %>'
                                            CssClass="button-style-2" Text="Claim" /></div>
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
