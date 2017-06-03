<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="NungningRacingShop.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <%--<link rel="stylesheet" href="../Scripts/ProductGallery/dist/xzoom.css">--%>

    <link rel="stylesheet" href="../Scripts/ProductGallery/css/normalize.css" />
    <link rel="stylesheet" href="../Scripts/ProductGallery/css/foundation.css" />
    <%--<link rel="stylesheet" href="../Scripts/ProductGallery/css/demo.css" />--%>
    <script src="../Scripts/ProductGallery/js/vendor/modernizr.js"></script>
    <script src="../Scripts/ProductGallery/js/vendor/jquery.js"></script>
    <!-- xzoom plugin here -->
    <script src="../Scripts/ProductGallery/dist/xzoom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Scripts/ProductGallery/css/xzoom.css" media="all" />
    <!-- hammer plugin here -->
    <script type="text/javascript" src="../Scripts/ProductGallery/hammer.js/1.0.5/jquery.hammer.min.js"></script>
    <!--[if lt IE 9]><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    <link type="text/css" rel="stylesheet" media="all" href="../Scripts/ProductGallery/fancybox/source/jquery.fancybox.css" />
    <link type="text/css" rel="stylesheet" media="all" href="../Scripts/ProductGallery/magnific-popup/css/magnific-popup.css" />
    <script type="text/javascript" src="../Scripts/ProductGallery/fancybox/source/jquery.fancybox.js"></script>
    <script type="text/javascript" src="../Scripts/ProductGallery/magnific-popup/js/magnific-popup.js"></script>

    <script type="text/javascript">

        function isNumeric(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));

            if ((charCode >= 48 && charCode <= 57) || charCode == 8) {
                return true;
            }
            //alert("Enter numerals only in this field.");
            return false;
        }

        function isAlphabet(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));

            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 3585 && charCode <= 3641) || (charCode >= 3648 && charCode <= 3661) || charCode == 8 || charCode == 32) {
                return true;
            }
            //alert(charCode);
            return false;
        }
    </script>





    <!-- output window start -->
    <section id="output" style="margin-top: 5%">
        <div class="row">
            <div>
                <a runat="server" href="~/">Home</a>
                <span class="glyphicon glyphicon-arrow-right"></span>
                <a id="navCate" runat="server" ></a>
                <span class="glyphicon glyphicon-arrow-right"></span>
                <a id="navProduct" runat="server"></a>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 id="lblProductName" runat="server"></h3>


                    <div class="large-12 column">
                    </div>
                </div>
                <div class="panel-body">
                    <div class="large-5 column">
                        <div class="xzoom-container">
                            <img class="xzoom2" id="xzoom_magnific" runat="server" />
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


                        <div align="right">
                            <label>จำนวน </label>
                            <asp:TextBox placeholder="20" Style="text-align: right;" ID="txtAmount" CssClass="form-control" Width="100px" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
                            <br />
                            <asp:LinkButton ID="btnSend" runat="server" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnBuy_Click"> 
                                 สั่งซื้อ <span class="glyphicon glyphicon-shopping-cart"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="large-7 column">
                        <div class="large-" alight="left">
                            <label>ราคาสุทธิ </label> <span style='color:#d9534f;font-size:x-large' id="lblPrice" runat="server">ราคาสุทธิ </span>
                        </div>
                        <br />
                        <label>คุณสมบัตร</label>
                        <hr>
                        <p id="divDescription" runat="server">
                        </p>
                        <br>
                    </div>



                </div>
            </div>
        </div>
    </section>

    <script src="../Scripts/ProductGallery/js/foundation.min.js"></script>
    <script src="../Scripts/ProductGallery/js/setup.js"></script>

</asp:Content>
