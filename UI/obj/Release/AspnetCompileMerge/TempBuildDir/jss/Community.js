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
 * 生成编码后的字符串，作为 URL 的参数串
 * @return 合法的 URL 查询字符串
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
 * 生成编码后的字符串，作为 URL 的参数串
 * @return 合法的 URL 查询字符串
 */
function encodeParamObject(paramObject) {
  var s = "";
  var name;
  var i = 0;
  for (name in paramObject) {
    var value = paramObject[name];
    var vtype = typeof value;
    // 忽略未定义、函数和空值
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
 * 生成编码后的字符串，作为 URL 的参数串
 * 参数个数不定，应该是一个偶数，参数依次为名称1，值1，名称2，值2，等等
 * @return 合法的 URL 查询字符串
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
 * 将特定的字符转义，用于构造 URL 的参数串
 * 保留字符 ";", "/", "?", ":", "@", "=", "&" 共 7 个
 * 不安全的字符 "<", ">", "\"", "#", "%"
 * 不处理中文字符，中文字符使用 URLEncodeing (在 formenctype.vbs 中) 转义
 * 参考: rfc1738
 * 参考: http://www.blooberry.com/indexdot/html/topics/urlencoding.htm
 */
function escapeSpecial(value) {
  value = value.replace(/%/g, "%25"); // 必须先做
  // 7 个保留字
  value = value.replace(/&/g, "%26");
  value = value.replace(/\//g, "%2F");
  value = value.replace(/:/g, "%3A");
  value = value.replace(/;/g, "%3B");
  value = value.replace(/=/g, "%3D");
  value = value.replace(/\?/g, "%3F");
  value = value.replace(/@/g, "%40");
  // 不安全的字符
  value = value.replace(/"/g, "%22");
  value = value.replace(/#/g, "%23");
  value = value.replace(/</g, "%3C");
  value = value.replace(/>/g, "%3E");
  // 处理加号和空格
  value = value.replace(/\+/g, "%2B");
  value = value.replace(/ /g, "+"); // 必须在 + 之后做
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
	 alert("没有回调函数");
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
		alert("通信正忙，请稍后再试。");
		return null;
	} else {
		return comm;
	}
}

//获得数据库类型，wtm,返回值为0是Oracle，返回值是1是SQLserver
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
		/*只有设置当前业务日期不返回空值*/
		if(result.innerHTML.length > 0){
			/*
			var win1 = result.innerHTML;
			var syear = win1.substr(0, 4);
			var smonth = win1.substr(5, 2);
			var sday = win1.substr(8, 2);
			传入年月日三个参数，得到会计年度、会计期间
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

function trim(str){  //去除字符串首尾的空格
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
			alert("文件“" + value + "”在数据库中不存在！");
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
 * 描述：预留字段设置
 * 时间：2003-3-26
 *********************************************************/
function doPreCol(compoId,dataItemType,vsEnable,vsNameEnable){
	window.open("PreCol?COMPOID=" + compoId + "&DATAITEMTYPE="
								+ dataItemType + "&VSENABLE=" + vsEnable
								+ "&VSNAMEENABLE=" + vsNameEnable, "",
								"width=400,height=240,menubar=no,scrollbars=no,status=no,"
								+ "toolbar=no,resizable=yes,titlebar=yes,scrollbars=yes");
}

function capitalize(data){
	var result = "";///转换的结果

	///首先判断是否是合法的数字字符；
	data = parseFloat(data);
	if(isNaN(data))
	 return null;

	///转化为字符串
	var tmpValue = new String(data);
	data = tmpValue.toString();

	///求出是正还是负,-1 正,0 负
	var sign = data.indexOf("-");
	///alert("sign:"+sign);
	data = data.replace("-","");

	///求出小数点的位置+1
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
	var  posDigit = 0;///当前数字的位置；

	///data是全数字;
	if(sign == 0)
	{
		result += "负";
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
				result += "零";
				break;
			case '1':
				result += "壹";
				break;
			case '2':
				result += "贰";
				break;
			case '3':
				result += "叁";
				break;
			case '4':
				result += "肆";
				break;
			case '5':
				result += "伍";
				break;
			case '6':
				result += "陆";
				break;
			case '7':
				result += "柒";
				break;
			case '8':
				result += "捌";
				break;
			case '9':
				result += "玖";
				break;
			}
			if((money == '0') && !((i == 1)||(i == 5)||(i == 9)))
				continue;
			switch(i)
			{
			case -1:
				result += "分";
				break;
			case 0:
				result += "角";
				break;
			case 1:
				result += "圆";
				break;
			case 2:
				result += "拾";
				break;
			case 3:
				result += "佰";
				break;
			case 4:
				result += "仟";
				break;
			case 5:
				result += "万";
				break;
			case 6:
				result += "拾";
				break;
			case 7:
				result += "佰";
				break;
			case 8:
				result += "仟";
				break;
			case 9:
				result += "亿";
				break;
			case 10:
				result += "拾";
				break;
			case 11:
				result += "佰";
				break;
			case 12:
				result += "仟";
				break;
			case 13:
				result += "万";
				break;
			}
			if((i == 1)&&(data.charAt(posDigit) == '0')&&(data.charAt(posDigit+1) == '0'))
			{
				result += "整";
				break;
			}
			if((i == 0)&&(data.charAt(posDigit) == '0'))
			{
				result += "整";
				break;
			}
		}
	}else{
		if((data.charAt(1) == '0')&&(data.charAt(2) == '0'))
		{
			result += "零分";
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
				result += "零";
				break;
			case '1':
				result += "壹";
				break;
			case '2':
				result += "贰";
				break;
			case '3':
				result += "叁";
				break;
			case '4':
				result += "肆";
				break;
			case '5':
				result += "伍";
				break;
			case '6':
				result += "陆";
				break;
			case '7':
				result += "柒";
				break;
			case '8':
				result += "捌";
				break;
			case '9':
				result += "玖";
				break;
			}
			switch(i)
			{
			case 2:
				result += "分";
				break;
			case 1:
				result += "角";
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


//把字符串中的双引号(")变换为&quot;
//把字符串中的大于号(>)变换为&gt;
//把字符串中的小于号(<)变换为&lt;
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

//把字符串中的单引号(')变换为两个单引号('')
//把字符串中的&gt;变换为大于号(>)
function doubleApos(str){
	if (null == str)
		return null;
	str = str.replace(/&nbsp;/g," "); // TODO: 2004-6-8 13:54 删除此行，调用处用 innerText
	str = str.replace(/\'/g,"''");
	//-- str = str.replace(/&gt;/g,">"); // HH 2004-6-8 13:53 删除此行
	return str;
}

/**
 * 处理字符产中的特殊字符: & < > "
 * 【注意】首先将所有的 &nbsp; 变为空格，以处理由 innerHTML 得到的字符串中的
 * 特殊字符，没有办法保留 &nbsp; 用 &amp;nbsp; 也不行
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

/** 处理 \r\n 和 \n，替换为 &#10; */
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
设置表格字段宽度
name:页面名或者部件名
tableName:表名
fieldName：字段名
width:宽度
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
	alert("此操作要读写本地硬盘文件以记住表格宽度，若需要记住表格宽度，则要对IE浏览器设置。\n"+
		"解决办法是: " + "工具->Internet选项->安全->本地Intranet->自定义级别，"+
		"将对没有标记为安全的ActiveX控件进行初始化和脚本运行设置成『启用』。");
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
取得表格字段宽度
name:页面名或者部件名
tableName:表名
fieldName：字段名
返回值：字段宽度
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
设置表格表头标题的宽度
tableName：表名
fieldName:字段名
width:宽度值
*/
function setFieldCaptionWidth(tableName,fieldName,width1){
	var fieldID = document.getElementById(tableName + "_" + fieldName + "TableID");
	fieldID.style.width = width1- 2;
	var cel = document.getElementById(tableName + "_" + fieldName + "Cell");
	cel.style.width = width1;
}
/*
此函数用来创建文件.
fielName:文件名
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
//将数字以千分位显示(加逗号)
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
    //千分位格式化后字符串中第一个逗号前字符个数.
    var head = s.length%3;
    //需要加入逗号的个数
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
//删去千分位显示的逗号
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
// 平台调试函数
/////////////////////////////////////////////////////////////////////////////

/**
 * 替换 doRequest : Community.js
 * doRequest 返回数据范例:
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

  // 这里试图模拟回调函数，但是时序有问题
  var result = document.createElement("span");
  result.setAttribute("success", "false");
  result.innerHTML = "<pre>测试环境，无法查询 caller=\n"
    + doRequest.caller + "</pre>";
  eval(callback + "(result)");
}

/**
 * 替换 doRequestPage2 : Community.js
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

// 替换 requestData: Community.js
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

  // 这里试图模拟回调函数，但是时序有问题
  var xmldom = new ActiveXObject("Microsoft.XMLDOM");
  xmldom.loadXML("<xml id=\"result\" success=\"false\">测试环境，无法查询</xml>");
  var result = xmldom.documentElement.firstChild;
}

/** 调试用的函数 */
function dump(obj) {
  alert(obj);
}
/**
 * 取得每页可以打印的记录数
 * tplCode 打印模板代码
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

/* 改变翻译 */
function changeTrans(resId, resNa){
  var names = new Array();
  var values = new Array();
  names[0] = "resId";
  values[0] = resId;
  names[1] = "resNa";
  values[1] = resNa;
  requestData("changeTrans", "all", names, values);
}
