
<%@ page language="C#" autoeventwireup="true" inherits="Work_FaGui_messbackoper" CodeBehind="messbackoper.aspx.cs" masterpagefile="~/Master/MainAddUpdate.master" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/projSsMx.js") %>"
        type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/XMGL/ContextMen.js") %>"
        type="text/javascript"></script>

    <link href="<%=QxRoom.Common.Public.RelativelyPath("css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />
    
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jquery-1.4.2.min.js") %>"
        type="text/javascript"></script>

    <%--<script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>
        <script src="../../jquery.easyui/js/jquery-1.8.0.min.js" type="text/javascript"></script>--%>
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />

    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        function IsOnSubmit(obj) {
            if (obj.value == "ibtcontrol_ibtexit") {
                try {
                    IsClose();
                } catch (e) { window.close(); }
                return false;
            } else
                return PublicYanZheng();
        }
        function findwindow(val, obj) {
            var ProjectType = $("select[uid='ddl_BASE_FKLX']").eq(0).val();
            var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pd_year=" + $("select[uid='ddlPD_YEAR']").get(0).value + "&ProjectType=" + ProjectType;
            //alert(webFileUrl);
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ss = arr.split("~");
                    //alert(ss);
                    try {
                        document.getElementById("<%=txtPD_PROJECT_CODE.ClientID %>").value = ss[0];
                        obj.value = ss[1];
                    } catch (e) { alert(e) };
                }
            }
        }
        function fklx_change(obj) {
            try {
                switch (obj.value) {
                    case "01":
                    case "02":
                        $("input[uid='txtProjectName']").get(0).onclick = function () { findwindow('proj_bianma2', this); }
                        $("span", $("input[uid='txtProjectName']").get(0).parentNode).eq(0).html("*");
                        $("input[uid='txtProjectName']").css({ backgroundColor: "#FFF", color: "#000" });
                        break;
                    default:
                        $("input[uid='txtProjectName']").eq(0).val("");
                        $("input[uid='txtPD_PROJECT_CODE']").eq(0).val("");
                        $("input[uid='txtProjectName']").removeAttr("onclick");
                        $("span", $("input[uid='txtProjectName']").get(0).parentNode).eq(0).html("&nbsp");
                        $("input[uid='txtProjectName']").css({ backgroundColor: "#e9e9e9", color: "#666" });
                        break;
                }
            } catch (e) { alert(e); }
        }
        $(document).ready(function () {
            if ($("input[uid='ssxxCode']").eq(0).val() == '14')
                fklx_change($("select[uid='ddl_BASE_FKLX']").get(0));
        });
    </script>

    <asp:Label runat="server" ID="lblAUTO_ID" Visible="false"></asp:Label>
    <input type="hidden" runat="server" id="hgl" />
    <input type="hidden" runat="server" id="hjj" />
    <input type="hidden" runat="server" id="ssxxCode" uid="ssxxCode" />
    <div style="text-align: center;">
        <table cellspacing="0" cellpadding="0" border="0" width="82%">
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%;">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%;">
                    反馈类型：
                </td>
                <td height="25" align="left">
                    <asp:DropDownList ID="ddl_BASE_FKLX" uid="ddl_BASE_FKLX" runat="server" onchange="fklx_change(this)"
                        Style="width: 206px;">
                    </asp:DropDownList>
                    <span id="span_fklx" runat="server" style="color: Red">*</span>
                </td>
                <td height="25" align="right" class="style1" style="width: 13%; ">
                    项目年度：
                </td>
                <td height="25" align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Style="width: 206px;"
                        onchange="csPD_PROJECT_CODE()">
                    </asp:DropDownList>
                    <span id="span_xmnd" runat="server" style="color: Red">*</span>
                </td>
                <td height="25" align="left">
                    项目名称：
                </td>
                <td height="25" align="left">
                    <input type="text" id="txtProjectName" uid="txtProjectName" runat="server" style="width: 200px" rdonly="1" onclick="javascript: findwindow('proj_bianma2', this);" />
                    <span  id="span_xmmc" runat="server" style="color: Red">*</span>
                    <input type="hidden" id="txtPD_PROJECT_CODE" uid="txtPD_PROJECT_CODE" runat="server" />
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    反馈对象：
                </td>
                <td height="25" align="left" colspan="5">
                    <asp:DropDownList ID="ddlPD_QUOTA_DEPART" uid="ddlPD_QUOTA_DEPART" runat="server"
                        Style="width: 206px;">
                    </asp:DropDownList>
                    <span id="span_fkdx" runat="server" style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    存在的问题及困难：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="areakn" runat="server"></textarea>
                    <span id="span_wtjkn" runat="server" style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                  
                </td>
                <td height="25" align="left" colspan="5">
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    工作建议 ：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="areajianyi" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    乡镇政府意见 ：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="areaxzyj" runat="server" onclick="return areaxzyj_onclick()"></textarea>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    备注 ：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="areapz" runat="server"></textarea>
                </td>
            </tr><tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    业务股室意见 ：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="ywgsyj" runat="server"></textarea>
                </td>
            </tr><tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">&nbsp;
                    
                </td>
                <td height="25" align="left" colspan="5">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%; font-weight: bold">
                    乡财局意见 ：
                </td>
                <td height="25" align="left" colspan="5">
                    <textarea style="width: 100%" cols="40" rows="6" id="xcjyj" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%">&nbsp;
                    
                </td>
                <td height="25" align="left">&nbsp;
                    
                </td>
                <td height="25" align="right">&nbsp;
                    
                </td>
                <td height="25" align="left">&nbsp;
                    
                </td>
                <td height="25" align="right">&nbsp;
                    
                </td>
                <td height="25" align="left">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style1" style="width: 13%">
                    填报单位 ：
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtcompany" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td height="25" align="right">
                    填报日期 ：
                 <%--   <input id="txt_StartTime" type="text" class="easyui-datebox" data-options="formatter:myformatter,parser:myparser"
                         style='width: 162px;' name="datetime" />--%>
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtdate" uid="txtdate" runat="server" Width="200px" data-options="formatter:myformatter,parser:myparser"  class="easyui-datebox"></asp:TextBox>
                </td>
                <td height="25" align="right">
                    填报人员 ：
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtman" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td height="25" align="right" class="style1">
                    填报部门 ：
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="Textdept" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td align="right" style="height: 21px">
                    审核单位 ：
                </td>
                <td align="left" style="height: 21px">
                    <asp:TextBox ID="txtshcompany" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td align="right" style="height: 21px">
                    审核部门 ：
                </td>
                <td align="left" style="height: 21px">
                    <asp:TextBox ID="txtshdepart" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" class="style1" style="width: 13%">
                    审核日期 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtshdate" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;审核人员 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtshman" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                </td>
                <td align="right">&nbsp;
                    
                </td>
                <td align="left">&nbsp;
                    
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            BindDate($("input[uid='txtdate']").get(0).id);
        });
    </script>

</asp:Content>
