var MouseOnRowIndex=-1; //鼠标所在当前行的假标识号,跟在ID后面。
var path="/WebControls/UserControl/"//删除按钮路径

//var path="./UserControls/"//删除按钮路径
var inputCount=1;//控件个数，实际上传数少一个， 
var Allupfiled=0;//总共上传
var Endupfiled=0;//已上传

var ua = navigator.userAgent.toLowerCase(); //浏览器信息
var info = {    
        ie: /msie/.test(ua) && !/opera/.test(ua),        //匹配IE浏览器    
        op: /opera/.test(ua),     //匹配Opera浏览器    
        sa: /version.*safari/.test(ua),     //匹配Safari浏览器    
        ch: /chrome/.test(ua),     //匹配Chrome浏览器    
        ff: /gecko/.test(ua) && !/webkit/.test(ua)     //匹配Firefox浏览器
        }; 
//window.onload=SetClick;//加载完成，添加一个控件

//function SetClick()
//{
//    //if(inputCount>=10)
//    //{
//        //alert("附件个数不能超过10个!");
//        //return;
//    //}
//    try{
//    var container=document.getElementById("fileUpArea");
//    var input1=document.createElement("input");
//    input1.type="file";
//    //input1.name="file"+inputCount;
//    input1.name="filesupload";
//    input1.id="file"+inputCount;
//    input1.className="fileinput";
//    input1.onchange=function(event)
//    {
//        if(this.value)
//        {
//           var k=this.value.lastIndexOf("\\");
//           var str=this.value.substring(k+1);
//           var divs=document.getElementById("ShowDIV"+MouseOnRowIndex).getElementsByTagName("div");
//           var check=false;

