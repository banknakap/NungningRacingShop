<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillPayment.aspx.cs" Inherits="NungningRacingShop.Bill.BillPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    <h2>แจ้งชำระเงิน</h2>
    <div>

        <p>โอนเงินได้ที่ TMB : 215-2-67671-0 ชื่อบัญชี น.ส. สาวิตรี แฝดสูงเนิน</p>
        <br />
        <label>วัน: <span class="red">*</span> </label>
        <asp:TextBox ID="txtDate" placeholder="01/01/2011" CssClass="form-control" runat="server"></asp:TextBox>

        <label>เวลา: <span class="red">*</span> </label>
        <asp:TextBox ID="txtTime" placeholder="11:02:03" CssClass="form-control" runat="server"></asp:TextBox>

        <label>ยอดชำระเงิน: <span class="red">*</span> </label>
        <asp:TextBox ID="txtPaymentPrice" CssClass="form-control" runat="server" onkeypress="return isNumeric(event);"></asp:TextBox>
        <%--<label>เลขบัญชีผู้ชำระเงิน : <span class="red">*</span> </label>
        <asp:TextBox ID="txtPaymentAccount" CssClass="form-control" runat="server" ></asp:TextBox>--%>

        <label>ชื่อผู้ชำระเงิน: <span class="red">*</span> </label>
        <asp:TextBox ID="txtPaymentName" CssClass="form-control" runat="server" ></asp:TextBox>

        <label>อับโหลดภาพ: <span class="red">*</span> </label>
        <asp:FileUpload ID="fileImage" AllowMultiple="false" runat="server" />

    </div>

    <asp:Button ID="btnSend" runat="server" Text="ยืนยันการชำระเงิน" ValidationGroup="RegisterGold" style="color:black;" CssClass="" OnClick="btnSend_Click" />
</asp:Content>
