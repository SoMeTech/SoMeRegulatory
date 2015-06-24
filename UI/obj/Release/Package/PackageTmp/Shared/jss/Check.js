//首先我们创建一个XMLHttpRequest对象
//源码下载及讨论地址：http://www.51aspx.com/CV/AjaxCheckUser

var xmlHttp;
var flog = 1;
function createXmlHttpRequest()
{
    if(window.XMLHttpRequest)
    {
        xmlHttp=new XMLHttpRequest();
    
        if(xmlHttp.overrideMimeType)
        {
            xmlHttp.overrideMimeType("text/xml");
        }
    }
    else if(window.ActiveXObject)
    {
        try
        {
            xmlHttp=new ActiveXObject("Msxml2.XMLHTTP");   
        }
        catch(e)
        {
            xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");   
        }
    }
    if(!xmlHttp)
    {
        window.alert("你的浏览器不支持创建XMLhttpRequest对象");
    }
    return xmlHttp;
}

//判断文本框的值是否为空
function isNull(txtContent)
{
    if(txtContent.value=="")
    {
        if(flog == 1)
        {
            window.alert("该数据不能为空！");
            txtContent.focus();
        }
        flog+=1;
    }
}


//唯一性判断通用方法
//val---------------控件对象
//url---------------判断是否唯一的后台调用页面 + 参数名称
//text--------------错误信息
//obj---------------显示错误信息的 div 层的 ID
//code--------------事件代码
function checkIsRepeat(val,url,text,obj,code)
{
    createXmlHttpRequest();
    var url1=url+encodeURI(val.value)+"&Event="+code;
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        obj.innerHTML = '<font color="red">'+text+'</font>';
        obj.style.display = 'block';
    }
    else
    {
        obj.style.display = 'none';
    }
}


//检验服务名称
function checkServiceName(name,url)
{
    //isNull(name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(name.value)+"&Event=CheckName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
       window.alert('服务名已经存在！');
       name.value="";
       name.focus();
    }
    else
    {
       return;
    }
}

//检验服务编号
function checkServiceBH(BH,url)
{
    //isNull(BH);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=CheckBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('服务编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检验服务权限编码
function checkServicePowerCode(PowerCode,url)
{       
    //isNull(PowerCode);
    createXmlHttpRequest();
    var url1=url+"?PowerCode="+encodeURI(PowerCode.value)+"&Event=CheckPowerCode";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('服务权限编码已经存在！');
        PowerCode.value="";
        PowerCode.focus();
    }
    else
    {
        return;
    }
}

//检验菜单权限编码 
function checkMenuPowerCode(PowerCode,url)
{
    //isNull(PowerCode);
    createXmlHttpRequest();
    var url1=url+"?PowerCode="+encodeURI(PowerCode.value)+"&Event=CheckMenuPowerCode";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('菜单权限编码已经存在！');
        PowerCode.value="";
        PowerCode.focus();
    }
    else
    {
        return;
    }
}

