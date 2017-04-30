<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NungningRacingShop._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
img{
display: block;
margin: 0 auto;
}
    </style>

    <asp:repeater id="rptProducts" runat="server" onitemcommand="rptProducts_ItemCommand">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>

                     <div class="col-md-3">
                         <div class="panel panel-default">
                              <div class="panel-heading"> <%# Eval("title") %></div>
                       <div class="panel-body">

                        <img ="100" src="<%# getImage(Eval("image").ToString()) %>"  style="height:150px; max-width: 240px;"/> <br>
                        <label style="float: left;">เหลือ <%# Eval("amount") %> ชิ้น</label>
                           
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
