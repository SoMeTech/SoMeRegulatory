<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="CompanyUpdate.aspx.cs" title="Untitled Page" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_CompanyUpdate" %>

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
                if (num == "1") {
                    document.all['<%=txtsjgs.ClientID %>'].value = ss[1];
                document.all['<%=txtsjgspk.ClientID %>'].value = ss[0];
            }
        }
    }
    </script>

    <input id="txtishasbaby" type="hidden" runat="server" />
    <input id="txtcmbh" type="hidden" runat="server" />
    <input id="txtsjgspk" type="hidden" value="" runat="server" />
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Height="400px">
        <cc1:TabPanel ID="TabPanel1" runat="server" closable="False" HeaderText="基本信息">
            <ContentTemplate>
                <div style=" width: 100%; height: 100%">
                    <table width="100%">
                        <tr height="15px">
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right">
                                上级单位
                            </td>
                            <td>
                                <asp:TextBox ID="txtsjgs" runat="server" Width="150px" onclick="javascript:findwindow('Company','1');"
                                    Style="border-color: #000080; border-style: none none groove none; border-width: 1px;
                                    " onkeypress="return fifteenth(this, event)" ReadOnly="false" onkeydown="return noCodeIn();"></asp:TextBox>
                                <img src="../../../images/8.png" onclick="javascript:findwindow('Company','1');"
                                    alt="查找档案信息" />
                            </td>
                            <td style="text-align: right;">
                                单位编号<font color="red">*</font>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpk_corp" runat="server" Width="150px" ReadOnly="true" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                关键字
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeyChar" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                单位简称
                            </td>
                            <td>
                                <asp:TextBox ID="txtShortName" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                单位全称<font color="red">*</font>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtName" runat="server" Width="470px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onblur="checkCompanyName(this,'../../../PublicMode/DiagList/DisposeEvent.aspx');"
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                法人代表
                            </td>
                            <td>
                                <asp:TextBox ID="txtHolder" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                注册资金
                            </td>
                            <td>
                                <asp:TextBox ID="txtRegMoney" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeyup="return onlyNum3()" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                开户银行
                            </td>
                            <td>
                                <asp:DropDownList ID="dropBankPK" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; ">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                发票单位
                            </td>
                            <td>
                                <asp:TextBox ID="txtFPDWM" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                单位税号
                            </td>
                            <td>
                                <asp:TextBox ID="txtDutyNum" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                发票类型
                            </td>
                            <td>
                                <asp:TextBox ID="txtInvoiceType" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right; height: 58px;">
                                简要说明
                            </td>
                            <td colspan="5" style="height: 58px">
                                <asp:TextBox ID="txtDiscription" runat="server" Width="720px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" closable="False" HeaderText="联系信息">
            <ContentTemplate>
                <div style=" width: 100%; height: 100%">
                    <table width="100%">
                        <tr height="15px">
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                国家
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                省份
                            </td>
                            <td>
                                <asp:TextBox ID="txtProvince" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                地区
                            </td>
                            <td>
                                <asp:TextBox ID="txtArea" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                单位地址
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtAddress" runat="server" Width="750px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right">
                                单位网址
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtUrl" runat="server" Width="750px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onblur="testisNet(this)" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                电子邮箱1
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail1" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onblur="nz_mail(this,'电子邮箱填写不正确！')" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                电子邮箱2
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail2" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onblur="nz_mail(this,'电子邮箱填写不正确！')" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                电子邮箱3
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail3" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onblur="nz_mail(this,'电子邮箱填写不正确！')" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                邮政编码
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                联系人1
                            </td>
                            <td>
                                <asp:TextBox ID="txtlinkman1" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                联系人2
                            </td>
                            <td>
                                <asp:TextBox ID="txtlinkman2" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                联系电话1
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone1" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                联系电话2
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone2" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum2();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                联系电话3
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone3" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="text-align: right;">
                                传真号码1
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax1" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                传真号码2
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax2" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                传真号码3
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax3" runat="server" Width="150px" Style="border-color: #000080;
                                    border-style: none none groove none; border-width: 1px; "
                                    onkeydown="return onlyNum1();" onkeypress="return fifteenth(this, event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
