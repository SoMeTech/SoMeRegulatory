<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default"  CodeBehind="Login.aspx.cs" inherits="Login_page" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>乡镇财政资金监管信息系统--用户登陆</title>
    <link href="css/applus.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jss/login.js"></script>

    <script type="text/javascript" src="jss/Community.js"></script>
    <script src="jss/jquery-1.4.2.min.js" type="text/javascript"></script>
    
    <style type="text/css">
        .AnyiTitle
        {
            font-family: "宋体";
            font-size: 18px;
            font-weight: bold;
        }
        .unChangedFontSize
        {
            font-family: "宋体";
            font-size: 12px;
        }
        .style1
        {
            width: 75px;
        }
        #msg
        {
          color:Red;
          font-family:"宋体";
          font-size:13px;
        }
        	
        </style>

    <script type="text/javascript">

        var val11 = 1;
        function findwindow(val,num)
        {
            if(document.all["txtUser"].value=='')
            {
                if(val11 == 1)
                {
                    alert('请输入用户名！');
                }
                document.all["txtUser"].focus();
                val11 += 1;
            }           
            else
            {
           
           
           
                var webFileUrl = "Shared/DiagList/GetSession.aspx?tn="+val+"&UsersPk="+escape(document.all["txtUser"].value);
                var _xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                _xmlhttp.open("POST", webFileUrl, false);
                _xmlhttp.send("");
    　　		
                var arr = window.showModalDialog("Shared/DiagList/Home.aspx", window, "dialogWidth:350px; dialogHeight:400px;resizable:0; help:0; status:0");
                //alert(arr);
                if (arr != null)
                {
                    if (arr != "false")
                        helpMess(arr,num);
                }
            }
        }

        function closeMsg() {

          
            document.getElementById("msg").style.display ="none";
       
        }
        function helpMess(val,num)
        {
            if (val.indexOf("~")>0)
            {
                ss=val.split("~");
                if(num == "1")
                {
                    document.all["CompanyPk"].value = ss[0];
                    document.all["txtCompany"].value = ss[1];
                    document.all["txtPW"].focus();
                }
            }
            else
            {
                document.all["CompanyPk"].value = "";
                document.all["txtCompany"].value = "";
            }
        }
        
        function findcompany()
        {
            if(document.all["txtUser"].value != "" && document.all["txtCompany"].value == "")
            {
                document.all["txtCompany"].focus();
            }
        }
        
        function setfocus()
        {
            if(document.all['txtUser'].value=="")
            {
                document.all['txtUser'].focus();
            }
            else
            {
                document.all["txtPW"].focus();
            }
        }
        //屏蔽右键
        function document.oncontextmenu() 
        { 
            return false;
        }
       
        
        function findcompany()
        {

            if (document.all["txtUser"].value != "") 
            {   
                $.ajax({
                    url: "login.ashx?username="+encodeURIComponent( document.all["txtUser"].value),
                    type: "post",
                    dataType: "text",
                    async: true ,
                    error: function(e){alert("error!!");},
                    success: function(msg){//msg为返回的数据，在这里做数据绑定
                        if(msg != null && msg != "false")
                        {
                            var val1 = msg;
                            var val = val1.split(',');
                            document.all["txtCompany"].value = val[1];
                            document.all["CompanyPk"].value = val[0];
                        }
                        else
                        {
                            //先不提示，信息不足，回来处理
                            alert("该用户不存在或未分配单位！。");
                            document.all["txtUser"].focus();
                        }
                        return;
                    }
                });
                //调用服务端方法
                //调用方法:类名.方法名 (参数为指定一个回调函数)
                //                Login_page.GetCompanyCodeAndName(document.all["txtUser"].value, GetCompanyCodeAndName_callback);
                //                document.all["txtPW"].focus();
            }
        }
        
        function GetCompanyCodeAndName_callback(res) //回调函数,显示结果
        {
            //alert(res.value);
            if(res.value != null && res.value != "false")
            {
                var val1 = res.value;
                var val = val1.split(',');
                document.all["txtCompany"].value = val[1];
                document.all["CompanyPk"].value = val[0];
            }
            else
            {
                alert("该用户不存在或未分配单位！");
                //document.all["txtUser"].focus();
            }
        }
     
        
        //        //打开新的窗体
        //        function OpenPage(iWidth,iHeight,Url) {
        //            window.returnValue = 'close';
        //            var iWidth=iWidth;//弹出窗口的宽度;
        //            var iHeight=iHeight;//弹出窗口的高度;
        //            var iTop = (window.screen.availHeight-30-iHeight)/2;//获得窗口的垂直位置;
        //            var iLeft = (window.screen.availWidth-10-iWidth)/2;//获得窗口的水平位置;
        //            window.open(Url, "_blank", "toolbar=no,status=no,resizable=no,width="+iWidth+",height="+iHeight+",scrollbars=no,left="+iLeft+",top="+iTop+"");
        //            window.open('', '_self');
        //            window.opener = null;
        //        }
        function addfavorite()
        {
            var url = window.location.href.substring(0,window.location.href.lastIndexOf('/'))+"/index.aspx";
            if (document.all && window.external){ 
                try{
                    window.external.addToFavoritesBar(url,'乡镇财政资金监管信息系统', 'slice');
                    window.external.AddFavorite(url,'乡镇财政资金监管信息系统');}catch(e){ }
            }else if (window.sidebar){
                window.sidebar.addPanel('乡镇财政资金监管信息系统', url, "");
            }else{
                alert("浏览器不支持，请手动加入收藏夹");
            }
        } 
        $(document).ready(function(){
            $("#D_ClientChange").css({position:"absolute", left:document.body.scrollWidth-80,top:"10"});
            
        })
    </script>

    <style type="text/css">
        .AnyiTitle
        {
            font-family: "宋体";
            font-size: 18px;
            font-weight: bold;
        }
        .unChangedFontSize
        {
            font-family: "宋体";
            font-size: 12px;
        }
        .style1
        {
            width: 75px;
        }
    </style>
