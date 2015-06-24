<%@ page language="C#" autoeventwireup="true" CodeBehind="GetXmlMess.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_GetXmlMess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据权限</title>
    <link href="../../css/Admin_Style.css" rel="stylesheet" type="text/css" />
    <script src="../../jss/GridViewChangeColor.js" type="text/javascript"></script>
    <script src="../../jss/Qx_nz.js" type="text/javascript"></script>
    <script src="../../jss/setday.js" type="text/javascript"></script>
</head>
<body text="#d">
    <form id="form1" runat="server">
        <div align="center">
            <asp:DropDownList ID="ddltablename" runat="server" OnSelectedIndexChanged="ddltablename_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlColumnName" runat="server" OnSelectedIndexChanged="ddlColumnName_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList></div>
    </form>
</body>
</html>
