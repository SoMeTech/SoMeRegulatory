var detailNum_JD=0;
function loadTable_JD(tableID,jsonObjItem,loop)
{
    var detailNum= ++detailNum_JD;
    try{
        var table_xmsszl = document.getElementById(tableID);
        var _tr = table_xmsszl.insertRow(-1);
        switch(loop)
        {
            case 'xmss_5':
                xmss_5_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_PROJECT_ATTACH_NAME!=""&&jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM!="")
                    AddShowFile(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_PROJECT_ATTACH_NAME,jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM,tableID,detailNum);
                break;
            case 'xmpf_4':
                xmpf_4_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_PROJECT_ATTACH_NAME!=""&&jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM!="")
                    AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_PROJECT_ATTACH_NAME,jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM,detailNum);
                break;
            case "ss_table_htgl":
                table_xmsszl_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_CONTRACT_FILENAME!=""&&jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM!="")
                    AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_CONTRACT_FILENAME,jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM,tableID,detailNum);
                
                //BindDate('datetime'+detailNum);
                break;
            case "ss_table_htbggl":
                ss_table_htbggl_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_CONTRACT_CHANGE_FILENAME_SQ!=""&&jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM_SQ!="")
                    AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_CONTRACT_CHANGE_FILENAME_SQ,jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM_SQ,tableID,detailNum);
                
                //BindDate('datetime'+detailNum);
                break;
            case "ss_table_xmssjk":
                ss_table_xmssjk_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_MONITOR_FILENAME!=""&&jsonObjItem.PD_MONITOR_FILENAME_SYSTEM!="")
                    AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_MONITOR_FILENAME,jsonObjItem.PD_MONITOR_FILENAME_SYSTEM,tableID,detailNum);
                
                //BindDate('datetime'+detailNum);
                break;
            case "ss_table_xmccxc":
                ss_table_xmccxc_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.PD_INSPECTION_FILENAME!=""&&jsonObjItem.PD_INSPECTION_FILENAME_SYSTEM!="")
                    AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.PD_INSPECTION_FILENAME,jsonObjItem.PD_INSPECTION_FILENAME_SYSTEM,tableID,detailNum);
                //BindDate('datetime'+detailNum);
                break;
            case 'bz_xzxx':
                bz_xzxx_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                if(jsonObjItem.FILE_NAME!=""&&jsonObjItem.FILE_SYSNAME!="") 
                    AddShowFile(document.getElementById("ShowDIV"+detailNum),_tr.rowIndex,jsonObjItem.FILE_NAME,jsonObjItem.FILE_SYSNAME,tableID,detailNum);
                break;
            case 'bz_table_BzGGXX':
                bz_table_BzGGXX_RowAdd(tableID,jsonObjItem,_tr,detailNum);
                BindDate('datetime'+detailNum);
                break;
        }
        
        //Bind("upfile"+detailNum,detailNum);//绑定右键菜单
        
    } catch(e){alert('xmss:'+e);}
}

//补助性资金监管

