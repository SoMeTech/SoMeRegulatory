<%@ control language="C#" autoeventwireup="true" inherits="ReportOrderControl" CodeBehind="ReportOrderControl.ascx.cs" %>

<script language="javascript">
    //验证不能输入单引号
    function onlyNum4() {
        if (event.keyCode == 222) {
            return false;
        }
        else {
            return true;
        }
    }
</script>
<asp:Table ID="_conttable" runat="server">
<asp:TableRow ID="_controw" runat="server">
</asp:TableRow>
</asp:Table>
<!--table border="0" cellpadding="0" cellspacing="0" style="width:auto">
    <tr>
        <td>
            资金性质：<asp:DropDownList ID="DropDownList_zjxz" SkinID="" runat="server" Width="100px" CssClass="mouthType">
            </asp:DropDownList></td>
        <td style="width: 40px; text-align: right;">
            乡镇：</td><td style="width: 84px">
            <asp:DropDownList ID="DropDownList_xz" SkinID="" runat="server" Width="100px" CssClass="mouthType">
            </asp:DropDownList></td>
        <td style="text-align: right;">
            文件编号：</td>
        <td>
            <asp:TextBox ID="TextBox_wjbh" SkinID="" runat="server" Width="120px" onkeydown="return onlyNum4();"></asp:TextBox></td>
        <td style="text-align: right;">
            文件名称：</td>
        <td>
            <asp:TextBox ID="TextBox_wjmc" SkinID="" runat="server" Width="120px" onkeydown="return onlyNum4();"></asp:TextBox></td>
        <td align="center" style="width: 50px; ">
            </td>
    </tr>
</table-->
