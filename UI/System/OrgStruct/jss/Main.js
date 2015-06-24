// JScript 文件

moveTo(0,0);
resizeTo(window.screen.availWidth,window.screen.availHeight);

//加载效果
setTimeout(function() {
	Ext.get('loading').remove();
	Ext.get('loading-mask').fadeOut({remove:true});
}, 3000); 

var north=new Ext.Panel({
    region:'north', 
    html:'<iframe src="../../../head.aspx" border="0" width="100%" height="52px" scrolling="no"></iframe>', 
    height:52, 
    autoScroll:false
});

var botton=new Ext.BoxComponent({
    el:"botton",
    height:15
});
//底部
var south=new Ext.Panel({
    border:false,
    region:"south",
    height:15,
    items:[botton]
});

var west=new Ext.Panel({
    //style:'background-color:#E7EDF6;',
    region:'west', 
    html:'<iframe id="menuhei" src="treeview.aspx" width="100%" height="100%" border="0" scrolling="no"></iframe>', 
    title:'乡镇财政资金监管信息系统', 
    width:220, 
    //是否可隐藏
    collapsible:true, 
    //是否可拖动
    split:true,
    loadMask:true, 
    autoScroll:true,
    listeners:{
        'collapse':function(obj){
            var tab = center.getActiveTab();
            //alert(tab.getInnerWidth());
            
            document.getElementById('wid2').value = tab.getInnerWidth();
            document.getElementById('stu').value = '1';
            document.cookie = "wid2="+tab.getInnerWidth();
            document.cookie = "stu=1";
            //只重画当前页签
            //window.frames["iframe_"+tab.id].menuCollapse(tab.getInnerWidth());
            //重画所有页签
            center.items.each(function(item){
                window.frames["iframe_"+item.id].menuCollapse(tab.getInnerWidth());
            });
            
            //Ext.Msg.alert('消息', '菜单收缩');
        },
        'expand':function(obj){
            setTimeout("mianMenuExpand()", 100);
            //Ext.Msg.alert('消息', '菜单打开');
        }
    }
});
function mianMenuExpand()
{
    var tab = center.getActiveTab();
    //alert(tab.getInnerWidth());
    
    document.getElementById('wid1').value = tab.getInnerWidth();
    document.getElementById('stu').value = '0';
    document.cookie = "wid1="+tab.getInnerWidth();
    document.cookie = "stu=0";
    //只重画当前页签
    //window.frames["iframe_"+tab.id].menuExpand(tab.getInnerWidth());
    //重画所有页签
    center.items.each(function(item){
        window.frames["iframe_"+item.id].menuCollapse(tab.getInnerWidth());
    });
}
var center=new Ext.TabPanel({
    //距两边间距
    style:'padding:0 0px 0 3px',
    region:'center',
    //默认选中第一个
    activeItem:0,
    //是否可隐藏
    //collapsible:true, 
    //如果Tab过多会出现滚动条
    enableTabScroll:true,
    //加载时渲染所有
    //deferredRender:false,
    //layoutOnTabChange:true,
    
    items:[{
        xtype:'panel',
        id:'index',
        iconCls:'tabs',
        title:'单位列表',
        
	    listeners:{
            //添加点击激活页签的事件，重画页面的页签控件。
            //主要解决菜单收缩展开后，没有激活的页签的子页签控件看不见的问题。
            'activate':function(){
                setTimeout("setWidth()", 1000);
            }
        },
        html:'<iframe id="iframe_index" src="CompanyList.aspx?pk_corp=" scrolling="no" frameborder="0" width="100%" height="100%"></iframe>'}],
    //添加关闭tab的右键菜单
    plugins: new Ext.ux.TabCloseMenu()
});
            
Ext.onReady(function(){
    var viewport = new Ext.Viewport({
        layout : 'border',
        items : [north,west,center,south]
    });
    //window.frames["menuhei"].setMenuHeight();
});

function addTabPanel(id, title, url){
    PanelMain(id, title, url);
}

function tabPanelChangePage(url){
    PanelMainChangePage(url);
}