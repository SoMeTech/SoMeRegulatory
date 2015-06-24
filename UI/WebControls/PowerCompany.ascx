<%@ control language="C#" autoeventwireup="true" inherits="WebControls_PowerCompany" CodeBehind="PowerCompany.ascx.cs"%>
    
<script type="text/javascript">
    function postBackByObject() {
        var o = window.event.srcElement;
        if (o.tagName == "INPUT" && o.type == "checkbox") {
            __doPostBack("", "");
        }
    }

    //获取元素指定tagName的父元素
    function public_GetParentByTagName(element, tagName) {
        var parent = element.parentNode;
        var upperTagName = tagName.toUpperCase();
        //如果这个元素还不是想要的tag就继续上溯
        while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
            parent = parent.parentNode ? parent.parentNode : parent.parentElement;
        }
        return parent;
    }

    //设置节点的父节点Cheched——该节点可访问，则它的父节点也必能访问
    function setParentChecked(objNode) {
        var objParentDiv = public_GetParentByTagName(objNode, "div");
        if (objParentDiv == null || objParentDiv == "undefined") {
            return;
        }
        var objID = objParentDiv.getAttribute("ID");
        objID = objID.substring(0, objID.indexOf("Nodes"));
        objID = objID + "CheckBox";
        var objParentCheckBox = document.getElementById(objID);
        if (objParentCheckBox == null || objParentCheckBox == "undefined") {
            return;
        }
        if (objParentCheckBox.tagName != "INPUT" && objParentCheckBox.type == "checkbox")
            return;
        objParentCheckBox.checked = true;
        setParentChecked(objParentCheckBox);
    }

    //设置节点的子节点uncheched——该节点不可访问，则它的子节点也不能访问
    function setChildUnChecked(divID) {
        var obHRhild = divID.children;
        var count = obHRhild.length;
        for (var i = 0; i < obHRhild.length; i++) {
            var tempObj = obHRhild[i];
            if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                tempObj.checked = false;
            }
            setChildUnChecked(tempObj);
        }
    }

    //设置节点的子节点cheched——该节点可以访问，则它的子节点也都能访问
    function setChildChecked(divID) {
        var obHRhild = divID.children;
        var count = obHRhild.length;
        for (var i = 0; i < obHRhild.length; i++) {
            var tempObj = obHRhild[i];
            if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                tempObj.checked = true;
            }
            setChildChecked(tempObj);
        }
    }

    //触发事件
    function CheckEvent() {
        var objNode = event.srcElement;

        if (objNode.tagName != "INPUT" || objNode.type != "checkbox")
            return;

        if (objNode.checked == true) {
            setParentChecked(objNode);
            var objID = objNode.getAttribute("ID");
            var objID = objID.substring(0, objID.indexOf("CheckBox"));
            var objParentDiv = document.getElementById(objID + "Nodes");
            if (objParentDiv == null || objParentDiv == "undefined") {
                return;
            }
            setChildChecked(objParentDiv);
        }
        else {
            var objID = objNode.getAttribute("ID");
            var objID = objID.substring(0, objID.indexOf("CheckBox"));
            var objParentDiv = document.getElementById(objID + "Nodes");
            if (objParentDiv == null || objParentDiv == "undefined") {
                return;
            }
            setChildUnChecked(objParentDiv);
        }
    }
</script>
<fieldset style="font-size:9pt; height:370px; width:300px;">
    <legend style="color:red">管理范围列表</legend>
    <div style="width:300px; height:355px; overflow-y:scroll;">
        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="1" ShowCheckBoxes="All" ShowLines="True" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged">
        </asp:TreeView>
    </div>
</fieldset>

