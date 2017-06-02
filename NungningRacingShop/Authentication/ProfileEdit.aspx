﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileEdit.aspx.cs" Inherits="NungningRacingShop.Authentication.ProfileEdit" %>
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

    <h2>Register</h2>
    <div>


        <label>ชื่อ: <span class="red">*</span> </label>
        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

        <label>นามสกุล: <span class="red">*</span> </label>
        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

        <label>เพศ: <span class="red">*</span></label>
        <label class="radio-inline">
            <asp:RadioButton ID="rdoMale" runat="server" Checked="True" GroupName="RDO_SEX" />
            ชาย
        </label>
        <label class="radio-inline">
            <asp:RadioButton ID="rdoFemale" runat="server" GroupName="RDO_SEX" />
            หญิง
        </label>


        <label>ที่อยู่: <span class="red">*</span> </label>
        <asp:TextBox ID="txtAddress" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

       <asp:Button ID="btnSend" runat="server" Text="แก้ไขข้อมูลสมาชิก" ValidationGroup="RegisterGold" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
</asp:Content>