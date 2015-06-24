<%@ page language="C#" masterpagefile="~/Master/MainMX.master" title="合同变更管理" autoeventwireup="true" CodeBehind="HeTongBGMx.aspx.cs" inherits="Work_projectGL_HeTongBG_HeTongBGMx" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainMX.master" %>
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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/jq.date.js") %>" type="text/javascript"></script>

    <script src="HeTongBG.js" type="text/javascript"></script>

    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        function findwindow(val, obj) {
            var webFileUrl = getWebFIleUrl(val);
            if (webFileUrl == "")
                return;
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");

            var arr = window.showModalDialog("../../../Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
            //alert(arr);
            if (arr != null && arr != "false") {
                if (arr.indexOf("~") > 0) {
                    ChuLiData(val, obj, arr)
                }
            }
        }
        function getWebFIleUrl(val) {
            var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&ProjectType=01";
            switch (val) {
                case "HeTongBH":
                    var txtPD_PROJECT_CODE = $("input[uid='txtPD_PROJECT_CODE']").get(0);
                    if (trim(txtPD_PROJECT_CODE.value) == "") {
                        webFileUrl = "";
                        Ext.Msg.alert("操作失败", "请先选择项目名称,才能选择合同");
                        return;
                    }
                    else
                        webFileUrl += "&PD_PROJECT_CODE=" + txtPD_PROJECT_CODE.value;
                    break;
                case "proj_bianma2":
                    var pd_year = $("select[uid='ddlPD_YEAR']").get(0).value;
                    webFileUrl += "&pd_found_xz=01&pd_year=" + pd_year;
                    break;
            }
            return webFileUrl;
        }
        function ChuLiData(val, obj, arr) {
            ss = arr.split("~");
            //alert(arr);
            try {
                switch (val) {
                    case "HeTongBH":
                        obj.value = ss[3];
                        $("input[uid='txtPD_CONTRACT_NO']").value = ss[0];
                        $("input[uid='txtPD_CONTRACT_MONEY']").value = ss[2];
                        SumCHANGE_ZJ_DL();
                        break;
                    case "proj_bianma2":
                        document.getElementById("<%=txtPD_PROJECT_CODE.ClientID %>").value = ss[0];
                    obj.value = ss[1];
                    break;
            }
        } catch (e) { alert(e) };
    }
    </script>

    <div style="text-align: left;">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr style="display: none;">
                <td align="right" style="width: 130px; height: 40px;">
                    自动序号 ：
                </td>
                <td align="left">
                    <asp:Label ID="lblAUTO_NO" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 30px;">
                    <span style="width: 130px; height: 40px;">项目</span>年度：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Width="206px" onchange="csPD_PROJECT_CODE()">
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 40px;">
                    项目名称 ：
                </td>
                <td align="left">
                    <input type="text" id="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server"
                        style="width: 200px; display: none;" readonly="readonly">
                    <input type="text" id='txtPD_PROJECT_Name' uid='txtPD_PROJECT_Name' runat="server"
                        style="width: 200px;" rdonly="1" onclick="javascript: findwindow('proj_bianma2', this);"
                        readonly="readonly" />
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 30px;">
                    合同类型 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="txtPD_CONTRACT_TYPE" runat="server" Width="206px">
                        <asp:ListItem Value="01">施工合同</asp:ListItem>
                        <asp:ListItem Value="02">设计合同</asp:ListItem>
                        <asp:ListItem Value="03">监理合同</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    合同名称 ：
                </td>
                <td align="left">
                    <input type='text' id='txtPD_CONTRACT_NO_Name' uid='txtPD_CONTRACT_NO_Name' runat="server"
                        readonly='readonly' style="width: 200px;" rdonly="1" onclick="javascript: findwindow('HeTongBH', this);" />
                    <input type='hidden' id='txtPD_CONTRACT_NO' uid='txtPD_CONTRACT_NO' runat="server" />
                    <span style="color: Red">*</span>
                </td>
                <td align="right" style="width: 130px; height: 40px;">
                    合同金额 ：
                </td>
                <td align="left">
                    <input id="txtPD_CONTRACT_MONEY" type='text' uid='txtPD_CONTRACT_MONEY' readonly='readonly'
                        style="background-color: #e9e9e9; color: #666; width: 200px;" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 40px;">
                    变更原因 ：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPD_CONTRACT_CHANGE_REASON" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td align="right">
                    变更时间 ：
                </td>
                <td align="left">
                    <input type="text" id="txtPD_CONTRACT_CHANGE_DATE" uid='txtPD_CONTRACT_CHANGE_DATE'
                        readonly="readonly" runat="server" style="width: 200px;" />
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    变更类型 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="txtPD_CONTRACT_CHANGE_TYPE" runat="server" Width="206px">
                        <asp:ListItem Value="01">一般变更</asp:ListItem>
                        <asp:ListItem Value="02">重大变更</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 30px;">
                    变更批复文号：
                </td>
                <td align="left">
                    <input type='text' runat="server" id='txtPD_CONTRACT_CHANGE_WH' uid='txtPD_CONTRACT_CHANGE_WH'
                        style="width: 200px;">
                </td>
                <td align="right">
                    变更金额 ：
                </td>
                <td align="left">
                    <input type='text' runat="server" id='txtPD_CONTRACT_CHANGE_ZJ' uid='txtPD_CONTRACT_CHANGE_ZJ'
                        onkeypress="myKeyDown(this,event,0);" onchange="SumCHANGE_ZJ_DL() " style="width: 200px;" />
                    <span style="color: Red">*</span>
                </td>
                <td align="right">
                    变更后金额 ：
                </td>
                <td align="left">
                    <input type='text' runat="server" id='txtPD_CONTRACT_CHANGE_MONEY' uid='txtPD_CONTRACT_CHANGE_MONEY'
                        readonly='readonly' style="width: 200px;">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 40px;">
                    合同变更资料 ：
                </td>
                <td colspan="5" align="left">
                    <table id="zxzb_bt" runat="server">
                        <tr>
                            <td>
                                <div id='upfile10000' style='width: 100%' onmouseover="MouseOnRowIndex=10000">
                                    <div id='ShowDIV10000' class="filetxt">
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="fileUpArea" onmouseover="MouseOnRowIndex=10000">
                                    <input type="file" class="fileinput" name="filesupload" onchange="BindUpLoad(this,'zxzb_bt',0)"
                                        columnindex='0' rowindex='10000' onmouseover="MouseOnRowIndex=10000" /></div>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <uc1:FilePostCtr ID="FilePostCtr1" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <input type="hidden" id="json_btData" uid="json_btData" runat="server" />
    </div>
</asp:Content>
