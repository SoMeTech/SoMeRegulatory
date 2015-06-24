<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="RoleAdd.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Role_RoleAdd" %>

<%@ Register Src="../../../WebControls/PowerServices.ascx" TagName="PowerServices"
    TagPrefix="uc3" %>
<%@ Register Src="../../../WebControls/PowerRow.ascx" TagName="PowerRow" TagPrefix="uc2" %>
<%@ Register Src="../../../WebControls/PowerMenu.ascx" TagName="PowerMenu" TagPrefix="uc1" %>

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

    <script src="../../../PublicMode/jss/Check.js" type="text/javascript" charset="gb2312"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "";

            if (document.all['<%=txtCompany.ClientID %>'].value != "") {
            webFileUrl = "../../../PublicMode/DiagList/GetSession.aspx?tn=" + val + "&pk_corp=" + document.getElementById('<%=txtssgspk.ClientID %>').value;
        }
        else {
            if (num == '2') {
                alert('请先选择单位再选择部门！');
                return false;
            }
            else {
                webFileUrl = "../../../PublicMode/DiagList/GetSession.aspx?tn=" + val;
            }
        }

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
            if (num == "1") {
                document.all['<%=txtCompany.ClientID %>'].value = ss[1];
                document.all['<%=txtssgspk.ClientID %>'].value = ss[0];
            }
            if (num == "2") {
                document.all['<%=txtBranch.ClientID %>'].value = ss[1];
                document.all['<%=txtssbmpk.ClientID %>'].value = ss[0];
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
                            </td>
                        </tr>
                        <tr style="height: 40px">
                            <td align="right">
                                角色名称<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td align="right">
                                角色编号<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtjsbh" runat="server" Width="200px" onblur="doCheck(this,'../../../PublicMode/DiagList/DisposeEvent.aspx?BH=','编号已经存在','1','checkRoleBH')"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                                <div id="divbh" runat="server" style="display: none;">
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 40px">
                            <td align="right">
                                所属单位<font color="red">*</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCompany" runat="server" onclick="javascript:findwindow('Company','1');"
                                    Height="15px" Width="180px"  style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../../jquery.easyui/css/images/search_2.png" onclick="javascript:findwindow('Company','1');"
                                    alt="查找档案信息" />
                            </td>
                            <td align="right">
                                所属部门</font>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBranch" runat="server" onclick="javascript:findwindow('Branch','2');"
                                    Height="15px" Width="180px" style="border-right-style:none;float:left;" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../../jquery.easyui/css/images/search_2.png"onclick="javascript:findwindow('Branch','2');" alt="查找部门信息" />
                            </td>
                        </tr>
                        <tr style="height: 40px">
                            <td align="right">
                                是否启用权限<font color="red">*</font>
                            </td>
                            <td align="left" colspan="3">
                                <asp:DropDownList ID="ddlsfqyqx" runat="server" Width="200px">
                                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                                    <asp:ListItem Value="0">不启用</asp:ListItem>
                                </asp:DropDownList>
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
                                <uc1:PowerMenu ID="PowerMenu1" runat="server" />
                            </td>
                            <td align="left">
                                <uc3:PowerServices ID="PowerServices1" runat="server" />
                                <uc2:PowerRow ID="PowerRow1" runat="server" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    
</asp:Content>
