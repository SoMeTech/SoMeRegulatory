<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" StylesheetTheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登陆</title>

    <script type="text/javascript">



        function openDefault() {
            window.returnValue = 'close';
            //            var iWidth = window.screen.width; //弹出窗口的宽度;
            //            var iHeight = window.screen.height ; //弹出窗口的高度;
            var iWidth = 1006; //弹出窗口的宽度;
            var iHeight = 706; //弹出窗口的高度;
            var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //获得窗口的垂直位置;
            if (iTop < 0)
                iTop = 0;
            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //获得窗口的水平位置;

            if (request('from') == 'uf') {
                var userName = request('UserName');

                newwindow = window.open("Login.aspx?from=uf&UserName=" + request('UserName') + "&Pwd=" + request('Pwd'), "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "");

            }
            else {
                newwindow = window.open("Login.aspx", "_blank", "toolbar=no,status=no,resizable=no,scrollbars=no,location=no,width=" + iWidth + ",height=" + iHeight + ",left=" + iLeft + ",top=" + iTop + "");

            }

            if (window.focus) { newwindow.focus() }
            window.open('', '_self');
            window.opener = null;
            window.close();
            return false;
        }

        function request(strParame) {
            var args = new Object();
            var query = location.search.substring(1);

            var pairs = query.split("&"); // Break at ampersand 
            for (var i = 0; i < pairs.length; i++) {
                var pos = pairs[i].indexOf('=');
                if (pos == -1) continue;
                var argname = pairs[i].substring(0, pos);
                var value = pairs[i].substring(pos + 1);
                value = decodeURIComponent(value);
                args[argname] = value;
            }
            return args[strParame];
        }


    </script>

</head>
<body onload="openDefault();">
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
