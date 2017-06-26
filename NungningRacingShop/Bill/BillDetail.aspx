﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="NungningRacingShop.BillDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .table {
            border-collapse: collapse !important;
            color: #000;
            font-family: 'db_helvethaica_x';
            font-size: 19px;
            line-height: 19px;
        }

        .table-bordered {
            border: 1px solid #ddd;
        }

        .table.radius {
            border-collapse: separate;
            border-radius: 5px;
        }


        .table-bordered.table-bg > thead > tr > th {
            background: #e6e7e7;
            font-size: 20px;
            color: #161616;
            padding: 10px 20px;
        }

        .table-bordered.table-bg > thead > tr:first-child > th {
            border-top: 1px solid #fff;
            border-bottom: 1px solid #fff;
        }
    </style>

    <h1 align="center">NungNing RacingShop</h1>
    <div style="width: 50%; margin: 0 auto;">
        <p>ที่อยู่ หกดกหดกหดหกดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดด</p>
        <p>ที่อยู่ หกดกหดกหดหกดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดด</p>
        <p>ที่อยู่ หกดกหดกหดหกดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดดด</p>
      
    </div>

    <hr style="width: 70%" />
      <h3 align="center">ใบเสร็จ</h3>
    <table align="center" class="table table-bordered table-bg radius" cellspacing="0" style="width: 70%; border-collapse: collapse;">
        <tbody>
            <tr >

                <td style="width: 61%;"></td>
                <td align="right" style="width: 20%;">
                    <p id="pReceiptCode" runat="server"></p>
                </td>
            </tr>
            <tr>

                <td style="width: 61%;">
                    <p id="pAddress" runat="server"></p>
                </td>
                <td align="right" style="width: 20%;">
                    <p id="pCreateDate" runat="server"></p>
                </td>

            </tr>
        </tbody>
    </table>

    <asp:Repeater ID="rptBillDetail" runat="server">
        <HeaderTemplate>
            <table align="center" class="table table-bordered table-bg radius" cellspacing="0" style="width: 70%; border-collapse: collapse;">
                <thead>
                    <tr>

                        <th scope="col">ชื่อสินค้า</th>
                        <th align="left" scope="col">จำนวน</th>
                        <th align="center" scope="col">ราคาต่อหน่วย</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>

                <td style="width: 61%;">
                    <%# Eval("title") %>
                </td>
                <td align="center" style="width: 5%;"><%# Eval("amount") %></td>
                <td align="right" style="width: 20%;"><%# Eval("sum_price").Equals("0.") ? "-" : Eval("sum_price", "{0:#,#0.##}") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>

            <tr>

                <td style="width: 61%;">
                </td>
                <td align="center" style="width: 5%;">ราคาสุทธิ</td>
                <td align="right" style="width: 20%;"><p><%# total_price.ToString("#,##0.##") %></p></td>
            </tr>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Button ID="btnSend" runat="server" Text="ส่งเมล" ValidationGroup="RegisterGold" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
</asp:Content>