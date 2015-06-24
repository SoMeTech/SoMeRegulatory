/** $Id: login.js,v 1.24 2004/06/17 08:57:18 zhangys Exp $ */
var isOldUser = true;
function trim(str){  //ȥ���ַ����м�Ŀո�
  var oldstr = str;
  for(var i=0;i<oldstr.length;i++)
    str =  str.replace(" ","");
  return str;
}

function getIEVersion(){
	var ua = navigator.userAgent;
	var IEOffset = ua.indexOf("MSIE ");
	return parseInt(ua.substr(IEOffset + 5,1));
}

function login(formName){ //��¼
	var version = navigator.appVersion;
	if ((navigator.appVersion.indexOf("MSIE") == -1) ||
					(getIEVersion() < 6)){
		alert("����������������ڵ�����������У���������IE 6.0���ϣ�");
		return;
	}
	if(!isOldUser){
		alert("�޴˲���Ա�����Ҳ�����Ӧ��ְԱ���������������Ա��");
    var user = document.getElementById("txtUser");
		user.value = "";
    user.focus();
		return;
	}
  var formElement = formName.elements;
  var userNameE;
  var passwordE;
  var actionE;
  var xmlPacketLogin;
  for(var i=0;i<formElement.length;i++){
    if(formElement[i].name=="userName")
      userNameE = formElement[i];
    if(formElement[i].name=="password")
      passwordE = formElement[i];
    if(formElement[i].name=="action")
      actionE = formElement[i];
  }
  userNameE.value = trim(userNameE.value);
  if(userNameE.value ==''){ //���û��������붼����ʱ�Ĵ���.
    alert("���������Ա��");
  }else{
//    window.clipboardData.setData("Text",userNameE.value);
    names = new Array();
    values = new Array();
    names[0] = "username";
    values[0] = userNameE.value;
    names[1] = "password";
    values[1] = passwordE.value;
    communityLogin = getCommunity();
    if(document.getElementById("orgdepart")!=null){
		  names[2]="orgdepart";
			values[2]=document.getElementById("orgdepart").value;
  	}
    if(communityLogin != null){
      communityLogin.doRequestPage("login","all",names,values);
    }
  }
}
function enterLogin(){
  if(event.keyCode == 13){
    var userName = document.getElementById("txtUser").value;
    var formName = document.getElementById("formName");
    if(userName){
      login(formName);
    }else{
      alert("���������Ա��");
      document.getElementById("txtUser").focus();
    }
  }
}

function moveFocus(){
  if(event.keyCode == 13){
    var userName = document.getElementById("txtUser").value;
    if(userName == null || userName.length == 0){
      alert("���������Ա��");
    }else{
      document.getElementById("txtPW").focus();
    }
  }
}

function init(){
  document.getElementById("txtUser").focus();
//  clearAllTxt();
//  clearDepartSelect();
}

function userNameChange(){
	var names = new Array();
	var values = new Array();
	names[0] = "username";
	values[0] = document.getElementById("txtUser").getAttribute("value");
	var tempResult = requestData("getUserOrgDepart","all",names,values);
  var xmldom = new ActiveXObject("Microsoft.XMLDOM");
  xmldom.loadXML(tempResult.text);
	if(xmldom.firstChild.getAttribute("success") != "false"){
		isOldUser = true;
		var fields = xmldom.firstChild.childNodes;
		var valueStr = fields.item(0).getAttribute("value");
		var nameStr = fields.item(1).getAttribute("value");
		valueStr = valueStr.substring(1,valueStr.length-1);
		nameStr = nameStr.substring(1,nameStr.length-1);
		var values = valueStr.split(",");
		var names = nameStr.split(",");
		var orgDepartEle = document.getElementById("orgdepart");
		orgDepartEle.options.length = values.length;
		for(var i=0; i<values.length; i++){
			orgDepartEle.options[i].value = values[i];
			orgDepartEle.options[i].text = trim(names[i]);
		}
	}
	else{
	  var vsUserName = document.getElementById("txtUser").getAttribute("value");
		if(vsUserName.toUpperCase() == "SA")
		{
      //���� ��λ��֯��leidh; 20040514;
		  clearDepartSelect();
			isOldUser = true;
		}
		else if (trim(vsUserName)!= "")
		{
			alert("�޴˲���Ա�����Ҳ�����Ӧ��ְԱ���������������Ա��");
			var user = document.getElementById("txtUser");
			user.value = "";
     	user.focus();
  		var orgDepartEle = document.getElementById("orgdepart");
  		orgDepartEle.options.length = 0;
			isOldUser = false;
		}
	}
}

//���� ��λ��֯��leidh; 20040514;
function clearDepartSelect()
{
  //alert("clearDepartSelect();");
	var orgDepartEle = document.getElementById("orgdepart");
	for(var i= orgDepartEle.options.length- 1; i>= 1; i--)
	{
		orgDepartEle.options.remove(i);
	}

  if (orgDepartEle.options.length== 0)
  {
    var vjOption= document.createElement("<option>");
    vjOption.text = "-";
    vjOption.value = "";
    orgDepartEle.appendChild(vjOption);
  }
  else
  {
		orgDepartEle.options.length = 1;
    orgDepartEle.options[0].text = "-";
    orgDepartEle.options[0].value = "";
  }
}

function clearAllTxt(){
  document.getElementById("txtUser").value="";
  document.getElementById("txtPW").value="";
}


