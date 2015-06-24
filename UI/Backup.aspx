<%@ page language="C#" autoeventwireup="true" CodeBehind="Backup.aspx.cs" inherits="Backup" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
    

                <table>
                    <tr>
                        <td>
                            数据库名：<asp:TextBox ID="tbxDbname" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            备份路径：<asp:FileUpload ID="fupbk" runat="server" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备份类型：
                            <asp:DropDownList ID="ddlBktype1" runat="server" Width="200px">
                                <asp:ListItem Value="DB">备份数据库</asp:ListItem>
                                <asp:ListItem Value="DF">差异备份</asp:ListItem>
                                <asp:ListItem Value="LOG">日志备份</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td>
                            备份方式：
                            <asp:DropDownList ID="ddlBktype2" runat="server" Width="100px">
                                <asp:ListItem Value="1">追加</asp:ListItem>
                                <asp:ListItem Value="0">覆盖</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            设置密码：
                            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox><td>
                            </td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBackup" runat="server" Text="备  份" Width="65px" OnClick="btnBackup_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
           
        <p>
        </p>
        
                <table>
                    <tr>
                        <td>
                            数据库名：<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            还原文件路径：<asp:FileUpload ID="fupRe" runat="server" Width="500px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            输入密码：
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><td>
                            </td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRestore" runat="server" Text="还  原" Width="65px" OnClick="btnRestore_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            
    </div>
    </form>
</body>
</html>