function bz_table_BzGGXX_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    for(var i=0;i<19;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 1:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='BzGGXX_AUTO_NO' style=\" width:90%\" value=\""+jsonObjItem.AUTO_NO+"\"/>";
                break;
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_PROJECT_CODE' readonly='readonly' style=\" width:90%;\"  value=\""+jsonObjItem.PD_PROJECT_CODE+"\"/>";
                break;
            case 3:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_PROCESS' style=\" width:70%\" value=\""+jsonObjItem.PD_INSPECTION_PROCESS+"\"/>";
                break
            case 4:
                _td.align="center";
                _td.innerHTML="<input type='text' id='datetime"+detailNum+"' name='BzGGXX_PD_INSPECTION_DATE' readonly='readonly' style=\" width:75%\" value=\""+jsonObjItem.PD_INSPECTION_DATE+"\"/>";
                break;
            case 5:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_MANS' style=\" width:75%\" value=\""+jsonObjItem.PD_INSPECTION_MANS+"\"/>";
                break;
            case 6:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_ADDR' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_ADDR+"\"/>";
                break;
            case 7:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_CONTENT' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_CONTENT+"\"/>";
                break;
            case 8:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_SUGGEST' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_SUGGEST+"\"/>";
                break;
            case 9:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_CONCLUSION' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_CONCLUSION+"\"/>";
                break;
            case 10:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_FILENAME' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_FILENAME+"\"/>";
                break;
            case 11:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_PEASANT' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_PEASANT+"\"/>";
                break;
            case 12:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_IDNO' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_IDNO+"\"/>";
                break;
            case 13:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_FFNUM' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_FFNUM+"\"/>";
                break;
            case 14:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_FFSTAND' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_FFSTAND+"\"/>";
                break;
            case 15:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_FFMONEY' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_FFMONEY+"\"/>";
                break;
            case 16:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_ACCOUNTNO' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_ACCOUNTNO+"\"/>";
                break;
            case 17:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_PEASANT_ADDR' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_PEASANT_ADDR+"\"/>";
                break;
            case 18:
                _td.align="center";
                _td.innerHTML="<input type='text' name='BzGGXX_PD_INSPECTION_BTFFNAME' readonly='true' hiddenNum="+detailNum+" onclick=\"javascript:findwindow('INSPECTION_BTFFID',this);\" style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_BTFFNAME+"\"/>"+
                              "<input type='hidden' name='Hidden_PD_INSPECTION_BTFFID' uid='BTFFID"+detailNum+"' value=\""+jsonObjItem.PD_INSPECTION_BTFFID+"\"/>";
                break;
        }  
    }  
}

//项目抽查巡查
function ss_table_xmccxc_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.PD_INSPECTION_FILENAME==null)
    {
        jsonObjItem.PD_INSPECTION_FILENAME = jsonObjItem.PD_INSPECTION_FILENAME_SYSTEM ="";
    }
    for(var i=0;i<17;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 1:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='xmccxc_AUTO_NO' style=\" width:90%\" value=\""+jsonObjItem.AUTO_NO+"\"/>";
                break;
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='xmccxc_PD_PROJECT_CODE' readonly='readonly' style=\" width:90%;\"  value=\""+jsonObjItem.PD_PROJECT_CODE+"\"/>";
                break;
            case 3:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_PROCESS' style=\" width:70%\" value=\""+jsonObjItem.PD_INSPECTION_PROCESS+"\"/>";
                break
            case 4:
                _td.align="center";
                _td.innerHTML="<input type='text' id='datetime"+detailNum+"' name='xmccxc_PD_INSPECTION_DATE' readonly='readonly' style=\" width:75%\" value=\""+jsonObjItem.PD_INSPECTION_DATE+"\"/>";
                break;
                
                
            case 5:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_MONITOR_PROCEED_WCL' maxlength='3' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_PROCEED_WCL+"\"/>";
                break;
            case 6:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_PROJECT_TOTAL_MONEY' style=\" width:75%\" value=\""+jsonObjItem.PD_PROJECT_TOTAL_MONEY+"\"/>";
                break;
            case 7:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_MONITOR_TOTAL_MONEY_PAY' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_TOTAL_MONEY_PAY+"\"/>";
                break;
            case 8:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_MONITOR_TOTAL_MONEY_WCL' maxlength='3' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_TOTAL_MONEY_WCL+"\"/>";
                break;
                
                
                
                
                
            case 9:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_MANS' style=\" width:75%\" value=\""+jsonObjItem.PD_INSPECTION_MANS+"\"/>";
                break;
            case 10:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_ADDR' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_ADDR+"\"/>";
                break;
            case 11:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_CONTENT' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_CONTENT+"\"/>";
                break;
            case 12:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_SUGGEST' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_SUGGEST+"\"/>";
                break;
            case 13:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmccxc_PD_INSPECTION_CONCLUSION' style=\" width:90%\" value=\""+jsonObjItem.PD_INSPECTION_CONCLUSION+"\"/>";
                break;
            case 14:
                _td.align="center";
                _td.style.display="none";
                if(jsonObjItem.PD_CONTRACT_STATE==null||(jsonObjItem.PD_CONTRACT_STATE!=null&&jsonObjItem.PD_CONTRACT_STATE==""))
                    jsonObjItem.PD_CONTRACT_STATE="0";
                _td.innerHTML="<input type='text' name='xmccxc_PD_CONTRACT_STATE' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_STATE+"\"/>";
                break;
            case 15:  
                _td.align="center";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 16:  
                _td.align="center";
                //_td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',"+(i-1)+")\" ColumnIndex="+(i-1)+" rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }
        $('input',_td).attr('disabled','disabled');
    }  
}


