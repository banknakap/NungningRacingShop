<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="NungningRacingShop.Backend.Product.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <style>
        .custom-file-upload {
    border: 1px solid #ccc;
    display: inline-block;
    padding: 6px 12px;
    cursor: pointer;
}
    </style>
    <div>
        <div class="panel panel-default">
            <div class="panel-heading">แก้ไขสินค้า</div>
            <div class="panel-body">
                <label>ชื่อสินค้า : <span class="red">*</span> </label>
                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                <label>คำอธิบาย : <span class="red">*</span> </label>
                <asp:TextBox
                    ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
                <label>หมวดหมู่ <span style="color: red;">*</span> </label>
                <br>
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
                <br>
                <label>ราคา : <span class="red">*</span> </label>
                <asp:TextBox placeholder="2000" ID="txtPrice" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
                <label>จำนวน : <span class="red">*</span> </label>
                <asp:TextBox placeholder="20" ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>

                <asp:FileUpload ID="fileImage" AllowMultiple="true" runat="server" />
                <asp:Label ID="listofuploadedfiles" runat="server" />
                <ul class="list-group">

                <asp:Repeater ID="rptProductImages" runat="server" OnItemCommand="rptProductImages_ItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th style="width: 5%; text-align: center">ลำดับ</th>
                                    <th style="width: 5%; text-align: center">รูปภาพ</th>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <tr>
                            <td><%# Container.ItemIndex %></td>
                            <td><%# Eval("image") %></td>
                            <td></td>
                            <td><img ="100" src="<%# getImage(Eval("image").ToString()) %>" style="height:128px;"/></td>
                            <td>
                                <asp:TextBox ID="txtImageId" runat="server" type="hidden" Text='<%# Eval("image_id") %>'></asp:TextBox>
                                <asp:TextBox ID="txtImageName" runat="server" type="hidden" Text='<%# Eval("image") %>'></asp:TextBox>
                                <asp:FileUpload  ID="fileItemImage" AllowMultiple="false" runat="server" />
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkImageDel" runat="server" CssClass="btn btn-danger btn-lg submit-btn" CommandName="PROIMAGE_DEL"
                                    CommandArgument='<%# Eval("image_id") %>' ToolTip="ลบภาพ" Font-Underline="true" OnClientClick="return confirm('คุณต้องการลบรูปภาพจริงหรือไม่ จริงหรือไม่');">ลบรูปภาพ</asp:LinkButton>
                            </td>
                            <td>
                                <label class="custom-file-upload">
    <input type="file" style="display:none;"/>
    Custom Upload
</label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>

    <asp:Button ID="btnSend" runat="server" Text="แก้ไข" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
    <asp:Button ID="btnDel" runat="server" Text="ลบ" CssClass="btn btn-danger btn-lg submit-btn" OnClick="btnDel_Click" />
</asp:Content>
