<%@ page language="C#" autoeventwireup="true" CodeBehind="index.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="jscript" type="text/javascript">
        function openDefault() {
            window.open("Default2.aspx", "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no");
            window.open('', '_self');
            //window.opener = null;
            //window.close();

            //window.opener.parent.removeThisTab();
        }
	</script>
</head>
<body onload="openDefault();">
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
