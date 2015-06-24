
    function getXmlDom(xmlstr)
    {
        var xmldom = null;
        if(navigator.userAgent.toLowerCase().indexOf("msie")!=-1)
        {
            xmldom=new ActiveXObject("Microsoft.XMLDOM");
            xmldom.loadXML(xmlstr);
        }
        else
            xmldom=new DOMParser().parseFromString(xmlstr,"text/xml");
        return xmldom;
    }
    function SubmitDownExcel()
    {
        $("input[uid='ibtid']").get(0).value="DownExcel";
        SJ_Data();
    }
    
    function SubmitFrom()
    {
        $("input[uid='ibtid']").get(0).value="ShowData";
        SJ_Data();
    }
    function SJ_Data()
    {
        var xmlstr="<xml></xml>";
        var xmldom = getXmlDom(decodeURIComponent(xmlstr));
        var subLoop=true;

        $("*[uid='selectInput']").each(function(i){
        
            var Rows = xmldom.createElement("Rows");
            
            var ColumnsName = xmldom.createElement("ColumnsName");
            ColumnsName.text=this.name;
            
            var datatype = xmldom.createElement("datatype");
            datatype.text=this.datatype;
            
            
            var value = xmldom.createElement("value");
            value.text=this.value;
            
            var datetime = xmldom.createElement("datetime");
            if(this.datatype=="nullType.px")
            {
                var pxStr=this.innerHTML.split(',');
                for(var i=0;i<pxStr.length;i++)
                {
                    if(trim(pxStr[i])=="")
                        continue;
                    var bool=pd_order(pxStr[i]);
                    if(!bool)
                    {
                        alert("查询条件中没有此列："+pxStr[i]+" 请重新输入！");
                        subLoop=false;
                        return false;
                    }
                }
                
                value.text=this.innerHTML;
                
                if($("input[uid='c_desc']").get(0).checked)
                    datetime.text="desc";
            }
            else
                datetime.text=this.datetime;
                
            
            $(Rows).append(ColumnsName);
            $(Rows).append(datatype);
            $(Rows).append(value);
            $(Rows).append(datetime);
            
            var xml = xmldom.getElementsByTagName("xml");
            if(xml.length>0)
                xmldom.getElementsByTagName("xml")[0].appendChild(Rows);
            else
                $('xml',xmldom).eq(0).append(Rows);
        });
        
        
        
        if(subLoop)
        {
            $("input[uid='selectXMl']").get(0).value=xmldom.xml;
            $("form").get(0).submit();   
        }
    }
    function pd_order(pxStr)
    {
        var bool=false
        $("input[uid='selectInput']").each(function(i){
            if(trim(pxStr)==trim(this.name))
            {
                bool=true;
                return false;
            }
        });
        return bool;
    }
    function setOrderby(obj)
    {
        if(trim($("#nullType_px").get(0).innerHTML)!="")
        {
            if( $("#nullType_px").get(0).innerHTML.indexOf(trim(obj.innerHTML))==-1)
                $("#nullType_px").get(0).innerHTML=$("#nullType_px").get(0).innerHTML+","+obj.innerHTML;
        }
        else
            $("#nullType_px").get(0).innerHTML=obj.innerHTML;
    }
var extWindow=null;
function ShowSelect()
{
    if(extWindow==null)
    {
    var databaseSelect = document.getElementById($("div[uid='window1']").get(0).id);
    databaseSelect.style.display="block";
    var height = databaseSelect.offsetHeight+1;
    databaseSelect.style.display="none";
    if(height>500)
        height=500;
    try{
        extWindow = new Ext.Window({
            title : '高级查询',
    	    plain : true,
    	    width : 550,
    	    draggable: true,//允许拖动和改变大小
    	    shadow:false,//去除拖动大块阴影
    	    isTopContainer : true, //顶层显示
            modal : true, //仿模式窗体
    	    closeAction : 'hide',// 关闭窗口	
    	    maximizable : false,// 最大化控制 值为true时可以最大化窗体	  
            //layout:'fit',   
    	    autoScroll: true, //滚动条
    	    bodyStyle:'position:relative;overflow-y:auto;overflow-x:auto;height:'+height+"px",
    	    items : [databaseSelect]
            });
       }catch(e){alert("function ShowSelect()"+e)};
       databaseSelect.style.display="block";
    }
    extWindow.show();
}
function setHeight()
{
    var strCookie=document.cookie;
    var arrCookie=strCookie.split("; ");
    var hei = 600;
    for(var i=0;i<arrCookie.length;i++){
        var arr=arrCookie[i].split("=");
        if("allhei"==arr[0]){
            hei=arr[1];
            break;
        }
    }
    var _height=hei-$("table[uid='tbHead']").get(0).offsetHeight;
    $("div[uid='ShowDataDiv']").get(0).style.height=_height-60;
}
$(document).ready(function(){
  try{
     //setTimeout("setHeight()",1);
     
    document.getElementById("div1").style.width =getCookie('allwid')-80;
    document.getElementById("div1").style.height =getCookie('allhei')-160;
     $("input[uid='selectInput']").each(function(i)
     {
        if(this.datatype=="System.DateTime")
        {
            BindDate(this.id);
        }
    });
    if($("input[uid='ISSHOW']").eq(0).val()=="0")
    {
        ShowSelect();
        $("input[uid='ISSHOW']").eq(0).val("1");
    }
    
    //设置下拉文本框
    $("input[datatype='System.String']").each(function(i){
//        if(this.parentNode.getAttribute('type')=="td")
        var _td = this.parentNode;
        BindTxtSelect(this,null,$("table",$("div[uid='ShowDataDiv']")).get(0),this.name);
    });
  }catch(e){alert(e)};
});
function QingKong()
{
  try{
    $("input[uid='selectInput']").attr("value","");
    //$("a[uid='selectInput']").get(0).innerHTML=""; //排序列
  }catch(e){alert(e)};
}