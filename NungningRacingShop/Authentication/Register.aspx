<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="NungningRacingShop.Authentication.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

        <label>User Name : <span class="red">*</span> </label>
        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>

        <label>Password : <span class="red">*</span> </label>
        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>

        <label>Re-Password : <span class="red">*</span> </label>
        <asp:TextBox ID="txtRepassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>

        <label>ชื่อ: <span class="red">*</span> </label>
        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

        <label>นามสกุล: <span class="red">*</span> </label>
        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

        <label>อีเมล์: <span class="red">*</span> </label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>

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

    <asp:Button ID="btnSend" runat="server" Text="สมัครสมาชิก" ValidationGroup="RegisterGold" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
</asp:Content>
