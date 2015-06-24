<%@ page language="C#" autoeventwireup="true" smartnavigation="true" enableeventvalidation="false" stylesheettheme="Default" inherits="Menu_treeview1" CodeBehind="treeview1.aspx.cs"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
        body{
            scrollbar-face-color: #A8A8DF;
            scrollbar-shadow-color: #A8A8DF;
            scrollbar-highlight-color: #ffffff;
            scrollbar-arrow-color: #ffffff;
        }
    </style>
    <style type="text/css">
    .panelCss{
        overflow-x:hidden;
    }
    </style>
</head>
<body style="background-color:#cfe5f2;overflow:visible;">
    <form id="form1" runat="server">
        <table id="table1" cellspacing="0" cellpadding="0" border="0" style="border-color:#eaf4fa; width:100%;">
			<tr>
				<td id="menuheight" runat="server" valign="top" align="left" width="100%">
				    <asp:Panel ID="panel1" CssClass="panelCss" ScrollBars="Vertical" runat="server">
                        <asp:TreeView ID="TreeView1" runat="server"  Height="100%"
                            ImageSet="Arrows" Target="mainFrame" ExpandDepth="1" ShowLines="True" Width="100%" BorderColor="beige" ShowExpandCollapse="True">
                            <ParentNodeStyle Font-Bold="False" ImageUrl="~/images/open2.gif" />
                            <HoverNodeStyle Font-Underline="False" ForeColor="#5555DD" />
                            <SelectedNodeStyle BackColor="#BFDBFF" Font-Underline="False" 
                                ForeColor="#FF3300" HorizontalPadding="0px"
                                ImageUrl="~/images/open2.gif" VerticalPadding="0px" />
                            <RootNodeStyle ImageUrl="~/images/tree_root.gif" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                ImageUrl="~/images/file.gif" NodeSpacing="0px" Font-Underline="false" VerticalPadding="0px" Width="100%" CssClass="cursor:hand" />
                        </asp:TreeView>
                    </asp:Panel>
                </td>
			</tr>
			
		</table>
    </form>
    
    <script type="text/javascript"> 
        // 点击时激发的事件 
        function CheckEvent()
        {
            var objNode = event.srcElement;//获取事件对象
        
            //alert(objNode.tagName);
            //alert(objNode.href);
            //alert(objNode.title);
        
            //if (objNode.tagName == "SPAN" && objNode.href != "#" && objNode.href != "../")
            if (objNode.tagName == "A" && objNode.title != "")
            {
                //            alert('id:'+objNode.id);
                //            alert('href:'+objNode.href);
                //            alert('title:'+objNode.title);
                //            alert('text:'+objNode.innerText);
                //            alert('value:'+objNode.value);
                //            alert('target:'+objNode.target);
                //            alert(objNode);
                //            return;
                var objtarget=objNode.title.split('|')[0];
                var objtitle=objNode.title.split('|')[1];
            
                if(objtarget == "mainFrame")
                {
                    //window.parent.frames('mainFrame').addTabPanel(objNode.innerText, objNode.title);
 
                    window.parent.addTabPanel(encodeURIComponent(objNode.innerText), objNode.innerText, objtitle, objNode.value);
                }else
                {
                    var heig=window.screen.height-75;
                    window.open('../../'+objtitle, "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + window.screen.width + ",height=" + heig + "px,left=0,top=0");
                    //                if(objtitle.indexOf("PublicReport.aspx")==-1)
                    //                    window.open('../../'+objtitle, "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + window.screen.width + ",height=" + heig + "px,left=0,top=0");
                    //                else
                    //                    window.open('../../'+objtitle, "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + window.screen.width + ",height=" + heig + "px,left=0,top=0");
                }
            }
        }
    
        var treeView = document.getElementById("<% = this.TreeView1.ClientID %>");　　//获取容器对象
    var items = treeView.getElementsByTagName("A");  //获取所有A的tag（也就是链接了)
    //循环替换
    for(var i = 0; i < items.length; i++)    
    {
        var eventStr = items[i].href;
        //要判断链接中是否包含TreeView_ToggleNode，因为TreeView_ToggleNode这个函数是负责折叠的，所以不能置空
        if (eventStr.indexOf("TreeView_ToggleNode") == -1)
        {
            if(items[i].target == "")
            {
                items[i].onclick = "";   //将链接的onclick事件置空
                items[i].href = "#";
            }
        }
    }
    
        
    function setMenuHeight(){
        //获取cookie字符串
        var strCookie=document.cookie;
        //将多cookie切割为多个名/值对
        var arrCookie=strCookie.split("; ");
        var hei = 800;
        
        //遍历cookie数组，处理每个cookie对
        for(var i=0;i<arrCookie.length;i++){
            var arr=arrCookie[i].split("=");
            
            //找到名称为userId的cookie，并返回它的值
            if("hei"==arr[0]){
                hei=arr[1];
                break;
            }
        }
        
        var td = document.getElementById('menuheight');
        td.style.height = hei - 5;
        //        alert(td.style.height);
        var panel = document.getElementById('<%=panel1.ClientID %>');
        panel.style.height = hei - 5;
        //        alert(panel.style.height);
        //        alert(arrCookie);
        var table1 = document.getElementById("table1");
        table1.style.height=table1.offsetHeight-5;
    }
    setTimeout("setMenuHeight()", 300);
    
    //屏蔽右键
    function document.oncontextmenu() 
    { 
        //return false; 
    } 
    </script>
    
</body>
</html>