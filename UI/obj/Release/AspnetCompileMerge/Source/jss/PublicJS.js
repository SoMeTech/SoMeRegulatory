function BindDate(objID,_dateFormat)
{
//    _dateFormat=_dateFormat==null?'yy-m-d':_dateFormat;
//    $('#'+objID).datepicker({
//        dateFormat: _dateFormat,
//        buttonImage: '/images/calendar.gif', 
//        buttonImageOnly: true ,
//        showOn: 'both'
//    });
}

function myformatter(date){
	var y = date.getFullYear();
	var m = date.getMonth()+1;
	var d = date.getDate();
	return y+'-'+(m<10?('0'+m):m)+'-'+(d<10?('0'+d):d);
}
function myparser(s){
	if (!s) return new Date();
	var ss = s.split('-');
	var y = parseInt(ss[0],10);
	var m = parseInt(ss[1],10);
	var d = parseInt(ss[2],10);
	if (!isNaN(y) && !isNaN(m) && !isNaN(d)){
		return new Date(y,m-1,d);
	} else {
		return new Date();
	}
}

 


    //图片预览2013-4-1 【wr】
    function PreviewImage(imgFile)
    {
    try
    {
     
      var filextension=imgFile.value.substring(imgFile.value.lastIndexOf("."),imgFile.value.length);
      filextension=filextension.toLowerCase();
      if ((filextension!='.jpg')&&(filextension!='.gif')&&(filextension!='.jpeg')&&(filextension!='.png')&&(filextension!='.bmp'))
      {
          alert("对不起，系统仅支持标准格式的照片，请您调整格式后重新上传，谢谢 !");
          imgFile.focus();
          return;
      }
      else
      {
          var path;
          if(document.all)//IE
          {
              imgFile.select();
              path = document.selection.createRange().text;
              try
              {
                if($("div[id=imgPreview]").length!=0)
                {
              
                   $("div[id=imgPreview]").get(1).innerHTML=""; 
                  $("div[id=imgPreview]").get(1).style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled='true',sizingMethod='scale',src=\"" + path + "\")";//使用滤镜效果
                }
                else
                {
                    var _img=$("img.img",$(".bd")).get(1);
                    _img.src=path;
                  _img.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled='true',sizingMethod='scale',src=\"" + path + "\")";//使用滤镜效果
                }
              }
              catch(e)
              {
                alert(e+"11");
              }


          }
          else//FF
          {
              path = imgFile.files[0].getAsDataURL();
              //document.getElementById("imgPreview").innerHTML = "<img id='upimg' width='120px' height='100px' src='"+path+"'/>";
               document.getElementById("upimg").src = path;
          }
 
      }
      }
      catch(e)
      {
        alert(e+"22");
      }
    }
/*
 * 字符串操作类，主要用于字符串的添加和删除。例如：在字符串 "a,b,c"中添加字符串"d",或者直接删除某个字符串。
 * 主要提供将给定字符串添加到某个字符串，中间用逗号分隔
 *    By Lubin Insert. 2013/4/3
 */
