<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" inherits="ErrorMsg" CodeBehind="ErrorMsg.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误提示</title>

    <script type="text/javascript">
        //菜单收缩
        function menuCollapse(w){
            //setWidth(w);
        }
    
        //菜单打开
        function menuExpand(w){
            //setWidth(w);
        }
        //屏蔽右键
        function document.oncontextmenu() 
        { 
            return false; 
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color: #D4E4F6; height: 100%; width: 100%">
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" border="0" align="center" style="width: 100%;
            height: auto">
            <tr align="center">
                <td style="background-color: #D1E4F8">
                    <strong><span style="font-size: 12pt; color: red;">错误信息</span></strong><hr />
                </td>
            </tr>
            <tr>
                <td style="background-color: #E6EFF8" height="80px">
                    <br />
                    <b>产生错误的可能原因：</b><br />
                    <%--<li>您当前访问的页面不存在或者正在建设中！</li>--%>
                    <li>
                        <asp:Label ID="labError" runat="server" Text="Label"></asp:Label></li>
                </td>
            </tr>
            <tr align="center">
                <td style="background-color: #E6EFF8">
                    <a id="LnkReturnUrl" href="javascript:history.back();">&lt;&lt;&nbsp;返回上一页</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
