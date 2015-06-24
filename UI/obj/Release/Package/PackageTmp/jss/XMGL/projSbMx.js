
    function ClientSubmit()
    {
//        if($("#tb_tzjgc_1").get(0).rows.length<=1)
//        {
//            removeWindowFull();
//            Ext.Msg.alert("消息提示框", "投资及构成不能为空。");
//            $("input[uid='ibtid']").get(0).value='';
//            return false;
//        }
        //判断指标金额是否大于剩余金额，By LuBin Insert
        var quota="";
        $("input#TB_QUOTA_CODE",$("#tb_tzjgc_1")).each(function(){
            if(this.value!="")
            {
                var money = $("input#PD_PROJECT_MONEY_CZ_SJ",this.parentNode.parentNode).eq(0).val();
                quota += ",{code:\""+this.value+"\", money:\""+money+"\"}";
            }
        });
        var ref=false;
        $.ajax({
            type: "POST",
            url: "../../Work/XMGL/publicBll.ashx",
            data: "loop=SubSb_Quota&quota={t1:["+quota.substring(1)+"]}&pd_project_code="+$("input[uid='txtPD_PROJECT_CODE']").eq(0).val(),
            async: false ,
            dataType: 'text',
            error: function(){alert('Add ajax err!!');removeWindowFull(); return false;},
            success: function(result) { 
                var json=eval(result)[0];
                if(json.ref==0)
                {
                    var Message="";
                    $("input#TB_QUOTA_CODE",$("#tb_tzjgc_1")).each(function(){
                        if(this.value==json.code)
                        {
                           Message = "投资及构成中指标文号为："+ $("input#TB_QUOTA_ZBWH_H",this.parentNode.parentNode).eq(0).val()+" 的金额已经超过了指标剩余额度("+json.money+"元)，请修改！";
                        }
                    });
                    if(Message=="")
                        Message = "投资及构成中选择的指标中有金额已经超过了指标剩余额度("+json.money+"元)，请修改！";
                    alert(Message);
                    try{
                        removeWindowFull();
                    }catch(e){}
                    ref = false;
                    return false;
                }
                else
                    ref=true;
            }
        }); 
        if(ref){
            try{ return PublicYanZheng();
                }catch(e){alert(e);}
        }else
            return false;
    }
    
    
    function SumMoney_TZGC()
    {
        var Sj=0,Bj=0,Zc=0,Qt=0;
        
        var CaiZhengZiJin=0,TouZiZongE=0;
        $("input[name='PD_PROJECT_MONEY_CZ_SJ']").each(function(){
            var _tr=this.parentNode.parentNode;
            if(!isNaN(parseFloat(this.value))){
                this.value=parseFloat(this.value).toFixed(2);
                if($("select#PD_BASE_TZJGC",_tr).eq(0).val()<=2)
                    CaiZhengZiJin+=parseFloat(this.value);
                    
                switch($("select#PD_BASE_TZJGC",_tr).eq(0).val())
                {
                    case "1":Sj += parseFloat(this.value); break;
                    case "2":Bj += parseFloat(this.value); break;
                    case "3":Zc += parseFloat(this.value); break;
                    case "4":Qt += parseFloat(this.value); break;
                }
                
                TouZiZongE+=parseFloat(this.value);
            }
        });
        $("input[uid='txtPD_PROJECT_MONEY_CZ_SJ']").eq(0).val(Sj);
        $("input[uid='txtPD_PROJECT_MONEY_CZ_BJ']").eq(0).val(Bj);
        $("input[uid='txtPD_PROJECT_MONEY_ZC']").eq(0).val(Zc);
        $("input[uid='txtPD_PROJECT_MONEY_QT']").eq(0).val(Qt);
//        //申请投资总额
//        var sqtzze = $('input[uid="txtPD_PROJECT_MONEY_TOTAL_PF"]').get(0);
//        //财政资金总额
//        var czzjze =  $('input[uid="txtPD_PROJECT_MONEY_CZ_TOTAL_PF"]').get(0);
//        //上级财政资金
//        var sj = $('input[uid="txtPD_PROJECT_MONEY_CZ_SJ_PF"]').get(0); 
//        //本机
//        var bj = $('input[uid="txtPD_PROJECT_MONEY_CZ_BJ_PF"]').get(0);
//        //自筹
//        var zc = $('input[uid="txtPD_PROJECT_MONEY_ZC_PF"]').get(0);
//        //其他
//        var Otherzj = $('input[uid="txtPD_PROJECT_MONEY_QT_PF"]').get(0);
//        
//        if(sj.value!=''&&bj.value!='')
//            czzjze.value=parseFloat(sj.value)+parseFloat(bj.value);
//        else
//            czzjze.value='';
//            
//        if(czzjze.value!=''&&zc.value!=''&&Otherzj.value!='')
//            sqtzze.value=parseFloat(czzjze.value)+parseFloat(zc.value)+parseFloat(Otherzj.value);
//        else
//            sqtzze.value='';
        $('input[uid="txtPD_PROJECT_MONEY_TOTAL_PF"]').eq(0).val(parseFloat(TouZiZongE).toFixed(2));
        $('input[uid="txtPD_PROJECT_MONEY_CZ_TOTAL_PF"]').eq(0).val(parseFloat(CaiZhengZiJin).toFixed(2));
    }
    function tzgc_hidde(obj)
    {
        var _td=obj.parentNode;
        var _tr=_td.parentNode;
        
        $("input#TB_QUOTA_CODE",_tr).eq(0).val('');
        $("input#TB_QUOTA_ZBWH_H",_tr).eq(0).val('');
        $("input#PD_PROJECT_MONEY_CZ_SJ",_tr).eq(0).val('');
        $("a#PD_GK_DEPART_A",_tr).get(0).innerHTML='&nbsp;';
        $("a#PD_PROJECT_FILENO_JG_A",_tr).get(0).innerHTML='&nbsp;';
        $("a#PD_PROJECT_ZJLY_A",_tr).get(0).innerHTML='&nbsp;';
        $("a#PD_PROJECT_ZGKJ_A",_tr).get(0).innerHTML='&nbsp;';
//        $("input#PD_GK_DEPART",_tr).eq(0).val('');
//        $("input#PD_PROJECT_FILENO_JG",_tr).eq(0).val('');
//        $("input#PD_PROJECT_ZJLY",_tr).eq(0).val('');
//        $("input#PD_PROJECT_ZGKJ",_tr).eq(0).val('');

        if(obj.options[obj.selectedIndex].isGetQuota==1)
            $("input#TB_QUOTA_ZBWH_H",_tr).removeAttr("disabled");
        else
            $("input#TB_QUOTA_ZBWH_H",_tr).attr({disabled:"disabled"});
    }
    var SelectTZJGCStr;
    function tb_tzgc_Add(tbID)
    {try{
        var tableID='#'+tbID;
        var table=$(tableID).get(0);
        if(SelectTZJGCStr==null)
        {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "SbMx.aspx/getTZJGC", 
                data: "{selectValue:''}",
                async: false ,
                dataType: 'json',
                error: function(){alert('Add ajax err!!')},
                success: function(result) { 
                    SelectTZJGCStr = result.d.toString();
                }
            }); 
        }
        if(SelectTZJGCStr==null)
            return;
            
        var users = [{ CHECKBOX: '<input type="checkbox" name="'+tbID+'_cb" >',PD_BASE_TZJGC: SelectTZJGCStr,TB_QUOTA_CODE:'<input id="TB_QUOTA_ZBWH_H" style="width: 98%;" readonly="readonly" onclick="javascript:findwindow(1,this);" /><input type="hidden" name="TB_QUOTA_CODE" id="TB_QUOTA_CODE"/>',PD_PROJECT_MONEY_CZ_SJ:'<input type="text" name="PD_PROJECT_MONEY_CZ_SJ" id="PD_PROJECT_MONEY_CZ_SJ"  onchange="SumMoney_TZGC()" onKeyPress="myKeyDown(this,event,0)" class="NumTextCss" />', PD_GK_DEPART: '<a id="PD_GK_DEPART_A">&nbsp;</a>', PD_PROJECT_FILENO_JG: '<a id="PD_PROJECT_FILENO_JG_A">&nbsp;</a>', PD_PROJECT_ZJLY: '<a id="PD_PROJECT_ZJLY_A">&nbsp;</a>', PD_PROJECT_ZGKJ: '<a id="PD_PROJECT_ZGKJ_A">&nbsp;</a>' }]; 
        
