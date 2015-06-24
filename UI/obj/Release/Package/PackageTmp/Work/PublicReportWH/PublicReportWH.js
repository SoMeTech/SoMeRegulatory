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
        Ext.Msg.alert("消息提示框", strErr);
        $("input[uid='ibtid']").get(0).value='';
        return false;
    }
    return true;
}

$(document).ready(function(){
    if($("input[uid='json_btData']").get(0).value!="")
        Bind_tbHead(eval($("input[uid='json_btData']").get(0).value)[0],10000,'zxzb_bt',5);
    BindDate($("input[uid='txtPD_CONTRACT_DATE']").get(0).id);
    
});

function setBGJE(obj)
{
    $("input[uid='txtPD_CONTRACT_MOENY_CHANGE']").get(0).value=obj.value;
}

function csPD_PROJECT_CODE()
{
    $("input[uid='txtPD_PROJECT_CODE']").get(0).value = $("input[uid='txtPD_PROJECT_Name']").get(0).value = '';
}