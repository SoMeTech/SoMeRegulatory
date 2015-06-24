<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="Home.aspx.cs" inherits="PublicMode_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <TITLE>
		<%=pageTitle%>
	</TITLE>
	
	<script type="text/javascript">

	    window.frames["top"].focus();

	    function onkeypress11(keycode) {
	        window.frames[0].onkeypress11(keycode);
	    }
	</script>
	
</head>
    <frameset name="base" rows="20,80" BORDER="1" frameborder="0" framespacing="1">
	    <frame name="top" src="CheckDataUp.aspx<%=MSSQL %>" border="0"  noresize target="help" marginwidth="0"
		    marginheight="0" />
	    <frame name="main" src="CheckData.aspx<%=MSSQL %>" border="0" noresize target="help" marginwidth="0"
		    marginheight="0" />
	    <noframes>
	    <body>
		    <p>此网页使用了框架，但您的浏览器不支持框架。</p>
		</body>
	    </noframes>
    </frameset>
</html>
