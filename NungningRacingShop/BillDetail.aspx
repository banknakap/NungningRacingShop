<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="NungningRacingShop.BillDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <asp:repeater id="rptBillDetail" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                         <label>จำนวน <%# Eval("product_id") %> ชิ้น</label>
                  
              
                </ItemTemplate>
           
                <FooterTemplate>

                </FooterTemplate>
            </asp:repeater>
</asp:Content>
