function IsOnSubmit()
{
    var strErr='';
    if($("input[uid='txtPD_PROJECT_CODE']").get(0).value=='')
    {
        strErr = '项目名称不能为空!';
    }
    else if($("input[uid='txtPD_INSPECTION_DATE']").get(0).value=='')
    {
        strErr = '监管时间不能为空!';
    }
    if($("input[uid='txtPD_INSPECTION_MANS']").get(0).value=='')
    {
        strErr = '监管人员不能为空!';
    }
    if($("input[uid='txtPD_INSPECTION_ADDR']").get(0).value=='')
    {
        strErr = '监管地点不能为空!';
    }
    if($("input[uid='txtPD_INSPECTION_CONTENT']").get(0).value=='')
    {
        strErr = '监管内容不能为空!';
    }
    if($("input[uid='txtPD_INSPECTION_SUGGEST']").get(0).value=='')
    {
        strErr = '监管意见不能为空!';
    }
    if($("input[uid='txtPD_INSPECTION_CONCLUSION']").get(0).value=='')
    {
        strErr = '监管结论不能为空!';
    }
    if($("input[uid='txtPD_MONITOR_PROCEED_WCL']").get(0).value=='')
    {
        strErr = '项目进度完成比例不能为空!';
    }
    else if($("select[uid='txtPD_INSPECTION_PROCESS']").get(0).value=='')
    {
        strErr = '项目过程不能为空!';
    }
    else if($("select[uid='ddlPD_YEAR']").get(0).value=='')
    {
        strErr = '年度不能为空!';
    }
    if(strErr!='')
    {
        Ext.Msg.alert("消息提示框", strErr);
        $("input[uid='ibtid']").get(0).value='';
        return false;
    }
    return true;
}

$(document).ready(function(){
    if($("input[uid='json_btData']").get(0).value!="")
        Bind_tbHead(eval($("input[uid='json_btData']").get(0).value)[0],10000,'zxzb_bt',5);
    BindDate($("input[uid='txtPD_INSPECTION_DATE']").get(0).id);
    
});


function openLog()
{
    var txtPD_PROJECT_CODE = $("input[uid='txtPD_PROJECT_CODE']").get(0);
    if(!isNaN(txtPD_PROJECT_CODE.value))
    {
        window.open("ShowHD.aspx?code="+txtPD_PROJECT_CODE.value,'','toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no,left=150,top=50');
    }
}

function csPD_PROJECT_CODE()
{
    $("input[uid='txtPD_PROJECT_CODE']").get(0).value = $("input[uid='txtPD_PROJECT_Name']").get(0).value = '';
}