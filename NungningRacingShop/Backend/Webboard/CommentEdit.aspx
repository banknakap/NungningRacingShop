<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="CommentEdit.aspx.cs" Inherits="NungningRacingShop.Backend.Webboard.CommentEdit" %>
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

    <h2>Register</h2>
    <div>



        <label>ความเห็น : <span class="red">*</span> </label>
        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

 
    </div>

         

       <asp:Button ID="btnSend" runat="server" Text="แก้ไข" ValidationGroup="RegisterGold" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
</asp:Content>
