<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="Default2.aspx.cs"inherits="Default2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
        function openDefault() {
            window.returnValue = 'close';
            window.open("Default.aspx", "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no");
            window.open('', '_self');
            window.opener = null;//不需要确认直接关闭窗口
            window.close();
        }
	</script>
</head>
<body onload="openDefault();">
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
    </form>
</body>
</html>