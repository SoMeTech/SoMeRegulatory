<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" autoeventwireup="true" CodeBehind="ZJBFOper.aspx.cs" inherits="Work_ZJBF_ZJBFOper" title=" " enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="../DataPrint/OutPut/OutputZJBF.js" type="text/javascript"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function findwindow(val, obj) {
            var webFileUrl = "";
            var webShowModalUrl = "../../Shared/DiagList/Home.aspx";
            switch (val) {
                case "proj_bianma":
                    var year = document.getElementById("<%=ddlPD_YEAR.ClientID %>").value;
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&year=" + year + "&pd_found_xz=01";
                    break;
                case "ContractsMessage":
                    var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val + "&project_code=" + document.getElementById("<%=txtPD_PROJECT_CODE.ClientID %>").value + "&CONTRACTTYPE=" + document.getElementById("<%=ddlPD_CONTRACT_TYPE.ClientID %>").value;
                    break;
                case "mssql_kjkm":
                case "mssql_fzhs":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    webShowModalUrl += "?&MSSQL=" + $('#databaseSelect').get(0).value;
                    break;
                default:
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    break;

            }
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog(webShowModalUrl, window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
           //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    switch (val) {
                        case "proj_bianma":
                            if (trim(ss[0]) == "") {
                                ss[0] = ss[1] = "";
                                ss[2] = ',,,,';
                            }
                            document.getElementById("<%=txtPD_PROJECT_CODE.ClientID %>").value = ss[0];
                                document.getElementById("<%=txtPD_PROJECT_NAME.ClientID %>").value = ss[1];
                                document.getElementById("<%=txtPD_PROJECT_MONEY_TOTAL.ClientID %>").value = ss[2].split(',')[2];

                                break;
                            case "ContractsMessage":
                                if (trim(ss[0]) == "") {
                                    ss[0] = ss[1] = "";
                                    ss[2] = ',';
                                }
                                document.getElementById("<%=txtPD_PROJECT_CONTRACT.ClientID %>").value = ss[0];
                                document.getElementById("<%=txtcontract_name.ClientID %>").value = ss[1];
                                document.getElementById("<%=txtPD_CONTRACT_MONEY.ClientID %>").value = ss[2].split(',')[1];
                                document.getElementById("<%=txtPD_CONTRACT_COMPANY.ClientID %>").value = ss[2].split(',')[0];
                                break;
                            case "mssql_kjkm":
                                if (obj.id == 'lbl_kjkm_JF') {
                                    $("#txt_kjkm_JF").get(0).value = ss[0];
                                    $("#lbl_kjkm_JF").get(0).value = ss[1];
                                }
                                else if (obj.id == 'lbl_kjkm_DF') {
                                    $("#txt_kjkm_DF").get(0).value = ss[0];
                                    $("#lbl_kjkm_DF").get(0).value = ss[1];
                                }
                                break;
                            case "mssql_fzhs":
                                $("#txt_fzhs").get(0).value = ss[0];
                                $("#lbl_fzhs").get(0).value = ss[1];
                                break;

                        }

                    }
                }
            }

            function getCursorPos(obj) {
                var rngSel = document.selection.createRange();//建立选择域
                var rngTxt = obj.createTextRange();//建立文本域
                var flag = rngSel.getBookmark();//用选择域建立书签
                rngTxt.collapse();//瓦解文本域到开始位,以便使标志位移动
                rngTxt.moveToBookmark(flag);//使文本域移动到书签位
                rngTxt.moveStart('character', -obj.value.length);//获得文本域左侧文本
                str = rngTxt.text.replace(/\r\n/g, '');//替换回车换行符
                return (str.length);//返回文本域文本长度
            }

            function myKeyDown(obj, oEvent, loop) {
                var k = oEvent.keyCode;
                //	alert(String.fromCharCode(oEvent.keyCode))
                if ((k == 8) || (k == 45) || (k == 46) || (k >= 48 && k <= 57))
                { }
                else {
                    oEvent.returnValue = false;
                }
                //eval("var Res=/(.{"+getCursorPos(obj)+"})/g")
                //obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)),loop)
                //alert(obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)));
                var insertIndex = getCursorPos(obj);
                var objValue = obj.value.substring(0, insertIndex) + String.fromCharCode(oEvent.keyCode) + obj.value.substring(insertIndex)
                if (!_Number(objValue, loop))
                    oEvent.returnValue = false;
            }
            //loop=0两位小数，否则无小数
            function _Number(ssn, loop) {
                var re;
                if (loop == 0)
                    re = /^\-?[0-9]+\.?[0-9]{0,2}$/i;
                else
                    //re=/^\-?[0-9]+\.?[0-9]*$/i;
                    re = /^\-?[0-9]+$/i;
                if (ssn == '' || re.test(ssn))
                    return true;
                else
                    return false;
            }

            function IsOnSubmit(ibtid) {
                if (ibtid.value == "ibtcontrol_ibtsave")
                    return ClientSubmit();
                else
                    return true;
            }
            function ClientSubmit() {
                if (!PublicYanZheng())
                    return false;
                var returnbool = false;
                $.ajax({
                    url: "../XMGL/publicBll.ashx?loop=zjbf_pdmoney&bcMoney=" + $('input[uid="txtPD_FOUND_MONEY"]').eq(0).val() + "&bcCzMoney=" + $("input[uid='txtPD_FOUND_MONEY_CZ']").eq(0).val() + "&pj_code=" + $('input[uid="txtPD_PROJECT_CODE"]').eq(0).val() + "&contract=" + $('input[uid="txtPD_PROJECT_CONTRACT"]').eq(0).val() + "&bfid=" + $('input[uid="txtAUTO_NO"]').eq(0).val(),
                    type: "post",
                    dataType: "text",
                    async: false,
                    error: function (e) { alert("load database error !!"); },
                    success: function (msg) {//msg为返回的数据，在这里做数据绑定
                        var json = eval(msg);
                        if (json[0].ref != null && Trim(json[0].ref) != "")
                            alert(json[0].ref);
                        else
                            returnbool = true;
                    }
                });
                return returnbool;
            }
    </script>

    <style>
        .aaa
        {
            border: 1px solid #999999;
        }
    </style>
    <!--******************************增加页面代码********************************-->
    <input id="Hidden1" type="hidden" runat="server" /><div style="text-align: center;">
        <br />
        <br />
        <table cellspacing="0" cellpadding="0" width="90%" border="0" class="aaa">
            <tr>
                <td width="140" align="right" style="height: 40px;">
                    项目年度 ：
                </td>
                <td width="250" align="left">
                    <asp:TextBox ID="txtAUTO_NO" uid="txtAUTO_NO" runat="server" Width="200px" style="display:none;"></asp:TextBox>
                    <asp:DropDownList ID="ddlPD_YEAR" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    &nbsp;项目名称 ：
                </td>
                <td width="250" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_NAME" uid="txtPD_PROJECT_NAME" runat="server" ReadOnly="true"
                        Width="200px" rdonly="1" onclick="javascript:findwindow('proj_bianma',this);"></asp:TextBox>
                    <span style="color: Red">*</span>
                    <asp:TextBox ID="txtPD_PROJECT_CODE" uid="txtPD_PROJECT_CODE" runat="server" Width="200px" Style="display: none;"></asp:TextBox>
                    <asp:DropDownList ID="ddlPD_IF_HAVE" runat="server" Width="205px" Visible="false">
                    </asp:DropDownList>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    项目投资总额：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_PROJECT_MONEY_TOTAL" uid="txtPD_PROJECT_MONEY_TOTAL" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                    <asp:TextBox ID="txtPD_FOUND_ACC_TYPE" Enabled="false" runat="server" Width="200px"
                        Visible="false"></asp:TextBox>
                       <asp:TextBox ID="txtPD_FOUND_SYS_JJFL" runat="server" Enabled="false" Width="200px"
                        Visible="false"></asp:TextBox>
                </td>
            </tr>           
        </table>
        <br />
        <table cellspacing="0" cellpadding="0" width="90%" border="0" class="aaa">
            <tr>
                <td width="140" align="right" style="height: 40px;">
                    合同类型：
                </td>
                <td width="250" align="left">
                    <asp:DropDownList ID="ddlPD_CONTRACT_TYPE" uid="ddlPD_CONTRACT_TYPE" runat="server"
                        Style="width: 206px;">
                    </asp:DropDownList>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    &nbsp;合同名称 ：
                </td>
                <td width="250" align="left">
                    <%-- <asp:DropDownList ID="ddlPD_CONTRACT_COMPANY" runat="server" Width="200px"  Visible="false">
                </asp:DropDownList>--%>
                    <asp:TextBox ID="txtcontract_name" runat="server" Width="200px" rdonly="1" onclick="javascript:findwindow('ContractsMessage',this);"></asp:TextBox>
                    <asp:TextBox ID="txtPD_PROJECT_CONTRACT" uid="txtPD_PROJECT_CONTRACT" runat="server" rdonly="1" onclick="javascript:findwindow('ContractsMessage',this);"
                        Style="display: none;"></asp:TextBox>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    &nbsp;合同金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_CONTRACT_MONEY" uid="txtPD_CONTRACT_MONEY" Enabled="false" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;合同签约单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_CONTRACT_COMPANY" Enabled="false" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right" style="height: 40px;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
                <td align="right" style="height: 40px;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <table cellspacing="0" cellpadding="0" width="90%" border="0" class="aaa">
            <tr>
                <td width="140" align="right" style="height: 40px;">
                    &nbsp;拨付时间 ：
                </td>
                <td width="250" align="left">
                    <asp:TextBox ID="txtPD_FOUND_DATE" data-options="formatter:myformatter,parser:myparser"
                        class="easyui-datebox" runat="server" Width="205px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    拨付方式 ：
                </td>
                <td width="250" align="left">
                    <asp:DropDownList ID="ddlPD_FOUND_STYLE" runat="server" Width="206px">
                    </asp:DropDownList>
                </td>
                <td width="140" align="right">
                    拨付类型 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_FOUND_TYPE" runat="server" Width="205px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 40px;">
                    拨付依据 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_FILENAME" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;本次拨付总金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY" uid="txtPD_FOUND_MONEY" runat="server" Width="200px" CssClass="NumTextCss"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    &nbsp;累计拨付总金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_TOTAL" uid="txtPD_FOUND_MONEY_TOTAL" Enabled="false" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 40px;">
                    拨付完成总比 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_WCL" runat="server" Width="200px" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss"  Enabled="false"></asp:TextBox>
                </td>
                <td align="right" style="height: 40px;">
                    &nbsp;备注：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_SYS_FILENAME" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <%--<tr style="display:none;">
                <td align="right" style="height: 40px;">
                    本次拨付财政金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_CZ" uid="txtPD_FOUND_MONEY_CZ" runat="server" Width="200px" CssClass="NumTextCss"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="height: 40px;">
                    累计拨付财政金额 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_TOTAL_CZ" uid="txtPD_FOUND_MONEY_TOTAL_CZ" runat="server" Width="200px" rdonly="1"></asp:TextBox>
                </td>
                <td align="right" style="height: 40px;">
                    财政总投资&nbsp;&nbsp;&nbsp;&nbsp;<br />拨付完成比例：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_CZZTZ_WCL" runat="server" Width="200px" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss" rdonly="1"></asp:TextBox>
                </td>
                <td align="right" style="height: 40px;">
                    结算金额：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_MONEY_JS" runat="server" Width="200px" onKeyPress="myKeyDown(this,event,0)" CssClass="NumTextCss"></asp:TextBox>
                </td>
            </tr>--%>
        </table>
        <br />
        <table cellspacing="0" cellpadding="0" width="90%" border="0" class="aaa">
            <tr>
                <td width="140" style="text-align: right">
                    记账凭证号 ：
                </td>
                <td width="250" align="left">
                    <asp:TextBox ID="txtPD_FOUND_VOUNO" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td width="140" align="right" style="height: 40px;">
                    &nbsp;凭证月份：
                </td>
                <td width="250" align="left">
                    <asp:DropDownList ID="ddlmonth" runat="server" Width="206px">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                    月
                </td>
                <td width="140" align="right" style="height: 40px;">
                    凭证年份：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlyear" runat="server" Width="206px">
                    </asp:DropDownList>
                    年
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" style="height: 40px;">
                    &nbsp;资金来源 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_FOUND_SOURCES" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td align="right" style="height: 40px;">
                    &nbsp;收款单位 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_FOUND_COMPANY" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right" style="height: 40px;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="company" uid="company" runat="server" />
    <input type="hidden" id="txt_kjkmDB_DF" uid="txt_kjkmDB_DF" runat="server" />
    <input type="hidden" id="txt_kjkmDB_JF" uid="txt_kjkmDB_JF" runat="server" />
    <input type="hidden" id="txt_fzhs_DB" uid="txt_fzhs_DB" runat="server" />
    <input type="hidden" id="db_name" uid="db_name" runat="server" />

    <script type="text/javascript">
        $(document).ready(function () {
            try {
                if (!$("input[id='ibtcontrol_ibtsave']").length <= 0) {
                    RunBindData()
                }
            } catch (e) { alert(e) }
        });
        function RunBindData() {
            BindDate("<%=txtPD_FOUND_DATE.ClientID%>");
    }
    </script>

</asp:Content>
