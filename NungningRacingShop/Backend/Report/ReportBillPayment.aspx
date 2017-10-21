<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="ReportBillPayment.aspx.cs" Inherits="NungningRacingShop.Backend.Report.ReportBillPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h3 align="center">รายงานการแจ้งชำระเงิน</h3>
      <asp:Repeater ID="rptReport" runat="server">
        <HeaderTemplate>
            <table align="center" class="table table-bordered table-bg radius" cellspacing="0" style="width: 70%; border-collapse: collapse;">
                <thead>
                    <tr>

                        <th scope="center">ผู้ทำรายการ</th>
                        <th align="center" scope="col">หมายเลขบิล</th>
                        <th align="center" scope="col">วันที่แจ้งชำระ</th>
                         <th align="center" scope="col">วันที่ชำระ</th>
                        <th align="right" scope="col">ยอดที่ชำระ</th>
                        <th scope="center">ชื่อผู้แจ้งชำระเงิน</th>
                         <th scope="center">เลขบัญชีผู้ชำระเงิน</th>
                        <th scope="center">ภาพประกอบ</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>
                <td align="center" style="width: 10%;"><%# Eval("create_by") %></td>
                <td align="center" style="width: 10%;"><%# int.Parse(Eval("bill_code").ToString()).ToString("00000##") %></td>
                <td align="center" style="width: 10%;"><%# Eval("create_date") %></td>
                <td align="center" style="width: 10%;"><%# Eval("payment_time") %></td>
                <td align="right" style="width: 10%;"><%# Eval("payment_price").Equals("0.") ? "-" : Eval("payment_price", "{0:#,#0.##}") %></td>
                 <td align="center" style="width: 10%;"><%# Eval("payment_name") %></td>
                 <td align="center" style="width: 10%;"><%# Eval("payment_account") %></td>
                <td align="center" style="width: 10%;"> <img ="100" src="<%# getImage(Eval("payment_image").ToString()) %>"  style="height:150px; max-width: 240px;"/></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
     
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
