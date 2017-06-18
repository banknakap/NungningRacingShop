<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="NungningRacingShop.Backend.User.UserList" %>
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
     <label>UserName : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
       <label>ชื่อ : <span class="red">*</span> </label>
        <asp:TextBox  ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>

        <br>
    <asp:Button ID="btnSend" runat="server" Text="ค้นหา" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
      <a class="btn btn-default btn-lg submit-btn" runat="server" href="~/Backend/User/UserAdd">เพิ่มสมาชิก</a>

      <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="rptUsers_ItemCommand">
                <HeaderTemplate>
                    <table class="tableScoreReport">
                        <thead>
                            <tr>
                                <th style="width: 5%; text-align: center">ลำดับ</th>
                                 <th style="width: 5%; text-align: center">Username</th>
                                <th style="width: 5%; text-align: center">ชื่อ</th>
                                 <th style="width: 5%; text-align: center">นามสกุล</th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td><%# Container.ItemIndex %></td>
                        <td><%# Eval("user_name") %></td>
                         <td><%# Eval("first_name") %></td>
                        <td><%# Eval("last_name") %></td>
                        
                            <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-lg submit-btn" CommandName="USER_EDIT" 
                                CommandArgument='<%# Eval("user_infoid") %>'  ToolTip="แก้ไข" Font-Underline="true" OnClientClick="return SetTarget();" >แก้ไข</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkImageDel" runat="server" CssClass="btn btn-danger btn-lg submit-btn" CommandName="USER_DEL" 
                                CommandArgument='<%# Eval("user_infoid") %>'  ToolTip="ลบ" Font-Underline="true"  OnClientClick="return confirm('คุณต้องการลบจริงหรือไม่ จริงหรือไม่');" >ลบ</asp:LinkButton>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>
</asp:Content>
