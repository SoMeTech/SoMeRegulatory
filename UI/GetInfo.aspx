<%@ page language="C#" autoeventwireup="true" CodeBehind="GetInfo.aspx.cs" inherits="PublicMode_DiagList_GetServerInfo" enableEventValidation="false" stylesheettheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>生成客户端信息</title>
    <style type="text/css">
        body
        {
            width: 100%;
            font-family: Arial, Helvetica, sans-serif,Verdana;
            font-size: 14px;
        }
        .snbox
        {
            border: 1px solid #ccc;
            width: 560px;
            height: 285px;
            margin: 0 auto;
            margin-top: 30px;
        }
        .titles
        {
            background-image: url('images/snbg.png' );
            background-repeat: repeat-x;
            text-align: center;
            height: 24px;
            line-height: 24px;
        }
    </style>

    <script type="text/javascript">
        // 另存为文件
        function SaveCode(filename) {
            var win = window.open('', '_blank', 'top=100');
            var obj = document.getElementById('content_1');
            var code = obj.innerText;
            code = code == null || code == "" ? obj.value : code;
            win.opener = null;
            win.document.write(code);
            win.document.execCommand('saveas', true, filename);
            win.close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" name="saveas" action="" method="post">
    <div class="snbox">
        <div class="titles">
            <asp:Label ID="Label1" runat="server" Text="生成客户端信息"></asp:Label></div>
        <textarea id="content_1" runat="server" readonly="readonly" style="width: 555px;
            height: 200px; margin: 0 auto;" onclick='SaveCode(this,"客户信息")'>  
        </textarea> 
        <br />
        <div style="text-align: center;">
            <asp:Button ID="btnCreate" runat="server" Text="生 成" OnClick="btnCreate_Click" Height="28px" 
                Width="81px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <%-- <input type="text" value="hello word" onclick='SaveCode(this,"save")' />
            <input type="button" value="保 存" height="28px" width="81px" onclick="SaveCode('客户信息.txt')" />--%>
             <asp:Button ID="btnSave" runat="server" Text="保 存" Height="28px" Width="81px" OnClientClick="SaveCode('客户信息.txt')" 
                />
            </div>
    </div>
    </form>
</body>
</html>
