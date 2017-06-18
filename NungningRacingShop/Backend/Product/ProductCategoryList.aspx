<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ProductCategoryList.aspx.cs" Inherits="NungningRacingShop.Backend.Product.ProductCategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
    function SetTarget() {
        originalTarget = document.forms[0].target;
        document.forms[0].target='_blank';
        window.setTimeout("document.forms[0].target=originalTarget;",300);
        return true;
    }
</script>
       <label>ชื่อหมวดหมู่สินค้า : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
    
    <asp:Button ID="btnSend" runat="server" Text="ค้นหา" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
    <a class="btn btn-default btn-lg submit-btn" runat="server" href="~/Backend/Product/ProductCategoryAdd">เพิ่มหมวดหมู่</a>

      <asp:Repeater ID="rptProductCategory" runat="server" OnItemCommand="rptProductCategory_ItemCommand">
                <HeaderTemplate>
                    <table class="tableScoreReport">
                        <thead>
                            <tr>
                                <th style="width: 5%; text-align: center">ลำดับ</th>
                                 <th style="width: 5%; text-align: center">หมวดหมู่</th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td><%# Container.ItemIndex %></td>
                        <td><%# Eval("title") %></td>
                        <td><%# Eval("description") %></td>
                            <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-lg submit-btn" CommandName="PRODUCT_CATE_EDIT" 
                                CommandArgument='<%# Eval("product_category_id") %>'  ToolTip="แก้ไขหมวดหมู่" Font-Underline="true" OnClientClick="return SetTarget();" >แก้ไข</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkImageDel" runat="server" CssClass="btn btn-danger btn-lg submit-btn" CommandName="PRODUCT_CATE_DEL" 
                                CommandArgument='<%# Eval("product_category_id") %>'  ToolTip="ลบหมวดหมู่" Font-Underline="true"  OnClientClick="return confirm('คุณต้องการลบหมวดหมู่จริงหรือไม่ จริงหรือไม่');" >ลบ</asp:LinkButton>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>
</asp:Content>
