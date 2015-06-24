<%@ page language="C#" autoeventwireup="true" CodeBehind="SMS_BookList.aspx.cs" inherits="Input_SMS_SMS_BookList" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    
      <script type="text/javascript">
          function selectCheck() {
              var els = event.srcElement;//获取当前事件的对象
              if (els.type == 'checkbox') {
                  var divId = els.id.replace('CheckBox', 'Nodes');//获取子节点的层Id
                  var divObj = document.getElementById(divId);//获取层对象
                  if (divObj == null)
                      return;
                  var checkBoxs = divObj.getElementsByTagName('input');//获取层下所有input 控件
                  for (var i = 0; i < checkBoxs.length; i++) {
                      if (checkBoxs[i].type == 'checkbox') //控件为checkbox
                      {
                          checkBoxs[i].checked = els.checked;//设置复选框状态
                      }
                  }
              }
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All"  onclick="selectCheck()" Height="257px"  Width="142px" Target="rightFrame"></asp:TreeView>        
       <asp:Button ID="btnok" runat="server" OnClick="btnok_onclick" />
      
    </div>
    </form>
</body>
</html>
