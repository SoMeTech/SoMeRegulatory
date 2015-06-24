<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" CodeBehind="EmployeeUpdate.aspx.cs" autoeventwireup="true" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Employee_EmployeeUpdate" %>

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
    </script>

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
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labbh" runat="server">员工编号</asp:Label><font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtbh" runat="server" Width="200px" ReadOnly="true" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtbh_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; text-align: right">
                <asp:Label ID="labName" runat="server">员工姓名</asp:Label><font color="red">*</font>
            </td>
            <td style="width: 258px; text-align: justify">
                <asp:TextBox ID="txtName" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtName_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labxb" runat="server">员工性别</asp:Label><font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:RadioButtonList ID="rblsex1" runat="server" Height="1px" RepeatDirection="Horizontal"
                    Width="83px">
                    <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                    <asp:ListItem Value="1">女</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="txtxbbak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; text-align: right">
                <asp:Label ID="labmz" runat="server">民族</asp:Label>
            </td>
            <td style="width: 258px; text-align: justify">
                <asp:TextBox ID="txtmz" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtmz_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;">
                <asp:Label ID="labage" runat="server">员工年龄</asp:Label>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtage" runat="server" onkeyup="return onlyNum3()" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtage_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px; color: #000000;">
                <asp:Label ID="labworkage" runat="server">员工工龄</asp:Label>
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txtworkage" runat="server" onkeyup="return onlyNum3()" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtworkage_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labnational" runat="server">国家</asp:Label>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtnational" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtnational_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right">
                <asp:Label ID="labprovince" runat="server">身份证</asp:Label>
            </td>
            <td style="width: 258px; text-align: left">
                <asp:TextBox ID="txtprovince" runat="server" Width="200px" onblur="jsz_15_to_18(this)"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtprovince_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labarea" runat="server">地区</asp:Label>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtarea" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtarea_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right">
                <asp:Label ID="labcity" runat="server">城市</asp:Label>
            </td>
            <td style="width: 258px; text-align: left">
                <asp:TextBox ID="txtcity" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtcity_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labpostcode" runat="server">邮政编码</asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:TextBox ID="txtpostcode" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtpostcode_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; color: #000000; text-align: right">
                <asp:Label ID="labBirthDay" runat="server">出生日期</asp:Label>
            </td>
            <td style="width: 258px; text-align: left">
                <input id="txtBirthDay" runat="server" style="border-color: #000080; border-style: none none groove none;
                    border-width: 1px;  width:200px" onkeypress="return fifteenth(this, event)" />
                <input id="txtBirthDay_bak" runat="server" visible="false"/>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="height: 26px; text-align: right; width: 131px;">
                <asp:Label ID="labaddress" runat="server">家庭住址</asp:Label>
            </td>
            <td colspan="3" style="height: 26px; text-align: left">
                <asp:TextBox ID="txtaddress" runat="server" Width="580px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtaddress_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; height: 26px; text-align: right">
                <asp:Label ID="labhousetel" runat="server">家庭电话</asp:Label>
            </td>
            <td style="width: 241px; height: 26px; text-align: left">
                <asp:TextBox ID="txthousetel" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txthousetel_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; height: 26px; text-align: right">
                <asp:Label ID="labofficetel" runat="server">办公电话</asp:Label>
            </td>
            <td style="width: 258px; height: 26px; text-align: left">
                <asp:TextBox ID="txtofficetel" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtofficetel_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="height: 21px; text-align: right; width: 131px;">
                <asp:Label ID="labmobile1" runat="server">移动电话1</asp:Label>
            </td>
            <td style="height: 21px; width: 241px; text-align: left;">
                <asp:TextBox ID="txtmobile1" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtmobile1_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="height: 21px; text-align: right; width: 116px;">
                <asp:Label ID="labmobile2" runat="server">移动电话2</asp:Label>
            </td>
            <td style="width: 258px; height: 21px; text-align: left;">
                <asp:TextBox ID="txtmobile2" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtmobile2_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;">
                <asp:Label ID="labqq" runat="server">QQ号码</asp:Label>
            </td>
            <td style="width: 241px; text-align: left;">
                <asp:TextBox ID="txtqq" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtqq_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px;">
                <asp:Label ID="labicq" runat="server">ICQ号码</asp:Label>
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txticq" runat="server" onkeydown="return onlyNum1();" Width="200px"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txticq_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="text-align: right; width: 131px;" onblur="nz_mail(this,'电子邮箱填写不正确！')">
                <asp:Label ID="labemail" runat="server">电子邮箱</asp:Label>
            </td>
            <td style="width: 241px; text-align: left">
                <asp:TextBox ID="txtemail" runat="server" Width="200px" onblur="nz_mail(this,'电子邮箱填写不正确！')"
                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtemail_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="text-align: right; width: 116px;">
                <asp:Label ID="labmsn" runat="server">MSN号码</asp:Label>
            </td>
            <td style="width: 258px; text-align: left;">
                <asp:TextBox ID="txtmsn" runat="server" Width="200px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtmsn_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right">
                <asp:Label ID="labother" runat="server">其他联系方式</asp:Label>
            </td>
            <td colspan="3" style="text-align: left">
                <asp:TextBox ID="txtother" runat="server" Width="580px" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                <asp:TextBox ID="txtother_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; height: 24px; text-align: right">
                <asp:Label ID="labCompany" runat="server">所属单位</asp:Label><font color="red">*</font>
            </td>
            <td colspan="3" style="height: 24px; text-align: left">
                <asp:TextBox ID="txtCompany" runat="server" onclick="javascript:findwindow('Company','1');"
                    Width="580px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Company','1');" alt="查找档案信息" />
                <asp:TextBox ID="txtCompany_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 24px">
            <td style="width: 131px; text-align: right; height: 24px;">
                <asp:Label ID="labBranch" runat="server">所属部门</asp:Label><font color="red">*</font>
            </td>
            <td style="width: 241px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtBranch" runat="server" onclick="javascript:findwindow('Branch','2');"
                    Width="200px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Branch','2');" alt="查找档案信息" />
                <asp:TextBox ID="txtBranch_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
            <td style="width: 116px; text-align: right; height: 24px;">
                <asp:Label ID="labRole" runat="server">员工职位</asp:Label><font color="red">*</font>
            </td>
            <td style="width: 258px; text-align: left; height: 24px;">
                <asp:TextBox ID="txtRole" runat="server" onclick="javascript:findwindow('Role','3');"
                    Width="200px" onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                <img src="../../images/8.png" onclick="javascript:findwindow('Role','3');" alt="查找档案信息" />
                <asp:TextBox ID="txtRole_bak" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
