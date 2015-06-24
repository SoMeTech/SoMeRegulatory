<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="1.aspx.cs" inherits="Shared_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">

        //var webFileUrl = "2.aspx?tn=123";
        var webFileUrl = "GetSession.aspx?tn=123";

        var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
        _xmlhttp.open("POST", webFileUrl, false);
        _xmlhttp.send("");

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
