<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="NungningRacingShop.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <%--<link rel="stylesheet" href="Scripts/ProductGallery/dist/xzoom.css">--%>

    <link rel="stylesheet" href="Scripts/ProductGallery/css/normalize.css" />
    <link rel="stylesheet" href="Scripts/ProductGallery/css/foundation.css" />
    <link rel="stylesheet" href="Scripts/ProductGallery/css/demo.css" />
    <script src="Scripts/ProductGallery/js/vendor/modernizr.js"></script>
    <script src="Scripts/ProductGallery/js/vendor/jquery.js"></script>
    <!-- xzoom plugin here -->
    <script src="Scripts/ProductGallery/dist/xzoom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Scripts/ProductGallery/css/xzoom.css" media="all" />
    <!-- hammer plugin here -->
    <script type="text/javascript" src="Scripts/ProductGallery/hammer.js/1.0.5/jquery.hammer.min.js"></script>
    <!--[if lt IE 9]><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    <link type="text/css" rel="stylesheet" media="all" href="Scripts/ProductGallery/fancybox/source/jquery.fancybox.css" />
    <link type="text/css" rel="stylesheet" media="all" href="Scripts/ProductGallery/magnific-popup/css/magnific-popup.css" />
    <script type="text/javascript" src="Scripts/ProductGallery/fancybox/source/jquery.fancybox.js"></script>
    <script type="text/javascript" src="Scripts/ProductGallery/magnific-popup/js/magnific-popup.js"></script>





    <!-- output window start -->
    <section id="output">
        <div class="row">
            <div class="large-12 column">
                <h3>Output window</h3>
            </div>
            <div class="large-5 column">
   

                    <div class="xzoom-container">
                    <img class="xzoom2" src="Scripts/ProductGallery/images/gallery/preview/01_b_car.jpg" xoriginal="Scripts/ProductGallery/images/gallery/original/01_b_car.jpg" />
                    <div class="xzoom-thumbs">
                        
                <asp:Repeater ID="rptProductImages" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>

   
          <a href="<%# getImage(Eval("image").ToString()) %>">
                            <img class="xzoom-gallery2" width="80" src="<%# getImage(Eval("image").ToString()) %>" xpreview="<%# getImage(Eval("image").ToString()) %>" title="The description goes here"></a>
                    </ItemTemplate>
                    <FooterTemplate>
 
                    </FooterTemplate>
                </asp:Repeater>
                       
             
                    </div>
                </div>
            </div>
            <div class="large-7 column">
                <div id="xzoom2-id" style="float: right; width: 200px; height: 200px;"></div>
            </div>

            
                         <label>ชื่อสินค้า : <span class="red">*</span> </label>
                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                <label>คำอธิบาย : <span class="red">*</span> </label>
                <asp:TextBox
                    ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
                <label>หมวดหมู่ <span style="color: red;">*</span> </label>
                <br>
                <br>
                <label>ราคา : <span class="red">*</span> </label>
                <asp:TextBox placeholder="2000" ID="txtPrice" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
                <label>จำนวน : <span class="red">*</span> </label>
                <asp:TextBox placeholder="20" ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>

        </div>
    </section>

    <script src="Scripts/ProductGallery/js/foundation.min.js"></script>
    <script src="Scripts/ProductGallery/js/setup.js"></script>

</asp:Content>
