function Trim(str) {
    return str.replace(/^\s+|\s+$/g, '');
}

//�س�����ָ����ť
function btnsearch(obj) {
    if (event.keyCode == 13) {
        eval("document.forms.item(0)." + obj + ".click()");
        return false;
    }
    else
        return true;
}
    
//�س�����ָ����ť
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

function getCookie(objName) {//��ȡָ�����Ƶ�cookie��ֵ
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
    if (window.confirm("�Ƿ�ȷ��ɾ�������ݣ�") == false)
        return false;
}

//��֤��ѡ���Ƿ���ѡ�е���Ϣ
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

//ȫѡ
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
  
//��ѡ
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
  
//���֤15λת18λ
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

//��֤���֤��
function checkCard(cardNum) {
//    var vcity = { 11: "����", 12: "���", 13: "�ӱ�", 14: "ɽ��", 15: "���ɹ�",
//        21: "����", 22: "����", 23: "������", 31: "�Ϻ�", 32: "����",
//        33: "�㽭", 34: "����", 35: "����", 36: "����", 37: "ɽ��", 41: "����",
//        42: "����", 43: "����", 44: "�㶫", 45: "����", 46: "����", 50: "����",
//        51: "�Ĵ�", 52: "����", 53: "����", 54: "����", 61: "����", 62: "����",
//        63: "�ຣ", 64: "����", 65: "�½�", 71: "̨��", 81: "���", 82: "����", 91: "���� "
//     } ;
    var isum = 0;
    var re = /^\d{17}(\d|X)$/i;
    var cardidstr = cardNum.value;
    if (cardidstr.length > 0 && cardidstr != null) {
        if (!re.test(cardidstr)) {
            alert("֤���Ų�����Ҫ��!");
            cardNum.value = "";
            cardNum.focus();
            return false;
        }

        //����ַ�Ƿ����Ҫ��
//        if (vcity[parseInt(cardidstr.substr(0, 2))] == null) {
//            alert("���֤��ַ������Ҫ��!");
//            return false;
//        }

        //                //�����������Ƿ�Ϸ�
        sbirthday = cardidstr.substr(6, 4) + "-" + Number(cardidstr.substr(10, 2)) + "-" + Number(cardidstr.substr(12, 2));
        var date = new Date(sbirthday.replace(/-/g, "/"));
        //alert("��������:"+sbirthday);
        //                if(sbirthday!=(date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate())){
        //                    //alert("�������ڷǷ�!"+date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate() +cardidstr.substr(10,2));
        //                    alert("�������ڷǷ�!"+date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate());
        //                    return false;
        //                }
        //�����֤���Ƿ�Ϸ�
        for (var i = 17; i >= 0; i--) {

            isum += (Math.pow(2, i) % 11) * parseInt(cardidstr.charAt(17 - i), 11);
        }
        //        if(isum%11!=1){
        //            alert("��֤��Ƿ�!");
        //            return false;
        //        }

        //        alert('���֤��ַ:'+vcity[parseInt(cardidstr.substr(0,2))]+"\n"
        //             +"��������:"+sbirthday+"\n"
        //             +"�Ա�:"+(cardidstr.substr(16,1)%2?"��":"Ů"));
    }
}

function noCodeIn() {
    return false;
}
//�����ַ�ASCII��
//С���㣺С����-110�������-190
//��  �ţ�С����-109�������-189
//ɾ  ���� 8
//��  ����13
//  ��  ��37
//  ��  ��39

//��֤����(��С����)
function onlyNum() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39||event.keyCode == 16) {
        //����С�����ϵ����ּ�
        return true;
    }
    else {
        return false;
    }
}

//��֤����(��"-"��С����)
function onlyNum1() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || event.keyCode == 189 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 109 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //����С�����ϵ����ּ�
        return true;
    }
    else {
        return false;
    }
}

//��֤����(��"X")
function onlyNum2() {
    //alert(event.keyCode);
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 88 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //����С�����ϵ����ּ�
        return true;
    }
    else {
        return false;
    }
}

//��֤������
function onlyNum3() {
    //alert(event.keyCode);
    //if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 190 || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 37 || event.keyCode == 39) {
        //����С�����ϵ����ּ�
        return true;
    }
    else {
        return false;
    }
}

//��֤�������뵥����
function onlyNum4() {
    alert(event.keyCode);
    if (event.keyCode == 222) {
        return false;
    }
    else {
        return true;
    }
}

//��֤������
function testisNum(object) {
    //var s =document.getElementById(object.id).value;         
    if (object.value != "") {
        if (isNaN(object.value)) {
            //alert("���������֣�");
            object.value = "0";
            object.focus();
        }
    }
}

