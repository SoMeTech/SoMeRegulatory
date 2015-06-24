<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="XmlEdit.aspx.cs" stylesheettheme="Default" inherits="User_XmlEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: #BFDBFF; border-color:#f5f5f5;">
            <tr>
                <td style="width: 88px; text-align: right">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="新增" />
                </td>
                <td style="width: 54px; height: 23px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" /></td>
                <td style="width: 85px; height: 23px; text-align: right">
                </td>
                <td style="height: 23px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 88px; height: 23px;">
                    表名：</td>
                <td style="width: 54px; height: 23px;">
                    <asp:TextBox ID="txtTableName" runat="server"></asp:TextBox></td>
                <td style="text-align: right; width: 85px; height: 23px;">
                    列名：</td>
                <td style="height: 23px">
                    <asp:TextBox ID="txtColName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 88px;">
                    表中文名：</td>
                <td style="width: 54px">
                    <asp:TextBox ID="txtTableChina" runat="server"></asp:TextBox></td>
                <td style="text-align: right; width: 85px;">
                    列中文名：</td>
                <td>
                    <asp:TextBox ID="txtColChina" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 88px;">
                </td>
                <td style="width: 54px; height: 23px">
                </td>
                <td style="height: 23px; text-align: right; width: 85px;">
                    列类型：</td>
                <td style="height: 23px">
                    <asp:DropDownList ID="ddlDataType" runat="server">
                        <asp:ListItem Selected="True" Value="body">人、部门类型</asp:ListItem>
                        <asp:ListItem Value="string">字符类型</asp:ListItem>
                        <asp:ListItem Value="int">数字类型</asp:ListItem>
                        <asp:ListItem Value="DateTime">时间类型</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 88px;">
                    表名：</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlTableName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
        <tr>
            <td style="vertical-align: top; text-align: right; width: 88px;">
                集合：</td>
            <td colspan="3">
                <yyc:SmartGridView ID="gvResult" runat="server" OnRowDeleting="gvResult_RowDeleting" OnSelectedIndexChanging="gvResult_SelectedIndexChanging">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" HeaderText="选择" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="删除" />
                    </Columns>
                </yyc:SmartGridView>
                <input id="txtTableNameVal" runat="server" style="width: 39px" type="text" visible="false" />
                <input id="txtTableChinaVal" runat="server" style="width: 39px" type="text" visible="false" />
                <input id="txtColNameVal" runat="server" style="width: 39px" type="text" visible="false" />
                <input id="txtColChinaVal" runat="server" style="width: 39px" type="text" visible="false" />
                <input id="txtDataType" runat="server" style="width: 39px" type="text" visible="false" /></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