var StringOperate ={
		separator    : ",",//字符串分隔符
		baforeInsert : false,//字符串追加方式，默认false是在后面添加，true在追加到前面
		isRepeat     : false,//追加的字符串是否可重复添加
		isDeleteAll  : true,//删除所有匹配的字符串
		
		//左边添加分隔符
		lInsertSeparator : function(operateString){
			if(operateString.indexOf(this.separator)  == 0)
				return operateString;
			return this.separator + operateString;
		},
		//右边添加分隔符
		rInsertSeparator : function(operateString){
			if(operateString.lastIndexOf(this.separator)  == (operateString.length - this.separator.length))
				return operateString;
			return operateString + this.separator; 
		},
		//去除左边分隔符
		lSeparatorTrim   : function(operateString){
			if(operateString.indexOf(this.separator)  == 0)
				return operateString.substring(1);
			return operateString;
		},
		//去除右边的分隔符
		rSeparatorTrim   : function(operateString){
			if(operateString.lastIndexOf(this.separator)  == (operateString.length - this.separator.length))
				return operateString.substring(0,operateString.length-1);
			return operateString;
		},
		//追加字符串，将str字符串 追加到operateString中
		add : function(operateString, str){
			if( str  && str != ""){
				if(this.isRepeat){//重复追加
					if(this.baforeInsert){//追加在开头
						 return this.rSeparatorTrim(this.lSeparatorTrim(str + this.separator + operateString));
					}
					return this.rSeparatorTrim(this.lSeparatorTrim(operateString + this.separator + str));
				}else{
					//开头和结尾都添加分隔符
					operateString =	this.lInsertSeparator(this.rInsertSeparator(operateString));
					if(operateString.indexOf(this.separator + str + this.separator) == -1){
						if(this.baforeInsert){
							return this.rSeparatorTrim(this.lSeparatorTrim(str + operateString));
						}else{
							return this.rSeparatorTrim(this.lSeparatorTrim(operateString + str));
						}
					}
					return this.rSeparatorTrim(this.lSeparatorTrim(operateString));
				}
			}
		},
		//删除指定字符串
		remove : function(operateString, str){
			if(operateString && str && operateString != "" && str != ""){
				//开头和结尾都添加分隔符
				operateString =	this.lInsertSeparator(this.rInsertSeparator(operateString));
				if(this.isDeleteAll){
					operateString = operateString.replace(new RegExp(this.separator,"g"),this.separator + this.separator);
					//删除所有匹配的字符串
					operateString =	 operateString.replace(new RegExp(this.separator + str +this.separator,"g"),this.separator);
					operateString = operateString.replace(new RegExp(this.separator+"{2,}","g"),this.separator);
				}else{
					operateString =	 operateString.replace(new RegExp(this.separator + str + this.separator),this.separator);
				}
				return this.rSeparatorTrim(this.lSeparatorTrim(operateString));
			}
		}
		
		
};
function getCursorPos(obj,loop){
  var rngSel = document.selection.createRange();//建立选择域
  var rngTxt = obj.createTextRange();//建立文本域
  var flag = rngSel.getBookmark();//用选择域建立书签
  rngTxt.collapse();//瓦解文本域到开始位,以便使标志位移动
  rngTxt.moveToBookmark(flag);//使文本域移动到书签位
  rngTxt.moveStart('character',-obj.value.length);//获得文本域左侧文本
  str = rngTxt.text.replace(/\r\n/g,'');//替换回车换行符
  if(loop)
    return str;
  else
    return(str.length);//返回文本域文本长度
}

function myKeyDown(obj,oEvent,loop) {
    if(PinBiCtrlV())
        return;
	var k = oEvent.keyCode;
//	alert(String.fromCharCode(oEvent.keyCode))
	if ((k == 8) || (k == 45) || (k == 46) || (k >= 48 && k <= 57))
	{ }
	else {
		oEvent.returnValue = false;
	}
	
    var selecter=document.selection.createRange();
    if(selecter.text!="")
    {
        return;
    }
	//eval("var Res=/(.{"+getCursorPos(obj)+"})/g")
	//obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)),loop)
	//alert(obj.value.replace(Res,'$1'+String.fromCharCode(oEvent.keyCode)));
	var insertIndex=getCursorPos(obj);
	var objValue=obj.value.substring(0,insertIndex)+String.fromCharCode(oEvent.keyCode)+obj.value.substring(insertIndex)
	if(loop>=2)
	{
	    if(!_Number(objValue,loop))
		    oEvent.returnValue = false;
	}
	else if(objValue!='-' && !_Number(objValue,loop))
		oEvent.returnValue = false;
    }
//loop=0两位小数，否则无小数
function _Number(ssn,loop)
{
	var re;
	switch(loop)
	{
	    case 0:
	    case 2://不允许负数
		    re=/^\-?[0-9]+\.?[0-9]{0,2}$/i;
		    break;
		case 4://不允许负数
		    re=/^\-?[0-9]+\.?[0-9]{0,4}$/i;
	    case 1:
	    case 3:
		    re=/^\-?[0-9]+$/i;
		    break;
		case -4://允许负数
		    re=/^\-?[0-9]+\.?[0-9]{0,4}$/i;
		    break;
	}
	if(ssn==''||re.test(ssn))
		return true;
	else
		return false;
}



