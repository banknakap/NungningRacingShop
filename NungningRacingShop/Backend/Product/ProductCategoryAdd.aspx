<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ProductCategoryAdd.aspx.cs" Inherits="NungningRacingShop.Backend.Product.ProductCategoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>

        <label>ชื่อหมวดหมู่ : <span class="red">*</span> </label>
        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
        <label>คำอธิบาย : <span class="red">*</span> </label>
        <asp:TextBox ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

       <asp:Button ID="btnSend" runat="server" Text="เพิ่มหมวดหมู่" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />

</asp:Content>
