<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" inherits="Welcome" CodeBehind="Welcome.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
    
        //获取页面大小初始值
        function SetWH() {
            var w = 1366; var h = 768;
            w = document.documentElement.clientWidth;
            h = document.documentElement.clientHeight;
            window.parent.parent.document.getElementById('wid1').value = w;
            window.parent.parent.document.getElementById('hei').value = h;
            window.parent.parent.document.getElementById('stu').value = '0';

            document.cookie = "mm=" + w;
            document.cookie = "wid1=" + w;
            document.cookie = "stu=0";
            document.cookie = "hei=" + h;
            document.cookie = "allwid=" + window.screen.availWidth;
            document.cookie = "allhei=" + window.screen.availHeight;
        }

        function getCookie(objName) {//获取指定名称的cookie的值
            var arrStr = document.cookie.split("; ");
            for (var i = 0; i < arrStr.length; i++) {
                var temp = arrStr[i].split("=");
                if (temp[0] == objName)
                    return unescape(temp[1]);
            }
        }

        //菜单收缩
        function menuCollapse(){
        }
        
        //菜单打开
        function menuExpand(){
        }
    
        //屏蔽右键
        function document.oncontextmenu() {
            return false;
        }
        
        function reloadpage() {
            window.location.reload();
        }
        //setTimeout(reloadpage, 600000);
    </script>

