<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.Master" AutoEventWireup="true" CodeBehind="TopicEdit.aspx.cs" Inherits="NungningRacingShop.Backend.Webboard.TopicEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <script type="text/javascript">
              function SetTarget() {
                  originalTarget = document.forms[0].target;
                  document.forms[0].target = '_blank';
                  window.setTimeout("document.forms[0].target=originalTarget;", 300);
                  return true;
              }
</script>

    <script type="text/javascript">

        function isNumeric(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));

            if ((charCode >= 48 && charCode <= 57) || charCode == 8) {
                return true;
            }
            //alert("Enter numerals only in this field.");
            return false;
        }

        function isAlphabet(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));

            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 3585 && charCode <= 3641) || (charCode >= 3648 && charCode <= 3661) || charCode == 8 || charCode == 32) {
                return true;
            }
            //alert(charCode);
            return false;
        }
    </script>

    <h2>Register</h2>
    <div>



        <label>หัวเรื่อง : <span class="red">*</span> </label>
        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server" ></asp:TextBox>
        <label>กระทู้ฮอท: <span class="red">*</span></label>
        <label class="radio-inline">
            <asp:RadioButton ID="rdoYes" runat="server" Checked="True" GroupName="RDO_TOP" />
            ใช่
        </label>
              <label class="radio-inline">
            <asp:RadioButton ID="rdoNo" runat="server" GroupName="RDO_TOP" />
            ไม่ใช่
        </label>
        <br />
        <label>คำอธิบาย: <span class="red">*</span> </label>
        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" onkeypress="return isAlphabet(event);"></asp:TextBox>

 
    </div>

          <asp:Repeater ID="rptComments" runat="server" OnItemCommand="rptComments_ItemCommand">
                <HeaderTemplate>
                    <table class="tableScoreReport">
                        <thead>
                            <tr>
                                <th style="width: 5%; text-align: center">ลำดับ</th>
                                 <th style="width: 5%; text-align: center">ความเห็น</th>
                                <th style="width: 5%; text-align: center">ผู้สร้างความเห็น</th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <td><%# Container.ItemIndex+1 %></td>
                        <td><%# Eval("description") %></td>
                         <td><%# Eval("create_by") %></td>
                         <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning btn-lg submit-btn" CommandName="EDIT" 
                                CommandArgument='<%# Eval("comment_id") %>'  ToolTip="แก้ไข" Font-Underline="true" OnClientClick="return SetTarget();" >แก้ไข</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkImageDel" runat="server" CssClass="btn btn-danger btn-lg submit-btn" CommandName="DEL" 
                                CommandArgument='<%# Eval("comment_id") %>'  ToolTip="ลบ" Font-Underline="true"  OnClientClick="return confirm('คุณต้องการลบจริงหรือไม่ จริงหรือไม่');" >ลบ</asp:LinkButton>
                        </td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:Repeater>

       <asp:Button ID="btnSend" runat="server" Text="แก้ไข" ValidationGroup="RegisterGold" CssClass="btn btn-success btn-lg submit-btn" OnClick="btnSend_Click" />
</asp:Content>
