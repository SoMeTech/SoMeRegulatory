<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="Test.aspx.cs" inherits="PublicMode_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test</title>
    <link href="../css/Admin_Style.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">
		    function GetMess(val, cuspk) {
		        //var webFileUrl = "GetSession.aspx?tn=" + val;
		        //开始取值过程
		        //var xmlHttp = new ActiveXObject("MSXML2.XMLHTTP");
		        //xmlHttp.open("POST", webFileUrl, false);
		        //xmlHttp.send("");

		        var webFileUrl = "GetSession.aspx?tn=" + val + "&cuspk=" + cuspk + "";
		        var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
		        _xmlhttp.open("POST", webFileUrl, false);
		        _xmlhttp.send("");

		        var arr = window.showModalDialog("Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
		        //window.open("Home.aspx");
		        //var arr = "";
		        if (arr != null) {
		            if (arr != "false")
		                helpMess(arr);
		        }
		    }

		    function helpMess(val) {
		        if (val.indexOf("~") > 0) {
		            ss = val.split("~");
		            //document.form1.txtId.value = ss[0];
		            document.all["txtId"].value = ss[0];
		            document.all["txtMess"].value = ss[1];
		            //document.form1.txtId.focus();
		            document.all["txtId"].focus();
		        }
		        else {
		            document.all["txtMess"].value = "";
		            document.form1.txtId.value = "";
		        }
		    }
		</script>
		
		<!--鼠标拖动效果-->
		<script  type="text/javascript">
		    var tmpElement = null;
		    var dragElement = null;
		    var downX, downY, tmp_o_x, tmp_o_y;
		    var refElement = null;
		    var dragActive = 0;
		    var draging = 0;
		    function readyDrag() {
		        dragActive = 1;
		        if (event.srcElement.tagName != "DIV")
		            return;
		        dragElement = event.srcElement.parentNode;
		        tmpElement = dragElement.cloneNode(true);
		        tmpElement.style.filter = "alpha(opacity=90)";
		        tmpElement.style.zIndex = 2;
		        dragElement.style.zIndex = 1;
		        tmpElement.style.position = "absolute";
		        if (dragElement.parentNode.tagName != "BODY") {
		            dragElement.style.left = dragElement.offsetLeft + dragElement.parentNode.style.pixelLeft;
		            dragElement.style.top = dragElement.offsetTop + dragElement.parentNode.style.pixelTop;
		        }
		        downX = event.clientX;
		        downY = event.clientY;
		        tmp_o_x = dragElement.style.pixelLeft;
		        tmp_o_y = dragElement.style.pixelTop;
		        tmpElement.style.visibility = "hidden";
		        document.body.appendChild(tmpElement);
		        document.onmousemove = startDrag;
		    }
		    document.onmouseup = endDrag;
		    function startDrag() {
		        if (dragActive == 1 && event.button == 1 && dragElement != null && tmpElement != null) {
		            tmpElement.style.visibility = "visible";
		            tmpElement.style.left = tmp_o_x + event.clientX - downX;
		            tmpElement.style.top = tmp_o_y + event.clientY - downY;
		            dragElement.style.backgroundColor = "#CCCCCC";
		            document.body.style.cursor = "move";
		            draging = 1;
		        }
		    }
		    function endDrag() {
		        if (dragActive == 1 && tmpElement != null) {
		            if (draging == 1) {
		                dragElement.removeNode(true);
		                draging = 0;
		            }
		            tmpElement.style.filter = "alpha(opacity=100)";
		            tmpElement.style.zIndex = 1;
		            document.body.style.cursor = "default";
		            if (refElement != null && refElement.parentNode != null && refElement.parentNode.tagName != "BODY") {
		                tmpElement.style.width = refElement.parentNode.style.width;
		                tmpElement.style.position = "";
		                refElement.parentNode.insertBefore(tmpElement, refElement);
		            }
		        }
		        dragElement = null;
		        tmpElement = null;
		        dragActive = 0;
		    }
		    function readyInsert() {
		        if (dragActive == 1) {
		            var element = event.srcElement;
		            if (element == dragElement) return;
		            if (element.tagName != "DIV")
		                return;
		            if (element.className == "dragBar" || element.className == "textSheet" || element.className == "blankBar")
		                element = element.parentNode;
		            element.style.backgroundColor = "#CCCCCC";
		            element.style.filter = "alpha(opacity=50)";
		            refElement = element;
		        }
		    }
		    function failInsert() {
		        var element = event.srcElement;
		        if (element.tagName != "DIV")
		            return;
		        try {
		            if (element.className == "dragBar" || element.className == "textSheet" || element.className == "blankBar")
		                element = element.parentNode;
		        } catch (e) { }
		        element.style.filter = "alpha(opacity=100)";
		        element.style.backgroundColor = "#FFFFFF";
		        refElement = null;
		    }
		    document.onselectstart = function () { return false }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_one" class="div_one" style="Z-INDEX:1; LEFT:80px; WIDTH:433px; POSITION:absolute; TOP:80px; BACKGROUND-COLOR:#ffffff; layer-background-color:#FFFFFF"
		onmouseover="readyInsert()" onmouseout="failInsert()">
		<div onmousedown="readyDrag()" style="BORDER-RIGHT:#996666 1px solid; BORDER-TOP:#996666 1px solid; BORDER-LEFT:#996666 1px solid; CURSOR:move; BORDER-BOTTOM:#996666 1px solid; HEIGHT:18px; BACKGROUND-COLOR:#996666"
			name="dragDIV" class="dragBar">公共参照测试窗口</div>
		<div>
			<input id="txtId" name="txtId" runat="server" type="text"> <input id="txtMess" name="txtMess" runat="server" type="text" onfocus="javascript:GetMess('SubjectKind','');">
			<input id="Button1" type="button" value="参 照" onclick="javascript: GetMess('SubjectKind', '');" runat="server"><!--  -->
		</div>
	</div>
    </form>
</body>
</html>