//           for(var i=0;i<divs.length;i++)
//           {
//             if(divs[i].innerHTML.indexOf(str)!=-1)   
//             {
//                  check=true;
//                  break;
//             }
//           }
//           if(!check)
//           {
//               Allupfiled++;
//               SetIframeInput(this,inputCount,str);
//           }
//           else
//           {
//               alert("不允许添加同名附件！请重命名！");
//               return;
//           }
//       }
//    }
//    container.appendChild(input1);
//    inputCount++;
//    }catch(e){alert(e);}
//    //input1.click();
//}
function CreateFile(Obj,tabelID)
{
    var FatherObj=Obj.parentNode;
    var _rowIndex = FatherObj.parentNode.parentNode.rowIndex;
    try{
    FatherObj.innerHTML="<input type=\"file\" class=\"fileinput\" name=\"file\"  onchange=\"BindUpLoad(this,'"+tabelID+"',"+Obj.ColumnIndex+")\" ColumnIndex="+Obj.ColumnIndex+" rowIndex="+Obj.rowIndex+" onmouseover=\"MouseOnRowIndex="+Obj.rowIndex+"\"/>";
    }catch(e){alert(e);}
    return _rowIndex;
}
function CheckFileNames(str)
{
    var divs=document.getElementById("ShowDIV"+MouseOnRowIndex).getElementsByTagName("div");
    var check=false;
          
    for(var i=0;i<divs.length;i++)
    {
        if(/"+str"+/i.test(divs[i].innerHTML))
        {
                  check=true;
                  break;
        }
   }
   
}
function SetIframeInput(input,num,str,tabelID,TempFile)//选取值后的file控件，第几个，选取的文件名称
{

 
    var body = document.body; //页面body
    var name=input.id;//fileName
    var contxt=document.createElement("div");//显示附件名称用的div
     var contxtDiv=document.createElement("div");//显示附件名称用的a
    var contxtA=document.createElement("a");//显示附件名称用的a
 
    var filetxtDiv=document.getElementById("ShowDIV"+MouseOnRowIndex);//显示用的div(contxt)的上级div;
    var filedownAreaNum = document.getElementById("filedownArea"+MouseOnRowIndex);//下载DIV
    var iframename = "iframe"+name;//框架iframe的名称
    var	iframe;//框架
    var form=document.createElement('form');//创建表单
    var statediv=document.createElement("span");//状态div
    var stopdiv=document.createElement("span");//停止按钮
    var jxupdiv;//上传按钮
    var imgs=document.createElement('img');//删除按钮
    var upedfilename;//上传后文件名称
    
    //var filedNames=document.getElementById("filedName");//显示上传后所有附件名称，后台取值用
 
    var filedNames=getfiledName();
    if(Endupfiled==0)
    {
        filedNames.value="";
    }
    
    
//    contxt.id=input.id+"text";//显示用的div(contxt)的ID
//    contxt.innerHTML="<div style='width:auto;margin-left:-10px; height:21px; border:thin solid #899aa1;'><a style='cursor:hand;' href=\"javascript:void(0);\" onclick='DownFile(this);'>"+str+"</a></div>&nbsp;&nbsp;";//contxt的innerHTML（显示内容）
//    contxt.className="";
//    filetxtDiv.appendChild(contxt);//添加一个显示附件内容的div
//    if(filedownAreaNum!=null){
//        filedownAreaNum.style.cursor='hand'
//        filedownAreaNum.onclick=function(){DownFile(this);}
//    }
//    imgs.uid = "ImgDeleteFile";
//    imgs.src=path+"images/f2.gif";
//    imgs.style.cursor="hand";
//    imgs.onclick=Dispose;//删除事件
//    contxt.appendChild(imgs);//添加删除按钮


    
    //修改
    contxt.id=input.id+"text";//显示用的div(contxt)的ID
    if(filedownAreaNum!=null){
    filedownAreaNum.style.cursor='hand'
    filedownAreaNum.onclick=function(){DownFile(this);}
    }
    imgs.uid = "ImgDeleteFile";
    imgs.src=path+"images/f2.gif";
    imgs.style.cssText='cursor:pointer;float:left;margin-top:6px; margin-left:5px;';
    imgs.onclick=Dispose;//删除事件 
    contxtA.style.cssText="cursor:hand;float:left;";
    contxtA.onclick=function(){ DownFile(this);}
    contxtA.innerHTML=str;
    if(!isNaN(input.rowindex) || parseInt(input.rowindex)>=10000)
        contxtDiv.style.cssText='margin-top:-7px;height:25px;';
        //contxtDiv.style.cssText='width:auto;margin-left:-10px; height:21px; border:thin solid #899aa1;';
    contxtDiv.appendChild(contxtA);
    contxtDiv.appendChild(imgs);
    contxt.appendChild(contxtDiv);
    contxt.className="";
    filetxtDiv.appendChild(contxt);//添加一个显示附件内容的div
    
//    statediv.id="state"+num;
//    statediv.className="spanstate";
//    statediv.innerHTML="准备上传";
//    contxt.appendChild(statediv);//添加状态div
    
    //创建iframe
	iframe = document.createElement( info.ie ? "<iframe name=\"" + iframename + "\">" : "iframe");
	if(info.ie)
	{
	    document.createElement("<iframe name=\"" + iframename + "\">");
	}
	else
	{
	    document.createElement("iframe");
	}
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
    form.action=path+"Fileup.ashx"+UrlZX;
    //form.action="UserControls/CallBack.aspx";
    body.insertBefore( form, body.childNodes[0]);
    
    //添加一个新的file
    var _rowIndex = CreateFile(input,tabelID);
    //try{alert(_rowIndex);}catch(e){alert(e);}
    //int RowIndex = 
    //alert(RowIndex);
    
    //添加控件进form
    form.appendChild(input);
    
    statediv.innerHTML="正在上传";
   
   //添加停止按钮
    stopdiv.id="stopdiv"+num;
    stopdiv.innerHTML="停止";
    stopdiv.style.cursor="hand";
    contxt.appendChild(stopdiv);
    stopdiv.onclick=function()//停止事件
    {
        iframe.src =path+"StopUpLoad.ashx";//无任何处理代码
        window.frames[iframename].location.reload(); //重新刷新iframe终止上传，在 iframe onload事件中处理
        //iframe.location.reload();
    }   
    //定义iframe 的onload事件
    if (info.ie)//IE 需要注册onload事件
    {
         iframe.attachEvent("onload",CallBack);
    } 
    else
    {
       iframe.onload = CallBack;
    }
    
    //提交 --------------------------------------------------
    form.submit();
    //提交完毕-----------------------------------------------
    function CallBack()//iframe加载完成，返回结果处理
    {
         try
         {
              var value =iframe.contentWindow.document.body.innerHTML;
              upedfilename=value.substring(value.indexOf("@returnstart@")+13,value.indexOf("@returnend@"));
              if(upedfilename.length>3)//正常上传，返回上传后文件名
              {
                  //alert(upedfilename); 
                  finished();
              }
              else//停止上传，从StopUpLoad.ashx页面返回空值，也可能是返回错误001，000
              {
                  statediv.innerHTML="等待上传";
                  statediv.style.color="#008080";
                  continueUpLoad();//上传按钮
              }
          }
          catch(msg)
          {
               statediv.innerHTML="上传失败";
               statediv.style.color="#808080";
               continueUpLoad();//上传按钮
          }
     }
     function continueUpLoad()//上传按钮
     {
         stopdiv.style.visibility="hidden";
         jxupdiv=document.createElement("span");//上传按钮
         jxupdiv.id="jxupdiv"+num;
         jxupdiv.innerHTML="上传";
         jxupdiv.style.cursor="hand";
         contxt.appendChild(jxupdiv);//添加上传按钮
         jxupdiv.onclick=function()//重新上传
         {           
             contxt.removeChild(jxupdiv);
             statediv.innerHTML="正在上传";
             statediv.style.color="#0099FF";     
             stopdiv.style.visibility="visible";
             form.submit();//重新提交         
         }
     }
     function Dispose()//删除事件
     {
         //=contxt.innerText.substring(0,contxt.innerText.length-4).trim();
         //var OldFileName=contxt.getElementsByTagName("a")[0].innerText;
         
         filetxtDiv.removeChild(contxt);
         body.removeChild(form);
         body.removeChild(iframe);
         Allupfiled--;//总上传数减一
         if(upedfilename)
         {try{
             if(upedfilename.length>3)
             {
             
                Endupfiled--;
                filedNames.value = FileXmlCZ(filedNames.value,tabelID,_rowIndex,upedfilename,str,false);
                if(filedownAreaNum!=null)
                    filedownAreaNum.systemName='';
//                 var upFileName=_rowIndex+"-"+upedfilename;
//             //alert(upFileName);alert(str);
//                 
//                 if(upedfilename+":"+str==filedNames.value.substring(filedNames.value.indexOf('-')+1))
//                 {
//                     filedNames.value="";
//                 }
//                 else if(filedNames.value.indexOf(upedfilename)<5)
//                 {
//                     filedNames.value=filedNames.value.substring(filedNames.value.indexOf('-')+1);
//                     
//                     filedNames.value=filedNames.value.replace(upedfilename+":","");
//                     filedNames.value=filedNames.value.replace(str+"|","");
//                 }else{
//                     var tempIndex = filedNames.value.indexOf(upedfilename);
//                     var tempLastIndex = filedNames.value.lastIndexOf('|',tempIndex);
//                     var tempLastIndex2 = filedNames.value.lastIndexOf('-',tempIndex);
//                     filedNames.value = filedNames.value.substring(0,tempLastIndex)+filedNames.value.substring(tempLastIndex2+1);
//                     
//                     filedNames.value=filedNames.value.replace(upedfilename,""); 
//                     filedNames.value=filedNames.value.replace(":"+str,""); 
//                 }
             }}catch(e){alert(e)};
         }
     }
    function finished()//上传完毕
    {
        statediv.style.color="#ff0000";
//       statediv.innerHTML="上传成功";
        statediv.innerHTML="&nbsp;";
        contxt.removeChild(stopdiv);
        input.parentNode.removeChild(input);
        filedNames.value = FileXmlCZ(filedNames.value,tabelID,_rowIndex,upedfilename,str,true);
        contxt.getElementsByTagName("a")[0].setAttribute('systemName',upedfilename);
        
        if(filedownAreaNum!=null)
            filedownAreaNum.setAttribute('systemName',upedfilename);
//        if(filedNames.value=="")
//        {
//            filedNames.value=_rowIndex+"-"+upedfilename+":"+str;
//        }
//        else
//        {
//            filedNames.value+="|"+_rowIndex+"-"+upedfilename+":"+str;
//        }
        Endupfiled++;//已上传数加一
    }
}
function checkFileState()
{
    if(Endupfiled!=Allupfiled)
    {
        alert("还有文件未上传成功！");
        return false;
    }
    return true;
}
	
	
	


