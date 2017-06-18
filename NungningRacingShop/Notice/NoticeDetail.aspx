<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="NungningRacingShop.Notice.NoticeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        img {
            display: block;
            margin: auto;
        }
    </style>
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
    <section id="output" style="margin-top: 8px;margin-left: 77px;margin-right:77px;">
        <div class="row">
            <div class="col-md-12">
                <div>
                    <a runat="server" href="~/">Home</a>
                    <span class="glyphicon glyphicon-arrow-right"></span>
                    <a id="navItem" runat="server"></a>
                    
                </div>

                <br>
                <asp:Image ID="imgNotice" runat="server" Style="height: 600px;" />
                <br>
                <br />
                <h3>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </h3>
                <hr />
                <p id="lblDesciption" runat="server"></p>
            </div>
        </div>
    </section>
</asp:Content>
