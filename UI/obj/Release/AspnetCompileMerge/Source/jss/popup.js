function ArchjsPopup(param) {
    this.id = param.id;
    this.title = param.title;
    this.caption = param.caption;
    this.message = param.message;
    this.target = param.target;
    this.action = param.action;
    this.ishidden = param.ishidden;
    this.width = (typeof param.width != "undefined") ? param.width : 200;
    this.height = (typeof param.height != "undefined") ? param.height : 120;
    this.timeout = 200;
    this.speed = 2;
    this.step = 1;
    this.right = screen.width - 15;
    this.bottom = screen.height;
    this.left = this.right - this.width;
    this.top = this.bottom - this.height;
    this.timer = 0;
    this.pause = false;
    this.close = false;
    this.autoHide = true;
    this.messages = new Object();
    this.index = 0;
    this.linkEventobj;
    this.setSpeedEventobj;
    this.setAutoRefreshEventobj;

    ArchjsPopup.prototype.addMessage = function(param) {
        var item = new Message_Item(param);
        this.messages[this.index] = item;
        this.index++;
    }

    ArchjsPopup.prototype.onunload = function() {
        return true;
    }

    ArchjsPopup.prototype.oncommand = function() {
        if (typeof this.linkEventobj == 'undefined') {
            window.open(this.action, this.target);
        }
        else {
            this.linkEventobj();
        }
        if (param.ishidden != false) {
            this.hide();
        }
    }

    ArchjsPopup.prototype.onlink = function(action) {
        window.open(action, this.target);
        if (param.ishidden != false) {
            this.hide();
        }
    }

    ArchjsPopup.prototype.hide = function() {
        if (this.onunload()) {

            var offset = this.height > this.bottom - this.top ? this.height : this.bottom - this.top;
            var me = this;

            if (this.timer > 0) {
                window.clearInterval(me.timer);
            }

            var fun = function() {
                if (me.pause == false || me.close) {
                    var x = me.left;
                    var y = 0;
                    var width = me.width;
                    var height = 0;
                    if (me.offset > 0) {
                        height = me.offset;
                    }

                    y = me.bottom - height;

                    if (y >= me.bottom) {
                        window.clearInterval(me.timer);
                        me.Pop.hide();
                        if (typeof me.setAutoRefreshEventobj !== 'undefined') {
                            me.setAutoRefreshEventobj();
                        }
                    }
                    else {
                        me.offset = me.offset - me.step;
                    }
                    me.Pop.show(x, y, width, height);
                }
            }

            this.timer = window.setInterval(fun, this.speed)
        }
    }

    ArchjsPopup.prototype.show = function() {
        var oPopup = window.createPopup(); // IE5.5+   
        this.Pop = oPopup;

        var w = this.width;
        var h = this.height;
        var str = " <DIV style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH:  " + w + " px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT:  " + h + " px; BACKGROUND-COLOR: #c9d3f3'> ";
        str += " <TABLE style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#cfdef4 border=0> ";
        str += " <TR> ";
        str += " <TD style='FONT-SIZE: 12px;COLOR: #0f2c8c' width=30 height=24></TD> ";
        str += " <TD style='PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' vAlign=center width='100%'> " + this.caption + " </TD> ";
        str += " <TD style='PADDING-RIGHT: 2px; PADDING-TOP: 2px' vAlign=center align=right width=19> ";
        str += " <SPAN title='close' style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: red; MARGIN-RIGHT: 4px' id='btSysClose' ><img alt='' src='images/tab-close.gif' /></SPAN></TD> ";
        str += " </TR> ";
        str += " <TR> ";
        str += " <TD style='PADDING-RIGHT: 1px;PADDING-BOTTOM: 1px' colSpan=3 height= " + (h - 28) + " > ";
        str += " <DIV style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING-BOTTOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%'> " + this.title.replace(" {size} ", this.index > 0 ? this.index : 1) + " <BR><BR> ";
        str += " <DIV style='WORD-BREAK: break-all' align=left> ";
        if (this.index > 0) {
            for (i = 0; i < this.index; i++) {
                if (typeof (this.messages[i]) != " undefined ") {
                    str += " <A href=' " + (this.messages[i].link != null ? this.messages[i].link : this.action) + " ' hidefocus=true target='" + this.messages[i].target + "' id='btCommand1' title=' " + this.messages[i].title + " '><FONT color=#ff0000> " + this.messages[i].msg;
                    str += " </FONT></A><br> ";
                }
            }
            str += " </DIV> ";
        }
        else
            str += " <A href='javascript:void(0)' hidefocus=true id='btCommand'><FONT color=#ff0000> " + this.message + " </FONT></A></DIV> ";
        str += " </DIV> ";
        str += " </TD> ";
        str += " </TR> ";
        str += " </TABLE> ";
        str += " </DIV> ";
        oPopup.document.body.innerHTML = str;


        this.offset = 0;
        var me = this;

        oPopup.document.body.onmouseover = function() {
            me.pause = true;
        }
        oPopup.document.body.onmouseout = function() {
            me.pause = false;
        }

        var fun = function() {
            var x = me.left;
            var y = 0;
            var width = me.width;
            var height = me.height;

            if (me.offset > me.height) {
                height = me.height;
            }
            else {
                height = me.offset;
            }

            y = me.bottom - me.offset;
            if (y <= me.top) {
                me.timeout--;
                if (me.timeout == 0) {
                    window.clearInterval(me.timer);
                    if (me.autoHide) {
                        me.hide();
                    }
                }
            }
            else {
                me.offset = me.offset + me.step;
            }
            me.Pop.show(x, y, width, height);

        }

        this.timer = window.setInterval(fun, this.speed)

        var btClose = oPopup.document.getElementById("btSysClose");

        btClose.onclick = function() {
            if (typeof me.setSpeedEventobj !== 'undefined') {
                me.setSpeedEventobj();
            }
            me.close = true;
            me.hide();
        }

        var btCommand = oPopup.document.getElementById("btCommand");
        if (btCommand != null) {
            btCommand.onclick = function() {
                me.oncommand();
            }
        }
        else {
            var i, a;
            for (i = 0; (a = oPopup.document.getElementsByTagName("a")[i]); i++) {
                a.onclick = function() {
                    me.onlink(this);
                }
            }

        }
    }
    /*  
    ** 设置速度方法 
    * */
    ArchjsPopup.prototype.speed = function(s) {
        var t = 10;
        try {
            t = praseInt(s);
        }
        catch (e) {
        }
        this.speed = t;
    }
    /*  
    ** 设置步长方法 
    * */
    ArchjsPopup.prototype.step = function(s) {
        var t = 1;
        try {
            t = praseInt(s);
        }
        catch (e) {
        }
        this.step = t;
    }

    ArchjsPopup.prototype.rect = function(left, right, top, bottom) {
        try {
            this.left = left != null ? left : this.right - this.width;
            this.right = right != null ? right : this.left + this.width;
            this.bottom = bottom != null ? (bottom > screen.height ? screen.height : bottom) : screen.height;
            this.top = top != null ? top : this.bottom - this.height;
        }
        catch (e) {
        }
    }
}

function Message_Item(param) {
    this.link = param.linkUrl;
    this.msg = param.msg;
    this.title = param.title;
    this.target = param.target;
}