//        var users = [{ CheckBox: '<input type="checkbox" name="'+tbID+'_cb" >',PD_BASE_TZJGC: SelectTZJGCStr,TB_QUOTA_ZBWH:'<input id="TB_QUOTA_ZBWH_H" style="width: 98%;" readonly="readonly" onclick="javascript:findwindow(1,this);" /><input type="hidden" name="TB_QUOTA_ZBWH" id="TB_QUOTA_ZBWH"/>',PD_PROJECT_MONEY_CZ_SJ:'<input type="text" name="PD_PROJECT_MONEY_CZ_SJ" id="PD_PROJECT_MONEY_CZ_SJ"/>', PD_GK_DEPART: '<a id="PD_GK_DEPART_A">&nbsp;</a><input id="PD_GK_DEPART" name="PD_GK_DEPART" type="hidden" />', PD_PROJECT_FILENO_JG: '<a id="PD_PROJECT_FILENO_JG_A">&nbsp;</a><input id="PD_PROJECT_FILENO_JG" name="PD_PROJECT_FILENO_JG" type="hidden" />', PD_PROJECT_ZJLY: '<a id="PD_PROJECT_ZJLY_A">&nbsp;</a><input id="PD_PROJECT_ZJLY" name="PD_PROJECT_ZJLY" type="hidden" />', PD_PROJECT_ZGKJ: '<a id="PD_PROJECT_ZGKJ_A">&nbsp;</a><input id="PD_PROJECT_ZGKJ" name="PD_PROJECT_ZGKJ" type="hidden" />' }]; 
        
        $('#myTemplate').tmpl(users).appendTo(tableID); 
        
