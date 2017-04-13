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
    <div>

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

    </div>

    <asp:Button ID="btnSend" runat="server" Text="เพิ่มหมวดหมู่" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
    <asp:Button ID="btnDel" runat="server" Text="ลบ" CssClass="btn btn-danger btn-lg submit-btn" OnClick="btnDel_Click" />
</asp:Content>
