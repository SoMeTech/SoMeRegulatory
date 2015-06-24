<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" title="无标题页" CodeBehind="DataTableAdd.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="SystemSetup_Dictionary_DataDic_DataTableAdd" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitUpdate.js") %>" type="text/javascript"></script>

    <div id="loading">
        <div class="loading-indicator">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin-right: 8px;" align="absmiddle" />
            Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    <%} %>

    <script src="../../../PublicMode/jss/Check.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <table width="100%">
        <tr height="15px">
        </tr>
        <tr height="30px">
            <td align="right">
                表中文名<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtZWName" runat="server" Width="200px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    Font-Bold="True" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                表英文名<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtYWName" runat="server" Width="200px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    Font-Bold="True" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr height="30px">
            <td align="right">
                说明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtRemark" runat="server" Width="500px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    Font-Bold="True" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
