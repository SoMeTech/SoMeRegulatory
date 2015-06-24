<%@ page language="C#" masterpagefile="~/Master/MainAddUpdate.master" title=" " autoeventwireup="true" CodeBehind="PublicReportWHMx.aspx.cs" inherits="Work_PublicReportWH_PublicReportWHMx" enableEventValidation="false" stylesheettheme="Default" %>

<%@ MasterType VirtualPath="~/Master/MainAddUpdate.master" %>
<%@ Register Src="~/WebControls/UserControl/FilePostCtr.ascx" TagName="FilePostCtr" TagPrefix="uc1" %>

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

    <script src="HeTong.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        var path = '<%=QxRoom.Common.Public.RelativelyPath("WebControls/UserControl/") %>';//删除按钮路径
        function findwindow(val, obj) {
            var webFileUrl = "../../../Shared/DiagList/GetSession.aspx?tn=" + val + "&pd_year=" + $("select[uid='ddlPD_YEAR']").get(0).value;
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
    </script>
    
    <div style="text-align:left;"><table border="0" style="width:100%;">
	<tr style="display:none;">
	<td align="right" style="width:130px; height:30px;">
		自动编号
	：</td>
	<td align="left">
		<asp:label id="lblAUTO_NO" runat="server"></asp:label>
	</td>
	<tr>
	<td align="right" style="width:130px; height:30px;">
		项目名称
	：</td>
	<td align="left">
		<input type="text" id="txtPD_PROJECT_CODE" uid='txtPD_PROJECT_CODE' runat="server" style="width:200px;display:none;"   readonly="readonly" />
	    <input type="text" id='txtPD_PROJECT_Name' uid='txtPD_PROJECT_Name' runat="server" style="width:200px;" onClick="javascript: findwindow('proj_bianma2&pd_found_xz=01', this);" readonly="readonly" />
	<span style="color: Red"> *</span></td>
	<td align="right" style="width:130px; height:30px;">
		合同类型
	：</td>
	<td align="left">
        <asp:DropDownList ID="txtPD_CONTRACT_TYPE"  uid="txtPD_CONTRACT_TYPE" runat="server" Width="200px">
        </asp:DropDownList>	
        <span style="color: Red"> *</span>
	</td>
	<td align="right" style="width:130px; height:30px;">
		合同编号
	：</td>
	<td align="left">
	    <input type="text" id="txtPD_CONTRACT_NO" uid='txtPD_CONTRACT_NO' runat="server" style="width:200px;" disabled="disabled" />
	    <span style="color: Red"> *</span>
	</td>
	</tr>
	<tr>
	<td align="right">
		合同名称
	：</td>
	<td align="left">
		<asp:TextBox id="txtPD_CONTRACT_NAME" runat="server" Width="200px"></asp:TextBox>
	</td>
	<td align="right" style="width:130px; height:30px;">
		合同日期
	：</td>
	<td align="left">
	    <input type="text" id="txtPD_CONTRACT_DATE" uid='txtPD_CONTRACT_DATE' readonly="readonly" runat="server" style="width:180px;" />
	    <span style="color: Red"> *</span>
	</td>
	<td align="right">
		合同签约单位
	：</td>
	<td align="left">
		<asp:TextBox id="txtPD_CONTRACT_COMPANY" uid="txtPD_CONTRACT_COMPANY" runat="server" Width="200px"></asp:TextBox>
	    <span style="color: Red"> *</span>
	</td>
	</tr>
	<tr>
	<td align="right">
		合同金额
	：</td>
	<td align="left">
	    <input type="text" id="txtPD_CONTRACT_MOENY" uid="txtPD_CONTRACT_MOENY" runat="server" style="width:200px;" onKeyPress="myKeyDown(this,event,0);" onchange="setBGJE(this)" maxlength='10'/>
	    <span style="color: Red"> *</span>
	</td>
	<td align="right" style="width:130px; height:30px;">
		合同变更后金额
	：</td>
	<td align="left">
	    <input type="text" id="txtPD_CONTRACT_MOENY_CHANGE" uid="txtPD_CONTRACT_MOENY_CHANGE" runat="server" style="width:200px;" disabled="disabled"/>
	</td>
	<td align="right">
		合同工期要求
	：</td>
	<td align="left">
		<asp:TextBox id="txtPD_CONTRACT_ASK_LIMIT" uid="txtPD_CONTRACT_ASK_LIMIT" runat="server" Width="200px"></asp:TextBox>
	    <span style="color: Red"> *</span>
	</td></tr>
	<tr>
	<td align="right">
		合同进度要求
	：</td>
	<td align="left">
	    <input type="text" id="txtPD_CONTRACT_ASK_PROCEED" uid="txtPD_CONTRACT_ASK_PROCEED" runat="server" style="width:200px;"/>
	    <span style="color: Red"> *</span>
	</td>
	<td align="right" style="width:130px; height:30px;">
		合同付款要求
	：</td>
	<td align="left">
		<asp:TextBox id="txtPD_CONTRACT_ASK_PAYMENT" uid="txtPD_CONTRACT_ASK_PAYMENT" runat="server" Width="200px"></asp:TextBox>
	    <span style="color: Red"> *</span>
	</td>
	<td align="right">
		合同备注
	：</td>
	<td align="left">
		<asp:TextBox id="txtPD_CONTRACT_NOTE" runat="server" Width="200px"></asp:TextBox>
	</td>
	</tr>
     <tr>
        <td align="right" style="width: 130px; height: 30px;">
            年度
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlPD_YEAR" uid="ddlPD_YEAR" runat="server" Width="206px" onchange="csPD_PROJECT_CODE()">
            </asp:DropDownList>
            <span style="color: Red">*</span>
        </td>
        <td align="right">
        </td>
        <td align="left">
        </td>
        <td align="right">
        </td>
        <td align="left">
        </td>
    </tr>
	<tr>
	<td align="right" style="width:130px; height:30px;">
		合同相关资料
	：
		</td>
	<td align="left" colspan=5>
        <table id="zxzb_bt" runat="server">
            <tr><td>
                <div id='upfile10000' style='Width:100%' onMouseOver="MouseOnRowIndex=10000"><div id='ShowDIV10000' class="filetxt"></div></div>
            </td><td>
                <div class="fileUpArea"  onmouseover="MouseOnRowIndex=10000"><input type="file"  class="fileinput" name="filesupload"  onchange="BindUpLoad(this,'zxzb_bt',0)" ColumnIndex='0' rowIndex='10000' onMouseOver="MouseOnRowIndex=10000" /></div>
            </td></tr>
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
