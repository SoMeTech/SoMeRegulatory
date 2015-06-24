<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePW.aspx.cs" Inherits="ChangePW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改用户密码
    </title>

    <script type="text/javascript">
        //屏蔽右键
        function document.oncontextmenu()
        { 
            return false; 
        } 
    </script>

</head>
<body onload="javascript:document.all['txtNewPD'].focus();">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="3" style="background-image: url(images/loginheadBack.gif)" height="20px">
                </td>
            </tr>
            <tr height="30px">
                <td style="width: 100px; text-align: right">
                    新 密 码(<span style="text-decoration: underline">P</span>)：
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtNewPD" runat="server" Width="160px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPD" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr height="40px">
                <td style="width: 100px; text-align: right">
                    确认密码(<span style="text-decoration: underline">P</span>)：
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAginPD" runat="server" Width="160px" TextMode="Password"></asp:TextBox><asp:CompareValidator
                        ID="CompareValidator1" runat="server" ControlToCompare="txtAginPD" ControlToValidate="txtNewPD"
                        ErrorMessage="*"></asp:CompareValidator>
                </td>
            </tr>
            <tr style="background-image: url(images/loginheadBack.gif); height: 28px;
                text-align: center">
                <td colspan="2" style="height: 22px; text-align: center">
                    <asp:ImageButton ID="btnTrue" runat="server" OnClick="btnTrue_Click" ImageUrl="images/loginTrue.jpg"
                        Width="70px" Height="20px" BorderWidth="1" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <img onclick="javascript:window.close();" src="images/loginExit.jpg" style="width: 70px;
                        height: 20px;" alt="" border="1" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
