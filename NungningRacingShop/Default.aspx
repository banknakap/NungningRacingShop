<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NungningRacingShop._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        img {
            display: block;
            margin: 0 auto;
        }
    </style>

    <script src="Scripts/ResponsiveSlides/responsiveslides.min.js"></script>
    <link rel="stylesheet" href="Scripts/ResponsiveSlides/demo.css" />
    <!-- Slideshow 4 -->
    <br />
    <div class="callbacks_container">

        <asp:Repeater ID="rptNotices" runat="server">
            <HeaderTemplate>
               <ul class="rslides" id="slider4">
            </HeaderTemplate>
            
                <itemtemplate>
        <li>
            <a href="Notice/NoticeDetail?notice_id=<%# Eval("notice_id") %>">
          <img style="max-height:600px;" src="<%# getImage(Eval("image").ToString()) %>" alt="">
          <p class="caption"><%# Eval("title") %></p>
            </a>
        </li>
                </itemtemplate>

                <footertemplate>
            </ul>
            </FooterTemplate>
        </asp:Repeater>


    </div>


    <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>

            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading"><%# Eval("title") %></div>
                    <div class="panel-body">
                        <a href="Product/ProductDetail?product_id=<%# Eval("product_id") %>">
                             <img ="100" src="<%# getImage(Eval("image").ToString()) %>"  style="height:150px; max-width: 240px;"/> <br>
                        </a>

                        จำนวน <%# Eval("amount") %> ชิ้น
                               <br>
                        <label><%# getFormatMoney(Eval("price").ToString()) %> ฿</label>

                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default btn-sm" Style="float: right;" CommandName="ADD_CART"
                            CommandArgument='<%# Eval("product_id") %>' ToolTip="เพิ่มลงรถเข็น" Font-Underline="true"><span class="glyphicon glyphicon-shopping-cart"></span></asp:LinkButton>
                    </div>
                </div>
            </div>

        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>


    <script>
        $(function () {
            $(".rslides").responsiveSlides();

            // Slideshow 4
            $("#slider4").responsiveSlides({
                auto: false,
                pager: false,
                nav: true,
                speed: 500,
                namespace: "callbacks",
                before: function () {
                    $('.events').append("<li>before event fired.</li>");
                },
                after: function () {
                    $('.events').append("<li>after event fired.</li>");
                }
            });

        });
    </script>
</asp:Content>