function BindUpLoad(obj,tableID,_FileCellIndex,TempFile)
{
 
    if(obj.value)
    {        
//        alert(obj.parentNode.parentNode.parentNode.nodeType);
//        alert(obj.parentNode.parentNode.parentNode.innerHTML);
       var ImgDeleteFile = $("*[uid='ImgDeleteFile']",obj.parentNode.parentNode.parentNode.cells[_FileCellIndex])
//       alert(obj.parentNode.parentNode.parentNode.innerHTML);
       if(ImgDeleteFile.length!=0)
       {
            ImgDeleteFile.get(0).click();
//            obj.parentNode.parentNode.parentNode.cells[_FileCellIndex].lastChild.lastChild.firstChild.getElementsByTagName("img")[0].click();
       }
       var k=obj.value.lastIndexOf("\\");
       var str=obj.value.substring(k+1);
       var divs=document.getElementById("ShowDIV"+MouseOnRowIndex).getElementsByTagName("div");
       var check=false;

       for(var i=0;i<divs.length;i++)
       {
         if(divs[i].innerHTML.indexOf(str)!=-1)   
         {
              check=true;
              break;
         }
       }
       if(!check)
       {
           Allupfiled++;
           SetIframeInput(obj,inputCount,str,tableID,TempFile);
       }
       else
       {
           alert("不允许添加同名附件！请重命名！");
           return;
       }
   }
}
	    
