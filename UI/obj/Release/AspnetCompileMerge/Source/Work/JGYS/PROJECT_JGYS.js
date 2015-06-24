function IsOnSubmit()
{
    var strErr='';
    if (trim($("select[uid='txtPD_PROJECT_COMPLETE_DATE']").get(0).value)=='')
    {
        strErr += "项目竣工日期格式错误！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YSSQ_DATE']").get(0).value)=='')
    {
        strErr += "项目验收申请日期格式错误！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YS_DATE']").get(0).value)=='')
    {
        strErr += "项目验收日期格式错误！";
    }
    else if (trim($("select[uid='ddlPD_PROJECT_YS_COMPANY']").get(0).value)=='')
    {
        strErr += "项目验收单位不能为空！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YS_ZRR']").get(0).value)=='')
    {
        strErr += "项目验收责任人不能为空！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YS_NAME']").get(0).value)=='')
    {
        strErr += "项目验收人员名单不能为空！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YS_SUGGEST']").get(0).value)=='')
    {
        strErr += "项目验收意见不能为空！";
    }
    else if (trim($("select[uid='ddlPD_PROJECT_YS_RESULT']").get(0).value)=='')
    {
        strErr += "项目验收结论不能为空！";
    }
    else if (trim($("input[uid='txtPD_PROJECT_YS_CONDITION']").get(0).value)=='')
    {
        strErr += "存在主要问题整改不能为空！";
    }
    
    if(strErr!='')
    {
        Ext.Msg.alert("消息提示框", strErr);
        $("input[uid='ibtid']").get(0).value='';
        return false;
    }
    return true;
}
