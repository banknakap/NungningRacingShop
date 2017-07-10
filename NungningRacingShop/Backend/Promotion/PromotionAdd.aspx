<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="PromotionAdd.aspx.cs" Inherits="NungningRacingShop.Backend.Promotion.PromotionAdd" %>

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


        <label>รหัสโปรโมชั่น: <span class="red">*</span> </label>
        <asp:TextBox ID="txtPromotionCode" CssClass="form-control" runat="server"></asp:TextBox>
        <label>ประเภทโปรโมชั่น </label>
        <br>
        <asp:DropDownList ID="ddlPromotonType" CssClass="form-control" runat="server">
        </asp:DropDownList>
        <br>
        <label>ส่วนลดเปอเซ็น: </label>
        <asp:TextBox ID="txtDiscountPercent" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
        <label>ส่วนลดราคาเต็ม: </label>
        <asp:TextBox ID="txtDiscountValue" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
        <label>รหัสสินค้าที่แถม: </label>
        <asp:TextBox ID="txtFreeProductId" CssClass="form-control" runat="server"></asp:TextBox>
        <label>จำนวนที่แถม: </label>
        <asp:TextBox ID="txtFreeAmount" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>

        <label>ชื่อโปรโมชั่น: <span class="red">*</span> </label>
        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
        <label>คำอธิบาย : <span class="red">*</span> </label>
        <asp:TextBox
            ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
        <label>รูปภาพ: </label>
        <asp:FileUpload ID="fileImage" runat="server" />
        <asp:Label ID="listofuploadedfiles" runat="server" />
        <br />
    </div>

    <asp:Button ID="btnSend" runat="server" Text="เพิ่ม" CssClass="btn btn-success btn-mg submit-btn" OnClick="btnSend_Click" />

</asp:Content>
