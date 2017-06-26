<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopicDetail.aspx.cs" Inherits="NungningRacingShop.Webboard.TopicDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Scripts/CSS/NungNing.css" />
    <style>
        a {
            color: #428bca;
            text-decoration: none;
        }
    </style>

    <div style="margin: 8px 0 20px 30px;">
        <a runat="server" href="~/Webboard/TopicList">Webboard</a>
        <span class="glyphicon glyphicon-arrow-right"></span>
        <a id="navSup" runat="server"></a>

    </div>

    <div id="boxWebboard">
        <div class="boxTopic">
            <p id="lblTitle" runat="server" class="title new">
            </p>
            <div id="lblDes" runat="server" class="description">
            </div>
            <div class="boxUser">

                <p id="lblCreateBy" runat="server" class="name memberSilver"></p>

                <p id="lblTime" runat="server" class="time">
                </p>
               
            </div>



            <asp:Repeater ID="rptComments" runat="server" >
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>

                    <p id="lblTitle" runat="server" class="title new">
                       
                    </p>
                    <div id="lblDes" runat="server" class="description">
                        <%# Eval("description") %>
                    </div>
                    <div class="boxUser">

                        <p id="lblCreateBy" runat="server" class="name memberSilver"></p>
                        <%# Eval("create_by") %>
                        <p id="lblTime" runat="server" class="time">
                            <%# Eval("lastupdate_date","{0:dd MMM yyyy - HH:mm:ss}") %>
                        </p>
                        <%--<a class="btn btn-default btn-sm submit-btn" style="float: right; width: 100px;margin-top:5px;" runat="server" href="~/Webboard/TopicAdd">ตอบกลับ</a>--%>
                    </div>


                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
     
                </FooterTemplate>
            </asp:Repeater>



        </div>
    </div>

      <div id="divReply" runat="server" style="margin: 0 0 20px 30px;">

        <label>ความเห็นของคุณ</label>
        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
           <asp:Button ID="btnSend" runat="server" Text="แสดงความคิดเห็น" OnClientClick="return confirm('คุณต้องการแสดงความเห็น จริงหรือไม่');" CssClass="btn btn-default btn-lg submit-btn" OnClick="btnSend_Click" />
    </div>
   
</asp:Content>
