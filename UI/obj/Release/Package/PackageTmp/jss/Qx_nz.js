function Trim(str) {
    return str.replace(/^\s+|\s+$/g, '');
}

//回车调用指定按钮
function btnsearch(obj) {
    if (event.keyCode == 13) {
        eval("document.forms.item(0)." + obj + ".click()");
        return false;
    }
    else
        return true;
}
    
//回车调用指定按钮
function fifteenth(sixteenth, event) {
    var seventeenth = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (seventeenth == 13) {
        var eighteenth;
        for (eighteenth = 0; eighteenth < sixteenth.form.elements.length; eighteenth++) {
            if (sixteenth == sixteenth.form.elements[eighteenth])
                break;
        }
        eighteenth = (eighteenth + 1) % sixteenth.form.elements.length;
        sixteenth.form.elements[eighteenth].focus();
        return false;
    }
    else
        return true;
}

function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName)
            return unescape(temp[1]);
    }
}
function windowFull() {
    //var oPopup=window.createPopup();
    //var oPopBody=oPopup.document.body;

    var bgObj = document.createElement("div");
    bgObj.setAttribute('id', 'bgDiv');
    bgObj.style.position = "absolute";
    bgObj.style.top = "0";
    bgObj.style.background = "#fff";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75)";
    bgObj.style.opacity = "0.6";
    bgObj.style.left = "0";
    bgObj.style.width = document.body.offsetWidth;
    bgObj.style.height = document.body.offsetHeight;
    bgObj.style.zIndex = "10000";
    var bgframe = document.createElement("iframe");
    bgframe.style.background = "Transparent";
    bgframe.height = bgObj.style.height;
    bgframe.width = bgObj.style.width;
    bgframe.style.visibility = "inherit";
    bgframe.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
    bgObj.appendChild(bgframe);
    document.body.appendChild(bgObj);
    //oPopBody.appendChild(bgObj);
    //oPopup.show(0,0,1000,1000,document.body);
}

function removeWindowFull() {
    if (document.getElementById("bgDiv") != null)
        document.body.removeChild(document.getElementById("bgDiv"));
}

function Get_XmlHttp(_url) {
    var xmlHttp = new ActiveXObject("MSXML2.XMLHTTP");
    xmlHttp.open("POST", _url, false);
    xmlHttp.send("");
    return xmlHttp.responseText;
}

function Get_MicrosoftHttp(_url) {
    var xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    xmlHttp.open("POST", _url, false);
    xmlHttp.send("");
    return xmlHttp.responseText;
}

function CreateHTTPPoster() {
    if (window.XMLHttpRequest) return new XMLHttpRequest();
    try {
        return new ActiveXObject('MSXML2.XMLHTTP');
    }
    catch (e) {
        try {
            return new ActiveXObject('Microsoft.XMLHTTP');
        }
        catch (e) {
            try {
                return new ActiveXObject('MSXML2.XMLHTTP.4.0');
            }
            catch (e) {
                try {
                    return new ActiveXObject('MSXML2.XMLHTTP.3.0');
                }
                catch (e) {
                    try {
                        return new ActiveXObject('MSXML2.XMLHTTP.2.6');
                    }
                    catch (e) {
                        return null;
                    }
                }
            }
        }
    }
}

function return_del() {
    if (window.confirm("是否确定删除该数据？") == false)
        return false;
}

//验证复选框是否有选中的信息
function Check_Yes(form) {
    var obj1 = form;
    re_val = false;
    for (var i = 0; i < obj1.length; i++) {
        if (obj1[i].checked == true) {
            re_val = true;
            return re_val;
        }
    }
    return re_val;
}

//全选
function CheckAll(form) {
    for (var i = 0; i < form.elements.length; i++) {
        var e = form.elements[i];
        //alert(e.type);
        if (e.type == "checkbox") {
            if (e.id != "all_sel" && e.id != "no_all_sel")
                e.checked = true;
        }
    }
}
  
//反选
function no_CheckAll(form) {
    for (var i = 0; i < form.elements.length; i++) {
        var e = form.elements[i];
        if (e.type == "checkbox") {
            if (e.id != "all_sel" && e.id != "no_all_sel") {
                if (e.checked == true)
                    e.checked = false;
                else
                    e.checked = true;
            }
        }
    }
}
  
