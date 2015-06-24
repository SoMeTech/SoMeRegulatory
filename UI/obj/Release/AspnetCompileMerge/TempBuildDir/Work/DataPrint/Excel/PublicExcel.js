
function DownFile(obj)
{
//            alert( obj.parentNode.innerHTML);
//            alert( $("input",obj.parentNode).get(0).value);
    try{
        if($("input",obj.parentNode).eq(0).val()=="")
        {
            alert("选择的相应行不存在模板噢！请选择。");
            return;
        }
        
        if($("#iframeDown").length!=0)
        {
            document.body.removeChild($("#iframeDown").get(0));
        }
        var iframe = document.createElement("iframe");	
        iframe.id="iframeDown";	
        iframe.name="iframeDown";
        iframe.style.display = "none";
        document.body.insertBefore( iframe, document.body.childNodes[0]);	
        iframe.src="PublicExcel.ashx?type=getXmlData&id=" + $("input",obj.parentNode).eq(0).val();
    }catch(e){alert(e);}
//    
//    return;
//    $.ajax({
//        url: "PublicExcel.ashx?type=getXmlData&id=" + $("input",obj.parentNode).eq(0).val(),
//        contentType: "application/json",
//        type: "post",
//        dataType: 'text',
//        async: false ,
//        error: function(e){alert("load database error !!");},
//        success: function(msg){//msg为返回的数据，在这里做数据绑定
//            if(msg!="")
//            {
//                if($("#iframeDown").length!=0)
//                {
//                    document.body.removeChild($("#iframeDown").get(0));
//                }
//                var iframe = document.createElement("iframe");	
//                iframe.id="iframeDown";	
//                iframe.name="iframeDown";
//	            iframe.style.display = "none";
//	            document.body.insertBefore( iframe, document.body.childNodes[0]);	
//	            iframe.src="../../../WebControls/UserControl/DownFile.aspx?DefaultDown="+msg+"&all="+msg.substring(msg.lastIndexOf("/")+1);
//                
////                var form=document.createElement('form');//创建表单	
////                form.name="formDown"
////                form.target="iframeDown";
////                form.method="post";
////                form.encoding="multipart/form-data";
////                form.action="../../../WebControls/UserControl/DownFile.aspx?DefaultDown="+msg+"&all="+msg.substring(msg.lastIndexOf("/")+1);
////                document.body.insertBefore(form, document.body.childNodes[0]);	
////                form.submit();
//                
//                //window.location.href = 
////                var win = window.open("../../../WebControls/UserControl/DownFile.aspx?DefaultDown="+msg+"&all="+msg.substring(msg.lastIndexOf("/")+1)); 
//                //win.document.write("<script>window.close();</script>");
////                win.close();
//            }
//            else
//            {
//                alert("此模板似乎没有找到对应的导入列，请联系管理员！");
//            }
//            //CreateTable(eval(msg));
////                  alert(msg);
////                  alert(eval(msg)[0].COMMENTS);
////                  alert(eval(msg)[1].COMMENTS);
//        }
//    });
}
function CreateTable(json)
{
    try{
    var oXL = new ActiveXObject("Excel.Application");  
    var oWB = oXL.Workbooks.Add();
    var oSheet = oWB.ActiveSheet;  
    for(var i=0;i<json.length;i++)
    {
        oSheet.Cells(1, i+1).value = json[i].COMMENTS;
    }
    oXL.Visible = true;
    }catch(e){alert(e)}
}
var extWindow=null;
var UpFileID;
function UpFile(obj)
{
    if($("input",obj.parentNode).eq(0).val()=="")
    {
        alert("选择的相应行不存在模板噢！请选择。");
        return;
    }
    if(obj!=null){
        UpFileID = $("input",obj.parentNode).eq(0).val();
    }
    if(extWindow==null)
    {
        var _table=document.createElement("div");
        _table.innerHTML="<table width=\"80%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bordercolor=\"#999999\"> "+
          "<tr>"+
            "<td align=\"center\" style=\"width:50%;\">选择Excel数据</td>"+
            "<td align=\"center\" style=\"width:50%;\"><input type=\"file\" name=\"file1\" id=\"file1\"/></td>"+
          "</tr>"+
          "<tr>"+
            "<td colspan=\"2\" align=\"center\" style=\"\">"+
                "<button id=\"btn_ok\" onclick=\"upgo();\">确定导入</button>   "+
                "<button id=\"btn_cancel\" onclick=\"extWindow.hide()\">取消导入</button>"+
            "</td>"+
          "</tr>"+
    "</table>";
        
        var height = 48;
        if(height>500)
            height=500;
        try{
            extWindow = new Ext.Window({
                title : '数据导入',
                plain : true,
                width : 620,
                draggable: true,//允许拖动和改变大小
                shadow:false,//去除拖动大块阴影
                isTopContainer : true, //顶层显示
                modal : true, //仿模式窗体
                closeAction : 'hide',// 关闭窗口	
                maximizable : false,// 最大化控制 值为true时可以最大化窗体	  
                //layout:'fit',   
                autoScroll: true, //滚动条
                bodyStyle:'position:relative;overflow-y:auto;overflow-x:auto;height:'+height+"px",
                items : [_table]
                });
       }catch(e){alert("function ShowSelect()"+e)};
    }
    extWindow.show();
}
function upgo(obj)
{
    if($("#file1").eq(0).val()=="")
    {
        alert("请选择Excel文件");
        return;
    }
    ImgFileUp(null,$("#file1").get(0),"?temp=1",null);
    try{
    var Call = function(){backCall(UpFileID);}
    setTimeout(Call,10);
    }catch(e){alert(e)}
}
function backCall(inputValue)
{
    if($('#file1').attr('uid')==undefined)
    {
        var Call=function(){backCall(inputValue);}
        setTimeout(Call,10);
    }
    else if($('#file1').attr('err')!=undefined)
    {
        alert("获取Excel数据失败，请联系管理员！");
    }
    else
    {
        $.ajax({
            url: "PublicExcel.ashx?type=savadata&sysName=" + $('#file1').attr('uid')+"&id=" +inputValue ,
            contentType: "application/json",
            type: "post",
            dataType: 'text',
            async: true ,
            error: function(e){alert("导入数据失败，请检查Excel数据格式");},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
                if(msg=="")
                {
                    alert("导入成功！");
                    window.location.reload();
                }else
                    alert(msg);
            }
        });
    }
}