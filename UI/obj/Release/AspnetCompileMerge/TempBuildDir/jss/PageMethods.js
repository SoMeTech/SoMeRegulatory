// JScript 文件

//////////////////////  右下角提示框  ///////////////////////////////////////////////////
ShowPopup = function(param, paramMes) {
    //var pop1 = new ArchjsPopup({ id: 'pop1', title: '你有三个待办事宜', caption: '消息窗口', message: '查看', target: '_blank', action: 'http://www.163.com' });
    //pop1.addMessage({ linkUrl: "http://www.163.com", msg: "test", title: "点击链接", target: "_blank" });

    var pop1 = new ArchjsPopup({ id: param.id, title: param.title, caption: param.caption, message: param.message, target: param.target, action: param.action });
    //pop1.addMessage({ linkUrl: paramMes.linkUrl, msg: paramMes.msg, title: paramMes.title, target: paramMes.target });
    pop1.show();
}

//////////////////////  消息提示框  ///////////////////////////////////////////////////
//消息提示框(消息提示，弹出消息后关闭本窗体)
ShowMsg = function(val, title) {
    if (title != "undefined") {
        Ext.Msg.alert(title, val);
    }
    else {
        Ext.Msg.alert("消息提示框", val, function(button) {
            window.close();
        });
    }
};

//消息提示框(消息提示，打开的窗体弹出消息后刷新父窗体再关闭本窗体)
ShowMsg_TS = function(val, win) {
    if (win != "undefined") {
        Ext.Msg.alert("消息提示框", val, function(button) {
            try {
                win.opener.location.reload();
            }
            catch (e) { }
            win.close();
        });
    }
    else {
        Ext.Msg.alert("消息提示框", val);
    }
};

//消息提示框(消息提示，打开的窗体弹出消息后刷新父窗体)
ShowMsg_TS_Open = function(win, val){
    Ext.Msg.alert("消息提示框", val, function(button) {
        win.focus();
        if(win != window)
            window.location.reload();
    });
};

//显示消息(先提示登录已超时，然后跳转到 val 指定的页)
ShowMsg_Login = function(val){
    Ext.Msg.alert("登录超时提示框", "登录已超时，请重新登录！", function(button) {
        window.location= val;
    });
};


//////////////////////////删除、关闭、退回、授权等操作确认框////////////////////////////////////////////////////////////////////
function IsClose() {
    Ext.Msg.confirm("关闭确认框", "您确定要退出此窗体吗？", function(button) {
        if (button == 'yes') {
            window.close();
        }
        else {
            return false;
        }
    });
}

function IsDo(val) {
    Ext.Msg.confirm(val + "确认框", "您确定要对该笔数据进行" + val + "操作吗？", function(button) {
        if (button == 'yes') {
            return true;
        }
        else {
            return false;
        }
    });
}


/////////////////////////  操作确认框  ///////////////////////////////////////////////////////
//操作确认框
ShowConfirm = function(title, val){
    Ext.Msg.confirm(title, val, function(button){
        if(button == 'yes'){
            //do yes things
            return true;
        }
        else{
            //do yes things
            return false;
        }
    });
};

//显示确认框(操作确认)
ShowConfirm_CZ = function(val){
    return Ext.Msg.confirm("操作确认框", val, function(button){
        if(button == 'yes'){
            //do yes things
            return true;
        }
        else{
            //do yes things
            return false;
        }
    });
};

//显示确认框(删除)
ShowConfirm_Del = function(){
    Ext.Msg.confirm("删除确认框", "您确定要删除该笔数据吗？", function(button) {
        if(button == 'yes'){
            //do yes things
            return true;
        }
        else{
            //do yes things
            return false;
        }
    });
};

tabClose = function(){
    Ext.Msg.confirm("关闭确认框", "您确定要关闭当前窗口吗？", function(button) {
        if(button == 'yes')
            removeThisTab();
    });
};



//////////////////////  head1.aspx 注销、退出方法  ///////////////////////////////////////////////////
//退出
topClosePage = function(){
    Ext.Msg.confirm("退出确认框", "您确定要退出系统吗？", function(button) {
        if(button == 'yes')
        {
            CloseXtit();
            window.close();
        }
    });
};

//注销
topLogOut = function(){
    Ext.Msg.confirm("注销确认框", "您确定要注销当前用户吗？", function(button) {
        if(button == 'yes')
        {
            CloseXtit();
            window.location='index.aspx';
        }
    });
};

function CloseXtit()
{
    window.parent.document.body.onbeforeunload="";
}