//        var tr= document.createElement("<tr>");
//        tr.appendChild("<td>222</td>");
//        alert(table.lastChild.innerHTML);
//        alert(tr.innerHTML);
//        table.appendChild(table.lastChild.cloneNode(true));
//        var _tr = table.insertRow(-1);
//        var _td=_tr.insertCell(0);
//        _td.innerHTML="6700";
        //tr.innerHTML="<td>222</td>";//<input type='checkbox' name='"+tableID+"_cb' />
        }catch(e){alert(e)};
    }
    function pd_quota(obj,_event)
    {
        if(_event.keyCode==9)
            return;
        if(_event.keyCode==17){
            _event.returnValue = false;
            return;
        }
//        var _tr=obj.parentNode.parentNode;
//        var _select = $("select#PD_BASE_TZJGC",_tr).get(0);
//        if(_select.options[_select.selectedIndex].isGetQuota==1)
//        {
//            var TB_QUOTA_CODE = $("input#TB_QUOTA_CODE",_tr).eq(0).val();
//            if(trim(TB_QUOTA_CODE)=="")
//            {
//                alert("请先选择指标，才能进行金额的修改！");
//                _event.returnValue = false;
//            }
//        }
    }
    
    function tb_tzgc_Del(tableID)
    {
        var tb_cb=$("input[name='"+tableID+"_cb']");
        var tbID="#"+tableID;
        var table=$(tbID).get(0);
        for(var i=tb_cb.length-1;i>=0;i--)
        {
           try{
           if(tb_cb[i].checked)
           {
               var _tr=tb_cb[i].parentNode.parentNode;
               table.deleteRow(_tr.rowIndex);
           }
           }catch(e){alert(e)}
        }
    }
    function ShowTZGCAll()
    {
        var PD_PROJECT_CODE = $("input[uid='txtPD_PROJECT_CODE']").eq(0).val();
        if(isNaN(PD_PROJECT_CODE)||PD_PROJECT_CODE=='')
            return;
        $.ajax({
            type: "POST",
            url: "SbMx.aspx/getTZJGCAll", 
            contentType: "application/json",
            data: "{PD_PROJECT_CODE:'"+PD_PROJECT_CODE+"'}",
            async: true ,
            dataType: 'json',
            error: function(){alert('Add ajax err!!')},
            success: function(result) { try{
                $('#myTemplate').tmpl(eval(result.d)).appendTo("#tb_tzjgc_1");
                }catch(e){alert(e)};
            }
        });
    }