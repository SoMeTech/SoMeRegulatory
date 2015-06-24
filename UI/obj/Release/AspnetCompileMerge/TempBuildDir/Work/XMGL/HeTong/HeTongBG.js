function IsOnSubmit()
{
    var strErr='';
    if($("input[uid='txtPD_PROJECT_CODE']").get(0).value=='')
    {
        strErr = '项目编码不能为空!';
    }
    else if($("input[uid='txtPD_CONTRACT_NO']").get(0).value=='')
    {
        strErr = '合同编号不能为空!';
    }
    else if($("input[uid='txtPD_CONTRACT_CHANGE_DATE']").get(0).value=='')
    {
        strErr = '变更时间不能为空!';
    }
//    else if($("input[uid='txtPD_CONTRACT_CHANGE_ZJ']").get(0).value=='')
//    {
//        strErr = '调增调减不能为空!';
//    }
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
    BindDate($("input[uid='txtPD_CONTRACT_CHANGE_DATE']").get(0).id);
    
});

function csPD_PROJECT_CODE()
{
     $("input[uid='txtPD_CONTRACT_MONEY']").get(0).value 
     = $("input[uid='txtPD_CONTRACT_NO']").get(0).value 
     = $("input[uid='txtPD_PROJECT_CODE']").get(0).value 
     = $("input[uid='txtPD_PROJECT_Name']").get(0).value = '';
}