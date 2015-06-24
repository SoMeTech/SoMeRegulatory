<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="DataPower.aspx.cs" stylesheettheme="Default" inherits="User_DataPower" %>

<%@ Register Src="../../WebControls/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据权限</title>
    <link href="../css/Admin_Style.css" rel="stylesheet" type="text/css" />
    <script src="../jss/GridViewChangeColor.js" type="text/javascript"></script>
    <script src="../jss/Qx_nz.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table border="1" cellpadding="0" cellspacing="0" style="background-color: #BFDBFF; border-color:#f5f5f5;">
            <tr>
                <td>
                    <table border="1" cellpadding="0" cellspacing="0" width="100%" style="background-color: #BFDBFF; border-color:#f5f5f5;">
                        <tr>
                            <td>
                                业务数据：</td>
                            <td align="left">
                                <asp:DropDownList ID="ddltablename" runat="server">
                                </asp:DropDownList></td>
                            <td style="text-align: right">
                                数据列：</td>
                            <td align="left"><asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                匹配情况：</td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>模糊匹配</asp:ListItem>
                                    <asp:ListItem>前匹配</asp:ListItem>
                                    <asp:ListItem>后匹配</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="text-align: right">
                                满足情况：</td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>同时满足</asp:ListItem>
                                    <asp:ListItem>只要一样满足</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                限制条件：</td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox1" runat="server" Width="317px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                描述：</td>
                            <td colspan="3" align="left"><asp:TextBox ID="txtDiscription" BorderStyle="Groove" TextMode="MultiLine" Height="50px" runat="server" Width="384px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><input type="text" id="pk" name="pk" visible="false" runat="server" value="" style="width: 35px" />
                                <input type="text" id="tn" name="tn" visible="false" runat="server" value="" style="width: 35px" />
                                <input type="text" id="ifadd" name="ifadd" visible="false" runat="server" value="1" style="width: 35px" /></td>
                            <td>
                                <asp:Button ID="btSearch" runat="server" Text="搜索" BorderStyle="Groove" /></td>
                            <td>
                                <asp:Button ID="btDo" runat="server" Text="添加" BorderStyle="Groove" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #BFDBFF; border-color:#f5f5f5;">
                        <tr>
                            <td align="center"><asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvResult_RowDeleting"  OnRowUpdating="gvResult_RowUpdating" AllowPaging="True">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="30px" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="../images/bullet.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="名称" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="说明" SortExpression="Discription">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDiscription" runat="server" Text='<%# Bind("Discription") %>' Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="上级名称" SortExpression="FatherPK">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPKPath" runat="server" Text='<%# Bind("PKPath") %>' Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtFatherPK" runat="server" Text='<%# Bind("FatherPK") %>' Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="等级" SortExpression="Grade">
                                        <ItemTemplate>
                                            <asp:Label ID="lbGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="是否有下级" SortExpression="IsHasBaby">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="40px" />
                                        <ItemTemplate>
                                            <asp:Button ID="btSelect" BorderStyle="Groove" runat="server" CausesValidation="False" CommandName="Update"
                                                Text="选择" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="40px" />
                                        <ItemTemplate>
                                            <asp:Button ID="btDelete" BorderStyle="Groove" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('确认要删除吗？');" Text="删除" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#dcdcdc" Font-Bold="True" ForeColor="Black" Font-Size="12px" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView></td>
                        </tr>
                        <tr>
                            <td style="height: 19px">
                                <uc1:PageControl ID="pcPage" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