</head>
<body leftmargin="0" rightmargin="0" topmargin="0" onLoad="init();" class="login_bodybg" >
    <!--onload="javascript:setfocus();"-->

    <script src="<%=QxRoom.Common.Public.RelativelyPath("jss/Qx_nz.js") %>" type="text/javascript"
        charset="gb2312"></script>

    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0"  style="width:100%; height:800px;" background="./images/new/BackImg.jpg">
                    <tbody>
                        <tr>
                            <td align="center" valign="center">
                            
            <div style="position:absolute; top:308px; left:405px; width:235px; height: 63px;">
            <div style="display:none;"><asp:TextBox ID="txtServer" runat="server" ReadOnly="true"></asp:TextBox><img alt="更改服务器配置" onClick="OpenPage('ChangService.aspx','300','165')" src="images/chazhao.png" /></div>
            <div style="display:none;">单位组织: <select id="orgdepart" name="orgdepart" size="1"><option value="">-</option></select></div>
            <div><asp:TextBox ID="txtUser" runat="server" CssClass="login_input" onFocus="closeMsg()" onblur="findcompany()" OnTextChanged="txtUser_TextChanged" Width="200" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser" ErrorMessage="*"
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
            <div style=" padding-top:26px;">
            <asp:TextBox ID="txtPW" runat="server" CssClass="login_input" onFocus="closeMsg()"  TextMode="Password" OnTextChanged="txtPW_TextChanged" Width="200"  MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPW" ErrorMessage="*"
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                    
                                                                    
            </div>
            <div style="padding-top:26px;position:absolute; top:24px;left:225px;width:135px;height:90px;">
               <p runat="server"  id="msg" class="msg" style="display:none">*用户名或者密码错误!</p>
            </div>
             <div style="position:absolute; top:95px; left:8px; text-align:left; width:230px; height:30px; color:#FFF;">
            <asp:DropDownList ID="dplND" runat="server" Width="80px" Height="30px"></asp:DropDownList>
             </div>
            <div style="position:absolute; top:95px; left:88px; text-align:left; width:230px; height:30px;">
           
            &nbsp&nbsp<asp:CheckBox ID="cbxPW" runat="server" Text="修改密码"  />
            
           <asp:TextBox ID="txtCompany" runat="server" onclick="javascript:findwindow('Users','1');" Width="100"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany" ErrorMessage="*"
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            <a href="javascript:addfavorite()">添加收藏</a>
            <input id="CompanyPk" type="hidden" runat="server" />
            </div>
            </div>
            
            <div style="position:absolute; top:440px; left:383px; width:235px;">
            <asp:ImageButton ID="btnTrue" runat="server" BorderWidth="0" ImageUrl="~/images/new/ok.png"
                        OnClick="btnTrue_Click" alt=""/>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        
                        <asp:ImageButton ID="ImageButton11" runat="server" BorderWidth="0" ImageUrl="~/images/new/cancel.png"
                        alt=""/>
            </div>
            
            </td></tr></tbody></table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>