//项目实施监控
function ss_table_xmssjk_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.PD_MONITOR_FILENAME==null)
    {
        jsonObjItem.PD_MONITOR_FILENAME = jsonObjItem.PD_MONITOR_FILENAME_SYSTEM ="";
    }
    for(var i=0;i<10;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 1:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='xmssjk_AUTO_NO' style=\" width:90%\" value=\""+jsonObjItem.AUTO_NO+"\"/>";
                break;
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='xmssjk_PD_PROJECT_CODE' style=\" width:90%;\"  value=\""+jsonObjItem.PD_PROJECT_CODE+"\"/>";
                break;
            case 3:
                _td.align="center";
                _td.innerHTML="<input type='text' id='datetime"+detailNum+"' readonly='readonly' name='xmssjk_PD_MONITOR_INPUT_DATE' style=\" width:70%\" value=\""+jsonObjItem.PD_MONITOR_INPUT_DATE+"\"/>";
                break
            case 4:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmssjk_PD_MONITOR_PROCEED_WCL' maxlength='3' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_PROCEED_WCL+"\"/>";
                break;
            case 5:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmssjk_PD_PROJECT_TOTAL_MONEY' style=\" width:75%\" value=\""+jsonObjItem.PD_PROJECT_TOTAL_MONEY+"\"/>";
                break;
            case 6:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmssjk_PD_MONITOR_TOTAL_MONEY_PAY' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_TOTAL_MONEY_PAY+"\"/>";
                break;
            case 7:
                _td.align="center";
                _td.innerHTML="<input type='text' name='xmssjk_PD_MONITOR_TOTAL_MONEY_WCL' maxlength='3' style=\" width:90%\" value=\""+jsonObjItem.PD_MONITOR_TOTAL_MONEY_WCL+"\"/>";
                break;
            case 8:  
                _td.align="center";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 9:  
                _td.align="center";
                //_td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',8)\" ColumnIndex=8 rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }  
        $('input',_td).attr('disabled','disabled');
    }  
}

//合同变更管理
function ss_table_htbggl_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.PD_CONTRACT_CHANGE_FILENAME_SQ==null)
    {
        jsonObjItem.PD_CONTRACT_CHANGE_FILENAME_SQ = jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM_SQ ="";
    }
    for(var i=0;i<13;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 1:
                _td.align="center";
                _td.style.display="none";
                _td.appendChild(getSelectHtbggl(jsonObjItem.PD_CONTRACT_PICI));
                //_td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_PiCi' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_PICI+"\"/>";
                break;
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='htbggl_AUTO_NO' style=\" width:90%;\"  value=\""+jsonObjItem.AUTO_NO+"\"/>";
                break;
            case 3:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_NO' readonly='readonly' onfocus=\"javascript:findwindow('HeTongBH',this);\" style=\" width:70%\" value=\""+jsonObjItem.PD_CONTRACT_NO+"\"/>";
                break
            case 4:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='htbggl_PD_PROJECT_CODE' readonly='readonly' style=\" width:90%\" value=\""+jsonObjItem.PD_PROJECT_CODE+"\"/>";
                break;
            case 5:
                _td.align="center";
                _td.innerHTML="<input type='text' id='datetime"+detailNum+"' name='htbggl_PD_CONTRACT_CHANGE_DATE' style=\" width:75%\" value=\""+jsonObjItem.PD_CONTRACT_CHANGE_DATE+"\"/>";
                break;
            case 6:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_CHANGE_REASON' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_CHANGE_REASON+"\"/>";
                break;
            case 7:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_MONEY' readonly='readonly' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_MONEY+"\"/>";
                break;
            case 8:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_CHANGE_ZJ' class='NumTextCss' onKeyPress=\"myKeyDown(this,event,1);\" onchange=\"SumCHANGE_ZJ(this) \" style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_CHANGE_ZJ+"\"/>";
                break;
            case 9:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_CHANGE_MONEY' readonly='readonly' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_CHANGE_MONEY+"\"/>";
                break;
            case 10:
                _td.align="center";
                _td.style.display="none";
                if(jsonObjItem.PD_CONTRACT_STATE==null||(jsonObjItem.PD_CONTRACT_STATE!=null&&jsonObjItem.PD_CONTRACT_STATE==""))
                    jsonObjItem.PD_CONTRACT_STATE="0";
                _td.innerHTML="<input type='text' name='htbggl_PD_CONTRACT_STATE' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_STATE+"\"/>";
                break;
            case 11:  
                _td.align="center";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 12:  
                _td.align="center";
                //_td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',11)\" ColumnIndex=11 rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }  
        $('input',_td).attr('disabled','disabled');
    }  
}

