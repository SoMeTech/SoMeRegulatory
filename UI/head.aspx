<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="head.aspx.cs" inherits="head" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/Admin_Style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //关闭IE窗体
        function closepage()
        {
            window.parent.topClosePage();
        }
        
        //注销登录用户
        function logout()
        {
            window.parent.topLogOut();
        }
        
        //屏蔽右键
        function document.oncontextmenu() 
        { 
            return false; 
        } 
        
        //实时走动的时间
        function tick() {
            //haha
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
            window.setTimeout("tick();", 100);
        }
        window.onload = tick;
    </script>
<%--    <style type="text/css">
        .auto-style1 {
            background-image: url('images/img/header_a.jpg');
            background-repeat: no-repeat;
            background-position: left top;
            width: 530px;
        }
    </style>--%>
</head>
<body onload="startclock()">    
    <form id="form1" runat="server">
    <div>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="header_box">
    <tr>
        <td class="header_a">&nbsp;</td>
        <td class="header_b">&nbsp;</td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="header_c">
    <tr>
    	<td width="30" align="center"><img src="images/img/u_a.gif" width="20" height="20" alt="";style="margin-top:-3px;"/></td>
        <td width="60%"><span class="f_red"><asp:Label ID="lbluser" runat="server" Text="Label" ></asp:Label></span>&nbsp;&nbsp;欢迎您登录！&nbsp;&nbsp;<asp:Label ID="lblSN" runat="server" Text=""></asp:Label>今天是 <script type="text/javascript">
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
                       
    var timerID = null;
    var timerRunning = false;
    function stopclock (){
        if(timerRunning)
            clearTimeout(timerID);
        timerRunning = false;}
    function startclock () {
        stopclock();
        showtime();}
    function showtime () {
        var now = new Date();
        var hours = now.getHours();
        var minutes = now.getMinutes();
        var seconds = now.getSeconds()
        var timeValue = "" +((hours >= 12) ? "下午 " : "上午 " )
        timeValue += ((hours >12) ? hours -12 :hours)
        timeValue += ((minutes < 10) ? ":0" : ":") + minutes
        timeValue += ((seconds < 10) ? ":0" : ":") + seconds
        document.getElementById("thetime").innerHTML=timeValue;
        timerID = setTimeout("showtime()",1000);
        timerRunning = true;}

    //--hide-->   
                    </script> <span id="thetime" ></span>
</td>
        <td align="right" style="color: #A8C8DF;">
            <asp:Label ID="lblic" runat="server" Text="" ForeColor="Red"></asp:Label>&nbsp;|&nbsp;<a href="javascript:findwindow()">切换单位</a>&nbsp;|&nbsp;<a href="javascript:logout()">注销</a>&nbsp;|&nbsp;<a href="javascript:closepage()">退出系统</a>&nbsp;&nbsp;</td>
    </tr>
</table>


        <table border="0" cellpadding="0" cellspacing="0" width="100%" bordercolor="#082753" style="display:none;">
            <tr>
                <td background="images/new/topBack.png" height="100px">

                    <marquee width="75%" align="middle" direction="left" loop="-1" onmouseout="this.start()" onmouseover="this.stop()" scrollDelay="150"><img src="images/mbi_031.gif" /><b><asp:Label ID="labadmin" runat="server" Text="****" ForeColor="Red" Font-Size="10pt"></asp:Label></b>
                    欢迎您！
                    </marquee>
                    
                   
                    <b><a href="javascript:findwindow()">切换单位</a> | <a href="javascript:logout()">注销</a> | <a href="javascript:closepage()">退出系统</a></b>
                </td>
            </tr>
        </table>

    
        <script type="text/javascript" language="javascript">
            function findwindow(func)
            {
                var user = '<%=((SoMeTech.User.UserModel)Session["User"]).UserName %>';
                var webFileUrl = "Shared/DiagList/GetSession.aspx?tn=Users&&UsersPk="+user;
                var _xmlhttp = new ActiveXObject("MSXML2.XMLHTTP");
                _xmlhttp.open("POST", webFileUrl, false);
                _xmlhttp.send("");
     　　		
                var arr = window.showModalDialog("Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
                //alert(arr);
                if (arr != null)
                {
                    if (arr != "false")
                    {
                        if(func==null)
                            helpMess(arr);
                        else
                            func(arr);
                    }
                }
            }
           
            function helpMess(val)
            {
                if (val.indexOf("~")>0)
                {
                    ss=val.split("~");
                    head1.SetSession(ss[0], ss[1]);
                    window.parent.location.reload();
                }
            }
        </script>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">

    function ShowSelect(extWindow,databaseSelect)
    {
        if(extWindow==null)
        {
            databaseSelect.style.display="block";
            var height = databaseSelect.offsetHeight+1;
            databaseSelect.style.display="none";
            if(height>500)
                height=500;
            try{
                extWindow = new Ext.Window({
                    title : '高级查询',
                    plain : true,
                    width : 550,
                    draggable: true,//允许拖动和改变大小
                    shadow:false,//去除拖动大块阴影
                    isTopContainer : true, //顶层显示
                    modal : true, //仿模式窗体
                    closeAction : 'hide',// 关闭窗口	
                    maximizable : false,// 最大化控制 值为true时可以最大化窗体	  
                    //layout:'fit',   
                    autoScroll: true, //滚动条
                    bodyStyle:'position:relative;overflow-y:auto;overflow-x:auto;height:'+height+"px",
                    items : [databaseSelect]
                });
            }catch(e){alert("function ShowSelect()"+e)};
            databaseSelect.style.display="block";
        }
        extWindow.show();
    }
</script>