</head>
<body onload="javascript:SetWH();">
    <script src="jss/Qx_nz.js" type="text/javascript"></script>
    <form id="form1" runat="server">

    <script type="text/javascript">

        var isIE = (document.all) ? true : false;

        var $ = function(id) {
            return "string" == typeof id ? document.getElementById(id) : id;
        };

        var Class = {
            create: function() {
                return function() { this.initialize.apply(this, arguments); }
            }
        }

        var Extend = function(destination, source) {
            for (var property in source) {
                destination[property] = source[property];
            }
        }

        var Bind = function(object, fun) {
            return function() {
                return fun.apply(object, arguments);
            }
        }

        var BindAsEventListener = function(object, fun) {
            return function(event) {
                return fun.call(object, (event || window.event));
            }
        }

        var CurrentStyle = function(element) {
            return element.currentStyle || document.defaultView.getComputedStyle(element, null);
        }

        function addEventHandler(oTarget, sEventType, fnHandler) {
            if (oTarget.addEventListener) {
                oTarget.addEventListener(sEventType, fnHandler, false);
            } else if (oTarget.attachEvent) {
                oTarget.attachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = fnHandler;
            }
        };

        function removeEventHandler(oTarget, sEventType, fnHandler) {
            if (oTarget.removeEventListener) {
                oTarget.removeEventListener(sEventType, fnHandler, false);
            } else if (oTarget.detachEvent) {
                oTarget.detachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = null;
            }
        };

        //拖放程序
        var Drag = Class.create();
        Drag.prototype = {
            //拖放对象
            initialize: function(drag, options) {
                this.Drag = $(drag); //拖放对象
                this._x = this._y = 0; //记录鼠标相对拖放对象的位置
                this._marginLeft = this._marginTop = 0; //记录margin
                //事件对象(用于绑定移除事件)
                this._fM = BindAsEventListener(this, this.Move);
                this._fS = Bind(this, this.Stop);

                this.SetOptions(options);

                this.Limit = !!this.options.Limit;
                this.mxLeft = parseInt(this.options.mxLeft);
                this.mxRight = parseInt(this.options.mxRight);
                this.mxTop = parseInt(this.options.mxTop);
                this.mxBottom = parseInt(this.options.mxBottom);

                this.LockX = !!this.options.LockX;
                this.LockY = !!this.options.LockY;
                this.Lock = !!this.options.Lock;

                this.onStart = this.options.onStart;
                this.onMove = this.options.onMove;
                this.onStop = this.options.onStop;

                this._Handle = $(this.options.Handle) || this.Drag;
                this._mxContainer = $(this.options.mxContainer) || null;

                this.Drag.style.position = "absolute";
                //透明
                if (isIE && !!this.options.Transparent) {
                    //填充拖放对象
                    with (this._Handle.appendChild(document.createElement("div")).style) {
                        width = height = "100%"; backgroundColor = "#fff"; filter = "alpha(opacity:0)"; fontSize = 0;
                    }
                }
                //修正范围
                this.Repair();
                addEventHandler(this._Handle, "mousedown", BindAsEventListener(this, this.Start));
            },
            //设置默认属性
            SetOptions: function(options) {
                this.options = {//默认值
                    Handle: "", //设置触发对象（不设置则使用拖放对象）
                    Limit: false, //是否设置范围限制(为true时下面参数有用,可以是负数)
                    mxLeft: 550, //左边限制
                    mxRight: 9999, //右边限制
                    mxTop: 0, //上边限制
                    mxBottom: 9999, //下边限制
                    mxContainer: "", //指定限制在容器内
                    LockX: false, //是否锁定水平方向拖放
                    LockY: false, //是否锁定垂直方向拖放
                    Lock: false, //是否锁定
                    Transparent: false, //是否透明
                    onStart: function() { }, //开始移动时执行
                    onMove: function() { }, //移动时执行
                    onStop: function() { } //结束移动时执行
                };
                Extend(this.options, options || {});
            },
            //准备拖动
            Start: function(oEvent) {
                if (this.Lock) { return; }
                this.Repair();
                //记录鼠标相对拖放对象的位置
                this._x = oEvent.clientX - this.Drag.offsetLeft;
                this._y = oEvent.clientY - this.Drag.offsetTop;
                //记录margin
                this._marginLeft = parseInt(CurrentStyle(this.Drag).marginLeft) || 0;
                this._marginTop = parseInt(CurrentStyle(this.Drag).marginTop) || 0;
                //mousemove时移动 mouseup时停止
                addEventHandler(document, "mousemove", this._fM);
                addEventHandler(document, "mouseup", this._fS);
                if (isIE) {
                    //焦点丢失
                    addEventHandler(this._Handle, "losecapture", this._fS);
                    //设置鼠标捕获
                    this._Handle.setCapture();
                } else {
                    //焦点丢失
                    addEventHandler(window, "blur", this._fS);
                    //阻止默认动作
                    oEvent.preventDefault();
                };
                //附加程序
                this.onStart();
            },
            //修正范围
            Repair: function() {
                if (this.Limit) {
                    //修正错误范围参数
                    this.mxRight = Math.max(this.mxRight, this.mxLeft + this.Drag.offsetWidth);
                    this.mxBottom = Math.max(this.mxBottom, this.mxTop + this.Drag.offsetHeight);
                    //如果有容器必须设置position为relative或absolute来相对或绝对定位，并在获取offset之前设置
                    !this._mxContainer || CurrentStyle(this._mxContainer).position == "relative" || CurrentStyle(this._mxContainer).position == "absolute" || (this._mxContainer.style.position = "relative");
                }
            },
            //拖动
            Move: function(oEvent) {
                //判断是否锁定
                if (this.Lock) { this.Stop(); return; };
                //清除选择
                window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
                //设置移动参数
                var iLeft = oEvent.clientX - this._x, iTop = oEvent.clientY - this._y;
                //设置范围限制
                if (this.Limit) {
                    //设置范围参数
                    var mxLeft = this.mxLeft, mxRight = this.mxRight, mxTop = this.mxTop, mxBottom = this.mxBottom;
                    //如果设置了容器，再修正范围参数
                    if (!!this._mxContainer) {
                        mxLeft = Math.max(mxLeft, 0);
                        mxTop = Math.max(mxTop, 0);
                        mxRight = Math.min(mxRight, this._mxContainer.clientWidth);
                        mxBottom = Math.min(mxBottom, this._mxContainer.clientHeight);
                    };
                    //修正移动参数
                    iLeft = Math.max(Math.min(iLeft, mxRight - this.Drag.offsetWidth), mxLeft);
                    iTop = Math.max(Math.min(iTop, mxBottom - this.Drag.offsetHeight), mxTop);
                }
                //设置位置，并修正margin
                if (!this.LockX) { this.Drag.style.left = iLeft - this._marginLeft + "px"; }
                if (!this.LockY) { this.Drag.style.top = iTop - this._marginTop + "px"; }
                //附加程序
                this.onMove();
            },
            //停止拖动
            Stop: function() {
                //移除事件
                removeEventHandler(document, "mousemove", this._fM);
                removeEventHandler(document, "mouseup", this._fS);
                if (isIE) {
                    removeEventHandler(this._Handle, "losecapture", this._fS);
                    this._Handle.releaseCapture();
                } else {
                    removeEventHandler(window, "blur", this._fS);
                };
                //附加程序
                this.onStop();
            }
        };
    </script>

    <style type="text/css">
        .welcome_box
        {
            padding: 20px;
            background-color: #FFF;
        }
        .welcome_nrbox
        {
            border: 1px solid #bddaf0;
            padding: 20px 20px 30px 20px;
            margin-bottom: 30px;
        }
        .welcom_bt
        {
            font-size: 14px;
            font-weight: bold;
            color: #05478a;
            padding-bottom: 20px;
        }
    </style>
    <script type="text/javascript">
        function OpenWindow(objNode)
        {
            var objtarget=objNode.link.split('|')[0];
            var objtitle=objNode.link.split('|')[1];
           
            if(objtarget == "mainFrame")
            {
                //window.parent.frames('mainFrame').addTabPanel(objNode.innerText, objNode.title);encodeURIComponent
                window.parent.addTabPanel(objNode.id, decodeURIComponent(objNode.id), objtitle, objNode.value);
            }else
            {
                window.open('../../'+objtitle, "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + window.screen.width + ",height=" + window.screen.height + ",left=0,top=0");
            }
        }
    </script>

    <div class="welcome_box">
        <div class="welcome_nrbox">
            <div class="welcom_bt">
                <img style="vertical-align:middle;" src="images/new/WelCome/20131012030416621.png" />&nbsp; 项目建设资金监管</div>
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="指标信息" class="imgClass" style="cursor: hand; border:none" link="mainFrame|Work/ZB/ZBList.aspx" value=""
                                onclick="OpenWindow(this)" src="images/new/WelCome/w_01.png" width="48" height="48"  alt="指标信息" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="项目备选库" class="imgClass" style="cursor: hand; border:none" link="mainFrame|Work/XMGL/BXKList.aspx" value=""
                                onclick="OpenWindow(this)" src="images/new/WelCome/home.png" width="48" height="48" alt="项目备选库"
                                title="项目备选库" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center">333</td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="项目情况登记" class="imgClass" style="cursor: hand; border:none" link="mainFrame|Workness/XMGL/SbList.aspx" value=""
                                onclick="OpenWindow(this)" src="images/new/WelCome/w_07.png" width="48" height="48"
                                alt="项目登记" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center">111</td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="合同信息"  class="imgClass" style="cursor: hand;border:none" link="mainFrame|Work/XMGL/HeTong/HeTongList.aspx"
                                    value="" onclick="OpenWindow(this)" src="images/new/WelCome/info.png" width="48" height="48" title="合同信息" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="资金拨付" class="imgClass" style="cursor: hand;border:none" link="mainFrame|Work/ZJBF/ZJBFList.aspx"
                                    value="" onclick="OpenWindow(this)"  src="images/new/WelCome/w_08.png" width="48" height="48" title="资金拨付" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="公开公示" class="imgClass" style="cursor: hand;border:none" link="mainFrame|Work/XMGL/GKGS/proJSGKGSList.aspx"
                                    value="" onclick="OpenWindow(this)"  src="images/new/WelCome/w_03.png" width="48" height="48" title="公开公示" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="项目巡查" class="imgClass" style="cursor: hand;border:none" link="mainFrame|Work/XMGL/CCXC/ssXCList.aspx"
                                    value="" onclick="OpenWindow(this)" src="images/new/WelCome/w_05.png" width="48" height="48" title="竣工验收" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                </tr>
            </table>
        </div>
        <div class="welcome_nrbox">
            <div class="welcom_bt">
                <img style="vertical-align:middle;" src="images/new/WelCome/people.png" />&nbsp; 补助性资金监管</div>
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="Img1" class="imgClass" style="cursor: hand; border:none" link="mainFrame|Work/ZB/ZBList.aspx" value=""
                                onclick="OpenWindow(this)" src="images/new/WelCome/w_01.png" width="48" height="48"
                                title="指标信息" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="补助性资金项目管理" style="cursor: hand;border:none" link="mainFrame|Work/BZ/BzList.aspx"
                                    value="" onclick="OpenWindow(this)" src="images/new/WelCome/w_07.png" width="48" height="48" title="补助性资金项目管理" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="补助性公开公示" class="imgClass" style="cursor: hand; border:none" link="mainFrame|Work/BZ/GKGS/BZGKGSList.aspx" value=""
                                onclick="OpenWindow(this)" src="images/new/WelCome/w_03.png" width="48" height="48"
                                title="补助性公开公示" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                    <td width="36" align="center">
                        <img src="images/new/WelCome/r_turn.jpg" width="16" height="35" />
                    </td>
                    
                    <td width="99" height="119" align="center"><table border="0" cellpadding="0" cellspacing="00">
                              <tr>
                                <td><a href="#"><img name="ImgButton" id="补助性抽查" style="cursor: hand;border:none" link="mainFrame|Work/BZ/CCXC/bzCCList.aspx"
                                    value="" onclick="OpenWindow(this)" src="images/new/WelCome/w_05.png" width="48" height="48" alt="补助性抽查" /></a></td>
                              </tr>
                              <tr>
                                <td height="40" align="center"></td>
                              </tr>
                            </table></td>
                </tr>
            </table>
        </div>
       </div>
    <input type="hidden" runat="server" id="userid" />
    </form>
</body>
</html>

<script type="text/javascript">
    function Bind()
    {
        var imgDom=document.getElementsByName('ImgButton');
   
        var userid = document.getElementById("<%=userid.ClientID %>");
    var imgDomLength=imgDom.length;
    
    for(var i=imgDomLength-1;i>=0;i--)
    {
        try{
            var url = imgDom[i].link.split('|')[1];
            
            var returnStr = Get_XmlHttp("/Work/XMGL/publicBll.ashx?loop=Welcome&url=" + encodeURIComponent(url) + "&userid=" + encodeURIComponent(userid.value));
            imgDom[i].id=encodeURIComponent(imgDom[i].title=returnStr.split('|')[1]);
            //            if(i==1||i==3||i==5||i==6)
            if(returnStr.split('|')[0]=='false'){try{
                var _td = imgDom[i].parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
                //alert(_td.innerHTML);
                var _tr = _td.parentNode;
                var _cellIndex=_td.cellIndex;
                _tr.deleteCell(_cellIndex);
                if(_tr.cells.length>0){
                    if(_cellIndex>=_tr.cells.length)
                        _cellIndex--;
                    _tr.deleteCell(_cellIndex);
                }}catch(e){alert(e);}
            }else
            {
                var _td = imgDom[i].parentNode.parentNode;
                var _tr = _td.parentNode;
               
                _tr.parentNode.rows[_tr.rowIndex+1].cells[0].innerHTML="<a id=\""+encodeURIComponent(imgDom[i].title=returnStr.split('|')[1])+"\" link=\""+imgDom[i].link+"\" href=\"#\" onclick=\"OpenWindow(this)\">"+returnStr.split('|')[1]+"</a>";
                //_tr.parentNode.rows[_tr.rowIndex+1].cells[0].appendChild(_a);
                
                //alert(_tr.parentNode.rows[_tr.rowIndex+1].cells[0].innerHTML);
                //_tr.parentNode.rows[_tr.rowIndex+1].cells[0].innerHTML=returnStr.split('|')[1];
            }
        }catch(e){};
    }
}
Bind();
</script>