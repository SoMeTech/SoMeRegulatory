
<%@ page language="C#" autoeventwireup="true" CodeBehind="ImgUp.aspx.cs" inherits="ImgUp" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
        function clickFile() {
            alert(1);
            document.getElementById("file1").onclick();
            alert(2);
        }
    </script>
    <style type="text/css">
    
 .fileUpArea{ width:80px; height:20px; background:url(./images/addfile.gif) no-repeat left top;position:relative; overflow:hidden;}
 .fileHover{ width:80px; height:20px; background:url(./images/addfilehover.gif) no-repeat left top;position:relative; overflow:hidden;}
        /*.fileinput{ width:60px;size:1%; position:absolute; margin-left:10px;margin-top:1px;filter:alpha(opacity=0);-moz-opacity:0;cursor:point;}
       
        #fileUpArea input{ width:60px;size:1%; position:absolute; margin-left:10px;margin-top:1px;filter:alpha(opacity=0);-moz-opacity:0;cursor:point;}*/
.fileinput{
        font-size:20px;cursor:pointer;
	    position :absolute;right:0;bottom:0;
	    filter:alpha(opacity=0);opacity:0;
   	    outline:none;hide-focus:expression(this.hideFocus=true);
 }
 .filetxt{ font-size:12px; color:#0066FF; padding:10px;}
 #filetxt img{ cursor:hand;}
 .spanstate{font-size:11px; color:#0099FF; padding:10px;}
           
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="file" id="file1"/><br />
    <img id="img1" onclick="clickFile()" />
    </div>
    </form>
</body>
</html>
