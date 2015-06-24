
    var RowCount=15;
    var ds = null;
    var grid = null;
    //jColumn  JSON类型数据-构建表格的参数
    //url 获取JSON数据的页面
    //DivName 
    //zdBianhao 自动编号
    //colChebox 列是否有chebox多选框
    //displayInfo 控制是否显示displayMsg，emptyMsg设置的提示
    function DrawTable(jColumn,url,DivName,zdBianhao,colChebox,displayInfo)
    {
    try{
        var sm = new Ext.grid.CheckboxSelectionModel();
        var cm = null;
        var umHtme='cm = new Ext.grid.ColumnModel([';
        var dsHtme="ds = new Ext.data.Store({proxy: new Ext.data.HttpProxy({url:'"+url+"'}),"+
        "reader: new Ext.data.JsonReader({totalProperty: 'totalProperty',root: 'root'},[";
        
        if(zdBianhao)
            umHtme+='new Ext.grid.RowNumberer(),';
        if(colChebox)
            umHtme+='sm,';
        for(var i=0;i<jColumn.length;i++)
        {
            umHtme+="{header:'"+jColumn[i].CName+"',dataIndex:'"+jColumn[i].CId+"',sortable:"+jColumn[i].sortable+",renderer:"+jColumn[i].renderer+"}"
            dsHtme+="{name: '"+jColumn[i].CId+"'}";
            
            if(i<jColumn.length-1)
            {
                umHtme+=",";
                dsHtme+=",";
            }
        }
        umHtme+="]);";
        dsHtme+="])});";
        
        eval(umHtme);
        eval(dsHtme);
        function funA(value, cellmeta, record, rowIndex, columnIndex, store) 
        {
            return "<span style='color:green;font-weight:bold;'>"+value+"</span>";
        }
        function funB(value, cellmeta, record, rowIndex, columnIndex, store) 
        {
            return "<span style='color:red;font-weight:bold;'>"+value+"</span>";
        }
        
        grid = new Ext.grid.GridPanel({
            el: DivName,
            ds: ds,
            cm: cm,
            sm: sm,
            bbar: new Ext.PagingToolbar({
                pageSize: RowCount,
                store: ds,
                displayInfo: displayInfo,
                displayMsg: '显示第 {0} 条到 {1} 条记录，一共 {2} 条',
                emptyMsg: "没有记录"
                })
            });
            grid.render();
            ds.load({params:{start:0,limit:RowCount}});
            }catch(e){alert(e);}
    }
    
    function add()
    {        
            try{    
    NewRecordTemp = Ext.data.Record.create([{ 
            AUTO_NO : '' ,
            PD_PROJECT_CODE: '',
            PD_PROJECT_ATTACH_TYPE: '',
            PD_PROJECT_ATTACH_NAME: '',
            PD_PROJECT_ATTACH_NAME_SYSTEM: ''
            }]); 
            //新record 
            var newRecord = NewRecordTemp;
            //insert to DS 
            ds.insert(0, newRecord); 
            
            }catch(e){alert(e);}
    }
    