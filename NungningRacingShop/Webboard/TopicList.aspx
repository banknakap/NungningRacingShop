<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="NungningRacingShop.Webboard.TopicList" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Scripts/CSS/NungNing.css" />
 
    <br>
    
    <asp:Repeater ID="rptTopics" runat="server" OnItemCommand="rptTopics_ItemCommand">
        <HeaderTemplate>
            <table class="tableTopic-lastupdate"" >
                <thead>
                    <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                        <th style="width: 5%; text-align: center; color:#d11d1c;">ลำดับ</th>
                        <th style="width: 30%; text-align: left; color:#d11d1c;">หัวเรื่อง</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">อ่านแล้ว</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">ความเห็น</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">ผู้สร้างกระทู้</th>
                        <th style="width: 8%; text-align: center; color:#d11d1c;">อัพเดทล่าสุด</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                <td style="text-align: center"><%# Container.ItemIndex+1 %></td>
                <td style="text-align: left">   <asp:LinkButton ID="LinkButton1" runat="server" style="text-decoration: none;color: #343434;" CommandName="TOPIC_DETAIL" 
                                CommandArgument='<%# Eval("topic_id") %>'  ToolTip="ไปยังกระทู้" Font-Underline="true" ><%# Eval("title") %></asp:LinkButton></td>
                <td style="text-align: center"><%# Eval("read_count") %></td>
                <td style="text-align: center"><%# Eval("comment_count") %></td>
                <td style="text-align: center"><%# Eval("create_by") %></td>
                <td style="text-align: center"><%# Eval("lastupdate_date","{0:dd MMM yyyy}") %></td>
               

            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>

    <div id="boxWebboard">
        <div class="boxTitle-lastupdate2">
              <span class="title" style="font-size:20px;">กระทู้ล่าสุด</span>
            <a class="btn btn-default btn-sm submit-btn" style="float: right;width: 100px;" runat="server" href="~/Webboard/TopicAdd">เพิ่มกระทู้</a>
        </div>
    </div>

     
    <asp:Repeater ID="rptTopics2" runat="server" OnItemCommand="rptTopics2_ItemCommand">
        <HeaderTemplate>
            <table class="tableTopic-lastupdate2"" >
                <thead>
                    <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                        <th style="width: 5%; text-align: center; color:#d11d1c;">ลำดับ</th>
                        <th style="width: 30%; text-align: left; color:#d11d1c;">หัวเรื่อง</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">อ่านแล้ว</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">ความเห็น</th>
                        <th style="width: 10%; text-align: center; color:#d11d1c;">ผู้สร้างกระทู้</th>
                        <th style="width: 8%; text-align: center; color:#d11d1c;">อัพเดทล่าสุด</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>

            <tr style="border-bottom: 1px solid #D3D3D3; height:50px;">
                <td style="text-align: center"><%# Container.ItemIndex+1 %></td>
                <td style="text-align: left">   <asp:LinkButton ID="LinkButton1" runat="server" style="text-decoration: none;color: #343434;" CommandName="TOPIC_DETAIL" 
                                CommandArgument='<%# Eval("topic_id") %>'  ToolTip="ไปยังกระทู้" Font-Underline="true" ><%# Eval("title") %></asp:LinkButton></td>
                <td style="text-align: center"><%# Eval("read_count") %></td>
                <td style="text-align: center"><%# Eval("comment_count") %></td>
                <td style="text-align: center"><%# Eval("create_by") %></td>
                <td style="text-align: center"><%# Eval("lastupdate_date","{0:dd MMM yyyy}") %></td>
               

            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
        </FooterTemplate>
    </asp:Repeater>


</asp:Content>
