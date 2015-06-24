<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readinfo.aspx.cs" Inherits="readinfo"  enableEventValidation="false" stylesheettheme="Default"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
       
        function SaveCode(filename)
        {
            var win = window.open('', '_blank', 'top=100');
            var obj = document.getElementById('content_1');
            var code = obj.innerText;
            code = code == null || code == "" ? obj.value : code;
            win.opener = null;
            win.document.write(code);
            win.document.execCommand('saveas', true, filename);
            win.close();
        }
        function test2() {
            document.getElementById("btndiffs").click();
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ><div>
        
            <asp:Button ID="btndiffs" runat="server" Style="display: none" Text="Button" OnClick="btndiffs_Click" />
            <table>
                <tr>
                    <td>选择客户信息文件：</td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server"  /></td>  
                    <td style="width:150px"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td> 
                    <td rowspan="3" style='width: 300px;'>
                        <asp:Label ID="lbsn" runat="server" Text="注册码" style="text-align: center"></asp:Label>
                        <textarea id="content_1" runat="server" readonly="readonly" style="width: 480px;
            height: 100px; margin: 0 auto;">  
        </textarea> 
                    </td>
                </tr>
                <tr>
                    <td>客户行政区域编码：</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                   <td style="width:150px"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                  <td>选择到期日期：</td>
                    <td><asp:DropDownList ID="DPlist_year" runat="server" AutoPostBack="True"   Width="90px">
        </asp:DropDownList>年
        <asp:DropDownList ID="DPlist_month" runat="server" AutoPostBack="True">
        </asp:DropDownList>月
                     
                        <asp:ImageButton ID="IBTN_date" runat="server" ImageUrl="~/images/calendar.gif" OnClick="IBTN_date_Click" />
                    </td>  
                    <td style="width:150px"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style1"><asp:Button runat="server" Text="生成注册码" ID="Create_code" OnClick="Create_code_Click" /> 
                        <asp:Calendar ID="Calendar" Visible="false" runat="server"  OnSelectionChanged="Calendar_SelectionChanged" style="Z-INDEX: 101; POSITION: absolute"></asp:Calendar>

 
                    </td>
                    <td style="width:150px"><asp:HiddenField ID="hidf" runat="server" value="0" />
                    </td>
                    <td align="center" class="auto-style1">
                        <asp:Button ID="Save_code" Text="保存注册码" runat="server" OnClientClick="SaveCode('license.txt')"
                />
                        <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
       </asp:UpdatePanel>
    </form>
</body>
</html>