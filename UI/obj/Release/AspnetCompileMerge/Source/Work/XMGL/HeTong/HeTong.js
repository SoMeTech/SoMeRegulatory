function IsOnSubmit()
{
    var strErr='';
    if (trim($("input[uid='txtPD_PROJECT_CODE']").get(0).value)=='')
    {
        strErr += "项目名称不能为空！";
    }
    else if (trim($("select[uid='txtPD_CONTRACT_TYPE']").get(0).value)=='')
    {
        strErr += "合同类型不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_NO']").get(0).value)=='')
    {
        strErr += "合同编号不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_DATE']").get(0).value)=='')
    {
        strErr += "合同日期不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_COMPANY']").get(0).value)=='')
    {
        strErr += "合同签约单位不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_MOENY']").get(0).value)=='')
    {
        strErr += "合同金额不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_ASK_LIMIT']").get(0).value)=='')
    {
        strErr += "合同工期要求不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_ASK_PROCEED']").get(0).value)=='')
    {
        strErr += "合同进度要求不能为空！";
    }
    else if (trim($("input[uid='txtPD_CONTRACT_ASK_PAYMENT']").get(0).value)=='')
    {
        strErr += "合同付款要求不能为空！";
    }
    else if($("select[uid='ddlPD_YEAR']").get(0).value=='')
    {
        strErr = '年度不能为空!';
    }
    
    if(strErr!='')
    {
        removeWindowFull();
        Ext.Msg.alert("消息提示框", strErr);
        $("input[uid='ibtid']").get(0).value='';
        return false;
    }
    return true;
}

function getFile(data,loop)
{
    $.ajax({
        type: "POST",   //访问WebService使用Post方式请求
        contentType: "application/json", //WebService 会返回Json类型
        url: "HeTongMx.aspx/AjxGetFile", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
        data: "{loop:"+loop+",data:'"+data+"'}",         //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到       
        dataType: 'json',
        success: function(result) {     //回调函数，result，返回值
            return eval(result);
        }
    }); 
}
function Bing_Data(){
//    var file1 = getFile(1);
//    var file2 = getFile(2);
//    Bind_tbHead(file1[0],10000,'zxzb_bt',5);
//    Bind_tbHead(file2[0],10001,'zxzb_bt',5);
//        
try{
    if($("input[id='ibtcontrol_ibtsave']").length<=0){
        if($("input[uid='json_btData']").val()!=null && $("input[uid='json_btData']").val()!="")
            Bind_tbHeadNotDel(eval(decodeURIComponent($("input[uid='json_btData']").val()))[0],10000,'zxzb_bt',5);
        if($("input[uid='json_btData2']").val()!=null && $("input[uid='json_btData2']").val()!="")
            Bind_tbHeadNotDel(eval(decodeURIComponent($("input[uid='json_btData2']").val()))[0],10001,'zxzb_bt',5);
    }else
    {
        if($("input[uid='json_btData']").val()!=null && $("input[uid='json_btData']").val()!="")
            Bind_tbHead(eval(decodeURIComponent($("input[uid='json_btData']").val()))[0],10000,'zxzb_bt',5);
        if($("input[uid='json_btData2']").val()!=null && $("input[uid='json_btData2']").val()!="")
            Bind_tbHead(eval(decodeURIComponent($("input[uid='json_btData2']").val()))[0],10001,'zxzb_bt',5);
    }
//    $(".fileinput").each(function(){
//        this.style.width=1;
//    });
    }catch(e){alert(e)};
}

function setBGJE(obj)
{
    $("input[uid='txtPD_CONTRACT_MOENY_CHANGE']").get(0).value=obj.value;
}

function csPD_PROJECT_CODE()
{
    $("input[uid='txtPD_PROJECT_CODE']").get(0).value = $("input[uid='txtPD_PROJECT_Name']").get(0).value = '';
}