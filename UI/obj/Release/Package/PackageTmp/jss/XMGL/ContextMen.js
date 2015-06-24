
var Rmenu=null;
var menuType={menuItem:1,menuCheck:2,menuSeparator:3}//菜单类型
function Bind(objName,detailNum)
{
    Ext.onReady(function(){
          //禁止整个页面的右键
          Ext.getDoc().on("contextmenu", function(e){
                e.stopEvent();
          });
          //创建菜单
          createMenu(detailNum);
          //注册右键
          Ext.get(objName).on("contextmenu",function(e){
               Rmenu.showAt(e.getPoint()); //显示在当前位置 
          });
//          //添加菜单
//          Ext.get("btnAddMenu").on("click",function(){
//                addMenu(menuType.menuItem);
//          });
//          //菜单删除按钮注册
//          Ext.get("btnDelMenuItem").on("click",function(){
//             var index=parseInt(Ext.get("txtMenuIndex").getValue());
//             var ItemCount=Rmenu.items.length;
//             if(!isNaN(index) && index!=null)
//             {
//                if(index<(ItemCount+1)&&index>0)
//                {
//                    DelMenuItem(index);
//                }
//                else
//                {
//                 alert("索引超出数组界限");
//                 return;
//                }
//             }
//          });
      });

}
      //创建菜单
      function createMenu(detailNum)
      {
          Rmenu=new Ext.menu.Menu([ 
                    //new Ext.menu.BaseItem(document.getElementById('fileUpArea')),
                    { 
                        text:"添加附件", 
                        value:detailNum,
                        handler:function(e){  menuClick(e); } 
                    }, 
                    {       text:"删除附件", 
                            value:detailNum,
                            handler:function(e){ menuClick(e);} 
                    }
         ]); 
      }
      
      //添加菜单
      function addMenu(menuType)
      {
        var text=Ext.get("txtMenuText").getValue();
        if(text!=null)
        {
            if(menuType==1)//普通菜单项
            {
                var menuItem=new Ext.menu.Item({text:text,handler:function(e){menuClick(e);}});
                Rmenu.addMenuItem(menuItem);
            }
            else if(menuType==2)//checkbox菜单项
            {
                var menuCheck=new Ext.menu.CheckItem({text:text,checkHandle:function(e){}});
                Rmenu.addMenuItem(menuCheck);
            }
            else//菜单分隔符项
            {
                var menuSeparator=new Ext.menu.Separator({text:text,checkHandle:function(e){menuClick(e);}});
                Rmenu.addMenuItem(menuSeparator);
            }
            Ext.get("txtMenuText").set({"value":""});
        }
      }
      //设置菜单可用性
      function DelMenuItem(index)
      {
        //Rmenu.items.item(index).hide();//隐藏
        Rmenu.items.item(index).disable();
      }
      //遍历右键所有项
      function ForeachMenu()
      {
         var count=Rmenu.items.length;
         var txt="";
         for(var i=0;i<count;i++)
         {
           txt+=Rmenu.items.item(i).text+",";
         }
         alert(txt);
      }
      //菜单点击事件处理
      function menuClick(menuItem)
      {
        switch(menuItem.text)
        {
            case "添加附件":
                //AddFile();
                break;
            case "删除附件":
                break;
        }
      }
      function AddFile()
      {try{
            document.getElementById("file1").click();
      //document.getElementById("file1").fireEvent('onChange') ;
            }catch(e){alert(e);};
      }