function DownFile(obj)
{
    if(obj.systemName!=null && obj.systemName!="")
    {
            //调用服务端方法
            //调用方法:类名.方法名 (参数为指定一个回调函数)
            try{
            var xmldom = getXmlDom(decodeURIComponent(getfiledName().value));
            open("/WebControls/UserControl/DownFile.aspx?str="+encodeURIComponent(obj.systemName)+"&all="+encodeURIComponent($('Rows[id="'+obj.systemName+'"]',xmldom).get(0).getElementsByTagName('FileName')[0].text));
         }catch(e){alert(e)};
     }
}  
//非修改类附件下载
function DownFile_2(filename,sys_filename)
{
        //调用服务端方法
        //调用方法:类名.方法名 (参数为指定一个回调函数)
        try{
        open("/WebControls/UserControl/DownFile.aspx?str="+encodeURIComponent(sys_filename)+"&all="+encodeURIComponent(filename));
     }catch(e){alert(e)};
}
function Loadxmsszl(tabelID,jsonObj,addLoop)
{
    for(var i=0;i<jsonObj.length;i++)
    {
        loadTable_JD(tabelID,jsonObj[i],addLoop);
    }
}
//显示附件，并显示删除按钮
//loop 判断是否是表头
function AddShowFile(filetxtDiv,_rowIndex,str,upedfilename,tabelID,detailNum)
{
    var filedownAreaNum = document.getElementById("filedownArea"+detailNum);//下载DIV
    if(filedownAreaNum!=null){
        filedownAreaNum.setAttribute('systemName',upedfilename);
        filedownAreaNum.style.cursor='hand'
        filedownAreaNum.onclick=function(){DownFile(this);}
    }
        
    Endupfiled++;
    var filedNames=getfiledName();
    var contxt=document.createElement("div");//显示附件名称用的div
    
    //contxt.id=input.id+"text";//显示用的div(contxt)的ID
    contxt.innerHTML="<a style='cursor:hand;' href=\"javascript:void(0);\" systemName='"+upedfilename+"' onclick='DownFile(this);'>"+str+"</a>&nbsp;&nbsp;";//contxt的innerHTML（显示内容）
    contxt.className="";
    filetxtDiv.appendChild(contxt);//添加一个显示附件内容的div
    
    var imgs=document.createElement('img');//删除按钮
    imgs.uid = "ImgDeleteFile";
    imgs.src=path+"images/f2.gif";
    imgs.style.cursor="hand";
    imgs.onclick=Dispose;//删除事件
    contxt.appendChild(imgs);//添加删除按钮
    
    
//    var statediv=document.createElement("span");//状态div
//    statediv.style.color="#ff0000";
//    statediv.innerHTML="&nbsp;&nbsp;上传成功";
//    contxt.appendChild(statediv);//添加状态div

    filedNames.value = FileXmlCZ(filedNames.value,tabelID,_rowIndex,upedfilename,str,true);
    
//        if(filedNames.value=="")
//        {
//            filedNames.value=_rowIndex+"-"+upedfilename+":"+str;
//        }
//        else
//        {
//            filedNames.value+="|"+_rowIndex+"-"+upedfilename+":"+str;
//        }
    
     function Dispose()//删除事件
     {
         filetxtDiv.removeChild(contxt);
         if(upedfilename)
         {try{
             if(upedfilename.length>3)
             {
                filedNames.value = FileXmlCZ(filedNames.value,tabelID,_rowIndex,upedfilename,str,false);
                if(filedownAreaNum!=null)
                    filedownAreaNum.systemName='';
                
//                 var upFileName=_rowIndex+"-"+upedfilename;
//                 if(upedfilename+":"+str==filedNames.value.substring(filedNames.value.indexOf('-')+1))
//                 {
//                     filedNames.value="";
//                 }
//                 else if(filedNames.value.indexOf(upedfilename)<5)
//                 {
//                     filedNames.value=filedNames.value.substring(filedNames.value.indexOf('-')+1);
//                     
//                     filedNames.value=filedNames.value.replace(upedfilename+":","");
//                     filedNames.value=filedNames.value.replace(str+"|","");
//                 }else{
//                     var tempIndex = filedNames.value.indexOf(upedfilename);
//                     var tempLastIndex = filedNames.value.lastIndexOf('|',tempIndex);
//                     var tempLastIndex2 = filedNames.value.lastIndexOf('-',tempIndex);
//                     filedNames.value = filedNames.value.substring(0,tempLastIndex)+filedNames.value.substring(tempLastIndex2+1);
//                     
//                     filedNames.value=filedNames.value.replace(upedfilename,""); 
//                     filedNames.value=filedNames.value.replace(":"+str,""); 
//                 }
             }}catch(e){alert(e)};
         }
     }
}

