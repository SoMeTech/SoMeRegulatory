<%@ page language="C#" autoeventwireup="true" CodeBehind="OnKeyTongBu.aspx.cs" inherits="Work_TongBu_OnKeyTongBu" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>乡财县管基础资料同步</title>
    <link href="dialog.css" rel="stylesheet" type="text/css" />

    <script src="../../jquery.easyui/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="Dialog.js" type="text/javascript"></script>
    
     <style type="text/css">
        .boxer{
            text-align:center;  padding:20px 20px 20px 20px;
        }
        .gvTitle{
	        color:red; font-size:14px; font-weight:bold; text-align:left;  margin-bottom:10px;
        }
        .gvLine{
	        height:2px; background:#1D89D7; line-height:2px;font-size:0px;
         }
        .oprt-pnl{
            background:url(../images/oprt-pnl-bg.gif); background-repeat:repeat-x; height:27px; 
            line-height:27px; text-align:left; margin-bottom:1px; border:solid 1px #7F9DB9;
            }
        a.button{margin-top: 5px;
	        padding-right: 1px; display: block; font-size: 9pt; vertical-align: text-bottom; 
	        color: #444AA0; text-align: center; text-decoration: none
        }
        a.button:hover{
            background: url(../images/btnBg.gif) no-repeat -100px 100%;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $('#btnTB').click(function () {
                ;
                $("#div_TB").show();

                $.ajax({
                    type: "post",
                    url: "OnKeyTongBu.aspx/btn_tb",
                    //data:"{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert(data.d);

                        $("#div_TB").hide();

                    },
                    error: function (e) {
                        alert(e);
                    }
                });

            })

        })

    </script>
      <script language="javascript">
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
    <%--<div style="height: 50px; width: 100%;">
    </div>--%>
     <div class="gvTitle">
     <p></p>
            <asp:Label ID="lblTitle" runat="server" Text="乡财县管基础资料同步"></asp:Label>
            <div class="gvLine"></div>
        </div>
    
    <div style="border-color: Olive; border-width: 2px; margin-left:200px;">
        <h3>
            乡财县管基础资料同步</h3>
        <div style="margin-top: 20px;" >
            <div>
                <asp:Button ID="btnTB" runat="server" Text="一键同步" Height="34px" Width="78px" /></div>
        </div>
    </div>
    <!--弹出层时背景层DIV-->
    <div id="div_TB" style="margin: 0; padding: 0; width: 100%; height: 100%; display: none;" class="black_overlay">
        <div class="loading-indicator" style="margin-left:400px; margin-top:150px;">
            <img src="<%=QxRoom.Common.Public.RelativelyPath("images/extanim32.gif") %>" alt=""
                width="355" height="127" style="margin: 0 auto; " align="absmiddle" />
            正在获取数据,请稍候.....
        </div>
    </div>    
    <div style="float:left;width:224px;  overflow:hidden; margin:0;">
        <div>
            <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" onclick="selectCheck()"
                Height="257px" Width="142px" Target="rightFrame">
            </asp:TreeView>
        </div>
        <div>
            <asp:Button ID="btnok" runat="server" OnClick="btnok_onclick" Text="确定" />
        </div>
    </div>    
     
    </form>
</body>
</html>

