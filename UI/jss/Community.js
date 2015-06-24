//$Id: Community.js,v 1.112 2004/07/29 11:15:25 wantm Exp $
var comm = null;
var commpage = null;
var periodVal="";
var isException = false;
//--var confirmResult = false;
var operationID = null;

function Community(){
	document.body.insertAdjacentHTML("afterBegin","<span id=\"SPANFUNC\"></span>");
	var span=document.all("SPANFUNC");
	span.style.display = "none";
	span.innerHTML = "<iframe name=\"funcframe\" src=\"\"></iframe>";
	this.busy = false;
	this.justpage = false;
	this.doRequest = doRequest;
	this.doRequestPage = doRequestPage;
}

function requestData(functionID, componame, paramNames, paramValues,url){
	if (!url)
	  url = "/applus/Proxy";
	var str = "function=" + functionID + "&componame=" + componame;
	if (paramNames != null){
	  str += "&" + encodeParamArray(paramNames, paramValues);
	}

	var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
	xmlhttp.Open("POST",url,false);
	xmlhttp.setRequestHeader("Content-Length",str.length);
	xmlhttp.setRequestHeader("CONTENT-TYPE","application/x-www-form-urlencoded");
	xmlhttp.send(str);
	//--dump(str + "\n" + requestData.caller);
	var xmldom = new ActiveXObject("Microsoft.XMLDOM");
	xmldom.loadXML(xmlhttp.responseText);
	if (xmldom.documentElement && xmldom.documentElement.firstChild)
		return xmldom.documentElement.firstChild;
	return null;
}

/*--
function jspRequestData(url,paramNames,paramValues) {
	var str = "";
	if (paramNames != null){
	  str += encodeParamArray(paramNames, paramValues);
	}

	var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
	xmlhttp.Open("POST",url,false);
	xmlhttp.setRequestHeader("Content-Length",str.length);
	xmlhttp.setRequestHeader("CONTENT-TYPE","application/x-www-form-urlencoded");
	xmlhttp.send(str);
	var xmldom = new ActiveXObject("Microsoft.XMLDOM");
	return xmldom.loadXML(xmlhttp.responseText);
}
*/

/**
 * ���ɱ������ַ�������Ϊ URL �Ĳ�����
 * @return �Ϸ��� URL ��ѯ�ַ���
 */
function encodeParamArray(paramNames, paramValues) {
  var s = "";
  for(var i=0,j=paramNames.length;i<j; i++) {
    var value=paramValues[i];
    if ("string" == typeof value) {
      value = escapeSpecial(value);
    }
    if (0 != i){
      s += "&";
    }
    s += paramNames[i] + "=" + value;
  }
  
  s = URLEncoding(s);
  return s;
}

/**
 * ���ɱ������ַ�������Ϊ URL �Ĳ�����
 * @return �Ϸ��� URL ��ѯ�ַ���
 */
function encodeParamObject(paramObject) {
  var s = "";
  var name;
  var i = 0;
  for (name in paramObject) {
    var value = paramObject[name];
    var vtype = typeof value;
    // ����δ���塢�����Ϳ�ֵ
    if ("undefined" != vtype && "function" != vtype && null != value) {
      if ("string" == vtype) {
        value = escapeSpecial(value);
      }
      if (0 != i){
        s += "&";
      }
      s += name + "=" + value;
      i++;
    }
  }
  s = URLEncoding(s);
  return s;
}

/**
 * ���ɱ������ַ�������Ϊ URL �Ĳ�����
 * ��������������Ӧ����һ��ż������������Ϊ����1��ֵ1������2��ֵ2���ȵ�
 * @return �Ϸ��� URL ��ѯ�ַ���
 */
function encodeParams(name1, value1, name2, value2) {
  var names = new Array();
  var values = new Array();
  var n = 0;
  var args = encodeParams.arguments;
  for (var i = 0; i < args.length; i += 2, n++) {
    names[n] = args[i];
    if (i + 1 < args.length)
      values[n] = args[i + 1];
    else
      values[n] = "";
  }
  return encodeParamArray(names, values);
}

/**
 * ���ض����ַ�ת�壬���ڹ��� URL �Ĳ�����
 * �����ַ� ";", "/", "?", ":", "@", "=", "&" �� 7 ��
 * ����ȫ���ַ� "<", ">", "\"", "#", "%"
 * �����������ַ��������ַ�ʹ�� URLEncodeing (�� formenctype.vbs ��) ת��
 * �ο�: rfc1738
 * �ο�: http://www.blooberry.com/indexdot/html/topics/urlencoding.htm
 */