function AddShowFileNotDel(filetxtDiv,rowIndex,filename,sys_filename,tableID,detailNum)
{
    var contxt=document.createElement("div");//显示附件名称用的div
    contxt.innerHTML="<a style='cursor:hand;' href=\"javascript:void(0);\" onclick='DownFile_2(\""+filename+"\",\""+sys_filename+"\");'>"+filename+"</a>&nbsp;&nbsp;";//contxt的innerHTML（显示内容）
    contxt.className="";
    filetxtDiv.appendChild(contxt);//添加一个显示附件内容的div
    
    if(filedownAreaNum!=null){
        var filedownAreaNum = document.getElementById("filedownArea"+detailNum);//下载DIV
            filedownAreaNum.setAttribute('systemName',upedfilename);
            filedownAreaNum.style.cursor='hand'
            filedownAreaNum.onclick=function(){DownFile(this);}
    }
}

//获取触发事件源
function getEventItem()
{
    try{
        var ev = window.event || arguments.callee.caller.arguments[0]
        var et = ev.srcElement || ev.target;
        return et
    }catch(e){alert(e)};
}

//function SubmitV()
//{    
//    var errText=toYanZheng(gvResult_htgl);
//    alert("gvResult_htgl Row="+gvResult_htgl.rows.length);
//    if(errText!="")
//    {
//        alert(errText);return false;
//    }
//    errText=toYanZheng(gvResult_htbggl);
//    alert("gvResult_htbggl Row="+gvResult_htbggl.rows.length);
//    if(errText!="")
//    {
//        alert(errText);return false;
//    }
//    errText=toYanZheng(gvResult_xmssjk);
//    alert("gvResult_xmssjk Row="+gvResult_xmssjk.rows.length);
//    if(errText!="")
//    {
//        alert(errText);return false;
//    }
//    errText=toYanZheng(gvResult_xmccxc);
//    alert("gvResult_xmccxc Row="+gvResult_xmccxc.rows.length);
//    if(errText!="")
//    {
//        alert(errText);return false;
//    }
//     return false;
//}
//function toYanZheng(table)
//{
//    for(var i=1;i<table.rows.length;i++)
//    {
//        try{
//            for(var j=1;j<table.rows[i].cells.length;j++)
//            {
//                switch(j)
//                {
//                    case 0:
//                        break;
//                    default:
//                    try{
//                        alert(table.rows[i].cells[j].firstChild.value);
//                         alert(table.rows[i].cells[j].firstChild.value==null||trim(table.rows[i].cells[j].firstChild.value)=="");
//                        if(table.rows[i].cells[j].firstChild.value==null||trim(table.rows[i].cells[j].firstChild.value)=="")
//                        {alert("ys:"+table.rows[0].cells[j].innerText+"不能为空")
//                            return table.rows[0].cells[j].innerText+"不能为空";
//                        }
//                        }catch(e){alert(e)};
//                        break;
//                }
//            }
//        }catch(e){alert(e)}
//    }
//    return "";
//}

