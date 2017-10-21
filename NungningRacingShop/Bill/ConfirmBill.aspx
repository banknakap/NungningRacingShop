<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmBill.aspx.cs" Inherits="NungningRacingShop.Bill.ConfirmBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <asp:Repeater ID="rptBillConfirms" runat="server" OnItemCommand="rptBillConfirms_ItemCommand">
        <HeaderTemplate>
            <table class="tableTopic-lastupdate"" >
                <thead>
                    <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                        <th style="width: 5%; text-align: center; color:#a74646;">ลำดับ</th>
                        <th style="width: 30%; text-align: left; color:#d11d1c;">ที่อยู่</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">ราคารวม</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">วันที่ทำรายการ</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">เวลาที่ทำรายการ</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                <td style="text-align: center"><%# Container.ItemIndex+1 %></td>
                <td style="text-align: left"> <asp:LinkButton ID="LinkButton1" runat="server" style="text-decoration: none;color: #343434;" CommandName="COMMAND" 
                                CommandArgument='<%# Eval("bill_id") %>'  ToolTip="ยืนยันการชำระเงิน" Font-Underline="true" ><%# Eval("first_name") + " " + Eval("last_name") %></asp:LinkButton></td>
                <td style="text-align: center"><%# Eval("total_price", "{0:#,##0.##}") %></td>
                <td style="text-align: center"><%# Eval("create_date","{0:d MMM yyyy}") %></td>
               <td style="text-align: center"><%# Eval("create_date","{0:hh:mm:ss}") %></td>

            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
