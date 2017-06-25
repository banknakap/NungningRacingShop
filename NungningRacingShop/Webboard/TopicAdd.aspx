<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopicAdd.aspx.cs" Inherits="NungningRacingShop.Webboard.TopicAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label>หัวเรื่อง : <span class="red">*</span> </label>
        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>

        <label>คำอธิบาย : <span class="red">*</span> </label>
        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnSend" runat="server" Text="เพิ่มกระทู้" CssClass="btn btn-success btn-lg submit-btn" OnClientClick="return confirm('คุณต้องเพิ่มกระทู้ จริงหรือไม่');" OnClick="btnSend_Click" />
</asp:Content>
