<%@ page language="C#" autoeventwireup="true" inherits="Work_DataPrint_Excel_GetSystemParame"  CodeBehind="GetSystemParame.aspx.cs" enableEventValidation="false" stylesheettheme="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" runat="server" id="NowData" />
    <asp:TreeView runat="server" ID="tree1" ImageSet="Arrows" Target="mainFrame" ExpandDepth="1" ShowLines="True" Width="100%" BorderColor="beige" ShowExpandCollapse="True">
    </asp:TreeView>
    </div>
    </form>
    <script type="text/javascript">

        function CheckEvent() {
            var objNode = event.srcElement;//获取事件对象
            if (objNode.title != "") {
                window.returnValue = objNode.title.substring(1);
                window.close();
            }
        }
    </script>
</body>
</html>