//
function table_xmsszl_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.PD_CONTRACT_FILENAME==null)
    {
        jsonObjItem.PD_CONTRACT_FILENAME = jsonObjItem.PD_CONTRACT_FILENAME_SYSTEM ="";
    }
    for(var i=0;i<13;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 1:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_NO' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_NO+"\"/>";
                break;
            case 2:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_NAME' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_NAME+"\"/>";
                break;
            case 3:
                _td.align="center";
                _td.innerHTML="<input type='text' id='datetime"+detailNum+"' name='htgl_PD_CONTRACT_DATE' readonly='readonly' style=\" width:70%\" value=\""+jsonObjItem.PD_CONTRACT_DATE+"\"/>";
                
                break
            case 4:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_COMPANY' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_COMPANY+"\"/>";
                break;
            case 5:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_MOENY' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_MOENY+"\"/>";
                break;
            case 6:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_MOENY_CHANGE' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_MOENY_CHANGE+"\"/>";
                break;
            case 7:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_ASK_LIMIT' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_ASK_LIMIT+"\"/>";
                break;
            case 8:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_ASK_PROCEED' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_ASK_PROCEED+"\"/>";
                break;
            case 9:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_ASK_PAYMENT' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_ASK_PAYMENT+"\"/>";
                break;
            case 10:
                _td.align="center";
                _td.innerHTML="<input type='text' name='htgl_PD_CONTRACT_NOTE' style=\" width:90%\" value=\""+jsonObjItem.PD_CONTRACT_NOTE+"\"/>";
                break;
            case 11:  
                _td.align="center";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 12:  
                _td.align="center";
                //_td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',11)\" ColumnIndex=11 rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }  
        $('input',_td).attr('disabled','disabled');
    }  
}

function xmss_5_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.AUTO_NO==null)
    {
        jsonObjItem.PD_PROJECT_ATTACH_NAME = jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM ="";
    }
    for(var i=0;i<5;i++)  
    {  
        var _td=_tr.insertCell(i); 
         
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="";
                break;  
            case 1:
                _td.align="center";
                _td.height="30px";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
               //background-color:White;
//                  _td.style="background:White;"
 
                break;  
            case 2:
                _td.align="center";
                _td.appendChild(getProjFileType(tableID,jsonObjItem.PD_PROJECT_ATTACH_TYPE));
                break;   
            case 3:  
                _td.align="center";
                var str="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                str+="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',3)\" ColumnIndex=3 rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";
                str+="<div class=\"filedownArea\" id='filedownArea"+detailNum+"' style='cursor:hand;'  onmouseover=\"MouseOnRowIndex="+detailNum+"\" systemName='"+jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM+"' title='"+jsonObjItem.PD_PROJECT_ATTACH_NAME+"' onclick='DownFile(this);'></div>";
                
                //_td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
            
                _td.innerHTML=str;
                break;
            case 4:  
                _td.style.display="none";
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',3)\" ColumnIndex=3 rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }  
    }  
}

