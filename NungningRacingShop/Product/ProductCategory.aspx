﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCategory.aspx.cs" Inherits="NungningRacingShop.Product.ProductCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
         img {
             display: block;
             margin: 0 auto;
         }
       
     </style>

         <a runat="server" href="~/">Home</a>
         <span class="glyphicon glyphicon-arrow-right"></span>
         <a id="navCate" runat="server" ></a>

    <asp:repeater id="rptProducts" runat="server" onitemcommand="rptProducts_ItemCommand">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>

                     <div class="col-md-3">
                         <div class="panel panel-default">
                              <div class="panel-heading"> <%# Eval("title") %></div>
                       <div class="panel-body">
                           <a href="ProductDetail?product_id=<%# Eval("product_id") %>"> 
                                <img ="100" src="<%# getImage(Eval("image").ToString()) %>"  style="height:150px; max-width: 240px;"/> <br>
                           </a>
                 
                               จำนวน <%# Eval("amount") %> ชิ้น
                               <br>
                               <label><%# getFormatMoney(Eval("price").ToString()) %> ฿</label>
                           
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default btn-sm" style="float: right;" CommandName="ADD_CART" 
                                CommandArgument='<%# Eval("product_id") %>'  ToolTip="เพิ่มลงรถเข็น" Font-Underline="true" ><span class="glyphicon glyphicon-shopping-cart"></span></asp:LinkButton>
                            </div>
                           </div>
                     </div>
              
                </ItemTemplate>
           
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:repeater>

</asp:Content>