//身份证15位转18位
function jsz_15_to_18(sender) {
    var obj1 = sender;
    osfzhm = obj1.value;
    if (osfzhm.length == 18) {
        return osfzhm;
    }

    if (osfzhm.length != 15) {
        return osfzhm;
    }

    var w = new Array(17);
    w[0] = 7;
    w[1] = 9;
    w[2] = 10;
    w[3] = 5;
    w[4] = 8;
    w[5] = 4;
    w[6] = 2;
    w[7] = 1;
    w[8] = 6;
    w[9] = 3;
    w[10] = 7;
    w[11] = 9;
    w[12] = 10;
    w[13] = 5;
    w[14] = 8;
    w[15] = 4;
    w[16] = 2;

    var y = new Array(10);
    y[0] = "1";
    y[1] = "0";
    y[2] = "X";
    y[3] = "9";
    y[4] = "8";
    y[5] = "7";
    y[6] = "6";
    y[7] = "5";
    y[8] = "4";
    y[9] = "3";
    y[10] = "2";
    xx = osfzhm.substr(0, 6) + "19" + osfzhm.substr(osfzhm.length - 9);
    olen = 17;
    nsfzhm = "";
    fx = 0;
    for (i = 0; i < olen; i++) {
        ai = xx.substr(0, 1);
        xx = xx.substr(1);
        nsfzhm = nsfzhm + ai;
        fx = fx + ai * w[i];
    }

    fx = fx % 11;
    return nsfzhm + y[fx];
}

//验证身份证号
function checkCard(cardNum) {
//    var vcity = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古",
//        21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏",
//        33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南",
//        42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆",
//        51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃",
//        63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 "
//     } ;
    var isum = 0;
    var re = /^\d{17}(\d|X)$/i;
    var cardidstr = cardNum.value;
    if (cardidstr.length > 0 && cardidstr != null) {
        if (!re.test(cardidstr)) {
            alert("证件号不符合要求!");
            cardNum.value = "";
            cardNum.focus();
            return false;
        }

        //检查地址是否符合要求
//        if (vcity[parseInt(cardidstr.substr(0, 2))] == null) {
//            alert("身份证地址不符合要求!");
//            return false;
//        }

        //                //检查出生日期是否合法
        sbirthday = cardidstr.substr(6, 4) + "-" + Number(cardidstr.substr(10, 2)) + "-" + Number(cardidstr.substr(12, 2));
        var date = new Date(sbirthday.replace(/-/g, "/"));
        //alert("出生日期:"+sbirthday);
        //                if(sbirthday!=(date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate())){
        //                    //alert("出生日期非法!"+date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate() +cardidstr.substr(10,2));
        //                    alert("出生日期非法!"+date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate());
        //                    return false;
        //                }
        //检查验证码是否合法
        for (var i = 17; i >= 0; i--) {

            isum += (Math.pow(2, i) % 11) * parseInt(cardidstr.charAt(17 - i), 11);
        }
        //        if(isum%11!=1){
        //            alert("验证码非法!");
        //            return false;
        //        }

        //        alert('身份证地址:'+vcity[parseInt(cardidstr.substr(0,2))]+"\n"
        //             +"出生日期:"+sbirthday+"\n"
        //             +"性别:"+(cardidstr.substr(16,1)%2?"男":"女"));
    }
}

function noCodeIn() {
    return false;
}
//特殊字符ASCII码
//小数点：小键盘-110，大键盘-190
//减  号：小键盘-109，大键盘-189
//删  除： 8
//回  车：13
//  左  ：37
//  右  ：39

//验证数字(带小数点)
function onlyNum() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39||event.keyCode == 16) {
        //考虑小键盘上的数字键
        return true;
    }
    else {
        return false;
    }
}

//验证数字(带"-"和小数点)
function onlyNum1() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || event.keyCode == 189 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 109 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //考虑小键盘上的数字键
        return true;
    }
    else {
        return false;
    }
}

//验证数字(带"X")
function onlyNum2() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 88 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //考虑小键盘上的数字键
        return true;
    }
    else {
        return false;
    }
}

