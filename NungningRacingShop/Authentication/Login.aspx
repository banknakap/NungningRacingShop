<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NungningRacingShop.Authentication.Login" %>

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

    <h2>Login</h2>
    <div>

        <label>User Name</label>
        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>

        <label>Password</label>
        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>

    </div>
        <div>
       <asp:Button ID="btnSend" runat="server" Text="ล็อคอิน"  CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
    <asp:Button ID="btmCancel" runat="server" Text="ยกเลิก" CssClass="btn btn-danger btn-lg submit-btn" OnClick="btnSend_Click" />
     </div>
</asp:Content>
