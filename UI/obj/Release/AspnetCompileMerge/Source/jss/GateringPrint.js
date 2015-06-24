
var mainPrintElement;//主要打印元素

// 参数说明
// pk-------------业务主表PK
// propk----------业务进度表PK
// bcjnje---------本次缴纳金额
mainPrintElement=function(pk, propk, bcjnje){

    PrintElementStore = new Ext.data.Store({
        proxy:new Ext.data.HttpProxy({
            url:"GateringPrintJsonData.aspx",
            method:"POST"
        }),
        reader:new Ext.data.JsonReader({
	        fields:fields,
            root:"data",
            id:"typeid",
            totalProperty:"totalCount"
        })
	});
	//加载时参数
	RoomTypestore.load({params:{start:0,limit:pageSize}}); 
	
    var divs = new Ext.Panel({
        region:'main', 
        html:{
            
        },
        //是否可隐藏
        collapsible:false, 
        //是否可拖动
        split:true,
        loadMask:false, 
        autoScroll:false
    });
}