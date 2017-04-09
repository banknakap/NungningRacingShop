<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="NungningRacingShop.Backend.Product.ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <label>ชื่อสินค้า : <span class="red">*</span> </label>
        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
        <label>คำอธิบาย : <span class="red">*</span> </label>
        <asp:TextBox ID="txtDesciption" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
        <label>หมวดหมู่ <span style="color: red;">*</span> </label>
        <asp:DropDownList ID="ddlCategory" runat="server">
        </asp:DropDownList>
        <label>ราคา : <span class="red">*</span> </label>
        <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
        <label>จำนวน : <span class="red">*</span> </label>
        <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>

        <asp:FileUpload ID="fileImage" AllowMultiple="true" runat="server" />

    </div>

    <asp:Button ID="btnSend" runat="server" Text="เพิ่มหมวดหมู่" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />

</asp:Content>
