<%@ page language="C#" autoeventwireup="true" CodeBehind="Default.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script language="jscript" type="text/javascript">
        function openDefault() {
            //moveTo(0,0);
            window.open("Default2.aspx", "", "toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no");
            window.open('', '_self');
            window.opener = null;
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
