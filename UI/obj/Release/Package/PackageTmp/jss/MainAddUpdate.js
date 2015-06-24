
        function setHeight()
        {
        
        }
        function IsOnSubmit(ibtid)
        {
            if(ibtid==null)
                return true;
            if(ibtid.value=="false")
            {
                removeWindowFull();
                return false;
            }
            else if(Trim(ibtid.value)=="")
                return true;
            else
            {
                try{
                    if(!necessaryIsFull())
                    {
                        removeWindowFull();
                        return false;
                    }
                    return true;
                }catch(e){}
                return true;
            }
        }
        
        $(document).ready(function(){
            setHeight();
        });
        function necessaryIsFull(){
           var _onsubmit=true;
           //alert( $("font[color='red']"));
           
//           alert(jQuery("font").length);
//           alert($("font").length);
//           alert(document.getElementsByTagName("font").length);
           var fontNode=document.getElementsByTagName("font");
           if(fontNode!=null&&fontNode.length>0){
               jQuery.each(fontNode,function(i,n)//i下标,n值
               {
                    if(Trim(this.innerHTML)=='*')
                    {
                        var _td=this.parentNode;
                        var _tr=this.parentNode.parentNode;
                        if(_tr!=null && _tr.cells!=null && _tr.cells.length>_td.cellIndex)
                        {
                            if(jQuery("input[type='text']",_tr.cells[_td.cellIndex+1]).length>0){
                                if(_tr.cells[_td.cellIndex+1].childNodes.length>0 && Trim(jQuery("input[type='text']",_tr.cells[_td.cellIndex+1]).get(0).value)=="")
                                {
                                    _onsubmit=false;
                                    alert(_td.innerText.replace('*','')+" 不能为空");
                                    jQuery("input[type='text']",_tr.cells[_td.cellIndex+1]).get(0).focus();
                                    return false;
                                }
                            }
                        }
                    }
               });
           }
           return _onsubmit;
        }
