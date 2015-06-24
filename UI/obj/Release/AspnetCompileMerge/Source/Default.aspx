<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="Default.aspx.cs" inherits="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
  
<html xmlns="http://www.w3.org/1999/xhtml" > 
<head id="Head1" runat="server">
    <title id="title1" runat="server">乡镇财政资金监管信息系统</title>
    <META NAME="Generator" CONTENT="EditPlus">
    <META NAME="Author" CONTENT="">
    <META NAME="Keywords" CONTENT="">
    <META NAME="Description" CONTENT="">
    <link href="css/Loading.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Ext/resources/css/ext-all.css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    
    <script src="Ext/adapter/ext/ext-base.js" type="text/javascript"></script>
    <script src="Ext/ext-all.js" type="text/javascript"></script>
    <script src="jss/popup.js" type="text/javascript"></script>
    <script src="jss/AllEvents.js" type="text/javascript"></script>
    <script src="jss/Main.js" type="text/javascript"></script>
    <script src="jss/PageMethods.js" type="text/javascript"></script>
    
    <script  type="text/javascript">
        //屏蔽右键
        //function document.oncontextmenu() 
        //{ 
        //    return false; 
        //} 
        
        //实时走动的时间
        function tick() {
            var hours, minutes, seconds, xfile;
            var intHours, intMinutes, intSeconds;
            var today;
            today = new Date();
            intHours = today.getHours();
            intMinutes = today.getMinutes();
            intSeconds = today.getSeconds();
            if (intHours == 0) {
                hours = "12:";
                //xfile = "午夜";
            } else if (intHours < 12) { 
                hours = intHours+":";
                //xfile = "上午";
            } else if (intHours == 12) {
                hours = "12:";
                //xfile = "正午";
            } else {
                intHours = intHours - 12
                hours = intHours + ":";
                //xfile = "下午";
            }
            if (intMinutes < 10) {
                minutes = "0"+intMinutes+":";
            } else {
                minutes = intMinutes+":";
            }
            if (intSeconds < 10) {
                seconds = "0"+intSeconds+" ";
            } else {
                seconds = intSeconds+" ";
            } 
            timeString = hours+minutes+seconds;
            //Clock.innerHTML = timeString;
            window.setTimeout("tick();", 100);
        }
        window.onload = tick;
    </script>
</head>
<body>

    <div id="loading">
        <div class="loading-indicator">
            <img src="images/extanim32.gif" alt="" width="355" height="127" style="margin-right:8px;" align="absmiddle"/>
        </div>
    </div>
    <div id="loading-mask">
    </div>
    
    <div id="botton" style="font-size: 9pt; height:30px; line-height:30px;"  class="bottonall">
        <%if (Session["pk_corp"] != null && Session["companyname"] != null && Session["user"] != null) %>
        <%{ %>
        <%--<marquee width="94%" align="middle" direction="left" loop="-1" onmouseout="this.start()" onmouseover="this.stop()" scrollDelay="150">--%>
        
        <div class="footer_box">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="footer_a" style="table-layout: fixed">
                <tr>
                    <td align="left" class="f_blue">年度：<%=yearND %>年&nbsp;&nbsp;环境：<%=login_comname %>&nbsp;&nbsp;用户：<%=user_name%>&nbsp;&nbsp;单位：<%=user_comname %>&nbsp;&nbsp;&nbsp;&nbsp;部门：<%=user_braname %></td>
                    <td align="right" class="f_blue">IE版本：<%=verion %>&nbsp;&nbsp;Copyright © 2006-2015 XX信息科技有限公司&copy;</td>
                </tr>
            </table>
        </div>
        
        <table border="0" width="100%" height="20px" style="display:none;" >
            <tr>
                <td width="15%" align="left">运行环境：<b><%=login_comname %></b></td>
                <td width="15%" align="left"><script type="text/javascript">
                        <!--hide
    var enable=0; today=new Date();
    var day; var date;
    if(today.getDay()==0)  day=" 星期日" 
    if(today.getDay()==1)  day=" 星期一" 
    if(today.getDay()==2)  day=" 星期二" 
    if(today.getDay()==3)  day=" 星期三" 
    if(today.getDay()==4)  day=" 星期四" 
    if(today.getDay()==5)  day=" 星期五" 
    if(today.getDay()==6)  day=" 星期六" 
    date=(today.getFullYear())+"年"+(today.getMonth()+1)+"月"+today.getDate()+"日 ";
    document.write(date + day);
    //--hide-->   
                    </script></td>
                <td width="15%" align="left">用户：<b><%=user_name%></b></td>
                <td width="15%" align="left">单位：<b><%=user_comname %></b></td>
                <td width="15%" align="left">部门：<b><%=user_braname %></b></td>
                <td width="15%" align="left">角色：<b><%=user_rolname %></b></td>
                <td width="10%" align="center"><a href="ModelFile/dsoframer.rar" target="_blank">打证插件下载</a></td>
            </tr>
        </table>
             <%--| 
             | 
             | --%>
            
        <%--</marquee>--%>
        <%} %>
        
        &nbsp&nbsp&nbsp
    </div>
    
    <input type="hidden" id="hei" runat="server" />
    <input type="hidden" id="wid1" runat="server" />
    <input type="hidden" id="wid2" runat="server" />
    <input type="hidden" id="stu" runat="server" />
</body> 
</html> 