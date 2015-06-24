<%@ page language="C#" autoeventwireup="true" CodeBehind="ShowHD.aspx.cs" inherits="Work_projectBZ_ShowHD" enableEventValidation="false" stylesheettheme="Default" %>
<%@ Register Src="~/WebControls/Buttons1.ascx" TagName="Buttons1" TagPrefix="uc1" %>
<html>
<head runat="server">
    <script src="/jss/PublicJS.js" type="text/javascript"></script>

    <style type="text/css">
        .tKeepAll{width:100%;border:1px solid #999;}
        .tKeepAll th{
	        word-break: keep-all;
	        white-space:nowrap;
	        border-right-width: 1px;
	        border-bottom-width: 1px;
	        border-right-style: solid;
	        border-bottom-style: solid;
	        border-right-color: #CCCCCC;
	        border-bottom-color: #CCCCCC;
        }
        .tKeepAll td{
	        word-break: keep-all;
	        white-space:nowrap;
	        border-right-width: 1px;
	        border-bottom-width: 1px;
	        border-right-style: solid;
	        border-bottom-style: solid;
	        border-right-color: #CCCCCC;
	        border-bottom-color: #CCCCCC;
        }
    </style>
</head><body >
<div id='divMain' style="position:absolute;height:600px;width:100%;overflow:auto;background:#EEEEEE;" >
<form runat="server" id="form1" onsubmit="return IsSubmit()">
<input type="hidden" id="ibtid" name="ibtid" uid='ibtid' runat="server" />
<input type="hidden" id="jgjlText_H" name="jgjlText" uid='jgjlText' runat="server" />
<uc1:Buttons1 ID="Buttons1_1" runat="server" />
            <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                ContextMenuCssClass="RightMenu" AllowSorting="true" CssClass="tKeepAll"
               >
            </yyc:SmartGridView></form>
<div id="divHet"></div>
</div>
<script type="text/javascript">

    function PageSubmit(val) {

        //windowFull();
        //alert(val);
        if (val == "ibtcontrol_ibtrefresh") {
            window.location.reload();
        }

        if (val == "ibtcontrol_ibtimpower") {
            //window.parent.IsDo("授权");
            if (!confirm("您确定要给该职员授权吗？")) {
                val = "";
                return false;
            }
        }

        if (val == "ibtcontrol_ibtsetback") {
            //window.parent.IsDo("弃审");
            if (!confirm("您确定要将该笔数据弃审吗？")) {
                val = "";
                return false;
            }
        }

        if (val == "ibtcontrol_ibtrollback") {
            //window.parent.IsDo("退回");
            if (!confirm("您确定要将该笔数据退回吗？")) {
                val = "";
                return false;
            }
        }

        if (val == "ibtcontrol_ibtaudit") {
            //IsDo("审核");
            if (!confirm("您确定要执行该项操作吗？")) {
                val = "";
                return false;
            }
        }

        if (val == "ibtcontrol_ibtapply") {
            //IsDo("审批");
            if (!confirm("您确定要执行该项操作吗？")) {
                val = "";
                return false;
            }
        }

        if (val == "ibtcontrol_ibtdelete") {
            //window.parent.IsDo("删除");
            if (!confirm("您确定要该笔数据删除吗？"))
                return false;
        }

        //查看日志
        if (val == "ibtcontrol_ibtlook") {
            try {
                val = "";
                openLog();
            } catch (e) { };
            return false;
        }
        if (val == "ibtcontrol_ibtputout") {
            try {
                val = "";
                openPrint();
            } catch (e) { };
            return false;
        }

        if (val == "ibtcontrol_ibtexit") {
            try {
                window.parent.IsCloseTab();
            } catch (e) { window.close(); }
        }
        document.all('<%=ibtid.ClientID %>').value = val;
        }
        function IsSubmit() {
            if (document.all('<%=ibtid.ClientID %>').value == "")
            return false;
        else {
            //内容页如需提交时验证，需实现IsOnSubmit()方法。
            try { return IsOnSubmit(); } catch (e) { return true; }
        }
    }
    function GetHeight() {
        var gvResult = document.getElementById('<%=gvResult.ClientID %>');

    //document.getElementById('divHet').style.height=document.body.offsetHeight-gvResult.offsetHeight;
    document.getElementById('divMain').style.height = document.body.offsetHeight - 5;
}
function openPrint() {
    tbSaveExcel('财政资金项目台帐', '<%=gvResult.ClientID %>', window)
}
setTimeout(GetHeight, 0);
</script>
</body>
</html>