//��֤����(����С����)
function checkNum(obj) {
    if (obj.value != "") {
        var re = /^-?[1-9]*(\.\d*)?$|^-?d^(\.\d*)?$/;
        if (!re.test(obj.value)) {
            if (isNaN(obj.value)) {
                alert("���������֣�");
                obj.value = "0";
                obj.focus();
                return false;
            }
        }
    }
}

//��֤����(�����"-")
function checkNum1(obj) {
    if (obj.value != "") {
        var re = /^-?[1-9]*(\-\d*)?$|^-?d^(\-\d*)?$/;
        if (!re.test(obj.value)) {
            if (isNaN(obj.value)) {
                alert("���������֣�");
                obj.value = "0";
                obj.focus();
                return false;
            }
        }
    }
}

//��֤��������
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

//��֤IP
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

//��֤��ַ������
function testisNet(object) {
    if (object.value != "") {
        var re = /^([a-zA-Z0-9-]+\.)+(com|cn|net|biz|name|info|tv|org|cc)$/;
        if (!re.test(object.value)) {
            alert("��ַ(����)��д����ȷ��");
            object.value = "";
            object.focus();
        }
    }
}

//��֤������
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

//��������
function set_date(sender, name, width, height) {
    var obj1 = sender;
    var win_re_val = window.showModalDialog("../km_date.aspx?sel_date=" + obj1.value, window, "dialogWidth:300px; dialogHeight:200px;resizable:0; help:0; scroll:0; status:0");

    if (win_re_val == "" && obj1.value != "")
        obj1.value = obj1.value;
    else
        obj1.value = win_re_val;
}

//�ո���֤
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

//��֤E��Mail
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

//У��(����)�������� 

function isPostalCode(object) {
    if (object.value != "") {
        var pattern = /^[0-9]{6}$/;
        if (!pattern.exec(object.value)) {
            window.alert('����������д����ȷ��');
            object.value = "";
            object.focus();
        }
    }
}

//У���ֻ����룺���������ֿ�ͷ���������⣬�ɺ��С�-��
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
            alert('�ֻ�������д����ȷ��');
            object.value = "";
            object.focus();
        }
    }
}

//��֤Ǯ
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

// ��֤����
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
//��֤�ַ�������
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

//��֤����ֵ�Ƿ����
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

//¼�����ƣ��绰����
function nz_tel()
{
	if ((event.keyCode>47 && event.keyCode<59) || event.keyCode==45)
	{
		return true;
	}
	else
		return false;
}

//¼�����ƣ�IP����
function nz_ip()
{
	if ((event.keyCode>47 && event.keyCode<59) || event.keyCode==46)
	{
		return true;
	}
	else
		return false;
}

//ɾ��ѯ��
function del_data(msg_xx)
{
	if (window.confirm(msg_xx)==false)
		return false;
	else
		return true;
}

//¼�����ƣ���������
function nz_num()
{
	if (event.keyCode>47 && event.keyCode<59)
		return true;
	else
		return false;
		
}
			
//��һ��ģʽ����
function open_new1(name,width,height)
{
	var win_re_val=window.showModalDialog(name, window, "dialogWidth:"+width+"; dialogHeight:"+height+";resizable:0; help:0; scroll:0; status:0");
	return win_re_val;
}

//��һ��ģʽ����
function open_new(name,width,height)
{
	var win_re_val=window.showModalDialog(name, window, "dialogWidth:"+width+"; dialogHeight:"+height+";resizable:0; help:0; scroll:0; status:0");
	if (win_re_val==true)
		return true;
	else
		return false;
}

//���µĴ���
function OpenPage(Url, iWidth, iHeight) {
    window.returnValue = 'close';
    var iWidth = iWidth; //�������ڵĿ��;
    var iHeight = iHeight; //�������ڵĸ߶�;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //��ô��ڵĴ�ֱλ��;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //��ô��ڵ�ˮƽλ��;
    window.open(Url, "_blank", "toolbar=no,status=no,resizable=no,width=" + iWidth + ",height=" + iHeight + ",scrollbars=no,left=" + iLeft + ",top=" + iTop + "");

    //���ƵĴ��ڴ���Ҫ�����жϣ�
    //����Ǵ򿪲���Ҫˢ�¸������ģʽ������ò�ˢ�¸�����ĵ�����Ϣģʽ��
    //����������仰Ӧ��ע�͵�����Ϊ���Ὣ window.opener = null; ��գ����²���ˢ���б�
    window.open('', '_self');
    window.opener = null;
}

