<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" inherits="ChangeService" CodeBehind="ChangeService.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>更改服务器配置</title>
    <script type="text/javascript">
        //屏蔽右键
        function document.oncontextmenu() 
        { 
            return false; 
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="3" style="background-image: url(images/loginheadBack.gif)" height="20px">
            </td>
        </tr>
        <tr height="40px">
            <td align="right">
                服务器(<span style="text-decoration: underline">S</span>)：
            </td> 
            <td align="left">
                <asp:TextBox ID="txtService" runat="server" Width="180px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtService" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr height="40px">
            <td align="right">
                用户名(<span style="text-decoration: underline">U</span>)：
            </td>
            <td align="left">
                <asp:TextBox ID="txtUser" runat="server" Width="180px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr height="40px">
            <td align="right">
                密码(<span style="text-decoration: underline">P</span>)：
            </td>
            <td align="left">
                <asp:TextBox ID="txtPW" runat="server" Width="180px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPW" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height: 28px;" align="right">
                <asp:ImageButton ID="ibtTestCon" runat="server" OnClick="ibtTestCon_Click" ImageUrl="images/loginTest.jpg"
                    Width="70px" Height="20px" BorderWidth="1" />
            </td>
            <td align="left">
                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnTrue" runat="server" OnClick="btnTrue_Click" ImageUrl="images/ok.gif"
                    Width="70px" Height="22px" BorderWidth="1" />&nbsp; &nbsp;&nbsp;<img 
                    onclick="javascript:window.close();" src="images/cancel.gif" style="width: 68px;
                    height: 22px;" alt="" border="1" /></td>
            <td align="center" > &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
