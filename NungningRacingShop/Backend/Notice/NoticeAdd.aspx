<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="NoticeAdd.aspx.cs" Inherits="NungningRacingShop.Backend.Notice.NoticeAdd" %>
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

        <label>ประกาศ: <span class="red">*</span> </label>
        <asp:TextBox  ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
        <label>คำอธิบาย : <span class="red">*</span> </label>
        <asp:TextBox 
            ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
       <asp:FileUpload ID="fileImage" runat="server" />
        <asp:Label ID="listofuploadedfiles" runat="server" />
         <br>
        <label>url: </label>
        <asp:TextBox  ID="txtUrl" CssClass="form-control" runat="server"></asp:TextBox>
           <label>เรียงลำดับ: <span class="red">*</span> </label>
        <asp:TextBox  ID="txtDisplaySort" CssClass="form-control" runat="server"></asp:TextBox>

          <label>LinkPage </label>
        <br>
        <asp:DropDownList ID="ddlLinkPage" runat="server">
        </asp:DropDownList>
        <br>
           <label>LinkParam: </label>
        <asp:TextBox  ID="txtLinkParam" CssClass="form-control" runat="server"></asp:TextBox>

    </div>

    <asp:Button ID="btnSend" runat="server" Text="เพิ่มประกาศ" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />

</asp:Content>
