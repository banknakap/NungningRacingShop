<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillHistoryList.aspx.cs" Inherits="NungningRacingShop.Bill.BillHistoryList" %>

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
    <br />

    <asp:Repeater ID="rptBills" runat="server" OnItemCommand="rptBills_ItemCommand">
        <HeaderTemplate>
            <table class="table table-bordered table-bg radius" cellspacing="0" style="width: 100%; border-collapse: collapse;">
                <thead>
                    <tr>
                        <th align="left" scope="col">ลำดับ</th>
                        <th scope="col">ที่อยู่</th>
                        <th align="center" scope="col">ราคาสุทธิ</th>
                        <th align="center" scope="col">วันที่ทำรายการ</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr>
                <td align="center" style="width: 5%;"><%# Container.ItemIndex+1 %></td>
                 <td style="width: 61%;">
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="DETAIL"
                        CommandArgument='<%# Eval("bill_id") %>' ToolTip="แก้ไข" Font-Underline="true"><%# Eval("address") %></asp:LinkButton>
                </td>
                <td align="right" style="width: 12%;"><%# Eval("total_price").Equals("0.") ? "-" : Eval("total_price", "{0:#,#0.##}") %></td>
                <td align="left" style="width: 20%;"><%# Eval("create_date","{0:dd MMM yyyy - HH:mm:ss}") %></td>
           


            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
