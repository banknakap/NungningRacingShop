<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="NungningRacingShop.Backend.Notice.NoticeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
    function SetTarget() {
        originalTarget = document.forms[0].target;
        document.forms[0].target='_blank';
        window.setTimeout("document.forms[0].target=originalTarget;",300);
        return true;
    }
</script>
       <label>ชื่อสินค้า : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
        <br>
    <asp:Button ID="btnSend" runat="server" Text="ค้นหา" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
   <a class="btn btn-default btn-lg submit-btn" runat="server" href="~/Backend/Notice/NoticeAdd">เพิ่มประกาศ</a>

      <asp:Repeater ID="rptNotices" runat="server" OnItemCommand="rptNotices_ItemCommand">
                <HeaderTemplate>
                    <table class="tableScoreReport">
                        <thead>
                            <tr>
                                <th style="width: 5%; text-align: center">ลำดับ</th>
                                 <th style="width: 5%; text-align: center">ประกาศ</th>
                                <th style="width: 5%; text-align: center">รูปภาพ</th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td><%# Container.ItemIndex %></td>
                        <td><%# Eval("title") %></td>
                        <td><img ="100" src="<%# getImage(Eval("image").ToString()) %>" style="height:128px;"/></td>
                            <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-lg submit-btn" CommandName="NOTICE_EDIT" 
                                CommandArgument='<%# Eval("notice_id") %>'  ToolTip="แก้ไข" Font-Underline="true" OnClientClick="return SetTarget();" >แก้ไข</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkImageDel" runat="server" CssClass="btn btn-danger btn-lg submit-btn" CommandName="NOTICE_DEL" 
                                CommandArgument='<%# Eval("notice_id") %>'  ToolTip="ลบ" Font-Underline="true"  OnClientClick="return confirm('คุณต้องการลบจริงหรือไม่ จริงหรือไม่');" >ลบ</asp:LinkButton>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>
</asp:Content>
