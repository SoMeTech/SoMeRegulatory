<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_ShowUrl" CodeBehind="ShowUrl.aspx.cs" %>

<%@ Register Src="../../WebControls/Buttons1.ascx" TagName="Buttons1" TagPrefix="uc2" %>

<%@ Register Src="../../WebControls/FileShow.ascx" TagName="FileShow" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        window.name = "file";
        window.returnValue = "";
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" height="400" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="1" valign="top" class="bordercolor1">
                </td>
                <td valign="top" class="gridviewbgcolor">
                    <br />
                    <!--
                    <asp:Table ID="TbFiles" runat="server" Width="95%" CellPadding="0" CellSpacing="0" CssClass="menutext" HorizontalAlign="Center" BorderStyle="Dotted" BorderColor="#404040">
                    </asp:Table>
                    -->
                    <uc1:FileShow ID="fs1" runat="server" />
                </td>
                <td width="1" valign="top" class="bordercolor1">
                </td>
            </tr>
            <!--
            <tr>
                <td width="1" valign="top" bgcolor="#323232">
                </td>
                <td align="center"><a href="showurl.aspx" target="file">返回</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value="关闭" onclick="javascript:window.close();" /></td>
                <td width="1" valign="top" bgcolor="#323232">
                </td>
            </tr>
            -->
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg10.jpg" class="pagerightfoot">
            <tr>
                <td width="29" align="left">
                    <img src="images/bg8.jpg" width="29" height="23" /></td>
                <td>
                    &nbsp;</td>
                <td width="32" align="right">
                    <img src="images/bg7.jpg" width="32" height="23" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