function trim(str){ //删除左右两端的空格
    if(str!=null){
	str = str.replace(/(^\s*)|(\s*$)/g, "");
　　return str;
　　}
　　else
　　    return "";
}

function tbdel(tableID)  
{
   var tb_cb = document.getElementsByName(tableID+"_cb");
   var table = document.getElementById(tableID);
   for(var i=tb_cb.length-1;i>=0;i--)
   {
       try{
       if(tb_cb[i].checked)
       {
           var Row=tb_cb[i].parentNode.parentNode;
           table.deleteRow(Row.rowIndex);
       }
       }catch(e){alert(e)}
   }
}

function tableJDdel(tableID,_FileCellIndex)  
{
   var tb_cb = document.getElementsByName(tableID+"_cb");
   var table = document.getElementById(tableID);
   var systemName = "";
   for(var i=tb_cb.length-1;i>=0;i--)
   {
       try{
       if(tb_cb[i].checked)
       {
           var Row=tb_cb[i].parentNode.parentNode;
           if($("img[uid='ImgDeleteFile']",Row).length!=0)
           {
               DelA=$("img[uid='ImgDeleteFile']",Row).get(0);
               if(DelA.parentNode.firstChild.innerHTML!="")
               {
                   systemName = DelA.parentNode.firstChild.systemName;
                   DelA.click();
               }
           }
           table.deleteRow(Row.rowIndex);
       }
       }catch(e){alert(e)}
   }
   try{
   if(getfiledName().value!="")
   {
       var xmldom=getXmlDom(getfiledName().value);
       
       for(var i=1;i<table.rows.length;i++)
       {
            if(!isNaN(systemName) && systemName!="")
            {//alert(1);
                 var row = $('Rows[id="'+systemName+'"]',xmldom)
                 var row = $('rowIndex',row).text(table.rows[i].rowIndex);
            }
 	        
       }
       getfiledName().value = xmldom.xml;
       //alert(getfiledName().value)
   }
   }catch(e){alert("tableJDdel:Err. mess:"+e)}
//   try{
//   if(getfiledName().value!="")
//   {
//       var FNAll=getfiledName().value.split('|');
//       
//       for(var i=1;i<table.rows.length;i++)
//       {
//               if(table.rows[i].cells[_FileCellIndex].lastChild.lastChild.innerHTML!="")
//               {
//                    var ShowFileName = table.rows[i].cells[_FileCellIndex].lastChild.lastChild.firstChild.getElementsByTagName("a")[0].innerHTML;
//                    for(var j=0;j<FNAll.length;j++)
//                    {
//                        if(FNAll[j].split(':')[1]==ShowFileName)
//                        {
//                            FNAll[j]=table.rows[i].rowIndex+FNAll[j].substring(FNAll[j].indexOf('-'));
//                        }
//                    }
//               }
// 	        
//       }
//       getfiledName().value=FNAll.join("|");
//       //alert(getfiledName().value)
//   }
//   }catch(e){alert(e)}
}

