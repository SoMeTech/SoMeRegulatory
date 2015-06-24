<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="DataRowPowerItem.aspx.cs" stylesheettheme="Default" inherits="User_DataRowPowerItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table border="1" cellpadding="0" cellspacing="0" style="border-left-color: #f5f5f5;
            border-bottom-color: #f5f5f5; border-top-color: #f5f5f5; background-color: #bfdbff;
            border-right-color: #f5f5f5" width="100%">
            <tr>
                <td style="height: 23px; text-align: right">
                    名称：</td>
                <td align="left" style="height: 23px">
                    <asp:TextBox ID="txtname" runat="server" Width="160px"></asp:TextBox></td>
                <td style="height: 23px; text-align: right">
                    权限编码：</td>
                <td align="left" style="height: 23px">
                    <asp:TextBox ID="txtpowercode" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 23px; text-align: right">
                    业务数据：</td>
                <td align="left" style="width: 318px; height: 23px">
                    <asp:DropDownList ID="ddltablename" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltablename_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="height: 23px; text-align: right">
                    </td>
                <td align="left" style="height: 23px">
                    <asp:DropDownList ID="ddlColumnName" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem>--请选择--</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: right">
                    权限选项：</td>
                <td align="left" colspan="3">
                    <table border="1" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td rowspan="4" style="width: 193px">
                                <asp:ListBox ID="lballqxxx" runat="server" Height="175px" Width="271px"></asp:ListBox>
                            </td>
                            <td style="width: 8px">
                                <asp:DropDownList ID="ddlgxysf" runat="server">
                                    <asp:ListItem>and</asp:ListItem>
                                    <asp:ListItem Value="or ">or </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td rowspan="4">
                                &nbsp;<asp:ListBox ID="lbxzqx" runat="server" Height="175px" Width="271px"></asp:ListBox></td>
                        </tr>
                        <tr>
                            <td style="width: 8px; text-align: center">
                                <asp:Button ID="btadd" runat="server" OnClick="btadd_Click" Text="-->>" /></td>
                        </tr>
                        <tr>
                            <td style="width: 8px; text-align: center">
                                <asp:Button ID="btdel" runat="server" OnClick="btdel_Click" Text="<<--" /></td>
                        </tr>
                        <tr>
                            <td style="width: 8px; height: 37px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: right">
                    描述：</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtDiscription" runat="server" BorderStyle="Groove" Height="50px"
                        TextMode="MultiLine" Width="478px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 318px">
                    <input id="pk" runat="server" name="pk" style="width: 35px" type="text" visible="false" />
                    <input id="tn" runat="server" name="tn" style="width: 35px" type="text" visible="false" />
                    <input id="ifadd" runat="server" name="ifadd" style="width: 35px" type="text" value="1"
                        visible="false" /></td>
                <td>
                    <asp:Button ID="btDo" runat="server" OnClick="btDo_Click" Text="添加" /></td>
                <td>
                    <input id="Reset1" type="reset" value="重填" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
