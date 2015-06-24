<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" stylesheettheme="Default" CodeBehind="CheckData.aspx.cs" inherits="PublicMode_CheckData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/Admin_Style.css" type="text/css" rel="stylesheet">

    <style type="text/css">
        #tbList tbody tr:nth-child(add) td, #tbList tbody tr:nth-child(add)th
        {
        	 background-color:Red;
        	}
    </style>

    <script type="text/javascript">
        window.name = "help";

        function openMe(val) {
            form1.type.value = val;
            form1.submit();
        }

        function openHelp(val) {
            window.returnValue = val;
            window.close();
        }

        //javascript鼠标按下弹出脚本
        function trmove(trname, i) {
            trna = eval(trname);
            trna.style.backgroundColor = "#afeeee";
        }

        function trout(trname, i) {
            trna = eval(trname);
            if (i % 2 == 0) {
                trna.style.backgroundColor = "#ffffff";
            }
            else {
                trna.style.backgroundColor = "#ffffff";
            }
        }

        function goback() {
            history.back(-1);
            //history.go(-1);
        }

        function onkeypress11(keycode) {
            if (keycode >= 48 && keycode <= 57) {
                //调用控件的 click 点击事件
                var evt = document.createEvent('HTMLEvents');
                evt.initEvent('click', true, true);
                element = document.getElementById('link_' + keycode);
                element.dispatchEvent(evt);
            }
        } //onkeypress="javascript:var keycode=event.keyCode; onkeypress11(keycode);"
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <input id="type" type="hidden" name="type">
    <div  >
        <table>
            <tr>
                <td style="height: 45px; width: 100%">
                    <asp:Table ID="tbList" runat="server" CssClass="f1" Style="width: 100%" 
                        BorderColor="#A3C0E8" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" 
                        HorizontalAlign="Center">
                        <asp:TableRow CssClass="f1" runat="server" ID="Tablerow1" NAME="Tablerow1">
                        </asp:TableRow>
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:LinkButton ID="lbUp" runat="server" OnClick="lbUp_Click">向上</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
