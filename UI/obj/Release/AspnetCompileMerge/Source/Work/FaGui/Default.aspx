<%@ page language="C#" autoeventwireup="true" inherits="Work_FaGui_Default" CodeBehind="Default.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../jquery.easyui/css/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../jquery.easyui/css/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.easyui/js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui/js/jquery.easyui.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function myformatter(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
        }
        function myparser(s) {
            if (!s) return new Date();
            var ss = s.split('-');
            var y = parseInt(ss[0], 10);
            var m = parseInt(ss[1], 10);
            var d = parseInt(ss[2], 10);
            if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                return new Date(y, m - 1, d);
            } else {
                return new Date();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="txt_StartTime" type="text" class="easyui-datebox" data-options="formatter:myformatter,parser:myparser"
            required="true" style='width: 162px;' name="datetime" />
    </div>
    </form>
</body>
</html>
