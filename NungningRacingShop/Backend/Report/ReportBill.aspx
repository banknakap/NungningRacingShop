<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ReportBill.aspx.cs" Inherits="NungningRacingShop.Backend.Report.ReportBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <label>วันที่เริ่มต้น : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtStart" placeholder="01/01/2011" style="width:15%" CssClass="form-control" runat="server"></asp:TextBox>
        <br>
      <label>วันที่สิ้นสุด : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtEnd" placeholder="01/01/2011" style="width:15%" CssClass="form-control" runat="server"></asp:TextBox>
        <br>
    <asp:Button ID="btnSend" runat="server" Text="ค้นหา" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />

      <asp:Repeater ID="rptReport" runat="server">
        <HeaderTemplate>
            <table align="center" class="table table-bordered table-bg radius" cellspacing="0" style="width: 70%; border-collapse: collapse;">
                <thead>
                    <tr>

                        <th scope="center">ผู้ซื้อสินค้า</th>
                        <th align="center" scope="col">ชื่อสินค้า</th>
                        <th align="center" scope="col">จำนวน</th>
                         <th align="right" scope="col">ราคารวม</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>
                <td align="center" style="width: 20%;"><%# Eval("user_name") %></td>
                <td align="center" style="width: 25%;"><%# Eval("product_title") %></td>
                <td align="center" style="width: 20%;"><%# Eval("amount") %></td>
                <td align="right" style="width: 25%;"><%# Eval("total_price").Equals("0.") ? "-" : Eval("total_price", "{0:#,#0.##}") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
     
            <tr>
                <td align="center" style="width: 20%;"></td>
                <td align="center" style="width: 25%;"></td>
                <td align="center" style="width:20%;">ราคารวมทั้งหมด</td>
                <td align="right" style="width: 25%;">
                    <p><%# total_price.ToString("#,##0.##") %></p>
                </td>
            </tr>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
