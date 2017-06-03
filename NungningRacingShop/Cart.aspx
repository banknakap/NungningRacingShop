<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="NungningRacingShop.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        img {
            display: block;
            margin: 0 auto;
        }
    </style>
    <h2>รายการสินค้าในรถเข็น</h2>
     <label id="lbl_message" runat="server"></label>
    <asp:repeater id="rptProducts" runat="server" onitemcommand="rptProducts_ItemCommand">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>

                     <div class="col-md-3">
                         <div class="panel panel-default">
                              <div class="panel-heading"> <%# Eval("title") %></div>
                       <div class="panel-body" >
                           
                        <img ="100" src="<%# getImage(Eval("image").ToString()) %>"  style="height:150px; max-width: 240px;"/> <br>
                          
                           <div>
                        จำนวน <%# Eval("cart_amount") %> ชิ้น
                               <br>
                               <label><%# getFormatMoney(Eval("sum_price").ToString()) %> ฿</label>
                           
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-sm" style="float: right;" CommandName="DEL_CART" 
                                CommandArgument='<%# Eval("product_id") %>' OnClientClick="return confirm('คุณต้องการลบจริงหรือไม่ จริงหรือไม่');"  ToolTip="ลบ" Font-Underline="true" ><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                              
                             <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-default btn-sm" style="float: right;" CommandName="EDIT_CART" 
                                CommandArgument='<%# Eval("product_id") %>'   ToolTip="เพิ่มจำนวน" Font-Underline="true" ><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                 
                          </div>
                            </div>
                           </div>
                     </div>
              
                </ItemTemplate>
           
                <FooterTemplate>
                    </div>
                    <label>ราคาสุทธิ <%# getFormatMoney(total_price.ToString()) %> ฿</label>
                </FooterTemplate>
            </asp:repeater>

    <div id="submit_div" runat="server" class="row">
        <div class="col-md-6" style="float: right;">
             <div class="input-group" >
        <span class="input-group-addon">ที่อยู่</span>
        <asp:TextBox ID="txtAddress" style="width:100%" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
             <asp:Button ID="btnSend" style="float: right;" runat="server" Text="สั่งซื้อ" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
        </div>
    </div>


</asp:Content>
