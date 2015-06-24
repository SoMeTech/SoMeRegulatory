<%@ page language="C#" masterpagefile="~/Master/MainMX.master" autoeventwireup="true" CodeBehind="BXKMx.aspx.cs" inherits="Work_GL_BXKMx" title=" " enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
<%@ Register Assembly="ExtExtenders" Namespace="ExtExtenders" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.css") %>"
        type="text/css" rel="stylesheet" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/fileup.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/resources/css/ext-all.css") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/adapter/ext/ext-base.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("Ext/ext-all.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="../../jss/XMGL/projSbMx.js" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../Ext/j/jquery.tmpl.min.js" type="text/javascript"></script>

    <script id="myTemplate" type="text/x-jquery-tmpl"> 
        <tr><td>{{html CHECKBOX}}</td><td>{{html PD_BASE_TZJGC}}</td><td>{{html PD_PROJECT_MONEY_CZ_SJ}}</td></tr> 
    </script>

    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        var selectPD_YEAR_id = "<%=ddlPD_YEAR.ClientID %>";
        var selectPD_FOUND_XZ_id = "<%=ddlPD_FOUND_XZ.ClientID %>";
        var selectPD_PROJECT_TYPE_id = "<%=ddlPD_PROJECT_TYPE.ClientID %>";
    
    
    
    </script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <script type="text/javascript">
        function findwindow(val, obj) {
            var webFileUrl = "";
            var shMod_cs = "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0";
            switch (val) {
                case "FG":
                    webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=" + val;
                    break;
            }
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, shMod_cs);
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    switch (val) {
                        case "FG":
                            ss = arr.split("~");
                            $("input[uid='txtPD_PROJECT_FILENO_JG']").get(0).value = ss[1];
                            break;
                    }
                }
            }
        }

        function findcompany(obj) {
            $.ajax({
                url: "publicBll.ashx?loop=xmsb&value=" + obj.value + "&name=" + obj.id,
                type: "post",
                dataType: "text",
                error: function (e) { alert("load database error !!"); },
                success: function (msg) {//msg为返回的数据，在这里做数据绑定
                    if (msg != null && Trim(msg) != "") {
                        alert(msg);
                        obj.value = "";
                        obj.focus();
                    }
                }
            });

            //         if(this.value != "")
            //         {
            //            Work_projectGL_projSbMx.ExistsCodeAndName(obj.value,obj.id, ExistsCodeAndName_callback);
            //         }
        }

        function ExistsCodeAndName_callback(res) {
            if (res.value != null) {
                var value = res.value.split('|')[1]
                alert(value);
                document.getElementsByName(res.value.split('|')[0])[0].value = "";
                document.getElementsByName(res.value.split('|')[0])[0].focus();
            }
        }

        //乡镇,村,组三级联动 var xmlhttp = null;
        function province(va) {

            checkName("Handler.ashx?type=Xiang&id=" + va, processCity);



        }
        function areaTmp(vArea) {

            checkName("Handler.ashx?type=Cun&id=" + vArea, processArea);
        }


        function checkName(url, method) {
            createHttpReq();
            xmlhttp.onreadystatechange = method;
            xmlhttp.open("get", url, true);
            xmlhttp.send(null)
        }
        function createHttpReq() {
            if (window.XMLHttpRequest) {
                xmlhttp = new XMLHttpRequest();
            }
            else {
                if (window.ActiveXObject) {
                    try {
                        xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
                    }
                    catch (e) {
                        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                    }
                }
            }

        }
        function processArea() {
            if (xmlhttp.readyState == 4) {
                if (xmlhttp.status == 200) {
                    var f = document.getElementById("<%=ddlPD_PROJECT_GROUP.ClientID %>");
                var list = xmlhttp.responseText;
                var classList = list.split("|");
                f.options.length = 0;
                for (var i = 0; i < classList.length; i++) {
                    var tmp = classList[i].split(",");
                    f.add(new Option(tmp[0], tmp[1]));
                }


            }
        }
    }
    function processCity() {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {

                var f = document.getElementById("<%=ddlPD_PROJECT_VILLAGE.ClientID %>");
            var list = xmlhttp.responseText;
            var classList = list.split("|");
            f.options.length = 0;
            for (var i = 0; i < classList.length; i++) {
                var tmp = classList[i].split(",");
                f.add(new Option(tmp[0], tmp[1]));
            }

        }
    }
}
    </script>

    <input type="hidden" id="txtPD_PROJECT_MONEY_CZ_SJ" uid="txtPD_PROJECT_MONEY_CZ_SJ"
        runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_CZ_BJ" uid="txtPD_PROJECT_MONEY_CZ_BJ"
        runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_ZC" uid="txtPD_PROJECT_MONEY_ZC" runat="server" />
    <input type="hidden" id="txtPD_PROJECT_MONEY_QT" uid="txtPD_PROJECT_MONEY_QT" runat="server" />
    <div style="text-align: left; margin-top: 10px;">
        <asp:TextBox ID="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server" Style="display: none;"></asp:TextBox>
        <table id="tb_top" border="0" style="text-align: left;">
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    项目年度 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" runat="server" Width="206">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    项目名称 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_NAME" runat="server" Width="200px"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
                <td style="width: 130px;" align="right">
                    资金性质 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_FOUND_XZ" uid='ddlPD_FOUND_XZ' runat="server" Width="206"
                        Enabled="false">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>

                </td>
            </tr>
            <tr>
                <td style="width: 130px; height: 30px;" align="right">
                    项目类别 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_TYPE" runat="server" Width="206">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td height="30" align="right">
                    是否乡镇直接管理 ：
                </td>
                <td height="30" align="left">
                    <asp:DropDownList ID="ddlPD_PROJECT_IFXZGL" runat="server" Width="206">
                    </asp:DropDownList>
                </td>
                <td height="30" align="right">
                    受益人数 ：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_SYRS" runat="server" Width="200px" onkeydown="return onlyNum3(this);"
                        onKeyPress="myKeyDown(this,event,1)" CssClass="NumTextCss"></asp:TextBox>
                    <asp:TextBox ID="txtPD_PROJECT_FILENO_LX" runat="server" Width="200px" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" align="right">
                    村名：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="pd_project_cm" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    投资总额：
                </td>
                <td height="30" align="left">
                    <asp:TextBox ID="txtPD_PROJECT_MONEY_TOTAL" uid='txtPD_PROJECT_MONEY_TOTAL_PF' runat="server"
                        Width="180px" onKeyPress="myKeyDown(this,event,0)" class="NumTextCss"></asp:TextBox>(元)
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" align="left">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
        Visible="true">
        <cc1:TabPanel ID="Panel_xmgk" runat="server" HeaderText="项目概况">
            <HeaderTemplate>
                项概目况
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%;" cellpadding="4">
                    <tr>
                        <td height="30" style="text-align: right;">
                            项目建设地点：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="ddlPD_PROJECT_COUNTRY" runat="server" Width="600px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <%--  <asp:DropDownList ID="ddlPD_PROJECT_COUNTRY"   runat="server" onchange="province(this.value)" Visible=false
                                Width="150px">
                            </asp:DropDownList>--%>
                            <select id="ddlPD_PROJECT_VILLAGE" runat="server" onchange="areaTmp(this.value)"
                                visible="false" style="width: 150px">
                            </select>
                            <select id="ddlPD_PROJECT_GROUP" runat="server" style="width: 150px" visible="false">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            主要建设内容：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_CONTENT" runat="server" Width="93%" Height="50px"
                                TextMode="MultiLine"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            实施范围：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_SSFW" runat="server" Width="93%" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top;">
                            项目用途：
                        </td>
                        <td colspan='5' style="text-align: left;">
                            <asp:TextBox ID="txtPD_PROJECT_XMYT" runat="server" Width="93%" Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px;">
                            项目申报日期：
                        </td>
                        <td align="left" style="height: 30px;">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_DATE" data-options="formatter:myformatter,parser:myparser"
                                class="easyui-datebox" runat="server" Width="205px" ></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                            项目申报单位：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="ShowPD_PROJECT_INPUT_COMPANY" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 100px;">
                            项目申报经办人：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="ShowPD_PROJECT_INPUT_MAN" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            项目申报部门 ：
                        </td>
                        <td align="left" style="height: 30px;">
                            <asp:TextBox ID="txtdepart" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 130px;">
                        </td>
                        <td align="left">
                        </td>
                        <td style="text-align: right; width: 130px;">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <%--<cc1:TabPanel ID="Panel_xmtzsq" runat="server" HeaderText="投资概算">
            <ContentTemplate>
                <div uid='add_del_button' style="text-align: left; padding: 5px 10px;">
                    <a href="javascript:void(0)" onclick='tb_tzgc_Add("tb_tzjgc_1")'><img src="../../images/AddRow.png" /></a>
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                    <a href="javascript:void(0)" onclick='tb_tzgc_Del("tb_tzjgc_1");'><img src="../../images/DelRow.png" /></a>
                </div>
                <div id="div1" uname="div_file">
                    <table id="tb_tzjgc_1" style="text-align: center;" border="1" cellpadding="4"
                        cellspacing="0">
                        <tr style="background: #E9E9E9; height:30px;">
                        <th style="width:30px; text-align:center;">选择</th>
                        <th style="width:150px; text-align:center;">投资构成</th>
                        <th style="width:150px; text-align:center;">金额(元)</th>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>--%>
        <%--
        <cc1:TabPanel ID="Panel_xmtzsq" runat="server" HeaderText="投资及构成">
            <ContentTemplate>
                <table style="width: 100%; text-align: left;" cellpadding="4">
                    <tr>
                        <td style="width: 130px; height:30px; text-align: right;">
                            申请投资总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_TOTAL" runat="server" Width="200px" Text="0"
                                Enabled="false"></asp:TextBox>&nbsp;元
                        <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请财政资金总额：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_TOTAL" runat="server" Width="200px" Text="0"
                                Enabled="false"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请上级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_SJ" uid='txtPD_PROJECT_MONEY_CZ_SJ' runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_SJ_PF" uid='txtPD_PROJECT_MONEY_CZ_SJ_PF' runat="server" Width="200px" style="display:none;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            &nbsp;&nbsp;&nbsp;&nbsp;申请本级财政资金：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_CZ_BJ" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请自筹资金：
                        </td>
                        <td>
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_ZC" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height:30px; ">
                            申请其他资金：
                        </td>
                        <td>
                            <asp:TextBox   ID="txtPD_PROJECT_MONEY_QT" runat="server" Width="200px" Text="0" CssClass="NumTextCss"></asp:TextBox>&nbsp;元
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>--%>
        <cc1:TabPanel ID="Panel_xmsbzl" runat="server" HeaderText="项目资料">
            <ContentTemplate>
                <div uid='add_del_button' style="text-align: left; padding: 5px 10px;">
                    <a href="javascript:void(0)" onclick='loadTable_add()'>
                        <img src="../../images/AddRow.png" /></a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="javascript:void(0)"
                            onclick="tableJDdel('table_xmsbzl',3);">
                            <img src="../../images/DelRow.png" /></a>
                </div>
                <div id="div_file" uname="div_file">
                    <table id="table_xmsbzl" style="width: 98%; text-align: center;" border="1" cellpadding="4"
                        cellspacing="0">
                        <tr style="background: #E9E9E9;">
                            <td style="display: none; text-align: center;">
                                自动ID
                            </td>
                            <td height="30" style="width: 50px; text-align: center;">
                                序号
                            </td>
                            <td style="width: 200px; display: none; text-align: center;">
                                项目代码
                            </td>
                            <td style="text-align: center;" colspan="2" align="center">
                                附件名称
                            </td>
                            <%-- <td style="width: 100px; text-align:center;">
                            操作
                        </td>--%>
                        </tr>
                    </table>
                    <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

    <script type="text/javascript">
        function PostLoadxmsszl(tableID, json, addLoop) {
            Loadxmsszl(tableID, json, addLoop);
        }
        function loadTable_add() {
            loadTable_JD("table_xmsbzl", eval("<%=jsonStrNull%>")[0], 'xmss_5');
    }

    $(document).ready(function () {
        try {
            PostLoadxmsszl('table_xmsbzl', eval("<%=jsonStr %>"), 'xmss_5');
        $("input[uid='txtPD_PROJECT_FILENO_JG']").attr("readonly", "readonly");


        RunBindData();
        $("#" + selectPD_YEAR_id).change(function () { getPD_PROJECT_TYPE(); })
        $("#" + selectPD_FOUND_XZ_id).change(function () { getPD_PROJECT_TYPE(); })

        //调用母版页中的方法
        setHeight();

        //绑定投资及构成
        //ShowTZGCAll();
    } catch (e) { alert(e) }
    });
    function RunBindData() {
        //readonly
        $("input[uid='txtPD_PROJECT_FILENO_PF']").attr("readonly", "true");
        $("input[uid='txtPD_PROJECT_FILENO_JG']").attr("readonly", "true");
    }
    </script>

</asp:Content>
