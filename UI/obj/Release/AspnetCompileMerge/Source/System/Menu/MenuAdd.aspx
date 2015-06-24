<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" CodeBehind="MenuAdd.aspx.cs" autoeventwireup="true" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_MenuAdd" %>

<%@ Register Src="../WebControls/Menu_ImageLoad.ascx" TagName="Menu_ImageLoad" TagPrefix="uc2" %>
<%--<%@ Register Src="../../WebControls/NDropDownList.ascx" TagName="NDropDownList" TagPrefix="uc1" %>--%>
<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (!Page.IsPostBack) %>
    <%{ %>
    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/Loading.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/dowaitOpen.js") %>" type="text/javascript"></script>

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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Shared/jss/Check.js")%>"
        type="text/javascript" charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;

            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px; resizable:0; help:0; status:0");
            if (arr != null) {
                if (arr != "false")
                    helpMess(arr, num);
            }
        }

        function helpMess(val, num) {
            if (val.indexOf("~") > 0) {
                ss = val.split("~");
                if (num == "1") {
                    document.all['<%=txtFartherMenu.ClientID %>'].value = ss[1];
                    document.all['<%=FartherMenuPK.ClientID %>'].value = ss[0];
                }
            }
        }

        function doCheck(val, url, text, num, code) {
            if (num == "1") {
                checkIsRepeat(val, url, text, document.all['<%=divbh.ClientID %>'], code);
            }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <script src="../../Shared/jss/Check.js" type="text/javascript"></script>

            <table cellpadding="0" cellspacing="0" class="menutext" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tbody>
                    <tr height="15px">
                    </tr>
                    <tr height="40">
                        <td style="width: 113px" align="right" height="30">
                            上级菜单
                        </td>
                        <td align="left" height="30">
                            <asp:TextBox runat="server" ID="txtFartherMenu" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;" onfocus="findwindow('Menu','1')"
                                ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox><input id="FartherMenuPK" runat="server" type="hidden" />
                            <img src="../../images/8.png" onclick="javascript:findwindow('Menu','1');" alt="查找档案信息" />
                            <%--<uc1:NDropDownList id="nd1" runat="server"></uc1:NDropDownList>--%>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                            菜单名称<font color="red">*</font>
                        </td>
                        <td style="width: 248px; text-align: left" height="30">
                            <label>
                                <asp:TextBox ID="txtMenuName" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;"></asp:TextBox></label>
                        </td>
                    </tr>
                    <tr height="40">
                        <td style="width: 113px" align="right" height="30">
                            权限编码
                        </td>
                        <td style="width: 196px" align="left" height="30">
                            <label>
                                <span style="color: #000000">
                                    <asp:TextBox ID="txtfwqxbm" runat="server" onblur="doCheck(this,'../../Shared/DiagList/DisposeEvent.aspx?PowerCode=','权限编码已经存在','1','CheckMenuPowerCode')" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;"></asp:TextBox></span></label>
                            <div id="divbh" runat="server" style="display: none;">
                            </div>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                            菜单路径
                        </td>
                        <td style="width: 248px; text-align: left" height="30">
                            <asp:TextBox ID="txtMenuUrl" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;"></asp:TextBox><input id="Button1"
                                onclick="javascript:var re_val=window.showModalDialog('showurl.aspx', window, 'dialogWidth:650px; dialogHeight:450px; resizable:0; help:0; scroll:0; status:0');document.forms.item(0).<%=txtMenuUrl.ClientID%>    .value=re_val;"
                                type="button" value="选择" />
                        </td>
                    </tr>
                    <tr height="40">
                        <td style="width: 113px; height: 30px" align="right">
                            菜单窗口
                        </td>
                        <td style="width: 196px; height: 30px" align="left">
                            <asp:DropDownList ID="drpdWindow" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">
                                <asp:ListItem Selected="True" Value="">--请选择--</asp:ListItem>
                                <asp:ListItem Value="mainFrame">主窗体</asp:ListItem>
                                <asp:ListItem Value="_blank">新窗体</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 117px; height: 30px" align="right">
                            权限状态
                        </td>
                        <td style="width: 248px; height: 30px; text-align: left">
                            <asp:DropDownList ID="drpdPodomZT" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">
                                <asp:ListItem Selected="True" Value="">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">需要验证</asp:ListItem>
                                <asp:ListItem Value="0">无需验证</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="40">
                        <td style="width: 113px; height: 30px" align="right">
                            是否展开
                        </td>
                        <td style="width: 196px; height: 30px" align="left">
                            <asp:DropDownList ID="txtTally" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">
                                <asp:ListItem Selected="True" Value="0">不展开</asp:ListItem>
                                <asp:ListItem Value="1">展开</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 117px; height: 30px" align="right">
                            是否显示
                        </td>
                        <td style="width: 248px; height: 30px; text-align: left">
                            <asp:DropDownList ID="drpdIsList" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">
                                <asp:ListItem Selected="True" Value="">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">显示</asp:ListItem>
                                <asp:ListItem Value="0">不显示</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="60">
                        <td style="width: 113px" align="right" height="30">
                            排序状态
                        </td>
                        <td style="width: 196px" align="left" height="30">
                            <asp:TextBox ID="txtMenuPX" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">0</asp:TextBox>
                        </td>
                        <td style="width: 117px" align="right" height="30">
                            菜单类型
                        </td>
                        <td style="width: 248px; text-align: left" height="30">
                            <asp:DropDownList ID="DrpType" runat="server" Width="200px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;">
                                <asp:ListItem Selected="True" Value="">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">后台菜单</asp:ListItem>
                                <asp:ListItem Value="2">前台菜单</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                    </tr>
                    <tr height="60">
                        <td style="width: 113px; height: 30px" align="right">
                            菜单图片
                        </td>
                        <td colspan="3" align="left">
                            <uc2:Menu_ImageLoad ID="fl1" runat="server"></uc2:Menu_ImageLoad>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 117px; height: 30px" align="right">
                            菜单描叙
                        </td>
                        <td style="width: 248px; height: 30px; text-align: left" colspan="3">
                            <asp:TextBox ID="txtMenuMemo" runat="server" Width="580px" Style=" border: 1px solid #CCCCCC; background-color: #FFFFFF; padding:2px;" BorderColor="#CCCCCC"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
