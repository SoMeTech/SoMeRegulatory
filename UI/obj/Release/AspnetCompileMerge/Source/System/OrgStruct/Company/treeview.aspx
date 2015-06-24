<%@ page language="C#" autoeventwireup="true" smartnavigation="true" CodeBehind="treeview.aspx.cs" enableeventvalidation="false" stylesheettheme="Default" inherits="Company_treeview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body style="background-color:#eaf4fa;">
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" border="0" bordercolor="#eaf4fa" width="100%">
			<tr>
				<td id="menuheight" runat="server" valign="top" align="left" width="100%">
				    <asp:Panel ID="panel1" ScrollBars="Auto" runat="server">
                        <asp:TreeView ID="TreeView1" runat="server" 
                            ImageSet="Arrows" Target="mainFrame" ExpandDepth="0" ShowLines="True" 
                            Width="100%" BorderColor="beige" ShowExpandCollapse="True">
                            <ParentNodeStyle Font-Bold="False" ImageUrl="~/images/open2.gif" />
                            <HoverNodeStyle Font-Underline="False" ForeColor="#5555DD" />
                            <SelectedNodeStyle BackColor="#BFDBFF" Font-Underline="False" ForeColor="#5555DD" HorizontalPadding="0px"
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
        function CheckEvent() {
            var objNode = event.srcElement;//获取事件对象

            if (objNode.tagName == "A" && objNode.title != "") {
                if (objNode.target == "") {
                    //window.parent.tabPanelChangePage(objNode.title);
                    window.parent.addTabPanel(objNode.id, objNode.innerText, objNode.title);
                }
            }
        }

        var treeView = document.getElementById("<% = this.TreeView1.ClientID %>");　　//获取容器对象
        var items = treeView.getElementsByTagName("A");  //获取所有A的tag（也就是链接了)
        //循环替换
        for (var i = 0; i < items.length; i++) {
            var eventStr = items[i].href;
            //要判断链接中是否包含TreeView_ToggleNode，因为TreeView_ToggleNode这个函数是负责折叠的，所以不能置空
            if (eventStr.indexOf("TreeView_ToggleNode") == -1) {
                if (items[i].target == "") {
                    items[i].onclick = "";   //将链接的onclick事件置空
                    items[i].href = "#";
                }
            }
        }

        function setMenuHeight() {
            //获取cookie字符串
            var strCookie = document.cookie;
            //将多cookie切割为多个名/值对
            var arrCookie = strCookie.split("; ");
            var hei = 621;

            //遍历cookie数组，处理每个cookie对
            for (var i = 0; i < arrCookie.length; i++) {
                var arr = arrCookie[i].split("=");

                //找到名称为userId的cookie，并返回它的值
                if ("hei" == arr[0]) {
                    hei = arr[1];
                    break;
                }
            }
            var td = document.getElementById('menuheight');
            td.style.height = hei;
        }
        setTimeout("setMenuHeight()", 300);






        // 点击时激发的事件 
        //function CheckEvent()
        //{
        //var objNode = event.srcElement;//获取事件对象

        //if (objNode.tagName == "A" && objNode.title != "")
        //{
        //alert("pk_corp='" + objNode.title + "'");
        //window.parent.frames('mainFrame').dolistchange("pk_corp='" + objNode.title + "' or FatherPK='" + objNode.title + "'");
        //}
        //}

        //var treeView = document.getElementById("<% = this.TreeView1.ClientID %>");　　//获取容器对象
        //var items = treeView.getElementsByTagName("A");  //获取所有A的tag（也就是链接了)
        ////循环替换
        //for(var i = 0; i < items.length; i++)    
        //{    
        //var eventStr = items[i].href;    
        //要判断链接中是否包含TreeView_ToggleNode，因为TreeView_ToggleNode这个函数是负责折叠的，所以不能置空
        //if (eventStr.indexOf("TreeView_ToggleNode") == -1)
        //{
        //items[i].onclick = "";   //将链接的onclick事件置空
        //items[i].href = "#";
        //}
        //}
    </script>
    
</body>
</html>
