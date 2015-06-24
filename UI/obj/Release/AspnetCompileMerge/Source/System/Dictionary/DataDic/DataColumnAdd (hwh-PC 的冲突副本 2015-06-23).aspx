<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="DataColumnAdd.aspx.cs" title="无标题页" enableeventvalidation="false" stylesheettheme="Default" inherits="SystemSetup_Dictionary_DataDic_DataColumnAdd" %>

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

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "../../../PublicMode/DiagList/GetSession.aspx?tn=" + val;
            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            if (arr != null) {
                if (arr != "false")
                    helpMess(arr, num);
            }
        }

        function helpMess(val, num) {
            if (val.indexOf("~") > 0) {
                ss = val.split("~");
                if (num == "10") {
                    strs = ss[0].split("|");
                    if (strs.length <= 1) {
                        strs = ['', '', '', '', '', '', '', '', '', ''];
                    }

                    document.all['<%=txtTablePK.ClientID %>'].value = strs[1];
                    document.all['<%=txtTable.ClientID %>'].value = ss[1];
                }
            }
        }
    </script>

    <table width="100%">
        <tr height="15px">
            <td>
                <input id="txtTablePK" type="hidden" runat="server" />
            </td>
        </tr>
        <tr height="30px">
            <td align="right">
                数据表名<font color="red">*</font>
            </td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtTable" runat="server" onclick="javascript:findwindow('DB_DataTable','10');"
                    Width="200px" Style="border-color: #000080; border-style: none none groove none;
                    border-width: 1px; " onkeypress="return fifteenth(this, event)"
                    ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../../images/8.png" onclick="javascript:findwindow('DB_DataTable','10');"
                    alt="查找档案信息" />
            </td>
        </tr>
        <tr height="30px">
            <td align="right">
                字段中文名<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtZDZWName" runat="server" Width="200px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td align="right">
                字段英文名<font color="red">*</font>
            </td>
            <td align="left">
                <asp:TextBox ID="txtZDYWName" runat="server" Width="200px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr height="30px">
            <td align="right">
                说明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtRemark" runat="server" Width="525px" Style="border-color: #000080;
                    border-style: none none groove none; border-width: 1px; "
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
