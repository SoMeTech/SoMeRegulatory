<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="DataRowPowerList.aspx.cs" stylesheettheme="Default" inherits="User_DataRowPowerList" %>

<%@ Register Src="../../WebControls/PageNavigator.ascx" TagName="PageNavigator" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script src="../../jss/GridViewChangeColor.js" type="text/javascript" charset="gb2312"></script>
    <script src="../../jss/Qx_nz.js" type="text/javascript" charset="gb2312"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="text-align: left">
                    <%--<table border="1" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="text-align: left" colspan="3">
                                名称：<asp:TextBox ID="txtname" runat="server" BorderStyle="Groove"></asp:TextBox>
                                <asp:Button ID="btSearch" runat="server" BorderStyle="Groove" OnClick="btSearch_Click"
                                    Text="搜索" /></td>
                        </tr>
                    </table>--%>
                                <input id="ifadd" runat="server" name="ifadd" style="width: 35px" type="text" value="1"
                                    visible="false" /><input id="pk" runat="server" name="pk" style="width: 35px" type="text" visible="false" /><input id="tn" runat="server" name="tn" style="width: 35px" type="text" visible="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BorderStyle="Ridge" Width="750px" Height="300px"> 
                                <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                                   ContextMenuCssClass="RightMenu" Width="1000px" OnRowDeleting="gvResult_RowDeleting" OnRowUpdating="gvResult_RowUpdating"  DataKeyNames="PK">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle width="15px" />
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="../images/bullet.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="名称" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                <asp:TextBox ID="txtPK" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PK") %>' Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="权限编码" SortExpression="PowerCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lbPowerCode" runat="server" Text='<%# Bind("PowerCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数据表名" SortExpression="TableName">
                                            <ItemTemplate>
                                                <asp:Label ID="lbTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数据列名" SortExpression="ColumnName">
                                            <ItemTemplate>
                                                <asp:Label ID="lbColumnName" runat="server" Text='<%# Bind("ColumnName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="字段类型" SortExpression="TJType">
                                            <ItemTemplate>
                                                <asp:Label ID="lbTJType" runat="server" Text='<%# Bind("TJType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="查询条件" SortExpression="strWhere">
                                            <ItemTemplate>
                                                <asp:Label ID="lbstrWhere" runat="server" Text='<%# Bind("strWhere") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="描述" SortExpression="discription">
                                            <ItemTemplate>
                                                <asp:Label ID="lbdiscription" runat="server" Text='<%# Bind("discription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="40px" />
                                            <ItemTemplate>
                                                <asp:Button ID="btSelect" runat="server" BorderStyle="Groove" CausesValidation="False"
                                                    CommandName="Update" Text="选择" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="40px" />
                                            <ItemTemplate>
                                                <asp:Button ID="btDelete" runat="server" BorderStyle="Groove" CausesValidation="False"
                                                    CommandName="Delete" OnClientClick="return confirm('确认要删除吗？');" Text="删除" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FixRowColumn FixColumns="0,1" FixRows="" FixRowType="Header,Pager" />
                                </yyc:SmartGridView>
                                </asp:Panel>
                                <uc1:PageNavigator ID="PageNavigator1" runat="server" />
                             </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
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
