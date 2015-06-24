<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="UserAdd.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="User_UserAdd" %>

<%@ Register Src="../../WebControls/PowerCompany.ascx" TagName="PowerCompany" TagPrefix="uc4" %>
<%@ Register Src="../../WebControls/PowerRow.ascx" TagName="PowerRow" TagPrefix="uc3" %>
<%@ Register Src="../../WebControls/PowerMenu.ascx" TagName="PowerMenu" TagPrefix="uc2" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
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

    <script src="../../PublicMode/jss/Check.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "";

            if (document.all['<%=txtssgspk.ClientID %>'].value != "") {
                if (num == '3' && document.all['<%=txtssbmpk.ClientID %>'].value == "") {
                    alert('请先选择单位和部门再选择角色！');
                    return false;
                }
                else {
                    webFileUrl = "../../PublicMode/DiagList/GetSession.aspx?tn=" + val + "&pk_corp=" + document.getElementById('<%=txtssgspk.ClientID %>').value + "&branchpk=" + document.getElementById('<%=txtssbmpk.ClientID %>').value;
                }
            }
            else {
                if (num == '2') {
                    alert('请先选择单位再选择部门！');
                    return false;
                }
                else if (num == '3' && document.all['<%=txtssbmpk.ClientID %>'].value == "") {
                    alert('请先选择单位和部门再选择角色！');
                    return false;
                }
                else {
                    webFileUrl = "../../PublicMode/DiagList/GetSession.aspx?tn=" + val;
                }
            }

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
                    document.all['<%=txtssgs.ClientID %>'].value = ss[1];
                    document.all['<%=txtssgspk.ClientID %>'].value = ss[0];
                }
                if (num == "2") {
                    document.all['<%=txtssbm.ClientID %>'].value = ss[1];
                    document.all['<%=txtssbmpk.ClientID %>'].value = ss[0];
                }
                if (num == "3") {
                    document.all['<%=txtssjs.ClientID %>'].value = ss[1];
                    document.all['<%=txtssjspk.ClientID %>'].value = ss[0];
                }
            }
        }

        function compareToPwd() {
            var pwd = document.getElementById('<%=txtPwd.ClientID %>');
            var pwd1 = document.getElementById('<%=txtpass.ClientID %>');
            var flog = 1;
            if (pwd.value != "") {
                if (pwd.value != pwd1.value) {
                    alert('确认密码与密码不一致！');
                    pwd1.value = "";
                    pwd.value = "";
                    pwd.focus();
                }
            }
        }

        function doCheck(val, url, text, num, code) {
            if (num == "1") {
                checkIsRepeat(val, url, text, document.all['<%=divbh.ClientID %>'], code);
            }
        }
    </script>

    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Height="500px">
        <cc1:TabPanel ID="TabPanel1" runat="server" closable="False" HeaderText="基本信息">
            <ContentTemplate>
                <div style=" width: 100%; height: 100%">
                    <table width="100%">
                        <tr height="15px">
                            <td>
                                <input id="txtssgspk" type="hidden" runat="server" />
                                <input id="txtssbmpk" type="hidden" runat="server" />
                                <input id="txtssjspk" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                所属单位<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtssgs" runat="server" Width="180px" onclick="javascript:findwindow('Company','1');"
                                     style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Company','1');" alt="查找档案信息" />
                            </td>
                            <td align="right">
                                所属部门<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtssbm" runat="server" Width="180px" onclick="javascript:findwindow('Branch','2');"
                                    style="border-right-style:none;float:left;"  onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Branch','2');" alt="查找档案信息" />
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                用户角色<font color="red">*</font>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtssjs" runat="server" Width="180px" onclick="javascript:findwindow('Role','3');"
                                    style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox><img
                                        src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Role','3');" alt="查找档案信息" />
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                用户名<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUserName" runat="server" onblur="doCheck(this,'../../PublicMode/DiagList/DisposeEvent.aspx?Name=','用户名已经存在','1','checkUserName')"
                                    Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                                <div id="divbh" runat="server" style="display: none;">
                                </div>
                            </td>
                            <td align="right">
                                真实姓名<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTrueName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                密码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="password" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td align="right">
                                确认密码
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtpass" runat="server" TextMode="password" Width="200px" onblur="compareToPwd()"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" closable="False" HeaderText="权限设置">
            <ContentTemplate>
                <div style=" width: 100%; height: 100%">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <uc4:PowerCompany ID="PowerCompany1" runat="server" />
                            </td>
                            <td align="left">
                                <uc2:PowerMenu ID="PowerMenu1" runat="server" />
                                <uc3:PowerRow ID="PowerRow1" runat="server" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