function xmpf_4_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.AUTO_NO==null)
    {
        jsonObjItem.PD_PROJECT_ATTACH_NAME = jsonObjItem.PD_PROJECT_ATTACH_NAME_SYSTEM ="";
    }
    for(var i=0;i<5;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="";
                break;  
            case 1:
                _td.align="center";
                _td.height="30px";
                //_td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' style=\" width:90%\" readonly='readonly' value=\""+jsonObjItem.PD_PROJECT_CODE+"\"/>";
                break;   
            case 3:  
                _td.align="center";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%'><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 4:  
                _td.align="center";
                //_td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',3)\" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
        }  
    }  
}
function bz_xzxx_RowAdd(tableID,jsonObjItem,_tr,detailNum)
{
    if(jsonObjItem.FILE_NAME==null)
        jsonObjItem.FILE_NAME = jsonObjItem.FILE_SYSNAME ="";
        
    if(jsonObjItem.AUTO_NO==null||jsonObjItem.AUTO_NO=="")
        jsonObjItem.AUTO_NO="0";
    if(jsonObjItem.PD_UP_MONEY==null)
        jsonObjItem.PD_UP_MONEY="";
    for(var i=0;i<11;i++)  
    {  
        var _td=_tr.insertCell(i);  
        switch(i)  
        {
            case 0:  
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='"+tableID+"_AUTO_NO' style=\" width:90%;\" value=\""+jsonObjItem.AUTO_NO+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_PD_QUOTA_SERVERPK' value=\""+jsonObjItem.PD_QUOTA_SERVERPK+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_ISRECEIVE' value=\""+jsonObjItem.ISRECEIVE+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_IF_SHOW' value=\""+jsonObjItem.IF_SHOW+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_ISHUIZHI' value=\""+jsonObjItem.ISHUIZHI+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_RECEIVE_MAN' value=\""+jsonObjItem.RECEIVE_MAN+"\"/>"
                              +" <input type='hidden' name='"+tableID+"_HUIZHI_MAN' value=\""+jsonObjItem.HUIZHI_MAN+"\"/>";
                break;  
            case 1:
                _td.align="center";
                _td.height="30px";
                _td.style.display="none";
                _td.innerHTML="<input type=\"checkbox\" name=\""+tableID+"_cb\" value=\"checkbox\" />";
                break;  
            case 2:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<input type='text' name='"+tableID+"_PD_QUOTA_CODE' value=\""+jsonObjItem.PD_QUOTA_CODE+"\"/>";
                break;   
            case 3:
                _td.align="center";
                _td.appendChild(getXZXX(jsonObjItem.COMPANY_CODE,jsonObjItem.COMPANY_NAME));
                break;   
            case 4:
                _td.align="center";
                _td.innerHTML="<input type='text' name='"+tableID+"_PD_UP_MONEY' class='NumTextCss' onKeyPress=\"EnterDown(this,event,"+i+")\" onblur=\"sumMoney('"+tableID+"',this)\" style=\" width:99%;\"value=\""+jsonObjItem.PD_UP_MONEY+"\"/>";
                break;
            case 5:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<div id='upfile"+detailNum+"' style='Width:100%' onmouseover=\"MouseOnRowIndex="+detailNum+"\"><div id='ShowDIV"+detailNum+"' class=\"filetxt\"></div></div>";
                break;
            case 6:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML="<div class=\"fileUpArea\"  onmouseover=\"MouseOnRowIndex="+detailNum+"\"><input type=\"file\"  class=\"fileinput\" name=\"filesupload\"  onchange=\"BindUpLoad(this,'"+tableID+"',"+(i-1)+")\" ColumnIndex="+(i-1)+" rowIndex="+detailNum+" onmouseover=\"MouseOnRowIndex="+detailNum+"\"/></div>";  
                break;
            case 7:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML=jsonObjItem.ISRECEIVE_CH+"&nbsp;";
                break;
            case 8:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML=jsonObjItem.RECEIVE_MANNAME+"&nbsp;";
                break;
            case 9:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML=jsonObjItem.ISHUIZHI_CH+"&nbsp;";
                break;
            case 10:
                _td.align="center";
                _td.style.display="none";
                _td.innerHTML=jsonObjItem.HUIZHI_MANNAME+"&nbsp;";
                break;
        }  
    }  
}
//指标管理
function EnterDown(obj,event,objColumn)
{
    if(event.keyCode==13)
    {
        try{
            objRow=obj.parentNode.parentNode;
            if(objRow.rowIndex<objRow.parentNode.rows.length-1)
            {
                objRow.parentNode.rows[objRow.rowIndex+1].cells[objColumn].firstChild.focus();
            }
        }catch(e){alert(e)};
        event.keyCode=0;
        event.returnValue=false;
    }
    else
        myKeyDown(obj,event,-4);
        
}
//项目情况登记，附件类型 json DOM
var ProjectFileTypeJSON=null;
function getProjFileType(tableID,type)
{
    var select = document.createElement("select");
    select.name=tableID+"_file_type";
    if(ProjectFileTypeJSON==null)
    {
        $.ajax({
            url: "../../Work/XMGL/publicBll.ashx?loop=FileType",
            type: "post",
            dataType: "text",
            async: false ,
            error: function(e){alert(e);},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
                ProjectFileTypeJSON=eval(msg);
            }
       });
    }
    
                
    $(ProjectFileTypeJSON).each(function(i){ 
        if(!isNaN(this.ID)){
            var option = document.createElement("option");
            option.value= this.ID;
            option.innerHTML= this.NAME;
            if(this.ID==type)
                option.selected="true";
                
            select.appendChild(option)
        }
     });
     
     return select;
}

