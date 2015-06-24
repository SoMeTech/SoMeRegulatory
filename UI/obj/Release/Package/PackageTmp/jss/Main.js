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
    html:'<iframe src="head.aspx" id="topFrame" border="0" width="100%" height="100px" scrolling="no"></iframe>', 
    height:100, 
    autoScroll:false
});

var botton=new Ext.BoxComponent({
    el:"botton",
    height:35
});
//底部
var south=new Ext.Panel({
    border:false,
    region:"south",
    height:35,
    items:[botton]
});

var west = new Ext.Panel({
    region: 'west',
    html: '<iframe id="menuhei" src="System/Menu/treeview.aspx" width="100%" height="100%" border="0" scrolling="no"></iframe>',
    title: '功能导航',
    width: 300,
    //添加动画效果
    layoutConfig: {
        animate: true
    },
    //是否可隐藏
    collapsible: true,
    //是否可拖动
    split: true,
    loadMask: false,
    //是否自动滚动条
    autoScroll: false,
    listeners: {
        'collapse': function(obj) {
            var tab = center.getActiveTab();

            document.getElementById('wid2').value = tab.getInnerWidth();
            document.getElementById('stu').value = '1';
            document.cookie = "wid2=" + tab.getInnerWidth();
            document.cookie = "stu=1";

            //只重画当前页签
            //确认页面加载完成
            try
            {
                if (window.frames["iframe_" + tab.id].document.readyState == "complete") {
                    window.frames["iframe_" + tab.id].menuCollapse(tab.getInnerWidth());
                }
            }
            catch(e){
                //alert(e)
            }
            //重画所有页签
            //center.items.each(function(item){
            //    if(window.frames["iframe_"+item.id].document.readyState == "complete"){
            //        window.frames["iframe_"+item.id].menuCollapse(tab.getInnerWidth());
            //    }
            //});
        },
        'expand': function(obj) {
            setTimeout("mianMenuExpand()", 100);
        }
    }
});
function mianMenuExpand(){
    var tab = center.getActiveTab();
    
    document.getElementById('wid1').value = tab.getInnerWidth();
    document.getElementById('stu').value = '0';
    document.cookie = "wid1="+tab.getInnerWidth();
    document.cookie = "stu=0";
    
    //只重画当前页签
    //确认页面加载完成
    try
    {
        if (window.frames["iframe_" + tab.id].document.readyState == "complete") {
            window.frames["iframe_" + tab.id].menuExpand(tab.getInnerWidth());
        }
    }catch(e)
    {
        //alert(e);
    }
    //重画所有页签
    //center.items.each(function(item){
    //    if(window.frames["iframe_"+item.id].document.readyState == "complete"){
    //        window.frames["iframe_"+item.id].menuCollapse(tab.getInnerWidth());
    //    }
    //});
}
var center=new Ext.TabPanel({
    border:false,
    //距两边间距
    style:'padding:0 0px 0 3px',
    region:"center",
    //默认选中第一个
    activeItem:0,
    //是否可隐藏
    //collapsible:true, 
    //如果Tab过多会出现滚动条
    enableTabScroll:true,
    //加载时渲染所有
    //deferredRender:false,
    layoutOnTabChange:true,
    defaults: {
		style: "background-color:#FFFFFF"
	},

    items:[{
        xtype:"panel",
        id:"index",
        iconCls:"tabs",
        title:'欢迎使用',
        html:'<iframe id="iframe_index" src="Welcome.aspx" scrolling="no" frameborder="0" width="100%" height="100%"></iframe>'}],
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

function removeThisTab(){
    TabClose();
}


////控制tab页面容器大小的函数 
//function allComResize(){
//    var w = Ext.getCmp('center').getActiveTab().getInnerWidth();  
//    var h = Ext.getCmp('center').getActiveTab().getInnerHeight(); 
//      
//    //循环遍历
//    center.items.each(function(item){
//        item.setWidth(w);
//        item.setHeight(h);
//    });
//}
////通过window.onresize事件来执行allComResize函数控制tab容器的大小
//var oTime;
//window.onresize = function(){
//    if (oTime)
//    {
//        clearTimeout(oTime);
//    }
//    oTime = setTimeout("allComResize()", 100); //延迟100毫秒执行
//}

//execl输出
function tbSaveExcel(SaveName,tbName,_Window)
{//整个表格拷贝到EXCEL中
   // alert(SaveName+","+tbName+","+_Window);
    var tableid=tbName;
    var curTbl = _Window.document.getElementById(tableid);
    var oXL = new ActiveXObject("Excel.Application");
    //创建AX对象excel
    var oWB = oXL.Workbooks.Add();
    //获取workbook对象
    var xlsheet = oWB.Worksheets(1);
    //激活当前sheet
    var sel = _Window.document.body.createTextRange();
    sel.moveToElementText(curTbl);
    //把表格中的内容移到TextRange中
    sel.select();
    //全选TextRange中内容
    sel.execCommand("Copy");
    //复制TextRange中内容
    xlsheet.Paste();
    //粘贴到活动的EXCEL中
    oXL.Visible = true;
    //设置excel可见属性

    try{
        var fname = oXL.Application.GetSaveAsFilename(SaveName+".xls", "Excel Spreadsheets (*.xls), *.xls");
        if(fname){
            oWB.SaveAs(fname);
        }
    

    }catch(e){
        print("Nested catch caught " + e);
    }finally{
        oWB.Close(savechanges=false);
        oXL.Quit();
        oXL=null;
         //结束excel进程，退出完成
        idTmr = window.setInterval("Cleanup();",1);
    }
}

function newSaveWord()
{
    
    document.getElementById("Button1").click();
    
}

function tbSaveWord(SaveName,tbName,_Window)
{
     //debugger;
            try {
                
                var fileName = SaveName;  //文件名
                
                var areaRes = document.getElementById(tbName);  //指定要输入区域
                var wordObj = new ActiveXObject("Word.Application");  //指定输出类型
                var docObj = wordObj.Documents.Add("", 0, 1);
                var oRange = docObj.Range(0, 1);
                var sel = document.body.createTextRange();
                sel.moveToElementText(areaRes);
                sel.select();
                sel.execCommand("Copy");
                oRange.Paste();
                wordObj.Application.Visible = true;

                var filePath=showDialog();
                if(filePath) 
                    docObj.SaveAs( filePath);
                
                function showDialog(){
                                var  dial=wordObj.FileDialog(2);
                                return dial.show()==-1?dial.SelectedItems(1):'';
                         }   
            }
            catch (e) {
                print("Nested catch caught " + e);
            }
            finally {
                docObj.Close(savechanges=false);
                wordObj.Quit();
                wordObj=null;
                 //结束excel进程，退出完成
                idTmr = window.setInterval("Cleanup();",1);
            }


}
        


function Cleanup() {
    window.clearInterval(idTmr);

    CollectGarbage();
  }