function tbSaveExcel(SaveName,tbName,_Window)
{
    try{
        var filedlg = new ActiveXObject("MSComDlg.CommonDialog");
    /*MSComDlg.CommonDialog 的方法
    ShowOpen 显示“打开”对话框 
    ShowSave 显示“另存为”对话框 
    ShowColor 显示“颜色”对话框 
    ShowFont 显示“字体”对话框 
    ShowPrinter 显示“打印”或“打印选项”对话框 
    ShowHelp 调用 Windows 帮助引擎 
    */
    }catch(e){
        var curTbl = _Window.document.getElementById(tbName);
        var win = window.open(); 
        win.document.write(curTbl.parentNode.innerHTML);
        win.document.execCommand('Saveas',false,'c:\\'+SaveName+'.xls')
        win.close();
        return;
    }
 
    try{
        var textarea = event.srcElement; 
        filedlg.Filter = "*.xls|"+SaveName+".xls";
        filedlg.FilterIndex = 1;
        filedlg.MaxFileSize = 128;
        filedlg.ShowSave();
        if(filedlg.FileName!=null && filedlg.FileName!="")
        {
            var curTbl = _Window.document.getElementById(tbName);
            var fso, tf; 
            fso = new ActiveXObject("Scripting.FileSystemObject"); 
            tf = fso.CreateTextFile(filedlg.FileName, true); 
            tf.WriteLine(curTbl.parentNode.innerHTML) ; 
            tf.Close(); 
            alert("导出成功!");
        }
    }catch(e){alert(e);}

}

function HTMLSaveExcel(SaveName,tbHTML,_Window)
{
    try{
        var filedlg = new ActiveXObject("MSComDlg.CommonDialog");
    /*MSComDlg.CommonDialog 的方法
    ShowOpen 显示“打开”对话框 
    ShowSave 显示“另存为”对话框 
    ShowColor 显示“颜色”对话框 
    ShowFont 显示“字体”对话框 
    ShowPrinter 显示“打印”或“打印选项”对话框 
    ShowHelp 调用 Windows 帮助引擎 
    */
    }catch(e){
        var win = window.open(); 
        win.document.write(tbHTML);
        win.document.execCommand('Saveas',false,'c:\\'+SaveName+'.xls')
        win.close();
    }
    
    try{
        var textarea = event.srcElement; 
        filedlg.Filter = "*.xls|"+SaveName+".xls";
        filedlg.FilterIndex = 1;
        filedlg.MaxFileSize = 128;
        filedlg.ShowSave();
        if(filedlg.FileName!=null && filedlg.FileName!="")
        {
            var fso, tf; 
            fso = new ActiveXObject("Scripting.FileSystemObject"); 
            tf = fso.CreateTextFile(filedlg.FileName, true); 
            tf.WriteLine(tbHTML) ; 
            tf.Close(); 
            alert("导出成功!");
        }
    }catch(e){alert(e);}

}


/**************************************************

返回剪贴板的内容

**************************************************/
function getClipboard() {
   if (window.clipboardData) {

      return(window.clipboardData.getData('Text'));

   }
   else if (window.netscape) {

      netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');

      var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);

      if (!clip) return;

      var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);

      if (!trans) return;

      trans.addDataFlavor('text/unicode');

      clip.getData(trans,clip.kGlobalClipboard);

      var str = new Object();

      var len = new Object();

      try {
         trans.getTransferData('text/unicode',str,len);
      }
      catch(error) {
         return null;
      }
      if (str) {
         if (Components.interfaces.nsISupportsWString) str=str.value.QueryInterface(Components.interfaces.nsISupportsWString);
         else if (Components.interfaces.nsISupportsString) str=str.value.QueryInterface(Components.interfaces.nsISupportsString);
         else str = null;
      }
      if (str) {
         return(str.data.substring(0,len.value / 2));
      }
   }
   return null;
}


