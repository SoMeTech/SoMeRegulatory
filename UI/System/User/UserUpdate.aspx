<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="UserUpdate.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="User_UserUpdate" %>

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

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "";

            if (document.all['<%=txtssgspk.ClientID %>'].value != "") {
                if (num == '3' && document.all['<%=txtssbmpk.ClientID %>'].value == "") {
                    alert('请先选择单位和部门再选择角色！');
                    return false;
                }
                else {
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pk_corp=" + document.getElementById('<%=txtssgspk.ClientID %>').value + "&branchpk=" + document.getElementById('<%=txtssbmpk.ClientID %>').value;
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
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                }
            }

            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
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
            if (pwd.value != "" && pwd1.value != "") {
                if (pwd.value != pwd1.value) {
                    alert('确认密码与密码不一致！');
                    pwd1.value = "";
                    pwd.value = "";
                    pwd.focus();
                }
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
                                <asp:Label ID="labssgspk" runat="server" Visible="false">所属单位PK</asp:Label>
                                <input id="txtssgspk" type="hidden" runat="server" />
                                <input id="txtssgspk_bak" type="hidden" runat="server" />
                                <asp:Label ID="labssbmpk" runat="server" Visible="false">所属部门PK</asp:Label>
                                <input id="txtssbmpk" type="hidden" runat="server" />
                                <input id="txtssbmpk_bak" type="hidden" runat="server" />
                                <asp:Label ID="labssjspk" runat="server" Visible="false">所属角色PK</asp:Label>
                                <input id="txtssjspk" type="hidden" runat="server" />
                                <input id="txtssjspk_bak" type="hidden" runat="server" />
                                <asp:Label ID="labcompower" runat="server" Visible="false">管理范围</asp:Label>
                                <input id="txtcompower" type="hidden" runat="server" />
                                <input id="txtcompower_bak" type="hidden" runat="server" />
                                <asp:Label ID="labrolepower" runat="server" Visible="false">数据行权限</asp:Label>
                                <input id="txtrolepower" type="hidden" runat="server" />
                                <input id="txtrolepower_bak" type="hidden" runat="server" />
                                <asp:Label ID="labserpower" runat="server" Visible="false">业务权限</asp:Label>
                                <input id="txtserpower" type="hidden" runat="server" />
                                <input id="txtserpower_bak" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                <asp:Label ID="labssgs" runat="server">所属单位</asp:Label><font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtssgs" runat="server" Width="180px" onclick="javascript:findwindow('Company','1');"
                                    style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Company','1');" alt="查找档案信息" />
                                <asp:TextBox ID="txtssgs_bak" runat="server" Visible="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="labssbm" runat="server">所属部门</asp:Label><font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtssbm" runat="server" Width="180px" onclick="javascript:findwindow('Branch','2');"
                                     style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Branch','2');" alt="查找档案信息" />
                                <asp:TextBox ID="txtssbm_bak" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                <asp:Label ID="labssjs" runat="server">用户角色</asp:Label><font color="red">*</font>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtssjs" runat="server" Width="180px" onclick="javascript:findwindow('Role','3');"
                                     style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox><img
                                      <img src="../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Role','3');" alt="查找档案信息" />
                                <asp:TextBox ID="txtssjs_bak" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                <asp:Label ID="labUserName" runat="server">用户名</asp:Label><font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUserName" runat="server" onblur="doCheck(this,'../../Shared/DiagList/DisposeEvent.aspx?Name=','用户名已经存在','1','checkUserName')"
                                    Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                                <asp:TextBox ID="txtUserName_bak" runat="server" Visible="false"></asp:TextBox>
                                <div id="divbh" runat="server" style="display: none;">
                                </div>
                            </td>
                            <td align="right">
                                <asp:Label ID="labTrueName" runat="server">真实姓名</asp:Label><font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTrueName" runat="server" Width="200px"></asp:TextBox>
                                <asp:TextBox ID="txtTrueName_bak" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30px">
                            <td align="right">
                                <asp:Label ID="labPwd" runat="server">密码</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="password" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                                <asp:TextBox ID="txtPwd_bak" runat="server" Visible="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server">确认密码</asp:Label>
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
                                <input id="txtcombak" type="hidden" runat="server" />
                            </td>
                            <td align="left">
                                <uc2:PowerMenu ID="PowerMenu1" runat="server" />
                                <input id="txtmenubak" type="hidden" runat="server" />
                                <uc3:PowerRow ID="PowerRow1" runat="server" Visible="false" />
                                <input id="txtrowbak" type="hidden" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