//验证纯数字
function onlyNum3() {
    //alert(event.keyCode);
    //if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //考虑小键盘上的数字键
        return true;
    }
    else {
        return false;
    }
}

//验证不能输入单引号
function onlyNum4() {
    alert(event.keyCode);
    if (event.keyCode == 222) {
        return false;
    }
    else {
        return true;
    }
}

//验证纯数字
function testisNum(object) {
    //var s =document.getElementById(object.id).value;         
    if (object.value != "") {
        if (isNaN(object.value)) {
            //alert("请输入数字！");
            object.value = "0";
            object.focus();
        }
    }
}

//验证数字(允许小数点)
function checkNum(obj) {
    if (obj.value != "") {
        var re = /^-?[1-9]*(\.\d*)?$|^-?d^(\.\d*)?$/;
        if (!re.test(obj.value)) {
            if (isNaN(obj.value)) {
                alert("请输入数字！");
                obj.value = "0";
                obj.focus();
                return false;
            }
        }
    }
}

//验证数字(允许带"-")
function checkNum1(obj) {
    if (obj.value != "") {
        var re = /^-?[1-9]*(\-\d*)?$|^-?d^(\-\d*)?$/;
        if (!re.test(obj.value)) {
            if (isNaN(obj.value)) {
                alert("请输入数字！");
                obj.value = "0";
                obj.focus();
                return false;
            }
        }
    }
}

//验证长日期型
function isdate(str_date, msg_xx) {
    var R_b = false;
    var str = str_date;
    var reg = /^(\d+)\-(\d{1,2})\-(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
    if (reg.test(obj1.value) == false) {
        R_b = false;
        alert(msg_xx);
        obj1.focus();
    }
    else {
        R_b = true;
    }
    return R_b;
}

//验证IP
function isIp(str_data, msg_xx) {
    if (str_data.value != "") {
        var R_b = false;
        var obj1 = str_data;
        var reg = /^((1??\d{1,2}|2[0-4]\d|25]0-5])\.){3}(1??\d{1,2}|2[0-4]\d|25]0-5])$/;
        if (reg.test(obj1.value) == false) {
            R_b = false;
            alert(msg_xx);
            obj1.focus();
        }
        else
            R_b = true;
        return R_b;
    }
}

//验证网址。域名
function testisNet(object) {
    if (object.value != "") {
        var re = /^([a-zA-Z0-9-]+\.)+(com|cn|net|biz|name|info|tv|org|cc)$/;
        if (!re.test(object.value)) {
            alert("网址(域名)填写不正确！");
            object.value = "";
            object.focus();
        }
    }
}

//验证短日期
function isshortdate(sender, msg_xx) {
    var R_b = false;
    var obj1 = sender;
    var reg = /^(\d+)\-(\d{1,2})\-(\d{1,2})$/;
    if (reg.test(obj1.value) == false) {
        R_b = false;
        alert(msg_xx);
        obj1.focus();
    }
    else {
        R_b = true;
    }
    return R_b;
}

//设置日期
function set_date(sender, name, width, height) {
    var obj1 = sender;
    var win_re_val = window.showModalDialog("../km_date.aspx?sel_date=" + obj1.value, window, "dialogWidth:300px; dialogHeight:200px;resizable:0; help:0; scroll:0; status:0");

    if (win_re_val == "" && obj1.value != "")
        obj1.value = obj1.value;
    else
        obj1.value = win_re_val;
}

//空格验证
function nz_trim(sender, msg_xx) {
    var R_b = false;
    var obj1 = sender;
    if (Trim(obj1.value) == "") {
        R_b = false;
        obj1.value = "";
        alert(msg_xx);
        obj1.focus();
    }
    else
        R_b = true;
    return R_b;
}

//验证E－Mail
function nz_mail(sender, msg_xx) {
    if (sender.value != "") {
        var re = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
        var obj1 = sender;
        if (re.test(obj1.value) == false) {
            alert(msg_xx);
            obj1.value = "";
            obj1.focus();
            return false;
        }
        else
            return true;
    }
}

//校验(国内)邮政编码 

function isPostalCode(object) {
    if (object.value != "") {
        var pattern = /^[0-9]{6}$/;
        if (!pattern.exec(object.value)) {
            window.alert('邮政编码填写不正确！');
            object.value = "";
            object.focus();
        }
    }
}