function escapeSpecial(value) {
  value = value.replace(/%/g, "%25"); // ��������
  // 7 ��������
  value = value.replace(/&/g, "%26");
  value = value.replace(/\//g, "%2F");
  value = value.replace(/:/g, "%3A");
  value = value.replace(/;/g, "%3B");
  value = value.replace(/=/g, "%3D");
  value = value.replace(/\?/g, "%3F");
  value = value.replace(/@/g, "%40");
  // ����ȫ���ַ�
  value = value.replace(/"/g, "%22");
  value = value.replace(/#/g, "%23");
  value = value.replace(/</g, "%3C");
  value = value.replace(/>/g, "%3E");
  // ����ӺźͿո�
  value = value.replace(/\+/g, "%2B");
  value = value.replace(/ /g, "+"); // ������ + ֮����
  return value;
}

function doRequest(functionID,componame,paramNames,paramValues,callback) {
	var doc = window.frames["funcframe"].document;
	form = doc.createElement("form");
	form.setAttribute("name","funcform");
	form.setAttribute("method","post");
	form.setAttribute("target","");
	form.setAttribute("action","/applus/Proxy");
	doc.appendChild(form);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","function");
	input.setAttribute("value",functionID);
	form.appendChild(input);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","componame");
	input.setAttribute("value",componame);
	form.appendChild(input);
  /*-----------------------------------------------------------------*/
  /*put operation info to be used in LogFilter class (mod by xjh 3.12)*/
  if (operationID){
    input = doc.createElement("input");
    input.setAttribute("type","hidden");
    input.setAttribute("name","operation");
    input.setAttribute("value",operationID);
    form.appendChild(input);
    operationID = null;
  }
  /*-----------------------------------------------------------------*/
  if (paramNames != null){
		for(var i=0,j=paramNames.length;i<j;) {
			input = doc.createElement("input");
			input.setAttribute("type","hidden");
			input.setAttribute("name",paramNames[i]);
			input.setAttribute("value",paramValues[i]);
			form.appendChild(input);
			i=i+1;
		}
	}

  if(document.getElementById("digest")){
    var digest = document.getElementById("digest").getAttribute("value");
    input = doc.createElement("input");
    input.setAttribute("type","hidden");
    input.setAttribute("name","digest");
    input.setAttribute("value",digest);
    form.appendChild(input);

    var pageName = document.getElementById("meta").getAttribute("pageName");
    input = doc.createElement("input");
    input.setAttribute("type","hidden");
    input.setAttribute("name","pageName");
    input.setAttribute("value",pageName);
    form.appendChild(input);
  }

	if (callback == null) {
	 alert("û�лص�����");
	} else {
		input = doc.createElement("input");
		input.setAttribute("type","hidden");
		input.setAttribute("name","callback");
		input.setAttribute("value",callback);
		form.appendChild(input);
	}
	this.justpage = false;
	//--dump(form.innerHTML + "\n" + doRequest.caller);
	form.submit();
}

function doRequestPage(functionID,componame,paramNames,paramValues,target) {
	vtarget = "_parent";
	if (target == "" && functionID == "fprint")
		target = componame + "_WIN";
	if (target != null)
		vtarget = target;
	var doc = window.frames["funcframe"].document;
	form = doc.createElement("form");
	form.setAttribute("name","funcform");
	form.setAttribute("method","post");
	form.setAttribute("target",vtarget);
	form.setAttribute("action","Proxy");
	doc.appendChild(form);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","function");
	input.setAttribute("value",functionID);
	form.appendChild(input);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","componame");
	input.setAttribute("value",componame);
	form.appendChild(input);
	if (paramNames != null)
		for(var i=0,j=paramNames.length;i<j;) {
			input = doc.createElement("input");
			input.setAttribute("type","hidden");
			input.setAttribute("name",paramNames[i]);
			input.setAttribute("value",paramValues[i]);
			form.appendChild(input);
			i=i+1;
		}
	this.justpage = true;
	form.submit();
}

function getCommunity() {
	if (comm == null)
		comm = new Community();
	if (comm.justpage == true) {
		return comm;
	}else if (comm.busy == true ) {
		alert("ͨ����æ�����Ժ����ԡ�");
		return null;
	} else {
		return comm;
	}
}

//������ݿ����ͣ�wtm,����ֵΪ0��Oracle������ֵ��1��SQLserver
function getDBType(){
      var names = new Array();
      var values = new Array();
      names[0] = "dbType";
      values[0] = "test";
      var result = requestData("getDBType", "all", names, values);
      return result.xml;     
}

function PageCommunity(){
	var span=document.all("SPANPAGE");
	if (!span){
		document.body.insertAdjacentHTML("afterBegin","<span id=\"SPANPAGE\"></span>");
		span=document.all("SPANPAGE");
		span.style.display = "none";
	}
	span.innerHTML = "<iframe name=\"pageframe\" src=\"\"></iframe>";
	this.busy = false;
	this.justpage = false;
	this.doRequestPage = doRequestPage2;
}

function doRequestPage2(functionID,componame,paramNames,paramValues,target,url) {
	vtarget = "_parent";
	if (target == "" && functionID == "fprint")
		target = componame + "_WIN";
	if (target != null)
		vtarget = target;
	var doc = window.frames["pageframe"].document;
	form = doc.createElement("form");
	form.setAttribute("name","funcform");
	form.setAttribute("method","post");
	form.setAttribute("target",vtarget);
	if (!url){
		form.setAttribute("action","/applus/Proxy");
	}else{
		form.setAttribute("action",url);
	}
	doc.appendChild(form);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","function");
	input.setAttribute("value",functionID);
	form.appendChild(input);
	input = doc.createElement("input");
	input.setAttribute("type","hidden");
	input.setAttribute("name","componame");
	input.setAttribute("value",componame);
	form.appendChild(input);
	if (paramNames != null)
		for(var i=0,j=paramNames.length;i<j;) {
			input = doc.createElement("input");
			input.setAttribute("type","hidden");
			input.setAttribute("name",paramNames[i]);
			input.setAttribute("value",paramValues[i]);
			form.appendChild(input);
			i=i+1;
		}
	form.submit();
	document.all("SPANPAGE").innerHTML = "";
}

function getPageCommunity() {
	var commpage = new PageCommunity();
	return commpage;
}

function free() {
	if (comm != null)
		comm.busy = false;
}

function getDBData(ruleID,names,values,callback){
	var param = ""
	if(names != null){
		param = AS_arrayToEntityString(names, values);
		/*
		param = "<entity>";
		if(names.length > 0){
			for (var i=0,j=names.length; i<j; i++){
				param += "<field name=\"" + names[i] + "\" value=\"" + values[i] + "\"/>";
			}
		}
		param += "</entity>";
		*/
	}
	var pNames = new Array();
	var pValues = new Array();
	pNames[0] = "ruleID";
	pValues[0] = ruleID;
	pNames[1] = "param";
	pValues[1] = param;
	var com = getCommunity();
	if (com != null)
		doRequest("getDBData","all",pNames,pValues,callback);
}

function qryData(ruleID, names, values){
	var param = ""
	if(names != null){
		param = AS_arrayToEntityString(names, values);
		/*
		param = "<entity>";
		if(names.length > 0){
			for (var i=0,j=names.length; i<j; i++){
				param += "<field name=\"" + names[i] + "\" value=\"" + values[i] + "\"/>";
			}
		}
		param += "</entity>";
		*/
	}
	var pNames = new Array();
	var pValues = new Array();
	pNames[0] = "ruleID";
	pValues[0] = ruleID;
	pNames[1] = "param";
	pValues[1] = param;
	var result = requestData("getDBData", "all", pNames, pValues);
	if (result && "undefined" != result.text)
		return result.text;
	return null;
}

function setSv(entity){
	var names = new Array();
	var values = new Array();
	names[0] = "entity";
	values[0] = entity;
	var com = getCommunity();
	if (com != null){
		com.doRequest("setSv", "all", names, values, "setSv_R");
	}
}

function setSv_R(result){
	if (result.getAttribute("success") == "false"){
		alert(result.innerHTML);
	}else{
		/*ֻ�����õ�ǰҵ�����ڲ����ؿ�ֵ*/
		if(result.innerHTML.length > 0){
			/*
			var win1 = result.innerHTML;
			var syear = win1.substr(0, 4);
			var smonth = win1.substr(5, 2);
			var sday = win1.substr(8, 2);
			���������������������õ������ȡ�����ڼ�
			*/
			setPeriod(win1,"getPer");
		}
	}
}

function getPer(perVal){
	periodVal = perVal.innerHTML;
	if(periodVal.length > 0){
		setSv("svFiscal", periodVal);
	}
}

function trim(str){  //ȥ���ַ�����β�Ŀո�
	return ltrim(rtrim(str));
}

function ltrim(str){
	var index = -1;
	for (var i=0,j=str.length; i<j; i++){
		if (str.charAt(i) != " "){
			index = i;
			break;
		}
	}
	if (index == -1){
		return "";
	}else{
		return str.substr(index);
	}
}

function rtrim(str){
	var index = -1;
	for (var i=str.length-1 ,j=0; i>=j; i--){
		if (str.charAt(i) != " "){
			index = i;
			break;
		}
	}
	if(index == -1)
		return str;
	else
		return str.substring(0, index + 1);
}

function browseFile(){
	var name = event.srcElement.getAttribute("name");
	var tableName = event.srcElement.getAttribute("tablename");
	var mainTable = getMainTableName();
	var fieldEle = document.getElementById(tableName + "_" + name + "ID");
  if(fieldEle.getAttribute("alwaysreadonly") == "true" ||
     document.getElementById("status").getAttribute("value") == "edit") return;
	var fileID = null;
	if(tableName == mainTable){
		fileID = getField(name + "_BLOBID");
	}else{
		var row = getCurrentRow(tableName);
		fileID = getRowField(row, name + "_BLOBID");
	}
	var win_edit = showModalDialog("browseFile.htm", fileID,
																 "dialogHeight:100px;dialogWidth:400px;"
																 + "resizable:no;help:no;status:no");
	if(win_edit){
		var pathName = win_edit[0];
		var index = pathName.lastIndexOf("\\");
		var doc = document.getElementById(tableName + "_" + name + "ID");
		doc.setAttribute("value", pathName.substr(index + 1));
		if(tableName == mainTable){
			var doc1 = document.getElementById(tableName + "_" + name + "_BLOBIDID");
			doc1.setAttribute("value", win_edit[1]);
			changed = true;
		}else{
			var row = getCurrentRow(tableName);
			setRowField(row, name + "_BLOBID", win_edit[1]);
      changed = true;
		}
    if(eval("typeof after_browse_" + tableName + "_" + name + " == \"function\""))
      eval("after_browse_" + tableName + "_" + name + "()");
	}
}

function readFile(){
	var name = event.srcElement.getAttribute("name");
	var tableName = event.srcElement.getAttribute("tablename");
	var fieldEle = document.getElementById(tableName + "_" + name + "ID");
	var value = fieldEle.getAttribute("value");
	var mainTable = getMainTableName();
	var fileId = "";
	if(mainTable == tableName){
		var doc = document.getElementById(tableName + "_" + name + "_BLOBIDID");
		fileId = doc.value;
		if (trim(fileId) == "") {
			alert("�ļ���" + value + "�������ݿ��в����ڣ�");
			return;
		}
	}else{
		var row = getCurrentRow(tableName);
		fileId = getRowField(row, name + "_BLOBID");
	}
	var win_edit = open("Proxy?function=readfile&fileid=" + fileId, 0,
											"menubar=no,scrollbars=no,status=no,toolbar=no,"
											+ "resizable=yes,titlebar=yes,scrollbars=yes,"
											+ "height=" + (screen.availHeight - 30) + ",width="
											+ (screen.availWidth - 10) + ",top=0,left=0");
}

/**********************************************************
 * ������Ԥ���ֶ�����
 * ʱ�䣺2003-3-26
 *********************************************************/
function doPreCol(compoId,dataItemType,vsEnable,vsNameEnable){
	window.open("PreCol?COMPOID=" + compoId + "&DATAITEMTYPE="
								+ dataItemType + "&VSENABLE=" + vsEnable
								+ "&VSNAMEENABLE=" + vsNameEnable, "",
								"width=400,height=240,menubar=no,scrollbars=no,status=no,"
								+ "toolbar=no,resizable=yes,titlebar=yes,scrollbars=yes");
}

function capitalize(data){
	var result = "";///ת���Ľ��

	///�����ж��Ƿ��ǺϷ��������ַ���
	data = parseFloat(data);
	if(isNaN(data))
	 return null;

	///ת��Ϊ�ַ���
	var tmpValue = new String(data);
	data = tmpValue.toString();

	///����������Ǹ�,-1 ��,0 ��
	var sign = data.indexOf("-");
	///alert("sign:"+sign);
	data = data.replace("-","");

	///���С�����λ��+1
	var  decimalPosition = data.indexOf(".");
	if(decimalPosition == -1){
		decimalPosition = data.length;
		data += "00";
	}else
	{
		data = data.replace(".","");
  	data += "00";
	}

	if(data.charAt(0) == '0')
		decimalPosition = 0;

	var  pos = 0;
	var  posDigit = 0;///��ǰ���ֵ�λ�ã�

	///data��ȫ����;
	if(sign == 0)
	{
		result += "��";
	}
	if(decimalPosition > 0)
	{
		for(i = decimalPosition; i > -2; i--)
		{
			var money = data.charAt(posDigit);
			posDigit++;
			switch(money)
			{
			case '0':
				if((money == '0') && ((i==-1)||(i == 1)||(i == 5)||(i == 9)))
					break;
				if((money == '0') && (data.charAt(posDigit) == '0'))
					break;
				result += "��";
				break;
			case '1':
				result += "Ҽ";
				break;
			case '2':
				result += "��";
				break;
			case '3':
				result += "��";
				break;
			case '4':
				result += "��";
				break;
			case '5':
				result += "��";
				break;
			case '6':
				result += "½";
				break;
			case '7':
				result += "��";
				break;
			case '8':
				result += "��";
				break;
			case '9':
				result += "��";
				break;
			}
			if((money == '0') && !((i == 1)||(i == 5)||(i == 9)))
				continue;
			switch(i)
			{
			case -1:
				result += "��";
				break;
			case 0:
				result += "��";
				break;
			case 1:
				result += "Բ";
				break;
			case 2:
				result += "ʰ";
				break;
			case 3:
				result += "��";
				break;
			case 4:
				result += "Ǫ";
				break;
			case 5:
				result += "��";
				break;
			case 6:
				result += "ʰ";
				break;
			case 7:
				result += "��";
				break;
			case 8:
				result += "Ǫ";
				break;
			case 9:
				result += "��";
				break;
			case 10:
				result += "ʰ";
				break;
			case 11:
				result += "��";
				break;
			case 12:
				result += "Ǫ";
				break;
			case 13:
				result += "��";
				break;
			}
			if((i == 1)&&(data.charAt(posDigit) == '0')&&(data.charAt(posDigit+1) == '0'))
			{
				result += "��";
				break;
			}
			if((i == 0)&&(data.charAt(posDigit) == '0'))
			{
				result += "��";
				break;
			}
		}
	}else{
		if((data.charAt(1) == '0')&&(data.charAt(2) == '0'))
		{
			result += "���";
			return result;
		}
		for(i = 1;i < 3; i++)
		{
			money = data.charAt(i);
			if(money == '0')
				continue;
			switch(money)
			{
			case '0':
				result += "��";
				break;
			case '1':
				result += "Ҽ";
				break;
			case '2':
				result += "��";
				break;
			case '3':
				result += "��";
				break;
			case '4':
				result += "��";
				break;
			case '5':
				result += "��";
				break;
			case '6':
				result += "½";
				break;
			case '7':
				result += "��";
				break;
			case '8':
				result += "��";
				break;
			case '9':
				result += "��";
				break;
			}
			switch(i)
			{
			case 2:
				result += "��";
				break;
			case 1:
				result += "��";
				break;
			}
		}
	}
	return result;
}

function showMessage(message){
	window.info = message;
	var formula = showModalDialog("/applus/message?",window,
									'dialogHeight:500px;dialogWidth:600px;center:yes;help:no');
}


//���ַ����е�˫����(")�任Ϊ&quot;
//���ַ����еĴ��ں�(>)�任Ϊ&gt;
//���ַ����е�С�ں�(<)�任Ϊ&lt;
function transString(str){
	return packSpecialChar(str);
	/*-- 2004-4-30 12:13 HH comment out
	str = str.replace("\"","&quot;");
	str = str.replace("<","&lt;");
	return str;
	*/
}

function transChar(str,originChar,replaceChar){
	return str.replace(originChar,replaceChar);
}

//���ַ����еĵ�����(')�任Ϊ����������('')
//���ַ����е�&gt;�任Ϊ���ں�(>)
function doubleApos(str){
	if (null == str)
		return null;
	str = str.replace(/&nbsp;/g," "); // TODO: 2004-6-8 13:54 ɾ�����У����ô��� innerText
	str = str.replace(/\'/g,"''");
	//-- str = str.replace(/&gt;/g,">"); // HH 2004-6-8 13:53 ɾ������
	return str;
}

/**
 * �����ַ����е������ַ�: & < > "
 * ��ע�⡿���Ƚ����е� &nbsp; ��Ϊ�ո��Դ����� innerHTML �õ����ַ����е�
 * �����ַ���û�а취���� &nbsp; �� &amp;nbsp; Ҳ����
 */
function packSpecialChar(str){
	if ((str == null) || (str == ""))
		return "";
	str = str.replace(/&nbsp;/g," ");
	str = str.replace(/&/g,"&amp;"); // 2004-4-29 17:43 HH add this
	str = str.replace(/</g,"&lt;");
	str = str.replace(/>/g,"&gt;");
	str = str.replace(/\"/g,"&quot;");
	return str;
}

/** ���� \r\n �� \n���滻Ϊ &#10; */
function escapeLineBreak(str){
	if ((str == null) || (str == ""))
		return "";
	str = str.replace(/\r\n/g,"&#10;");
	str = str.replace(/\r/g,"&#10;");
	str = str.replace(/\n/g,"&#10;");
	return str;
}

function setBtnVisible(func,visible){
	var funcbtn = document.getElementById(func + "ID");
  if (!funcbtn) return;
  var funcparentTd=funcbtn.parentNode;
  if (!funcparentTd) return;
  if  (funcparentTd.id==func + "_menuTd"){
     funcparentTd.parentNode.style.display = visible?"":"none";
     return;
  }
	if(funcbtn)
		funcbtn.style.display = visible?"":"none";
	var funcbtnLeftImg = document.getElementById(func + "_leftImg");
	if(funcbtnLeftImg)
		funcbtnLeftImg.style.display = visible?"":"none";
	var funcbtnRightImg = document.getElementById(func + "_rightImg");
	if(funcbtnRightImg)
		funcbtnRightImg.style.display = visible?"":"none";
}

function parseInteger(str){
	if((str == null) || (str.length == 0))
	  return 0;
	return parseInt(str, 10);
	/*
	var result = str;
	var index = result.indexOf("0");
	while((index == 0) && (result.length) > 1){
		result = result.substr(1);
		index = result.indexOf("0");
	}
	return parseInt(result);
	*/
}

function copyNode(parentNode,node){
	var element = document.createElement(node.tagName);
	var attrs = node.attributes;
	for (var i=0,j=attrs.length; i<j; i++){
		var attrName = attrs[i].name;
		var attrValue = attrs[i].value;
		element.setAttribute(attrs[i].name,attrs[i].value);
	}
	parentNode.appendChild(element);
	for (var i=0,j=node.childNodes.length; i<j; i++){
		copyNode(element,node.childNodes[i]);
	}
}
/*
���ñ���ֶο��
name:ҳ�������߲�����
tableName:����
fieldName���ֶ���
width:���
*/
function setFieldWidth(name,tableName,fieldName,width){
	var temp = tableName + ":" + fieldName;
	//setCookies(temp,width);
	try{
		var fso = new ActiveXObject("Scripting.FileSystemObject");
		var file1 = null;
		if (!fso.FileExists("c:\\cookies\\" + name + tableName + ".txt")){
  			file1 = createFile(name + tableName);
			file1.Write(temp + ":" + width);
		}
		else{
			file1 = fso.OpenTextFile("c:\\cookies\\" + name + tableName + ".txt",1);
			var before = file1.ReadAll();
			file1.Close();
			var index = before.indexOf(temp);
			if (index == -1){
				before += "&" + temp + ":" + width;
				file1 = fso.OpenTextFile("c:\\cookies\\" + name + tableName + ".txt",2);
				file1.Write(before);
			}
			else{
				var end = before.indexOf("&",index);
				var temp2;
        			if(end != -1)
	        			temp2 = before.substring(index,end);
        			else
					temp2 = before.substring(index);
				before = before.replace(temp2,temp + ":" + width);
				file1 = fso.OpenTextFile("c:\\cookies\\" + name + tableName + ".txt",2);
				file1.Write(before);
			}
		}
	}
	catch(e){
		isException = true;
		securityAlert();
	}
	finally{
		if(file1)
			file1.Close();
	}
}

function securityAlert() {
	alert("�˲���Ҫ��д����Ӳ���ļ��Լ�ס����ȣ�����Ҫ��ס����ȣ���Ҫ��IE��������á�\n"+
		"����취��: " + "����->Internetѡ��->��ȫ->����Intranet->�Զ��弶��"+
		"����û�б��Ϊ��ȫ��ActiveX�ؼ����г�ʼ���ͽű��������óɡ����á���");
}

function isFileExists(fileName){
	try{
		var fso = new ActiveXObject("Scripting.FileSystemObject");
		return fso.FileExists(fileName);
	}catch(e){
		securityAlert();
	}
}

/*
ȡ�ñ���ֶο��
name:ҳ�������߲�����
tableName:����
fieldName���ֶ���
����ֵ���ֶο��
*/
function getFieldWidth(name,tableName,fieldName){
	try{
	var fso = new ActiveXObject("Scripting.FileSystemObject");
	var result;
	var file;
	var temp = tableName + ":" + fieldName;
	if (!fso.FileExists("c:\\cookies\\" + name + tableName + ".txt")){
		return 0;
	}else{
		file = fso.OpenTextFile("c:\\cookies\\" + name + tableName + ".txt",1);
		var before = file.ReadAll();
		var index = before.indexOf(temp);
		if (index == -1){
			return 0;
		}
		else{
			var end = before.indexOf("&",index);
			var temp2;
      			if (end != -1)
				temp2 = before.substring(index,end);
			else
				temp2 = before.substring(index);
			var tempLen = temp.length;
			result = temp2.substring(tempLen +1);
			result = parseInt(result);
			return result;
		}
	}
	}
	catch(e){
		isException = true;
		securityAlert();
	}
	finally{
		if(file)
			file.Close();
  	}
}
/*
���ñ���ͷ����Ŀ��
tableName������
fieldName:�ֶ���
width:���ֵ
*/
function setFieldCaptionWidth(tableName,fieldName,width1){
	var fieldID = document.getElementById(tableName + "_" + fieldName + "TableID");
	fieldID.style.width = width1- 2;
	var cel = document.getElementById(tableName + "_" + fieldName + "Cell");
	cel.style.width = width1;
}
/*
�˺������������ļ�.
fielName:�ļ���
*/
function createFile(fileName){
	var fso = new ActiveXObject("Scripting.FileSystemObject");
	var file1 = null;
	if (!fso.FolderExists("c:\\cookies")){
		fso.CreateFolder("c:\\cookies");
	}
	if (!fso.FileExists("c:\\cookies\\" + fileName + ".txt"))
  		file1 = fso.CreateTextFile("c:\\cookies\\" + fileName + ".txt",true);
  	return file1;
}
//��������ǧ��λ��ʾ(�Ӷ���)
function kiloStyle(s1){
		var result = "";
		if ((s1 == null) || (s1 == ""))
			return result;
		var s = "";
		var s2 = "";
		s1 = "" + s1;
		var isMinus = false;
		if(s1.charAt(0) == "-"){
			s1 = s1.substring(1);
			isMinus = true;
		}
		var index = s1.indexOf(".");
		if (index != -1){
			s = s1.substring(0,index);
			s2 = s1.substring(index);
		}
		else{
			s = s1;
			s2 = "";
		}
    //ǧ��λ��ʽ�����ַ����е�һ������ǰ�ַ�����.
    var head = s.length%3;
    //��Ҫ���붺�ŵĸ���
    var numOfComma = Math.floor(s.length/3);
    //alert("xxxxxxxxxx" + head + ":" + numOfComma);
    if ((head != 0) && (numOfComma != 0)){
      result += s.substring(0, head);
      result += ",";
      for (var i = 0; i < numOfComma; i++) {
        result += s.substring(i*3+head,(i+1)*3+head);
				if (i != numOfComma - 1)
          result += ",";
      }
    }
    else if ((head != 0) && (numOfComma == 0)){
      result += s.substring(0,head);
    }
    else if ((head == 0) && (numOfComma != 0)){
      for (var j =0;j<numOfComma;j++){
        result += s.substring(j*3,(j+1)*3);
        if (j != numOfComma - 1)
          result += ",";
      }
    }
    else
      	result += "";
	result += s2;
	if(isMinus)
		result = "-" + result
  return result;
}
//ɾȥǧ��λ��ʾ�Ķ���
function deleteComma(source1){
	//alert("deleteComma begin:" + source1);
	var result = "";
	if ((source1 == "") || (source1 == null))
		return result;
	var index;
	var source;
	var source2;
	source1 = "" + source1;
  var isMinus = false;
	if(source1.charAt(0) == "-"){
		source1 = source1.substring(1);
		isMinus = true;
	}
	index = source1.indexOf(".");
	if (index != -1){
		source = source1.substring(0,index);
		source2 = source1.substring(index);
	}
	else{
		source = source1;
		source2 = "";
	}
	var first = source.indexOf(",");
	var last = first;
	if (first == -1){
		if(isMinus){
			source1 = "-" + source1;
		}
		return source1;
	}
	while(first != -1){
		result = result + source.substring(0,first);
		source = source.substring(first+1);
		last = first;
		first = source.indexOf(",");
	}
	result = result + source;
	result = result + source2;
	if(isMinus)
		result = "-" + result
	return result;
}


function setDebugMode() {
  window.doRequest = debugMode_doRequest;
  window.doRequestPage2 = debugMode_doRequestPage2;
  window.requestData = debugMode_requestData;
}

/////////////////////////////////////////////////////////////////////////////
// ƽ̨���Ժ���
/////////////////////////////////////////////////////////////////////////////

/**
 * �滻 doRequest : Community.js
 * doRequest �������ݷ���:
 *   <html><body><xml id="result" success="true"></xml><script>
 *   parent.free();
 *   var doc = document.getElementById("result");
 *   parent.save_R(doc);
 *   </script></body></html>
 */
function debugMode_doRequest(functionID, componame, paramNames, paramValues, callback) {
  var s;
  s = "*** doRequest\n"
    + "functionID=" + functionID + "\n"
    + "componame=" + componame + "\n"
    + "callback=" + callback + "\n"
    + "\n[paramNames / paramValues]\n";
  if (paramNames != null){
    for(var i = 0; i < paramNames.length; i++)
      s += paramNames[i] + "=" + paramValues[i] + "\n";
  }
  dump(s);

  // ������ͼģ��ص�����������ʱ��������
  var result = document.createElement("span");
  result.setAttribute("success", "false");
  result.innerHTML = "<pre>���Ի������޷���ѯ caller=\n"
    + doRequest.caller + "</pre>";
  eval(callback + "(result)");
}

/**
 * �滻 doRequestPage2 : Community.js
 */
function debugMode_doRequestPage2(functionID, componame, paramNames, paramValues, target, url) {
  var s;
  s = "*** doRequestPage2\n"
    + "functionID=" + functionID + "\n"
    + "componame=" + componame + "\n"
    + "target=" + target + "\n"
    + "url=" + url + "\n"
    + "\n[paramNames / paramValues]\n";
  if (paramNames != null){
    for(var i = 0; i < paramNames.length; i++)
      s += paramNames[i] + "=" + paramValues[i] + "\n";
  }
  dump(s);
}

// �滻 requestData: Community.js
function debugMode_requestData(functionID, componame, paramNames, paramValues,url) {
  var s;
  s = "*** requestData\n"
    + "functionID=" + functionID + "\n"
    + "componame=" + componame + "\n"
    + "url=" + url + "\n"
    + "\n[paramNames / paramValues]\n";
  if (paramNames != null){
    for(var i = 0; i < paramNames.length; i++)
      s += paramNames[i] + "=" + paramValues[i] + "\n";
  }
  dump(s);

  // ������ͼģ��ص�����������ʱ��������
  var xmldom = new ActiveXObject("Microsoft.XMLDOM");
  xmldom.loadXML("<xml id=\"result\" success=\"false\">���Ի������޷���ѯ</xml>");
  var result = xmldom.documentElement.firstChild;
}

/** �����õĺ��� */
function dump(obj) {
  alert(obj);
}
/**
 * ȡ��ÿҳ���Դ�ӡ�ļ�¼��
 * tplCode ��ӡģ�����
 */
function getPrintRowsPerPage(tplCode){
  var names = new Array();
  var values = new Array();
  names[0] = "TPL_CODE";
  values[0] = tplCode;
  var temp = requestData("fpreprint","all",names,values).text;
  if((temp) && (parseInt(temp))){
  	return parseInt(temp)
  }
  else{
  	return 0;
  }
}

/* �ı䷭�� */
function changeTrans(resId, resNa){
  var names = new Array();
  var values = new Array();
  names[0] = "resId";
  values[0] = resId;
  names[1] = "resNa";
  values[1] = resNa;
  requestData("changeTrans", "all", names, values);
}
