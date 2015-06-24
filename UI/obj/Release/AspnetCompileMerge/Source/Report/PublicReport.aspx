<%@ page language="C#" masterpagefile="~/Master/Report.master" autoeventwireup="true" inherits="Report_PublicReport" ValidateRequest="false" title=" " enableEventValidation="false" stylesheettheme="Default" CodeBehind="PublicReport.aspx.cs" %>

<%@ MasterType VirtualPath="~/Master/Report.master" %>
<%@ Register Src="~/WebControls/reprotButtonlTwo.ascx" TagName="reprotButtonlTwo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        @media print
        {
            .buttonNoPrint
            {
                display: none;
            }
            .PageNext{page-break-after: always;}
        }
    </style>
    <style>
        .tKeepAll
        {
            width: 100%;
        }
        .tKeepAll t
        {
            word-break: keep-all;
            white-space: nowrap;
            border: 1px solid #666; 
        }
       th{
            background-color: #dedede;
            color:#333333;
	        line-height:20px;
	        padding:2px;
	        font-weight:bold;
            text-align: center;
            border: 1px solid #666;  
       }
   
        #ui-datepicker-div {z-index:10000 !important;}
    </style>

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

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PublicJS.js") %>" type="text/javascript"></script>
    
    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/PulbicReport.js") %>" type="text/javascript"></script>

    <link href="../WebControls/TextSelect/TextSelect.css" rel="stylesheet" type="text/css" />

    <script src="../WebControls/TextSelect/TextSelect.js" type="text/javascript"></script>
    
<script type="text/javascript">
        function BindDate(objID,_dateFormat)
        {
            _dateFormat=_dateFormat==null?'yy-m-d':_dateFormat;
            $('#'+objID).datepicker({
                dateFormat: _dateFormat,
                buttonImage: '/images/calendar.gif', 
                buttonImageOnly: true ,
                showOn: 'both'
            });
        }
        function getCookie(objName) {//获取指定名称的cookie的值
            var arrStr = document.cookie.split("; ");
            for (var i = 0; i < arrStr.length; i++) {
                var temp = arrStr[i].split("=");
                if (temp[0] == objName)
                    return unescape(temp[1]);
            }
        }
        function CallDivHidden()
        {
            try{
            document.getElementById("div1").style.overflow = 'hidden';
            document.getElementById("div1").style.width = 'auto';
            document.getElementById("div1").style.padding = '0 0 0 0'; 
            }catch(e){}
        }
        function CallDivShow() {
            try{
            document.getElementById("div1").style.overflow = 'auto';
            document.getElementById("div1").style.width = getCookie('allwid')-80;
            document.getElementById("div1").style.padding = '0 0 0 37px'; 
            }catch(e){}
        }
        function findwindow(val,tb,column,where,obj)
        {
            var webFileUrl = "../../Shared/DiagList/GetSession.aspx?tn=PublicReport&tb=" + tb + "&column=" + column + "&where=" + where;
            var shMod_cs = "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0";
            
            //var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
            var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            _xmlhttp.open("POST", webFileUrl, false);
            _xmlhttp.send("");
            var arr = window.showModalDialog("../../Shared/DiagList/Home.aspx", window, shMod_cs);
            obj.value=arr.split('~')[1];
        }
        
</script>
    <div id="window1" uid="window1" runat="server" style="display: none; width:500px;" class="buttonNoPrint">
    </div>
<%--    <input type="hidden" runat="server" id="GOV_VIEW_NAME" />--%>
    <input type="hidden" runat="server" id="ISSHOW" uid="ISSHOW" />
    <input type="hidden" runat="server" id="reportParameter" uid="reportParameter" />
    <input type="hidden" runat="server" id="reportParameterSchema" uid="reportParameterSchema" />
    <input type="hidden" runat="server" id="SpanRow" uid="SpanRow" />
    <%--<input type="hidden" runat="server" id="HiDateType" uid="HiDateType" value="yy-m-d" />--%>
    <input type="hidden" id="ibtid" name="ibtid" uid='ibtid' runat="server" />
    <input type="hidden" id="selectXMl" name="selectXMl" uid='selectXMl' runat="server" />
    <table uid='tbHead' style="width: 100%; border: 0px solid #FFFFFF;" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="50" align="center" valign="middle" style="border: 0px solid #FFFFFF;"
                colspan="1">
                <label id="tbHead" runat="server" style="width: 100%; font-size: 24px;" />
            </td>
        </tr>
        <tr>
            <td style="padding:0 0 0 37px">
                <uc1:reprotButtonlTwo ID="reprotButtonl1" runat="server" />
                <input type="button" value="高级查询" id="gjSelect" class="buttonNoPrint" style="height: 30px"
                    onclick="ShowSelect()" />
            </td>
        </tr>
    </table>
    <br />
    <div style=" text-align:left;width:100%;overflow:hidden; padding:0 0 0 37px;" id="div1" uid="ShowDataDiv" >
        
       <yyc:SmartGridView ID="gvResult" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
            CssClass="tKeepAll" ContextMenuCssClass="RightMenu" >
           <FixRowColumn FixColumns="" FixRows="" FixRowType="Header,Pager" />
        </yyc:SmartGridView>
    </div>
</asp:Content>
