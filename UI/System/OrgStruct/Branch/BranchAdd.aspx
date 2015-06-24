<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="BranchAdd.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Branch_BranchAdd" %>

<%@ Register Src="~/WebControls/PowerCompany.ascx" TagName="PowerCompany" TagPrefix="uc2" %>
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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Shared/jss/Check.js")%>"
        type="text/javascript" charset="gb2312"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, num) {
            if (document.all['<%=txtssgs.ClientID %>'].value != "") {
                var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&&pk_corp=" + document.all['<%=txtssgspk.ClientID %>'].value + "";
            }
            else {
                if (num == '3') {
                    alert('请先选择单位再选择负责人！');
                    return false;
                }
                else {
                    var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val;
                }
            }

            //alert(webFileUrl);
            var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
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
                    document.all['<%=txtsjbm.ClientID %>'].value = ss[1];
                    document.all['<%=txtsjbmpk.ClientID %>'].value = ss[0];
                }
                if (num == "3") {
                    document.all['<%=txtfzr.ClientID %>'].value = ss[1];
                    document.all['<%=txtfzrpk.ClientID %>'].value = ss[0];
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
            <HeaderTemplate>
                基本信息
            </HeaderTemplate>
            <ContentTemplate>
                <div style="width: 100%; height: 100%;">
                    <table width="100%">
                        <tr height="15px">
                            <td>
                                <input id="txtssgspk" type="hidden" value="" runat="server" />
                                <input id="txtsjbmpk" type="hidden" value="" runat="server" />
                                <input id="txtfzrpk" type="hidden" value="" runat="server" />
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                所属单位<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtssgs" runat="server" Width="180px" style="border-right-style:none;float:left;"  onclick="javascript:findwindow('Company','1');"
                                    onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                    <img   src="../../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Company','1');" alt="查找档案信息" />
                            </td>
                            <td align="right">
                                上级部门
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtsjbm" runat="server" Width="180px" style="border-right-style:none;float:left;" onclick="javascript:findwindow('Branch','2');"
                                    onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img  src="../../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Branch','2');" alt="查找档案信息" />
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                部门编号<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtbmbh" runat="server" Width="200px" onblur="doCheck(this,'../../../Shared/DiagList/DisposeEvent.aspx?BH=','部门编号已经存在','1','checkBranchBH')"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                                <div id="divbh" runat="server" style="display: none;">
                                </div>
                            </td>
                            <td align="right">
                                部门名称<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                负责人
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtfzr" runat="server" Width="180px" style="border-right-style:none;float:left;" onclick="javascript:findwindow('Employee','3');"
                                    onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox><img
                                        src="../../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Employee','3');"
                                        alt="查找档案信息" />
                            </td>
                            <td align="right">
                                电子邮箱
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtemail" runat="server" Width="200px" onblur="nz_mail(this,'电子邮箱填写不正确！')"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                联系电话
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtphone" runat="server" Width="200px" onkeydown="return onlyNum1();"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td align="right">
                                传真
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtfax" runat="server" Width="200px" onkeydown="return onlyNum1();"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="30">
                            <td align="right">
                                部门地址
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtaddress" runat="server" Width="610px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" closable="False" HeaderText="权限设置">
            <ContentTemplate>
                <div style="width: 100%; height: 100%">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <uc2:PowerCompany ID="PowerCompany1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
