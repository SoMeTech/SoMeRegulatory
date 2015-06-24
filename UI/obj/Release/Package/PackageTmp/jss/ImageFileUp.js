//input:上传控件
function LoadUp(obj,input,iframename,ImagePath)
{
 
    var inputFather=input.parentNode;
    var body = document.body; //页面body

	iframe = document.createElement( info.ie ? "<iframe name=\"" + iframename + "\">" : "iframe");

	iframe.name = iframename;
	iframe.style.display = "none";
	body.insertBefore( iframe, body.childNodes[0]);	
	
    var form=document.createElement('form');//创建表单
	form.target=iframename;
    form.method="post";
    form.encoding="multipart/form-data";
    form.action=path+"Fileup.ashx?filepath="+ImagePath;
  
 
    //form.action="UserControls/CallBack.aspx";
    body.insertBefore( form, body.childNodes[0]);
    
    //添加控件进form
    form.appendChild(input);
    
        
 
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
         inputFather.insertBefore(input,obj);
         try
         {
              var value =iframe.contentWindow.document.body.innerHTML;
              upedfilename=value.substring(value.indexOf("@returnstart@")+13,value.indexOf("@returnend@"));
              if(upedfilename.length>3)//正常上传，返回上传后文件名
              {
                  finished();
              }
              else
              {
                    alert('err');
                //停止上传，从StopUpLoad.ashx页面返回空值，也可能是返回错误001，000
              }
          }
          catch(msg)
          {
            //上传失败
          }
     }
    function finished()//上传完毕
    {
        alert('ok');
    }
    function errupload()
    {
        
    }
}