//校验手机号码：必须以数字开头，除数字外，可含有“-”
function isMobile(object) {
    var s = object.value;
    var reg0 = /^13\d{5,9}$/;
    var reg1 = /^15\d{5,9}$/;
    var reg2 = /^189\d{4,8}$/;
    var reg3 = /^0\d{10,11}$/;
    var reg4 = /^0\d{9,11}$/;
    var my = false;
    if (reg0.test(s)) my = true;
    if (reg1.test(s)) my = true;
    if (reg2.test(s)) my = true;
    if (reg3.test(s)) my = true;
    if (reg4.test(s)) my = true;
    if (s != "") {
        if (!my) {
            alert('手机号码填写不正确！');
            object.value = "";
            object.focus();
        }
    }
}

//验证钱
function nz_money(sender,msg_xx)
{
    if(sender.value!="")
    {
	    var re=/^([0-9]{1,}.[0-9]{2}$)/;
	    var obj1=sender;
	    if (re.test(obj1.value)==false)
	    {
		    alert(msg_xx);
		    obj1.value="";
		    obj1.focus();
		    return false;
	    }
	    else
		    return true;
    }
}

// 验证视力
function nz_sl_left(sender,msg_xx)
{
    if(sender.value!="")
    {
	    var re=/^([0-9]{1}.[0-9]{1}$)/;
	    var obj1=sender;
	    if (re.test(obj1.value)==false)
	    {
    		
		    alert(msg_xx);
		    obj1.value="";
		    obj1.focus();
		    return false;
	    }
	    else
		    return true;	
	}
}
//验证字符串长度
function nz_length(sender,msg_xx,str_len)
{
	var obj1=sender;
	if (obj1.value.length<str_len)
	{
		alert(msg_xx);
		obj1.value="";
		obj1.focus();
		return false;
	}
	else
		return true;
}

//验证两个值是否相等
function nz_xd(sender,sender1,msg_xx)
{
	var obj1=sender;
	var obj2=sender1;
	if (obj1.value!=obj2.value)
	{
		alert(msg_xx);
		obj2.value="";
		obj2.focus();
		return false;
	}
	else
		return true;
}

//录入限制，电话限制
function nz_tel()
{
	if ((event.keyCode>47 && event.keyCode<59) || event.keyCode==45)
	{
		return true;
	}
	else
		return false;
}

//录入限制，IP限制
function nz_ip()
{
	if ((event.keyCode>47 && event.keyCode<59) || event.keyCode==46)
	{
		return true;
	}
	else
		return false;
}

//删除询问
function del_data(msg_xx)
{
	if (window.confirm(msg_xx)==false)
		return false;
	else
		return true;
}

//录入限制，数据限制
function nz_num()
{
	if (event.keyCode>47 && event.keyCode<59)
		return true;
	else
		return false;
		
}
			
//打开一个模式窗口
function open_new1(name,width,height)
{
	var win_re_val=window.showModalDialog(name, window, "dialogWidth:"+width+"; dialogHeight:"+height+";resizable:0; help:0; scroll:0; status:0");
	return win_re_val;
}

//打开一个模式窗口
function open_new(name,width,height)
{
	var win_re_val=window.showModalDialog(name, window, "dialogWidth:"+width+"; dialogHeight:"+height+";resizable:0; help:0; scroll:0; status:0");
	if (win_re_val==true)
		return true;
	else
		return false;
}

//打开新的窗体
function OpenPage(Url, iWidth, iHeight) {
    window.returnValue = 'close';
    var iWidth = iWidth; //弹出窗口的宽度;
    var iHeight = iHeight; //弹出窗口的高度;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //获得窗口的垂直位置;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //获得窗口的水平位置;
    window.open(Url, "_blank", "toolbar=no,status=no,resizable=no,width=" + iWidth + ",height=" + iHeight + ",scrollbars=no,left=" + iLeft + ",top=" + iTop + "");

    //类似的窗口打开需要加入判断，
    //如果是打开不需要刷新父窗体的模式，则调用不刷新父窗体的弹出消息模式，
    //这里的这两句话应该注释掉，因为它会将 window.opener = null; 清空，导致不能刷新列表
    window.open('', '_self');
    window.opener = null;
}