//专项指标文件，乡镇信息json DOM
var zxzz_xzxxJSON=null;
function getAllxzxx(LoginCompany)
{
    var json_xzxx = decodeURIComponent($("input[uid='json_xzxx']").get(0).value);
    if(zxzz_xzxxJSON==null)
    {
        $.ajax({
            url: "../../Work/SMYSZB/getData.ashx?LoginCompany=" + LoginCompany,
            type: "post",
            dataType: "text",
            async: true ,
            error: function(e){alert(e);},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
               zxzz_xzxxJSON=eval(msg);
               
                var jsonObj = eval(json_xzxx)[0];
                $(zxzz_xzxxJSON).each(function(i){ 
                    if(!isNaN(this.PK_CORP)){
                        jsonObj.COMPANY_CODE=trim(this.PK_CORP);
                        jsonObj.COMPANY_NAME=trim(this.NAME);
                        loadTable_JD("table_xzxx",jsonObj,"bz_xzxx");
                    }
                 });
                 return;
            }
       });
    }
    var jsonObj = eval(json_xzxx)[0];
    $(zxzz_xzxxJSON).each(function(i){ 
        if(!isNaN(this.PK_CORP)){
            jsonObj.COMPANY_CODE=trim(this.PK_CORP);
            jsonObj.COMPANY_NAME=trim(this.NAME);
            loadTable_JD("table_xzxx",jsonObj,"bz_xzxx");
        }
     });
}
function getXZXX(COMPANY_CODE,COMPANY_NAME)
{

    var _a = document.createElement("<a name='aCompanyName'></a>");
    var _hidden = document.createElement("<input type='hidden' name='PD_Company_NAME'></input>");
   _a.innerHTML=COMPANY_NAME
   
   _hidden.value=COMPANY_CODE;
   _a.appendChild(_hidden);
    return _a;
}
//指标，计算下发金额
function sumMoney(tableID,obj)
{
    var _pd_up_money = document.getElementsByName(tableID+"_PD_UP_MONEY");
    var pd_quota_zbxdzh = document.getElementById(pd_quota_zbxdzhID);
    
    var money=0;
    $("input[name='"+tableID+"_PD_UP_MONEY']").each(function(i){ 
        if(this.value!=null&&trim(this.value)!="")
        {
            money+=parseFloat(this.value);
            this.value=parseFloat(this.value).toFixed(4);
        }
        else
           this.value="";
    });
    
    pd_quota_zbxdzh.value=money.toFixed(2);    
}


//合同变更管理，批号
function getSelectHtbggl(PiCi)
{
    var select = document.createElement("<select name='htbggl_PD_CONTRACT_PiCi'></select>");
    for(var i=0;i<5;i++)
    {
        var option = document.createElement("option");
        option.value=(i+1);
        option.innerHTML=(i+1);
        var _index=(i+1)+"";
        if(trim(PiCi)==trim(_index))
            option.selected="selected";
        select.appendChild(option);
    }
    return select;
}
function Bind_tbHead(jsonObjItem,detailNum,tableID,rowIndex)
{
    if(jsonObjItem!=null&&jsonObjItem.FILE_NAME!=null && jsonObjItem.FILE_NAME!="")
        AddShowFile(document.getElementById("ShowDIV"+detailNum),rowIndex,jsonObjItem.FILE_NAME,jsonObjItem.FILE_SYSNAME,tableID);
}

function Bind_tbHeadNotDel(jsonObjItem,detailNum,tableID,rowIndex)
{
    if(jsonObjItem!=null&&jsonObjItem.FILE_NAME!=null && jsonObjItem.FILE_NAME!="")
        AddShowFileNotDel(document.getElementById("ShowDIV"+detailNum),rowIndex,jsonObjItem.FILE_NAME,jsonObjItem.FILE_SYSNAME,tableID);
}


