<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="newDictionary.aspx.cs" title="无标题页" enableeventvalidation="false" stylesheettheme="Default" inherits="Dictionary_newDictionary" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<%--<%@ Register Src="../../WebControls/NDropDownList.ascx" TagName="NDropDownList" TagPrefix="uc2" %>--%>
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

    <script src="../../PublicMode/jss/Check.js" charset="gb2312"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">

        function findwindow(num) {
            var webFileUrl = "../../PublicMode/DiagList/GetSession.aspx?tn=" + document.getElementById('<%=tableName.ClientID %>').value;
            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");
            var arr = window.showModalDialog("../../PublicMode/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            if (arr != null) {
                if (arr != "false")
                    helpMess(arr, num);
            }
        }

        function helpMess(val, num) {
            if (val.indexOf("~") > 0) {
                ss = val.split("~");
                if (num == "1") {
                    document.all['<%=FatherPk.ClientID %>'].value = ss[0];
                    document.all['<%=txtFatherPk.ClientID %>'].value = ss[1];
                }
            }
        }

        function doCheck(val, text, num, code) {
            if (document.all['<%=flog.ClientID %>'].value == 'add') {
                if (num == "1") {
                    checkIsRepeat(val, '../../PublicMode/DiagList/DisposeEvent.aspx?tableName=' + document.all['<%=tableName.ClientID %>'].value + '&BH=', text, document.all['<%=divbh.ClientID %>'], code);
                }
            }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr height="15px">
                    <td>
                        <input type="hidden" id="tableName" runat="server" />
                        <input type="hidden" id="flog" runat="server" />
                        <input id="FatherPk" type="hidden" runat="server" />
                    </td>
                </tr>
                <tr height="30px">
                    <td align="center">
                        名称<font color="red">*</font>
                    </td>
                    <td style="text-align: left; height: 30px;">
                        <asp:TextBox ID="txtname" runat="server" Width="200px" onblur="checkName(this);"
                            Style="border-color: #000080; border-style: none none groove none; border-width: 1px;
                            " onkeypress="return fifteenth(this, event)"></asp:TextBox>
                    </td>
                    <td align="right">
                        编号<font color="red">*</font>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBH" runat="server" Width="200px" Style="border-color: #000080;
                            border-style: none none groove none; border-width: 1px; "
                            onblur="doCheck(this,'编号已经存在','1','checkUsualBookTable')" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                        <div id="divbh" runat="server" style="display: none;">
                        </div>
                    </td>
                </tr>
                <tr height="30px">
                    <td align="right">
                        上级名称
                    </td>
                    <%--<td>
                        <uc2:NDropDownList ID="nd1" runat="server" />
                    </td>--%>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtFatherPk" runat="server" onclick="javascript:findwindow('1');"
                            Width="200px" Style="border-color: #000080; border-style: none none groove none;
                            border-width: 1px; " onkeypress="return fifteenth(this, event)"
                            ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                        <img src="../../images/8.png" onclick="javascript:findwindow('1');" alt="查找档案信息" />
                    </td>
                </tr>
                <tr height="30px">
                    <td align="right">
                        描述
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtDiscription" runat="server" Width="600px" Style="border-color: #000080;
                            border-style: none none groove none; border-width: 1px; "
                            onkeypress="return fifteenth(this, event)"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