function PinBiCtrlV(){ //屏蔽鼠标右键、Ctrl+n、shift+F10、F5刷新、退格键    
    if ((event.ctrlKey)&&(event.keyCode==86)) //屏蔽 Ctrl+V    
    {
        event.keyCode=0;   
        event.returnValue=false;
        return true;
    }
}
function PinBiContextMenu()
{
    event.returnValue=false;
}
function trim(str){ //删除左右两端的空格
    if(str!=null){
	str = str.replace(/(^\s*)|(\s*$)/g, "");
　　return str;
　　}
　　else
　　    return "";
}

        //设置ReadOnly文本框
        function setReadOnly()
        {
            if($("input[id='ibtcontrol_ibtsave']").length>0){
                /*disabled状态可以设置背景色，但字体颜色不能设定，所以只能取消前者改为readonly
                 *兼容IE6~IE8
                 *     By Lubin update. 2013/4/7   
                 */
                //设置不可编辑的框颜色(轻灰)
                $("*[readonly='true'],*[readonly='readonly'],*[disabled='true'],*[disabled='disabled']").css({backgroundColor:"#e9e9e9",color:"#666"});
                
                $("input[rdonly='1'],input[disabled='true'],input[disabled='disabled']").attr({readonly:"readonly"});
                $("input[disabled='true'],input[disabled='disabled']").removeAttr("disabled");
                
                //设置必填的颜色
                $($("span")).each(function(){
                    if(trim(this.outerText)=='*'){
                        if((this.parentNode.firstChild.type=="text"||this.parentNode.firstChild.type=="textarea"||this.parentNode.firstChild.type=="select-one")&&!this.parentNode.firstChild.disabled)
                        {
                            this.parentNode.firstChild.style.backgroundColor="#FFEFFF";
                            this.parentNode.firstChild.style.color="#000";
                        }
                    }
                });
                //
//                try{
//                alert($("input[type='text']").data("events")["click"]);
//                }catch(e){alert(e)}
//                $("input[type='text']").each(function(i){
//                    if(this.onclick!=null)
//                    {
//                        this.style.backgroundColor="";
//                        this.style.color="";
//                    }
//                });
                
//                $("input[rdonly='1']").css({backgroundColor:"#EFF5D6",color:"#333"});
//                
//                $($("img")).each(function(){
//                    if(this.src.indexOf('/images/calendar.gif')>-1){
//                        this.parentNode.firstChild.style.backgroundColor="#EFF5D6";
//                        this.parentNode.firstChild.style.color="#333";
//                    }
//                });
//                
            }
                //alert($("input[disabled='true']").length);
                //alert($("#ctl00_ContentPlaceHolder1_txtPD_QUOTA_GLLX").attr("disabled"));
        }
        function SetColor()
        {
            if($("input[id='ibtcontrol_ibtsave']").length<=0)
            {
                $("input[type='text'],*[type='textarea']").attr({disabled:"",readonly:"readonly",onclick:""});
                $("input[type='text']").attr("onclick","");
                $("input[type='text']").css({backgroundColor:"#e9e9e9",color:"#666"});
                $("input[QiPao='true']").attr({QiPao:""});
    //            $("input[type='text'],input[type='checkbox']").css("color","#666");

                $("input[type='file'],input[type='checkbox']").css("display","none");
                $("input[type='file']").attr({disabled:"disabled",onclick:""});
                
                $("select").attr("disabled","disabled");
                $("select").css("backgroundColor","#e9e9e9");
                //$("select").css("color","#333");
                
                $("textarea").attr("readonly","readonly");
                $("textarea").css({backgroundColor:"#e9e9e9",color:"#666"});
                
                
                $("div[uid='add_del_button']").attr('style','display:none;');
                
                //By Lubin update. 2013/4/2
                //如果不能修改，取消附件的删除按钮与上传按钮
                $("div.fileUpArea").attr('style','display:none;');
                if($("img.search-img").length>0)
                    $("img.search-img").get(0).onclick="";
//                alert($("input.'easyui-datebox datebox-f combo-f'").length);
                
                $("span.combo-arrow").attr('style','display:none;');
//                alert($("input[class='easyui-datebox datebox-f combo-f']").length);
                $("img[uid='ImgDeleteFile']").attr('style','display:none;');
               
               
               //wr对上传图片的按钮做处理
                $(".up_imgsinput").attr({disabled:"disabled"}); 
                $(".del_imgsinput").attr({disabled:"disabled"}); 
                $("#btn_save").attr({disabled:"disabled"}); 
                
            }
            else
            {
                //setTimeout(SetNumEvent,1);
            }
            
            setReadOnly();
        }
    function SetNumEvent()
    {
        $("input").each(function(i){
            if(this.onkeypress!=null&&this.onkeypress!='undefined'&&this.onkeypress!=''){
                if((this.onkeypress+"").indexOf('myKeyDown')>=0){
                    this.className="NumTextCss";
                    this.oncontextmenu = PinBiContextMenu;
                    this.onkeydown = PinBiCtrlV;//屏蔽数值文本框的粘贴
                }
            }
        });
    }
    
 //验证控件