////实施管理
function SumCHANGE_ZJ(obj)
{
    var _row=obj.parentNode.parentNode;
    if(_row.cells[7].firstChild.value!=null&&_row.cells[7].firstChild.value!=""&&_row.cells[8].firstChild.value!=null&&_row.cells[8].firstChild.value!="")
        _row.cells[9].firstChild.value=parseInt(_row.cells[7].firstChild.value)+parseInt(_row.cells[8].firstChild.value);
    else
        _row.cells[9].firstChild.value=_row.cells[7].firstChild.value;
}
////实施管理_独立
function SumCHANGE_ZJ_DL()
{
    var pd_contract_money=$("input[uid='txtPD_CONTRACT_MONEY']").get(0);
    var pd_contract_change_zj=$("input[uid='txtPD_CONTRACT_CHANGE_ZJ']").get(0);
    var pd_contract_change_money=$("input[uid='txtPD_CONTRACT_CHANGE_MONEY']").get(0);
    
    if(pd_contract_money.value!=null&&pd_contract_money.value!=""&&pd_contract_change_zj.value!=null&&pd_contract_change_zj.value!="")
        pd_contract_change_money.value=(parseFloat(pd_contract_money.value)+parseFloat(pd_contract_change_zj.value)).toFixed(2);
    else
        pd_contract_change_money.value=parseFloat(pd_contract_money.value).toFixed(2);
}

//获取申报管理 项目类别 过滤
function getPD_PROJECT_TYPE()
{
    var PD_YEAR = document.getElementById(selectPD_YEAR_id);
    var PD_FOUND_XZ = document.getElementById(selectPD_FOUND_XZ_id);
    var PD_PROJECT_TYPE = document.getElementById(selectPD_PROJECT_TYPE_id);
    
    var pd_yearValue = PD_YEAR.options[PD_YEAR.selectedIndex].value
    var pd_found_xzValue = PD_FOUND_XZ.options[PD_FOUND_XZ.selectedIndex].value
    
        $.ajax({
            url: "/Work/XMGL/publicBll.ashx?loop=project_type&year=" + pd_yearValue + "&pd_found_xz=" + pd_found_xzValue,
            type: "post",
            dataType: "text",
            async: false ,
            error: function(e){alert(e);},
            success: function(msg){//msg为返回的数据，在这里做数据绑定
                PD_PROJECT_TYPE.index=0;
                $(eval(msg)).each(function(i){ 
                   var option = document.createElement("option");
                   option.value=this.CODE;
                   option.innerHTML=this.NAME;
                   PD_PROJECT_TYPE.appendChild(option);
                 });
                
            }
       });   
}

function js_dateYear()
{
    var begin_date=document.getElementById(txtPD_PROJECT_BEGIN_DATE);
    var end_date=document.getElementById(txtPD_PROJECT_END_DATE);
    var years=document.getElementById(txtPD_PROJECT_YEARS);
    var bdate = begin_date.value.split('-');
    var edate = end_date.value.split('-');
    if(bdate.length==3&&edate.length==3){
        years.value = (parseInt(edate[0])-parseInt(bdate[0]))*12+(parseInt(edate[1])-parseInt(bdate[1]));
    }
}


function openPrint()
{
    var txtPD_PROJECT_CODE = $("input[uid='txtPD_PROJECT_CODE']").get(0);
    var ddlPD_FOUND_XZ = $("input[uid='ddlPD_FOUND_XZ']").get(0);
    var selectoption=ddlPD_FOUND_XZ.options[ddlPD_FOUND_XZ.selectedIndex];
    
    if(!isNaN(txtPD_PROJECT_CODE.value)&&!isNaN(selectoption.value))
    {
        window.open("/Report/jsxGTable.aspx?code="+txtPD_PROJECT_CODE.value+'&pd_found_xz='+selectoption.value,'','toolbar=no,status=no,resizable=no,width=800px,height=600px,scrollbars=no,location=no,left=150,top=50');
    }
}

function DownModel()
{
    open("../../WebControls/UserControl/DownFile.aspx?DownModel=1");
}