//检验通用字典表编号的唯一性 
function checkUsualBookTableBH(BH,url,tableName)
{
    //isNull(BH);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkUsualBookTable&tableName="+tableName;
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('该编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检验通用字典表名称的唯一性 
function checkUsualBookTableName(Name,url,tableName)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(Name.value)+"&Event=checkUsualBookTable&tableName="+tableName;
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('该名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查业务类别编号的唯一性
function checkYWLBBH(BH,url)
{
    //isNull(BH);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkYWLBBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('业务类别编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检查业务类别名称的唯一性
function checkYWLBName(Name,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkYWLBName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('业务类别名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查服务类别编号的唯一性
function checkServiceTypeBH(BH,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkServiceTypeBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('服务类别名称已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检查服务类别名称的唯一性
function checkServiceTypeName(Name,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkServiceTypeName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('服务类别名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查税费类别名称的唯一性
function checkSFTypeName(Name,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkSFType";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('税费类别名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查计量计价类别名称的唯一性
function checkJLJJTypeName(Name,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkJLJJTypeName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('计量加价类别名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查服务类别编号的唯一性
function checkEmployeeBH(BH,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkEmployeeBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('员工编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检查部门编号的唯一性
function checkBranchBH(BH,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkBranchBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('部门编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检查角色编号的唯一性
function checkRoleBH(BH,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?BH="+encodeURI(BH.value)+"&Event=checkRoleBH";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('角色编号已经存在！');
        BH.value="";
        BH.focus();
    }
    else
    {
        return;
    }
}

//检查公司编号的唯一性
function checkCompanyBH(BH,url)
{
    //isNull(Name);
    if(BH.value.length<5)
    {
        createXmlHttpRequest();
        var url1=url+"?pk_corp="+encodeURI(BH.value)+"&Event=checkCompanyBH";
        xmlHttp.open("post",url1,false);
        xmlHttp.send(null);
        if(xmlHttp.responseText=="true")
        {
            window.alert('单位编号已经存在！');
            BH.value="";
            BH.focus();
        }
    }
    else
    {
        window.alert('单位编码只能是4位长度！');
        BH.value="";
        BH.focus();
    }
}

//检查公司名称的唯一性
function checkCompanyName(Name,url)
{
    //isNull(Name);
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkCompanyName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('单位名称已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//检查用户名的唯一性
function checkUserName(Name,url)
{
    createXmlHttpRequest();
    var url1=url+"?Name="+encodeURI(Name.value)+"&Event=checkUserName";
    xmlHttp.open("post",url1,false);
    xmlHttp.send(null);
    if(xmlHttp.responseText=="true")
    {
        window.alert('用户名已经存在！');
        Name.value="";
        Name.focus();
    }
    else
    {
        return;
    }
}

//创建用户检测的回调函数
function checkServiceNameResult()
{
    if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
        }
    }
}

//注册新的用户
function RegUser(Name,Pass)
{
    if(document.getElementById("UserName").value=="")
    {
        window.alert("用户名不能为空");
        document.getElementById("UserName").focus();
        return false;
    }
    if(document.getElementById("Password").value=="")
    {
        window.alert("密码不能为空");
        document.getElementById("Password").focus();
        return false;
    }
    if(document.getElementById("Password").value!=document.getElementById("Password1").value)
    {
        window.alert("确认密码错误");
        document.getElementById("Password1").focus();
        return false;
    }
    createXmlHttpRequest();
    var url="DisposeEvent.aspx?Name="+document.getElementById("UserName").value+"&Pass="+document.getElementById("Password").value+"&Event=Reg";
    xmlHttp.open("GET",url,true);
    xmlHttp.onreadystatechange=RegUserInfo;
    xmlHttp.send(null);
}

//创建注册用户的回调函数
function RegUserInfo()
{
    if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
            if(xmlHttp.responseText=="true")
            {
                window.alert("恭喜，新用户注册成功!");
            }
            else
            {
                window.alert("对不起,你注册失败");
            }
            document.getElementById("UserName").value="";
            document.getElementById("Password").value="";
            document.getElementById("Password1").value="";
        }
    }
}

function Set()
{
    document.getElementById("imgflag").src="image/load.GIF";
    document.getElementById("btnReg").disabled=false;
    document.getElementById("Password1").disabled=false;
    document.getElementById("btnlogin").disabled=false;
}

function loginResult()
{
    if(xmlHttp.readyState==4)//服务器响应状态
    {
        if(xmlHttp.status==200)//代码执行状态
        {
            if(xmlHttp.responseText=="true")
            {
                location="http://www.51aspx.com/CV/AjaxCheckUser";
            }
            else
            {
                window.alert("对不起,你登录失败");
                document.getElementById("UserName").value="";
                document.getElementById("Password").value="";
                document.getElementById("Password1").value="";
            }
        }
    }
}

function login()
{
    if(document.getElementById("UserName").value=="")
    {
        window.alert("用户名不能为空");
        document.getElementById("UserName").focus();
        return false;
    }
    if(document.getElementById("Password").value=="")
    {
        window.alert("密码不能为空");
        document.getElementById("Password").focus();
        return false;
    }    
    createXmlHttpRequest();
    var url="DisposeEvent.aspx?Name="+document.getElementById("UserName").value+"&Pass="+document.getElementById("Password").value+"&Event=login";
    xmlHttp.open("GET",url,true);
    xmlHttp.onreadystatechange=loginResult;
    xmlHttp.send(null);
}
   
