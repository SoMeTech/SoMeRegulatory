var databaseSelect = null;
var extWindow=null;

function LoadSelect()
{
    var selectStr="<div style=' text-align:center; width:100%;'><table style='width:100%; text-align:center;'><tr><td colspan='2' style='height:30px;'><select id='databaseSelect' name='databaseSelect' style='width:180px; text-align:center;' onchange='qk_JD_txt()'>";
        var company = $('input[uid="company"]').get(0).value;
        $.ajax({
            url: "/Work/XMGL/publicBll.ashx?loop=OutputZJBF&company="+company,
            type: "post",
            dataType: "text",
            async: true ,
            error: function(e){alert("load database error !!");},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
               var jsonStr=eval(msg);
                $(jsonStr).each(function(i){ 
                   selectStr = selectStr+"<option value=\""+this.DATANAME+"\">"+this.SHOWNAME+"</option>";
                 });
            }
       });
    return new Ext.XTemplate(selectStr+"</select></td></tr><tr><td colspan='2' style='height:30px;'>借方科目：<input type='text' id='lbl_kjkm_JF' name='lbl_kjkm_JF' readonly='true' onclick=\"findwindow('mssql_kjkm',this)\" style='width:60%;'/><input type='hidden' id='txt_kjkm_JF' name='txt_kjkm_JF' /></td></tr><tr><td colspan='2' style='height:30px;'>贷方科目：<input type='text' id='lbl_kjkm_DF' name='lbl_kjkm_DF' readonly='true' onclick=\"findwindow('mssql_kjkm',this)\" style='width:60%;'/><input type='hidden' id='txt_kjkm_DF' name='txt_kjkm_DF' /></td></tr><tr><td colspan='2' style='height:30px;'>项目核算：<input type='text' id='lbl_fzhs' name='lbl_fzhs' readonly='true' onclick=\"findwindow('mssql_fzhs',this)\" style='width:60%;'/><input type='hidden' id='txt_fzhs' name='txt_fzhs' /></td></tr><tr><td style=' height:30px;'><button id='button_OK' onclick='submitGO()'>确定</button></td><td  style='height:30px'><button id='button_qx' onclick='extWindow.hide()'>取消</button></td></tr></table><div>");
}
function openLog()
{
    if(databaseSelect==null)
       databaseSelect = LoadSelect()
    try{
    extWindow = new Ext.Window({	title : '选择帐套',
    	width : 260,	
    	height : 210,	
    	plain : true,
    	draggable: false,
    	isTopContainer : true, //顶层显示
        modal : true, //仿模式窗体
    	closeAction : 'hide',// 关闭窗口	
    	maximizable : false,// 最大化控制 值为true时可以最大化窗体	
    	layout:'fit',	
    	items : [databaseSelect]
        });
    	
        extWindow.show();
   }catch(e){alert(e)};
}
function qk_JD_txt()
{
    $("#lbl_kjkm_JF").get(0).value='';
    $("#lbl_kjkm_DF").get(0).value='';
    $("#lbl_fzhs").get(0).value='';
    $("#txt_fzhs").get(0).value='';
    $("#txt_kjkm_JF").get(0).value='';
    $("#txt_kjkm_DF").get(0).value='';
}

function submitGO()
{
    if(document.getElementById('txt_kjkm_JF').value==null ||document.getElementById('txt_kjkm_JF').value=='')
    {
        alert('借方科目不能为空');
        return;
    }
    if(document.getElementById('txt_kjkm_DF').value==null || document.getElementById('txt_kjkm_DF').value=='')
    {
        alert('贷方科目不能为空');
        return;
    }
    
    $("input[uid='ibtid']").get(0).value = 'ibtcontrol_ibtlook2';
    $("input[uid='txt_kjkmDB_JF']").get(0).value = document.getElementById('txt_kjkm_JF').value;
    $("input[uid='txt_kjkmDB_DF']").get(0).value = document.getElementById('txt_kjkm_DF').value;
    $("input[uid='txt_fzhs_DB']").get(0).value = document.getElementById('txt_fzhs').value;
    $("input[uid='db_name']").get(0).value = document.getElementById('databaseSelect').value;
    $("form[uid='form1']").get(0).submit();   
    
}