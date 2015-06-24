<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="DataRowPower.aspx.cs" stylesheettheme="Default" inherits="User_DataRowPower" %>

<%@ Register Src="../../WebControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据权限</title>
    <link href="../css/Admin_Style.css" rel="stylesheet" type="text/css" />
    <script src="../jss/GridViewChangeColor.js" type="text/javascript"></script>
    <script src="../jss/Qx_nz.js" type="text/javascript"></script>
    <script src="../jss/setday.js" type="text/javascript"></script>
</head>
<body text="#d">
    <form id="form1" runat="server">
        <div align="center">
            <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: #BFDBFF; border-color:#f5f5f5;">
                <tr>
                    <td style="height: 23px; text-align: right">
                        名称：</td>
                    <td align="left" style="height: 23px">
                        <asp:TextBox ID="txtname" runat="server" Width="160px"></asp:TextBox></td>
                    <td style="text-align: right; height: 23px;">
                        权限编码：</td>
                    <td align="left" style="height: 23px">
                        <asp:TextBox ID="txtpowercode" runat="server" Width="160px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 23px;">
                        业务数据：</td>
                    <td align="left" style="width: 318px; height: 23px">
                        <asp:DropDownList ID="ddltablename" runat="server" OnSelectedIndexChanged="ddltablename_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList></td>
                    <td style="text-align: right; height: 23px;">
                        数据列：</td>
                    <td align="left" style="height: 23px"><asp:DropDownList ID="ddlColumnName" runat="server" OnSelectedIndexChanged="ddlColumnName_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>--请选择--</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 28px;">
                        限制条件：</td>
                    <td align="left" colspan="3" style="height: 28px">
                        <div id="divstr1" runat="server" visible="true">
                            <asp:DropDownList ID="ddlstrppqk" runat="server">
                                <asp:ListItem>精确匹配</asp:ListItem>
                                <asp:ListItem>模糊匹配</asp:ListItem>
                                <asp:ListItem>前匹配</asp:ListItem>
                                <asp:ListItem>后匹配</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtstring" runat="server" Width="160px"></asp:TextBox>
                        </div>
                        <div id="divstr2" runat="server" visible="true">
                            <asp:DropDownList ID="ddlstrself" runat="server">
                                <asp:ListItem Value="自己">自己</asp:ListItem>
                                <asp:ListItem Value="部门">部门</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtstring1" runat="server" Width="160px" Visible="false"></asp:TextBox>
                        </div>
                        <div id="divint" runat="server" visible="false">
                            <asp:DropDownList ID="ddlintppqk" runat="server" OnSelectedIndexChanged="ddlintppqk_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>大于</asp:ListItem>
                                <asp:ListItem>大于等于</asp:ListItem>
                                <asp:ListItem>小于</asp:ListItem>
                                <asp:ListItem>小于等于</asp:ListItem>
                                <asp:ListItem>等于</asp:ListItem>
                                <asp:ListItem>区间值</asp:ListItem>
                                <asp:ListItem>含等于区间值</asp:ListItem>
                            </asp:DropDownList>
                            <div id="divint1" runat="server"><asp:TextBox ID="txtint" runat="server" Width="160px"></asp:TextBox></div>
                            <div id="divint2" runat="server" visible="false">
                                最小值：<asp:TextBox ID="txtintmin" runat="server" Width="160px"></asp:TextBox>
                                最大值：<asp:TextBox ID="txtintmax" runat="server" Width="160px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="divdatetime" runat="server" visible="false">
                            <asp:DropDownList ID="ddlDateType" runat="server">
                                <asp:ListItem>大于</asp:ListItem>
                                <asp:ListItem>大于等于</asp:ListItem>
                                <asp:ListItem>小于</asp:ListItem>
                                <asp:ListItem>小于等于</asp:ListItem>
                                <asp:ListItem>等于</asp:ListItem>
                                <asp:ListItem>区间值</asp:ListItem>
                                <asp:ListItem>含等于区间值</asp:ListItem>
                            </asp:DropDownList>
                            <div id="divdatetime1" runat="server">
                            <asp:DropDownList ID="ddlDateTime" runat="server">
                                <asp:ListItem Value="一天">一天</asp:ListItem>
                                <asp:ListItem>三天</asp:ListItem>
                                <asp:ListItem>一周</asp:ListItem>
                                <asp:ListItem>一旬</asp:ListItem>
                                <asp:ListItem>半个月</asp:ListItem>
                                <asp:ListItem>一个月</asp:ListItem>
                                <asp:ListItem>三个月</asp:ListItem>
                                <asp:ListItem>半年</asp:ListItem>
                                <asp:ListItem>一年</asp:ListItem>
                                <asp:ListItem>二年</asp:ListItem>
                                <asp:ListItem>三年</asp:ListItem>
                                <asp:ListItem>四年</asp:ListItem>
                                <asp:ListItem>五年</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div id="divdatetime2" runat="server" visible="false">
                                最小值：<asp:DropDownList ID="ddldatemin" runat="server">
                                <asp:ListItem Value="一天">一天</asp:ListItem>
                                <asp:ListItem>三天</asp:ListItem>
                                <asp:ListItem>一周</asp:ListItem>
                                <asp:ListItem>一旬</asp:ListItem>
                                <asp:ListItem>半个月</asp:ListItem>
                                <asp:ListItem>一个月</asp:ListItem>
                                <asp:ListItem>三个月</asp:ListItem>
                                <asp:ListItem>半年</asp:ListItem>
                                <asp:ListItem>一年</asp:ListItem>
                                <asp:ListItem>二年</asp:ListItem>
                                <asp:ListItem>三年</asp:ListItem>
                                <asp:ListItem>四年</asp:ListItem>
                                <asp:ListItem>五年</asp:ListItem>
                            </asp:DropDownList>
                                最大值：<asp:DropDownList ID="ddldatemax" runat="server">
                                <asp:ListItem Value="一天">一天</asp:ListItem>
                                <asp:ListItem>三天</asp:ListItem>
                                <asp:ListItem>一周</asp:ListItem>
                                <asp:ListItem>一旬</asp:ListItem>
                                <asp:ListItem>半个月</asp:ListItem>
                                <asp:ListItem>一个月</asp:ListItem>
                                <asp:ListItem>三个月</asp:ListItem>
                                <asp:ListItem>半年</asp:ListItem>
                                <asp:ListItem>一年</asp:ListItem>
                                <asp:ListItem>二年</asp:ListItem>
                                <asp:ListItem>三年</asp:ListItem>
                                <asp:ListItem>四年</asp:ListItem>
                                <asp:ListItem>五年</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <asp:TextBox ID="txtdatetime" runat="server" Width="160px" Visible="False"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        描述：</td>
                    <td colspan="3" align="left"><asp:TextBox ID="txtDiscription" BorderStyle="Groove" TextMode="MultiLine" Height="50px" runat="server" Width="478px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 318px">
                        <input type="text" id="pk" name="pk" visible="false" runat="server" value="" style="width: 35px" />
                        <input type="text" id="tn" name="tn" visible="false" runat="server" value="" style="width: 35px" />
                        <input type="text" id="ifadd" name="ifadd" visible="false" runat="server" value="1" style="width: 35px" /></td>
                    <td>
                        <asp:Button ID="btDo" runat="server" Text="添加" OnClick="btDo_Click" /></td>
                    <td>
                        <input id="Reset1" type="reset" value="重填" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
