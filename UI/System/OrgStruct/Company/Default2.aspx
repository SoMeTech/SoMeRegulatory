<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" CodeBehind="Default2.aspx.cs" stylesheettheme="Default" inherits="SystemSetup_OrgStruct_Company_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title id="title1" runat="server">组织架构</title>
    <link href="../../../css/Loading.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet"  type="text/css" href="../../../Ext/resources/css/ext-all.css" />
    
    <script src="../../../Ext/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="../../../Ext/ext-all.js"type="text/javascript"></script>
    
    <script src="../jss/AllEvents.js"type="text/javascript"></script>
    <script src="../jss/Main.js"type="text/javascript"></script>
    <script src="../../../jss/PageMethods.js"type="text/javascript"></script>
</head>
<body>

    <div id="loading">
        <div class="loading-indicator">
            <img src="../images/extanim32.gif" alt="" width="32" height="32" style="margin-right:8px;" align="absmiddle"/>
                Loading.....
        </div>
    </div>
    <div id="loading-mask">
    </div>
    
    <div id="botton" style="text-align:left;" class="bottonall">
        <%if (Session["pk_corp"] != null && Session["companyname"] != null && Session["user"] != null) %>
        <%{ %>
        <!--<marquee width="95%" align="middle" direction="left" loop="-1" onmouseout="this.start()" onmouseover="this.stop()" scrollDelay="100">-->
            当前系统运行环境：<b><%=login_comname %></b> | 
            用户单位：<b><%=user_comname %></b> | 
            用户部门：<b><%=user_braname %></b>
        <!--</marquee>-->
        <%} %>
    </div>
    
    <input type="hidden" id="hei" runat="server" />
    <input type="hidden" id="wid1" runat="server" />
    <input type="hidden" id="wid2" runat="server" />
    <input type="hidden" id="stu" runat="server" />
    
</body>
</html>
