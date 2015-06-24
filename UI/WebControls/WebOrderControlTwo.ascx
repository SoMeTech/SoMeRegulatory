<%@ control language="C#" autoeventwireup="true" inherits="WebOrderControlTow" CodeBehind="WebOrderControlTwo.ascx.cs" %>

<script language="javascript">
    //验证不能输入单引号
    function onlyNum4() {
        if (event.keyCode == 222) {
            return false;
        }
        else {
            return true;
        }
    }
    function outputExcel(obj) {
        try {
            if (!isNaN(obj.outtbid)) {
                tbSaveExcel("", obj.out - tb - id, window);
            }
            else {
                var _table = document.getElementsByTagName("table");
                for (var i = 0; i < _table.length; i++) {
                    if (_table[i].id.indexOf("gvResult") != -1) {
                        var spanTitle = document.getElementById("spanTitle");
                        if (spanTitle != null && spanTitle.innerText != "")
                            tbSaveExcel(spanTitle.innerText, _table[i].id, window);
                        else
                            tbSaveExcel("Sheet1", _table[i].id, window);
                        return false;
                    }
                }
                alert("导出失败，请联系管理员！");
            }
        } catch (e) { alert(e) };
        return false;
    }
    function tbSaveExcel(SaveName, tbName, _Window) {
        try {
            var filedlg = new ActiveXObject("MSComDlg.CommonDialog");
            /*MSComDlg.CommonDialog 的方法
            ShowOpen 显示“打开”对话框 
            ShowSave 显示“另存为”对话框 
            ShowColor 显示“颜色”对话框 
            ShowFont 显示“字体”对话框 
            ShowPrinter 显示“打印”或“打印选项”对话框 
            ShowHelp 调用 Windows 帮助引擎 
            */
        } catch (e) { alert("打开系统组件出错，请运行regsvr32 comdlg32.ocx进行注册"); return; }

        try {
            var textarea = event.srcElement;
            filedlg.Filter = "*.xls|" + SaveName + ".xls";
            filedlg.FilterIndex = 1;
            filedlg.MaxFileSize = 128;
            filedlg.ShowSave();
            if (filedlg.FileName != null && filedlg.FileName != "") {
                var curTbl = _Window.document.getElementById(tbName);
                var fso, tf;
                fso = new ActiveXObject("Scripting.FileSystemObject");
                tf = fso.CreateTextFile(filedlg.FileName, true);
                tf.WriteLine(curTbl.parentNode.innerHTML);
                tf.Close();
                alert("导出成功!");
            }
        } catch (e) { alert(e); }

    }
</script>
<asp:Button ID="Button1" runat="server" Text="高级查询"  CssClass="mouthType"/>
<asp:Button ID="Button2" runat="server" Text="导出Excel"  CssClass="mouthType" />


<table border="0" cellpadding="0" cellspacing="0" style="width:auto">
    <tr>
        <td style="width: 84px">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
            </asp:DropDownList></td>
        <td style="width: 50px; text-align: right;">
            内容：</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="200px" onkeydown="return onlyNum4();" style=" border:1px solid #CCCCCC; padding:2px; background-color:#FFF;"></asp:TextBox></td>
        <td align="center" style="width: 60px; ">
            <asp:Button ID="btn_order" name="btn_order" runat="server" OnClick="btn_order_Click" Text="查询" CssClass="mouthType" /></td>
        <td align="center" style="width: 50px; ">
            <asp:Button ID="btnlike" name="btnlike" runat="server" OnClick="btnlike_Click" Text="模糊"  CssClass="mouthType"/></td>
        <td align="center" style="width: 100px; text-align:right;">
            <asp:Button ID="btnOutPut" name="btnOutPut" runat="server" Text="导出Excel"  CssClass="mouthType" /></td>
    </tr>
</table>