function getXmlDom(xmlstr)
{
    var xmldom = null;
    
    //xmldom=$(xmlstr);
//    xmldom = Ext.DomHelper.createTemplate(xmlstr);
    if(navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
    {
        xmldom=new ActiveXObject("Microsoft.XMLDOM");
        xmldom.loadXML(xmlstr);
    }
    else
        xmldom=new DOMParser().parseFromString(xmlstr,"text/xml");
    return xmldom;
}
function FileXmlCZ(xmlstr,tableID,_rowIndex,SystemName,ShowText,addBool) {
try{
    if(xmlstr==null || (xmlstr!=null&&xmlstr==""))
    {
//        $("form").append("<div id='fileString' style='display:none;'></div>");
        
        xmlstr="<xml></xml>";
    }
    var xmldom = getXmlDom(decodeURIComponent(xmlstr));

    if(addBool)
    {
//        $("#fileString").append("<Rows id='"+SystemName+"'><tableID>"+tableID+"</tableID><rowIndex>"+_rowIndex+"</rowIndex><FileSysName>"+SystemName+"</FileSysName><FileName>"+ShowText+"</FileName></Rows>");

//        alert( $("#fileString").html());
        var Rows = xmldom.createElement("Rows");
        Rows.setAttribute("id",SystemName);
        
        var itemTable = xmldom.createElement("tableID");
        itemTable.text=tableID;
        var rowIndex = xmldom.createElement("rowIndex");
        rowIndex.text=_rowIndex;
        
        var FileSysName = xmldom.createElement("FileSysName");
        FileSysName.text=SystemName;
        var FileName = xmldom.createElement("FileName");
        FileName.text=ShowText;
        
        $(Rows).append(itemTable);
        $(Rows).append(rowIndex);
        $(Rows).append(FileSysName);
        $(Rows).append(FileName);
        
        var xml = xmldom.getElementsByTagName("xml");
        if(xml.length>0)
            xmldom.getElementsByTagName("xml")[0].appendChild(Rows);
        else
            $('xml',xmldom).eq(0).append(Rows);
    }else
    {
        try{
            $('Rows[id="'+SystemName+'"]',xmldom).remove();
        }catch(e){alert(e+"；RowsRemove")};
    }
    //return $("#fileString").html()
    //alert(xmldom.xml);
    return encodeURIComponent(xmldom.xml);
    }catch(e){alert(e)}
}