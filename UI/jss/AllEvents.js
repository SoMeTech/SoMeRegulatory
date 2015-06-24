// JScript 文件
//////////////////////////////////////////////////////////////////////////////////////
//关闭TabPanel标签
Ext.ux.TabCloseMenu = function(){
  var tabs, menu, ctxItem;
  this.init = function(tp) {
     tabs = tp;
     tabs.on('contextmenu', onContextMenu);
  }
  function onContextMenu(ts, item, me) {
     if (!menu) { 
        menu = new Ext.menu.Menu([{
           id: tabs.id + '-close',
           text: '关闭当前标签',
           iconCls:"closetabone",
           handler : function() {
              tabs.remove(ctxItem);
           }
        },{
           id: tabs.id + '-close-others',
           text: '除此之外全部关闭',
           iconCls:"closetaball",
           handler : function() {
              tabs.items.each(function(item){
                 if(item.closable && item != ctxItem){
                    tabs.remove(item);
                 }
              });
           }
        }]);
     }
     ctxItem = item;
     var items = menu.items;
     items.get(tabs.id + '-close').setDisabled(!item.closable);
     var disableOthers = true;
     tabs.items.each(function() {
        if (this != item && this.closable) {
           disableOthers = false;
           return false;
        }
     });
     items.get(tabs.id + '-close-others').setDisabled(disableOthers);
     menu.showAt(me.getXY());
  }
};
   
//内容为Panel
PanelMain = function(id, title, url, code) {
    var tab = center.getItem(id);

    if (url.indexOf('?') > 0)
        url = url + "&strTitle=" + escape(title);
    else
        url = url + "?strTitle=" + escape(title);
    //alert(url);
    //var width = center.getActiveTab().getInnerWidth();
    if (!tab) {
        tab = center.add({
            id: id,
            iconCls: 'tabs',

            xtype: 'panel',
            title: title,
            closable: true,
            layout: 'fit',
            loadMask: true,
            listeners: {
                //添加点击激活页签的事件，重画页面的页签控件。
                //主要解决菜单收缩展开后，没有激活的页签的子页签控件看不见的问题。
                'activate': function() {
                    setTimeout("setWidth()", 100);
                }
            },

            html: '<iframe id="iframe_' + id + '" src="' + url + '" scrolling="no" frameborder="0" width="100%" height="100%"></iframe>'
        });
    }
    center.setActiveTab(tab);
};

//关闭当前标签
TabClose = function(){
    var tab = center.getActiveTab();
    center.remove(tab);
};

//调用子页面上的重置宽度方法
function setWidth(){
    var tab_child = center.getActiveTab();
    
    //确认页面加载完成
    //alert(window.frames["iframe_"+tab_child.id].document.readyState);
    if(window.frames["iframe_"+tab_child.id].document.readyState == "complete"){
        try{
        window.frames["iframe_"+tab_child.id].menuCollapse(tab_child.getInnerWidth());
        }catch(e){}
    }
};

function IsCloseTab() {
    Ext.Msg.confirm("关闭确认框", "您确定要退出此窗体吗？", function(button) {
        if (button == 'yes') {
            window.parent.removeThisTab();
        }
        else {
            return false;
        }
    });
}


function window.onbeforeunload()
{
    return '您即将关闭浏览器,确认要继续吗？';
}
function document.onkeydown()    
{    
    if ( event.keyCode==116)    
    {
        document.body.onbeforeunload=null;
//       event.keyCode = 0;    
//       event.cancelBubble = true;    
//       return false;    
    }    
}