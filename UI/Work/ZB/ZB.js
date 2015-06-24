function PublicYanZheng()
{
    if($("input[uid='ibtid']").get(0).value!="ibtcontrol_ibtsave")
        return true;
    var strErr='';
    if (trim($("input[uid='txtPD_QUOTA_ZBWH']").get(0).value) == '')
    {
        strErr += "指标文号不能为空！";
        //$("input[uid='txtPD_QUOTA_NAME']").get(0).style.backgroundColor='#F08080';
    }
    else if (trim($("input[uid='txtPD_QUOTA_NAME']").get(0).value) == '')
    {
        strErr += "文件名称不能为空！";
        //$("input[uid='txtPD_QUOTA_NAME']").get(0).style.backgroundColor='#F08080';
    }
    else if($("select[uid='ddlzjly']").get(0).value!='01' && $("select[uid='ddlzgkj']").get(0).value=='-1')
    {
        strErr += "请选择主管科局！";
    }
    else if (trim($("select[uid='ddlPD_YEAR']").get(0).value) == '')
    {
        strErr += "文件年度不能为空！";
    }
    else if (trim($("input[name='ctl00$ContentPlaceHolder1$txtPD_QUOTA_FWDATA']").val()) == '')
    {
        strErr += "发文日期不能为空！";
    }
    else if (trim($("select[uid='ddlPD_QUOTA_ZJXZ']").get(0).value) == '')
    {
        strErr += "资金性质不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_COMPANY']").get(0).value) == '')
    {
        strErr += "资金使用单位不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_MONEY_TOTAL']").get(0).value) == '')
    {
        strErr += "指标额度不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_ZBXDZH']").get(0).value) == '') {
        strErr += "指标下达总额不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_ZBYT']").get(0).value) == '')
    {
        strErr += "财政资金用途不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_GLLX']").get(0).value) == '')
    {
        strErr += "功能分类科目不能为空！";
    }
    else if (trim($("input[uid='txtPD_QUOTA_JJLX']").get(0).value) == '')
    {
        strErr += "经济分类科目不能为空！";
    }
    else if (trim($("textarea[uid='txtPD_QUOTA_JGYQ']").get(0).value) == '')
    {
        strErr += "监管要求不能为空！";
    }
    else if (parseFloat(trim($("input[uid='txtPD_QUOTA_ZBXDZH']").get(0).value)) > parseFloat(trim($("input[uid='txtPD_QUOTA_MONEY_TOTAL']").get(0).value)))
    {
        strErr += "指标下达总额 不允许超过 指标额度！";
    }
    else if (!$("input[uid='txtPD_QUOTA_ZBWH']").get(0).disabled && pd_IsZBWH($("input[uid='txtPD_QUOTA_ZBWH']").get(0).value))
    {
        strErr += "指标文号已存在,请重新输入！";
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
function t_change_zbwh(obj)
{
    saixZF(obj);
    if(parseInt($("input[uid='PD_QUOTA_PICI']").get(0).value)==1)
    {
        if(trim(obj.value)!="" && pd_IsZBWH(obj.value))
        {
            alert("指标文号已存在,请重新输入！");
            obj.focus();
            obj.select();
        }
    }
}
function pd_IsZBWH(zbwh)
{
    var rStr=false;
    if(parseInt($("input[uid='PD_QUOTA_PICI']").get(0).value)==1)
    {
        var CODE = $("input[uid='txtPD_QUOTA_CODE']").get(0).value;
        $.ajax({
            url: "/Work/XMGL/publicBll.ashx?loop=pd_IsZBWH&zbwh=" + encodeURIComponent(zbwh) + "&code=" + encodeURIComponent(CODE),
            type: "post",
            dataType: "text",
            async: false ,
            error: function(e){alert("load database error !!"); rStr=true;},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
               rStr = (msg=="true");
            }
       });
   }
   return rStr;
}

