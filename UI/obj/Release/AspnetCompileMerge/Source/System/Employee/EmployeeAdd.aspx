<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="EmployeeAdd.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Employee_EmployeeAdd" %>

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

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        function findwindow(val, num) {
            var webFileUrl = "";

            if (document.all['<%=txtssgspk.ClientID %>'].value != "") {
                if (num == '3' && document.all['<%=txtssbmpk.ClientID %>'].value == "") {
                    alert('请先选择公司和部门再选择角色！');
                    return false;
                }
                else {
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pk_corp=" + document.getElementById('<%=txtssgspk.ClientID %>').value + "&branchpk=" + document.getElementById('<%=txtssbmpk.ClientID %>').value;
                }
            }
            else {
                if (num == '2') {
                    alert('请先选择公司再选择部门！');
                    return false;
                }
                else if (num == '3' && document.all['<%=txtssbmpk.ClientID %>'].value == "") {
                    alert('请先选择公司和部门再选择角色！');
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
                    document.all['<%=txtCompany.ClientID %>'].value = ss[1];
                    document.all['<%=txtssgspk.ClientID %>'].value = ss[0];
                }
                if (num == "2") {
                    document.all['<%=txtBranch.ClientID %>'].value = ss[1];
                    document.all['<%=txtssbmpk.ClientID %>'].value = ss[0];
                }
                if (num == "3") {
                    document.all['<%=txtRole.ClientID %>'].value = ss[1];
                    document.all['<%=txtssjspk.ClientID %>'].value = ss[0];
                }
            }
        }

        $(document).ready(function () {
            $('#<%=txtBirthDay.ClientID %>').datepicker({ dateFormat: 'yy-m-d', showOn: 'button', buttonImage: '<%=QxRoom.Common.Public.RelativelyPath("images/calendar.gif") %>', buttonImageOnly: true });
        });

        function doCheck(val, url, text, num, code) {
            if (num == "1") {
                checkIsRepeat(val, url, text, document.all['<%=divbh.ClientID %>'], code);
            }
        }
    </script>

    <table width="100%">
        <tr height="15px">
            <td>
                <input id="txtssgspk" type="hidden" runat="server" />
                <input id="txtssbmpk" type="hidden" runat="server" />
                <input id="txtssjspk" type="hidden" runat="server" />
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                员工编号<font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtbh" runat="server" onblur="doCheck(this,'../../Shared/DiagList/DisposeEvent.aspx?BH=','编号已经存在','1','checkEmployeeBH')"
                    Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <div id="divbh" runat="server" style="display: none;">
                </div>
            </td>
            <td style="width: 116px; text-align: right">
                员工姓名<font color="red">*</font>
            </td>
            <td style="width: 258px; text-align: justify">
                <asp:TextBox ID="txtName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                员工性别<font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:RadioButtonList ID="rblsex1" runat="server" Height="1px" RepeatDirection="Horizontal"
                    Width="83px">
                    <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                    <asp:ListItem Value="1">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="width: 116px; text-align: right">
                民族
            </td>
            <td style="width: 258px; text-align: justify">
                <asp:TextBox ID="txtmz" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;">
                员工年龄
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtage" runat="server" onkeyup="return onlyNum3()" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px; color: #000000;">
                员工工龄
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txtworkage" runat="server" onkeyup="return onlyNum3()" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; text-align: right; height: 24px;">
                国家
            </td>
            <td style="width: 241px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtnational" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right; height: 24px;">
                身份证
            </td>
            <td style="width: 258px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtprovince" runat="server" Width="200px" onblur="checkCard(this)"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                地区
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtarea" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right">
                城市
            </td>
            <td style="width: 258px; text-align: left">
                <asp:TextBox ID="txtcity" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                邮政编码
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtpostcode" runat="server" onkeyup="return onlyNum3()" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right">
                出生日期
            </td>
            <td style="width: 258px; text-align: left">
                <input id="txtBirthDay" runat="server" style="border-color: #000080; border-style: none none groove none;
                    border-width: 1px;  width:200px" onkeypress="return fifteenth(this, event)" />
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="height: 26px; text-align: right; width: 131px;">
                家庭住址
            </td>
            <td colspan="3" style="height: 26px; text-align: left">
                <asp:TextBox ID="txtaddress" runat="server" Width="580px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; height: 26px; text-align: right">
                家庭电话
            </td>
            <td style="width: 241px; height: 26px; text-align: left">
                <asp:TextBox ID="txthousetel" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="width: 116px; height: 26px; text-align: right">
                办公电话
            </td>
            <td style="width: 258px; height: 26px; text-align: left">
                <asp:TextBox ID="txtofficetel" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="height: 21px; text-align: right; width: 131px;">
                移动电话1
            </td>
            <td style="height: 21px; width: 241px; text-align: left;">
                <asp:TextBox ID="txtmobile1" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="height: 21px; text-align: right; width: 116px;">
                移动电话2
            </td>
            <td style="width: 258px; height: 21px; text-align: left;">
                <asp:TextBox ID="txtmobile2" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;">
                QQ号码
            </td>
            <td style="width: 241px; text-align: left;">
                <asp:TextBox ID="txtqq" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px;">
                ICQ号码
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txticq" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;">
                电子邮箱
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtemail" runat="server" Width="200px" onblur="nz_mail(this,'电子邮箱填写不正确！')"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px;">
                MSN号码
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txtmsn" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                其他联系方式
            </td>
            <td colspan="3" style="text-align: left">
                <asp:TextBox ID="txtother" runat="server" Width="580px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; height: 24px; text-align: right">
                所属单位<font color="red">*</font>
            </td>
            <td colspan="3" style="height: 24px; text-align: left">
                <asp:TextBox ID="txtCompany" runat="server" onclick="javascript:findwindow('Company','1');"
                    Width="580px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Company','1');"
                    alt="查找档案信息" />
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right; height: 24px;">
                所属部门<font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtBranch" runat="server" onclick="javascript:findwindow('Branch','2');"
                    Width="200px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Branch','2');" alt="查找档案信息" />
            </td>
            <td style="width: 116px; text-align: right; height: 24px;">
                员工职位<font color="red">*</font>
            </td>
            <td style="width: 258px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtRole" runat="server" onclick="javascript:findwindow('Role','3');"
                    Width="200px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Role','3');" alt="查找档案信息" />
            </td>
        </tr>
    </table>
</asp:Content>