function PublicYanZheng()
{
    var _return=true;
    $($("span")).each(function(){
     if(trim(this.outerText)=='*'){
        var _tr = this.parentNode.parentNode;

        if($("input.easyui-datebox",this.parentNode).size()==0)
        {
            if($("input,textarea",this.parentNode).length>0 && trim($("input,textarea",this.parentNode).get(0).value)=="")
            {
                var _name = _tr.cells[this.parentNode.cellIndex-1].innerHTML;
                _name = _name.substring(0,_name.indexOf("："));
                Ext.Msg.alert("消息提示框", _name+" 不能为空。");
                $("input[uid='ibtid']").get(0).value='';
                removeWindowFull();
                _return= false;
                return _return;
            }
        }
        else  //日历控件
        {
            
            if(trim($("input.combo-value",this.parentNode).val())=="")
            {
                var _name = _tr.cells[this.parentNode.cellIndex-1].innerHTML;
                _name = _name.substring(0,_name.indexOf("："));
                Ext.Msg.alert("消息提示框", _name+" 不能为空。");
                $("input[uid='ibtid']").get(0).value='';
                removeWindowFull();
                _return=false;
                return _return;
            }
            
        }
        if($("select",this.parentNode).length>0 && trim($("select",this.parentNode).val())=="")
        {
                var _name = _tr.cells[this.parentNode.cellIndex-1].innerHTML;
                _name = _name.substring(0,_name.indexOf("："));
                Ext.Msg.alert("消息提示框", _name+" 不能为空。");
                $("input[uid='ibtid']").get(0).value='';
                removeWindowFull();
                _return=false;
                return _return;
        }
       
     } 
    });
    return  _return;
}
    
    

    
function ImgFileUp(obj,input,TempFile,Pk)//选取值后的file控件，第几个，选取的文件名称
{
 
   try{
    var inputFather=input.parentNode;
    input.style.display="none";
    var body = document.body; //页面body
    var name=input.id;//fileName
    var iframename = "iframe"+name;//框架iframe的名称
    var	iframe;//框架
    var form=document.createElement('form');//创建表单
    var upedfilename;//上传后文件名称
    var file_name="";
    

    //创建iframe
	iframe = document.createElement("<iframe name=\"" + iframename + "\">");
//	iframe = document.createElement( info.ie ? "<iframe name=\"" + iframename + "\">" : "iframe");
//	if(info.ie)
//	{
//	    document.createElement("<iframe name=\"" + iframename + "\">");
//	}
//	else
//	{
//	    document.createElement("iframe");
//	}
	iframe.name = iframename;
	iframe.style.display = "none";
	//插入body
	body.insertBefore( iframe, body.childNodes[0]);	
	
	//设置form
	var UrlZX="";
	if(TempFile!=null && TempFile!="")
	    UrlZX = TempFile;
	form.name="form"+name;//表单名称
	form.target=iframename;
    form.method="post";
    form.encoding="multipart/form-data";
    form.action="/WebControls/UserControl/Fileup.ashx"+UrlZX;
    body.insertBefore( form, body.childNodes[0]);
    
    //添加控件进form
    form.appendChild(input);
    
    //定义iframe 的onload事件
    iframe.attachEvent("onload",CallBack);
//    if (info.ie)//IE 需要注册onload事件
//    {
//         iframe.attachEvent("onload",CallBack);
//    } 
//    else
//    {
//       iframe.onload = CallBack;
//    }
    //提交 --------------------------------------------------
    form.submit();
    //提交完毕-----------------------------------------------
    }catch(e){alert(e);}
    function CallBack()//iframe加载完成，返回结果处理
    {

        try
        {
//        file_name=upedfilename;
//        alert(file_name);
//        input.uid=file_name+"123";
        if(obj!=null)
            inputFather.insertBefore(input,obj);
        else
            inputFather.appendChild(input);
        input.style.display="block";

        }catch(e){alert(e)}          
         try
         {
              var value =iframe.contentWindow.document.body.innerHTML;
              upedfilename=value.substring(value.indexOf("@returnstart@")+13,value.indexOf("@returnend@"));
              file_name=upedfilename;
              if(upedfilename=="000")
              {
                //alert("图片路径不能为空。请先上传图片！");  
                
                if(obj!=null)
                    alert('上传完成');
                return;
              } 
              if(upedfilename.length>3)//正常上传，返回上传后文件名
              {
                  finished();
                  return upedfilename;
              }
              else//停止上传，从StopUpLoad.ashx页面返回空值，也可能是返回错误001，000
              {      
                if(obj!=null)
                    alert('上传完成');
              }
          }
          catch(msg)
          {
             input.err="true"
                if(obj!=null)
                    alert("上传失败"); 
          }
     }
    function finished()//上传完毕
    {
         input.uid=file_name;
         if(obj!=null) 
            alert('上传完成');
    }
}



    function BindQiPao()
    {try{
        if( $("input[QiPao='true']").length==0)
            return;
	    var wh = getpos($("input[QiPao='true']").get(0)).split(',');
        //定义滚动条事件，执行气泡移动代码
        $("#"+($("#top1").get(0).parentNode.id)).get(0).onscroll=function(e){
            if($(".container").get(0).style.display!="none"){
//	            $(".container").get(0).style.top=parseInt(wh[0])+30-$("#"+($("#top1").get(0).parentNode.id)).scrollTop();
	            $(".DivIframe").get(0).style.top=parseInt(wh[0])-50-$("#"+($("#top1").get(0).parentNode.id)).scrollTop();
	            $(".container").get(0).style.top=parseInt(wh[0])-50-$("#"+($("#top1").get(0).parentNode.id)).scrollTop();
            }
        }
        //定义承载元素的鼠标移入事件
        $("input[QiPao='true']").live("mouseover",function(e){
//	        var xx = e.originalEvent.x || e.originalEvent.layerX || 0; 
//	        var yy = e.originalEvent.y || e.originalEvent.layerY || 0; 
            var container = $(".container").get(0);
            if(container.style.display=="none"){
	            container.style.top=parseInt(wh[0])-50-$("#"+($("#top1").get(0).parentNode.id)).scrollTop();
	            container.style.left=parseInt(wh[1])+this.offsetWidth-40;
	            
//	            if($(".DivIframe").length==0)
//	            {
//	                var iframe = document.createElement("iframe");
//	                iframe.className="DivIframe";
//	                iframe.src="javascript:false;" 
//	                iframe.scrolling="no";
//	                iframe.frameborder="0"
//	                iframe.style.cssText = "position:absolute; top:0px; left:0px; display:none;";
//	                try{
//	                document.body.insertBefore(iframe , document.body.childNodes[0]);
//	                }catch(e){alert(e)}
//	            }
//	            container.style.display = "block";
//	            
//	            var IfrRef = $(".DivIframe").get(0);
//	            
//                IfrRef.style.width = container.offsetWidth;
//                IfrRef.style.height = container.offsetHeight;
//                IfrRef.style.top = container.offsetTop+80;
//                IfrRef.style.left = container.offsetLeft+20;
//                IfrRef.style.zIndex = -1;
//                IfrRef.style.display = "block";
	            $(".container").show(300,HideDivQP);
	        }
        });
        //定义承载元素的失去光标事件
        $("input[QiPao='true']").live("blur",function(e){
	        $(".container").hide(300);
	        $(".DivIframe").hide(300);
        });
        }catch(e){alert("弹出气泡出错！"+e)}
    }
    function HideDivQP()
    {
	    setTimeout(function(){$(".container").hide(300);},3000);
    }
    function getpos(e) {  
        var t=e.offsetTop;  
        var l=e.offsetLeft;  
        var height=e.offsetHeight;  
        while(e=e.offsetParent) {  
             t+=e.offsetTop;  
             l+=e.offsetLeft;  
         }
         return t+","+l;
    }  
    
    