function PostLoadxmsszl(tableID,json,addLoop)
{
    Loadxmsszl(tableID,json,addLoop);
}
function loadTable_add(tableID,dataHidden,loop){
    loadTable_JD(tableID,eval(decodeURIComponent($("input[uid='dataHidden']").get(0).value))[0],loop);
}
$(document).ready(function(){
    RunBindJS($("input[uid='LoginCompany']").eq(0).val());
    //绑定弹出气泡
    BindQiPao();
});
function RunBindJS(LoginCompany)
{
    try{
    //alert(eval(decodeURIComponent($("input[uid='json_xzxxData']").get(0).value)).length);
    PostLoadxmsszl('table_xzxx',eval(decodeURIComponent($("input[uid='json_xzxxData']").get(0).value)),'bz_xzxx');
    Bind_tbHead(eval(decodeURIComponent($("input[uid='json_btData']").get(0).value))[0],10000,'zxzb_bt',5);
    $("input[uid='txtPD_QUOTA_CODE']").get(0).style.display="none";
    
    if($("input[uid='txtPD_QUOTA_CODE']").get(0).value==null||$("input[uid='txtPD_QUOTA_CODE']").get(0).value==""||eval(decodeURIComponent($("input[uid='json_xzxxData']").get(0).value)).length==0)
       getAllxzxx(LoginCompany);
    if($("input[id='ibtcontrol_ibtsave']").length<=0)
    {
        $("div[uid='div_PasteData']").get(0).onkeydown="";
    }else
        BindDate($("input[uid='txtPD_QUOTA_FWDATA']").get(0).id);
    //setHeight();
    }catch(e){alert(e)}
    
    //setMenuHeight();
}

function addZGBM(obj)
{
    if(obj.value!="-1")
        $("input[uid='txtPD_QUOTA_ZGBM']").get(0).value=obj.options[obj.selectedIndex].text;
    else
        $("input[uid='txtPD_QUOTA_ZGBM']").get(0).value='乡镇人民政府';
}
function setExcel(tableID)
{
    var txt = getClipboard();
    var Rows=txt.split('\r\n');
    $("a[name='aCompanyName']").each(function(){
        for(var i=0;i<Rows.length;i++)
        {
            var column = Rows[i].split('\t');
            if(column.length==2){
                if(trim(this.innerText)==trim(column[0]))
                {
                    if(parseFloat(column[1]).toString()!='NaN'){
//                        this.parentNode.nextSibling.childNodes[0].value=(parseFloat(column[1])/10000).toFixed(4);
                        this.parentNode.nextSibling.childNodes[0].value=(parseFloat(column[1])).toFixed(2);
                    }
                }
            }
        }
    });
//            $("select[name='PD_Company_NAME']").each(function(){
//                if(trim(this.options[this.selectedIndex].text)==trim(column[0]))
//                {
//                    if(parseFloat(column[1]).toString()!='NaN')
//                        this.parentNode.nextSibling.childNodes[0].value=(parseFloat(column[1])/10000).toFixed(4);
//                }
//            });
    sumMoney(tableID);
}
function KeyDown(tableID){ //屏蔽鼠标右键、Ctrl+n、shift+F10、F5刷新、退格键    
    if ((event.ctrlKey)&&(event.keyCode==86)) //屏蔽 Ctrl+V    
    {
        setExcel(tableID);
        event.keyCode=0;   
        event.returnValue=false;   
    }   
}

function saixZF(obj)
{
    while(obj.value.indexOf("【")>=0||obj.value.indexOf("】")>=0)
    {
        obj.value=obj.value.replace("【","[");
        obj.value=obj.value.replace("】","]");
    }
//    var insertIndex = getCursorPos(obj);
//    var objValue=obj.value.substring(0,insertIndex)+String.fromCharCode(oEvent.keyCode)+obj.value.substring(insertIndex);
//    alert(objValue);
//    if ((event.ctrlKey)&&(event.keyCode==86)) //屏蔽 Ctrl+V    
//    {
//        event.keyCode=0;
//        event.returnValue=false;  
//    }
//    alert(getCursorPos(obj,true));
    
}